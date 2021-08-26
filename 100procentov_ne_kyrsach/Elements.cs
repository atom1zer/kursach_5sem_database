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
    public partial class Elements : Form
    {

        SqlDataAdapter sqlDataAdapter;
        private DataSet dataSet3 = null;
        SqlDataAdapter sqlDataAdapter3;
        SqlConnection cnn = null;
        DataSet dataSet = null;
        int a = 0;
        int b = 0;
        int c = 0;
        int d = 0;
        int i = 0;
        int f = 0;
        int g = 0;
        int q = 0;
        int w = 0;       
        int r = 0;
        int t = 0;     
        int y = 0;
        int u = 0;
        int o = 0;
        int p = 0;
        int s = 0;      
        int h = 0;
        int j = 0;
        int k = 0;
        int l = 0;
        int z = 0;
        /*int x = 0;
        int v = 0;*/

        public Elements()
        {
            InitializeComponent();
        }

        private void LinkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //капот
            w = 1;
            linkLabel9.LinkVisited = true;
        }

        private void Elements_Load(object sender, EventArgs e)
        {

            string connectionString = $"Data Source=USER-ПК;Initial Catalog=Avtoteka;Persist Security Info=True; User ID ='{Data.Login}'; Password ='{Data.Pass}'";
            cnn = new SqlConnection(connectionString);
            cnn.Open();

            sqlDataAdapter3 = new SqlDataAdapter("Select vin FROM vin ", cnn);

            dataSet3 = new DataSet();
            sqlDataAdapter3.Fill(dataSet3, "vin");
           // MessageBox.Show(Convert.ToString(dataSet3.Tables["vin"].Rows.Count));
          
            comboBox1.DataSource = dataSet3.Tables["vin"];
            comboBox1.ValueMember = "vin";
            comboBox1.Refresh();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int number;
            number = Convert.ToInt32(textBox1.Text);

             if(int.TryParse(textBox1.Text, out number))
             {
                 try
                 {
                     dataSet = new DataSet();
                     sqlDataAdapter = new SqlDataAdapter($"INSERT INTO elements (right_front_fender,right_rear_fender,left_front_fender,left_rear_fender,passenger_front_door,passenger_right_rear_door,drivers_door,passenger_left_rear_door,hood,rear_bumper,front_bumper,windshield,roof,side_windows,trunk_lid,wheels,right_rear_light,right_headlight,left_rear_light,left_front_headlight,rear_view_glass, number_of_crash_elements, vin) VALUES ('{a}','{b}','{c}','{d}','{i}','{f}','{g}','{q}','{w}','{z}','{r}','{t}','{y}','{u}','{o}','{p}','{s}','{h}','{j}','{k}','{l}' ,'{number}', '{comboBox1.Text}')", cnn);
                     sqlDataAdapter.Fill(dataSet);

                     MessageBox.Show("Добавлено!)");
                 }catch(Exception ex)
                 {
                     MessageBox.Show("Ошибка!" + ex);
                 }
             }
            
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            a = 1;
            linkLabel1.ForeColor = Color.Green;
            linkLabel1.LinkVisited = true;
        }

        private void LinkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            b = 1;
            linkLabel4.ForeColor = Color.Green;
            linkLabel4.LinkVisited = true;
        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            c = 1;
            linkLabel2.ForeColor = Color.Green;
            linkLabel2.LinkVisited = true;
        }

        private void LinkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            d = 1;
            linkLabel3.ForeColor = Color.Green;
            linkLabel3.LinkVisited = true;
        }

        private void LinkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            i = 1;
            linkLabel5.ForeColor = Color.Green;
            linkLabel5.LinkVisited = true;
        }

        private void LinkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            f = 1;
            linkLabel8.ForeColor = Color.Green;
            linkLabel8.LinkVisited = true;
        }

        private void LinkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            g = 1;
            linkLabel6.ForeColor = Color.Green;
            linkLabel6.LinkVisited = true;
        }

        private void LinkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            q = 1;
            linkLabel7.ForeColor = Color.Green;
            linkLabel7.LinkVisited = true;
        }

        private void LinkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            z = 1;
            linkLabel11.ForeColor = Color.Green;
            linkLabel11.LinkVisited = true;
        }

        private void LinkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            r = 1;
            linkLabel10.ForeColor = Color.Green;
            linkLabel10.LinkVisited = true;
        }

        private void LinkLabel12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            t = 1;
            linkLabel12.ForeColor = Color.Green;
            linkLabel12.LinkVisited = true;
        }

        private void LinkLabel14_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            y = 1;
            linkLabel14.ForeColor = Color.Green;
            linkLabel14.LinkVisited = true;
        }

        private void LinkLabel15_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            u = 1;
            linkLabel15.ForeColor = Color.Green;
            linkLabel15.LinkVisited = true;
        }

        private void LinkLabel16_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            o = 1;
            linkLabel16.ForeColor = Color.Green;
            linkLabel16.LinkVisited = true;
        }

        private void LinkLabel17_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            p = 1;
            linkLabel17.ForeColor = Color.Green;
            linkLabel17.LinkVisited = true;
        }

        private void LinkLabel21_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            s = 1;
            linkLabel21.ForeColor = Color.Green;
            linkLabel21.LinkVisited = true;
        }

        private void LinkLabel18_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            h = 1;
            linkLabel18.ForeColor = Color.Green;
            linkLabel18.LinkVisited = true;
        }

        private void LinkLabel20_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            j = 1;
            linkLabel20.ForeColor = Color.Green;
            linkLabel20.LinkVisited = true;
        }

        private void LinkLabel19_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            k = 1;
            linkLabel19.ForeColor = Color.Green;
            linkLabel19.LinkVisited = true;
        }

        private void LinkLabel13_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            l = 1;
            linkLabel13.ForeColor = Color.Green;
            linkLabel13.LinkVisited = true;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form a = new Form3();
            a.ShowDialog();
            this.Close();
        }
    }
}
