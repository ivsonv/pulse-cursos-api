namespace Admin.Domain.Interface.Integrations.Geography
{
    public interface IGeography
    {
        Task<Models.DTO.AddressDto> GetAddress(string zipcode);
    }
}