using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vibez.Domain.Context;
using Vibez.Domain.Models;
using Vibez.Repositories.Dtos.RequestDtos;
using Vibez.Repositories.Dtos.ResponseDtos;

namespace Vibez.Repositories.Repositories.Interface
{
    public interface IImageRepository : IRepository<int, Image>
    {
        List<ImageResponseDto> GetAllImages();
        ImageResponseDto GetImageById(int Id);
        void AddImage(ImageRequestDto imageRequestDto);
        void EditImage(ImageRequestDto imageRequestDto);
    }
}
