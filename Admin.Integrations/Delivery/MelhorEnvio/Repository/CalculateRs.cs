namespace Admin.Integrations.Delivery.MelhorEnvio.Repository
{
    public class CalculateRs
    {
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public double custom_price { get; set; }
        public double discount { get; set; }
        public string currency { get; set; }
        public int delivery_time { get; set; }
        public CalculateRsDeliveryRange delivery_range { get; set; }
        public int custom_delivery_time { get; set; }
        public CalculateDeliveryRange custom_delivery_range { get; set; }
        public List<CalculatePackage> packages { get; set; }
        public CalculateAdditionalServices additional_services { get; set; }
        public CalculateCompany company { get; set; }
        public string error { get; set; }
    }

    public class CalculateRsDeliveryRange
    {
        public int min { get; set; }
        public int max { get; set; }
    }

    public class CalculateDeliveryRange
    {
        public int min { get; set; }
        public int max { get; set; }
    }

    public class CalculateDimensions
    {
        public int height { get; set; }
        public int width { get; set; }
        public int length { get; set; }
    }

    public class CalculateRsProduct
    {
        public string id { get; set; }
        public int quantity { get; set; }
    }

    public class CalculatePackage
    {
        public double price { get; set; }
        public double discount { get; set; }
        public string format { get; set; }
        public CalculateDimensions dimensions { get; set; }
        public double weight { get; set; }
        public double insurance_value { get; set; }
        public List<CalculateRsProduct> products { get; set; }
    }

    public class CalculateAdditionalServices
    {
        public bool receipt { get; set; }
        public bool own_hand { get; set; }
        public bool collect { get; set; }
    }

    public class CalculateCompany
    {
        public int id { get; set; }
        public string name { get; set; }
        public string picture { get; set; }
    }

}
