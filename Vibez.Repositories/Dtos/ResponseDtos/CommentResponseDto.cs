using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vibez.Repositories.Dtos.ResponseDtos
{
    public class CommentResponseDto
    {
        public int Id { get; set; }
        public string ContentOfComment { get; set; }
        public int postId { get; set; }
    }
}
