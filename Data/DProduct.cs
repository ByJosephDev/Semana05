using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DProduct
    {

        public List<Product> Listar(Product product)
        {
            SqlParameter[] parameters = null;
            string commandText = string.Empty;
            List<Product> products = null;

            try
            {
                commandText = "USP_GetProductActive";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@IdProduct", SqlDbType.Int);
                parameters[0].Value = product.IdProduct;
                products = new List<Product>();

                using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.Connection, commandText,
                    CommandType.StoredProcedure, parameters))
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            IdProduct = reader["IdProduct"] != null ? Convert.ToInt32(reader["IdProduct"]) : 0,
                            Name = reader["Name"] != null ? Convert.ToString(reader["Name"]) : string.Empty,
                            Price = reader["Price"] != null ? Convert.ToDouble(reader["Price"]) : 0,
                            IsActive = reader["IsActive"] as bool? == true ? Convert.ToString('A') : Convert.ToString('I')
                        });
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return products;

        }

        public List<Product> ListarInactivos(Product product)
        {
            SqlParameter[] parameters = null;
            string commandText = string.Empty;
            List<Product> products = null;

            try
            {
                commandText = "USP_GetProductInactive";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@IdProduct", SqlDbType.Int);
                parameters[0].Value = product.IdProduct;
                products = new List<Product>();

                using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.Connection, commandText,
                    CommandType.StoredProcedure, parameters))
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            IdProduct = reader["IdProduct"] != null ? Convert.ToInt32(reader["IdProduct"]) : 0,
                            Name = reader["Name"] != null ? Convert.ToString(reader["Name"]) : string.Empty,
                            Price = reader["Price"] != null ? Convert.ToDouble(reader["Price"]) : 0,
                            IsActive = reader["IsActive"] as bool? == true ? Convert.ToString('A') : Convert.ToString('I')
                        });
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return products;

        }

        public void Insertar(Product product)
        {
            SqlParameter[] parameters = null;
            string commandText = string.Empty;
            try
            {
                commandText = "USP_InsProduct";
                parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@Name", SqlDbType.VarChar);
                parameters[0].Value = product.Name;
                parameters[1] = new SqlParameter("@Price", SqlDbType.Decimal);
                parameters[1].Value = product.Price;
                SQLHelper.ExecuteNonQuery(SQLHelper.Connection, commandText, CommandType.StoredProcedure, parameters);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Actualizar(Product product)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;
            try
            {
                comandText = "USP_UpdProduct";
                parameters = new SqlParameter[4];
                parameters[0] = new SqlParameter("@IdProduct", SqlDbType.Int);
                parameters[0].Value = product.IdProduct;
                parameters[1] = new SqlParameter("@Name", SqlDbType.VarChar);
                parameters[1].Value = product.Name;
                parameters[2] = new SqlParameter("@Price", SqlDbType.Decimal);
                parameters[2].Value = product.Price;
                parameters[3] = new SqlParameter("@IsActive", SqlDbType.Bit);
                parameters[3].Value = product.IsActive == Convert.ToString('A') ? 1 : 0;
                SQLHelper.ExecuteNonQuery(SQLHelper.Connection, comandText, CommandType.StoredProcedure, parameters);

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public void Eliminar(int IdProduct)
        {
            SqlParameter[] parameters = null;
            string commandText = string.Empty;
            try
            {
                commandText = "USP_DelProduct";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@IdProduct", SqlDbType.Int);
                parameters[0].Value = IdProduct;
                SQLHelper.ExecuteNonQuery(SQLHelper.Connection, commandText, CommandType.StoredProcedure, parameters);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarDefinitivo(int IdProduct)
        {
            SqlParameter[] parameters = null;
            string commandText = string.Empty;
            try
            {
                commandText = "USP_DelFinallyProduct";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@IdProduct", SqlDbType.Int);
                parameters[0].Value = IdProduct;
                SQLHelper.ExecuteNonQuery(SQLHelper.Connection, commandText, CommandType.StoredProcedure, parameters);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
