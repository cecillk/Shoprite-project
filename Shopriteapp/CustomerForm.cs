using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Shopriteapp
{
    public partial class CustomerForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Cecil K\Desktop\VS\Shopriteapp\Inventorydb.mdf"";Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        public CustomerForm()
        {
            InitializeComponent();
        }
        public void loadCustomer()
        {
            int i = 0;
            dataGridView2.Rows.Clear();
            cmd = new SqlCommand("SELECT * FROM UserTbl", con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView2.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
            }
            dr.Close();
            con.Close();

        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            string colname = dataGridView2.Columns[e.ColumnIndex].Name;
            if (colname == "Edit")
            {
                CustModuleForm custmod = new CustModuleForm();
                custmod.cusid.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                custmod.custextb1.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                custmod.custextb2.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();

                custmod.btnSave.Enabled = true;
                custmod.txtupdate.Enabled = true;
                custmod.ShowDialog();




            }
            else if (colname == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this User?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) ;
                {
                    con.Open();
                    cmd = new SqlCommand("DELETE FROM tblCustomer WHERE CusID LIKE '" + dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record has successfully been deleted");
                }
            }

            loadCustomer();
        }


        private void btnCustomer_Click(object sender, EventArgs e)
        {
            CustModuleForm moduleform = new CustModuleForm();
            moduleform.btnSave.Enabled = true;
            moduleform.txtupdate.Enabled = false;
            moduleform.ShowDialog();
            loadCustomer();

        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
