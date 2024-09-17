using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Queries;
using Application.Specifications;
using Domain.Entities;
using Domain.Interfaces.Repositorios;
using MediatR;

namespace Application.Features.Handlers
{
    public class GetImageFilteredHandler : IRequestHandler<GetImageFiltered, List<Image>>
    {
        private readonly IImageRepository imageRepository;
        public GetImageFilteredHandler(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        public async Task<List<Image>> Handle(GetImageFiltered request, CancellationToken cancellationToken)
        {
            var response = await imageRepository.GetAll(new ImageSpecification(request.date, request.page));
            return response.ToList();
        }
    }
}
