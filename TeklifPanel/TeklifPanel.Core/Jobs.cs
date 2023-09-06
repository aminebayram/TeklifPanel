using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeklifPanel.Core
{
    public static class Jobs
    {
        public const string ImageRoute = "/Content/images/C";
        public static string UploadImage(IFormFile file, string url, int companyId)
        {
            var extension = Path.GetExtension(file.FileName);
            var randomName = $"{url}-{Guid.NewGuid()}{extension}";

            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Content/images/C" + companyId);
            Directory.CreateDirectory(folderPath); // Klasörü oluşturur

            var path = Path.Combine(folderPath, randomName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return randomName;
        }

        public static string MakeUrl(string url)
        {
            url = url.Replace("I", "i");
            url = url.Replace("İ", "i");
            url = url.Replace("ı", "i");

            url = url.ToLower();

            url = url.Replace("ö", "o");
            url = url.Replace("ü", "u");
            url = url.Replace("ğ", "g");
            url = url.Replace("ç", "c");
            url = url.Replace("ş", "s");

            url = url.Replace("/", "");
            url = url.Replace("\\", "");
            url = url.Replace(".", "");
            url = url.Replace(" ", "-");

            return url;
        }

        public static string MakeUserName(string userName)
        {
            userName = userName.Replace("ı", "i");
            userName = userName.Replace("ö", "o");
            userName = userName.Replace("ü", "u");
            userName = userName.Replace("ğ", "g");
            userName = userName.Replace("ç", "c");
            userName = userName.Replace("ş", "s");

            userName = userName.ToUpper();

            userName = userName.Replace("İ", "I");
            userName = userName.Replace("Ö", "O");
            userName = userName.Replace("Ü", "U");
            userName = userName.Replace("Ğ", "G");
            userName = userName.Replace("Ç", "C");
            userName = userName.Replace("Ş", "S");

            userName = userName.Replace("/", "");
            userName = userName.Replace("\\", "");
            userName = userName.Replace(".", "");
            userName = userName.Replace(" ", "-");

            return userName;
        }

        public static string CreateMessage(string title, string message, string alertType)
        {
            var alertMessage = new AlertMessage()
            {
                Title = title,
                Message = message,
                AlertType = alertType
            };
            return JsonConvert.SerializeObject(alertMessage);
        }
    }

}
