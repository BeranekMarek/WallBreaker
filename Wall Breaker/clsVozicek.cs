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

        // integery pro pouziti venku
        public int pintVozicekX, pintVozicekY, pintVozicekSirka;

        // Souřadnice vozíčku
        int mintVozicekX, mintVozicekY;
        int mintVozicekSirka, mintVozicekVyska;
        Brush mobjBrush;

        // Je vozíček vidět?
        bool mblIsVisible;

        // posun plosiny
        int mintVozicekPosun;

        //-----------------------------------------
        // Konstruktor
        //-----------------------------------------
        public clsVozicek(int intVozicekX, int intVozicekY, int intVozicekSirka, int intVozicekVyska, int intVozicekPosun, Graphics objPlatno)
        {
            pintVozicekX = mintVozicekX = intVozicekX;
            pintVozicekY = mintVozicekY = intVozicekY;
            pintVozicekSirka = mintVozicekSirka = intVozicekSirka;
            mintVozicekVyska = intVozicekVyska;
            mintVozicekPosun = intVozicekPosun;
            mobjPlatno = objPlatno;
            mobjBrush = new SolidBrush(Color.Black);

            mblIsVisible = true;
        }

        // posune souradnice plosiny
        public void PosunVozicek()
        {
            mintVozicekX = mintVozicekX + mintVozicekPosun;
            pintVozicekX = mintVozicekX;
        }

        //-----------------------------------------
        // Metoda pro zobrazení vozíčku
        //-----------------------------------------
        public void VykresliSe()
        {
            if (mblIsVisible)
            {
                mobjPlatno.FillRectangle(mobjBrush, mintVozicekX, mintVozicekY, mintVozicekSirka, mintVozicekVyska);
            }
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

        // ovladani plosiny
        public void PosunRight()
        {
            if (mintVozicekPosun < 0)
            {
                mintVozicekPosun = mintVozicekPosun * (-1);
            }
        }
        public void PosunLeft()
        {
            if (mintVozicekPosun > 0)
            {
                mintVozicekPosun = mintVozicekPosun * (-1);
            }
        }
    }
}

