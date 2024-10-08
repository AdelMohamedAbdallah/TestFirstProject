using Microsoft.AspNetCore.Http;

namespace Project.BLL.Helper
{
    public static class FileServices
    {
        public static string UploadFile(this IFormFile formFile, string foldername)
        {
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", foldername);

            var filename = Guid.NewGuid() + Path.GetFileName(formFile.FileName);

            var fullpath = Path.Combine(filepath, filename);

            using (var streem = new FileStream(fullpath, FileMode.Create))
            {
                formFile.CopyTo(streem);
            }

            return filename;
        }

        public static string RemoveFile(this IFormFile formFile, string foldername)
        {
            try
            {
                var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", foldername, formFile.FileName);
                if (File.Exists(filepath))
                {
                    File.Delete(filepath);
                }
                return "File Not Found";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }





    }
}
