using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mochila
{
    public class Objeto
    {
        private byte _Peso;
        private byte _Valor;
        public Objeto(byte peso, byte valor)
        {
            this._Peso = peso;
            this._Valor = valor;
        }
        public byte Peso
        {
            get
            {
                return this._Peso;
            }
            set
            {
                if (this._Peso != value)
                {
                    this._Peso = value;
                }
            }
        }
        public byte Valor
        {
            get
            {
                return this._Valor;
            }
            set
            {
                if (this._Valor != value)
                {
                    this._Valor = value;
                }
            }
        }
    }
}
