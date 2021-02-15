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
    public partial class Inicio : Form
    {
        SQLiteConn conn = new SQLiteConn("neflisdata.db", true);

        public Inicio()
        {
            InitializeComponent();
            pctCover.Image = Image.FromFile("images/cover.jpg");
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            User user = new User(0, "", "", "", "", "", "", "", null);
            bool pass = false;

            if (txtUsuario.Text != "" && txtPass.Text != "") //Comprobar que no esté vacio
            {
                if (conn.GetUsers().Exists(u => u.Username == txtUsuario.Text))
                {//Comprobar si el usuario existe
                    user = conn.GetUsers().Find(u => u.Username == txtUsuario.Text);
                    if (user.Password == txtPass.Text) pass = true;
                    else MessageBox.Show("Contraseña incorrecta!");
                }
                else if (conn.GetUsers().Exists(u => u.Email == txtUsuario.Text))
                {//Comprobar si el correo existe
                    user = conn.GetUsers().Find(u => u.Email == txtUsuario.Text);
                    if (user.Password == txtPass.Text) pass = true;
                    else MessageBox.Show("Contraseña incorrecta!");
                }
                else MessageBox.Show("El usuario ingresado no existe!");
            }
            else MessageBox.Show("Ingrese todos los datos!");
            
            if (pass)
            {
                Principal principal = new Principal(conn, this, user);
                this.Hide();
                principal.Show();
            }
        }

        //private void btnRegistrar_Click(object sender, EventArgs e)
        //{
        //    Registro registro = new Registro();
        //    registro.Show();
        //}

        private void Registrar_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro();
            registro.Show();
        }

        private void Registrar_MouseLeave(object sender, EventArgs e)
        {
            Registrar.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular);
        }

        private void Registrar_MouseMove(object sender, MouseEventArgs e)
        {
            Registrar.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Underline);
        }

        private void txtPass_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                User user = new User(0, "", "", "", "", "", "", "", null);
                bool pass = false;

                if (txtUsuario.Text != "" && txtPass.Text != "") //Comprobar que no esté vacio
                {
                    if (conn.GetUsers().Exists(u => u.Username == txtUsuario.Text))
                    {//Comprobar si el usuario existe
                        user = conn.GetUsers().Find(u => u.Username == txtUsuario.Text);
                        if (user.Password == txtPass.Text) pass = true;
                        else MessageBox.Show("Contraseña incorrecta!");
                    }
                    else if (conn.GetUsers().Exists(u => u.Email == txtUsuario.Text))
                    {//Comprobar si el correo existe
                        user = conn.GetUsers().Find(u => u.Email == txtUsuario.Text);
                        if (user.Password == txtPass.Text) pass = true;
                        else MessageBox.Show("Contraseña incorrecta!");
                    }
                    else MessageBox.Show("El usuario ingresado no existe!");
                }
                else MessageBox.Show("Ingrese todos los datos!");

                if (pass)
                {
                    Principal principal = new Principal(conn, this, user);
                    this.Hide();
                    principal.Show();
                }
            }
        }
    }
}