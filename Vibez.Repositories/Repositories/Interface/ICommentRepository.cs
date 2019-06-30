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
    public interface ICommentRepository : IRepository<int, Comment>
    {
        List<CommentResponseDto> GetAllComment();
        CommentResponseDto GetCommentById(int Id);
        void CreateComment(CommentRequestDto commentRequestDto);
        void EditComment(CommentRequestDto commentRequestDto);
        void DeleteComment(int Id);
    }
}
