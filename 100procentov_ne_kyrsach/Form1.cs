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

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Selectt();
        }



        static void Selectt()
        {         
            SqlCommand command;
            SqlDataReader dataReader;
            String sql, Output="";
            SqlConnection cnn;
            string connectionString = $"Data Source=USER-ПК;Initial Catalog=Avtoteka;Persist Security Info=True; User ID ={Data.Login}; Password ={Data.Pass}";         
            using (cnn = new SqlConnection(connectionString))
            {
                cnn.Open();

                try
                {
                    
                    sql = "Select id,damage,repair_cost,date from crash";
                    command = new SqlCommand(sql, cnn);
                    dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Output += dataReader.GetValue(0) + "-" + dataReader.GetValue(1) + "\n";
                    }
                    MessageBox.Show(Output);
                    dataReader.Close();
                    command.Dispose();
                    cnn.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Доступ запрещен!");
                }
            }
            
            
        }
    }

}
