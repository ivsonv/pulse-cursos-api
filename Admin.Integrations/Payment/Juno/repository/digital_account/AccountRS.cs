namespace Admin.Integrations.Payment.Juno.repository.digital_account
{
    public class AccountRS
    {
        public string id { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public string personType { get; set; }
        public string document { get; set; }
        public DateTime createdOn { get; set; }
        public string resourceToken { get; set; }
        public long accountNumber { get; set; }
    }
}