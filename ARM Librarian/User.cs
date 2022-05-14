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
    public partial class User : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= Book.mdb";
        private OleDbConnection myConnection;
        public User()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void User_Load(object sender, EventArgs e)
        {
            this.книгиTableAdapter.Fill(this.bookDataSet.Книги);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox1.Text);
            string query = "SELECT [Код], Название, Автор, Год, Издательство FROM Книги WHERE Код LIKE '%" + kod + "%' ";
            OleDbDataAdapter command = new OleDbDataAdapter(query, myConnection);
            DataTable dt = new DataTable();
            command.Fill(dt);
            dataGridView2.DataSource = dt;

            textBox1.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Admin af = new Admin();
            af.Owner = this;
            af.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            dataGridView2.DataSource = книгиBindingSource;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            string Name = textBox2.Text;
            string Status = "Возврат";
            var Time = DateTime.Today.ToShortDateString();
            string query = "INSERT INTO Отчеты ([Наименование], [Статус], [Дата]) VALUES ('" + Name + "','" + Status + "', '" + Time + "')";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены!");
            textBox2.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Name = textBox2.Text;
            string Status = "Получение";
            var Time = DateTime.Today.ToShortDateString();
            string query = "INSERT INTO Отчеты ([Наименование], [Статус], [Дата]) VALUES ('" + Name + "','" + Status + "', '" + Time + "')";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены!");
            textBox2.Clear();
        }
    }
}
