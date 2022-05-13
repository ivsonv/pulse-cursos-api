using Admin.Domain.Models.DTO.ShoppingCart;

namespace Admin.Domain.Interface.Integrations.Delivery
{
    public interface IDelivery
    {
        Task<List<DeliveryDTO>> GetCalculatePrice(List<CartProductDTO> cartProducts, string zipcode_origin, string zipcode_destination);
    }
}
