using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mochila
{
    public class Mochila
    {
        public const byte valorMaxObjeto = 100;
        public byte numObjetos { get; set; } = valorMaxObjeto;
        public byte pesoSuportado { get; set; }
    }
}
