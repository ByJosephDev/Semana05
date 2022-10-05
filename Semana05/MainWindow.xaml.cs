using Business;
using Entity;
using Semana05.ViewModel;
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

namespace Semana05
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ManCategoriaViewModel viewModel;

        public int ID { get; set; }

        public MainWindow(int Id)
        {
            InitializeComponent();
            ID = Id;
            viewModel = new ManCategoriaViewModel();
            this.DataContext = viewModel;
            if (ID > 0)
            {
                BCategoria bCategoria = new BCategoria();
                List<Categoria> categorias = new List<Categoria>();
                categorias = bCategoria.Listar(ID);
                if (categorias.Count > 0)
                {
                    viewModel.ID = categorias[0].IdCategoria;
                    viewModel.Nombre = categorias[0].NombreCategoria;
                    viewModel.Descripcion = categorias[0].Descripcion;
                }
            }
        }

        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }


}
