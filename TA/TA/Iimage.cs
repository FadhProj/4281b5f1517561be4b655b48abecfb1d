using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TA
{
    class Iimage
    {
        private struct Pos
        {
            int m;
            int n;

            public Pos(int m, int n)
            {
                this.m = m;
                this.n = n;
            }
        }
        private Bitmap img;
        private int blok;
        private Pos[] defBlok;

        public Bitmap Img { get => img; }
        public int Blok { get => blok; }
        private Pos[] DefBlok { get => defBlok; }

        public Iimage(Bitmap img)
        {
            this.img = img;
            setDefBlok(img);
        }


        public void setDefBlok(Bitmap img)
        {
            blok = 0;
            for (int i = 0; i < img.Height; i+=3)
            {
                for (int j = 0; j < img.Width; j+=3)
                {
                    defBlok[blok] = new Pos(j, i);
                    blok++;
                }
            }
        }


    }
}
