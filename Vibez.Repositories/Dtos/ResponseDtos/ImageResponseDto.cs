﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vibez.Repositories.Dtos.ResponseDtos
{
    public class ImageResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Extension { get; set; }
        public int postId { get; set; }
    }
}
