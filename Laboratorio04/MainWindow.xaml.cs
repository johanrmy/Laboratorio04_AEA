using System.Data;
using System.Data.SqlClient;
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

namespace Laboratorio04
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

        private void btnProducto_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=LAB1504-18\\SQLEXPRESS;Initial Catalog=Neptuno;User Id=tecsup;Password=123456";
            List<Producto> productos = new List<Producto>();

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand("USP_listar_productos", connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int Idproducto = reader.IsDBNull("idproducto") ? 0 : reader.GetInt32("idproducto");
                    string NombreProducto = reader.IsDBNull("nombreProducto") ? string.Empty : reader.GetString("nombreProducto");
                    string CantidadPorUnidad = reader.IsDBNull("cantidadPorUnidad") ? string.Empty : reader.GetString("cantidadPorUnidad");
                    decimal PrecioUnidad = reader.IsDBNull("precioUnidad") ? 0 : reader.GetDecimal("precioUnidad");
                    int UnidadesEnExistencia = reader.IsDBNull("unidadesEnExistencia") ? 0 : reader.GetInt16("unidadesEnExistencia");
                    int UnidadesEnPedido = reader.IsDBNull("unidadesEnPedido") ? 0 : reader.GetInt16("unidadesEnPedido");
                    int NivelNuevoPedido = reader.IsDBNull("nivelNuevoPedido") ? 0 : reader.GetInt16("nivelNuevoPedido");
                    int Suspendido = reader.IsDBNull("suspendido") ? 0 : reader.GetInt16("suspendido");
                    string CategoriaProducto = reader.IsDBNull("categoriaProducto") ? string.Empty : reader.GetString("categoriaProducto");

                    productos.Add(new Producto
                    {
                        idproducto = Idproducto,
                        nombreProducto = NombreProducto,
                        cantidadPorUnidad = CantidadPorUnidad,
                        precioUnidad = PrecioUnidad,
                        unidadesEnExistencia = UnidadesEnExistencia,
                        unidadesEnPedido = UnidadesEnPedido,
                        nivelNuevoPedido = NivelNuevoPedido,
                        suspendido = Suspendido,
                        categoriaProducto = CategoriaProducto,
                    });
                }


                connection.Close();


                dgGrid.ItemsSource = productos;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnCategoria_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=LAB1504-18\\SQLEXPRESS;Initial Catalog=Neptuno;User Id=tecsup;Password=123456";
            List<Categoria> categorias = new List<Categoria>();

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand("USP_listar_categorias", connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int Idcategoria = reader.IsDBNull("idcategoria") ? 0 : reader.GetInt32("idcategoria");
                    string Nombrecategoria = reader.IsDBNull("nombrecategoria") ? string.Empty : reader.GetString("nombrecategoria");
                    string Descripcion = reader.IsDBNull("descripcion") ? string.Empty : reader.GetString("descripcion");
                    bool Activo = reader.IsDBNull("Activo") ? false : reader.GetBoolean("Activo");
                    string CodCategoria = reader.IsDBNull("CodCategoria") ? string.Empty : reader.GetString("CodCategoria");


                    categorias.Add(new Categoria
                    {
                        idcategoria = Idcategoria,
                        nombrecategoria = Nombrecategoria,
                        descripcion = Descripcion,
                        Activo = Activo,
                        CodCategoria = CodCategoria,
                    });
                }

                connection.Close();

                dgGrid.ItemsSource = categorias;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

    }
}