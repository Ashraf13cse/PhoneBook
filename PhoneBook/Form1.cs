
using System.Data.SqlClient;

namespace PhoneBook
{
    public partial class PhoneBook : Form
    {
        public PhoneBook()
        {
            InitializeComponent();
            Load();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-BQ19UBA; Initial Catalog=phbk; Integrated Security=true");
        SqlCommand cmd;

        SqlDataReader read;
        SqlDataAdapter drr;

        bool Mode = true;
        string sql;
        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        public void Load()
        {
            try
            {
                sql = "select * from Contact";
                cmd = new SqlCommand(sql, con);
                con.Open();
                read = cmd.ExecuteReader();
                dataGridView1.Rows.Clear();

                while (read.Read())
                {
                    dataGridView1.Rows.Add(read[0], read[1], read[2], read[3],read[4]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
         ///   txtEmail.Text = "hello";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string PhnNumber = txtPhoneNumber.Text;
            string Email = txtEmail.Text;
            string Name = txtFullName.Text;
            string Address = txtAddress.Text;

            if (Mode == true)
            {
                sql = "insert into Contact(Name,Mobile,Email,Address) values(@Name,@Mobile,@Email,@Address)";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Mobile", PhnNumber);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Address", Address);
                MessageBox.Show("Record Addddedddd");
                cmd.ExecuteNonQuery();

                txtFullName.Clear();
                txtPhoneNumber.Clear();
                txtEmail.Clear();
                txtAddress.Clear();
                txtFullName.Focus();

            }
            con.Close();
        }

        private void txtPhoneNumber_TextChanged(object sender, EventArgs e)
        {

        }
    }
}