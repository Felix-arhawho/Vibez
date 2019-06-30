using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vibez.Domain.Context;
using Vibez.Domain.Models;
using Vibez.Repositories.Dtos.RequestDtos;
using Vibez.Repositories.Dtos.ResponseDtos;
using Vibez.Repositories.Repositories.Interface;

namespace Vibez.Repositories.Repositories.Concrete
{
    public class ImageRepository : Repository<int, Image>, IImageRepository
    {
        private VibezContext _context;
        public ImageRepository(VibezContext context) : base(context)
        {
            _context = context;
        }

        public List<ImageResponseDto> GetAllImages()
        {
            var images = GetAll();
            var listOfImages = new List<ImageResponseDto>();

            foreach(var image in images)
            {
                var imageDto = new ImageResponseDto
                {
                    Id = image.Id,
                    Name = image.Name,
                    Url = image.Url,
                    Extension = image.Extension,
                    postId = image.postId
                };

                listOfImages.Add(imageDto);
            }

            return listOfImages;
        }

        public ImageResponseDto GetImageById(int Id)
        {
            var image = GetById(Id);
            var imageDto = new ImageResponseDto
            {
                Id = image.Id,
                Name = image.Name,
                Url = image.Url,
                Extension = image.Extension,
                postId = image.postId
            };

            return imageDto;
        }

        public void AddImage(ImageRequestDto imageRequestDto)
        {
            var image = new Image
            {
                Name = imageRequestDto.Name,
                Url = imageRequestDto.Url,
                Extension = imageRequestDto.Extension,
                postId = imageRequestDto.postId
            };
            Add(image);
        }

        public void EditImage(ImageRequestDto imageRequestDto)
        {
            var image = GetById(imageRequestDto.Id);
            image.Id = imageRequestDto.Id;
            image.Name = imageRequestDto.Name;
            image.Url = imageRequestDto.Url;
            image.Extension = imageRequestDto.Extension;
            image.postId = imageRequestDto.postId;
        }
    }
}