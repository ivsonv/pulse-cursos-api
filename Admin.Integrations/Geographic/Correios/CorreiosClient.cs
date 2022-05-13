using Admin.Domain.Helpers;
using Admin.Domain.Models.DTO;

namespace Admin.Integrations.Geographic.Correios
{
    public class ClientGeographicCorreios : Domain.Interface.Integrations.Geography.IGeography
    {
        public async Task<AddressDto> GetAddress(string zipcode)
        {
            zipcode = string.Join("", zipcode.ToCharArray().Where(Char.IsDigit));
            if (zipcode.IsNotEmpty())
            {
                using (var _client = new ServiceReference1.AtendeClienteClient())
                {
                    var res = await _client.consultaCEPAsync(zipcode);
                    if(res != null && res.@return != null)
                    {
                        return new AddressDto()
                        {   
                            neighborhood = res.@return.bairro.RemoveAccents().Trim(),
                            address = res.@return.end.RemoveAccents().Trim(),
                            city = res.@return.cidade.RemoveAccents().Trim(),
                            uf = res.@return.uf.ToUpper().Trim(),
                            zipcode = res.@return.cep.Trim(),
                            country = "BR"
                        };
                    }
                }
            }
            return null;
        }
    }
}