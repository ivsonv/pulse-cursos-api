using Admin.Domain.Helpers;
using Admin.Domain.Interface.Helpers;
using Admin.Domain.Models.DTO;

namespace Admin.Integrations.Geographic.ViaCep
{
    public class ViaCepClient : Domain.Interface.Integrations.Geography.IGeography
    {
        private readonly IRequestHttp _http;

        public ViaCepClient(IRequestHttp http)
        {
            _http = http;
        }

        public async Task<AddressDto> GetAddress(string zipcode)
        {
            zipcode = string.Join("", zipcode.ToCharArray().Where(Char.IsDigit));
            if (zipcode.IsNotEmpty())
            {
                string endpoint = string.Format("https://viacep.com.br/ws/{0}/json/", zipcode);
                var res = await _http.Get(endpoint);

                if (res.HasSuccess && res.Data.IsNotEmpty())
                {
                    var viaCepRS = res.Data.Deserialize<repository.ViaCepRs>();
                    return new AddressDto()
                    {
                        zipcode = viaCepRS.cep.clearMask(),
                        complement = viaCepRS.complemento,
                        neighborhood = viaCepRS.bairro,
                        address = viaCepRS.logradouro,
                        city = viaCepRS.localidade,
                        siafi = viaCepRS.siafi,
                        ibge = viaCepRS.ibge,
                        uf = viaCepRS.uf,
                        country = "BR"
                    };
                }
            }
            return null;
        }

    }

}