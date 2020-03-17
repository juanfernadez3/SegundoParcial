using SegundoParcial.BLL;
using SegundoParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SegundoParcial.UI.Consultas
{
    /// <summary>
    /// Lógica de interacción para FormularioConsulta.xaml
    /// </summary>
    public partial class FormularioConsulta : Window
    {
        public FormularioConsulta()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Llamadas>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltrarComboBox.SelectedIndex)
                {
                    case 0:
                        listado = LlamadasBLL.GetList(x => true);
                        break;

                    case 1:
                        int id;
                        id = int.Parse(CriterioTextBox.Text);
                        listado = LlamadasBLL.GetList(l => l.LlamadaId == id);
                        break;

                    case 2:

                        listado = LlamadasBLL.GetList(x => x.Descripcion == CriterioTextBox.Text);
                        break;
                }
            }
            else
            {
                listado = LlamadasBLL.GetList(l=> true);
            }
            ConsultarDataGrid.ItemsSource = null;
            ConsultarDataGrid.ItemsSource = listado;
        }
    }
}
