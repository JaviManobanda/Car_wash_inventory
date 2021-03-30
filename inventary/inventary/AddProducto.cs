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
    public partial class UserControl1 : UserControl
    {
        string servidor = "localhost";
        string db = "inventary_car_wash";
        string user = "root";
        string password = "2527";

        MySQL_Logic sql; 

        public UserControl1()
        {
            InitializeComponent();
            sql = new MySQL_Logic(servidor, db, user, password);
            getUnits();
            getCategories();
            getMarcas();
            getBodegas();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void getUnits()
        {
            cbxUnits.Items.AddRange(sql.getUnitsProduct().ToArray());
        }

        private void getCategories()
        {
            cbxCategories.Items.AddRange(sql.getCategoryProduct().ToArray());
        }

        private void getMarcas()
        {
            cbMarca.Items.AddRange(sql.getMarcaProduct().ToArray());
        }

        private void getBodegas()
        {
            cbxBodega.Items.AddRange(sql.getBodega().ToArray());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
