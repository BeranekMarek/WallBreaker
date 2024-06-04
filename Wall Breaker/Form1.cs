using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wall_Breaker
{
    public partial class Form1 : Form
    {
        // bitmapa do které kreslím
        Bitmap mobjMyBitmap;
        Graphics mobjPlatnoBackround;

        // grafika na okně z pictureboxu
        Graphics mobjPlatnoForm;

        // kulička
        clsKulicka mobjKulicka;

        // vozíček
        clsVozicek mobjVozicek;

        // Cihly
        clsCihla[] mobjCihly;
        const int mintPocetCihel = 40;
        const int mintPrvniCihlyX = 10, mintPrvniCihlyY = 10, mintPrvniCihlyMezera = 5;
        const int mintSirkaCihly = 50, mintVyskaCihly = 20;

        public Form1()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            this.KeyPreview = true; // Přidáno pro zachytávání kláves ve formuláři
        }

        //----------------------------------------------------------------------------
        // nahrání formu do paměti
        //----------------------------------------------------------------------------
        private void Form1_Load(object sender, EventArgs e)
        {
            int lintCihlaX, lintCihlaY;

            // vytvoření grafiky z pictureboxu
            mobjPlatnoForm = pbPlatno.CreateGraphics();

            // vytvoření bitmapy
            mobjMyBitmap = new Bitmap(pbPlatno.Width, pbPlatno.Height);
            mobjPlatnoBackround = Graphics.FromImage(mobjMyBitmap);

            // vytvoření kuličky
            mobjKulicka = new clsKulicka(50, 150, 2, 10, mobjPlatnoBackround);
            mobjKulicka.StetecKulicky = Brushes.Red;

            // vytvoření cihel
            mobjCihly = new clsCihla[mintPocetCihel]; // Vytvoření pole (array)

            // vytvoření vozíčku
            mobjVozicek = new clsVozicek(100, pbPlatno.Height - 30, 100, 20, mobjPlatnoBackround); // Upravte souřadnice a rozměry vozíčku podle potřeby

            // vytvoření jednotlivých cihel
            lintCihlaX = mintPrvniCihlyX;
            lintCihlaY = mintPrvniCihlyY;

            for (int i = 0; i < mintPocetCihel; i++)
            {
                // vytvoření cihly
                mobjCihly[i] = new clsCihla(lintCihlaX, lintCihlaY, mintSirkaCihly, mintVyskaCihly, mobjPlatnoBackround);

                // posun po ose X
                lintCihlaX = lintCihlaX + mintSirkaCihly + mintPrvniCihlyMezera;

                // test na další řadu
                if ((lintCihlaX + mintSirkaCihly + mintPrvniCihlyMezera) > pbPlatno.Width)
                {
                    lintCihlaX = mintPrvniCihlyX;
                    lintCihlaY = lintCihlaY + mintVyskaCihly + mintPrvniCihlyMezera;
                }
            }

            // nastavení timeru překreslení
            tmrRedraw.Interval = 5;
            tmrRedraw.Enabled = true;
        }

        //----------------------------------------------------------------------------
        // překreslení obrazu
        //----------------------------------------------------------------------------
        private void tmrRedraw_Tick(object sender, EventArgs e)
        {
            // vymazat plátno - pohyb
            mobjPlatnoBackround.Clear(Color.White);

            // nakreslit kuličku
            mobjKulicka.VykresliSe();

                // vykreslit cihly
                for (int i = 0; i < mintPocetCihel; i++)
            {
                // test kolize s kuličkou
                if (true == TestKolizeCihlaKulicka(mobjKulicka.rectObrys, mobjCihly[i].rectObrys))
                {
                    // cihla není vidět
                    mobjCihly[i].blVisible = false;

                    // změna pohybu kuličky
                    mobjKulicka.ZmenPohybY();
                }

                // vykreslení cihly
                mobjCihly[i].Vykreslit();
            }

            // test kolize vozíčku s kuličkou
            if (TestKolizeVozicekKulicka(mobjKulicka.rectObrys, new Rectangle(mobjVozicek.X, mobjVozicek.Y, mobjVozicek.Sirka, mobjVozicek.Vyska)))
            {
                mobjKulicka.ZmenPohybY();
            }

            // vykreslit vozíček
            mobjVozicek.Zobraz();

            // posun kuličky
            mobjKulicka.PosunSe();

            // vykreslení na pbPlatno
            mobjPlatnoForm.DrawImage(mobjMyBitmap, 0, 0);
        }

        //----------------------------------------------------------------------------
        // test kolize cihly a kuličky
        //----------------------------------------------------------------------------
        private bool TestKolizeCihlaKulicka(Rectangle objRectKulicka, Rectangle objRectCihla)
        {
            Rectangle lobjPrekryv;
            lobjPrekryv = Rectangle.Intersect(objRectKulicka, objRectCihla);

            // test zda existuje překrytý obdélník
            if (lobjPrekryv.Width == 0 && lobjPrekryv.Height == 0)
                return false;

            // objekty se překrývají
            return true;
        }

        //----------------------------------------------------------------------------
        // test kolize vozíčku a kuličky
        //----------------------------------------------------------------------------
        private bool TestKolizeVozicekKulicka(Rectangle objRectKulicka, Rectangle objRectVozicek)
        {
            Rectangle lobjPrekryv;
            lobjPrekryv = Rectangle.Intersect(objRectKulicka, objRectVozicek);

            // test zda existuje překrytý obdélník
            if (lobjPrekryv.Width == 0 && lobjPrekryv.Height == 0)
                return false;

            // objekty se překrývají
            return true;
        }

        //----------------------------------------------------------------------------
        // zpracování událostí kláves
        //----------------------------------------------------------------------------
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            const int krok = 5; // krok pohybu vozíčku

            if (e.KeyCode == Keys.Left)
            {
                if (mobjVozicek.X - krok >= 0)
                {
                    mobjVozicek.X -= krok;
                    tmrRedraw_Tick(sender, e); // Překreslit form
                }
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (mobjVozicek.X + mobjVozicek.Sirka + krok <= pbPlatno.Width)
                {
                    mobjVozicek.X += krok;
                    tmrRedraw_Tick(sender, e); // Překreslit form
                }
            }
        }
    }


}
