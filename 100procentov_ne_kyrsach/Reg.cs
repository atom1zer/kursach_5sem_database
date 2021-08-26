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

namespace _100procentov_ne_kyrsach
{
    public partial class Reg : Form
    {
        string login;
        string password;
        string se_password;
        string email;
        string fam;
        string name;
        string sec_name;
        SqlDataAdapter sqlDataAdapter;
        SqlDataAdapter sqlDataAdapter1;
        SqlConnection cnn = null;
        DataSet dataSet = null;

        public Reg()
        {
            InitializeComponent();
        }
        private void Reg_Load(object sender, EventArgs e)
        {
            string connectionString = $"Data Source=USER-ПК;Initial Catalog=Avtoteka;Persist Security Info=True; User ID =user; Password =123456789";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
        }




        private void Button1_Click(object sender, EventArgs e)
        {
            login = Convert.ToString(textBox1.Text);
            email = Convert.ToString(textBox4.Text);
            password = Convert.ToString(textBox2.Text);
            se_password = Convert.ToString(textBox3.Text);
            fam = Convert.ToString(textBox5.Text);
            name = Convert.ToString(textBox6.Text);
            sec_name = Convert.ToString(textBox7.Text);

            if (password == se_password)
            {
                try
                {
                   // MessageBox.Show("1");
                    sqlDataAdapter = new SqlDataAdapter($"Select login FROM auth Where login = '{login}' ", cnn);
                    dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    if (dataSet.Tables[0].Rows.Count < 1)
                    {
                       
                        sqlDataAdapter1 = new SqlDataAdapter($"INSERT INTO auth (login, email,password, Фамилия, Имя, Отчество) VALUES ('{login}', '{email}','{password}','{fam}' ,'{name}' ,'{sec_name}' )", cnn);
                        sqlDataAdapter1.Fill(dataSet);

                        MessageBox.Show("Регистрация произошла успешно!)");
                        Hide();
                        Form a = new auth();
                        a.ShowDialog();
                        this.Close();
                        cnn.Close();
                    }
                }catch(Exception ex)
                {
                    MessageBox.Show("Ошибка:" + ex);
                }

            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form b = new auth();
            b.ShowDialog();
            this.Close();
        }
    }
}
