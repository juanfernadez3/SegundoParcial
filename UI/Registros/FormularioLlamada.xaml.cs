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
using SegundoParcial.Entidades;
using SegundoParcial.BLL;

namespace SegundoParcial.UI.Registros
{
    /// <summary>
    /// Lógica de interacción para FormularioLlamada.xaml
    /// </summary>
    public partial class FormularioLlamada : Window
    {
        Llamadas llamada = new Llamadas();
        public List<LlamadaDetalle> Detalle { get; set; }

        public FormularioLlamada()
        {
            InitializeComponent();
            this.DataContext = llamada;
            this.Detalle = new List<LlamadaDetalle>();
            LlamadaIdTextBox.Text = "0";
        }
        private void Limpiar()
        {
            LlamadaIdTextBox.Text = "0";
            DescripcionTexbox.Text = string.Empty;

            this.Detalle = new List<LlamadaDetalle>();
            CargarGrid();
        }



        private void CargarGrid()
        {
            LlamadaDetalleDataGrid.ItemsSource = null;
            LlamadaDetalleDataGrid.ItemsSource = this.Detalle;
        }

        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = llamada;
        }


        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private bool ExisteEnDb()
        {
            Llamadas llamada = LlamadasBLL.Buscar(Convert.ToInt32(LlamadaIdTextBox.Text));
            return (llamada != null);
        }

        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrEmpty(DescripcionTexbox.Text))
            {
                MessageBox.Show("El campo descripcion no puede estar vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                paso = false;
                DescripcionTexbox.Focus();
            }

            if (this.Detalle.Count == 0)
            {
                MessageBox.Show("Debe agregar un telefono", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                paso = false;
            }

            return paso;
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (!Validar())
                return;

            if (string.IsNullOrEmpty(LlamadaIdTextBox.Text) || LlamadaIdTextBox.Text == "0")
                paso = LlamadasBLL.Guardar(llamada);
            else
            {
                if (!ExisteEnDb())
                {
                    MessageBox.Show("No se puede agregar alguien que no existe", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                    return;
                }
                paso = LlamadasBLL.Modificar(llamada);
            }

            if (paso)
            {
                MessageBox.Show("Guardado!!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("No guardo", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(LlamadaIdTextBox.Text, out id);

            Limpiar();
            if (LlamadasBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No Eliminado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            if (LlamadaDetalleDataGrid.Items.Count > 0 && LlamadaDetalleDataGrid.SelectedItem != null)
            {
                this.Detalle.RemoveAt(LlamadaDetalleDataGrid.SelectedIndex);
                CargarGrid();
            }
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            if (LlamadaDetalleDataGrid.ItemsSource != null)
                this.Detalle = (List<LlamadaDetalle>)LlamadaDetalleDataGrid.ItemsSource;

            this.Detalle.Add(new LlamadaDetalle()
            {
                Id = 0,
                Problema = ProblemaTextBox.Text,
                Solucion = SolucionTextBox.Text
            });

            CargarGrid();
            ProblemaTextBox.Text = string.Empty;
            SolucionTextBox.Text = string.Empty;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(LlamadaIdTextBox.Text, out id);

            llamada = LlamadasBLL.Buscar(id);

            if (llamada != null)
            {
                this.DataContext = llamada;
                Actualizar();
            }
            else
            {
                MessageBox.Show("No encontrado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
