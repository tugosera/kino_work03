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
    public partial class User_buy_tickets : Form
    {

        public int SelectedFilmId { get; set; }


        public User_buy_tickets()
        {
            InitializeComponent();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            this.Hide();
            User_choose user_Choose = new User_choose();
            user_Choose.Show();
        }
        private void SeatButton_Click(object sender, EventArgs e)
        {
            Button seatButton = sender as Button;
            int seatId = (int)seatButton.Tag;

            // Переключение статуса
            bool isReserved = seatButton.BackColor == Color.Red;
            seatButton.BackColor = isReserved ? Color.Green : Color.Red;

            // Обновление в базе данных
            UpdateSeatStatus(seatId, isReserved ? 0 : 1);
        }

        private void UpdateSeatStatus(int seatId, int status)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=kino;Integrated Security=True";
            string query = "UPDATE seat SET seatStatus = @Status WHERE seatId = @SeatId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Status", status);
                    command.Parameters.AddWithValue("@SeatId", seatId);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
