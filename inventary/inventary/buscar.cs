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
        string id_bodega_product = string.Empty;

        string[] filters = new string[] {
            "Seleccionar ..",
            "Nombre",
            "Marca",
            "Bodega",
            "Descripción"
        };
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
            cbxFilter.Items.AddRange(filters);
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
            var tupleValuesTable = sql.searchProducts(txtSearch.Text, "marca.name");
            this.id_bodega_product = tupleValuesTable.Item2;
            dataView.DataSource = tupleValuesTable.Item1;
        }

        private void button4_Click(object sender, EventArgs e)
        {// envia todos los datos a actualizar
            sql.updateProduct(
                product.Id,
                infoProduct.txtNombre.Text,
                infoProduct.txtDescripcion.Text,
                infoProduct.unidadesDict[infoProduct.cbxUnits.SelectedItem.ToString()],
                infoProduct.CategoriaDict[infoProduct.cbxCategories.SelectedItem.ToString()],
                infoProduct.MarcaDict[infoProduct.cbMarca.SelectedItem.ToString()],
                product.Stock, infoProduct.PackingDict[infoProduct.CbxPacking.SelectedItem.ToString()],
                infoProduct.BodegaDict[infoProduct.cbxBodega.SelectedItem.ToString()],
                id_bodega_product                                                         
                );
        }

        private void dataView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
       
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
    }
}
