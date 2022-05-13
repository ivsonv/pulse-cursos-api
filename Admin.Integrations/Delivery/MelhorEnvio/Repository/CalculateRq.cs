namespace Admin.Integrations.Delivery.MelhorEnvio.Repository
{
    public class CalculateRq
    {
        public CalculateFrom from { get; set; }
        public CalculateTo to { get; set; }
        public List<CalculateProduct> products { get; set; }

    }
    public class CalculateProduct
    {
        public string id { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int length { get; set; }
        public double weight { get; set; }
        public double insurance_value { get; set; }
        public int quantity { get; set; }
    }

    public class CalculateFrom
    {
        public string postal_code { get; set; }
    }

    public class CalculateTo
    {
        public string postal_code { get; set; }
    }
}
