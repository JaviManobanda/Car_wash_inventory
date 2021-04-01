using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventary
{
    public partial class buscar : UserControl
    {
        string servidor = "localhost";
        string db = "inventary_car_wash";
        string user = "root";
        string password = "2527";

        string initTextCbx = "Seleccionar ..";


        Dictionary<string, string> FilterOptions = new Dictionary<string, string>() { };
        Products product;

        MySQL_Logic sql;
        public buscar()
        {
            InitializeComponent();
            initComponents();
        }

        private void initComponents()
        {
            sql = MySQL_Logic.getInstance(servidor, db, user, password);

            FilterOptions.Add("Nombre","products.name");
            FilterOptions.Add("Marca","marca.name");
            FilterOptions.Add("Bodega","bodega.name");
            FilterOptions.Add("Descripción","products.description");
            List<string> listOptionsFilters = FilterOptions.Keys.ToList();
            cbxFilter.Items.Add(initTextCbx);
            cbxFilter.Items.AddRange(listOptionsFilters.ToArray());
            clearAll();
        }

        private void clearAll()
        {
            cbxFilter.SelectedIndex = 0;
            txtSearch.Clear();
        }
        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                dataView.DataSource = sql.searchProducts(txtSearch.Text, FilterOptions[cbxFilter.SelectedItem.ToString()]);
            }
            catch (Exception)
            {

                MessageBox.Show("Ingrese un filtro", "Error",  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {// envia todos los datos a actualizar

            try
            {
                sql.updateProduct(
                product.Id,
                infoProduct.txtNombre.Text,
                infoProduct.txtDescripcion.Text,
                infoProduct.unidadesDict[infoProduct.cbxUnits.SelectedItem.ToString()],
                infoProduct.CategoriaDict[infoProduct.cbxCategories.SelectedItem.ToString()],
                infoProduct.MarcaDict[infoProduct.cbMarca.SelectedItem.ToString()],
                infoProduct.txtQTY.Text,
                infoProduct.PackingDict[infoProduct.CbxPacking.SelectedItem.ToString()],
                infoProduct.BodegaDict[infoProduct.cbxBodega.SelectedItem.ToString()],
                product.id_bodega_product
                );
                MessageBox.Show(product.ToString(), "se ha almacenado");
                infoProduct.clearAllItems();
            }
            catch (Exception)
            {

                MessageBox.Show("Selecciona un Item para actualizar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void dataView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            product = new Products();
            if (dataView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataView.CurrentRow.Selected = true;
                product.Id = dataView.Rows[e.RowIndex].Cells[0].Value.ToString();
                product.Nombre = dataView.Rows[e.RowIndex].Cells[1].Value.ToString();
                product.Descripcion = dataView.Rows[e.RowIndex].Cells[2].Value.ToString();
                product.Codigo = dataView.Rows[e.RowIndex].Cells[3].Value.ToString();
                product.Marca= dataView.Rows[e.RowIndex].Cells[4].Value.ToString();
                product.Categoria = dataView.Rows[e.RowIndex].Cells[5].Value.ToString();
                product.Unidades = dataView.Rows[e.RowIndex].Cells[6].Value.ToString();
                product.Stock = dataView.Rows[e.RowIndex].Cells[7].Value.ToString();
                product.Packing = dataView.Rows[e.RowIndex].Cells[8].Value.ToString();
                product.Bodega= dataView.Rows[e.RowIndex].Cells[9].Value.ToString();
                product.id_bodega_product = dataView.Rows[e.RowIndex].Cells[10].Value.ToString();

                try
                {
                    infoProduct.fillProduct(
                        product.Id,
                        product.Nombre,
                        product.Descripcion,
                        product.Codigo,
                        product.Marca, 
                        product.Categoria,
                        product.Unidades, 
                        product.Stock,
                        product.Packing,
                        product.Bodega);

                }
                catch (Exception)
                {

                    throw;
                }

            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                sql.deleteProduct(product.Id, product.id_bodega_product);
                MessageBox.Show("Se borra");
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
