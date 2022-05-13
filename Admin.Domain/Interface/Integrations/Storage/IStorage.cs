namespace Admin.Domain.Interface.Integrations.Storage
{
    public interface IStorage
    {
        Task Remove(Models.DTO.Storage.StorageDTO dto);
        Task Remove(string key);

        Task Upload(Models.DTO.Storage.StorageDTO dto);
        Task Upload(string key, Stream file, Domain.Helpers.Enumerados.StoragePolice police);

        string Assign(Models.DTO.Storage.StorageDTO dto);
        string Assign(string key, int expire = 60);
    }
}