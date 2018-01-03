using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.Runtime.InteropServices;

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
        private int nPadW, nPadH;
        private Color[] valPadW, valPadH;

        public Bitmap Image { get => image; }
        public int Blok { get => blok; }
        internal Pos[] DefBlok { get => defBlok; }
        public int PadW { get => nPadW; set => nPadW = value; }
        public int PadH { get => nPadH; set => nPadH = value; }
        public int NPadW { get => nPadW; set => nPadW = value; }
        public int NPadH { get => nPadH; set => nPadH = value; }
        public Color[] ValPadW { get => valPadW; set => valPadW = value; }
        public Color[] ValPadH { get => valPadH; set => valPadH = value; }

        public Iimage(Bitmap image)
        {            
            this.image = image;
            blok = ((this.image.Height * this.image.Width) / 9);
            defBlok = new Pos[blok];
            //setDefBlok(this.image);
           
            
        }


        public void setDefBlok(Bitmap image)
        {
            Console.WriteLine("{0} {1} ", image.Width, image.Height);

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

        public void addPadding(bool d)
        {
            Console.WriteLine("{0} {1} ", image.Width, image.Height);
            
            int x = image.Width , y = image.Height ;
            if (image.Width % 3 != 0 && image.Height % 3 != 0)
            {
                this.nPadH = 3 - (image.Height % 3);
                this.nPadW = 3 - (image.Width % 3);
                x = image.Width + nPadW;
                y = image.Height + nPadH;
            }
            else if (image.Width % 3 != 0)
            {
                this.nPadW = 3 - (image.Width % 3);
                x = image.Width + nPadW;
            }
            else if (image.Height % 3 != 0)
            {
                this.nPadH = 3 - (image.Height % 3);
                y = image.Height + nPadH;
            }
            if (image.Width % 3 != 0 && image.Height % 3 != 0)
            {
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
            Console.WriteLine("{0} {1} ", image.Width, image.Height);
            blok = ((this.image.Height * this.image.Width) / 9);
            defBlok = new Pos[blok];
            if (d)
            {
                //initialisasi value padding
                copyToImage();
            }
            setDefBlok(this.image);
        }
        public void copyToArray()
        {
            int w = 0,h = 0;
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = image.Width - nPadW; x < image.Width; x++)
                {
                    valPadW[w] = image.GetPixel(x, y);
                    w++;
                }
                if (y >= image.Height - nPadH)
                {
                    
                    for (int x = 0; x < image.Width; x++)
                    {
                        valPadH[h] = image.GetPixel(x, y);
                        h++;
                    }
                }
            }
        }
        public void copyToImage()
        {
            int w = 0, h = 0;
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = image.Width - nPadW; x < image.Width; x++)
                {
                    Console.Write("{0} || ", image.GetPixel(x, y));
                    image.SetPixel(x, y, valPadW[w]);
                    w++;
                    Console.WriteLine("{0} || {1} {2}", image.GetPixel(x, y),x,y);

                }
                if (y >= image.Height - nPadH)
                {

                    for (int x = 0; x < image.Width; x++)
                    {
                        Console.Write("{0} || ", image.GetPixel(x, y));

                        image.SetPixel(x, y, valPadH[h]);
                        h++;
                        Console.WriteLine("{0} || {1} {2}", image.GetPixel(x, y), x, y);

                    }
                }
            }
        }
        
        public void closePadding(bool e)
        {
            if (e)
            {
                this.valPadW = new Color[PadW * image.Height];
                this.valPadH = new Color[PadH * image.Width];
                Console.WriteLine("{0} {1} ", valPadH.Length, valPadH);
                Console.WriteLine("{0} {1} ", valPadW.Length, valPadW);
                Console.WriteLine("{0} {1} ", image.Width, image.Height);

                copyToArray();
            }

            Bitmap result = new Bitmap(image.Width - nPadW, image.Height - nPadH);
            using (Graphics graph = Graphics.FromImage(result))
            {
                Rectangle ImageSize = new Rectangle(0, 0, result.Width, result.Height);
                graph.FillRectangle(Brushes.Black, ImageSize);
            }

            for (int i = 0; i < result.Height; i++)
            {
                for (int j = 0; j < result.Width; j++)
                {
                    result.SetPixel(j, i, image.GetPixel(j, i));
                }
            }
            this.image = result;
            Console.WriteLine("{0} {1} ", valPadH.Length, valPadH);
            Console.WriteLine("{0} {1} ", valPadW.Length, valPadW);

        }


    }
}
