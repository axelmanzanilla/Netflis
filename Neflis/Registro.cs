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
    public partial class Registro : Form
    {
        SQLiteConn conn = new SQLiteConn("neflisdata.db", true);

        public Registro()
        {
            InitializeComponent();
            disp.Hide();
            pass.Hide();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //Asignar tipo de membresia
            int Membresia = 0;
            if (btnPremium.Checked) Membresia = 1;

            DateTime deadline = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);
            
            if (txtUsuario.Text == "" ||
                txtNombre.Text == "" ||
                txtApellido.Text == "" ||
                txtCorreo.Text == "" ||
                txtPass.Text == "") MessageBox.Show("Datos incompletos!");
            else if (conn.GetUsers().Exists(u => u.Username == txtUsuario.Text))
                MessageBox.Show("Ingrese un usuario diferente!");
            else if (txtPass.Text != txtRePass.Text)
                MessageBox.Show("Las contraseñas no coinciden!");
            else
            {
                conn.ExecuteNonQuery($"INSERT INTO memberships (id, username, fname, lname, birthday, password," +
                $"email, deadline, membershiptype_id) VALUES ({conn.GetUsers().Count}," +
                                                        $"'{txtUsuario.Text}'," +
                                                        $"'{txtNombre.Text}'," +
                                                        $"'{txtApellido.Text}'," +
                                                        $"'{conn.GetDate(birthDate.Value)}'," +
                                                        $"'{txtPass.Text}'," +
                                                        $"'{txtCorreo.Text}'," +
                                                        $"'{conn.GetDate(deadline)}'," +
                                                        $"{Membresia});");
                MessageBox.Show("Usuario registrado con Éxito!");
                this.Close();
            }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            if (conn.GetUsers().Exists(u => u.Username == txtUsuario.Text) || txtUsuario.Text == "")
            {
                disp.Show();
                disp.ForeColor = Color.Red;
                disp.Text = "Usuario no disponible";
            }
            else
            {
                disp.Show();
                disp.ForeColor = Color.Green;
                disp.Text = "Usuario disponible";
            }
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            if (txtPass.Text != txtRePass.Text) pass.Show();
            else pass.Hide();
        }

        private void txtRePass_TextChanged(object sender, EventArgs e)
        {
            if (txtPass.Text != txtRePass.Text) pass.Show();
            else pass.Hide();
        }
    }
}
