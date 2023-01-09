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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        public void AddControls(Form f)
        {
            centerpanel.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel=false;
            centerpanel.Controls.Add(f);
            f.Show();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void Home_Click(object sender, EventArgs e)
        {
            AddControls(new Fhome());
        }

        private void Products_Click(object sender, EventArgs e)
        {
            AddControls(new Fprod());

        }

        private void Categories_Click(object sender, EventArgs e)
        {
            AddControls(new Fcat());
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void centerpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Bill_Click(object sender, EventArgs e)
        {
            AddControls(new Ffac());
        }
    }
}
