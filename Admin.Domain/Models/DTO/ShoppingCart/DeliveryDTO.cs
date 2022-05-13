namespace Admin.Domain.Models.DTO.ShoppingCart
{
    public class DeliveryDTO
    {
        public string company_service_name { get; set; }
        public string company_service_id { get; set; }

        public string company_image { get; set; }
        public string company_name { get; set; }
        public string company_id { get; set; }

        public double price { get; set; }
        public double discount { get; set; }

        /// <summary>
        /// Quantidade de dias
        /// </summary>
        public int delivery_time { get; set; }


        public List<DeliveryPackageDTO> Packages { get; set; }
    }

    public class DeliveryPackageDTO
    {
        public double price { get; set; }
        public double discount { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        public int length { get; set; }
        public double weight { get; set; }
        public string format { get; set; }

        public List<DeliveryPackageProductDTO> Products { get; set; }
    }

    public class DeliveryPackageProductDTO
    {
        public string id { get; set; }
        public int qtd { get; set; }
    }
}