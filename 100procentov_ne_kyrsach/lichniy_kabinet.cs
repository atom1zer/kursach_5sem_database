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
    public partial class lichniy_kabinet : Form
    {

        private DataSet dataSet = null;
        private DataSet dataSet1 = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private SqlDataAdapter sqlDataAdapter1 = null;
        SqlConnection cnn = null;
        SqlCommandBuilder sqlBuilder = null;       
        private bool newRowsAdding = false;
        public lichniy_kabinet()
        {
            InitializeComponent();
        }

        private void lichniy_kabinet_Load(object sender, EventArgs e)
        {
            if(Data.Klient_on == 1)
            {
                string connectionString = $"Data Source=USER-ПК;Initial Catalog=Avtoteka;Persist Security Info=True; User ID =user; Password =123456789";
                cnn = new SqlConnection(connectionString);
                cnn.Open();
                Selectt();
            }
           /* else
            {
                string connectionString = $"Data Source=USER-ПК;Initial Catalog=Avtoteka;Persist Security Info=True; User ID ={Data.Login}; Password ={Data.Pass}";
                cnn = new SqlConnection(connectionString);
                cnn.Open();
                Selectt();
            }*/
            

        }

        private void Selectt()
        {

            try
            {
                sqlDataAdapter1 = new SqlDataAdapter($"Select id, email, Фамилия, Имя, Отчество  FROM auth Where login = '{Data.Login}' AND password = '{Data.Pass}'", cnn);
               
                dataSet1 = new DataSet();
                sqlDataAdapter1.Fill(dataSet1, "auth");               
                //Data.User_login = Convert.ToString(dataSet1.Tables[0].Rows[0][0]);             

                sqlDataAdapter = new SqlDataAdapter($"Select vin, model, issue_date,type,color,engine_capacity,power, car_make  FROM vin Where login_user = '{Data.Login}'", cnn);
                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "vin");
                MessageBox.Show("Добро пожаловать в личный кабинет! В этом разделе представлена подробная информация о вашем автомобиле.", "Личный кабинет",MessageBoxButtons.OK, MessageBoxIcon.Information);

                label1.Text = Convert.ToString(dataSet1.Tables[0].Rows[0][2]);
                label2.Text = Convert.ToString(dataSet1.Tables[0].Rows[0][3]);
                label3.Text = Convert.ToString(dataSet1.Tables[0].Rows[0][4]);

                textBox1.Text = Convert.ToString(dataSet.Tables[0].Rows[0][0]);               
                textBox2.Text = Convert.ToString(dataSet.Tables[0].Rows[0][7] + " " + dataSet.Tables[0].Rows[0][1]);                
                textBox3.Text = Convert.ToString(dataSet.Tables[0].Rows[0][3]);                
                textBox4.Text = Convert.ToString(dataSet.Tables[0].Rows[0][4]);               
                textBox5.Text = Convert.ToString(dataSet.Tables[0].Rows[0][5]);                
                textBox6.Text = Convert.ToString(dataSet.Tables[0].Rows[0][6]);
                textBox7.Text = Convert.ToString(dataSet.Tables[0].Rows[0][2]);
                        
            }
            catch (Exception ex)
            {
                MessageBox.Show("Вы еще не добавлены в базу сотрудниками ГИБДД. \n Попытайтесь авторизоваться позже.");
                button2.Visible = false;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            cnn.Close();
            Hide();
            Form a = new auth();
            a.ShowDialog();
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            cnn.Close();
            Hide();
            Form a = new Otchet();
            a.ShowDialog();
            this.Close();
        }
    }
}
