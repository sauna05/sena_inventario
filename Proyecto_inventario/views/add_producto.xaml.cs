using Proyecto_inventario.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

namespace Proyecto_inventario.views
{
    /// <summary>
    /// Lógica de interacción para add_producto.xaml
    /// </summary>
    public partial class add_producto : Window
    {
        public add_producto()
        {
            InitializeComponent();
            getCombodatos();
        }

        public void getCombodatos()
        {
            using (var db = new SenaInventarioContext())
            {
                var categorias = db.Categorias.ToList();
                categoria.ItemsSource = categorias;
                categoria.SelectedValuePath = "id";
                categoria.DisplayMemberPath = "NombreCategoria";

                var personas = db.Personas.ToList();
                persona_encargada.ItemsSource = personas;
                persona_encargada.SelectedValuePath = "id";
                persona_encargada.DisplayMemberPath = "Nombre";

                var estados = db.EstadoElementos.ToList();
                estado.ItemsSource = estados;
                estado.SelectedValuePath = "id";
                estado.DisplayMemberPath = "NombreEstadoElemento";
            }
        }


        private void categoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void persona_encargada_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        public void registrar_producto()
        {
            try
            {
                using (SenaInventarioContext db = new SenaInventarioContext())
                {
                    if (string.IsNullOrEmpty(txt_nombre.Text))
                    {
                        MessageBox.Show("Este campo nombre es obligatorio");
                    }
                    else if (string.IsNullOrEmpty(txt_cantidad.Text))
                    {
                        MessageBox.Show("Este campo cantidad es obligatorio");
                    }
                    else if (string.IsNullOrEmpty(codigo_txt.Text))
                    {
                        MessageBox.Show("Este campo cadigo es obligatorio");
                    }
                    else if (categoria.SelectedItem == null)
                    {
                        MessageBox.Show("selecione una categoria");
                    }
                    else if (persona_encargada.SelectedItem == null)
                    {
                        MessageBox.Show("selecione la persona encargada");
                    }
                    else
                    {
                        Elemento nuevo_elemento = new Elemento();
                        nuevo_elemento.NombreElemento = txt_nombre.Text;
                        nuevo_elemento.CodigoElemento = codigo_txt.Text;

                        if (estado.SelectedItem is EstadoElemento selectedEstado)
                        {
                            nuevo_elemento.IdEstado = selectedEstado.Id;
                        }
                        else
                        {
                            MessageBox.Show("Seleccione un estado válido");
                            return;
                        }

                        if (categoria.SelectedItem is Categoria selectedCategoria)
                        {
                            nuevo_elemento.IdCategoria = selectedCategoria.Id;
                        }
                        else
                        {
                            MessageBox.Show("Seleccione una categoría válida");
                            return;
                        }

                        if (persona_encargada.SelectedItem is Persona selectedPersona)
                        {
                            nuevo_elemento.IdPersonaEncargada = selectedPersona.Id;
                        }
                        else
                        {
                            MessageBox.Show("Seleccione una persona encargada válida");
                            return;
                        }

                        nuevo_elemento.Cantidad = int.Parse(txt_cantidad.Text);

                        db.Elementos.Add(nuevo_elemento);
                        db.SaveChanges();
                        MessageBox.Show("Se registró correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar: " + ex, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            registrar_producto();
           
        }

        private void categoria_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void estado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
