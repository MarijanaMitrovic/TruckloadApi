using Application.Commands;
using Application.DataTransfer;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Implementation.Commands
{
    public class EfUploadBolCommand : IUploadBolCommand
    {

        private readonly TruckloadContext context;

        public EfUploadBolCommand(TruckloadContext context)
        {
            this.context = context;
        }

        public int Id => 23;

        public string Name => "Upload BOL";

        public void Execute(UploadBolDto dto)
        {

            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(dto.Img.FileName);

            var newFileName = guid + extension;

            var path = Path.Combine("wwwroot", "images", newFileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                dto.Img.CopyTo(fileStream);
            }

            var bol = new BillOfLading
            {
                LoadId = dto.LoadId,
                DriverId = dto.DriverId,
               Image = newFileName
            };

            context.BillOfLadings.Add(bol);

            context.SaveChanges();






        }


    }
}
