using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vibez.Repositories.Dtos.ResponseDtos
{
    public class PostResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public List<CommentResponseDto> Comments { get; set; }
        public List<ImageResponseDto> Images { get; set; }
        public int CategoryId { get; set; }
    }
}