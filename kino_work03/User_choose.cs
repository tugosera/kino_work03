using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

    namespace kino_work03
    {
        public partial class User_choose : Form
        {
            public User_choose()
            {
                InitializeComponent();
            }

        string path = @"C:\Users\opilane.TTHK\source\repos\kino_work03\kino_work03\images.txt";
        int tt = 0;
        List<string> pildid = new List<string> { };
        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=kino;Integrated Security=True";
            string query = "SELECT filmImg FROM film WHERE filmId = @id";

            int someFilmId = 1; // Укажите ID фильма, который хотите загрузить

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", someFilmId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Чтение значения столбца filmImg и добавление в список
                                string imagePath = reader["filmImg"].ToString();
                                pildid.Add(imagePath);
                            }
                        }
                    }

                    if (pildid.Count > 0)
                    {
                        string fail = pildid[tt];
                        pictureBox1.Image = Image.FromFile(fail);
                        tt++;
                        if (tt == pildid.Count) { tt = 0; }
                    }
                    else
                    {
                        MessageBox.Show("Нет изображений для отображения.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
            }
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
            {
                this.Hide();
                User_buy_tickets User_buy_tickets = new User_buy_tickets();
                User_buy_tickets.Show();
            }
        }       
    }
        