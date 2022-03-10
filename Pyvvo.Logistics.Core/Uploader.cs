using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Auth;
using Microsoft.Azure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Core
{
    public class Uploader:ICoreUploader
    {
        private readonly IcoreImage _image;
        public Uploader(IcoreImage image)
        {
             _image=image;
        }

        public async Task<List<Uri>> GetBlobs()
        {
            var accountName = Properties.Resources.AzureStorageAccount;
            var accountKey = Properties.Resources.AzureStorageAccountKey;
            var storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, accountKey), true);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(Properties.Resources.AzureStorageContainer);
            await container.SetPermissionsAsync(new BlobContainerPermissions{
                PublicAccess = BlobContainerPublicAccessType.Blob
            });
            BlobContinuationToken blobContinuationToken = null;
            List<Uri> allBlobs = new List<Uri>();
            do
            {
                var results = await container.ListBlobsSegmentedAsync(blobContinuationToken);
                foreach (IListBlobItem blob in results.Results)
                {
                    if (blob.GetType() == typeof(CloudBlockBlob))
                        allBlobs.Add(blob.Uri);
                }
                blobContinuationToken = results.ContinuationToken;
            } while (blobContinuationToken != null);
            return allBlobs;
        }

        public async Task<Uri> GetBlob(string filename)
        {
            var accountName = Properties.Resources.AzureStorageAccount;
            var accountKey = Properties.Resources.AzureStorageAccountKey;
            var storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, accountKey), true);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(Properties.Resources.AzureStorageContainer);
            await container.SetPermissionsAsync(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });
            CloudBlockBlob blob = container.GetBlockBlobReference(filename);
            return blob.Uri;
        }

        public async Task<Uri> UploadBlob(IFormFile file,long userId)
        {

            try
            {
                if (file == null) return null;
                string filename = string.Concat(Properties.Resources.AzureStorageContainer+"-", Guid.NewGuid());
                string extension = Path.GetExtension(file.FileName);
                filename += extension;
                string contentType = "application/octet-stream";
                SetContentType(extension, contentType);
                var accountName = Properties.Resources.AzureStorageAccount;
                var accountKey = Properties.Resources.AzureStorageAccountKey;
                var storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, accountKey), true);
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference(Properties.Resources.AzureStorageContainer);
                CloudBlockBlob blob = container.GetBlockBlobReference(filename);
                blob.Properties.ContentType = contentType;
                using (Stream stream = file.OpenReadStream())
                {
                    await blob.UploadFromStreamAsync(stream);
                    stream.Close();
                }
                await container.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
                if (blob.Uri != null)
                {
                    Model.Image image = new Model.Image()
                    {
                        CreatedOn = DateTime.Now,
                        UpdatedOn = DateTime.Now,
                        Extension = extension,
                        FileName = filename,
                        IsActive = true,
                        PathUrl = blob.Uri.ToString()
                    };
                   await _image.Create(image, userId);
                }
                return blob.Uri;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteBlob(string filename)
        {
            try
            {
                var image = await _image.Get(filename);
                if (image != null)
                {
                    var accountName = Properties.Resources.AzureStorageAccount;
                    var accountKey = Properties.Resources.AzureStorageAccountKey;
                    var storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, accountKey), true);
                    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                    CloudBlobContainer container = blobClient.GetContainerReference(Properties.Resources.AzureStorageContainer);
                    CloudBlockBlob blob = container.GetBlockBlobReference(image.FileName);
                    await blob.DeleteAsync();
                    await _image.Delete(image.FileName);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string SetContentType(string extension, string contentType)
        {
            switch (extension)
            {
                case ".svg":
                    contentType = "image/svg+xml";
                    break;
                case ".png":
                    contentType = "image/png";
                    break;
                case ".jpg":
                    contentType = "image/jpeg";
                    break;
                case ".jpeg":
                    contentType = "image/jpeg";
                    break;
            }
            return contentType;
        }
    }
}
