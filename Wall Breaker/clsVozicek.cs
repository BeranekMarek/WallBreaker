using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall_Breaker
{
    internal class clsVozicek
    {
        // Plátno
        Graphics mobjPlatno;

        // Souřadnice vozíčku
        int mintVozicekX, mintVozicekY;
        int mintVozicekSirka, mintVozicekVyska;
        Brush mobjBrush;

        // Je vozíček vidět?
        bool mblIsVisible;

        //-----------------------------------------
        // Konstruktor
        //-----------------------------------------
        public clsVozicek(int intVozicekX, int intVozicekY, int intVozicekSirka, int intVozicekVyska, Graphics objPlatno)
        {
            mintVozicekX = intVozicekX;
            mintVozicekY = intVozicekY;
            mintVozicekSirka = intVozicekSirka;
            mintVozicekVyska = intVozicekVyska;
            mobjBrush = Brushes.Black;
            mblIsVisible = true;
            mobjPlatno = objPlatno;
        }

        //-----------------------------------------
        // Metoda pro zobrazení vozíčku
        //-----------------------------------------
        public void Zobraz()
        {
            if (mblIsVisible)
            {
                mobjPlatno.FillRectangle(mobjBrush, mintVozicekX, mintVozicekY, mintVozicekSirka, mintVozicekVyska);
            }
        }

        //-----------------------------------------
        // Metoda pro nastavení viditelnosti
        //-----------------------------------------
        public void NastavViditelnost(bool viditelnost)
        {
            mblIsVisible = viditelnost;
        }

        //-----------------------------------------
        // Vlastnosti pro přístup k souřadnicím a rozměrům vozíčku
        //-----------------------------------------
        public int X
        {
            get { return mintVozicekX; }
            set { mintVozicekX = value; }
        }

        public int Y
        {
            get { return mintVozicekY; }
            set { mintVozicekY = value; }
        }

        public int Sirka
        {
            get { return mintVozicekSirka; }
            set { mintVozicekSirka = value; }
        }

        public int Vyska
        {
            get { return mintVozicekVyska; }
            set { mintVozicekVyska = value; }
        }
    }
}

