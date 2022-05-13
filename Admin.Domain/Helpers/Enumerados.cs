using System.ComponentModel.DataAnnotations;

namespace Admin.Domain.Helpers
{
    public static class Enumerados
    {
        public enum CategoryType
        {
            [Display(Name = "Não Definido")]
            undefined = 0,

            [Display(Name = "Menu Superior")]
            home_top = 1,

            [Display(Name = "Home")]
            home_middle = 1,
        }

        public enum CouponAmountType
        {
            [Display(Name = "Monetario")]
            monetary = 0,

            [Display(Name = "Percentual")]
            percentage = 1,
        }

        public enum PaymentType
        {
            [Display(Name = "Pix")]
            pix = 0,

            [Display(Name = "Boleto")]
            boleto = 1,

            [Display(Name = "Cartão de crédito")]
            creditcard = 2,

            [Display(Name = "Cartão de débito")]
            debitcard = 3,

            [Display(Name = "Transferencia")]
            transfer = 4
        }

        public enum PaymentStatus
        {
            [Display(Name = "Aguardando Pagamento")]
            awaiting = 0,

            [Display(Name = "Confirmado")]
            confirmed = 1,

            [Display(Name = "Cancelado")]
            cancelled = 2,

            [Display(Name = "Estornado")]
            reversed = 3
        }

        public enum PaymentProvider
        {
            juno = 0,
            pagarme = 1,
            pagSeguro = 2,
        }

        public enum CardBrand
        {
            [Display(Name = "Mastercard")]
            mastercard = 0,

            [Display(Name = "Visa")]
            visa = 1,

            [Display(Name = "Dinners")]
            dinners = 2,

            [Display(Name = "American Express")]
            american_express = 3,

            [Display(Name = "Hiper")]
            hiper = 4,

            [Display(Name = "Hipercard")]
            hipercard = 5,

            [Display(Name = "Elo")]
            Elo = 6
        }

        public enum StoragePolice
        {
            PublicRead = 0,
            PublicReadWrite = 1,
            AuthenticatedRead = 2,
            Private = 3,
            NoPolicy = 4
        }

        public enum AccountBankType
        {
            [Display(Name = "Conta Corrente")]
            account_checking = 0, // corrente

            [Display(Name = "Poupança")]
            account_deposit = 1, // poupança
        }

        public enum AuthUserType
        {
            [Display(Name = "Administrador")]
            admin,

            [Display(Name = "Cliente")]
            customer,

            [Display(Name = "Parceiro")]
            partners
        }

        public enum Billed
        {
            [Display(Name = "Cliente")]
            customer = 0,

            [Display(Name = "Parceiro")]
            partner = 1,

            [Display(Name = "Website")]
            website = 2
        }

        public enum StatusSales
        {
            [Display(Name = "Aguardando Envio")]
            waiting_sent = 0,

            [Display(Name = "Enviado")]
            sent = 1,

            [Display(Name = "Entregue")]
            delivered = 2,

            [Display(Name = "Aguardando Devolução")]
            devolution = 3,

            [Display(Name = "Devolvida")]
            returned = 4,

            [Display(Name = "Cancelada")]
            canceled = 5,

            [Display(Name = "Estornado")]
            reversal = 6
        }
    }
}