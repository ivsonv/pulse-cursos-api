namespace Admin.Integrations.Payment.Juno.repository.webhook
{
    public class WebhookRQ
    {
        public string url { get; set; }
        public List<string> eventTypes { get; set; }
    }
}