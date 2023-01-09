using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;

namespace Gestionresto
{
    public partial class Fcat : Form
    {
        ClasseCat cn;
        public Fcat()
        {
            InitializeComponent();
            cn = new ClasseCat();
            ListerCatogories();

        }
        private void ListerCatogories()
        {
            string req = "Select * from CategorieTbl";
            CategoriesListe.DataSource = cn.Recupdonne(req);

        }


        private void Fcat_Load(object sender, EventArgs e)
        {

        }

        private void ajouter_Click(object sender, EventArgs e)
        {
            try
                {
                if (NomTb.Text == "" || RemTb.Text == "")
                {
                    MessageBox.Show("Completer le formulaire svp !");
                 }
                else
                {
                    string Nom = NomTb.Text;
                    string Rem = RemTb.Text;
                    string req = "insert into CategorieTbl values('{0}','{1}')";
                    req = string.Format(req, Nom, Rem);
                    cn.envoidonne(req);
                    ListerCatogories();
                    MessageBox.Show("Categorie Ajoutée !!");
                    NomTb.Text = "";
                    RemTb.Text = "";
                }
            }
                  catch (Exception Ex)
                {
                MessageBox.Show(Ex.Message);
                }
        }
        int key = 0;

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NomTb.Text = CategoriesListe.SelectedRows[0].Cells[1].Value.ToString();
            RemTb.Text = CategoriesListe.SelectedRows[0].Cells[2].Value.ToString();
            if (NomTb.Text == "")
            {
                key = 0;

            }
            else
            {
                key = Convert.ToInt32(CategoriesListe.SelectedRows[0].Cells[0].Value.ToString());
            }


        }

        private void modifier_Click(object sender, EventArgs e)
        {
            try
            {
                if (NomTb.Text == "" || RemTb.Text == "")
                {
                    MessageBox.Show("Completer le formulaire svp !");
            }
                else
                {
                    string Nom = NomTb.Text;
                    string Rem = RemTb.Text;
                    string req = "update CategorieTbl set CatNom='{0}',CatDes='{1}' where CatCode={2}";
                    req = string.Format(req, Nom, Rem, key);
                    cn.envoidonne(req);
                    ListerCatogories();
                    MessageBox.Show("Categorie Modifiée !!");
                    NomTb.Text = "";
                    RemTb.Text = "";
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }

        private void supprimer_Click(object sender, EventArgs e)
        {
            try
            {
                if (NomTb.Text == "" || RemTb.Text == "")
                {
                    MessageBox.Show("Completer le formulaire svp !");
            }
                else
                {
                    string Nom = NomTb.Text;
                    string Rem = RemTb.Text;
                    string req = "delete from CategorieTbl where CatCode={0}";
                    req = string.Format(req, key);
                    cn.envoidonne(req);
                    ListerCatogories();
                    MessageBox.Show("Categorie Supprimée !!");
                    NomTb.Text = "";
                    RemTb.Text = "";
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
    }
}
