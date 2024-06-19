using Proyecto_inventario.DB;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;

namespace Proyecto_inventario.views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            getElementos();
           
        }

        public void gemail()
        {
            // Configuración del correo electrónico
            string senderEmail = "alexandersauna05@gmail.com";
            string senderPassword = "Alex9124";
            string recipientEmail = "alexandersauna05@gmail.com";
            string subject = "Test Email";
            string body = "Hola, como estas Alexander?";

            // Crear el objeto MailMessage
            MailMessage message = new MailMessage();
            message.From = new MailAddress(senderEmail);
            message.To.Add(new MailAddress(recipientEmail));
            message.Subject = subject;
            message.Body = body;

            // Configuración del cliente SMTP
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.Credentials = new NetworkCredential(senderEmail, senderPassword);

            // Enviar el correo electrónico
            client.Send(message);
        }
        public void getElementos()
        {
            using (SenaInventarioContext db = new SenaInventarioContext())
            {
                var query = from elementos in db.Elementos
                            join categoria in db.Categorias on elementos.IdCategoria equals categoria.Id
                            join persona in db.Personas on elementos.IdPersonaEncargada equals persona.Id
                            join estado in db.EstadoElementos on elementos.IdEstado equals estado.Id
                            select new
                            {
                                id=elementos.Id,
                                cd=elementos.CodigoElemento,
                                nm=elementos.NombreElemento,
                                ec=elementos.Cantidad,
                                pn=persona.Nombre,
                                es=estado.NombreEstadoElemento,
                                cg=categoria.NombreCategoria

                            };
                dataproductos.ItemsSource = query.ToList();

            };

        }

        

        public void buscarDatos()
        {
            var txtbuscar = txtbuscado.Text.Trim(); // Obtener el texto del cuadro de búsqueda
            using (SenaInventarioContext db = new SenaInventarioContext())
            {
                // Construir la consulta con filtro por código y nombre
                var query = from elementos in db.Elementos
                            join categoria in db.Categorias on elementos.IdCategoria equals categoria.Id
                            join persona in db.Personas on elementos.IdPersonaEncargada equals persona.Id
                            join estado in db.EstadoElementos on elementos.IdEstado equals estado.Id
                            where elementos.CodigoElemento.Contains(txtbuscar) || elementos.NombreElemento.Contains(txtbuscar)
                            select new
                            {
                                cd = elementos.CodigoElemento,
                                nm = elementos.NombreElemento,
                                ec = elementos.Cantidad,
                                pn = persona.Nombre,
                                es = estado.NombreEstadoElemento,
                                cg = categoria.NombreCategoria
                            };
                dataproductos.ItemsSource = query.ToList(); // Asignar los resultados al origen de datos
            }
           
        }

        private void txtbuscado_TextChanged(object sender, TextChangedEventArgs e)
        {
            buscarDatos(); // Llamar al método de búsqueda cada vez que se modifica el texto
        }

       
        private void btneliminar_Click(object sender, RoutedEventArgs e)
        {
            using (SenaInventarioContext db = new SenaInventarioContext())
            {
                int id_elemento = (int)((Button)sender).CommandParameter;
                var elemento=db.Elementos.Find(id_elemento);
                if (elemento !=null)
                {
                    var opcevaluar = MessageBox.Show($"¿Estás seguro de eliminar el elemento '{elemento.NombreElemento}'?", "Confirmación de eliminación", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (opcevaluar == MessageBoxResult.Yes)
                    {
                        
                        db.Elementos.Remove(elemento);
                        db.SaveChanges();
                        getElementos();
                    }
                    //else
                    //{
                    //    MessageBox.Show("se cancelo la eliminacion");
                    //}

                }
               
            }
            
        }


        //metodo para agarrar los cambios 
        private void btneditar_Click(object sender, RoutedEventArgs e)
        {
            using (SenaInventarioContext db = new SenaInventarioContext())
            {
                int id_editar = (int)((Button)sender).CommandParameter;
                var elemento = db.Elementos.Find(id_editar);
                editar_elementos editar_Elementos = new editar_elementos(elemento.Id, elemento.NombreElemento, elemento.CodigoElemento, elemento.Cantidad, elemento.IdEstado, elemento.IdCategoria, elemento.IdPersonaEncargada);
                editar_Elementos.Show();
                this.Close();
            }

        }

       //metodo para agregar ubn nuevo producto
        private void btnagregar_Click(object sender, RoutedEventArgs e)
        {
            add_producto add_Producto = new add_producto();
            add_Producto.Show();
            Close();
            
        }

        

        private void combo_categoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
    

