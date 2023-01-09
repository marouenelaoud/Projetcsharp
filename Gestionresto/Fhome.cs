using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestionresto
{
    public partial class Fhome : Form
    {
        public Fhome()
        {
            InitializeComponent();
        }

        private void save_Click(object sender, EventArgs e)
        {
            FormMain fprod = new FormMain();
            fprod.Show();
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
