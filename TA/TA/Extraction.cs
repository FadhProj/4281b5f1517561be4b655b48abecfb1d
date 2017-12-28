using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace TA
{
    class Extraction
    {
        private ArrayList L;

        public Extraction(ref Iimage img, ArrayList L,ref string msg)
        {
            this.L = L;
            extrac(ref img, ref msg);

            histShiffting(ref img);
        }

        public ArrayList L1 { get => L; set => L = value; }

        public void histShiffting(ref Iimage img)
        {
            int n = 0;
            Rectangle rect = new Rectangle(0, 0, img.Image.Width, img.Image.Height);
            BitmapData bmpData = img.Image.LockBits(rect, ImageLockMode.ReadWrite, img.Image.PixelFormat);

            IntPtr ptr = bmpData.Scan0;

            int bytes = Math.Abs(bmpData.Stride) * img.Image.Height;
            byte[] rgbValues = new byte[bytes];


            Marshal.Copy(ptr, rgbValues, 0, bytes);

            for (int i = 0; i < rgbValues.Length; i += 4)
            {
                byte pixelValue = (byte)((rgbValues[i] + rgbValues[i + 1] + rgbValues[i + 2]) / 3);
                if (pixelValue == 254 && L[n].Equals(1))
                {
                    rgbValues[i] = rgbValues[i + 1] = rgbValues[i + 2] = 255;
                    n++;
                }
                else if (pixelValue == 1 && L[n].Equals(1))
                {
                    rgbValues[i] = rgbValues[i + 1] = rgbValues[i + 2] = 0;
                    n++;
                }
                else if ((pixelValue == 1) || (pixelValue == 254)  )
                {
                    n++;
                }
            }
            Marshal.Copy(rgbValues, 0, ptr, bytes);


            img.Image.UnlockBits(bmpData);
        }

        public string BinaryToString(string data)
        {
            List<Byte> byteList = new List<Byte>();

            for (int i = 0; i < data.Length - (data.Length % 8) ; i += 8)
            {
                byteList.Add(Convert.ToByte(data.Substring(i, 8), 2) );
            }
            return Encoding.ASCII.GetString(byteList.ToArray());
        }

        public void extrac(ref Iimage img,ref string msg)
        {
            string b = "";
            int diff;//,i=0,j=0;

            for (int blok = 0; blok < img.Blok; blok++)
            {
                //Console.WriteLine("{0} {1} ",n,binMsg.Length);                
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (!(i == 0 && j == 0))
                        {

                            int Cij = (img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).R + img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).G + img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).B) / 3;
                            int Ci1 = (img.Image.GetPixel(img.DefBlok[blok].M, img.DefBlok[blok].N).R + img.Image.GetPixel(img.DefBlok[blok].M, img.DefBlok[blok].N).G + img.Image.GetPixel(img.DefBlok[blok].M, img.DefBlok[blok].N).B) / 3; ;
                            diff = Cij - Ci1;
                            //Console.Write(" blok {0} N {1} M {2} diff {3} Cij {4} Ci1 {5} || ", blok, img.DefBlok[blok].N+i, img.DefBlok[blok].M+j, diff, Cij, Ci1);
                            if (diff == 0 || diff == -1)
                            {
                                //Console.Write("0 ");
                                //Console.Write("blok {0} M {1} N {2} msg {3} diff {4} ", blok, j, i, "0",diff);
                                b += "0";

                            }
                            else if (diff == 1 || diff == -2)
                            {
                                //Console.Write("1 ");
                               // Console.Write("blok {0} M {1} N {2} msg {3} diff {4} ", blok, j, i, "0",diff);
                                b += "1";
                            }
                            if (diff > 0)
                            {
                                img.Image.SetPixel(j, i, Color.FromArgb(img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).R - 1, img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).G - 1, img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).B - 1));
                            }
                            else if (diff < -1)
                            {
                                img.Image.SetPixel(j, i, Color.FromArgb(img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).R + 1, img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).G + 1, img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).B + 1));
                            }

                        }
                       
                    }
                }
                //Console.WriteLine("");

            }
            Console.WriteLine(b);
            msg = BinaryToString(b);
            //Console.WriteLine(msg);

        }
    }
}
