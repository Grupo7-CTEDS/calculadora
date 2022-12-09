using System;
using System.Collections.Generic;
using System.Linq;
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

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static Configs dots;
        public static int w2 = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Igual_MouseEnter(object sender, MouseEventArgs e)
        {
            Igual.Background = Brushes.Red;
        }

        private void Igual_MouseLeave(object sender, MouseEventArgs e)
        {
            Igual.Background = Brushes.IndianRed;
        }

        private void Igual_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Igual.Background = Brushes.Red;
        }

        private void Igual_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Igual.Background = Brushes.IndianRed;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void btnUm_Click(object sender, RoutedEventArgs e)
        {
            txtBox.AppendText("1");
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



        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //if (this.WindowState == System.Windows.WindowState.Normal)
            //{
            //    this.WindowState = System.Windows.WindowState.Maximized;
            //}
            //else
            //{
            //    this.WindowState = System.Windows.WindowState.Normal;
            //}
        }

        private void btnDois_Click(object sender, RoutedEventArgs e)
        {
            txtBox.AppendText("2");
        }

        private void btnTres_Click(object sender, RoutedEventArgs e)
        {
            txtBox.AppendText("3");
        }

        private void backspace_Click(object sender, RoutedEventArgs e)
        {
            if (txtBox.Text.Length > 0)
            {
                var text = txtBox.Text;
                txtBox.Text = text.Remove(text.Length - 1);
            }
        }

        private void btnZero_Click(object sender, RoutedEventArgs e)
        {
            txtBox.AppendText("0");
        }

        private void btnSeis_Click(object sender, RoutedEventArgs e)
        {
            txtBox.AppendText("6");
        }

        private void btnCinco_Click(object sender, RoutedEventArgs e)
        {
            txtBox.AppendText("5");
        }

        private void btnQuatro_Click(object sender, RoutedEventArgs e)
        {
            txtBox.AppendText("4");
        }

        private void btnNove_Click(object sender, RoutedEventArgs e)
        {
            txtBox.AppendText("9");
        }

        private void btnOito_Click(object sender, RoutedEventArgs e)
        {
            txtBox.AppendText("8");
        }

        private void btnSete_Click(object sender, RoutedEventArgs e)
        {
            txtBox.AppendText("7");
        }

        private void txtBox_KeyDown(object sender, KeyEventArgs e)
        {

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
            string numeroTexto = txtBox.Text + caracterDigitado;
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
            //VisibilidadeDots();

            if (w2 == 0)
            {
                dots = new(); ;
                dots.Show();
                w2 = 1;
            }
        }

        private void btnErase_Click(object sender, RoutedEventArgs e)
        {
            txtBox.Text = "";
        }

        //public static void VisibilidadeDots()
        //{
        //    if (w2 == 0)
        //    {
        //        Configs dots = new(); ;
        //        dots.Show();
        //        btnDotsIcon.Visibility = Visibility.Collapsed;
        //    }
        //    else if (w2 == 1)
        //    {
        //        btnDotsIcon.Visibility = Visibility.Visible;
        //        w2 = 0;
        //    }

        //}
    }
}
