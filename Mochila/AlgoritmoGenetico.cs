using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mochila
{
    public class AlgoritmoGenetico
    {
        private byte _Colunas;
        private int _Linhas;
        private int _TamanhoPopulacao;
        private byte _TamanhoCromossomo;
        List<List<bool>> _Cromossomos;
        List<List<bool>> _MelhoresCromossomos;
        public AlgoritmoGenetico(byte colunas, byte limitePeso, List<Objeto> objetos)
        {
            this._Colunas = colunas;
            this._Linhas = 10 * colunas;
            this._TamanhoPopulacao = this._Linhas;
            this._TamanhoCromossomo = colunas;
            Random random = new Random();
            this._Cromossomos = new List<List<bool>>();
            for (int i = 0; i < this._Linhas; i++)
            {
                char[] numBinario = DecimalParaBinario(LongRandom(1, (int)Math.Pow(2, this._TamanhoCromossomo), random)).ToCharArray();
                this._Cromossomos.Add(new List<bool>());
                short pesoCromossomo = 0;
                for (int j = 0; j < this._Colunas; j++)
                {
                    this._Cromossomos[i].Add(false);
                    if (j < numBinario.Length)
                    {
                        if (numBinario[numBinario.Length - (j + 1)].Equals('1'))
                        {
                            if (pesoCromossomo + objetos[j].Peso <= limitePeso)
                            {
                                this._Cromossomos[i][j] = true;
                                pesoCromossomo += objetos[j].Peso;
                            }                   
                        }
                    }
                }
            }
        }

        long LongRandom(long min, long max, Random rand)
        {
            byte[] buf = new byte[8];
            rand.NextBytes(buf);
            long longRand = BitConverter.ToInt64(buf, 0);

            long x = (Math.Abs(longRand % (max - min)) + min);
            return x;
        }
        public List<List<bool>> Cromossomos
        {
            get
            {
                if (this._Cromossomos == null)
                {
                    this._Cromossomos = new List<List<bool>>();
                }
                return this._Cromossomos;
            }
            set
            {
                if (this._Cromossomos != value)
                {
                    this._Cromossomos = value;
                }
            }
        }

        public List<List<bool>> MelhoresCromossomos
        {
            get
            {
                if (this._MelhoresCromossomos == null)
                {
                    this._MelhoresCromossomos = new List<List<bool>>();
                }
                return this._MelhoresCromossomos;
            }
            set
            {
                if (this._MelhoresCromossomos != value)
                {
                    this._MelhoresCromossomos = value;
                }
            }
        }
        public void CrossOver()
        {
            //seleciona o indice do meio da lista de cromossomos;
            byte indiceMeio = Convert.ToByte(this._Colunas);
            Random random = new Random();
            for (int i = 0; i < this._Cromossomos.Count; i++)
            {
                if (this._Cromossomos.Count > (i + 1))
                {
                    List<bool> pai1Metade1 = new List<bool>();
                    List<bool> pai1Metade2 = new List<bool>();
                    for (int k = 0; k < indiceMeio; k++)
                    {
                        pai1Metade1.Add(this._Cromossomos[i][k]);
                    }
                    for (int k = indiceMeio; k < this._Cromossomos[i].Count; k++)
                    {
                        pai1Metade2.Add(this._Cromossomos[i][k]);
                    }
                    List<bool> pai2Metade1 = new List<bool>();
                    List<bool> pai2Metade2 = new List<bool>();
                    for (int k = 0; k < indiceMeio; k++)
                    {
                        pai2Metade1.Add(this._Cromossomos[i + 1][k]);
                    }
                    for (int k = indiceMeio; k < this._Cromossomos[i].Count; k++)
                    {
                        pai2Metade2.Add(this._Cromossomos[i + 1][k]);
                    }
                    this._Cromossomos.RemoveAt(i);
                    this._Cromossomos.RemoveAt(i);
                    var filho1 = pai1Metade1.Concat(pai2Metade2);
                    this._Cromossomos.Add(filho1.ToList<bool>());
                    var filho2 = pai2Metade1.Concat(pai1Metade2);
                    this._Cromossomos.Add(filho2.ToList<bool>());
                    if (random.Next(0, 2) == 1)
                    {
                        Mutacao();
                    }
                }
                else
                {
                    i = this._Cromossomos.Count;
                    break;
                }
            }
        }

        private void Mutacao()
        {
            if (this._Cromossomos[this._Cromossomos.Count - 1][this._TamanhoCromossomo -1] == true)
            {
                this._Cromossomos[this._Cromossomos.Count - 1][this._TamanhoCromossomo-1] = false;
            }
            else
            {
                this._Cromossomos[this._Cromossomos.Count - 1][this._TamanhoCromossomo-1] = true;
            }
        }
        private byte GetMaiorValorObjeto(List<Objeto> lista)
        {
            byte maiorValor = 0;
            for (int i = 0; i < lista.Count; i++)
            {
                byte valorAtual = lista[i].Valor;
                if (valorAtual > maiorValor)
                {
                    maiorValor = valorAtual;
                }
            }
            return maiorValor;
        }
        public void Fitness(List<Objeto> objetos, byte pesoSuportado)
        {
            //pega o índice do objeto que possue maior valor;
            uint maiorValorObjeto = GetMaiorValorObjeto(objetos);
            for (int i = 0; i < this._Cromossomos.Count; i++)
            {
                uint beneficio = 0;
                uint totalPeso = 0;
                for (int j = 0; j < this._Cromossomos[i].Count; j++)
                {
                    if (this._Cromossomos[i][j] == true)
                    {
                        beneficio += objetos[j].Valor;
                        totalPeso += objetos[j].Peso;
                    }
                }
                if (totalPeso > pesoSuportado)
                {
                    this._Cromossomos.RemoveAt(i);
                    i--;
                }
                else
                {
                    if (beneficio >= (float)maiorValorObjeto)
                    {

                        if (!ExisteNaLista(MelhoresCromossomos, this._Cromossomos[i]))
                        {
                            this._MelhoresCromossomos.Add(this._Cromossomos[i]);
                            this._Cromossomos.RemoveAt(i);
                            i--;
                        }
                    }
                }
            }
        }
        public bool ExisteNaLista(List<List<bool>> lista1, List<bool> lista2)
        {
            byte comparador = 0;
            for (int i = 0; i < lista1.Count; i++)
            {
                comparador = 0;
                for (int j = 0; j < lista1[i].Count; j++)
                {
                    if (lista1[i][j] == lista2[j])
                    {
                        comparador++;
                    }
                }
                if (comparador == lista2.Count)
                {
                    break;
                }
            }
            if (comparador == lista2.Count)
            {
                return true;
            }
            return false;
        }
        public void DeletarPiorCromossomo(List<List<bool>> cromossomos, List<Objeto> lista)
        {
            const uint infinito = 9999;
            byte indice = 0;
            uint valorMenorCromossomo = infinito;
            uint sValorAtual = 0;
            for (int i = 0; i < cromossomos.Count; i++)
            {
                sValorAtual = 0;
                for (int j = 0; j < cromossomos[i].Count; j++)
                {
                    if (cromossomos[i][j] == true)
                    {
                        sValorAtual += lista[j].Valor;
                    }
                }
                if (sValorAtual < valorMenorCromossomo)
                {
                    valorMenorCromossomo = sValorAtual;
                    indice = (byte)i;
                }

            }
            cromossomos.RemoveAt(indice);
        }
        private string DecimalParaBinario(long numero)
        {
            string valor = "";
            int dividendo = Convert.ToInt32(numero);

            if (dividendo == 0 || dividendo == 1)
            {

                return Convert.ToString(dividendo);

            }
            else
            {
                while (dividendo > 0)
                {
                    valor += Convert.ToString(dividendo % 2);

                    dividendo = dividendo / 2;
                }
                return InverterString(valor);
            }
        }

        private string InverterString(string str)
        {
            int tamanho = str.Length;

            char[] caracteres = new char[tamanho];

            for (int i = 0; i < tamanho; i++)
            {
                caracteres[i] = str[tamanho - 1 - i];
            }

            return new string(caracteres);
        }

    }
}
