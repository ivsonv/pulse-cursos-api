namespace Admin.Integrations.Payment.Juno.repository.documents
{
    public class DocumentsRQ
    {
        public string type { get; set; }
        public bool emailOptOut { get; set; } = true;
        public string returnUrl { get; set; }
        public string refreshUrl { get; set; }
    }
}
