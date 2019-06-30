using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vibez.Repositories.Dtos.RequestDtos
{
    public class CategoryRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PostRequestDto> Posts { get; set; }
    }
}
