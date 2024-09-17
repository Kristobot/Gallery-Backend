using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;
using Domain.Entities;

namespace Domain.Interfaces.Repositorios
{
    public interface IImageRepository
    {
        Task Save(Image image);
        Task<List<Image>> GetAll(Specification<Image> spec);
    }
}
