using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Shopriteapp
{
    public partial class CustModuleForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Cecil K\Desktop\VS\Shopriteapp\Inventorydb.mdf"";Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        public CustModuleForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void CusID_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this Customer?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.OK) 
                
                {
                    cmd = new SqlCommand("INSERT INTO tblCustomer (CusName,CusPhone)VALUES(@CusName,@CusPhone)", con);
                    cmd.Parameters.AddWithValue("@CusName", custextb1.Text);
                    cmd.Parameters.AddWithValue("@CusPhone", custextb2.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("User has successfully been saved");
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        public void Clear()
        {
            custextb1.Clear();
            custextb2.Clear();
           
        }

        private void txtupdate_Click(object sender, EventArgs e)
        {

            try
            {
                if (MessageBox.Show("Are you sure you want to Update this user?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.OK) ;
                {
                    con.Open();
                    cmd = new SqlCommand("UPDATE tblCustomer SET CusName = @CusName,CusPhone= @CusPhone WHERE CusID LIKE '" + cusid.Text + "'", con);
                    cmd.Parameters.AddWithValue("@CusName", custextb1.Text);
                    cmd.Parameters.AddWithValue("@CusPhone", custextb2.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("User has successfully been updated");
                    this.Dispose();
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            txtupdate.Enabled = true;
            btnSave.Enabled = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void custextb1_TextChanged(object sender, EventArgs e)
        {

        }

        private void CustModuleForm_Load(object sender, EventArgs e)
        {

        }
    }
}
