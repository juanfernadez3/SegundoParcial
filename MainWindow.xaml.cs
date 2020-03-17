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
using SegundoParcial.UI.Registros;
using SegundoParcial.UI.Consultas;

namespace SegundoParcial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegistrarLlamada_Click(object sender, RoutedEventArgs e)
        {
            FormularioLlamada fl = new FormularioLlamada();
            fl.Show();
        }

        private void ConsultarLlamada_Click(object sender, RoutedEventArgs e)
        {
            FormularioConsulta fc = new FormularioConsulta();
            fc.Show();
        }
    }
}
