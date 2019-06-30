using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vibez.Repositories.Dtos.ResponseDtos
{
    public class ErrorResponseDto
    {
        public string ExceptionMessage { get; set; }
        public string InnerExceptionMessage { get; set; }
    }
}
