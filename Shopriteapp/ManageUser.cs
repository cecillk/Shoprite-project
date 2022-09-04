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
using System.Security.Cryptography.X509Certificates;

namespace Shopriteapp
{
    public partial class ManageUsr : Form
    {
        public ManageUsr()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Cecil K\Desktop\VS\Shopriteapp\Inventorydb.mdf"";Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();

        private static DataTable DataSource;

        private void ManageUser_Load(object sender, EventArgs e)
        {
            populate();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        void populate()
        {
            try
            {
                con.Open();
                string Myquery = "select * from UserTbl";
                SqlDataAdapter da = new SqlDataAdapter(Myquery, con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                UserGv.DataSource = ds.Tables[0];
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private SqlDataAdapter SqlDataAdapter(string myquery, SqlConnection con)
        {
            throw new NotImplementedException();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert Into UserTbl values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')", con);

                cmd.ExecuteNonQuery();
                MessageBox.Show("User Successfully Added");
            }
            catch (Exception)
            {


            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFullName_Click(object sender, EventArgs e)
        {

        }

        private void txtPhone_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
             try
            {
                if (MessageBox.Show("Are you sure you want to save this user?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.OK);
                {
                    cmd = new SqlCommand("INSERT UserTbl(UserName,FullName,Password,Phone)VALUES(@UserName,@FullName,@Password,@Phone)", con);
                    cmd.Parameters.AddWithValue("@UserName", textBox1.Text);
                    cmd.Parameters.AddWithValue("@FullName", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Password", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Phone", textBox4.Text);
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

        private void txtedit_Click(object sender, EventArgs e)
        {

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {

            try
            {
                if (MessageBox.Show("Are you sure you want to Update this user?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.OK) ;
                {
                    cmd = new SqlCommand("UPDATE UserTbl SET UserName= @UserName,FullName =@FullName,Password =@Password,Phone= @Phone WHERE UserName LIKE '"+ textBox1.Text+ "'", con);
                    cmd.Parameters.AddWithValue("@UserName", textBox1.Text);
                    cmd.Parameters.AddWithValue("@FullName", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Password", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Phone", textBox4.Text);
                    con.Open();
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

        private void UserGv_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
