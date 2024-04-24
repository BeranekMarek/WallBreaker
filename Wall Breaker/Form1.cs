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

        // random button
        public Form1()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------------
        // nahrani formu do pameti
        //----------------------------------------------------------------------------
        private void Form1_Load(object sender, EventArgs e)
        {
            // vytvoreni grafiky z pisctureboxu
            mobjPlatnoForm = pbPlatno.CreateGraphics();

            // vytvorenji bitmapy
            mobjMyBitmap = new Bitmap(pbPlatno.Width,pbPlatno.Height);
            mobjPlatnoBackround = Graphics.FromImage(mobjMyBitmap);

            // vytvorit kulicku
            mobjKulicka = new clsKulicka(50, 50, 2, 10);

            // nastaveni timeru prekresleni
            tmrRedraw.Interval = 10;
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

            // posun kulicky
            mobjKulicka.PosunSe();
            
            // vykesleni na pbPlatno
            mobjPlatnoForm.DrawImage(mobjMyBitmap, 0, 0);

        }
    }
}
