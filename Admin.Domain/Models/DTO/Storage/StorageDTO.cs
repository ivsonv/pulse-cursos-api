namespace Admin.Domain.Models.DTO.Storage
{
    public class StorageDTO
    {
        public string key { get; set; } = null;
        public string bucket { get; set; } = null;
        public string region { get; set; } = null;
        public Stream file { get; set; } = null;
        public string accesskeyid { get; set; } = null;
        public string secretaccesskey { get; set; } = null;
        public Domain.Helpers.Enumerados.StoragePolice police { get; set; } = Domain.Helpers.Enumerados.StoragePolice.NoPolicy;

        /// <summary>
        /// Tempo Expiração em minutos
        /// </summary>
        public int? expire { get; set; } = null;
    }
}
