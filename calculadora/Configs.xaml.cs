using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace calculadora
{
    /// <summary>
    /// Lógica interna para Configs.xaml
    /// </summary>
    public partial class Configs : Window
    {
        public Configs()
        {
            InitializeComponent();
        }

        private void btnToCloseW2_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.w2 = 0;
            //MainWindow.VisibilidadeDots();
            Close();
        }

       

        public void segundaTela_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //if (e.ChangedButton == MouseButton.Left)
            //{

            //    MainWindow.dots.DragMove();
                
            //}
        }
    }
}
