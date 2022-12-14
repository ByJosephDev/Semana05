using Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Semana05.ViewModel
{
    public class ListaCategoriaViewModel : ViewModelBase
    {

        public ObservableCollection<Categoria> Categorias { get; set; }

        public ICommand NuevoCommand { set; get; }

        public ICommand ConsultarCommand { set; get; }

        public ListaCategoriaViewModel()
        {
            Categorias = new Model.CategoriaModel().Categorias;

            NuevoCommand = new RelayCommand<Window>(
                param => Abrir());

            ConsultarCommand = new RelayCommand<object>(
                o => Categorias = new Model.CategoriaModel().Categorias);

            void Abrir()
            {
                MainWindow window = new MainWindow(0);
                window.ShowDialog();
            }

        }


    }
}
