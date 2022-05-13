using Admin.Domain.Helpers;
using Admin.Domain.Models.DTO.Storage;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Configuration;

namespace Admin.Integrations.Storage.Amazon
{
    public class ClientStorageAmazon : Domain.Interface.Integrations.Storage.IStorage
    {
        private readonly IConfiguration _configuration;
        private IAmazonS3 _amazon = null;
        private RegionEndpoint _region;
        private string _bucket;
        public ClientStorageAmazon(IConfiguration configuration)
        {
            _configuration = configuration;
            this.init();
        }

        private void init(StorageDTO dto = null)
        {
            if (dto == null) dto = new StorageDTO();

            // Load default            
            dto.secretaccesskey = dto.secretaccesskey ?? _configuration["s3:secretaccesskey"];
            dto.accesskeyid = dto.accesskeyid ?? _configuration["s3:accesskeyid"];
            dto.bucket = dto.bucket ?? _configuration["s3:bucket"];
            dto.region = dto.region ?? _configuration["s3:region"];

            // inicializar
            _bucket = dto.bucket;
            switch (dto.region)
            {
                case "sa-east-1": _region = RegionEndpoint.SAEast1; break;
                default: _region = RegionEndpoint.USEast1; break;
            }

            _amazon = new AmazonS3Client(awsSecretAccessKey: dto.secretaccesskey,
                                         awsAccessKeyId: dto.accesskeyid,
                                         region: _region);
        }

        public async Task Remove(StorageDTO dto)
        {
            this.init(dto);

            await _amazon.DeleteObjectAsync(new DeleteObjectRequest()
            {
                BucketName = dto.bucket,
                Key = dto.key
            });
        }
        public async Task Remove(string key)
        {
            await _amazon.DeleteObjectAsync(new DeleteObjectRequest()
            {
                BucketName = _bucket,
                Key = key
            });
        }

        public string Assign(StorageDTO dto)
        {
            this.init(dto);

            return _amazon.GetPreSignedURL(new GetPreSignedUrlRequest
            {
                Expires = DateTime.UtcNow.AddMinutes(dto.expire ?? 60),
                BucketName = dto.bucket,
                Key = dto.key
            });
        }
        public string Assign(string key, int expire = 60)
        {
            return _amazon.GetPreSignedURL(new GetPreSignedUrlRequest
            {
                Expires = DateTime.UtcNow.AddMinutes(expire),
                BucketName = _bucket,
                Key = key
            });
        }

        public async Task Upload(StorageDTO dto)
        {
            this.init(dto);

            // upload
            await _amazon.PutObjectAsync(new PutObjectRequest()
            {
                CannedACL = GetPoliceACL(dto.police),
                BucketName = dto.bucket,
                InputStream = dto.file,
                Key = dto.key
            });
        }
        public async Task Upload(string key, Stream file, Enumerados.StoragePolice police)
        {
            await _amazon.PutObjectAsync(new PutObjectRequest()
            {
                CannedACL = GetPoliceACL(police),
                BucketName = _bucket,
                InputStream = file,
                Key = key
            });
        }
        private S3CannedACL GetPoliceACL(Enumerados.StoragePolice police)
        {
            switch (police)
            {
                case Enumerados.StoragePolice.PublicRead: return S3CannedACL.PublicRead;
                case Enumerados.StoragePolice.PublicReadWrite: return S3CannedACL.PublicReadWrite;
                case Enumerados.StoragePolice.Private: return S3CannedACL.Private;
                default: return S3CannedACL.NoACL;
            }
        }
    }
}