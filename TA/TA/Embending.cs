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
    class Embending
    {
        private ArrayList L;

        public ArrayList L1 { get => L; }

        public Embending(ref Iimage img, string msg)
        {
            L = new ArrayList();
            histShiffting(ref img);
            embed(ref img, msg);
        }

        public string tobin(string inp)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in inp.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            return sb.ToString();

        }


        public void histShiffting(ref Iimage img)
        {
            Rectangle rect = new Rectangle(0, 0, img.Image.Width, img.Image.Height);
            BitmapData bmpData = img.Image.LockBits(rect, ImageLockMode.ReadWrite, img.Image.PixelFormat);

            IntPtr ptr = bmpData.Scan0;

            int bytes = Math.Abs(bmpData.Stride) * img.Image.Height;
            byte[] rgbValues = new byte[bytes];


            Marshal.Copy(ptr, rgbValues, 0, bytes);

            for (int i = 0; i < rgbValues.Length; i += 4)
            {
                byte pixelValue = (byte)((rgbValues[i] + rgbValues[i + 1] + rgbValues[i + 2]) / 3);
                if (pixelValue == 0)
                {
                    L.Add(1);
                    rgbValues[i] = rgbValues[i + 1] = rgbValues[i + 2] = 1;
                }
                else if (pixelValue == 255)
                {
                    L.Add(1);
                    rgbValues[i] = rgbValues[i + 1] = rgbValues[i + 2] = 254;
                }
                else if ((pixelValue == 1) || (pixelValue == 254))
                {
                    L.Add(0);
                }
            }
            Marshal.Copy(rgbValues, 0, ptr, bytes);


            img.Image.UnlockBits(bmpData);
        }

        public void embed(ref Iimage img, string msg)
        {
            int b = 0, diff, R, G, B, n = 0;
            int valM, valN,Cbi,Cb1;
            string binMsg = tobin(msg);
            for (int blok = 0; blok < img.Blok; blok++)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        valM = img.DefBlok[blok].M;
                        valN = img.DefBlok[blok].N;
                        R = img.Image.GetPixel(valM + j, valN + i).R;
                        G = img.Image.GetPixel(valM + j, valN + i).G;
                        B = img.Image.GetPixel(valM + j, valN + i).B;
                        Cbi = (R + G + B) / 3;
                        Cb1 = (img.Image.GetPixel(valM, valN).R + img.Image.GetPixel(valM, valN).G + img.Image.GetPixel(valM, valN).B) / 3;
                        diff = Cbi - Cb1;
                        //Console.WriteLine(" blok {0} N {1} M {2} diff {3} Cij {4} Ci1 {5} R {6} G {7} B {8} || ", blok, img.DefBlok[blok].N+i, img.DefBlok[blok].M+j, diff, Cbi, Cb1, R, G, B);

                        if (n != binMsg.Length)
                            b = binMsg[n] - 48;
                        if (!(i == 0 && j == 0))
                        {
                            if (diff < -1)
                            {
                                R -= 1; G -= 1; B -= 1;
                                img.Image.SetPixel(valM + j, valN + i, Color.FromArgb(R, G, B));
                            }
                            else if (diff == -1)
                            {
                                if (n < binMsg.Length)
                                {
                                    R -= b; G -= b; B -= b;
                                    img.Image.SetPixel(valM + j, valN + i, Color.FromArgb(R, G, B));
                                    n++;
                                }
                            }
                            else if (diff == 0)
                            {
                                if (n < binMsg.Length)
                                {
                                    R += b; G += b; B += b;
                                    img.Image.SetPixel(valM + j, valN + i, Color.FromArgb(R, G, B));
                                    n++;
                                }
                            }
                            else if (diff > 0)
                            {
                                R += 1; G += 1; B += 1;
                                img.Image.SetPixel(valM + j, valN + i, Color.FromArgb(R, G, B));
                            }
                        }
                    }
                }
            }
            /*valM = img.DefBlok[0].M;
            valN = img.DefBlok[0].N;
            R = img.Image.GetPixel(valM + 2, valN + 0).R;
            G = img.Image.GetPixel(valM + 2, valN + 0).G;
            B = img.Image.GetPixel(valM + 2, valN + 0).B;
            Cbi = (R + G + B) / 3;
            Cb1 = (img.Image.GetPixel(valM, valN).R + img.Image.GetPixel(valM, valN).G + img.Image.GetPixel(valM, valN).B) / 3;
            diff = Cbi - Cb1;
            Console.WriteLine(" blok {0} N {1} M {2} diff {3} Cij {4} Ci1 {5} R {6} G {7} B {8} || ", 0, valM + 2, valN + 0, diff, Cbi, Cb1, R, G, B);
            */Console.WriteLine(binMsg);

        }
        /*public void embed(ref Iimage img, string msg)
        {
            int n = 0;
            int b = 0;
            int diff,R,G,B;

            string binMsg = tobin(msg);
            Console.WriteLine(binMsg.Length);
            Console.WriteLine(binMsg);
            diff = 0;
            /*for (int blok = 0; blok < img.Blok; blok++)
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
                            Console.Write(" blok {0} N {1} M {2} diff {3} Cij {4} Ci1 {5} || ", blok, img.DefBlok[blok].N + i, img.DefBlok[blok].M + j, diff, Cij, Ci1);

                        }
                    }
                }
                Console.WriteLine("");
            }
            Console.WriteLine("=================================================================================================");
            for (int blok = 0; blok < img.Blok; blok++)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (!(i == 0 && j == 0))
                        {
                            int Cij = (img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).R + img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).G + img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).B) / 3;
                            int Ci1 = (img.Image.GetPixel(img.DefBlok[blok].M, img.DefBlok[blok].N).R + img.Image.GetPixel(img.DefBlok[blok].M, img.DefBlok[blok].N).G + img.Image.GetPixel(img.DefBlok[blok].M, img.DefBlok[blok].N).B) / 3; ;
                            diff = Cij - Ci1;
                            R = img.Image.get
                            //Console.Write(" blok {0} N {1} M {2} diff {3} Cij {4} Ci1 {5} || ", blok, img.DefBlok[blok].N+i, img.DefBlok[blok].M+j, diff, Cij, Ci1);
                            if (diff < -1)
                            {
                                img.Image.SetPixel(j, i, Color.FromArgb((byte)(img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).R - 1), (byte)(img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).G - 1), (byte)(img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).B - 1)));
                            }
                            else if (diff == -1)
                            {
                                if (n < binMsg.Length)
                                {
                                    //Console.Write(" blok {0} M {1} N {2} msg {3} diff {4}  || ", blok, j, i, binMsg[n], diff);
                                    b = (binMsg[n] - 48);
                                    //Console.Write("{0} {1}",b,b.GetType());
                                    img.Image.SetPixel(j, i, Color.FromArgb((byte)(img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).R - b), (byte)(img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).G - b), (byte)(img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).B - b)));
                                    n++;
                                }
                                else
                                    img.Image.SetPixel(j, i, Color.FromArgb((byte)(img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).R + 0), (byte)(img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).G + 0), (byte)(img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).B + 0)));

                            }
                            else if (diff == 0)
                            {

                                if (n<binMsg.Length)
                                {
                                    //Console.Write(" blok {0} M {1} N {2} msg {3} diff {4}  || ", blok, j, i, binMsg[n], diff);
                                    b = (binMsg[n] - 48);
                                    //Console.Write("{0} {1}",b,b.GetType());
                                    img.Image.SetPixel(j, i, Color.FromArgb((byte)(img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).R + b), (byte) (img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).G + b), (byte) (img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).B + b)));
                                    n++;
                                }
                                else
                                    img.Image.SetPixel(j, i, Color.FromArgb((byte)(img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).R + 0), (byte) (img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).G + 0), (byte) (img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).B + 0)));
                            }
                            else if (diff > 0)
                            {
                                img.Image.SetPixel(j, i, Color.FromArgb((byte)(img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).R + 1), (byte)(img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).G + 1), (byte)(img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).B + 1)));
                            }
                            //Cij = (img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).R + img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).G + img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).B) / 3;
                            //Ci1 = (img.Image.GetPixel(img.DefBlok[blok].M, img.DefBlok[blok].N).R + img.Image.GetPixel(img.DefBlok[blok].M, img.DefBlok[blok].N).G + img.Image.GetPixel(img.DefBlok[blok].M, img.DefBlok[blok].N).B) / 3; ;
                            //diff = Cij - Ci1;
                            //Console.WriteLine("a blok {0} N {1} M {2} diff {3} Cij {4} Ci1 {5} || ", blok, img.DefBlok[blok].N + i, img.DefBlok[blok].M + j, diff, Cij, Ci1);

                        }
                    }
                }
               // Console.WriteLine("");
            }
            diff = 0;
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
                            Console.Write("b blok {0} N {1} M {2} diff {3} Cij {4} Ci1 {5} || ", blok, img.DefBlok[blok].N + i, img.DefBlok[blok].M + j, diff, Cij, Ci1);

                        }
                    }
                }
                Console.WriteLine("");
            }
            Console.WriteLine("=================================================================================================");
            Console.WriteLine(binMsg);

        }


    */
    }
}
