using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Vibez.Repositories.Dtos.RequestDtos
{
    public class PostRequestDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        public List<CommentRequestDto> Comments { get; set; }
        public List<ImageRequestDto> Images { get; set; }
        public int CategoryId { get; set; }
    }
}