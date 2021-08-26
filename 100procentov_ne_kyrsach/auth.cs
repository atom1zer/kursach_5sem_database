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
    public partial class auth : Form
    {
        SqlConnection cnk = null;

        private DataSet dataSet = null;      
        private SqlDataAdapter sqlDataAdapter = null;
        public auth()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (auth_control.SelectedItem == "Сотрудник")
            {
               
            
                String login = Convert.ToString(textBox1.Text);
                String password = Convert.ToString(textBox2.Text);
                SqlConnection cnn;
       
                string connectionString = $"Data Source=USER-ПК;Initial Catalog=Avtoteka;Persist Security Info=True; User ID ={login}; Password ={password}";               

                using (cnn = new SqlConnection(connectionString))
                {
                    try
                    {

                        cnn.Open();
                        MessageBox.Show("Сотрудник");
                        Data.Login = login;
                        Data.Pass = password;
                        Hide();
                        Form a = new Form3();
                        a.ShowDialog();
                        this.Close();

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Пароль или логин неверны");
                    }
                }
                cnn.Close();
            }
            else
            {
                String login = Convert.ToString(textBox1.Text);
                String password = Convert.ToString(textBox2.Text);
                
                string connectionKlient = $"Data Source=USER-ПК;Initial Catalog=Avtoteka;Persist Security Info=True; User ID = user; Password = 123456789";
                cnk = new SqlConnection(connectionKlient);
                cnk.Open();
                sqlDataAdapter = new SqlDataAdapter($"Select Фамилия FROM auth Where login = '{textBox1.Text}' AND password = '{textBox2.Text}'", cnk);
               
                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
              
                Data.Login = login;
                Data.Pass = password;             

                if (dataSet.Tables[0].Rows.Count !=0)
                {                           
                        try
                        {
                        
                        Data.Klient_on = 1;                     
                        Hide();
                        Form a = new Form2();
                        a.ShowDialog();
                        this.Close();

                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Пароль или логин неверны");
                        }
                    
                    cnk.Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль!");
                    cnk.Close();
                }

                

            }
        }

        private void Auth_Load(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form b = new Reg();
            b.ShowDialog();
            this.Close();
        }
    }
}
