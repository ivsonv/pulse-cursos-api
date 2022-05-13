using Admin.Domain.Models.DTO.Integrations.Payment;

namespace Admin.Domain.Interface.Integrations.Payment
{
    public interface IPaymentProviderIntegrations
    {
        Task Buy();

        Task CreateAccountEstablishment(AccountEstablishmentDTO dto);
        Task GetAccountEstablishment(AccountEstablishmentDTO dto);
        Task CreateWebhookAccount(AccountEstablishmentDTO dto);
        Task<string> SendDocumentsAccountEstablishment(AccountEstablishmentDTO dto);
    }
}
