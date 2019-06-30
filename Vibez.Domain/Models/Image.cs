using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vibez.Domain.Models
{
    [Table("Image")]
    public class Image
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Extension { get; set; }
        public int postId { get; set; }
        [ForeignKey("postId")]
        public Post post { get; set; }
    }
}