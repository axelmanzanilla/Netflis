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
    public partial class Principal : Form
    {
        SQLiteConn conn;
        Inicio inicio;
        User userlogin;
        List<Movie> buscar;
        List<Movie> recientes;
        List<Movie> recom;
        List<Movie> best;

        public Principal(SQLiteConn conn, Inicio inicio, User userlogin)
        {
            this.conn = conn;
            this.inicio = inicio;
            this.userlogin = userlogin;
            InitializeComponent();

            panel2.Hide();
            pnlMas.Hide();
            
            lblBienvenida.Text = $"Bienvenido {userlogin.FirstName}";
            lblCuenta.Text = $"Cuenta {userlogin.membership.Description}";

            cmbGenero.DataSource = conn.GetGenres();

            LoadMaterias();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            inicio.Show();
        }

        private void chekNocturno_CheckedChanged(object sender, EventArgs e)
        {
            if (chekNocturno.Checked)
            {
                this.BackColor = Color.FromArgb(40,40,40);
                lblBienvenida.ForeColor = Color.White;
                lblBest.ForeColor = Color.White;
                lblRecientes.ForeColor = Color.White;
                lblCuenta.ForeColor = Color.White;
                lblReco.ForeColor = Color.White;
                label1.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                label3.ForeColor = Color.White;
                label4.ForeColor = Color.White;
                label5.ForeColor = Color.White;
                label6.ForeColor = Color.White;
                label7.ForeColor = Color.White;
                label8.ForeColor = Color.White;
                chekNocturno.ForeColor = Color.White;
                lblOpciones.ForeColor = Color.White;
                lblMenos.ForeColor = Color.White;
            }
            else
            {
                this.BackColor = Control.DefaultBackColor;
                lblBienvenida.ForeColor = Color.Black;
                lblBest.ForeColor = Color.Black;
                lblCuenta.ForeColor = Color.Black;
                lblRecientes.ForeColor = Color.Black;
                lblReco.ForeColor = Color.Black;
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
                label3.ForeColor = Color.Black;
                label4.ForeColor = Color.Black;
                label5.ForeColor = Color.Black;
                label6.ForeColor = Color.Black;
                label7.ForeColor = Color.Black;
                label8.ForeColor = Color.Black;
                chekNocturno.ForeColor = Color.Black;
                lblOpciones.ForeColor = Color.Black;
                lblMenos.ForeColor = Color.Black;
            }
        }

        private void Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Cerrar_Sesión cerrar = new Cerrar_Sesión();
            cerrar.Show();
        }

        private void Recientes1_Click(object sender, EventArgs e)
        {
            Description description = new Description(this, userlogin, recientes[0], chekNocturno.Checked);
            description.Show();
        }

        private void Recientes2_Click(object sender, EventArgs e)
        {
            Description description = new Description(this, userlogin, recientes[1], chekNocturno.Checked);
            description.Show();
        }

        private void Recientes3_Click(object sender, EventArgs e)
        {
            Description description = new Description(this, userlogin, recientes[2], chekNocturno.Checked);
            description.Show();
        }

        private void Recientes4_Click(object sender, EventArgs e)
        {
            Description description = new Description(this, userlogin, recientes[3], chekNocturno.Checked);
            description.Show();
        }

        private void Recientes5_Click(object sender, EventArgs e)
        {
            Description description = new Description(this, userlogin, recientes[4], chekNocturno.Checked);
            description.Show();
        }

        private void Reco1_Click(object sender, EventArgs e)
        {
            Description description = new Description(this, userlogin, recom[0], chekNocturno.Checked);
            description.Show();
        }

        private void Reco2_Click(object sender, EventArgs e)
        {
            Description description = new Description(this, userlogin, recom[1], chekNocturno.Checked);
            description.Show();
        }

        private void Reco3_Click(object sender, EventArgs e)
        {
            Description description = new Description(this, userlogin, recom[2], chekNocturno.Checked);
            description.Show();
        }

        private void Reco4_Click(object sender, EventArgs e)
        {
            Description description = new Description(this, userlogin, recom[3], chekNocturno.Checked);
            description.Show();
        }

        private void Reco5_Click(object sender, EventArgs e)
        {
            Description description = new Description(this, userlogin, recom[4], chekNocturno.Checked);
            description.Show();
        }

        private void Best1_Click(object sender, EventArgs e)
        {
            Description description = new Description(this, userlogin, best[0], chekNocturno.Checked);
            description.Show();
        }

        private void Best2_Click(object sender, EventArgs e)
        {
            Description description = new Description(this, userlogin, best[1], chekNocturno.Checked);
            description.Show();
        }

        private void Best3_Click(object sender, EventArgs e)
        {
            Description description = new Description(this, userlogin, best[2], chekNocturno.Checked);
            description.Show();
        }

        private void Best4_Click(object sender, EventArgs e)
        {
            Description description = new Description(this, userlogin, best[3], chekNocturno.Checked);
            description.Show();
        }

        private void Best5_Click(object sender, EventArgs e)
        {
            Description description = new Description(this, userlogin, best[4], chekNocturno.Checked);
            description.Show();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            txtAmin.Clear();
            txtAmax.Clear();
            txtBuscar.Clear();
            txtCalmin.Clear();
            txtCalmax.Clear();
            cmbGenero.SelectedIndex = 0;
        }

        private void lblOpciones_Click(object sender, EventArgs e)
        {
            pnlMas.Show();
        }

        private void lblMenos_Click(object sender, EventArgs e)
        {
            pnlMas.Hide();
        }

        private void picRes1_Click(object sender, EventArgs e)
        {
            Description description = new Description(this, userlogin, buscar[0], chekNocturno.Checked);
            description.Show();
        }

        private void picRes2_Click(object sender, EventArgs e)
        {
            Description description = new Description(this, userlogin, buscar[1], chekNocturno.Checked);
            description.Show();
        }

        private void picRes3_Click(object sender, EventArgs e)
        {
            Description description = new Description(this, userlogin, buscar[2], chekNocturno.Checked);
            description.Show();
        }

        private void picRes4_Click(object sender, EventArgs e)
        {
            Description description = new Description(this, userlogin, buscar[3], chekNocturno.Checked);
            description.Show();
        }

        private void picRes5_Click(object sender, EventArgs e)
        {
            Description description = new Description(this, userlogin, buscar[4], chekNocturno.Checked);
            description.Show();
        }

        private void picRes6_Click(object sender, EventArgs e)
        {
            Description description = new Description(this, userlogin, buscar[5], chekNocturno.Checked);
            description.Show();
        }

        private void picRes7_Click(object sender, EventArgs e)
        {
            Description description = new Description(this, userlogin, buscar[6], chekNocturno.Checked);
            description.Show();
        }

        private void picRes8_Click(object sender, EventArgs e)
        {
            Description description = new Description(this, userlogin, buscar[7], chekNocturno.Checked);
            description.Show();
        }

        private void picRes9_Click(object sender, EventArgs e)
        {
            Description description = new Description(this, userlogin, buscar[8], chekNocturno.Checked);
            description.Show();
        }

        private void picRes10_Click(object sender, EventArgs e)
        {
            Description description = new Description(this, userlogin, buscar[9], chekNocturno.Checked);
            description.Show();
        }

        private void picRes11_Click(object sender, EventArgs e)
        {
            Description description = new Description(this, userlogin, buscar[10], chekNocturno.Checked);
            description.Show();
        }

        private void picRes12_Click(object sender, EventArgs e)
        {
            Description description = new Description(this, userlogin, buscar[11], chekNocturno.Checked);
            description.Show();
        }

        private void picRes13_Click(object sender, EventArgs e)
        {
            Description description = new Description(this, userlogin, buscar[12], chekNocturno.Checked);
            description.Show();
        }

        private void picRes14_Click(object sender, EventArgs e)
        {
            Description description = new Description(this, userlogin, buscar[13], chekNocturno.Checked);
            description.Show();
        }

        private void picRes15_Click(object sender, EventArgs e)
        {
            Description description = new Description(this, userlogin, buscar[14], chekNocturno.Checked);
            description.Show();
        }

        private void LoadMaterias()
        {
            recientes = conn.GetMoviesSeen(userlogin);
            recom = conn.GetMoviesByGenre(conn.GetGenreFav(userlogin));
            best = conn.GetMoviesByRanked();

            if (recientes.Count > 0) Recientes1.BackgroundImage = Image.FromFile($"images/{recientes[0].Image}");
            if (recientes.Count > 1) Recientes2.BackgroundImage = Image.FromFile($"images/{recientes[1].Image}");
            if (recientes.Count > 2) Recientes3.BackgroundImage = Image.FromFile($"images/{recientes[2].Image}");
            if (recientes.Count > 3) Recientes4.BackgroundImage = Image.FromFile($"images/{recientes[3].Image}");
            if (recientes.Count > 4) Recientes5.BackgroundImage = Image.FromFile($"images/{recientes[4].Image}");

            if (recom.Count > 0) Reco1.BackgroundImage = Image.FromFile($"images/{recom[0].Image}");
            if (recom.Count > 1) Reco2.BackgroundImage = Image.FromFile($"images/{recom[1].Image}");
            if (recom.Count > 2) Reco3.BackgroundImage = Image.FromFile($"images/{recom[2].Image}");
            if (recom.Count > 3) Reco4.BackgroundImage = Image.FromFile($"images/{recom[3].Image}");
            if (recom.Count > 4) Reco5.BackgroundImage = Image.FromFile($"images/{recom[4].Image}");

            if (best.Count > 0) Best1.BackgroundImage = Image.FromFile($"images/{best[0].Image}");
            if (best.Count > 1) Best2.BackgroundImage = Image.FromFile($"images/{best[1].Image}");
            if (best.Count > 2) Best3.BackgroundImage = Image.FromFile($"images/{best[2].Image}");
            if (best.Count > 3) Best4.BackgroundImage = Image.FromFile($"images/{best[3].Image}");
            if (best.Count > 4) Best5.BackgroundImage = Image.FromFile($"images/{best[4].Image}");
        }

        private void Buscar()
        {
            string aux1 = txtAmin.Text;
            string aux2 = txtCalmin.Text;
            string aux3 = txtCalmax.Text;

            if (aux1 == "") aux1 = $"{0}";
            if (aux2 == "") aux2 = $"{0}";
            if (aux3 == "") aux3 = $"{5}";

            if (Convert.ToInt32(aux1) < 0)
            {
                MessageBox.Show("Ingresa un año mayor a cero!");
            }
            else if (Convert.ToInt32(aux2) < 0 || Convert.ToInt32(aux3) > 5)
            {
                MessageBox.Show("El rango de valores es de 0 a 5");
            }
            else
            {
                panel2.Show();
                buscar = new List<Movie>();
                buscar = conn.SearchMovies(userlogin.membership.Id, txtBuscar.Text, cmbGenero.SelectedItem as string, txtAmin.Text, txtAmax.Text, txtCalmin.Text, txtCalmax.Text);
                List<Movie> aux = new List<Movie>(buscar);
                if (buscar.Count <= 15) panel2.AutoScroll = false;
                else panel2.AutoScroll = true;

                if (txtCalmin.Text != "") buscar = aux.FindAll(m => m.ScoreTotal >= Convert.ToInt32(txtCalmin.Text));
                aux = buscar;
                if (txtCalmax.Text != "") buscar = aux.FindAll(m => m.ScoreTotal <= Convert.ToInt32(txtCalmax.Text));



                picRes1.BackgroundImage = null;
                picRes2.BackgroundImage = null;
                picRes3.BackgroundImage = null;
                picRes4.BackgroundImage = null;
                picRes5.BackgroundImage = null;
                picRes6.BackgroundImage = null;
                picRes7.BackgroundImage = null;
                picRes8.BackgroundImage = null;
                picRes9.BackgroundImage = null;
                picRes10.BackgroundImage = null;
                picRes11.BackgroundImage = null;
                picRes12.BackgroundImage = null;
                picRes13.BackgroundImage = null;
                picRes14.BackgroundImage = null;
                picRes15.BackgroundImage = null;
                picRes16.BackgroundImage = null;
                picRes17.BackgroundImage = null;
                picRes18.BackgroundImage = null;
                picRes19.BackgroundImage = null;
                picRes20.BackgroundImage = null;
                picRes21.BackgroundImage = null;
                picRes22.BackgroundImage = null;
                picRes23.BackgroundImage = null;
                picRes24.BackgroundImage = null;
                picRes25.BackgroundImage = null;
                picRes26.BackgroundImage = null;
                picRes27.BackgroundImage = null;
                picRes28.BackgroundImage = null;
                picRes29.BackgroundImage = null;
                picRes30.BackgroundImage = null;
                picRes31.BackgroundImage = null;
                picRes32.BackgroundImage = null;
                picRes33.BackgroundImage = null;
                picRes34.BackgroundImage = null;
                picRes35.BackgroundImage = null;
                picRes36.BackgroundImage = null;
                picRes37.BackgroundImage = null;
                picRes38.BackgroundImage = null;
                picRes39.BackgroundImage = null;
                picRes40.BackgroundImage = null;

                if (buscar.Count > 0) picRes1.BackgroundImage = Image.FromFile($"images/{buscar[0].Image}");
                if (buscar.Count > 1) picRes2.BackgroundImage = Image.FromFile($"images/{buscar[1].Image}");
                if (buscar.Count > 2) picRes3.BackgroundImage = Image.FromFile($"images/{buscar[2].Image}");
                if (buscar.Count > 3) picRes4.BackgroundImage = Image.FromFile($"images/{buscar[3].Image}");
                if (buscar.Count > 4) picRes5.BackgroundImage = Image.FromFile($"images/{buscar[4].Image}");
                if (buscar.Count > 5) picRes6.BackgroundImage = Image.FromFile($"images/{buscar[5].Image}");
                if (buscar.Count > 6) picRes7.BackgroundImage = Image.FromFile($"images/{buscar[6].Image}");
                if (buscar.Count > 7) picRes8.BackgroundImage = Image.FromFile($"images/{buscar[7].Image}");
                if (buscar.Count > 8) picRes9.BackgroundImage = Image.FromFile($"images/{buscar[8].Image}");
                if (buscar.Count > 9) picRes10.BackgroundImage = Image.FromFile($"images/{buscar[9].Image}");
                if (buscar.Count > 10) picRes11.BackgroundImage = Image.FromFile($"images/{buscar[10].Image}");
                if (buscar.Count > 11) picRes12.BackgroundImage = Image.FromFile($"images/{buscar[11].Image}");
                if (buscar.Count > 12) picRes13.BackgroundImage = Image.FromFile($"images/{buscar[12].Image}");
                if (buscar.Count > 13) picRes14.BackgroundImage = Image.FromFile($"images/{buscar[13].Image}");
                if (buscar.Count > 14) picRes15.BackgroundImage = Image.FromFile($"images/{buscar[14].Image}");
                if (buscar.Count > 15) picRes16.BackgroundImage = Image.FromFile($"images/{buscar[15].Image}");
                if (buscar.Count > 16) picRes17.BackgroundImage = Image.FromFile($"images/{buscar[16].Image}");
                if (buscar.Count > 17) picRes18.BackgroundImage = Image.FromFile($"images/{buscar[17].Image}");
                if (buscar.Count > 18) picRes19.BackgroundImage = Image.FromFile($"images/{buscar[18].Image}");
                if (buscar.Count > 19) picRes20.BackgroundImage = Image.FromFile($"images/{buscar[19].Image}");
                if (buscar.Count > 20) picRes21.BackgroundImage = Image.FromFile($"images/{buscar[20].Image}");
                if (buscar.Count > 21) picRes22.BackgroundImage = Image.FromFile($"images/{buscar[21].Image}");
                if (buscar.Count > 22) picRes23.BackgroundImage = Image.FromFile($"images/{buscar[22].Image}");
                if (buscar.Count > 23) picRes24.BackgroundImage = Image.FromFile($"images/{buscar[23].Image}");
                if (buscar.Count > 24) picRes25.BackgroundImage = Image.FromFile($"images/{buscar[24].Image}");
                if (buscar.Count > 25) picRes26.BackgroundImage = Image.FromFile($"images/{buscar[25].Image}");
                if (buscar.Count > 26) picRes27.BackgroundImage = Image.FromFile($"images/{buscar[26].Image}");
                if (buscar.Count > 27) picRes28.BackgroundImage = Image.FromFile($"images/{buscar[27].Image}");
                if (buscar.Count > 28) picRes29.BackgroundImage = Image.FromFile($"images/{buscar[28].Image}");
                if (buscar.Count > 29) picRes30.BackgroundImage = Image.FromFile($"images/{buscar[29].Image}");
                if (buscar.Count > 30) picRes31.BackgroundImage = Image.FromFile($"images/{buscar[30].Image}");
                if (buscar.Count > 31) picRes32.BackgroundImage = Image.FromFile($"images/{buscar[31].Image}");
                if (buscar.Count > 32) picRes33.BackgroundImage = Image.FromFile($"images/{buscar[32].Image}");
                if (buscar.Count > 33) picRes34.BackgroundImage = Image.FromFile($"images/{buscar[33].Image}");
                if (buscar.Count > 34) picRes35.BackgroundImage = Image.FromFile($"images/{buscar[34].Image}");
                if (buscar.Count > 35) picRes36.BackgroundImage = Image.FromFile($"images/{buscar[35].Image}");
                if (buscar.Count > 36) picRes37.BackgroundImage = Image.FromFile($"images/{buscar[36].Image}");
                if (buscar.Count > 37) picRes38.BackgroundImage = Image.FromFile($"images/{buscar[37].Image}");
                if (buscar.Count > 38) picRes39.BackgroundImage = Image.FromFile($"images/{buscar[38].Image}");
                if (buscar.Count > 39) picRes40.BackgroundImage = Image.FromFile($"images/{buscar[39].Image}");
                if (buscar.Count > 40) picRes41.BackgroundImage = Image.FromFile($"images/{buscar[40].Image}");
                if (buscar.Count > 41) picRes42.BackgroundImage = Image.FromFile($"images/{buscar[41].Image}");
                if (buscar.Count > 42) picRes43.BackgroundImage = Image.FromFile($"images/{buscar[42].Image}");
                if (buscar.Count > 43) picRes44.BackgroundImage = Image.FromFile($"images/{buscar[43].Image}");
                if (buscar.Count > 44) picRes45.BackgroundImage = Image.FromFile($"images/{buscar[44].Image}");
                if (buscar.Count > 45) picRes46.BackgroundImage = Image.FromFile($"images/{buscar[45].Image}");
                if (buscar.Count > 46) picRes47.BackgroundImage = Image.FromFile($"images/{buscar[46].Image}");
                if (buscar.Count > 47) picRes48.BackgroundImage = Image.FromFile($"images/{buscar[47].Image}");
                if (buscar.Count > 48) picRes49.BackgroundImage = Image.FromFile($"images/{buscar[48].Image}");
                if (buscar.Count > 49) picRes50.BackgroundImage = Image.FromFile($"images/{buscar[49].Image}");
            }
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Buscar();
            }
        }
    }
}