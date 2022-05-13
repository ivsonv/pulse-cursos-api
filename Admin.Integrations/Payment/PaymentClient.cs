using Microsoft.Extensions.Configuration;

using Admin.Domain.Interface.Helpers;
using Admin.Domain.Interface.Integrations.Payment;
using Admin.Domain.Helpers;
using Admin.Domain.Models.DTO.Integrations.Payment;

namespace Admin.Integrations.Payment
{
    public class PaymentClient : IPayment
    {
        private IPaymentProviderIntegrations _provider;
        private readonly IConfiguration _configuration;
        private readonly IRequestHttp _http;

        public PaymentClient(
            IConfiguration configuration,
            IRequestHttp http)
        {
            _configuration = configuration;
            _http = http;
        }

        public async Task Buy(Enumerados.PaymentProvider _client)
        {
            // Define
            _provider = GetProvider(_client);

            // Payment
            await _provider.Buy();
        }


        public async Task CreateAccountEstablishment(Enumerados.PaymentProvider _client, AccountEstablishmentDTO dto)
        {
            // Define
            _provider = GetProvider(_client);

            // create
            await _provider.CreateAccountEstablishment(dto);
        }

        public async Task GetAccountEstablishment(Enumerados.PaymentProvider _client, AccountEstablishmentDTO dto)
        {
            // define
            _provider = GetProvider(_client);

            // get account
            await _provider.GetAccountEstablishment(dto);
        }

        public async Task CreateAccountWebHook(Enumerados.PaymentProvider _client, AccountEstablishmentDTO dto)
        {
            // define
            _provider = GetProvider(_client);

            // get account
            await _provider.CreateWebhookAccount(dto);
        }

        public async Task<string> SendDocumentsAccountEstablishment(Enumerados.PaymentProvider _client, AccountEstablishmentDTO dto)
        {
            // define
            _provider = GetProvider(_client);

            // send documents account
            return await _provider.SendDocumentsAccountEstablishment(dto);
        }


        private IPaymentProviderIntegrations GetProvider(Enumerados.PaymentProvider provider)
        {
            switch (provider)
            {
                case Enumerados.PaymentProvider.juno:
                    return new Juno.JunoClient(_configuration, _http);

                default:
                    throw new ArgumentException("Provedor de pagamento não disponivel.");
            }
        }
    }
}
