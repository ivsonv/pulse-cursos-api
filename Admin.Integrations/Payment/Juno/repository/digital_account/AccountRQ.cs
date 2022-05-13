namespace Admin.Integrations.Payment.Juno.repository.digital_account
{
    public class AccountRQ
    {
        public string type { get; set; } = "PAYMENT";
        public string name { get; set; }
        //public string motherName { get; set; }
        public int monthlyIncomeOrRevenue { get; set; }
        public string document { get; set; }
        public string birthDate { get; set; }
        public string email { get; set; }
        public int businessArea { get; set; }
        public string phone { get; set; }
        public string linesOfBusiness { get; set; }
        public bool emailOptOut { get; set; }
        public string cnae { get; set; }
        public string companyType { get; set; }

        /// <summary>
        /// Data abertura da Empresa
        /// </summary>
        public string establishmentDate { get; set; }

        /// <summary>
        /// politicamente exposta
        /// </summary>
        public bool pep { get; set; }

        public AccountLegalRepresentative legalRepresentative { get; set; }
        public AccountAddress address { get; set; }
        public AccountBankAccount bankAccount { get; set; }
    }

    public enum AccountLegalRepresentativeEnum
    {
        INDIVIDUAL, ATTORNEY, DESIGNEE, MEMBER, DIRECTOR,
        PRESIDENT
    }

    public enum AccountCompanyType
    {
        MEI, EI, EIRELI, LTDA, SA,
        INSTITUITION_NGO_ASSOCIATION
    }

    public class AccountLegalRepresentative
    {
        public string name { get; set; }
        public string document { get; set; }
        public string birthDate { get; set; }
        public string motherName { get; set; }
        public string type { get; set; }

    }

    public class AccountCompanyMembers
    {
        public string name { get; set; }
        public string document { get; set; }
        public string birthDate { get; set; }
    }

    public class AccountAddress
    {
        public string street { get; set; }
        public string number { get; set; }
        public string complement { get; set; }
        public string neighborhood { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postCode { get; set; }
    }

    public class AccountBankAccount
    {
        public string bankNumber { get; set; }
        public string agencyNumber { get; set; }
        public string accountNumber { get; set; }
        public string accountType { get; set; }
        public string accountComplementNumber { get; set; }
        public accountHolder accountHolder { get; set; }
    }

    public class accountHolder
    {
        public string name { get; set; }
        public string document { get; set; }
    }
}