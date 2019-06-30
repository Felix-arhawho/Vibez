using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vibez.Domain.Models
{
    [Table("Comment")]
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int postId { get; set; }
        [ForeignKey("postId")]
        public Post post { get; set; }
    }
}