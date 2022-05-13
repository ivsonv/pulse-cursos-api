namespace Admin.Integrations.Geographic.ViaCep.repository
{
    public class ViaCepRs
    {
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public string ibge { get; set; }
        public string siafi { get; set; }
    }
}