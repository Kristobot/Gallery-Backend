using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Features.Commands;
using Domain.Entities;
using Domain.Interfaces.Repositorios;
using MediatR;

namespace Application.Features.Handlers
{
    public class SaveImageCommandHandler : IRequestHandler<SaveImageCommand, Result>
    {
        private readonly IImageRepository imageRepository;
        public SaveImageCommandHandler(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }
        public async Task<Result> Handle(SaveImageCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var image = new Image
                {
                    Path = request.Path,
                    Description = request.Description,
                    CreationTimeStamp = DateTime.Now,
                };

                await imageRepository.Save(image);

                return new Result { IsSuccess = true, Message = "Imagen guardada Exitosamente" };
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = $"Error: {ex}" };
            }
        }
    }
}
