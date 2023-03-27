using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TakeHome_Week_5
{
    public partial class Form1 : Form
    {
        DataTable dtProdukSimpan = new DataTable(); //data simpan produk
        DataTable dtProdukTampil = new DataTable(); //data hasil filter
        DataTable dtCategory = new DataTable();     //data kategori

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtProdukSimpan.Columns.Add("ID Product");
            dtProdukSimpan.Columns.Add("Nama Product");
            dtProdukSimpan.Columns.Add("Harga");
            dtProdukSimpan.Columns.Add("Stock");
            dtProdukSimpan.Columns.Add("ID Category");

            dtProdukTampil.Columns.Add("ID Product");
            dtProdukTampil.Columns.Add("Nama Product");
            dtProdukTampil.Columns.Add("Harga");
            dtProdukTampil.Columns.Add("Stock");
            dtProdukTampil.Columns.Add("ID Category");

            dtCategory.Columns.Add("ID Category");
            dtCategory.Columns.Add("Nama Category");
            Grid_Category.DataSource = dtCategory;
            Grid_Main.DataSource = dtProdukSimpan;

            preset();

        } 
        
        private void BTN_Filter_All_Click(object sender, EventArgs e)
        {
            CB_Filter.Enabled = false;
        }

        private void BTN_Filter_Click(object sender, EventArgs e)
        {
            CB_Filter.Enabled = true;
        }

        private void preset()
        {

        }

        private void display()
        {

        }

        private string ID(string name)
        {
            string result = "";
            int counter = 1;
            result = name.Substring(0, name.Length-1).ToUpper();
            foreach (DataColumn dataColumn in Grid_Category.Columns)
            {
                if(dataColumn.ColumnName == name)
                {
                    foreach(DataRow row in dataColumn.Table.Rows)
                    {
                        if(result == row.ToString().Substring(0, 1))
                        {
                            counter++;
                        }
                    }
                }
            }
            
            return result;
        }

       
    }
}
