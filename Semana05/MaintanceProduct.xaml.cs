using Business;
using System;
using System.Collections.Generic;
using System.Windows;


namespace Semana05
{
    /// <summary>
    /// Lógica de interacción para MaintanceProduct.xaml
    /// </summary>
    public partial class MaintanceProduct : Window
    {

        public int ProductID { get; set; }
        public MaintanceProduct(int productID)
        {
            InitializeComponent();
            ProductID = productID;
            if (ProductID > 0)
            {
                BProduct Bproduct = new BProduct();
                List < Entity.Product> products = new List<Entity.Product>();
                products = Bproduct.Listar(ProductID);
                if (products.Count > 0)
                {
                    lblID.Content = products[0].IdProduct.ToString();
                    txtName.Text = products[0].Name;
                    txtPrice.Text = products[0].Price.ToString();
                    if (products[0].IsActive == Convert.ToString('A'))
                    {
                        checkActive.IsChecked = true;
                        checkActive.IsEnabled = false;
                        btnEliminarDefinitivo.IsEnabled = false;
                    }
                    else
                    {
                        checkActive.IsChecked = false;
                        btnEliminarDefinitivo.IsEnabled = true;
                        btnEliminar.IsEnabled = false;
                    }

                }
            }
            else
            {
                checkActive.IsEnabled = false;
                btnEliminarDefinitivo.IsEnabled = false;
                btnEliminar.IsEnabled = false;
            }
        }

        private void BtnGrabar_Click(object sender, RoutedEventArgs e)
        {
            BProduct Bproduct = null;
            bool result = true;

            string vChecked = Convert.ToString('I');

            try
            {
                Bproduct = new BProduct();
                if (ProductID > 0)
                {   
                    if(checkActive.IsChecked == true)
                    {
                        vChecked = Convert.ToString('A');
                    }
                    result = Bproduct.Actualizar(new Entity.Product
                    {
                        IdProduct = ProductID,
                        Name = txtName.Text,
                        Price = Convert.ToDouble(txtPrice.Text),
                        IsActive = vChecked
                    });
                }
                else
                {
                    result = Bproduct.Insertar(new Entity.Product
                    {
                        Name = txtName.Text,
                        Price = Convert.ToDouble(txtPrice.Text)
                    });
                }
                if (!result)
                {
                    MessageBox.Show("Comunicarse con el Administrador");
                }
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Comunicarse con el Administrador");
            }
            finally
            {
                Bproduct = null;
            }
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            BProduct Bproduct = null;
            bool result = true;

            try
            {
                Bproduct = new BProduct();
                if (ProductID > 0)
                {
                    result = Bproduct.Eliminar(ProductID);
                }
                if (!result)
                {
                    MessageBox.Show("Comunicarse con el Administrador");
                }
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Comunicarse con el Administrador");
            }
            finally
            {
                Bproduct = null;
            }
        }

        private void BtnEliminarDefinitivo_Click(object sender, RoutedEventArgs e)
        {
            BProduct Bproduct = null;
            bool result = true;

            try
            {
                Bproduct = new BProduct();
                if (ProductID > 0)
                {
                    result = Bproduct.EliminarDefinitivo(ProductID);
                }
                if (!result)
                {
                    MessageBox.Show("Comunicarse con el Administrador");
                }
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Comunicarse con el Administrador");
            }
            finally
            {
                Bproduct = null;
            }
        }

        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
