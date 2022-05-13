using Admin.Domain.Helpers;
using Admin.Domain.Interface.Helpers;
using Admin.Domain.Interface.Integrations.Payment;
using Admin.Domain.Models.DTO.Helpers;
using Admin.Domain.Models.DTO.Integrations.Payment;
using Admin.Integrations.Payment.Juno.repository.digital_account;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace Admin.Integrations.Payment.Juno
{
    public class JunoClient : IPaymentProviderIntegrations
    {
        private repository.auth.AuthRS junoAuth = null;
        private readonly string apiVersion = "2";
        private readonly string _client_secret = "";
        private readonly string _client_id = "";
        private readonly string _endpoint = "";
        private readonly string _webhook = "";
        private readonly string _resource_token = ""; // conta master

        public JunoClient(IConfiguration configuration, IRequestHttp http)
        {
            _resource_token = configuration.GetSection("payment:juno:x_resource_token").Value;
            _client_secret = configuration.GetSection("payment:juno:client_secret").Value;
            _client_id = configuration.GetSection("payment:juno:client_id").Value;
            _endpoint = configuration.GetSection("payment:juno:endpoint").Value;
            _webhook = configuration.GetSection("payment:webhook").Value;
        }

        public Task Buy()
        {
            throw new NotImplementedException();
        }

        public Task CreateAccountEstablishment(AccountEstablishmentDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task GetAccountEstablishment(AccountEstablishmentDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task CreateWebhookAccount(AccountEstablishmentDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<string> SendDocumentsAccountEstablishment(AccountEstablishmentDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
