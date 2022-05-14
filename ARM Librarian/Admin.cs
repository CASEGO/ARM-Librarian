using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ARM_Librarian
{
    public partial class Admin : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= Book.mdb";
        private OleDbConnection myConnection;
        public Admin()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string NameUser = textBox11.Text;
            string LoginUser = textBox10.Text;
            string PassUser = textBox9.Text;
            string StatusUser = textBox8.Text;
            
            string query = "INSERT INTO Пользователи ([ФИО],[Логин],[Пароль],[Статус]) VALUES('" + NameUser + "','" + LoginUser + "','" + PassUser + "','" + StatusUser + "')";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены!");
            this.пользователиTableAdapter.Fill(this.bookDataSet.Пользователи);

            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            this.сотрудникиTableAdapter.Fill(this.bookDataSet.Сотрудники);
            this.пользователиTableAdapter.Fill(this.bookDataSet.Пользователи);
            this.отчетыTableAdapter.Fill(this.bookDataSet.Отчеты);
            this.книгиTableAdapter.Fill(this.bookDataSet.Книги);

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox1.Text);
            string query = "SELECT [Код], Название, Автор, Год, Издательство FROM Книги WHERE Код LIKE '%" + kod + "%' ";
            OleDbDataAdapter command = new OleDbDataAdapter(query, myConnection);
            DataTable dt = new DataTable();
            command.Fill(dt);
            dataGridView1.DataSource = dt;
            
            textBox1.Clear();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            dataGridView1.DataSource = книгиBindingSource;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox1.Text);
            string query = "DELETE FROM Книги WHERE [Код] = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены!");
            dataGridView1.DataSource = книгиBindingSource;
            this.книгиTableAdapter.Fill(this.bookDataSet.Книги);
            textBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            string NameBook = textBox4.Text;
            string AutorBook = textBox5.Text;
            string YearsBook = textBox6.Text;
            string IzdatBook = textBox7.Text;
            string query = "INSERT INTO Книги ([Название],[Автор],[Год],[Издательство]) VALUES('" + NameBook + "','" + AutorBook + "','" + YearsBook + "','" + IzdatBook + "')";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены!");
            this.книгиTableAdapter.Fill(this.bookDataSet.Книги);
        
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int kodUser = Convert.ToInt32(textBox2.Text);
            string query = "SELECT [Код], ФИО, Логин, Пароль, Статус FROM Пользователи WHERE Код LIKE '%" + kodUser + "%' ";
            OleDbDataAdapter command = new OleDbDataAdapter(query, myConnection);
            DataTable dt = new DataTable();
            command.Fill(dt);
            dataGridView2.DataSource = dt;

            textBox2.Clear();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            dataGridView2.DataSource = пользователиBindingSource;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int kodUser = Convert.ToInt32(textBox2.Text);
            string query = "DELETE FROM Пользователи WHERE [Код] = " + kodUser;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены!");
            dataGridView2.DataSource = пользователиBindingSource;
            this.пользователиTableAdapter.Fill(this.bookDataSet.Пользователи);
            textBox2.Clear();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int kodStaff = Convert.ToInt32(textBox3.Text);
            string query = "DELETE FROM Сотрудники WHERE [Код] = " + kodStaff;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены!");
            dataGridView4.DataSource = сотрудникиBindingSource;
            this.сотрудникиTableAdapter.Fill(this.bookDataSet.Сотрудники);
            textBox3.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int kodStaff = Convert.ToInt32(textBox3.Text);
            string query = "UPDATE Сотрудники SET Должность ='" + textBox12.Text + "' WHERE [Код] = " + kodStaff;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены!");
            this.сотрудникиTableAdapter.Fill(this.bookDataSet.Сотрудники);
            textBox12.Clear();
            textBox3.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string NameStaff = textBox16.Text;
            string PriceStaff = textBox12.Text;
            string StatusStaff = textBox14.Text;
            string TimeStaff = textBox13.Text;
            string query = "INSERT INTO Сотрудники ([ФИО],[Зарплата],[Должность],[Дата]) VALUES('" + NameStaff + "','" + PriceStaff + "','" + StatusStaff + "','" + TimeStaff + "')";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены!");
            this.сотрудникиTableAdapter.Fill(this.bookDataSet.Сотрудники);

            textBox16.Clear();
            textBox15.Clear();
            textBox14.Clear();
            textBox13.Clear();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            int kodList = Convert.ToInt32(textBox17.Text);
            string query = "SELECT [Код], Наименование, Статус, Дата FROM Отчеты WHERE Код LIKE '%" + kodList + "%' ";
            OleDbDataAdapter command = new OleDbDataAdapter(query, myConnection);
            DataTable dt = new DataTable();
            command.Fill(dt);
            dataGridView3.DataSource = dt;

            textBox17.Clear();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            dataGridView3.DataSource = отчетыBindingSource;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            int kodList = Convert.ToInt32(textBox17.Text);
            string query = "DELETE FROM Отчеты WHERE [Код] = " + kodList;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены!");
            dataGridView1.DataSource = книгиBindingSource;
            this.отчетыTableAdapter.Fill(this.bookDataSet.Отчеты);
            textBox17.Clear();
        }

      
    }
    }

