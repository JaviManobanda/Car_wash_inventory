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

        private DialogResult messageDialog(string caption)
        {
            DialogResult result;
            string message =
                    $"Nombre del producto: {infoProduct.txtNombre.Text}\n" +
                    $"Descripción: {infoProduct.txtDescripcion.Text}\n" +
                    $"Precio:  \n" +
                    $"Costo: \n" +
                    $"Unidad: {infoProduct.unidadesDict[infoProduct.cbxUnits.SelectedItem.ToString()]}\n" +
                    $"Código: {infoProduct.txtCodigo.Text} \n" +
                    $"Categoría: {infoProduct.CategoriaDict[infoProduct.cbxCategories.SelectedItem.ToString()]}\n" +
                    $"Bodega: {infoProduct.BodegaDict[infoProduct.cbxBodega.SelectedItem.ToString()]}\n" +
                    $"Marca: {infoProduct.MarcaDict[infoProduct.cbMarca.SelectedItem.ToString()]}\n" +
                    $"Cantidad total: {infoProduct.txtQTY.Text}\n" +
                    $"Packing: {infoProduct.PackingDict[infoProduct.CbxPacking.SelectedItem.ToString()]}";

            result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            return result;
        }
        private void button4_Click(object sender, EventArgs e)
        {// envia todos los datos a actualizar
            DialogResult result;

            try
                {
                result = messageDialog("Actualizar Datos");

                    if (result == System.Windows.Forms.DialogResult.Yes)
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

                        infoProduct.clearAllItems();
                    }
                    
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

                    MessageBox.Show("Selecciona un Item para actualizar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            DialogResult result;
            try
            {
                result = messageDialog("Eliminar Producto y bodega");
                if(result == System.Windows.Forms.DialogResult.Yes)
                {
                    sql.deletedProduct_and_bodega(product.Id, product.id_bodega_product);
                    infoProduct.clearAllItems();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Selecciona un Item para actualizar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void bntBorrarBodega_Click(object sender, EventArgs e)
        {
            DialogResult result;
            try
            {
                result = messageDialog("Eliminar bodega");
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    sql.deleteBodega( product.id_bodega_product);
                    infoProduct.clearAllItems();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Selecciona un Item para actualizar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_MouseHover(object sender, EventArgs e)
        {
            toolTipSave.Show("Guardar cambios", btnGuardar);
        }

        private void bntBorrarBodega_MouseHover(object sender, EventArgs e)
        {
            toolTipDelBodega.Show("Desvincular bodega", bntBorrarBodega);
        }

        private void btnBorrarAll_MouseMove(object sender, MouseEventArgs e)
        {
            toolTipDelAll.Show("Borra producto", btnBorrarAll);
        }
    }
}
