using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using static Ejercicio1.MainWindow;

namespace Ejercicio1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public class Producto
        {
            public string producto { get; set; }
            public string categoria { get; set; }
            public Double precio { get; set; }
            public int vendido { get; set; }
            public int stock {  get; set; }
           
        }
        public ObservableCollection<Producto> ListaProductos { get; set; }
         private ICollectionView vistaCategoria;
        public MainWindow()
        {
            InitializeComponent();

            ListaProductos = new ObservableCollection<Producto>
            {
                new Producto { producto = "Chance Chanel", categoria="Perfume", precio = 95, vendido = 15, stock = 10 },
                new Producto { producto = "Amor Amor Cacharel", categoria="Perfume",precio = 90, vendido = 17, stock = 15 },
                new Producto { producto = "Hidratante Sisheido", categoria="Skincare",precio = 75, vendido = 20, stock = 20 },
                new Producto { producto = "Serum Loreal", categoria="Skincare", precio = 60, vendido = 10, stock = 8 },
                new Producto { producto = "Barra labios", categoria="Maquillaje",precio = 3, vendido = 40, stock = 50 },
                new Producto { producto = "Locion hidratante", categoria="Bodycare",precio = 6, vendido = 30, stock = 25 }
            };

            dgFrutas.ItemsSource = ListaProductos;
            DataContext = this;

            vistaCategoria = CollectionViewSource.GetDefaultView(ListaProductos);
            dgFrutas.ItemsSource = vistaCategoria;
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProducto.Text))
            {
                MessageBox.Show("Debe rellenar este espacio" , "error" , MessageBoxButton.OK , MessageBoxImage.Error);
                txtProducto.Focus();
                return;

            }

            if (string.IsNullOrWhiteSpace(txtCategoria.Text))
            {
                MessageBox.Show("Debe rellenar este espacio", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtCategoria.Focus();
                return;

            }

            if(!Double.TryParse(txtPrecio.Text, out Double precio))
            {
                MessageBox.Show("Debe rellenar o cumplir con este espacio", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtPrecio.Focus();
                return;
            }

            if (!int.TryParse(txtPrecio.Text, out int vendido))
            {
                MessageBox.Show("Debe rellenar o cumplir con este espacio", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtVendido.Focus();
                return;
            }

            if (!int.TryParse(txtStock.Text, out int stock))
            {
                MessageBox.Show("Debe rellenar o cumplir con este espacio", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtStock.Focus();
                return;
            }

            ListaProductos.Add(new Producto
            {
                producto = txtProducto.Text,
                categoria = txtCategoria.Text,
                precio = precio,
                vendido = vendido,
                stock = stock


            });

            Limpiar();
        }

        private void Limpiar()
        {
            txtProducto.Text = null;
            txtCategoria.Text = null;
            txtPrecio.Text = null;
            txtVendido.Text = null;
            txtStock.Text = null;
        }

        private void BtnInforme_Click(object sender, RoutedEventArgs e)
        {
            List<Producto> listaProducto = ListaProductos.ToList();
            Window1 window1 = new Window1(listaProducto);
            window1.Show();

        }

        string[] categorias = { "Perfume", "Skincare", "maquillaje", "Bodycare", "Todos" };
        private void Combo_Categoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!categorias.Contains(Combo_Categoria.Text))
            {
                MessageBox.Show("Debe seleccionar primero la opcion");
                return;
            }

            string[] categoria_producto = categorias;

            vistaCategoria.Filter = obj =>
            {
                Producto p = obj as Producto;

                 if (p.categoria=="Perfume")
                {
                   return categorias == categoria_producto;

                }else if (p.categoria=="Skincare")
                {
                    return categorias == categoria_producto;

                }else if(p.categoria== "Maquillaje")
                {
                    return categorias == categoria_producto;

                }else if(p.categoria== "Bodycare")
                {
                    return categorias == categoria_producto;
                }
                else
                {
                    return categorias == categoria_producto;
                }

            };
        }
    }
}
