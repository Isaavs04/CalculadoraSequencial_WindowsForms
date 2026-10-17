using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        double armazenarNumero = 0, ResultadoOperacao = 0;
        string operacao = "";
        public Form1()
        {
            InitializeComponent();
        }
        private void btnSete_Click(object sender, EventArgs e)
        {
            txtVisor.Text = txtVisor.Text + "7";
        }

        private void btnOito_Click(object sender, EventArgs e)
        {
            txtVisor.Text = txtVisor.Text + "8";
        }

        private void btnNove_Click(object sender, EventArgs e)
        {
            txtVisor.Text = txtVisor.Text + "9";
        }

        private void btnQuatro_Click(object sender, EventArgs e)
        {
            txtVisor.Text = txtVisor.Text + "4";
        }

        private void btnCinco_Click(object sender, EventArgs e)
        {
            txtVisor.Text = txtVisor.Text + "5";
        }

        private void btnSeis_Click(object sender, EventArgs e)
        {
            txtVisor.Text = txtVisor.Text + "6";
        }

        private void btnUm_Click(object sender, EventArgs e)
        {
            txtVisor.Text = txtVisor.Text + "1";
        }

        private void btnDois_Click(object sender, EventArgs e)
        {
            txtVisor.Text = txtVisor.Text + "2";
        }

        private void btnTres_Click(object sender, EventArgs e)
        {
            txtVisor.Text = txtVisor.Text + "3";
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            txtVisor.Text = txtVisor.Text + "0";
        }

        private void btzVirgula_Click(object sender, EventArgs e)
        {
            if (txtVisor.Text == "" || txtVisor.Text == "Error")
            {
                return;
            }
            string texto = txtVisor.Text;
            char ultimoCaractere = texto[texto.Length - 1];
            if (ultimoCaractere == '+' || ultimoCaractere == '-' || ultimoCaractere == 'x' || ultimoCaractere == '/')
            {
                return;
            }
            string[] operadores = { "+", "-", "✖", "/" };
            string[] partes = texto.Split(operadores, StringSplitOptions.None);
            string numeroAtual = partes[partes.Length - 1];
            if (!numeroAtual.Contains(","))
            {
                txtVisor.Text = txtVisor.Text + ",";
            }
            Console.Beep();
        }

        private void btnParenteses_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
            System.Media.SystemSounds.Exclamation.Play();
        }

        private void btnPorcentagem_Click(object sender, EventArgs e)
        {
            if (operacao != "" && !TerminaComOperador())
            {
                ExecutarCalculoParcial();
            }
            armazenarNumero = double.Parse(txtVisor.Text);
            operacao = "%";
            txtVisor.Text = txtVisor.Text + "%";
            PosicionarCursorNoFim();
            Console.Beep();
        }

        private void btnDivisao_Click(object sender, EventArgs e)
        {
            if (operacao != "" && !TerminaComOperador())
            {
                ExecutarCalculoParcial();
            }
            armazenarNumero = double.Parse(txtVisor.Text);
            operacao = "/";
            txtVisor.Text = txtVisor.Text + "/";
            PosicionarCursorNoFim();
            Console.Beep();

        }

        private void btnMultiplicacao_Click(object sender, EventArgs e)
        {
            if (operacao != "" && !TerminaComOperador())
            {
                ExecutarCalculoParcial();
            }

            armazenarNumero = double.Parse(txtVisor.Text);
            operacao = "x";
            txtVisor.Text = txtVisor.Text + "x";
            PosicionarCursorNoFim();
            Console.Beep();
        }

        private void btnSubtracao_Click(object sender, EventArgs e)
        {
            if (operacao != "" && !TerminaComOperador())
            {
                ExecutarCalculoParcial();
            }

            armazenarNumero = double.Parse(txtVisor.Text);
            operacao = "-";
            txtVisor.Text = txtVisor.Text + "-";
            PosicionarCursorNoFim();
            Console.Beep();
        }

        private void btnSoma_Click(object sender, EventArgs e)
        {
            if (operacao != "" && !TerminaComOperador())
            {
                ExecutarCalculoParcial();
            }
            armazenarNumero = double.Parse(txtVisor.Text);
            operacao = "+";
            txtVisor.Text = txtVisor.Text + "+";
            PosicionarCursorNoFim();
            Console.Beep();

        }

        private void btnAc_Click(object sender, EventArgs e)
        {
            txtVisor.Clear();
            btnUm.Enabled = true;
            btnDois.Enabled = true;
            btnTres.Enabled = true;
            btnQuatro.Enabled = true;
            btnCinco.Enabled = true;
            btnSeis.Enabled = true;
            btnSete.Enabled = true;
            btnOito.Enabled = true;
            btnNove.Enabled = true;
            btnZero.Enabled = true;
            txtVisor.Enabled = true;
            System.Media.SystemSounds.Beep.Play();
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
           txtVisor.Text = txtVisor.Text.Substring(0, txtVisor.Text.Length - 1);
            Console.Beep();
        }

        private void txtVisor_TextChanged(object sender, EventArgs e)
        {
            //Desabilitar e habilitar botões
            //Botões simples
            if (txtVisor.Text == "Error")
            {
                btnAc.Enabled = true;
                txtVisor.Enabled = false;
                //Desabilita teclas operacionais
                btnApagar.Enabled = false;
                btnIgual.Enabled = false;
                btnSoma.Enabled = false;
                btnSubtracao.Enabled = false;
                btnMultiplicacao.Enabled = false;
                btnDivisao.Enabled = false;
                btnPorcentagem.Enabled = false;
                btzVirgula.Enabled = false;
                //Desabilita teclado numérico
                btnUm.Enabled = false;
                btnDois.Enabled = false;
                btnTres.Enabled = false;
                btnQuatro.Enabled = false;
                btnCinco.Enabled = false;
                btnSeis.Enabled = false;
                btnSete.Enabled = false;
                btnOito.Enabled = false;
                btnNove.Enabled = false;
                btnZero.Enabled = false;
            }
            else if (txtVisor.Text != "")
            {
                btnApagar.Enabled = true;
                btnAc.Enabled = true;
                btnIgual.Enabled = true;
                btzVirgula .Enabled = true;
                //Botões de operação
                char ultimoCaractere = txtVisor.Text[txtVisor.Text.Length - 1];
                if (ultimoCaractere == '+' || ultimoCaractere == '-' || ultimoCaractere == 'x' || ultimoCaractere == '/' || ultimoCaractere == ',')
                {
                    btnSoma.Enabled = false;
                    btnSubtracao.Enabled = false;
                    btnMultiplicacao.Enabled = false;
                    btnDivisao.Enabled = false;
                    btnPorcentagem.Enabled = false;
                    btzVirgula.Enabled = false;
                }
                else
                {
                    btnSoma.Enabled = true;
                    btnSubtracao.Enabled = true;
                    btnMultiplicacao.Enabled = true;
                    btnDivisao.Enabled = true;
                    btnPorcentagem.Enabled = true;
                    btzVirgula.Enabled = true;
                }
            }
            else
            {
                btzVirgula.Enabled = false;
                btnApagar.Enabled = false;
                btnAc.Enabled = false;
                btnIgual.Enabled = false;
                btnSoma.Enabled = false;
                btnSubtracao.Enabled = false;
                btnMultiplicacao.Enabled = false;
                btnDivisao.Enabled = false;
                btnPorcentagem.Enabled = false;
            }
            //Desativar o botão da vírugula quando a vírgula já tiver sido digitada no número
            string[] operadores = { "+", "-", "x", "/" };
            string texto = txtVisor.Text;
            string[] partes = texto.Split(operadores, StringSplitOptions.None);
            string numeroAtual = partes[partes.Length - 1];
            if (numeroAtual.Contains(","))
            {
                btzVirgula.Enabled = false;
            }
            else
            {
                btzVirgula.Enabled = true;
            }
        }

        private void Numero_Click(object sender, EventArgs e)
        {
            Button botaoClicado = (Button)sender;
            txtVisor.Text += botaoClicado.Text;
            PosicionarCursorNoFim();
            Console.Beep();
        }
        private double Calcular(double numArmazenado, double num, string operacao)
        {
            if (operacao == "+")
            {
                ResultadoOperacao = numArmazenado + num;
            }
            else if (operacao == "-")
            {
                ResultadoOperacao = numArmazenado - num;
            }
            else if (operacao == "x")
            {
                ResultadoOperacao = numArmazenado * num;
            }
            else if (operacao == "/")
            {
                    ResultadoOperacao = numArmazenado / num;
            }
            else
            {
                ResultadoOperacao = numArmazenado * (num / 100);
            }
            return ResultadoOperacao;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            string textoVisor = txtVisor.Text;
            string[] partes = textoVisor.Split(new string[] { operacao }, StringSplitOptions.None);
            if (partes.Length > 1)
            {
                double segundoNumero = double.Parse(partes[1]);
                if (segundoNumero == 0 && operacao == "/")
                {
                    txtVisor.ForeColor = Color.Red;
                    txtVisor.Text = "Error";
                    System.Media.SystemSounds.Hand.Play();
                }
                else
                {
                    double resultadoFinal = Calcular(armazenarNumero, segundoNumero, operacao);
                    txtVisor.Text = resultadoFinal.ToString();
                }
                PosicionarCursorNoFim();

            }
        }
        private bool TerminaComOperador()
        {
            if (string.IsNullOrEmpty(txtVisor.Text)) return false;
            char ultimo = txtVisor.Text[txtVisor.Text.Length - 1];
            return ultimo == '+' || ultimo == '-' || ultimo == 'x' || ultimo == '/';
        }
        private void ExecutarCalculoParcial()
        {
            try
            {
                string[] operadores = { "+", "-", "x", "/" };
                string[] partes = txtVisor.Text.Split(operadores, StringSplitOptions.RemoveEmptyEntries);

                if (partes.Length >= 2)
                {
                    double segundoNumero = double.Parse(partes[1]);
                    double resultadoParcial = Calcular(armazenarNumero, segundoNumero, operacao);
                    txtVisor.Text = resultadoParcial.ToString();
                    armazenarNumero = resultadoParcial;
                }
            }
            catch
            {
                
            }
        }
        private void PosicionarCursorNoFim()
        {
            txtVisor.SelectionStart = txtVisor.Text.Length;
            txtVisor.SelectionLength = 0;
        }
    }
}
