using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands
{
    public class SaveImageCommand : IRequest<Result>
    {
        public string? Path;
        public string? Description;
    }
}
