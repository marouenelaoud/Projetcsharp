using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;

namespace Gestionresto
{
    public partial class Fprod : Form
    {
        ClasseCat con;
        public Fprod()
        {
            InitializeComponent();
            con = new ClasseCat();
            ListerArtciles();
            RemplirCategories();

        }
        private void ListerArtciles()
        {
            string req = "Select * from ArticlesTbl";
            ArticlesListe.DataSource = con.Recupdonne(req);

        }

        private void Fprod_Load(object sender, EventArgs e)
        {

        }
        int key = 0;
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NomTb.Text = ArticlesListe.SelectedRows[0].Cells[1].Value.ToString();
            PrixTb.Text = ArticlesListe.SelectedRows[0].Cells[2].Value.ToString();
            CatCb.Text = ArticlesListe.SelectedRows[0].Cells[3].Value.ToString();
            qtTb.Text = ArticlesListe.SelectedRows[0].Cells[4].Value.ToString();
            if (NomTb.Text == "")
            {
                key = 0;

            }
            else
            {
                key = Convert.ToInt32(ArticlesListe.SelectedRows[0].Cells[0].Value.ToString());

            }

        }
        private void RemplirCategories()
        {
            string req = "select *from CategorieTbl";
            CatCb.DisplayMember = con.Recupdonne(req).Columns["CatNom"].ToString();
            CatCb.ValueMember = con.Recupdonne(req).Columns["CatCode"].ToString();
            CatCb.DataSource = con.Recupdonne(req);
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (NomTb.Text == "" || PrixTb.Text == "" || CatCb.SelectedIndex == -1 || qtTb.Text == "")
                {
                    MessageBox.Show("Completer le formulaire svp !");
                }
                else
                {
                    string Nom = NomTb.Text;
                    int Prix = Convert.ToInt32(PrixTb.Text);
                    int Categorie = Convert.ToInt32(CatCb.SelectedValue.ToString());
                    int Stock = Convert.ToInt32(qtTb.Text);
                    string ExpDate = datt.Value.Date.ToString();
                    string req = "insert into ArticlesTbl  values('{0}',{1},{2},{3},'{4}')";
                    req = string.Format(req, Nom, Prix, Categorie, Stock, ExpDate);
                    con.envoidonne(req);
                    ListerArtciles();
                    MessageBox.Show("Article Ajouté !!");
                    NomTb.Text = "";
                    PrixTb.Text = "";
                    qtTb.Text = "";
                    CatCb.SelectedIndex = -1;

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (key == 0)
                {
                    MessageBox.Show("selectionnez un article svp !");
            }
                else
                {
                    string Nom = NomTb.Text.ToString();
                    int Prix = Convert.ToInt32(PrixTb.Text);
                    int Categorie = Convert.ToInt32(CatCb.SelectedItem.ToString());
                    int Stock = Convert.ToInt32(qtTb.Text);
                    string ExpDate = datt.Value.Date.ToString();
                    string req = "delete from ArticlesTbl  where ArtCode ={0}";
                    req = string.Format(req, key);
                    con.envoidonne(req);
                    ListerArtciles();
                    MessageBox.Show("Article Supprimé !!");
                    NomTb.Text = "";
                    PrixTb.Text = "";
                    qtTb.Text = "";
                    CatCb.SelectedIndex = -1;

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (NomTb.Text == "" || PrixTb.Text == "")
                {
                    MessageBox.Show("Completer le formulaire svp !");
                }
                else
                {
                    string Nom = NomTb.Text;
                    int Prix = Convert.ToInt32(PrixTb.Text);
                    int Categorie = Convert.ToInt32(CatCb.SelectedValue.ToString());
                    int Stock = Convert.ToInt32(qtTb.Text);
                    string ExpDate = datt.Value.Date.ToString();
                    string req = "Update  ArticlesTbl  set ArtNom='{0},ArtPrix={1},ArtCat='{2}',ArtStock={3},ArtExpDate='{4}' where ArtCode={5}";
                    req = string.Format(req, Nom, Prix, Categorie, Stock, ExpDate, key);
                    con.envoidonne(req);
                    ListerArtciles();
                    MessageBox.Show("Categorie Modifiée !!");
                    NomTb.Text = "";
                    PrixTb.Text = "";
                    qtTb.Text = "";
                    CatCb.SelectedIndex = -1;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            InitializeComponent();
            NomTb.Clear();
            PrixTb.Clear();
            qtTb.Clear();


        }
    }
}
