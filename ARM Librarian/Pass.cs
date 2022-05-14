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
    public partial class Pass : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= Book.mdb";
        private OleDbConnection myConnection;
        public Pass()
        {
            InitializeComponent();
        }

        

       

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            {
                if (textBox1.Text == "admin" && textBox2.Text == "root")
                {
                    Admin ma = new Admin();
                    ma.Show();
                    this.Hide();
                }
                else
                {
                    string pass = "";
                    try
                    {
                        myConnection = new OleDbConnection(connectString);
                        myConnection.Open();
                        string query = $"SELECT Пароль FROM Пользователи WHERE Логин = '{textBox1.Text}'";
                        OleDbCommand command = new OleDbCommand(query, myConnection);
                        pass = command.ExecuteScalar().ToString();
                       


                    }
                    catch
                    {
                        MessageBox.Show("Логин не найден");
                        textBox1.Clear();
                        textBox2.Clear();

                    }
                    finally
                    {
                        myConnection.Close();
                        if (pass == textBox2.Text)
                        {
                            myConnection = new OleDbConnection(connectString);
                            myConnection.Open();
                            string query = $"SELECT Статус FROM Пользователи WHERE Логин = '{textBox1.Text}'";
                            OleDbCommand command1 = new OleDbCommand(query, myConnection);
                            var status = command1.ExecuteScalar().ToString();
                            if (status == "Admin")
                            {
                                Admin ma = new Admin();
                                ma.Show();
                                this.Hide();
                            }
                            else
                            {
                                User ma = new User();
                                ma.Show();
                                this.Hide();
                            }
                           

                        }
                        else
                        {
                            MessageBox.Show("Пароль неверный");
                            textBox1.Clear(); 
                            textBox2.Clear();
                        }
                    }


                }
            }
        }

        private void Pass_Load(object sender, EventArgs e)
        {

        }
    }
}
