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
        MySqlDataReader sqlReader;


        private static MySQL_Logic _instance;

        private MySQL_Logic( string servidor, string db, string user, string password)
        {
            this.servidor = servidor;
            this.db = db;
            this.user = user;
            this.password = password;

            string stringConnection = "Database=" + db + "; Data Source=" + servidor + "; User Id=" + user + "; Password=" + password + "";
            conexionBD = new MySqlConnection(stringConnection);

        }

        public static MySQL_Logic getInstance(string servidor, string db, string user, string password)
        {
            if (_instance == null)
            {
                _instance = new MySQL_Logic(servidor, db, user, password);
            }

            return _instance;
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
        public Dictionary<string, string> getUnitsProduct()
        {

            
            string command = "select * from units";
            return getItems(command);

        }

        public Dictionary<string, string> getCategoryProduct()
        {
            string command = "select * from category";
            return getItems(command);

        }

        public Dictionary<string, string> getMarcaProduct()
        {
            string command = "select * from marca";
            return getItems(command);

        }

        public Dictionary<string, string> getBodega()
        {
            string command = "select * from bodega";
            return getItems(command);

        }

        public Dictionary<string, string> getPacking()
        {
            string command = "select * from packing";
            return getItems(command);
        }

        private Dictionary<string, string> getItems(string command)
        {
            Dictionary<string, string> dictValues = new Dictionary<string, string>();

            try
            {
                sqlComman = new MySqlCommand(command);
                sqlComman.Connection = conexionBD;
                conexionBD.Open();

                sqlReader = sqlComman.ExecuteReader();

                while (sqlReader.Read())
                {

                    dictValues.Add(sqlReader.GetString(1), sqlReader.GetString(0));

                }

                conexionBD.Close();
            }
            catch (Exception)
            {
                conexionBD.Close();
                throw;
            }

            return dictValues;
        }
        public List<Products>  searchProducts(string searchItem, string filter)
        {
            List<Products> ProductList = new List<Products>();

            string command = "select products.idproducts, products.name, products.description,  products.codigo, " +
                                "marca.name as marca, " +
                                "category.name as category, " +
                                "units.name as units, " +
                                "bodega_product.stock as stock, " +
                                "packing.name as packing, " +
                                "bodega.name as bodega, " +
                                "bodega_product.id as id_bodega_product "+
                                "from products " +
                                "left join marca on marca.idmarca = products.id_marca " +
                                "left join category on category.idcategory = products.id_category " +
                                "left join units on units.idunits = products.id_units " +
                                "left join bodega_product on bodega_product.id_product = products.idproducts " +
                                "left join packing on packing.idpacking = bodega_product.id_packing " +
                                "left join bodega on bodega.idbodega = bodega_product.id_bodega " +
                                "where "+filter+" like '%"+ searchItem + "%'";

            string id_bodegaProduct = string.Empty;

            try
            {
                sqlComman = new MySqlCommand(command);
                sqlComman.Connection = conexionBD;
                conexionBD.Open();

                sqlReader = sqlComman.ExecuteReader();

                while (sqlReader.Read())
                {
                    ProductList.Add(new Products() {
                        Id = sqlReader.GetString(0),
                        Nombre  = sqlReader.GetString(1),
                        Descripcion= sqlReader.GetString(2),
                        Codigo = sqlReader.GetString(3),
                        Marca  = sqlReader.GetString(4),
                        Categoria= sqlReader.GetString(5),
                        Unidades = sqlReader.GetString(6),
                        Stock = sqlReader.GetString(7),
                        Packing = sqlReader.GetString(8),
                        Bodega  = sqlReader.GetString(9),
                        id_bodega_product = sqlReader.GetString(10)
                    });


                }
                conexionBD.Close();

            }
            catch (Exception)
            {
                conexionBD.Close();
                throw;
            }

            return ProductList;
        }


        public void updateProduct(string id, string name,
            string description, string units, string category,
            string marca, string stock, string packing, string id_bodega, string id_bodega_product)
        {
            //update producto
            string command = "update products " +
                "set " +
                "name = '" + name + "', " +
                "description = '" + description + "', " +
                "id_units = " + units + ", " +
                "id_category =" + category + ", " +
                "id_marca = " + marca + " " +
                "where idproducts =" + id ;

            insertData(command);

            //updtate bodega
            command = "update bodega_product " +
                "set " +
                "id_bodega =" + id_bodega + "," +
                "stock=" + stock + "," +
                "id_packing=" + packing + " " +
                "where id =" + id_bodega_product;

            insertData(command);
        }

        public void deleteProduct(string id_product)
        {
            string command = "DELETE FROM products WHERE idproducts =" + id_product;
            insertData(command);
        }

        public void deleteBodega(string id_bodega_producto)
        {
            string command = "DELETE FROM bodega_product WHERE id =" + id_bodega_producto;
            insertData(command);
        }

        public void deletedProduct_and_bodega(string id_product, string id_bodega_producto)
        {
            deleteBodega(id_bodega_producto);
            deleteProduct(id_product);
        }
    }
}
