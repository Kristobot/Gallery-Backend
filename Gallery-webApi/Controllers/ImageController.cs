using Application.Features.Commands;
using Application.Features.Queries;
using Application.Interfaces.Servicios;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gallery_webApi.Controllers
{
    [Route("api/[Controller]")]
    public class ImageController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IImgurService imgurService;
        public ImageController(IMediator mediator, IImgurService imgurService)
        {
            this.mediator = mediator;
            this.imgurService = imgurService;
        }
        [HttpPost("submit")]
        public async Task<IActionResult> Save([FromForm]IFormFile formFile)
        {
            if (formFile == null || formFile.Length == 0)
            {
                return BadRequest("No File Uploaded");
            }

            var stream = formFile.OpenReadStream();
            string imageUrl = await imgurService.UploadImageAsync(stream, formFile.FileName);

            var response = await mediator.Send(new SaveImageCommand { Path = imageUrl});

            return Ok(response);
        }
        [HttpGet("MyPictures")]
        public async Task<ActionResult<List<Image>>> GetAll([FromQuery]GetImageFiltered request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
