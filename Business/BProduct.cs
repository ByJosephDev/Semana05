using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BProduct
    {
        private DProduct DProduct = null;

        public List<Product> Listar(int IdProduct)
        {
            List<Product> products = null;
            try
            {
                DProduct = new DProduct();
                products = DProduct.Listar(new Product
                {
                    IdProduct = IdProduct
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return products;
        }

        public List<Product> ListarInactivos(int IdProduct)
        {
            List<Product> products = null;
            try
            {
                DProduct = new DProduct();
                products = DProduct.ListarInactivos(new Product
                {
                    IdProduct = IdProduct
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return products;
        }

        public bool Insertar(Product product)
        {
            bool result = true;
            try
            {
                DProduct = new DProduct();
                DProduct.Insertar(product);
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public bool Actualizar(Product product)
        {
            bool result = true;
            try
            {
                DProduct = new DProduct();
                DProduct.Actualizar(product);
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public bool Eliminar(int IdProduct)
        {
            bool result = true;
            try
            {
                DProduct = new DProduct();
                DProduct.Eliminar(IdProduct);
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public bool EliminarDefinitivo(int IdProduct)
        {
            bool result = true;
            try
            {
                DProduct = new DProduct();
                DProduct.EliminarDefinitivo(IdProduct);
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

    }
}
