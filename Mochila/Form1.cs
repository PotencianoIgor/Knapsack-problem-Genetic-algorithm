using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mochila
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Mochila mochila = new Mochila();
            mochila.pesoSuportado = Convert.ToByte(nud_Peso.Value);
            byte numObjetos = Convert.ToByte(nud_Objetos.Value);
            List<Objeto> objetos = new List<Objeto>();
            Random random = new Random();
            string diretorio = @"C: \Users\Igor\Documents\Visual Studio 2017\Projects\Mochila\icone{0}.png";
            objetos.Add(new Objeto((byte)random.Next(1, mochila.pesoSuportado), (byte)random.Next(1, Mochila.valorMaxObjeto)));
            pnl_PainelPrincipal.Controls.Clear();
            List<Control> controles = new  List<Control>();
            Panel painel = new Panel();
            PictureBox ptrBox = new PictureBox();
            painel.BorderStyle = BorderStyle.FixedSingle;
            painel.Size = new Size(85, 60);
            painel.Padding = new Padding(0, 0, 0, 0);
            Label lbl = new Label();
            lbl.Font = new Font(new FontFamily("Zurich Lt BT"), 7);
            lbl.Text = "Valor:" + objetos[0].Valor + "/Peso:" + objetos[0].Peso;
            lbl.TextAlign = ContentAlignment.TopLeft;
            painel.Controls.Add(lbl);
            Bitmap btm = new Bitmap(String.Format(diretorio, 0));
            ptrBox.Image = btm;
            ptrBox.Size = new Size(65, 85);
            ptrBox.Padding = new Padding(20, 0, 0, 5);
            ptrBox.SizeMode = PictureBoxSizeMode.CenterImage;
            painel.Controls.Add(ptrBox);
            controles.Add(painel);
            if (numObjetos > 1)
            {
                for (int i = 1; i < numObjetos; i++)
                {
                    objetos.Add(new Objeto((byte)random.Next(1, mochila.pesoSuportado), (byte)random.Next(1, Mochila.valorMaxObjeto)));

                    string caminho = String.Format(diretorio, i);
                    if (File.Exists(caminho))
                    {
                        painel = new Panel();
                        ptrBox = new PictureBox();
                        painel.BorderStyle = BorderStyle.FixedSingle;
                        painel.Size = new Size(85, 60);
                        painel.Padding = new Padding(0, 0, 0, 0);
                        if (i > 1 && (i + 1) % 9 == 1)
                        {
                            painel.Location = new Point(0, 1 + (i/9) * controles[i - 1].Size.Height);
                        }
                        else
                        {
                            painel.Location = new Point(controles[i - 1].Location.X + 86, controles[i - 1].Location.Y);
                        }
                        lbl = new Label();
                        lbl.Font = new Font(new FontFamily("Zurich Lt BT"), 7);
                        lbl.Text = "Valor:" + objetos[i].Valor + "/Peso:" + objetos[i].Peso;
                        lbl.TextAlign = ContentAlignment.TopLeft;
                        painel.Controls.Add(lbl);
                        btm = new Bitmap(caminho);
                        ptrBox.Image = btm;
                        ptrBox.Size = new Size(65, 85);
                        ptrBox.Padding = new Padding(20, 0, 0, 5);
                        ptrBox.SizeMode = PictureBoxSizeMode.CenterImage;
                        painel.Controls.Add(ptrBox);
                        controles.Add(painel);
                    }
                }
            }

            pnl_PainelPrincipal.Controls.AddRange(controles.ToArray());
            pnl_PainelPrincipal.Refresh();
            AlgoritmoGenetico ag = new AlgoritmoGenetico(numObjetos, mochila.pesoSuportado, objetos);
            ag.Fitness(objetos, mochila.pesoSuportado);
            /*if (ag.Cromossomos.Count != 1 && ag.Cromossomos.Count % 2 != 0)
            {
                ag.DeletarPiorCromossomo(ag.Cromossomos, objetos);
            }*/
            int contador = 0;
            while (contador < 10 * numObjetos && (ag.Cromossomos.Count > 1))
            {
                contador++;
                ag.CrossOver();
                ag.Fitness(objetos, mochila.pesoSuportado);
            }
            while (ag.MelhoresCromossomos.Count > 1)
            {
                ag.DeletarPiorCromossomo(ag.MelhoresCromossomos, objetos);
            }
            if (ag.MelhoresCromossomos.Count == 0)
            {
                int indice = objetos.FindIndex(filtro => filtro.Valor.Equals(GetMaiorValorObjeto(objetos)));
                List<bool> list = new List<bool>();
                for (int i = 0; i < numObjetos; i++)
                {
                    list.Add(false);
                    if (i == indice)
                    {
                        list[i] = true;
                        ag.MelhoresCromossomos.Add(list);
                    }
                }
            }
            controles = new List<Control>();
            byte itensMochila = 0;
            pnl_Mochila.Controls.Clear();
            for (int i = 0; i < ag.MelhoresCromossomos.Count; i++)
            {
                for (int j = 0; j < ag.MelhoresCromossomos[i].Count; j++)
                {
                    if (ag.MelhoresCromossomos[i][j] == true)
                    {
                        string caminho = String.Format(diretorio, j);
                        if (File.Exists(caminho))
                        {
                            painel = new Panel();
                            ptrBox = new PictureBox();
                            painel.BorderStyle = BorderStyle.FixedSingle;
                            painel.Size = new Size(85, 60);
                            painel.Padding = new Padding(0, 0, 0, 0);
                            lbl = new Label();
                            lbl.Font = new Font(new FontFamily("Zurich Lt BT"), 7);
                            lbl.Text = "Valor:" + objetos[j].Valor + "/Peso:" + objetos[j].Peso;
                            lbl.TextAlign = ContentAlignment.TopLeft;
                            painel.Controls.Add(lbl);
                            btm = new Bitmap(caminho);
                            ptrBox.Image = btm;
                            ptrBox.Size = new Size(65, 85);
                            ptrBox.Padding = new Padding(20, 0, 0, 5);
                            ptrBox.SizeMode = PictureBoxSizeMode.CenterImage;
                            painel.Controls.Add(ptrBox);
                            if (itensMochila == 0)
                            {
                                controles.Add(painel);
                            }
                            else
                            {
                                if (itensMochila > 1 && (itensMochila+1) % 9 == 1)
                                {
                                    painel.Location = new Point(0, 1 + (itensMochila / 9) * controles[itensMochila - 1].Size.Height);
                                }
                                else
                                {
                                    painel.Location = new Point(controles[controles.Count-1].Location.X + 86, controles[controles.Count - 1].Location.Y);
                                }
                            }
                         
                            itensMochila++;
                            controles.Add(painel);
                        }
                    }
                }
            }

            pnl_Mochila.Controls.AddRange(controles.ToArray());
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
    }
}
