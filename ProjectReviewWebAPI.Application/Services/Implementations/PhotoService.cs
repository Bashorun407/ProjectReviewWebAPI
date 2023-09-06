using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using ProjectReviewWebAPI.Application.Commons;
using ProjectReviewWebAPI.Application.Services.Abstractions;

namespace ProjectReviewWebAPI.Application.Services.Implementations
{
    public class PhotoService : IPhotoService
    {
        public IConfiguration Configuration { get; } //This is from CloudinaryDotNet dependency
        private CloudinarySettings _cloudinarySettings { get; } //A class I created in the Service Commons folder
        private Cloudinary _cloudinary; //This is from Cloudinary dependency

        public PhotoService(IConfiguration configuration)
        {
            Configuration = configuration;

            var cloudinarySettings = Configuration.GetSection("CloudinarySettings");
            _cloudinarySettings = new CloudinarySettings();
            _cloudinarySettings.CloudName = cloudinarySettings["CloudName"];
            _cloudinarySettings.ApiKey = cloudinarySettings["ApiKey"];
            _cloudinarySettings.ApiSecret = cloudinarySettings["ApiSecret"];

            //This account is from cloudinary dependency...it collects the basic information on one's cloudinary account
            Account account = new Account(_cloudinarySettings.CloudName, _cloudinarySettings.ApiKey, _cloudinarySettings.ApiSecret); //This is from cloudinary dependency 

            _cloudinary = new Cloudinary(account);
        }


        public string AddPhotoForUser(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.Name, stream)
                    };
                    uploadResult = _cloudinary.Upload(uploadParams);

                }
            }

            string url = uploadResult.Url.ToString();
            string publicId = uploadResult.PublicId;

            return url;
        }
    }
}
