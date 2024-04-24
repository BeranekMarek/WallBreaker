using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall_Breaker
{
    internal class clsKulicka
    {
        // kreslici platno
        Graphics mobjPlatno;

        // souradnice kulicky
        int mintKulickaX, mintKulickaY;
        int mintKulickaPosunX, mintKulickaPosunY;
        int mintKulickaPolomer = 10;

        public clsKulicka(int intKulickaX, int intKulickaY,
            int intKulickaPosun, int intKulickaPolomer,
            Graphics objPlatno)
        {
            mintKulickaX = intKulickaX;
            mintKulickaY = intKulickaY;
            mintKulickaPosunX = intKulickaPosun;
            mintKulickaPosunY = intKulickaPosun;
            mintKulickaPolomer = intKulickaPolomer;

            mobjPlatno = objPlatno;
        }

        //----------------------------------------------------------------------------
        // vykresleni
        //----------------------------------------------------------------------------
        public void VykresliSe()
        {
            mobjPlatno.FillEllipse(Brushes.Blue, mintKulickaX, mintKulickaY, 
                mintKulickaPolomer, mintKulickaPolomer);

        }

        //----------------------------------------------------------------------------
        // posun a kolize
        //----------------------------------------------------------------------------
        public void PosunSe()
        {
            mintKulickaX = mintKulickaX + mintKulickaPosunX;
            mintKulickaY = mintKulickaY + mintKulickaPosunY;

            // kolize
            if ((mintKulickaY + mintKulickaPolomer) > mobjPlatno.VisibleClipBounds.Height)
            {
                mintKulickaPosunY = mintKulickaPosunY * (-1);
            }

            if ((mintKulickaX + mintKulickaPolomer) > mobjPlatno.VisibleClipBounds.Width)
            {
                mintKulickaPosunX = mintKulickaPosunX * (-1);
            }

            if (mintKulickaY < 0)
            {
                mintKulickaPosunY = mintKulickaPosunY * (-1);
            }

            if (mintKulickaX < 0)
            {
                mintKulickaPosunX = mintKulickaPosunX * (-1);
            }

        }







    }
}
