using Business;
using System;
using System.Windows;
using System.Windows.Controls;


namespace Semana05
{
    /// <summary>
    /// Lógica de interacción para Product.xaml
    /// </summary>
    public partial class Product : Window
    {
        public Product()
        {
            InitializeComponent();
        }

        private void BtnListar_Click(object sender, RoutedEventArgs e)
        {
            Cargar();
        }

        private void BtnListarInactivos_Click(object sender, RoutedEventArgs e)
        {
            BProduct BProduct = null;
            try
            {
                BProduct = new BProduct();
                dgvProduct.ItemsSource = BProduct.ListarInactivos(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Comunicarse con el Administrador");

            }
            finally
            {
                BProduct = null;
            }
        }

        private void Cargar()
        {
            BProduct BProduct = null;
            try
            {
                BProduct = new BProduct();
                dgvProduct.ItemsSource = BProduct.Listar(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Comunicarse con el Administrador");

            }
            finally
            {
                BProduct = null;
            }
        }

        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        {
            MaintanceProduct maintanceProduct = new MaintanceProduct(0);
            maintanceProduct.ShowDialog();
            Cargar();
        }

        private void DgvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int IdProduct;
            var item = (Entity.Product)dgvProduct.SelectedItem;
            if (null == item) return;
            IdProduct = Convert.ToInt32(item.IdProduct);
            MaintanceProduct mainProduct = new MaintanceProduct(IdProduct);
            mainProduct.ShowDialog();
            Cargar();
        }

    }
}
