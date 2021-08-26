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
    public partial class Otchet : Form
    {

        private DataSet dataSet = null;
       
        private SqlDataAdapter sqlDataAdapter = null;
        private SqlDataAdapter sqlDataAdapter3 = null;
        SqlConnection cnn = null;
        SqlCommandBuilder sqlBuilder = null;
        public Otchet()
        {
            InitializeComponent();
        }

        private void Otchet_Load(object sender, EventArgs e)
        {

            string connectionString = $"Data Source=USER-ПК;Initial Catalog=Avtoteka;Persist Security Info=True; User ID =user; Password =123456789";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            // TODO: данная строка кода позволяет загрузить данные в таблицу "avtotekaOtchet.vin". При необходимости она может быть перемещена или удалена.
            // this.vinTableAdapter.Fill(this.avtotekaOtchet.vin);

            
            Otchetik();


        }

        private void Otchetik()
        {
            sqlDataAdapter = new SqlDataAdapter("Select vin.vin AS VIN, vin.model AS Модель, vin.issue_date AS [Дата выпуска], vin.type AS Тип, vin.color AS Цвет, vin.engine_capacity AS Объем, vin.power [Мощность л.с.], vin.car_make AS Марка, t.company AS [Компания такси], t.driver_name AS [ФИО водителя], s.couse AS [Причина розыска], p.cause AS [Причина залога], p.company AS [Компания розыска], p.date AS Дата, c.damage AS Повреждения, c.repair_cost AS [Стоимость ремонта], c.date AS [Дата ДТП], c.place AS [Место ремонта], e.right_front_fender AS [Правое переденее крыло], e.right_rear_fender AS [Правое заднее крыло], e.left_front_fender AS [Левое переденее крыло], e.left_rear_fender AS [Левое заднее крыло], e.passenger_front_door AS [Передняя пассажирская дверь], e.passenger_right_rear_door  AS [Правая задняя дверь пассажира], e.drivers_door AS [Водительская дверь], e.passenger_left_rear_door AS [Левая задняя дверь пассажира], e.hood AS [Капот], e.rear_bumper AS [Задний бампер], e.front_bumper AS [Передний бампер], e.windshield AS [Лобовое стекло], e.roof AS [Крыша], e.side_windows AS [Боковые стекла], e.trunk_lid AS [Крышка багажника], e.wheels AS [Колеса], e.right_rear_light AS [Правая задняя фара], e.right_headlight AS [Правая передняя фара], e.left_rear_light AS [Левая задняя фара], e.left_front_headlight AS [Левая передняя фара], e.rear_view_glass AS [Стекло заднего вида], e.etc  AS [Остальное]  FROM vin LEFT JOIN taxi t ON t.vin = vin.vin LEFT JOIN search s ON s.vin = vin.vin LEFT JOIN pledge p ON p.vin = vin.vin LEFT JOIN crash c ON c.vin = vin.vin LEFT JOIN elements e ON e.vin = vin.vin", cnn);
            sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);

            dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            dataGridView1.DataSource = dataSet.Tables[0];

        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            cnn.Close();
            Hide();
            Form a = new auth();
            a.ShowDialog();
            this.Close();
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            cnn.Close();
            Hide();
            Form b = new lichniy_kabinet();
            b.ShowDialog();
            this.Close();
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {

            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
                for (int j = 0; j <= dataGridView1.ColumnCount - 1; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null && dataGridView1.Rows[i].Cells[j].Value.ToString() == toolStripTextBox1.Text)
                    {
                        dataGridView1.Rows[i].Cells[j].Selected = true;
                        dataGridView1.CurrentCell = dataGridView1[j, i];
                    }
                           
        }
    }
}
