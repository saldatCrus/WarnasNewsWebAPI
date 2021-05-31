using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarnasNewsWebAPI.Models
{
    public class News
    {
        public int Id { get; set; }

        public byte[] Image { get; set; }

        public string Head { get; set; }

        public string Body { get; set; }

        public string Link { get; set; }
    }
}
