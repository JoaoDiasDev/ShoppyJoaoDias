using System.Net.Http.Headers;

namespace ShopJoaoDias.Helpers
{
    public class UploadHelper
    {
        private IWebHostEnvironment _environment;
        public UploadHelper(IWebHostEnvironment hosting)
        {
            _environment = hosting;
        }

        public async Task<string> Upload(IFormFile file, string folder = null)
        {
            var result = "";
            if (file.Length > 0)
            {
                try
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName?.Trim('"');
                    var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                    var fileExtension = Path.GetExtension(fileName);
                    var folderPath = folder == null
                        ? Path.Combine(_environment.WebRootPath + "/upload/")
                        : Path.Combine(_environment.WebRootPath + "/upload/" + folder + "/");
                    var directory = Directory.CreateDirectory(folderPath);
                    if (!directory.Exists)
                    {
                        directory.Create();
                    }
                    var newFileName = myUniqueFileName + fileExtension;
                    fileName = Path.Combine(folderPath + newFileName);
                    await using (var fileStream = File.Create(fileName))
                    {
                        await file.CopyToAsync(fileStream);
                        await fileStream.DisposeAsync();
                    }
                    result = newFileName;
                }
                catch (Exception e)
                {
                    throw new ArgumentException(e.Message);
                }
            }

            return result;
        }
    }
}
