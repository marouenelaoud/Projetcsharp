using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestionresto
{
    public partial class Ffac : Form
    {
        ClasseCat cn;
        public Ffac()
        {
            InitializeComponent();
            cn = new ClasseCat();
            RemplirArticles();

        }
     
        private void RemplirArticles()
        {
            string req = "select *from ArticlesTbl";
            artt.DisplayMember = cn.Recupdonne(req).Columns["ArtNom"].ToString();
            artt.ValueMember = cn.Recupdonne(req).Columns["ArtCode"].ToString();
            artt.DataSource = cn.Recupdonne(req);
        }
        private void Listerfacture()
        {
            string req = "Select * from Fac";
            metro.DataSource = cn.Recupdonne(req);

        }

        private void Ffac_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (tab.Text == "" || pr.Text == "" || qt.Text == "")
                {
                    MessageBox.Show("Completer le formulaire svp !");
                }
                else
                {
                    int price = Convert.ToInt32(pr.Text);
                    int artic = Convert.ToInt32(artt.SelectedValue.ToString());
                    int tabl = Convert.ToInt32(tab.Text);
                    int qte = Convert.ToInt32(qt.Text);
                    string req = "insert into Fac values({0},{1},{2},{3})";
                    req = string.Format(req, price, artic, tabl, qte);
                    cn.envoidonne(req);
                    Listerfacture();
                    MessageBox.Show("Commande Ajouté !!");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        int key = 0;
        private void metro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           {
                tab.Text = metro.SelectedRows[0].Cells[1].Value.ToString();
                pr.Text = metro.SelectedRows[0].Cells[2].Value.ToString();
                qt.Text = metro.SelectedRows[0].Cells[3].Value.ToString();
                if (tab.Text == "")
                {
                    key = 0;

                }
               else
               {
                    key = Convert.ToInt32(metro.SelectedRows[0].Cells[0].Value.ToString());

                }

            }
        }

        private void total_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (key == 0)
                {
                    MessageBox.Show("selectionnez un article svp !");
                }
                else
                {
                    int price = Convert.ToInt32(pr.Text);
                    int artic = Convert.ToInt32(artt.SelectedValue.ToString());
                    int tabl = Convert.ToInt32(tab.Text);
                    int qte = Convert.ToInt32(qt.Text);
                    string req = "delete from Fac where tab={0}";
                    req = string.Format(req, key);
                    cn.envoidonne(req);
                    Listerfacture();
                    MessageBox.Show("Commande Supprimé !!");
                   

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 285, 600);
            if (printPreviewDialog1.ShowDialog()== DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {


        }

        
    }
}
