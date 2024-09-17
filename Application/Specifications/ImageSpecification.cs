using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specifications
{
    public class ImageSpecification : Specification<Image>
    {
        public ImageSpecification(DateTime? date, int page)
        {
            Query.Skip((page - 1) * 10)
                .Take(10);

            if (date.HasValue) // Verifica si la fecha tiene un valor
            {
                Query.Where(images => images.CreationTimeStamp >= date.Value);
            }

        }
    }
}
