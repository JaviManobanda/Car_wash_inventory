using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace inventary
{
    public class MySQL_Logic
    {
        string servidor = null;
        string db = null;
        string user = null;
        string password = null;

        MySqlConnection conexionBD;
        MySqlCommand sqlComman;
        MySqlConnection conexionDB;
        MySqlDataReader sqlReader;


        public MySQL_Logic( string servidor, string db, string user, string password)
        {
            this.servidor = servidor;
            this.db = db;
            this.user = user;
            this.password = password;

            string stringConnection = "Database=" + db + "; Data Source=" + servidor + "; User Id=" + user + "; Password=" + password + "";
            conexionBD = new MySqlConnection(stringConnection);

        }

        public void AddProduct(string name, string description, string unit_price, string unit_cost, string img_url, string units, string category, string marca , string codigo)
        {

            string command = "insert into products(name, description,unit_price, unit_cost, imagen, id_units, id_category, id_marca, codigo) values('" 
                + name+"', '" + description+"', "+unit_price+", "+unit_cost+",'"+img_url+
                "', (select idunits from units where name = '"+units+"'),(select idcategory from category where name = '"+
                category+"'),(select idmarca from marca where name = '"+marca+"'),'"+codigo+"')";

            insertData(command);
        }

        public void addProduct_to_Bodega(string nombre_bodega, string codigo, string cantidad, string packing)
        {
            string command = "insert into bodega_product(id_bodega, id_product,stock,id_packing) values((select idbodega from bodega where name = '"+ nombre_bodega +
                "'),(select idproducts from products where codigo = '" + codigo + "')," + cantidad + 
                ",(select idpacking from packing where name = '"+packing+"'))";

            insertData(command);
        }


        private void insertData(string command)
        {
            try
            {
                sqlComman = new MySqlCommand(command);
                sqlComman.Connection = conexionBD;
                conexionBD.Open();

                sqlComman.ExecuteReader();
                 
                conexionBD.Close();
            }
            catch (Exception ex)
            {
                conexionBD.Close();
                MessageBox.Show("Error: " + ex.ToString());
            }
        }
        public List<string> getUnitsProduct()
        {
            List<string> unitsProducts = new List<string>();

            string command = "select * from units";

            try
            {
                sqlComman = new MySqlCommand(command);
                sqlComman.Connection = conexionBD;
                conexionBD.Open();

                sqlReader = sqlComman.ExecuteReader();

                while (sqlReader.Read())
                {
                    unitsProducts.Add(sqlReader.GetString(1));
                }

                conexionBD.Close();
            }
            catch (Exception)
            {
                conexionBD.Close();
                throw;
            }

            return unitsProducts;

        }


        public List<string> getCategoryProduct()
        {
            List<string> categoriesProducts = new List<string>();

            string command = "select * from category";

            try
            {
                sqlComman = new MySqlCommand(command);
                sqlComman.Connection = conexionBD;
                conexionBD.Open();

                sqlReader = sqlComman.ExecuteReader();

                while (sqlReader.Read())
                {
                    categoriesProducts.Add(sqlReader.GetString(1));
                }
                conexionBD.Close();

            }
            catch (Exception)
            {
                conexionBD.Close();
                throw;
            }

            return categoriesProducts;

        }



        public List<string> getMarcaProduct()
        {
            List<string> marcasProducts = new List<string>();

            string command = "select * from marca";

            try
            {
                sqlComman = new MySqlCommand(command);
                sqlComman.Connection = conexionBD;
                conexionBD.Open();

                sqlReader = sqlComman.ExecuteReader();

                while (sqlReader.Read())
                {
                    marcasProducts.Add(sqlReader.GetString(1));
                }
                conexionBD.Close();

            }
            catch (Exception)
            {
                conexionBD.Close();
                throw;
            }

            return marcasProducts;

        }


        public List<string> getBodega()
        {
            List<string> bodegas = new List<string>();

            string command = "select * from bodega";

            try
            {
                sqlComman = new MySqlCommand(command);
                sqlComman.Connection = conexionBD;
                conexionBD.Open();

                sqlReader = sqlComman.ExecuteReader();

                while (sqlReader.Read())
                {
                    bodegas.Add(sqlReader.GetString(1));
                }
                conexionBD.Close();

            }
            catch (Exception)
            {
                conexionBD.Close();
                throw;
            }

            return bodegas;

        }

        public List<string> getPacking()
        {
            List<string> packings = new List<string>();

            string command = "select * from packing";

            try
            {
                sqlComman = new MySqlCommand(command);
                sqlComman.Connection = conexionBD;
                conexionBD.Open();

                sqlReader = sqlComman.ExecuteReader();

                while (sqlReader.Read())
                {
                    packings.Add(sqlReader.GetString(1));
                }
                conexionBD.Close();

            }
            catch (Exception)
            {
                conexionBD.Close();
                throw;
            }

            return packings;
        }



    }
}
