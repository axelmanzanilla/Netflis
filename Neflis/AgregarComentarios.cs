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
    public partial class Add_Comentary : Form
    {
        SQLiteConn conn = new SQLiteConn("neflisdata.db", true);
        Movie movie;
        User userlogin;
        float score;

        public Add_Comentary(Movie movie, User userlogin, bool noct)
        {
            InitializeComponent();

            this.movie = movie;
            this.userlogin = userlogin;
            txtPelículas.Text = movie.Title;
            pctMovie.BackgroundImage = Image.FromFile($"images/{movie.Image}");

            if (noct)
            {
                this.BackColor = Color.FromArgb(40, 40, 40);
                lblBienvenida.ForeColor = Color.White;
                txtPelículas.BackColor = Color.FromArgb(40, 40, 40);
                txtPelículas.ForeColor = Color.White;
                label1.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                label3.ForeColor = Color.White;
            }
            else
            {
                this.BackColor = Control.DefaultBackColor;
                lblBienvenida.ForeColor = Color.Black;
                txtPelículas.BackColor = Control.DefaultBackColor;
                txtPelículas.ForeColor = Color.Black;
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
                label3.ForeColor = Color.Black;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (rbn1.Checked) score = 1;
            else if (rbn2.Checked) score = 2;
            else if (rbn3.Checked) score = 3;
            else if (rbn4.Checked) score = 4;
            else if (rbn5.Checked) score = 5;
            conn.ExecuteNonQuery($"INSERT INTO film_review (movie_code, score, commentary, membership_id) VALUES ('{movie.Code}', {score}, '{rtbComentarios.Text}'," +
                $"{userlogin.Id});");
            MessageBox.Show("Comentario registrado con Éxito!");
            this.Close();
        }
    }
}
