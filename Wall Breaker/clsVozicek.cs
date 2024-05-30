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

        // Souřadnice vozicku
        int mintVozicekX, mintVozicekY;
        int mintVozicekSirka, mintVozicekVyska;
        Brush mobjBrush;

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



    }
}
