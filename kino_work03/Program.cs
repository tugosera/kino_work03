using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kino_work03
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Admin());
        }
    }
}

//Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=kino;Integrated Security=True

//database
//create database kino;
//use kino;

//create table users(
//userId int primary key identity(1,1),
//userName varchar(50),
//password varchar(50));

//create table film(
//filmId int primary key identity(1,1),
//filmName varchar(50),
//filmYear int,
//filmImg text);

//create table seat(
//seatId int primary key identity(1,1),
//filmId int,
//seatStatus int,
//FOREIGN KEY (filmId) REFERENCES film(filmId));

//create table ticket(
//tickeId int primary key identity(1,1),
//seatId int,
//userId int,
//filmId int,
//FOREIGN KEY (seatId) REFERENCES seat(seatId),
//FOREIGN KEY (userId) REFERENCES users(userId),
//FOREIGN KEY (filmId) REFERENCES film(filmId));

//select* from users;
//select* from film;
//select* from seat;
//select* from ticket;
