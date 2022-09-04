using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;

namespace Shopriteapp
{
    public partial class UserForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Cecil K\Desktop\VS\Shopriteapp\Inventorydb.mdf"";Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        public UserForm()
        {
            InitializeComponent();
            loaduser();
        }
        public void loaduser()
        {
            int i = 0;
           dataGridView1.Rows.Clear();
            cmd = new SqlCommand("SELECT * FROM UserTbl", con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView1.Rows.Add(i,dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString()); 
            }
            dr.Close();
            con.Close();
             
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colname = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colname == "Edit")
            {
                ManageUsr usermodule = new ManageUsr();
                usermodule.textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                usermodule.textBox2.Text= dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                usermodule.textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                usermodule.textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

                usermodule.btnSave.Enabled = false;
                usermodule.btnupdate.Enabled = true;
                usermodule.textBox1.Enabled = false;
                usermodule.ShowDialog();

            }
            else if (colname == "Delete") ;
            {
                if (MessageBox.Show("Are you sure you want to delete this User?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) ;
                {
                    con.Open();
                    cmd = new SqlCommand("DELETE FROM UserTbl WHERE username LIKE '" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() +"'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record has successfully been deleted");
                }
            }
            loaduser();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            ManageUsr managUsr = new ManageUsr();
            managUsr.btnSave.Enabled = true;
            managUsr.btnAdd.Enabled = false;
            managUsr.ShowDialog();
            loaduser();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        
    }
    
}
