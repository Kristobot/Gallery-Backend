using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Servicios;
using Flurl.Http;
using Microsoft.Extensions.Configuration;

namespace Infraestructure.Services
{
    public class ImgurService: IImgurService
    {
        private readonly string clientId;
        private const string ImgurApiUrl = "https://api.imgur.com/3/image";

        public ImgurService(IConfiguration configuration)
        {
            this.clientId = configuration["Imgur:ClientId"];
        }

        public async Task<string> UploadImageAsync(Stream imageStream, string imageName)
        {
            var response = await ImgurApiUrl
                .WithHeader("Authorization", $"Client-ID {clientId}")
                .PostMultipartAsync(mp => mp
                    .AddFile("image", imageStream, imageName)
                );

            var responseData = await response.GetJsonAsync<ImgurResponse>();

            if (responseData.Success)
            {
                return responseData.Data.Link;
            }

            throw new Exception("Image upload failed");
        }
    }

    public class ImgurResponse
    {
        public bool Success { get; set; }
        public ImgurData Data { get; set; }
    }

    public class ImgurData
    {
        public string Link { get; set; }
    }
}
