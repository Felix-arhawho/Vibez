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
    public class CommentRepository : Repository<int, Comment>, ICommentRepository
    {
        private VibezContext _context;
        public CommentRepository(VibezContext context) : base(context)
        {
            _context = context;
        }

        public List<CommentResponseDto> GetAllComment()
        {
            var listOfComments = new List<CommentResponseDto>();
            var comments = GetAll();
            foreach(var comment in comments)
            {
                var commentDto = new CommentResponseDto
                {
                    Id = comment.Id,
                    ContentOfComment = comment.Content,
                    postId = comment.postId
                };
                listOfComments.Add(commentDto);
            }

            return listOfComments;
        }

        public CommentResponseDto GetCommentById(int Id)
        {
            var comment = GetById(Id);
            var commentDto = new CommentResponseDto
            {
                Id = comment.Id,
                ContentOfComment = comment.Content,
                postId = comment.postId
            };
            return commentDto;
        }

        public void CreateComment(CommentRequestDto commentRequestDto)
        {
            var comment = new Comment
            {
                Content = commentRequestDto.ContentOfComment,
                postId = commentRequestDto.postId
            };
            Add(comment);
        }

        public void EditComment(CommentRequestDto commentRequestDto)
        {
            var comment = GetById(commentRequestDto.Id);
            comment.Id = commentRequestDto.Id;
            comment.Content = commentRequestDto.ContentOfComment;
            comment.postId = commentRequestDto.postId;
        }

        public void DeleteComment(int Id)
        {
            var comment = GetById(Id);
            Remove(comment);
        }
    }
}