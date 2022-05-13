namespace Admin.Domain.Models.DTO.ShoppingCart
{
    public class ShoppingCartDTO
    {
        public CartCustomerDTO Customer { get; set; }

        public List<CartProductDTO> Products { get; set; }
    }

    public class CartProductDTO
    {
        public long id { get; set; }
        public string name { get; set; }
        public string link { get; set; }
        public double price { get; set; }
        public double total_price { get; set; }
        public double? discount { get; set; }
        public bool free_shipping { get; set; }

        /// <summary>
        /// Quantidade de produtos que o cliente selecionou
        /// </summary>
        public int qtd { get; set; }

        /// <summary>
        /// largura em centimentros
        /// </summary>
        public int width { get; set; }

        /// <summary>
        /// altura em centimentros
        /// </summary>
        public int height { get; set; }

        /// <summary>
        /// tamanho em centimentros
        /// </summary>
        public int length { get; set; }

        /// <summary>
        /// peso em kg
        /// </summary>
        public double weight { get; set; }

        public int partner_id { get; set; }
    }

    public class CartCustomerDTO
    {
        public long? id { get; set; }
        public string zipcode { get; set; }

    }
}