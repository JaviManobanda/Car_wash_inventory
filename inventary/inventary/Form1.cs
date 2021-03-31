using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace inventary
{
    public partial class Form1 : Form
    {
        addProducts addProduct;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userControl11.saveData();
        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        private void buscar1_Load(object sender, EventArgs e)
        {

        }
    }
}
