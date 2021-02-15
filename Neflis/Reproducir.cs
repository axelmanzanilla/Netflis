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
    public partial class Reproducir : Form
    {
        SQLiteConn conn;
        Movie movie;
        User user;
        int i = 1;

        public Reproducir(SQLiteConn conn, User user, Movie movie)
        {
            InitializeComponent();
            this.movie = movie;
            this.conn = conn;
            this.user = user;
            lblFin.Text = conn.SecondsToHours(movie.Seconds);
            lblInicio.Text = $"{conn.SecondsToHours(conn.GetSecond(user, movie))}";
            i = conn.GetSecond(user, movie);

            if (!conn.GetMoviesSeen(user).Exists(m => m.Code == movie.Code))
                conn.ExecuteNonQuery($"INSERT INTO movies_record (membership_id, movie_code, seconds_seen, watched) " +
                                     $"VALUES ({user.Id}, '{movie.Code}', 0, 1)");
            time.Start();
        }

        private void time_Tick(object sender, EventArgs e)
        {
            lblInicio.Text = conn.SecondsToHours(i);
            i++;
            trackBar1.SetRange(0, movie.Seconds);

            if (i % 30 == 0) conn.ExecuteNonQuery($"UPDATE movies_record SET seconds_seen = {i} " +
                                                  $"WHERE membership_id = {user.Id} AND movie_code = {movie.Code}");
        }

        private void btnVolume_Click(object sender, EventArgs e)
        {
            VolumeControl.Visible = !VolumeControl.Visible;
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            time.Stop();
            if (conn.GetMoviesSeen(user).Exists(m => m.Code == movie.Code))
                conn.ExecuteNonQuery($"UPDATE movies_record SET seconds_seen = {i} " +
                                 $"WHERE membership_id = {user.Id} AND movie_code = '{movie.Code}'");
            else conn.ExecuteNonQuery($"INSERT INTO movies_record (membership_id, movie_code, seconds_seen, watched) " +
                                      $"VALUES ({user.Id}, '{movie.Code}', {i}, 1)");
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            time.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            time.Stop();
            i = 0;
            lblInicio.Text = conn.SecondsToHours(i);
            if (conn.GetMoviesSeen(user).Exists(m => m.Code == movie.Code))
                conn.ExecuteNonQuery($"UPDATE movies_record SET seconds_seen = {i} " +
                                 $"WHERE membership_id = {user.Id} AND movie_code = '{movie.Code}'");
            else conn.ExecuteNonQuery($"INSERT INTO movies_record (membership_id, movie_code, seconds_seen, watched) " +
                                      $"VALUES ({user.Id}, '{movie.Code}', {i}, 1)");
            i++;
        }
    }
}
