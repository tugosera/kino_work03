using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kino_work03
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = Login_txt.Text.Trim();
            string password = Password_txt.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (login == "SigmaAdmin" && password == "joker228")
            {
                MessageBox.Show("Вы вошли как SigmaAdmin!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Admin Admin = new Admin();
                Admin.Show();
                return;
            }

            string connectionString = "Data Source=HOME\\SQLEXPRESS;Initial Catalog=kino;Integrated Security=True"; 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT COUNT(1) FROM users WHERE userName = @Login AND password = @Password";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Login", login);
                        command.Parameters.AddWithValue("@Password", password);

                        int userCount = Convert.ToInt32(command.ExecuteScalar());

                        if (userCount == 1)
                        {
                            MessageBox.Show("Вы успешно вошли в систему!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            User_choose user_Choose = new User_choose();
                            user_Choose.Show();
                        }
                        else
                        {
                            MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            new_user new_user = new new_user();
            this.Hide();
            new_user.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin Admin = new Admin();
            Admin.Show();
        }
    }
}
