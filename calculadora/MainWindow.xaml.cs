﻿using calculadora;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace calculadora
{
    public partial class MainWindow : Window
    {
        string operacaoParenteses = "";
        string resultadoConvertido = "";
        string resultadoRaiz = "";
        public static PersistenciaContas ex = new();
        public static int w2 = 0;

        string operador = "";
        string operadorRaiz = "";
        int resultado = 0;
        int numero1 = 0;
        int numero2 = 0;
        double numeroRaiz;

        public MainWindow()
        {
            InitializeComponent();
        }


        private void btnAdicao_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText("+");
        }

        private void btnSubtracao_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText("-");
        }

        private void btnMultiplicacao_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText("x");
        }

        private void btnDiv_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText("÷");
        }

        private void btnPorcentagem_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText("%");
        }

        private void btnRaizQuadrada_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText("√()");
        }

        private void btnParentesesDireita_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText("(");
        }

        private void btnParentesesEsquerda_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText(")");
        }
        private void btnZero_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText("0");
        }
        private void btnUm_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText("1");
        }
        private void btnDois_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText("2");
        }

        private void btnTres_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText("3");
        }
        private void btnQuatro_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText("4");
        }
        private void btnCinco_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText("5");
        }

        private void btnSeis_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText("6");
        }
        private void btnSete_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText("7");
        }
        private void
            btnOito_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText("8");
        }

        private void btnNove_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText("9");
        }
        private void btnPonto_Click(object sender, RoutedEventArgs e)
        {
            //boxContas1.AppendText(".");
        }

        private void boxContas1_KeyDown(object sender, KeyEventArgs e)
        {
            LimparContasAnteriores();
            var key = (System.Windows.Input.KeyEventArgs)e;

            bool nonNumberEntered = false;

            // Determine whether the keystroke is a number from the top of the keyboard.
            if (e.Key < Key.D0 || e.Key > Key.D9)
            {
                // Determine whether the keystroke is a number from the keypad.
                if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9)
                {
                    // Determine whether the keystroke is a backspace.
                    if (e.Key != Key.Back)
                    {
                        // A non-numerical keystroke was pressed.
                        // Set the flag to true and evaluate in KeyPress event.
                        nonNumberEntered = true;
                    }
                }
            }


            ////If shift key was pressed, it's not a number.
            if (ModifierKeys.Control.ToString() == "Shift")
            {
                nonNumberEntered = true;
            }


            //if (e.Key == Key.OemPeriod || (e.Key == Key.OemComma) || e.Key.ToString().ToUpper() =="X")
            if (ValidarCaracteresPermitidos((int)e.Key))
            {
                nonNumberEntered = false;

            }
            //Validar se texto formato está correto
            string caracterDigitado = KeycodeToChar((int)e.Key);
            string numeroTexto = boxContas1.Text + caracterDigitado;
            //double valorEsperado;

            //if (!double.TryParse(numeroTexto, out valorEsperado))
            //{

            //    nonNumberEntered = true;
            //}


            if (nonNumberEntered)
            {
                //Cancela a insersao
                e.Handled = true;
            }



        }

        public bool ValidarCaracteresPermitidos(int keyCode)
        {
            bool retorno = false;

            Key key = (Key)keyCode;
            //e.Key == Key.OemPeriod || (e.Key == Key.OemComma) || e.Key.ToString().ToUpper() == "X"
            switch (key)
            {
                case Key.Add:
                    return true;
                case Key.OemPeriod:
                    return true;
                case Key.OemComma:
                    return true;
                case Key.X:
                    return true;
                case Key.OemPlus:
                    return true;
                default:
                    return false;
            }

        }

        public String KeycodeToChar(int keyCode)
        {
            Key key = (Key)keyCode;

            switch (key)
            {
                case Key.Add:
                    return "+";
                case Key.Decimal:
                    return ".";
                case Key.Divide:
                    return "/";
                case Key.Multiply:
                    return "*";
                case Key.OemBackslash:
                    return "\\";
                case Key.OemCloseBrackets:
                    return "]";
                case Key.OemMinus:
                    return "-";
                case Key.OemOpenBrackets:
                    return "[";
                case Key.OemPeriod:
                    return ".";
                case Key.OemPipe:
                    return "|";
                case Key.OemQuestion:
                    return "/";
                case Key.OemQuotes:
                    return "\"";
                case Key.OemSemicolon:
                    return ";";
                case Key.OemComma:
                    return ",";
                case Key.OemPlus:
                    return "+";
                case Key.OemTilde:
                    return "`";
                case Key.Separator:
                    return "-";
                case Key.Subtract:
                    return "-";
                case Key.NumPad0:
                    return "0";
                case Key.NumPad1:
                    return "1";
                case Key.NumPad2:
                    return "2";
                case Key.NumPad3:
                    return "3";
                case Key.NumPad4:
                    return "4";
                case Key.NumPad5:
                    return "5";
                case Key.NumPad6:
                    return "6";
                case Key.NumPad7:
                    return "7";
                case Key.NumPad8:
                    return "8";
                case Key.NumPad9:
                    return "9";
                case Key.D0:
                    return "0";
                case Key.D1:
                    return "1";
                case Key.D2:
                    return "2";
                case Key.D3:
                    return "3";
                case Key.D4:
                    return "4";
                case Key.D5:
                    return "5";
                case Key.D6:
                    return "6";
                case Key.D7:
                    return "7";
                case Key.D8:
                    return "8";
                case Key.D9:
                    return "9";
                case Key.Space:
                    return " ";
                default:
                    return key.ToString();
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            if (w2 == 0)
            {
                this.WindowState = WindowState.Minimized;
            }
        }

        private void btnDotsIcon_Click(object sender, RoutedEventArgs e)
        {

            if (w2 == 0)
            {
                ex.Show();
                w2 = 1;
            }
        }

        private void btnIgual_Click(object sender, RoutedEventArgs e)
        {

            if (!boxContas1.Text.Equals(""))
            {
                string conta = boxContas1.Text;

                labelContas.Content = boxContas1.Text + " =";

                FiltrarOperador();

                OrganizarStringOperacao(conta);

                InserirOperacaoExibicao();
            }
            else
            {

            }

        }




        private void backspace_Click(object sender, RoutedEventArgs e)
        {
            if (boxContas1.Text.Length > 0)
            {
                var text = boxContas1.Text;
                boxContas1.Text = text.Remove(text.Length - 1);
            }
        }
        private void btnErase_Click(object sender, RoutedEventArgs e)
        {
            boxContas1.Text = "";
        }



        private void FiltrarOperador()
        {
            string conta = boxContas1.Text;

            if (conta.Contains('+'))
            {
                operador = "+";
            }
            else if (conta.Contains('-'))
            {
                operador = "-";
            }
            else if (conta.Contains('x'))
            {
                operador = "x";
            }
            else if (conta.Contains('/'))
            {
                operador = "/";
            }
            else if (conta.Contains('÷'))
            {
                operador = "÷";
            }
            else if (conta.Contains('%'))
            {
                operador = "%";
            }
            else if (conta.Contains("√()"))
            {
                operadorRaiz = "√()";
            }
            else if (conta.Contains('('))
            {
                //&& conta.Contains(')')
                operacaoParenteses = "(";
            }
            else
            {
                MessageBox.Show("Digite um operador válido!", "ERRO!", MessageBoxButton.OK);
            }
        }

        private void OrganizarStringOperacao(string conta)
        {
            if (!operacaoParenteses.Equals(""))
            {
                string selecaoNumero = conta.Substring(conta.LastIndexOf(operacaoParenteses) + 1);
            }

            else if (!operadorRaiz.Equals(""))
            {
                string selecaoNumero = conta.Substring(conta.LastIndexOf(operadorRaiz) + 3);
                numeroRaiz = Convert.ToDouble(selecaoNumero);
                double contaRaiz = Math.Sqrt(numeroRaiz);
                resultadoRaiz = contaRaiz.ToString();
                boxContas1.Text = resultadoRaiz;
            }
            else
            {
                string N1 = conta.Substring(0, conta.IndexOf(operador));
                numero1 = (int)Int64.Parse(N1);

                string N2 = conta.Substring(conta.LastIndexOf(operador) + 1);
                numero2 = (int)Int64.Parse(N2);

                OperarOperacoes();

                resultadoConvertido = resultado.ToString();
                boxContas1.Text = resultadoConvertido;
            }
        }
        private void OperarOperacoes()
        {
            switch (operador)
            {
                case "+":
                    resultado = numero1 + numero2;
                    break;
                case "-":
                    resultado = numero1 - numero2;
                    break;
                case "x":
                    resultado = numero1 * numero2;
                    break;
                case "/":
                    resultado = numero1 / numero2;
                    break;
                case "÷":
                    resultado = numero1 / numero2;
                    break;
                case "%":
                    double parte1 = numero1 * numero2;
                    resultado = (int)(parte1 / 100);
                    break;

            }
        }

        public void InserirOperacaoExibicao()
        {

            if (!operadorRaiz.Equals(""))
            {
                string resultadoExibicao = "\n" + operadorRaiz + " " + numeroRaiz + " " + "= " + resultadoRaiz;
                ex.exibicaoContas.AppendText(resultadoExibicao);
            }
            else
            {
                string resultadoExibicao = "\n" + numero1 + " " + operador + " " + numero2 + " " + "= " + resultadoConvertido;
                ex.exibicaoContas.AppendText(resultadoExibicao);
            }

        }
        private void LimparContasAnteriores()
        {
            if (boxContas1.Text.Equals(resultadoRaiz))
            {
                boxContas1.Text = "";
                labelContas.Content = "";
                resultadoConvertido = "";
                resultadoRaiz = "";
                operadorRaiz = "";
            }
            else if (boxContas1.Text.Equals(resultadoConvertido))
            {
                boxContas1.Text = "";
                labelContas.Content = "";
                resultadoConvertido = "";
                resultadoRaiz = "";
            }

        }
        public void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //if (e.ChangedButton == MouseButton.Left)
            //{
            //    MainWindow primeiraTela = new MainWindow();
            //    this.DragMove();
            //}
            //if (w2 == 1)
            //{
            //    Configs Mover2 = new();
            //    Mover2.segundaTela_MouseDown(sender, e);


            //}
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(1);
        }


    }
}
