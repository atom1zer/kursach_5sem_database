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
    public partial class Form3 : Form
    {
        private DataSet dataSet = null;
        private DataSet dataSet1 = null;
        private DataSet dataSet2 = null;
        private DataSet dataSet3 = null;
        private DataSet dataSet4 = null;
        private DataSet dataSet5 = null;

        int x = 0;
        int y = 0;
        private SqlDataAdapter sqlDataAdapter = null;
        private SqlDataAdapter sqlDataAdapter1 = null;
        private SqlDataAdapter sqlDataAdapter2 = null;
        private SqlDataAdapter sqlDataAdapter3 = null;
        private SqlDataAdapter sqlDataAdapter4 = null;
        private SqlDataAdapter sqlDataAdapter5 = null;
        SqlConnection cnn = null;
        SqlCommandBuilder sqlBuilder = null;
        private bool newRowsAdding = false;
        private bool RowsAdding = false;

        public Form3()
        {
            InitializeComponent();

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string connectionString = $"Data Source=USER-ПК;Initial Catalog=Avtoteka;Persist Security Info=True; User ID ={Data.Login}; Password ={Data.Pass}";
            cnn = new SqlConnection(connectionString);
            cnn.Open();        
        }

        private void AvtotekaDataSetBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try {

                if(e.ColumnIndex == 10 && y == 1)
                {
                    x = 10;
                    string task = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();

                    if(task == "Insert")
                    {
                        MessageBox.Show("Insert");
                        int rowIndex = dataGridView1.Rows.Count - 2;
                        DataRow row = dataSet.Tables["vin"].NewRow();

                        row["vin"] = dataGridView1.Rows[rowIndex].Cells["vin"].Value;
                        row["Логин"] = dataGridView1.Rows[rowIndex].Cells["Логин"].Value;
                        row["Модель"] = dataGridView1.Rows[rowIndex].Cells["Модель"].Value;
                        row["Дата выпуска"] = dataGridView1.Rows[rowIndex].Cells["Дата выпуска"].Value;
                        row["Тип"] = dataGridView1.Rows[rowIndex].Cells["Тип"].Value;
                        row["Цвет"] = dataGridView1.Rows[rowIndex].Cells["Цвет"].Value;
                        row["Объем"] = dataGridView1.Rows[rowIndex].Cells["Объем"].Value;
                        row["Мощность л.с."] = dataGridView1.Rows[rowIndex].Cells["Мощность л.с."].Value;
                        row["id"] = dataGridView1.Rows[rowIndex].Cells["id"].Value;
                        row["Марка"] = dataGridView1.Rows[rowIndex].Cells["Марка"].Value;

                        dataSet.Tables["vin"].Rows.Add(row);
                       // MessageBox.Show(Convert.ToString(dataSet.Tables["vin"].Rows.Count));
                        dataSet.Tables["vin"].Rows.RemoveAt(dataSet.Tables["vin"].Rows.Count - 1);
                       // MessageBox.Show(Convert.ToString(dataSet.Tables["vin"].Rows.Count));
                        dataGridView1.Rows[e.RowIndex].Cells[x].Value = "Delete";
                       // MessageBox.Show(Convert.ToString(dataSet.Tables["vin"].Rows.Count));
                        sqlDataAdapter.Update(dataSet, "vin");
                       // MessageBox.Show(Convert.ToString(dataSet.Tables["vin"].Rows.Count));
                        RowsAdding = false;


                    }
                    else if(task == "Delete")
                    {
                        if(MessageBox.Show("Удалить эту строку?", "Удаление",MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            == DialogResult.Yes)
                        {
                            
                            int rowsIndex = e.RowIndex;                        
                            dataGridView1.Rows.RemoveAt(rowsIndex);
                            dataSet.Tables["vin"].Rows[rowsIndex].Delete();
                            sqlDataAdapter.Update(dataSet, "vin");

                        }
                    }
                    else if(task == "Update")
                    {
                        int r = e.RowIndex;

                        dataSet.Tables["vin"].Rows[r]["vin"] = dataGridView1.Rows[r].Cells["vin"].Value;                      
                        dataSet.Tables["vin"].Rows[r]["Модель"] = dataGridView1.Rows[r].Cells["Модель"].Value;
                        dataSet.Tables["vin"].Rows[r]["Дата выпуска"] = dataGridView1.Rows[r].Cells["Дата выпуска"].Value;
                        dataSet.Tables["vin"].Rows[r]["Тип"] = dataGridView1.Rows[r].Cells["Тип"].Value;
                        dataSet.Tables["vin"].Rows[r]["Цвет"] = dataGridView1.Rows[r].Cells["Цвет"].Value;
                        dataSet.Tables["vin"].Rows[r]["Объем"] = dataGridView1.Rows[r].Cells["Объем"].Value;
                        dataSet.Tables["vin"].Rows[r]["Мощность л.с."] = dataGridView1.Rows[r].Cells["Мощность л.с."].Value;                      
                        dataSet.Tables["vin"].Rows[r]["Марка"] = dataGridView1.Rows[r].Cells["Марка"].Value;

                        sqlDataAdapter.Update(dataSet, "vin");
                        dataGridView1.Rows[e.RowIndex].Cells[x].Value = "Delete";
                    }
                    ReloadData();
                }
                                     //TO

                else if (e.ColumnIndex == 8 && y == 2)
                {
                    x = 8;
                    string task = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

                    if (task == "Insert")
                    {
                        int rowIndex = dataGridView1.Rows.Count - 2;
                        DataRow row = dataSet.Tables["maintenance"].NewRow();

                        row["Дата"] = dataGridView1.Rows[rowIndex].Cells["Дата"].Value;
                        row["Замена"] = dataGridView1.Rows[rowIndex].Cells["Замена"].Value;
                        row["Пробег"] = dataGridView1.Rows[rowIndex].Cells["Пробег"].Value;
                        row["Стоимость ремонта"] = dataGridView1.Rows[rowIndex].Cells["Стоимость ремонта"].Value;
                        row["Место ремонта"] = dataGridView1.Rows[rowIndex].Cells["Место ремонта"].Value;
                        row["vin"] = dataGridView1.Rows[rowIndex].Cells["vin"].Value;
                       

                        dataSet.Tables["maintenance"].Rows.Add(row);
                        dataSet.Tables["maintenance"].Rows.RemoveAt(dataSet.Tables["maintenance"].Rows.Count - 1);
                        dataGridView1.Rows[e.RowIndex].Cells[x].Value = "Delete";
                        sqlDataAdapter.Update(dataSet, "maintenance");
                        newRowsAdding = false;


                    }
                    else if (task == "Delete")
                    {
                        if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            == DialogResult.Yes)
                        {

                            int rowsIndex = e.RowIndex;
                            dataGridView1.Rows.RemoveAt(rowsIndex);
                            dataSet.Tables["maintenance"].Rows[rowsIndex].Delete();
                            sqlDataAdapter.Update(dataSet, "maintenance");

                        }
                    }
                    else if (task == "Update")
                    {
                        int r = e.RowIndex;

                        dataSet.Tables["maintenance"].Rows[r]["Дата"] = dataGridView1.Rows[r].Cells["Дата"].Value;                      
                        dataSet.Tables["maintenance"].Rows[r]["Замена"] = dataGridView1.Rows[r].Cells["Замена"].Value;
                        dataSet.Tables["maintenance"].Rows[r]["Пробег"] = dataGridView1.Rows[r].Cells["Пробег"].Value;
                        dataSet.Tables["maintenance"].Rows[r]["Стоимость ремонта"] = dataGridView1.Rows[r].Cells["Стоимость ремонта"].Value;
                        dataSet.Tables["maintenance"].Rows[r]["Место ремонта"] = dataGridView1.Rows[r].Cells["Место ремонта"].Value;
                        dataSet.Tables["maintenance"].Rows[r]["vin"] = dataGridView1.Rows[r].Cells["vin"].Value;                       

                        sqlDataAdapter.Update(dataSet,"maintenance");
                        dataGridView1.Rows[e.RowIndex].Cells[8].Value = "Delete";
                    }
                    ReloadData();
                } 
                //3 crash
                else if (e.ColumnIndex == 6 && y == 3)
                {
                    x = 6;
                    string task = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();

                    if (task == "Insert")
                    {
                        int rowIndex = dataGridView1.Rows.Count - 2;
                        DataRow row = dataSet.Tables["crash"].NewRow();

                        row["Повреждения"] = dataGridView1.Rows[rowIndex].Cells["Повреждения"].Value;
                        row["Стоимость ремонта"] = dataGridView1.Rows[rowIndex].Cells["Стоимость ремонта"].Value;                    
                        row["Дата"] = dataGridView1.Rows[rowIndex].Cells["Дата"].Value;
                        row["Место проведения ремонта"] = dataGridView1.Rows[rowIndex].Cells["Место проведения ремонта"].Value;
                        row["vin"] = dataGridView1.Rows[rowIndex].Cells["vin"].Value;


                        dataSet.Tables["crash"].Rows.Add(row);
                        dataSet.Tables["crash"].Rows.RemoveAt(dataSet.Tables["crash"].Rows.Count - 1);
                        dataGridView1.Rows[e.RowIndex].Cells[x].Value = "Delete";
                        sqlDataAdapter.Update(dataSet, "crash");
                        newRowsAdding = false;


                    }
                    else if (task == "Delete")
                    {
                        if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            == DialogResult.Yes)
                        {

                            int rowsIndex = e.RowIndex;
                            dataGridView1.Rows.RemoveAt(rowsIndex);
                            dataSet.Tables["crash"].Rows[rowsIndex].Delete();
                            sqlDataAdapter.Update(dataSet, "crash");

                        }
                    }
                    else if (task == "Update")
                    {
                        int r = e.RowIndex;

                        dataSet.Tables["crash"].Rows[r]["Повреждения"] = dataGridView1.Rows[r].Cells["Повреждения"].Value;
                        dataSet.Tables["crash"].Rows[r]["Стоимость ремонта"] = dataGridView1.Rows[r].Cells["Стоимость ремонта"].Value;
                        dataSet.Tables["crash"].Rows[r]["Дата"] = dataGridView1.Rows[r].Cells["Дата"].Value;
                        dataSet.Tables["crash"].Rows[r]["Место проведения ремонта"] = dataGridView1.Rows[r].Cells["Место проведения ремонта"].Value;
                        dataSet.Tables["crash"].Rows[r]["vin"] = dataGridView1.Rows[r].Cells["vin"].Value;
                        

                        sqlDataAdapter.Update(dataSet, "crash");
                        dataGridView1.Rows[e.RowIndex].Cells[x].Value = "Delete";
                    }
                    ReloadData();
                }
                //4 pledge             
                else if (e.ColumnIndex == 5 && y == 4)
                {
                    x= 5;
                    string task = dataGridView1.Rows[e.RowIndex].Cells[x].Value.ToString();

                    if (task == "Insert")
                    {
                        int rowIndex = dataGridView1.Rows.Count - 2;
                        DataRow row = dataSet.Tables["pledge"].NewRow();

                        //row["id"] = dataGridView1.Rows[rowIndex].Cells["id"].Value;
                        row["Причина"] = dataGridView1.Rows[rowIndex].Cells["Причина"].Value;
                        row["Компания"] = dataGridView1.Rows[rowIndex].Cells["Компания"].Value;
                        row["Дата"] = dataGridView1.Rows[rowIndex].Cells["Дата"].Value;
                        row["vin"] = dataGridView1.Rows[rowIndex].Cells["vin"].Value;



                        dataSet.Tables["pledge"].Rows.Add(row);
                        dataSet.Tables["pledge"].Rows.RemoveAt(dataSet.Tables["pledge"].Rows.Count - 1);
                        dataGridView1.Rows[e.RowIndex].Cells[x].Value = "Delete";
                        sqlDataAdapter.Update(dataSet, "pledge");
                        newRowsAdding = false;


                    }
                    else if (task == "Delete")
                    {
                        if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            == DialogResult.Yes)
                        {

                            int rowsIndex = e.RowIndex;
                            dataGridView1.Rows.RemoveAt(rowsIndex);
                            dataSet.Tables["pledge"].Rows[rowsIndex].Delete();
                            sqlDataAdapter.Update(dataSet, "pledge");

                        }
                    }
                    else if (task == "Update")
                    {
                        int r = e.RowIndex;

                       // dataSet.Tables["pledge"].Rows[r]["id"] = dataGridView1.Rows[r].Cells["id"].Value;
                        dataSet.Tables["pledge"].Rows[r]["Причина"] = dataGridView1.Rows[r].Cells["Причина"].Value;
                        dataSet.Tables["pledge"].Rows[r]["Компания"] = dataGridView1.Rows[r].Cells["Компания"].Value;
                        dataSet.Tables["pledge"].Rows[r]["Дата"] = dataGridView1.Rows[r].Cells["Дата"].Value;
                        dataSet.Tables["pledge"].Rows[r]["vin"] = dataGridView1.Rows[r].Cells["vin"].Value;



                        sqlDataAdapter.Update(dataSet, "pledge");
                        dataGridView1.Rows[e.RowIndex].Cells[x].Value = "Delete";
                    }
                    ReloadData();
                }

                //5 search
                else if (e.ColumnIndex == 3 && y == 5)
                {
                    x = 3;
                    string task = dataGridView1.Rows[e.RowIndex].Cells[x].Value.ToString();

                    if (task == "Insert")
                    {
                        int rowIndex = dataGridView1.Rows.Count - 2;
                        DataRow row = dataSet.Tables["search"].NewRow();

                        row["Причина"] = dataGridView1.Rows[rowIndex].Cells["Причина"].Value;
                        row["vin"] = dataGridView1.Rows[rowIndex].Cells["vin"].Value;

                        dataSet.Tables["search"].Rows.Add(row);
                        dataSet.Tables["search"].Rows.RemoveAt(dataSet.Tables["search"].Rows.Count - 1);
                        dataGridView1.Rows[e.RowIndex].Cells[3].Value = "Delete";
                        sqlDataAdapter.Update(dataSet, "search");
                        newRowsAdding = false;


                    }
                    else if (task == "Delete")
                    {
                        if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            == DialogResult.Yes)
                        {

                            int rowsIndex = e.RowIndex;
                            dataGridView1.Rows.RemoveAt(rowsIndex);
                            dataSet.Tables["search"].Rows[rowsIndex].Delete();
                            sqlDataAdapter.Update(dataSet, "search");

                        }
                    }
                    else if (task == "Update")
                    {
                        int r = e.RowIndex;

                        dataSet.Tables["search"].Rows[r]["Причина"] = dataGridView1.Rows[r].Cells["Причина"].Value;
                        dataSet.Tables["search"].Rows[r]["vin"] = dataGridView1.Rows[r].Cells["vin"].Value;
                        sqlDataAdapter.Update(dataSet, "search");
                        dataGridView1.Rows[e.RowIndex].Cells[x].Value = "Delete";
                    }
                    ReloadData();
                }
                //6 Taxi
                else if (e.ColumnIndex == 5 && y == 6)
                {
                    x = 5;
                    string task = dataGridView1.Rows[e.RowIndex].Cells[x].Value.ToString();

                    if (task == "Insert")
                    {
                        int rowIndex = dataGridView1.Rows.Count - 2;
                        DataRow row = dataSet.Tables["taxi"].NewRow();

                        row["Компания"] = dataGridView1.Rows[rowIndex].Cells["Компания"].Value;                    
                        row["ФИО водителя"] = dataGridView1.Rows[rowIndex].Cells["ФИО водителя"].Value;
                        row["vin"] = dataGridView1.Rows[rowIndex].Cells["vin"].Value;



                        dataSet.Tables["taxi"].Rows.Add(row);
                        dataSet.Tables["taxi"].Rows.RemoveAt(dataSet.Tables["taxi"].Rows.Count - 1);
                        dataGridView1.Rows[e.RowIndex].Cells[x].Value = "Delete";
                        sqlDataAdapter.Update(dataSet, "taxi");
                        newRowsAdding = false;


                    }
                    else if (task == "Delete")
                    {
                        if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            == DialogResult.Yes)
                        {

                            int rowsIndex = e.RowIndex;
                            dataGridView1.Rows.RemoveAt(rowsIndex);
                            dataSet.Tables["taxi"].Rows[rowsIndex].Delete();
                            sqlDataAdapter.Update(dataSet, "taxi");

                        }
                    }
                    else if (task == "Update")
                    {
                        int r = e.RowIndex;
                       
                        dataSet.Tables["taxi"].Rows[r]["Компания"] = dataGridView1.Rows[r].Cells["Компания"].Value;                      
                        dataSet.Tables["taxi"].Rows[r]["ФИО водителя"] = dataGridView1.Rows[r].Cells["ФИО водителя"].Value;
                        dataSet.Tables["taxi"].Rows[r]["vin"] = dataGridView1.Rows[r].Cells["vin"].Value;

                        sqlDataAdapter.Update(dataSet, "taxi");
                        dataGridView1.Rows[e.RowIndex].Cells[x].Value = "Delete";
                    }
                    ReloadData();
                }
                //7 elements
                else if (e.ColumnIndex == 24 && y == 7)
                {
                    x = 24;
                    string task = dataGridView1.Rows[e.RowIndex].Cells[x].Value.ToString();

                    if (task == "Insert")
                    {
                        int rowIndex = dataGridView1.Rows.Count - 2;
                        DataRow row = dataSet.Tables["elements"].NewRow();

                        row["Правое переденее крыло"] = dataGridView1.Rows[rowIndex].Cells["Правое переденее крыло"].Value;
                        row["Правое заднее крыло"] = dataGridView1.Rows[rowIndex].Cells["Правое заднее крыло"].Value;
                        row["Левое переденее крыло"] = dataGridView1.Rows[rowIndex].Cells["Левое переденее крыло"].Value;
                        row["Левое заднее крыло"] = dataGridView1.Rows[rowIndex].Cells["Левое заднее крыло"].Value;
                        row["Передняя пассажирская дверь"] = dataGridView1.Rows[rowIndex].Cells["Передняя пассажирская дверь"].Value;
                        row["Правая задняя дверь пассажира"] = dataGridView1.Rows[rowIndex].Cells["Правая задняя дверь пассажира"].Value;
                        row["Водительская дверь"] = dataGridView1.Rows[rowIndex].Cells["Водительская дверь"].Value;
                        row["Левая задняя дверь пассажира"] = dataGridView1.Rows[rowIndex].Cells["Левая задняя дверь пассажира"].Value;
                        row["Капот"] = dataGridView1.Rows[rowIndex].Cells["Капот"].Value;
                        row["Задний бампер"] = dataGridView1.Rows[rowIndex].Cells["Задний бампер"].Value;
                        row["Передний бампер"] = dataGridView1.Rows[rowIndex].Cells["Передний бампер"].Value;
                        row["Лобовое стекло"] = dataGridView1.Rows[rowIndex].Cells["Лобовое стекло"].Value;
                        row["Крыша"] = dataGridView1.Rows[rowIndex].Cells["Крыша"].Value;
                        row["Боковые стекла"] = dataGridView1.Rows[rowIndex].Cells["Боковые стекла"].Value;
                        row["Крышка багажника"] = dataGridView1.Rows[rowIndex].Cells["Крышка багажника"].Value;
                        row["Колеса"] = dataGridView1.Rows[rowIndex].Cells["Колеса"].Value;
                        row["Правая задняя фара"] = dataGridView1.Rows[rowIndex].Cells["Правая задняя фара"].Value;
                        row["Правая передняя фара"] = dataGridView1.Rows[rowIndex].Cells["Правая передняя фара"].Value;
                        row["Левая задняя фара"] = dataGridView1.Rows[rowIndex].Cells["Левая задняя фара"].Value;
                        row["Левая передняя фара"] = dataGridView1.Rows[rowIndex].Cells["Левая передняя фара"].Value;
                        row["Стекло заднего вида"] = dataGridView1.Rows[rowIndex].Cells["Стекло заднего вида"].Value;
                       // row["side_right_mirror"] = dataGridView1.Rows[rowIndex].Cells["side_right_mirror"].Value;
                        row["etc"] = dataGridView1.Rows[rowIndex].Cells["etc"].Value;
                        row["vin"] = dataGridView1.Rows[rowIndex].Cells["vin"].Value;



                        dataSet.Tables["elements"].Rows.Add(row);
                        dataSet.Tables["elements"].Rows.RemoveAt(dataSet.Tables["elements"].Rows.Count - 1);
                        dataGridView1.Rows[e.RowIndex].Cells[x].Value = "Delete";
                        sqlDataAdapter.Update(dataSet, "elements");
                        newRowsAdding = false;


                    }
                    else if (task == "Delete")
                    {
                        if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            == DialogResult.Yes)
                        {

                            int rowsIndex = e.RowIndex;
                            dataGridView1.Rows.RemoveAt(rowsIndex);
                            dataSet.Tables["elements"].Rows[rowsIndex].Delete();
                            sqlDataAdapter.Update(dataSet, "elements");

                        }
                    }
                    else if (task == "Update")
                    {
                        int r = e.RowIndex;

                        dataSet.Tables["elements"].Rows[r]["Правое переденее крыло"] = dataGridView1.Rows[r].Cells["Правое переденее крыло"].Value;
                        dataSet.Tables["elements"].Rows[r]["Правое заднее крыло"] = dataGridView1.Rows[r].Cells["Правое заднее крыло"].Value;
                        dataSet.Tables["elements"].Rows[r]["Левое переденее крыло"] = dataGridView1.Rows[r].Cells["Левое переденее крыло"].Value;
                        dataSet.Tables["elements"].Rows[r]["Левое заднее крыло"] = dataGridView1.Rows[r].Cells["Левое заднее крыло"].Value;                   
                        dataSet.Tables["elements"].Rows[r]["Передняя пассажирская дверь"] = dataGridView1.Rows[r].Cells["Передняя пассажирская дверь"].Value;
                        dataSet.Tables["elements"].Rows[r]["Правая задняя дверь пассажира"] = dataGridView1.Rows[r].Cells["Правая задняя дверь пассажира"].Value;
                        dataSet.Tables["elements"].Rows[r]["Водительская дверь"] = dataGridView1.Rows[r].Cells["Водительская дверь"].Value;
                        dataSet.Tables["elements"].Rows[r]["Левая задняя дверь пассажира"] = dataGridView1.Rows[r].Cells["Левая задняя дверь пассажира"].Value;
                        dataSet.Tables["elements"].Rows[r]["Капот"] = dataGridView1.Rows[r].Cells["Капот"].Value;
                        dataSet.Tables["elements"].Rows[r]["Задний бампер"] = dataGridView1.Rows[r].Cells["Задний бампер"].Value;
                        dataSet.Tables["elements"].Rows[r]["Передний бампер"] = dataGridView1.Rows[r].Cells["Передний бампер"].Value;
                        dataSet.Tables["elements"].Rows[r]["Лобовое стекло"] = dataGridView1.Rows[r].Cells["Лобовое стекло"].Value;
                        dataSet.Tables["elements"].Rows[r]["Крыша"] = dataGridView1.Rows[r].Cells["Крыша"].Value;
                        dataSet.Tables["elements"].Rows[r]["Боковые стекла"] = dataGridView1.Rows[r].Cells["Боковые стекла"].Value;
                        dataSet.Tables["elements"].Rows[r]["Крышка багажника"] = dataGridView1.Rows[r].Cells["Крышка багажника"].Value;
                        dataSet.Tables["elements"].Rows[r]["Колеса"] = dataGridView1.Rows[r].Cells["Колеса"].Value;
                        dataSet.Tables["elements"].Rows[r]["Правая задняя фара"] = dataGridView1.Rows[r].Cells["Правая задняя фара"].Value;
                        dataSet.Tables["elements"].Rows[r]["Правая передняя фара"] = dataGridView1.Rows[r].Cells["Правая передняя фара"].Value;
                        dataSet.Tables["elements"].Rows[r]["Левая задняя фара"] = dataGridView1.Rows[r].Cells["Левая задняя фара"].Value;
                        dataSet.Tables["elements"].Rows[r]["Левая передняя фара"] = dataGridView1.Rows[r].Cells["Левая передняя фара"].Value;
                        dataSet.Tables["elements"].Rows[r]["Стекло заднего вида"] = dataGridView1.Rows[r].Cells["Стекло заднего вида"].Value;
                       // dataSet.Tables["elements"].Rows[r]["side_right_mirror"] = dataGridView1.Rows[r].Cells["side_right_mirror"].Value;
                        //dataSet.Tables["elements"].Rows[r]["vin"] = dataGridView1.Rows[r].Cells["vin"].Value;
                        dataSet.Tables["elements"].Rows[r]["Остальное"] = dataGridView1.Rows[r].Cells["Остальное"].Value;




                        sqlDataAdapter.Update(dataSet, "elements");
                        dataGridView1.Rows[e.RowIndex].Cells[x].Value = "Delete";
                    }
                    ReloadData();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void BindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }


        private void Selectt()
        {
                                  
                try
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.Rows.Clear();
                    sqlDataAdapter = new SqlDataAdapter("Select vin AS VIN, login_user AS Логин ,model AS Модель, issue_date AS [Дата выпуска],type AS Тип,color AS Цвет,engine_capacity AS Объем,power AS [Мощность л.с.], id,car_make AS Марка, 'Delete' AS [Delete] FROM vin", cnn);
                    sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);
   
                    sqlDataAdapter1 = new SqlDataAdapter("Select model FROM model ", cnn);

                    sqlDataAdapter2 = new SqlDataAdapter("Select type FROM type ", cnn);
                    sqlDataAdapter3 = new SqlDataAdapter("Select color FROM color ", cnn);
                    sqlDataAdapter4 = new SqlDataAdapter("Select car_make FROM car_make ", cnn);
                    sqlDataAdapter5 = new SqlDataAdapter("Select login FROM auth ", cnn);


                    dataSet2 = new DataSet();
                    sqlDataAdapter2.Fill(dataSet2, "type");

                    dataSet3 = new DataSet();
                    sqlDataAdapter3.Fill(dataSet3, "color");

                    dataSet4 = new DataSet();
                    sqlDataAdapter4.Fill(dataSet4, "car_make");


                   dataSet5 = new DataSet();
                   sqlDataAdapter5.Fill(dataSet5, "auth");

                sqlBuilder.GetInsertCommand();
                    sqlBuilder.GetUpdateCommand();
                    sqlBuilder.GetDeleteCommand();
           

                    dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet, "vin");

                    dataSet1 = new DataSet();
                    sqlDataAdapter1.Fill(dataSet1, "model");

                dataGridView1.DataSource = dataSet.Tables["vin"];             

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                        dataGridView1[10, i] = linkCell;
                    DataGridViewComboBoxCell combocell = new DataGridViewComboBoxCell();
                    combocell.FlatStyle = FlatStyle.Popup;
                    DataGridViewComboBoxCell combocell1 = new DataGridViewComboBoxCell();
                    combocell1.FlatStyle = FlatStyle.Popup;
                    DataGridViewComboBoxCell combocell2 = new DataGridViewComboBoxCell();
                    combocell2.FlatStyle = FlatStyle.Popup;
                    DataGridViewComboBoxCell combocell3 = new DataGridViewComboBoxCell();
                    combocell3.FlatStyle = FlatStyle.Popup;
                    DataGridViewComboBoxCell combocell4 = new DataGridViewComboBoxCell();
                    combocell4.FlatStyle = FlatStyle.Popup;

                    for (int g = 0; g < dataSet5.Tables["auth"].Rows.Count; g++)
                    {
                        combocell4.Items.Add(dataSet5.Tables["auth"].Rows[g][0]);
                    }
                    dataGridView1[1, i] = combocell4;

                    for (int g = 0; g < dataSet1.Tables["model"].Rows.Count; g++)
                    {
                        combocell.Items.Add(dataSet1.Tables["model"].Rows[g][0]);
                    }
                    dataGridView1[2, i] = combocell;

                    for (int g = 0; g < dataSet2.Tables["type"].Rows.Count; g++)
                    {
                        combocell1.Items.Add(dataSet2.Tables["type"].Rows[g][0]);
                    }
                    dataGridView1[4, i] = combocell1;

                    for (int g = 0; g < dataSet3.Tables["color"].Rows.Count; g++)
                    {
                        combocell2.Items.Add(dataSet3.Tables["color"].Rows[g][0]);
                    }
                    dataGridView1[5, i] = combocell2;

                    for (int g = 0; g < dataSet4.Tables["car_make"].Rows.Count; g++)
                    {
                        combocell3.Items.Add(dataSet4.Tables["car_make"].Rows[g][0]);
                    }
                    dataGridView1[9, i] = combocell3;
                }            
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Доступ запрещен!" + ex);
                } 
        }

        private void TO()
        {
            try
            {
                //dataSet.Clear();
               
               
                sqlDataAdapter = new SqlDataAdapter("Select id, date AS Дата, replacement AS Замена, mileage AS Пробег, cost AS [Стоимость ремонта], place AS [Место ремонта],vin AS VIN, number_of_crash_elements AS [Идентефикатор авариии],'Delete' AS [Delete] FROM maintenance", cnn);
                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);

                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();
                sqlDataAdapter3 = new SqlDataAdapter("Select vin FROM vin ", cnn);
                sqlDataAdapter4 = new SqlDataAdapter("Select number_of_crash_elements FROM elements", cnn);


                dataSet3 = new DataSet();
                sqlDataAdapter3.Fill(dataSet3, "maintenance");

                dataSet4 = new DataSet();
                sqlDataAdapter4.Fill(dataSet4, "elements");

                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "maintenance");
               // MessageBox.Show(Convert.ToString(dataSet.Tables["maintenance"].Rows[0][1]));
               dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.DataSource = dataSet.Tables["maintenance"];

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[8, i] = linkCell;
                    //dataGridView1.Refresh();


                    DataGridViewComboBoxCell combocell6 = new DataGridViewComboBoxCell();
                    combocell6.FlatStyle = FlatStyle.Popup;

                    for (int g = 0; g < dataSet3.Tables["maintenance"].Rows.Count; g++)
                    {
                        combocell6.Items.Add(dataSet3.Tables["maintenance"].Rows[g][0]);
                    }
                    dataGridView1[6, i] = combocell6;

                    DataGridViewComboBoxCell combocell7 = new DataGridViewComboBoxCell();
                    combocell7.FlatStyle = FlatStyle.Popup;

                    for (int g = 0; g < dataSet4.Tables["elements"].Rows.Count; g++)
                    {
                        combocell7.Items.Add(dataSet4.Tables["elements"].Rows[g][0]);
                    }
                    dataGridView1[7, i] = combocell7;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Доступ запрещен!" + ex);
            }
        }

        private void DTP()
        {
            try
            {
                //dataSet.Clear();


                sqlDataAdapter = new SqlDataAdapter("Select id, damage AS Повреждения, repair_cost AS [Стоимость ремонта], date AS Дата, place AS [Место проведения ремонта], vin AS VIN,'Delete' AS [Delete] FROM crash", cnn);
                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);
                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();


                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "crash");

                sqlDataAdapter3 = new SqlDataAdapter("Select vin FROM vin ", cnn);


                dataSet3 = new DataSet();
                sqlDataAdapter3.Fill(dataSet3, "vin");


               
                // MessageBox.Show(Convert.ToString(dataSet.Tables["maintenance"].Rows[0][1]));
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.DataSource = dataSet.Tables["crash"];

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[6, i] = linkCell;
                    //dataGridView1.Refresh();

                    DataGridViewComboBoxCell combocell6 = new DataGridViewComboBoxCell();
                    combocell6.FlatStyle = FlatStyle.Popup;

                    for (int g = 0; g < dataSet3.Tables["vin"].Rows.Count; g++)
                    {
                        combocell6.Items.Add(dataSet3.Tables["vin"].Rows[g][0]);
                    }
                    dataGridView1[5, i] = combocell6;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Доступ запрещен!" + ex);
            }
        }


        private void Pledge()
        {
            try
            {
                //dataSet.Clear();


                sqlDataAdapter = new SqlDataAdapter("Select id, cause AS Причина, company AS Компания, date AS Дата,vin AS VIN,'Delete' AS [Delete] FROM pledge", cnn);
                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);
                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();

                sqlDataAdapter3 = new SqlDataAdapter("Select vin FROM vin ", cnn);


                dataSet3 = new DataSet();
                sqlDataAdapter3.Fill(dataSet3, "vin");


                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "pledge");
                // MessageBox.Show(Convert.ToString(dataSet.Tables["maintenance"].Rows[0][1]));
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.DataSource = dataSet.Tables["pledge"];

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[5, i] = linkCell;
                    //dataGridView1.Refresh();

                    DataGridViewComboBoxCell combocell6 = new DataGridViewComboBoxCell();
                    combocell6.FlatStyle = FlatStyle.Popup;

                    for (int g = 0; g < dataSet3.Tables["vin"].Rows.Count; g++)
                    {
                        combocell6.Items.Add(dataSet3.Tables["vin"].Rows[g][0]);
                    }
                    dataGridView1[4, i] = combocell6;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Доступ запрещен!" + ex);
            }
        }

        private void Search()
        {
            try
            {
                //dataSet.Clear();


                sqlDataAdapter = new SqlDataAdapter("Select id, couse AS Причина, vin AS VIN,'Delete' AS [Delete] FROM search", cnn);
                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);
                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();
                sqlDataAdapter3 = new SqlDataAdapter("Select vin FROM vin ", cnn);


                dataSet3 = new DataSet();
                sqlDataAdapter3.Fill(dataSet3, "vin");


                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "search");
                // MessageBox.Show(Convert.ToString(dataSet.Tables["maintenance"].Rows[0][1]));
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.DataSource = dataSet.Tables["search"];

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[3, i] = linkCell;
                    //dataGridView1.Refresh();

                    DataGridViewComboBoxCell combocell6 = new DataGridViewComboBoxCell();
                    combocell6.FlatStyle = FlatStyle.Popup;

                    for (int g = 0; g < dataSet3.Tables["vin"].Rows.Count; g++)
                    {
                        combocell6.Items.Add(dataSet3.Tables["vin"].Rows[g][0]);
                    }
                    dataGridView1[2, i] = combocell6;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Доступ запрещен!" + ex);
            }
        }

        private void Taxi()
        {
            try
            {
                //dataSet.Clear();


                sqlDataAdapter = new SqlDataAdapter("Select id, company AS Компания, id_auto, driver_name AS [ФИО водителя],vin AS VIN,'Delete' AS [Delete] FROM taxi", cnn);
                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);
                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();

                sqlDataAdapter3 = new SqlDataAdapter("Select vin FROM vin ", cnn);
                
                dataSet3 = new DataSet();
                sqlDataAdapter3.Fill(dataSet3, "vin");


                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "taxi");
                // MessageBox.Show(Convert.ToString(dataSet.Tables["maintenance"].Rows[0][1]));
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.DataSource = dataSet.Tables["taxi"];

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[5, i] = linkCell;
                    //dataGridView1.Refresh();

                    DataGridViewComboBoxCell combocell7 = new DataGridViewComboBoxCell();
                    combocell7.FlatStyle = FlatStyle.Popup;

                    for (int g = 0; g < dataSet3.Tables["vin"].Rows.Count; g++)
                    {
                        combocell7.Items.Add(dataSet3.Tables["vin"].Rows[g][0]);
                    }
                    dataGridView1[4, i] = combocell7;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Доступ запрещен!" + ex);
            }
        }


        private void Elements()
        {
            try
            {
                //dataSet.Clear();


                sqlDataAdapter = new SqlDataAdapter("Select id,right_front_fender AS [Правое переденее крыло], right_rear_fender AS [Правое заднее крыло], left_front_fender AS [Левое переденее крыло], left_rear_fender AS [Левое заднее крыло], passenger_front_door AS [Передняя пассажирская дверь], passenger_right_rear_door  AS [Правая задняя дверь пассажира], drivers_door AS [Водительская дверь], passenger_left_rear_door AS [Левая задняя дверь пассажира], hood AS [Капот], rear_bumper AS [Задний бампер], front_bumper AS [Передний бампер], windshield AS [Лобовое стекло], roof AS [Крыша], side_windows AS [Боковые стекла], trunk_lid AS [Крышка багажника], wheels AS [Колеса], right_rear_light AS [Правая задняя фара], right_headlight AS [Правая передняя фара], left_rear_light AS [Левая задняя фара], left_front_headlight AS [Левая передняя фара], rear_view_glass AS [Стекло заднего вида], etc  AS [Остальное]  ,vin AS VIN,'Delete' AS [Delete] FROM elements", cnn);
                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);
                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();

                sqlDataAdapter3 = new SqlDataAdapter("Select vin FROM vin ", cnn);

                dataSet3 = new DataSet();
                sqlDataAdapter3.Fill(dataSet3, "vin");

                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "elements");
                // MessageBox.Show(Convert.ToString(dataSet.Tables["maintenance"].Rows[0][1]));
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.DataSource = dataSet.Tables["elements"];

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[24, i] = linkCell;
                    //dataGridView1.Refresh();

                    DataGridViewComboBoxCell combocell7 = new DataGridViewComboBoxCell();
                    combocell7.FlatStyle = FlatStyle.Popup;

                    for (int g = 0; g < dataSet3.Tables["vin"].Rows.Count; g++)
                    {
                        combocell7.Items.Add(dataSet3.Tables["vin"].Rows[g][0]);
                    }
                    dataGridView1[23, i] = combocell7;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Доступ запрещен!" + ex);
            }
        }
        private void ReloadData()
        {
            try
            {
                if(y == 1)
                {
                    dataSet.Tables["vin"].Clear();
                    sqlDataAdapter.Fill(dataSet, "vin");

                    dataGridView1.DataSource = dataSet.Tables["vin"];

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                        dataGridView1[10, i] = linkCell;

                        DataGridViewComboBoxCell combocell = new DataGridViewComboBoxCell();
                        combocell.FlatStyle = FlatStyle.Popup;

                        DataGridViewComboBoxCell combocell4 = new DataGridViewComboBoxCell();
                        combocell4.FlatStyle = FlatStyle.Popup;

                        for (int g = 0; g < dataSet5.Tables["auth"].Rows.Count; g++)
                        {
                            combocell4.Items.Add(dataSet5.Tables["auth"].Rows[g][0]);
                        }
                        dataGridView1[1, i] = combocell4;

                        for (int g = 0; g < dataSet1.Tables["model"].Rows.Count; g++)
                        {
                            combocell.Items.Add(dataSet1.Tables["model"].Rows[g][0]);
                        }
                        dataGridView1[2, i] = combocell;

                        DataGridViewComboBoxCell combocell1 = new DataGridViewComboBoxCell();
                        combocell1.FlatStyle = FlatStyle.Popup;
                        for (int g = 0; g < dataSet2.Tables["type"].Rows.Count; g++)
                        {
                            combocell1.Items.Add(dataSet2.Tables["type"].Rows[g][0]);
                        }
                        dataGridView1[4, i] = combocell1;

                        DataGridViewComboBoxCell combocell2 = new DataGridViewComboBoxCell();
                        combocell2.FlatStyle = FlatStyle.Popup;
                        for (int g = 0; g < dataSet3.Tables["color"].Rows.Count; g++)
                        {
                            combocell2.Items.Add(dataSet3.Tables["color"].Rows[g][0]);
                        }
                        dataGridView1[5, i] = combocell2;
                        DataGridViewComboBoxCell combocell3 = new DataGridViewComboBoxCell();
                        combocell3.FlatStyle = FlatStyle.Popup;
                        for (int g = 0; g < dataSet4.Tables["car_make"].Rows.Count; g++)
                        {
                            combocell3.Items.Add(dataSet4.Tables["car_make"].Rows[g][0]);
                        }
                        dataGridView1[9, i] = combocell3;


                    }

                    RowsAdding = false;
                } else if(y == 2)
                {
                    dataSet.Tables["maintenance"].Clear();
                    sqlDataAdapter.Fill(dataSet, "maintenance");

                    dataGridView1.DataSource = dataSet.Tables["maintenance"];

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                        dataGridView1[8, i] = linkCell;

                        DataGridViewComboBoxCell combocell6 = new DataGridViewComboBoxCell();
                        combocell6.FlatStyle = FlatStyle.Popup;

                        for (int g = 0; g < dataSet3.Tables["maintenance"].Rows.Count; g++)
                        {
                            combocell6.Items.Add(dataSet3.Tables["maintenance"].Rows[g][0]);
                        }
                        dataGridView1[6, i] = combocell6;

                        DataGridViewComboBoxCell combocell7 = new DataGridViewComboBoxCell();
                        combocell7.FlatStyle = FlatStyle.Popup;

                        for (int g = 0; g < dataSet4.Tables["elements"].Rows.Count; g++)
                        {
                            combocell7.Items.Add(dataSet4.Tables["elements"].Rows[g][0]);
                        }
                        dataGridView1[7, i] = combocell7;
                    }

                    RowsAdding = false;
                }
                else if (y == 3) 
                {
                    dataSet.Tables["crash"].Clear();
                    sqlDataAdapter.Fill(dataSet, "crash");

                    dataGridView1.DataSource = dataSet.Tables["crash"];

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                        dataGridView1[6, i] = linkCell;

                        DataGridViewComboBoxCell combocell6 = new DataGridViewComboBoxCell();
                        combocell6.FlatStyle = FlatStyle.Popup;

                        for (int g = 0; g < dataSet3.Tables["vin"].Rows.Count; g++)
                        {
                            combocell6.Items.Add(dataSet3.Tables["vin"].Rows[g][0]);
                        }
                        dataGridView1[5, i] = combocell6;
                    }
                    RowsAdding = false;
                }
                else if (y == 4) 
                {
                    dataSet.Tables["pledge"].Clear();
                    sqlDataAdapter.Fill(dataSet, "pledge");

                    dataGridView1.DataSource = dataSet.Tables["pledge"];

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                        dataGridView1[5, i] = linkCell;

                        DataGridViewComboBoxCell combocell6 = new DataGridViewComboBoxCell();
                        combocell6.FlatStyle = FlatStyle.Popup;

                        for (int g = 0; g < dataSet3.Tables["vin"].Rows.Count; g++)
                        {
                            combocell6.Items.Add(dataSet3.Tables["vin"].Rows[g][0]);
                        }
                        dataGridView1[4, i] = combocell6;
                    }
                    RowsAdding = false;
                }
                else if (y == 5)
                {
                    dataSet.Tables["search"].Clear();
                    sqlDataAdapter.Fill(dataSet, "search");

                    dataGridView1.DataSource = dataSet.Tables["search"];

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                        dataGridView1[3, i] = linkCell;

                        DataGridViewComboBoxCell combocell6 = new DataGridViewComboBoxCell();
                        combocell6.FlatStyle = FlatStyle.Popup;

                        for (int g = 0; g < dataSet3.Tables["vin"].Rows.Count; g++)
                        {
                            combocell6.Items.Add(dataSet3.Tables["vin"].Rows[g][0]);
                        }
                        dataGridView1[2, i] = combocell6;
                    }
                    RowsAdding = false;
                }

                else if (y == 6)
                {
                    dataSet.Tables["taxi"].Clear();
                    sqlDataAdapter.Fill(dataSet, "taxi");

                    dataGridView1.DataSource = dataSet.Tables["taxi"];

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                        dataGridView1[5, i] = linkCell;

                        DataGridViewComboBoxCell combocell7 = new DataGridViewComboBoxCell();
                        combocell7.FlatStyle = FlatStyle.Popup;

                        for (int g = 0; g < dataSet3.Tables["vin"].Rows.Count; g++)
                        {
                            combocell7.Items.Add(dataSet3.Tables["vin"].Rows[g][0]);
                        }
                        dataGridView1[4, i] = combocell7;
                    }
                    RowsAdding = false;
                }

                else if (y == 7)
                {
                    dataSet.Tables["elements"].Clear();
                    sqlDataAdapter.Fill(dataSet, "elements");

                    dataGridView1.DataSource = dataSet.Tables["elements"];

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                        dataGridView1[24, i] = linkCell;

                        DataGridViewComboBoxCell combocell7 = new DataGridViewComboBoxCell();
                        combocell7.FlatStyle = FlatStyle.Popup;

                        for (int g = 0; g < dataSet3.Tables["vin"].Rows.Count; g++)
                        {
                            combocell7.Items.Add(dataSet3.Tables["vin"].Rows[g][0]);
                        }
                        dataGridView1[23, i] = combocell7;
                    }
                    RowsAdding = false;
                }


            }
            catch (Exception)
            {
                MessageBox.Show("Доступ запрещен!");
            }
        }     

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            ReloadData();

        }

        private void DataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if(newRowsAdding == false) {
                    RowsAdding = true;
                    int lastRows = dataGridView1.Rows.Count - 2;

                    DataGridViewRow row = dataGridView1.Rows[lastRows];
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                   // MessageBox.Show("Индекс" + x);
                    dataGridView1[x, lastRows] = linkCell;

                    row.Cells["Delete"].Value = "Insert";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка:" + ex);
            }
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(RowsAdding == false)
                {
                    int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow addingRow = dataGridView1.Rows[rowIndex];
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[x, rowIndex] = linkCell;

                    addingRow.Cells["Delete"].Value = "Update";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка:" + ex);
            }
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            y = 1;
            x = 10;
            Selectt();
            
            dataGridView1.Columns[8].Visible = false;
            toolStripButton10.Visible = false;
        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            y = 2;
            x = 8;
            TO();
           dataGridView1.Columns[0].Visible = false;
            /*dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;*/
            toolStripButton10.Visible = false;
        }

        private void ToolStripButton4_Click(object sender, EventArgs e)
        {
            y = 3;
            x = 6;
            DTP();
            dataGridView1.Columns[0].Visible = false;
           /*dataGridView1.Columns[5].Visible = false;*/
            toolStripButton10.Visible = false;
        }

        private void ToolStripButton5_Click(object sender, EventArgs e)
        {
            y = 4;
            x = 5;
            Pledge();
            dataGridView1.Columns[0].Visible = false;
            toolStripButton10.Visible = false;
        }

        private void ToolStripButton6_Click(object sender, EventArgs e)
        {
            y = 5;
            x = 3;
            Search();
            dataGridView1.Columns[0].Visible = false;
            toolStripButton10.Visible = false;
        }

        private void ToolStripButton7_Click(object sender, EventArgs e)
        {
            y = 6;
            x = 5;
            Taxi();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            toolStripButton10.Visible = false;

        }

        private void ToolStripButton8_Click(object sender, EventArgs e)
        {

             y = 7;
            x = 24;
            Elements();
            toolStripButton10.Visible = true;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[22].Visible = false;
        }

        private void ToolStripButton9_Click(object sender, EventArgs e)
        {
            toolStripButton10.Visible = false;
            cnn.Close();
            Hide();
            Form a = new auth();
            a.ShowDialog();
            this.Close();
        }

        private void ToolStripButton10_Click(object sender, EventArgs e)
        {

             Hide();
             Form a = new Elements();
             a.ShowDialog();
             this.Close();
        }
    }
}
