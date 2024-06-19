using Proyecto_inventario.DB;
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

namespace Proyecto_inventario.views
{
    /// <summary>
    /// Lógica de interacción para editar_elementos.xaml
    /// </summary>
    public partial class editar_elementos : Window
    {
        private readonly SenaInventarioContext _db;

        public editar_elementos(int id, string nombre, string codigo, int? cantidad, int? idEstado, int? idCategoria, int? idPersonaEncargada)
        {
            InitializeComponent();
            getCombodatos();
            _db = new SenaInventarioContext();

            // Cargar los datos en los controles del formulario
            txt_nombre.Text = nombre;
            txt_cantidad.Text = cantidad.ToString();
            codigo_txt.Text = codigo;
            estado.SelectedValue = idEstado;
            categoria.SelectedValue = idCategoria;
            persona_encargada.SelectedValue = idPersonaEncargada;
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


        
    

        private void btn_editar_Click(object sender, RoutedEventArgs e)
        {

            using (var db = new SenaInventarioContext())
            {
                int id = (int)((Button)sender).CommandParameter;
                var elemento = db.Elementos.Find(id);

                if (elemento != null)
                {
                    elemento.NombreElemento = txt_nombre.Text;
                    elemento.CodigoElemento = codigo_txt.Text;
                    elemento.Cantidad = int.Parse(txt_cantidad.Text);
                    elemento.IdEstado = (int)estado.SelectedItem;
                    elemento.IdCategoria = (int)categoria.SelectedItem;
                    elemento.IdPersonaEncargada = (int)persona_encargada.SelectedItem;

                    db.SaveChanges();
                    MessageBox.Show("Elemento editado correctamente");
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se encontró el elemento");
                }
            }

        }
        private void estado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void persona_encargada_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void categoria_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void codigo_txt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txt_nombre_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }


}
