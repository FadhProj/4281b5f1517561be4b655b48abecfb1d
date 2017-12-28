using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;

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
        
        private Bitmap image;
        private int blok;
        private Pos[] defBlok;

        public Bitmap Image { get => image; }
        public int Blok { get => blok; }
        internal Pos[] DefBlok { get => defBlok; }

        public Iimage(Bitmap image)
        {            
            this.image = image;
            addPadding();
            blok = ((this.image.Height * this.image.Width) / 9);
            defBlok = new Pos[blok];
            setDefBlok(this.image);
           
            
        }


        public void setDefBlok(Bitmap image)
        {
            int b = 0;
            for (int i = 0; i < image.Height; i += 3)
            {
                for (int j = 0; j < image.Width; j += 3)
                {
                    defBlok[b] = new Pos(j, i);
                    b++;
                }
            }

        }

        public void addPadding()
        {
            int x = image.Width , y = image.Height ;
            if (image.Width % 3 != 0 && image.Height % 3 != 0)
            {
                x = image.Width + (3 - (image.Width % 3));
                y = image.Height + (3 - (image.Height % 3));
            }
            else if (image.Width % 3 != 0)
            {
                x = image.Width + (3 - (image.Width % 3));
            }
            else if (image.Height % 3 != 0)
            {
                y = image.Height + (3 - (image.Height % 3));
            }
            Bitmap result = new Bitmap(x, y);
            using (Graphics graph = Graphics.FromImage(result))
            {
                Rectangle ImageSize = new Rectangle(0, 0, x, y);
                graph.FillRectangle(Brushes.Black, ImageSize);
            }
            for (int i = 0; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width; j++)
                {
                    result.SetPixel(j, i, image.GetPixel(j, i));
                }
            }
            this.image = result;
        }


    }
}
