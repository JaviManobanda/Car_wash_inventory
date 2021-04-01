using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace inventary
{
    public partial class addProducts : UserControl
    {

        string textSelect = "Seleccionar...";
        string servidor = "localhost";
        string db = "inventary_car_wash";
        string user = "root";
        string password = "2527";

        public Dictionary<string, string> unidadesDict = new Dictionary<string, string>();
        public Dictionary<string, string> CategoriaDict = new Dictionary<string, string>();
        public Dictionary<string, string> BodegaDict = new Dictionary<string, string>();
        public Dictionary<string, string> MarcaDict = new Dictionary<string, string>();
        public Dictionary<string, string> PackingDict = new Dictionary<string, string>();


        MySQL_Logic sql;



        public addProducts()
        {
            InitializeComponent();
            initComponents();
 
        }

        private void initComponents()
        {

            sql = MySQL_Logic.getInstance(servidor, db, user, password);


            cbxUnits.Items.Add(textSelect);
            cbxCategories.Items.Add(textSelect);
            cbMarca.Items.Add(textSelect);
            cbxBodega.Items.Add(textSelect);
            CbxPacking.Items.Add(textSelect);

            getUnits();
            getCategories();
            getMarcas();
            getBodegas();
            getPacking();

            clearAllItems();
            txtNombre.Focus();
        }

        private void Form1_EventFGuardarDato1()
        {
            throw new NotImplementedException();
        }

        private void Form1_EventFGuardarDato()
        {
            throw new NotImplementedException();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void getUnits()
        {
            unidadesDict = sql.getUnitsProduct();
            List<string> keys = unidadesDict.Keys.ToList();
            cbxUnits.Items.AddRange(keys.ToArray());
        }

        private void getCategories()
        {
            CategoriaDict = sql.getCategoryProduct();
            List<string> keys = CategoriaDict.Keys.ToList();
            cbxCategories.Items.AddRange(keys.ToArray());
        }

        private void getMarcas()
        {
            MarcaDict = sql.getMarcaProduct();
            List<string> keys = MarcaDict.Keys.ToList();
            cbMarca.Items.AddRange(keys.ToArray());
        }

        private void getBodegas()
        {
            BodegaDict= sql.getBodega();
            List<string> keys = BodegaDict.Keys.ToList();
            cbxBodega.Items.AddRange(keys.ToArray());
        }

        private void getPacking()
        {
            PackingDict = sql.getPacking();
            List<string> keys = PackingDict.Keys.ToList();
            CbxPacking.Items.AddRange(keys.ToArray());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int isNumber = 0;
            List<TextBox> NumberTextbox = new List<TextBox>();
            NumberTextbox.Add(txtCosto);
            NumberTextbox.Add(txtPrecio);
            NumberTextbox.Add(txtQTY);

            foreach (var item in NumberTextbox)
            {
                if (validateNumber(item.Text))
                {
                    isNumber += 1;
                }
            }

           

            if (isNumber == NumberTextbox.Count)
            {
                string marca = cbMarca.SelectedItem.ToString().ToUpper();
                string name = txtNombre.Text.ToUpper();
                string units = cbxUnits.SelectedItem.ToString().ToUpper();

                string year = DateTime.Now.Year.ToString();
                string year_cut = year.Substring(2, 2).ToUpper();
                //creo el codigo para cada producto
                string cod_product = year + marca.Substring(0, 3) + name.Replace(" ", string.Empty) + units.Substring(0, 3);

                txtCodigo.Text = cod_product;
                Thread.Sleep(20);

                // first add product

                sql.AddProduct(name,
                    txtDescripcion.Text.ToUpper(),
                    txtPrecio.Text,
                    txtCosto.Text,
                    txtImagen.Text.ToUpper(),
                    units,
                    cbxCategories.SelectedItem.ToString().ToUpper(),
                    marca,
                    cod_product.ToUpper());

                //second add bodega product
                sql.addProduct_to_Bodega(cbxBodega.SelectedItem.ToString().ToUpper(),
                    cod_product.ToUpper(),
                    txtQTY.Text,
                    CbxPacking.SelectedItem.ToString().ToUpper());

                clearAllItems();
            }
            else
            {
                MessageBox.Show("Revise los datos Por Favor");
            }
            
        }


        public void saveData()
        {
            int isNumber = 0;
            List<TextBox> NumberTextbox = new List<TextBox>();
            NumberTextbox.Add(txtCosto);
            NumberTextbox.Add(txtPrecio);
            NumberTextbox.Add(txtQTY);

            foreach (var item in NumberTextbox)
            {
                if (validateNumber(item.Text))
                {
                    isNumber += 1;
                }
            }



            if (isNumber == NumberTextbox.Count)
            {
                string marca = cbMarca.SelectedItem.ToString().ToUpper();
                string name = txtNombre.Text.ToUpper();
                string units = cbxUnits.SelectedItem.ToString().ToUpper();

                string year = DateTime.Now.Year.ToString();
                string year_cut = year.Substring(2, 2).ToUpper();
                //creo el codigo para cada producto
                string cod_product = year + marca.Substring(0, 3) + name.Replace(" ", string.Empty) + units.Substring(0, 3);

                txtCodigo.Text = cod_product;
                Thread.Sleep(20);

                // first add product

                sql.AddProduct(name,
                    txtDescripcion.Text.ToUpper(),
                    txtPrecio.Text,
                    txtCosto.Text,
                    txtImagen.Text.ToUpper(),
                    units,
                    cbxCategories.SelectedItem.ToString().ToUpper(),
                    marca,
                    cod_product.ToUpper());

                //second add bodega product
                sql.addProduct_to_Bodega(cbxBodega.SelectedItem.ToString().ToUpper(),
                    cod_product.ToUpper(),
                    txtQTY.Text,
                    CbxPacking.SelectedItem.ToString().ToUpper());

                clearAllItems();
            }
            else
            {
                MessageBox.Show("Revise los datos Por Favor");
            }

        }


        public void clearAllItems()
        { 
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtCosto.Clear();
            txtImagen.Clear();
            txtCodigo.Clear();
            txtNombre.Clear();
            txtQTY.Clear();

            cbxUnits.SelectedIndex = 0;
            cbxCategories.SelectedIndex = 0;
            cbMarca.SelectedIndex = 0;
            cbxBodega.SelectedIndex = 0;
            CbxPacking.SelectedIndex = 0;

        }

        private bool validateNumber(string number)
        {
            decimal outNumber = 0;
            bool canConvert = decimal.TryParse(number, out outNumber);
            return canConvert;
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        public void fillProduct(string id, string Nombre, string Descripcion, string Codigo,
            string Marca, string Categoria, string Unidades,
            string Stock, string Paking, string Bodega)
        {
            txtNombre.Text = Nombre;
            txtDescripcion.Text = Descripcion;
            //txtPrecio.Text = precio;
            //txtCosto.Text = costo;
            txtCodigo.Text = Codigo;
            cbxUnits.Text = Unidades;
            cbMarca.Text = Marca;
            cbxCategories.Text = Categoria;
            txtQTY.Text = Stock;
            CbxPacking.Text = Paking;
            cbxBodega.Text = Bodega;
        }
    }
}
