using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adonet_for
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ProductDal _productDal = new ProductDal();

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProduct();
        }
        public void LoadProduct()
        {
            DGWProducts.DataSource = _productDal.GetAll();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product { 
                Name = tbxName.Text ,
                UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),
                StockAmount = Convert.ToInt32(tbxStockAmount.Text)
                
            });
            LoadProduct();
            MessageBox.Show("Product added");
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Product product = new Product { 
                Id = Convert.ToInt32(DGWProducts.CurrentRow.Cells[0].Value),
                Name = tbxNameUpdate.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPriceUpdate.Text),
                StockAmount = Convert.ToInt32(tbxStockAmountUpdate.Text),

            };
            _productDal.Update(product);
            LoadProduct();
            MessageBox.Show("Updated");
        }

       

        private void DGWProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxNameUpdate.Text = DGWProducts.CurrentRow.Cells[1].Value.ToString();
            tbxUnitPriceUpdate.Text = DGWProducts.CurrentRow.Cells[2].Value.ToString();
            tbxStockAmountUpdate.Text = DGWProducts.CurrentRow.Cells[3].Value.ToString();

        }

        private void DGWProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(DGWProducts.CurrentRow.Cells[0].Value);
            _productDal.Delete(Id);
            LoadProduct();
            MessageBox.Show("Deleted!");
         

        }
    }
}