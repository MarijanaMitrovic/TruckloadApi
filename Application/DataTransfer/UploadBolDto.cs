using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class UploadBolDto
    {
        public int LoadId { get; set; }
        public int DriverId { get; set; }

        public string Image { get; set; }
        public IFormFile Img { get; set; }
    }
}
