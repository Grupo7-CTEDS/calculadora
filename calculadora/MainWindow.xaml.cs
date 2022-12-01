using calculadora.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace calculadora
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Context context;

        Operation newOperation = new()
        {
            Id = Guid.NewGuid(),
            creationTime = DateTime.Now
        };
        public MainWindow(Context context)
        {
            this.context = context;
            InitializeComponent();

            
            NewOperationGrid.DataContext = newOperation;


        }

        private void ListOperations(object sender, RoutedEventArgs e)
        {
            List<Operation> OperationList = context.Operations.ToList();
            MessageBox.Show(OperationList.Last().op);

        }

        private void SaveOperation(object sender, RoutedEventArgs e)
        {
            context.Operations.Add(newOperation);
            context.SaveChanges();

            newOperation = new Operation()
            {
                Id = Guid.NewGuid(),
                creationTime = DateTime.Now
            };
            NewOperationGrid.DataContext = newOperation;
        }
    }
}
