using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vibez.Domain.Models;
using Vibez.Repositories.Dtos.RequestDtos;
using Vibez.Repositories.Dtos.ResponseDtos;

namespace Vibez.Repositories.Repositories.Interface
{
    public interface IPostRepository : IRepository<int, Post>
    {
        List<PostResponseDto> GetAllPost();
        PostResponseDto GetPostById(int Id);
        void CreatePost(PostRequestDto postRequestDto);
        void EditPost(PostRequestDto postRequestDto);
        void DeletePost(int Id);
    }
}
