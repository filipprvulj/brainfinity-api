using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brainfinity.API
{
    public class CorsModel
    {
        public string[] Origins { get; set; }
        public string[] Headers { get; set; }
        public string[] Methods { get; set; }
    }
}