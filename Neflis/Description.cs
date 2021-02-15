using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLiteDb;

namespace Neflis
{
    public partial class Description : Form
    {
        bool noct;
        SQLiteConn conn = new SQLiteConn("neflisdata.db", true);
        User userlogin;
        Movie movie;

        public Description(Principal principal, User userlogin, Movie movie, bool noct)
        {
            InitializeComponent();
            this.userlogin = userlogin;
            this.movie = movie;
            this.noct = noct;
            if (conn.GetMoviesSeen(userlogin).Exists(m => m.Code == movie.Code)) btnVer.Text = "Continuar Viendo";

            if (noct)
            {
                this.BackColor = Color.FromArgb(40, 40, 40);
                nameMovie.BackColor = Color.FromArgb(40, 40, 40);
                nameMovie.ForeColor = Color.White;
                DateMovie.ForeColor = Color.White;
                label1.ForeColor = Color.White;
                txtDescription.BackColor = Color.FromArgb(40, 40, 40);
                txtDescription.ForeColor = Color.White;
                txtUser1.BackColor = Color.FromArgb(40, 40, 40);
                txtUser1.ForeColor = Color.White;
                txtUser2.BackColor = Color.FromArgb(40, 40, 40);
                txtUser2.ForeColor = Color.White;
                txtUser3.BackColor = Color.FromArgb(40, 40, 40);
                txtUser3.ForeColor = Color.White;
                txtUser4.BackColor = Color.FromArgb(40, 40, 40);
                txtUser4.ForeColor = Color.White;
                txtReview1.BackColor = Color.FromArgb(40, 40, 40);
                txtReview1.ForeColor = Color.White;
                txtReview2.BackColor = Color.FromArgb(40, 40, 40);
                txtReview2.ForeColor = Color.White;
                txtReview3.BackColor = Color.FromArgb(40, 40, 40);
                txtReview3.ForeColor = Color.White;
                txtReview4.BackColor = Color.FromArgb(40, 40, 40);
                txtReview4.ForeColor = Color.White;
            }
            else
            {
                this.BackColor = Control.DefaultBackColor;
                nameMovie.BackColor = Control.DefaultBackColor;
                nameMovie.ForeColor = Color.Black;
                DateMovie.ForeColor = Color.Black;
                label1.ForeColor = Color.Black;
                txtDescription.BackColor = Control.DefaultBackColor;
                txtDescription.ForeColor = Color.Black;
                txtUser1.BackColor = Control.DefaultBackColor;
                txtUser1.ForeColor = Color.Black;
                txtUser2.BackColor = Control.DefaultBackColor;
                txtUser2.ForeColor = Color.Black;
                txtUser3.BackColor = Control.DefaultBackColor;
                txtUser3.ForeColor = Color.Black;
                txtUser4.BackColor = Control.DefaultBackColor;
                txtUser4.ForeColor = Color.Black;
                txtReview1.BackColor = Control.DefaultBackColor;
                txtReview1.ForeColor = Color.Black;
                txtReview2.BackColor = Control.DefaultBackColor;
                txtReview2.ForeColor = Color.Black;
                txtReview3.BackColor = Control.DefaultBackColor;
                txtReview3.ForeColor = Color.Black;
                txtReview4.BackColor = Control.DefaultBackColor;
                txtReview4.ForeColor = Color.Black;
            }

            txtDescription.Text = movie.Description;
            pctMovie.BackgroundImage = Image.FromFile($"images/{movie.Image}");
            nameMovie.Text = movie.Title;
            DateMovie.Text = $"{movie.Year} - {movie.Genre}";
            txtReview1.Hide();
            txtReview2.Hide();
            txtReview3.Hide();
            txtReview4.Hide();

            if (movie.Reviews.Count > 0)
            {
                txtUser1.Show();
                txtReview1.Show();
                txtUser1.Text = movie.Reviews[movie.Reviews.Count - 1].Usuario.FullName;
                txtReview1.Text = $"{movie.Reviews[movie.Reviews.Count - 1].Commentary}; {movie.Reviews[movie.Reviews.Count - 1].Score} estrellas";
            }
            if (movie.Reviews.Count > 1)
            {
                txtUser2.Show();
                txtReview2.Show();
                txtUser2.Text = movie.Reviews[movie.Reviews.Count - 2].Usuario.FullName;
                txtReview2.Text = $"{movie.Reviews[movie.Reviews.Count - 2].Commentary}; {movie.Reviews[movie.Reviews.Count - 2].Score} estrellas";
            }
            if (movie.Reviews.Count > 2)
            {
                txtUser3.Show();
                txtReview3.Show();
                txtUser3.Text = movie.Reviews[movie.Reviews.Count - 3].Usuario.FullName;
                txtReview3.Text = $"{movie.Reviews[movie.Reviews.Count - 3].Commentary}; {movie.Reviews[movie.Reviews.Count - 3].Score} estrellas";
            }
            if (movie.Reviews.Count > 3)
            {
                txtUser4.Show();
                txtReview4.Show();
                txtUser4.Text = movie.Reviews[movie.Reviews.Count - 4].Usuario.FullName;
                txtReview4.Text = $"{movie.Reviews[movie.Reviews.Count - 4].Commentary}; {movie.Reviews[movie.Reviews.Count - 4].Score} estrellas";
            }
            
            if(movie.ScoreTotal >= 1) pictureBox1.Image = Image.FromFile("images/star_2.png");
            else if(movie.ScoreTotal >= 0.5) pictureBox1.Image = Image.FromFile("images/star_1.png");
            else pictureBox1.Image = Image.FromFile("images/star_0.png");

            if (movie.ScoreTotal >= 2) pictureBox2.Image = Image.FromFile("images/star_2.png");
            else if (movie.ScoreTotal >= 1.5) pictureBox2.Image = Image.FromFile("images/star_1.png");
            else pictureBox2.Image = Image.FromFile("images/star_0.png");

            if (movie.ScoreTotal >= 3) pictureBox3.Image = Image.FromFile("images/star_2.png");
            else if (movie.ScoreTotal >= 2.5) pictureBox3.Image = Image.FromFile("images/star_1.png");
            else pictureBox3.Image = Image.FromFile("images/star_0.png");

            if (movie.ScoreTotal >= 4) pictureBox4.Image = Image.FromFile("images/star_2.png");
            else if (movie.ScoreTotal >= 3.5) pictureBox4.Image = Image.FromFile("images/star_1.png");
            else pictureBox4.Image = Image.FromFile("images/star_0.png");

            if (movie.ScoreTotal == 5) pictureBox5.Image = Image.FromFile("images/star_2.png");
            else if (movie.ScoreTotal >= 4.5) pictureBox5.Image = Image.FromFile("images/star_1.png");
            else pictureBox5.Image = Image.FromFile("images/star_0.png");
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            Reproducir reproducir = new Reproducir(conn, userlogin, movie);
            this.Close();
            reproducir.Show();
        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            Add_Comentary add_Comentary = new Add_Comentary(movie, userlogin, noct);
            add_Comentary.Show();
        }
    }
}