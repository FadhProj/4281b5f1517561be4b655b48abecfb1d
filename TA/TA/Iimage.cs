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
        public struct Pos
        {
            int m;
            int n;

            public Pos(int m, int n)
            {
                this.m = m;
                this.n = n;
            }

            public int M { get => m; set => m = value; }
            public int N { get => n; set => n = value; }
        }
        
        private Bitmap img;
        private int blok;
        private Pos[] defBlok;

        public Bitmap Img { get => img; }
        public int Blok { get => blok; }
        internal Pos[] DefBlok { get => defBlok; }

        public Iimage(Bitmap img)
        {
            this.img = img;
            blok = ((this.img.Height * this.img.Width) / 9);
            defBlok = new Pos[blok];
            setDefBlok(img);
        }


        public void setDefBlok(Bitmap img)
        {
            //blok = 0;
            for (int i = 0; i < img.Height; i+=3)
            {
                for (int j = 0; j < img.Width; j+=3)
                {
                    defBlok[blok] = new Pos(j, i);
                   // blok++;
                }
            }
        }


    }
}
