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
        private string filmName; // Поле для хранения названия фильма
        private Dictionary<string, bool> selectedSeats = new Dictionary<string, bool>();

        // Конструктор, принимающий filmName
        public User_buy_tickets(string filmName)
        {
            InitializeComponent();
            this.filmName = filmName; // Инициализируем поле
        }






        private void button18_Click(object sender, EventArgs e)
        {
            this.Hide();
            User_choose user_Choose = new User_choose();
            user_Choose.Show();
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