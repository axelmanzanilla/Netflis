using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neflis
{
    public partial class Cerrar_Sesión : Form
    {
        public Cerrar_Sesión()
        {
            InitializeComponent();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btnRechazar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
