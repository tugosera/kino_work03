using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace kino_work03
{
    public partial class User_choose : Form
    {
        public User_choose()
        {
            InitializeComponent();
        }

        int tt = 0;
        List<string> pildid = new List<string>();
        List<string> names = new List<string>();
        List<string> years = new List<string>();
        List<int> filmIds = new List<int>();

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=kino;Integrated Security=True";
            string query = "SELECT filmImg FROM film";
            string queryName = "SELECT filmName FROM film";
            string queryYear = "SELECT filmYear FROM film";
            string queryId = "SELECT filmId FROM film";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string imageUrl = reader["filmImg"].ToString();
                                pildid.Add(imageUrl);
                            }
                        }
                    }

                    using (SqlCommand command = new SqlCommand(queryName, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string name = reader["filmName"].ToString();
                                names.Add(name);
                            }
                        }
                    }

                    using (SqlCommand command = new SqlCommand(queryYear, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string year = reader["filmYear"].ToString();
                                years.Add(year);
                            }
                        }
                    }

                    using (SqlCommand command = new SqlCommand(queryId, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                filmIds.Add(id);
                            }
                        }
                    }

                    if (pildid.Count > 0)
                    {
                        string imageUrl = pildid[tt];

                        string name = names[tt];

                        string year = years[tt];

                        textBox1.Text = name;

                        textBox2.Text = year;

                        pictureBox1.Image = LoadImageFromUrl(imageUrl);

                        tt++;

                        if (tt == pildid.Count)
                        {
                            tt = 0;
                        }
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

        private Image LoadImageFromUrl(string imageUrl)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    byte[] imageBytes = webClient.DownloadData(imageUrl);
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        return Image.FromStream(ms);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке изображения: " + ex.Message);
                return null;
            }
        }
        
        void button2_MouseClick(object sender, MouseEventArgs e)
        {
             
            this.Hide();
            var userBuyTickets = new User_buy_tickets
            {
                SelectedFilmId = filmIds[tt] // Передаем идентификатор выбранного фильма
            };
            userBuyTickets.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}