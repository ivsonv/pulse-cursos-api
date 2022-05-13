using Admin.Domain.Helpers;
using Admin.Domain.Interface.Helpers;
using Admin.Domain.Interface.Integrations.Delivery;
using Admin.Domain.Models.DTO.ShoppingCart;
using Microsoft.Extensions.Configuration;

namespace Admin.Integrations.Delivery.MelhorEnvio
{
    public class MelhorEnvioClient : IDelivery
    {
        private readonly string _app_email = "";
        private readonly string _app_name = "";
        private readonly string _endpoint = "";
        private readonly string _token = "";
        private readonly IRequestHttp _http;

        public MelhorEnvioClient(IConfiguration configuration, IRequestHttp http)
        {
            _app_email = configuration.GetSection("delivery:melhor_envio:app_email").Value;
            _app_name = configuration.GetSection("delivery:melhor_envio:app_name").Value;
            _endpoint = configuration.GetSection("delivery:melhor_envio:endpoint").Value;
            _token = configuration.GetSection("delivery:melhor_envio:token").Value;
            _http = http;
        }

        /// <summary>
        /// Enviar Produtos por Vendedor
        /// </summary>
        /// <param name="cartProducts"></param>
        /// <param name="zipcode_origin"></param>
        /// <param name="zipcode_destination"></param>
        public async Task<List<DeliveryDTO>> GetCalculatePrice(List<CartProductDTO> cartProducts, string origin, string destination)
        {
            var lst = new List<DeliveryDTO>();
            try
            {
                // request melhor envio
                var _req = new Repository.CalculateRq()
                {
                    from = new Repository.CalculateFrom() { postal_code = origin }, // origem
                    to = new Repository.CalculateTo() { postal_code = destination }, // destino
                    products = cartProducts.ConvertAll(x => new Repository.CalculateProduct()
                    {
                        insurance_value = x.total_price,
                        id = x.id.ToString(),
                        height = x.height,
                        length = x.length,
                        weight = x.weight,
                        quantity = x.qtd,
                        width = x.width
                    })
                };

                // post
                var _resPOST = await _http.Post(
                    new Domain.Models.DTO.Helpers.HttpDto()
                    {
                        Url = $"{_endpoint}/api/v2/me/shipment/calculate",
                        Headers = GetHeaders(),
                        Payload = _req,
                    });

                // retorno
                if (_resPOST.HasSuccess)
                {
                    var _res = _resPOST.Data.Deserialize<List<Repository.CalculateRs>>();
                    if (_res.IsNotEmpty())
                    {
                        foreach (var item in _res)
                        {
                            if (item.error.IsEmpty())
                            {
                                var delivery = new DeliveryDTO()
                                {
                                    company_id = item.company.id.ToString(),
                                    company_image = item.company.picture,
                                    company_name = item.company.name,

                                    company_service_id = item.id.ToString(),
                                    company_service_name = item.name,
                                    delivery_time = item.delivery_time,
                                    discount = item.discount,
                                    price = item.price
                                };

                                // pacote
                                if (item.packages.IsNotEmpty())
                                {
                                    delivery.Packages = item.packages.ConvertAll(x
                                        => new DeliveryPackageDTO()
                                        {
                                            height = x.dimensions != null ? x.dimensions.height : 0,
                                            length = x.dimensions != null ? x.dimensions.length : 0,
                                            width = x.dimensions != null ? x.dimensions.width : 0,
                                            discount = x.discount,
                                            format = x.format,
                                            weight = x.weight,
                                            price = x.price,
                                            Products = x.products.IsNotEmpty()
                                            ? x.products.ConvertAll(c => new DeliveryPackageProductDTO() { id = c.id, qtd = c.quantity })
                                            : null
                                        });
                                }
                                lst.Add(delivery);
                            }
                        }
                    }
                }
                else { throw new ArgumentException(_resPOST.Data); }
            }
            catch { throw; }

            // retorno
            return lst;
        }

        private List<Domain.Models.DTO.Helpers.HeadersDto> GetHeaders()
        {
            return new List<Domain.Models.DTO.Helpers.HeadersDto>()
            {
                new Domain.Models.DTO.Helpers.HeadersDto(){ name = "Authorization", value = $"Bearer {_token}" },
                //new Domain.Models.DTO.Helpers.HeadersDto(){ name = "Content-Type", value = "application/json" },
                //new Domain.Models.DTO.Helpers.HeadersDto(){ name = "User-Agent", value = $"{_app_name} {_app_email}" }
            };
        }
    }
}