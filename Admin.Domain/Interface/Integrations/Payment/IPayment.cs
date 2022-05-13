using Admin.Domain.Models.DTO.Integrations.Payment;

namespace Admin.Domain.Interface.Integrations.Payment
{
    public interface IPayment
    {
        Task<string> SendDocumentsAccountEstablishment(Domain.Helpers.Enumerados.PaymentProvider _client, AccountEstablishmentDTO dto);
        Task CreateAccountEstablishment(Domain.Helpers.Enumerados.PaymentProvider _client, AccountEstablishmentDTO dto);
        Task GetAccountEstablishment(Domain.Helpers.Enumerados.PaymentProvider _client, AccountEstablishmentDTO dto);
        Task CreateAccountWebHook(Domain.Helpers.Enumerados.PaymentProvider _client, AccountEstablishmentDTO dto);

        Task Buy(Domain.Helpers.Enumerados.PaymentProvider provider);
    }
}