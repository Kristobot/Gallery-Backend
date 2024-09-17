using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries
{
    public class GetImageFiltered : IRequest<List<Image>>
    {
        public int page { get; set; } = 1;
        public DateTime? date { get; set; }
    }
}
