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

        int i = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            // Подключение к базе данных
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=kino;Integrated Security=True"; // Замените на вашу строку подключения
            string query = "SELECT filmImg FROM film WHERE filmId = @id"; // Замените на название вашей таблицы

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    while (true) // Бесконечный цикл, из которого мы выйдем, если найдём запись
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@id", i);
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read()) // Проверяем, есть ли запись с текущим id
                                {
                                    string imageUrl = reader["filmImg"] as string;
                                    if (!string.IsNullOrEmpty(imageUrl))
                                    {
                                        try
                                        {
                                            // Загрузка изображения из ссылки
                                            using (WebClient webClient = new WebClient())
                                            {
                                                byte[] imageData = webClient.DownloadData(imageUrl);
                                                using (MemoryStream ms = new MemoryStream(imageData))
                                                {
                                                    pictureBox1.Image = Image.FromStream(ms);
                                                }
                                            }
                                        }
                                        catch (Exception imgEx)
                                        {
                                            MessageBox.Show($"Ошибка загрузки изображения: {imgEx.Message}");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Ссылка на изображение отсутствует.");
                                        pictureBox1.Image = null; // Очистить PictureBox, если ссылки нет
                                    }
                                    break; // Если запись найдена, выходим из цикла
                                }
                                else
                                {
                                    i++; // Если записи нет, увеличиваем i
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
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
        