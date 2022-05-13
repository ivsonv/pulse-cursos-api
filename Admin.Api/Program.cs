using Admin.Application.Services;
using Admin.Domain.Helpers;
using Admin.Domain.Interface.Cache;
using Admin.Domain.Interface.Entities;
using Admin.Domain.Interface.Helpers;
using Admin.Domain.Interface.Integrations.Delivery;
using Admin.Domain.Interface.Integrations.Geography;
using Admin.Domain.Interface.Integrations.Payment;
using Admin.Domain.Interface.Integrations.Storage;
using Admin.Domain.Interface.Services;
using Admin.Infra.Repository;
using Admin.Infra.Repository.Base;
using Admin.Integrations.Storage.Amazon;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.IO.Compression;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("website", new OpenApiInfo { Title = "API - WebSite Admin" });
    //c.SwaggerDoc("customer", new OpenApiInfo { Title = "API - Clientes Admin" });
    //c.SwaggerDoc("partner", new OpenApiInfo { Title = "API - Parceiros Admin" });
    //c.SwaggerDoc("payment", new OpenApiInfo { Title = "API - Pagamentos Admin" });
    //c.SwaggerDoc("webhook", new OpenApiInfo { Title = "API - Web hook Admin" });
    //c.SwaggerDoc("ecommerce", new OpenApiInfo { Title = "API -  Ecommerce" });

    //c.SwaggerDoc("account-partner", new OpenApiInfo { Title = "API - Parceiro" });
    //c.SwaggerDoc("account-customer", new OpenApiInfo { Title = "API - Cliente" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n " +
        "Enter 'Bearer'[space] and then your token in the text input below.\r\n\r\n" +
        "Example: \"Bearer 12345abcdef\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

// custom
builder.Services.AddMvc().AddNewtonsoftJson(op =>
{
    op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    op.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
});

// comprimir json com https
builder.Services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Fastest);
builder.Services.AddResponseCompression(options =>
{
    options.Providers.Add<GzipCompressionProvider>();
    options.EnableForHttps = true;
});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// banco de dados
builder.Services.AddDbContext<Admin.Infra.AdminContext>(opt =>
                     opt.UseNpgsql(
                         builder.Configuration.GetSection("connectionstrings:database").Value,
                         x => x.MigrationsAssembly("Admin.Infra")));

// base
builder.Services.AddScoped<AuthenticatedUser>(); // compartilhar usuario logado entre as camadas.
builder.Services.AddScoped(typeof(BaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<ICache, Admin.Infra.Cache.Cache>();
builder.Services.AddScoped<IGeography, Admin.Integrations.Geographic.ViaCep.ViaCepClient>();
builder.Services.AddScoped<IRequestHttp, Admin.Domain.Helpers.RequestHttp>();
builder.Services.AddScoped<IDelivery, Admin.Integrations.Delivery.MelhorEnvio.MelhorEnvioClient>();
builder.Services.AddScoped<IPayment, Admin.Integrations.Payment.PaymentClient>();
//builder.Services.AddScoped<Admin.Application.Services.Payment.PaymentService>();

// repository individual
builder.Services.AddScoped<IWebSiteUserRepository, WebSiteUserRepository>();
builder.Services.AddScoped<IWebSiteCategoryRepository, WebSiteCategoryRepository>();
builder.Services.AddScoped<IWebSiteGroupPermissionRepository, WebSiteGroupPermissionRepository>();
builder.Services.AddScoped<IWebSiteCarouselRepository, WebSiteCarouselRepository>();
builder.Services.AddScoped<IWebSiteFaqRepository, WebSiteFaqRepository>();
builder.Services.AddScoped<IWebSiteFaqQuestionRepository, WebSiteFaqQuestionRepository>();

//builder.Services.AddScoped<IWebSiteContractorRepository, WebSiteContractorRepository>();
//builder.Services.AddScoped<IPartnerRepository, PartnerRepository>();
//builder.Services.AddScoped<IPartnerAddressRepository, PartnerAddressRepository>();
//builder.Services.AddScoped<IPartnerBankAccountRepository, PartnerBankAccountRepository>();
//builder.Services.AddScoped<IPartnerProductRepository, PartnerProductRepository>();
//builder.Services.AddScoped<IPartnerProductImagemRepository, PartnerProductImagemRepository>();
//builder.Services.AddScoped<IPartnerSplitAccountRepository, PartnerAccountSplitRepository>();

//builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
//builder.Services.AddScoped<ICustomerFavoriteRepository, CustomerFavoriteRepository>();
//builder.Services.AddScoped<ICustomerReviewRepository, CustomerReviewRepository>();

// services individual
builder.Services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));

//builder.Services.AddScoped<EmailService>();
builder.Services.AddScoped<IStorage, ClientStorageAmazon>();
builder.Services.AddScoped<WebSiteCategoryService>();
builder.Services.AddScoped<WebSiteGroupPermissionService>();
builder.Services.AddScoped<WebSiteUserService>();
builder.Services.AddScoped<WebSiteCarouselService>();
builder.Services.AddScoped<WebSiteFaqQuestionService>();
builder.Services.AddScoped<WebSiteFaqService>();


// Token JWT
var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("secrets:signingkey").Value);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        ValidateIssuer = false
    };
});

var app = builder.Build();

//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint($"/swagger/website/swagger.json", "API BACKOFFICE");
        //c.SwaggerEndpoint($"/swagger/ecommerce/swagger.json", "API Ecommerce");
        //c.SwaggerEndpoint($"/swagger/account-customer/swagger.json", "API AREA DO ALUNO");
    });
}

app.UseHttpsRedirection();
app.MapControllers();

// cors
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseResponseCompression();

app.UseAuthentication();
app.UseAuthorization();

app.Run();