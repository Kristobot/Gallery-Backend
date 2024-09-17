using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Domain.Entities;
using Domain.Interfaces.Repositorios;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositorios
{
    public class ImageRepository : IImageRepository
    {
        private readonly GalleryContext context;
        public ImageRepository(GalleryContext context)
        {
            this.context = context;
        }

        public async Task<List<Image>> GetAll(Specification<Image> spec)
        {
            var query = context.Images.WithSpecification(spec);
            return await query.ToListAsync();
        }

        public async Task Save(Image image)
        {
            context.Images.Add(image);
            await context.SaveChangesAsync();
        }
    }
}
