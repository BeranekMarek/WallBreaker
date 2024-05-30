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
        // bitmapa do ktere kreslim
        Bitmap mobjMyBitmap;
        Graphics mobjPlatnoBackround;

        // grafika na okne z pictureboxu
        Graphics mobjPlatnoForm;

        //kulicka
        clsKulicka mobjKulicka;

        //vozicek
        clsVozicek mobjVozicek;

        // random button
        public Form1()
        {
            InitializeComponent();
        }

        // Cihly
        clsCihla[] mobjCihly;
        const int mintPocetCihel = 40;
        const int mintPrvniCihlyX = 10, mintPrvniCihlyY = 10, mintPrvniCihlyMezera = 5;
        const int mintSirkaCihly = 50, mintVyskaCihly = 20;



        //----------------------------------------------------------------------------
        // nahrani formu do pameti
        //----------------------------------------------------------------------------
        private void Form1_Load(object sender, EventArgs e)
        {
            int lintCihlaX, lintCihlaY;

            // vytvoreni grafiky z pisctureboxu
            mobjPlatnoForm = pbPlatno.CreateGraphics();

            // vytvorenji bitmapy
            mobjMyBitmap = new Bitmap(pbPlatno.Width,pbPlatno.Height);
            mobjPlatnoBackround = Graphics.FromImage(mobjMyBitmap);

            // vytvorit kulicku
            mobjKulicka = new clsKulicka(50, 150, 2, 10, mobjPlatnoBackround);
            mobjKulicka.StetecKulicky = Brushes.Red;

            // Vytvoření cihel
            mobjCihly = new clsCihla[mintPocetCihel]; // Vytvoření pole (array)

            // Vytvoření vozicku
            mobjVozicek = new clsVozicek(100, 150, 200, 100);

            // Vytvoření jednotlivých cihel
            lintCihlaX = mintPrvniCihlyX;
            lintCihlaY = mintPrvniCihlyY;

            for (int i = 0; i < mintPocetCihel; i++)
            {
                // Vytvoření cihly
                mobjCihly[i] = new clsCihla(lintCihlaX, lintCihlaY, mintSirkaCihly, mintVyskaCihly, mobjPlatnoBackround);

                // Posun po ose X
                lintCihlaX = lintCihlaX + mintSirkaCihly + mintPrvniCihlyMezera;

                // Test na další řadu
                if ((lintCihlaX + mintSirkaCihly + mintPrvniCihlyMezera) > pbPlatno.Width)
                {
                    lintCihlaX = mintPrvniCihlyX;
                    lintCihlaY = lintCihlaY + mintVyskaCihly + mintPrvniCihlyMezera;
                }
            }

            // nastaveni timeru prekresleni
            tmrRedraw.Interval = 5;
            tmrRedraw.Enabled = true;
        }


        //----------------------------------------------------------------------------
        // prekresleni obrazu
        //----------------------------------------------------------------------------
        private void tmrRedraw_Tick(object sender, EventArgs e)
        {
            //vymazat platno - pohyb
            mobjPlatnoBackround.Clear(Color.White);

            // nakresli kolecko
            mobjKulicka.VykresliSe();

            // Vykreslit cihly
            for (int i = 0; i < mintPocetCihel; i++)
            {
                //test kolize s kulickou
                if (true==TestKolizeCihlaKulicka(mobjKulicka.rectObrys, mobjCihly[i].rectObrys))
                {
                    // cihla neni videt
                    mobjCihly[i].blVisible = false;

                    // zmena pohybu kulicky
                    mobjKulicka.ZmenPohybY();
                
                }

                //vykresleni cihly
                mobjCihly[i].Vykreslit();
            }

            // posun kulicky
            mobjKulicka.PosunSe();
            
            // vykesleni na pbPlatno
            mobjPlatnoForm.DrawImage(mobjMyBitmap, 0, 0);

        }

        //----------------------------------------------------------------------------
        // test kolize cihly a kulicky
        //----------------------------------------------------------------------------
        private bool TestKolizeCihlaKulicka(Rectangle objRectKulicka, Rectangle objRectCihla)
        {
            Rectangle lobjPrekryv;
            lobjPrekryv = Rectangle.Intersect(objRectKulicka, objRectCihla);


            // test zda existuje prekryty obdelnik
            if (lobjPrekryv.Width == 0 && lobjPrekryv.Height == 0) 
                return false;
            
            // objekty se prekryvaji
            return true;
        }
        
        // poznamky po hodine
        // na pboxu je treba zachytit keydown atd
        // :(


    }
}
