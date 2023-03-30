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
            presetmain();
            

            dtProdukTampil.Columns.Add("ID Product");
            dtProdukTampil.Columns.Add("Nama Product");
            dtProdukTampil.Columns.Add("Harga");
            dtProdukTampil.Columns.Add("Stock");
            dtProdukTampil.Columns.Add("ID Category");

            dtCategory.Columns.Add("ID Category");
            dtCategory.Columns.Add("Nama Category");
            presetcat();

            Grid_Category.DataSource = dtCategory;
            Grid_Main.DataSource = dtProdukSimpan;
            presetcombobox();





        } 
        
        private void BTN_Filter_All_Click(object sender, EventArgs e)
        {
            CB_Filter.Enabled = false;
        }

        private void BTN_Filter_Click(object sender, EventArgs e)
        {
            CB_Filter.Enabled = true;
        }

        private void presetmain()
        {
            dtProdukSimpan.Rows.Add("J001", "Jas Hitam", 100000, 10, "C1");
            dtProdukSimpan.Rows.Add("T001", "T - Shirt Black Pink", 70000, 20, "C2");
            dtProdukSimpan.Rows.Add("T002", "T-Shirt Obsessive", 75000, 16, "C2");
            dtProdukSimpan.Rows.Add("R001", "Rok mini", 82000, 26, "C3");
            dtProdukSimpan.Rows.Add("J002", "Jeans Biru", 90000, 5, "C4");
            dtProdukSimpan.Rows.Add("C001", "Celana Pendek Coklat", 60000, 11, "C4");
            dtProdukSimpan.Rows.Add("C002", "Cawat Blink-blink", 1000000, 1, "C5");
            dtProdukSimpan.Rows.Add("R002", "Rocca Shirt", 50000, 8, "C2");
        }

        private void presetcat()
        {
            dtCategory.Rows.Add("C1", "Jas");
            dtCategory.Rows.Add("C2", "T-Shirt");
            dtCategory.Rows.Add("C3", "Rok");
            dtCategory.Rows.Add("C4", "Celana");
            dtCategory.Rows.Add("C5", "Cawat");
        }

        private void presetcombobox()
        {
            CB_Details_Category.Items.Add("Jas");
            CB_Details_Category.Items.Add("T-Shirt");
            CB_Details_Category.Items.Add("Rok");
            CB_Details_Category.Items.Add("Celana");
            CB_Details_Category.Items.Add("Cawat");

            CB_Filter.Items.Add("Jas");
            CB_Filter.Items.Add("T-Shirt");
            CB_Filter.Items.Add("Rok");
            CB_Filter.Items.Add("Celana");
            CB_Filter.Items.Add("Cawat");
        }

        private string ID(string name)
        {
            string result = name.Substring(0, 1).ToUpper();
            int counter = 1;
            for(int i  = 0; i < dtProdukSimpan.Rows.Count; i++)
            {
                if (result == dtProdukSimpan.Rows[i][1].ToString().Substring(0, 1).ToUpper())
                {
                        counter++;
                }
            }
            if (counter.ToString().Length == 1)
            {
                result = result + "00" + counter;
            }
            else if (counter.ToString().Length == 2)
            {
                result = result + "0" + counter;
            }
            else if (counter.ToString().Length == 3)
            {
                result = result + "" + counter;
            }
            return result;
        }

        private void BTN_Add_Product_Click(object sender, EventArgs e)
        {
            string saved_data = "";
            for(int i = 0; i < dtCategory.Rows.Count; i++)
            {
                if (dtCategory.Rows[i][1].ToString() == CB_Details_Category.SelectedItem.ToString())
                {
                    saved_data = dtCategory.Rows[i][0].ToString();
                }
            }
            string resultsave = TB_Details_Nama.Text;
            string resultid = ID(resultsave);
            dtProdukSimpan.Rows.Add(resultid, TB_Details_Nama.Text, TB_Details_Harga.Text, TB_Details_Stock.Text, saved_data); ;
        }


        private void BTN_Remove_Product_Click(object sender, EventArgs e)
        {
            Grid_Main.Rows.RemoveAt(Grid_Main.CurrentCell.RowIndex);
        }

        private void BTN_Add_Category_Click(object sender, EventArgs e)
        {   
            int IDCAT2 = dtCategory.Rows[dtCategory.Rows.Count - 1][0].ToString().Length - 1;
            int IDCAT = Convert.ToInt32(dtCategory.Rows[dtCategory.Rows.Count - 1][0].ToString().Substring(1, IDCAT2));
            CB_Details_Category.Items.Add(TB_Category_Nama.Text);
            CB_Filter.Items.Add(TB_Category_Nama.Text);
            dtCategory.Rows.Add( "C" + (IDCAT + 1), TB_Category_Nama.Text);
        }

        private void BTN_Remove_Category_Click(object sender, EventArgs e)
        {
            Grid_Category.Rows.RemoveAt(Grid_Category.CurrentCell.RowIndex);
        }

        private void BTN_Edit_Product_Click(object sender, EventArgs e)
        {

        }

        private void clickdgv(object sender, DataGridViewCellMouseEventArgs e)
        {
            TB_Details_Nama.Text = dtProdukSimpan.Rows[Grid_Main.CurrentCell.RowIndex][1].ToString();
            TB_Details_Harga.Text = dtProdukSimpan.Rows[Grid_Main.CurrentCell.RowIndex][2].ToString();
            TB_Details_Stock.Text = dtProdukSimpan.Rows[Grid_Main.CurrentCell.RowIndex][3].ToString();
        }
    }
}
