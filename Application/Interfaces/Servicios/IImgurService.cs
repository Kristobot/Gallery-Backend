using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Servicios
{
    public interface IImgurService
    {
        Task<string> UploadImageAsync(Stream imageStream, string fileName);
    }
}
