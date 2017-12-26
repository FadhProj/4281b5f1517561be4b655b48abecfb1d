﻿using System;
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

        public Embending(ref Iimage img,string msg)
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

            for (int i = 0; i < rgbValues.Length; i+=4)
            {
                byte pixelValue = (byte)((rgbValues[i] + rgbValues[i + 1] + rgbValues[i + 2]) / 3);
                if (pixelValue == 0 )
                {
                    L.Add(1);
                    rgbValues[i] = rgbValues[i + 1] = rgbValues[i + 2] = 1;
                }
                else if (pixelValue == 255)
                {
                    L.Add(1);
                    rgbValues[i] = rgbValues[i + 1] = rgbValues[i + 2] = 254;
                }
                else if ((pixelValue == 1) || (pixelValue== 254) )
                {
                    L.Add(0);
                }
            }
            Marshal.Copy(rgbValues, 0, ptr, bytes);
            

            img.Image.UnlockBits(bmpData);
        }
       

        public void embed(ref Iimage img, string msg)
        {
            int n = 0;
            int b = 0;
            int diff;
            string binMsg = tobin(msg);
            Console.WriteLine(binMsg);

            for (int blok = 0; blok < img.Blok; blok++)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        
                        int Cij = (img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).R + img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).G + img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).B) / 3  ;
                        int Ci1 = (img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N).R + img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N).G + img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N).B) / 3; ;
                        diff = Cij - Ci1;
                        if (diff < -1)
                        {
                            img.Image.SetPixel(j, i, Color.FromArgb(img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).R - 1, img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).G - 1, img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).B - 1));
                        }
                        else if (diff == 1)
                        {
                            if (n < binMsg.Length)
                            {
                                b = (int)binMsg[n] - 48;
                                img.Image.SetPixel(j, i, Color.FromArgb(img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).R - b, img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).G - b, img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).B - b));
                                n++;
                            }                            
                        }
                        else if (diff == 0)
                        {
                            if (n < binMsg.Length)
                            {
                                b = (int)binMsg[n] - 48;
                                img.Image.SetPixel(j, i, Color.FromArgb(img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).R + b, img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).G + b, img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).B + b));
                                n++;
                            }
                        }
                        else if (diff > 0)
                        {
                            img.Image.SetPixel(j, i, Color.FromArgb(img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).R + 1, img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).G + 1, img.Image.GetPixel(img.DefBlok[blok].M + j, img.DefBlok[blok].N + i).B + 1));
                        }
                    }
                }
            }
            Console.WriteLine(binMsg);

        }


    }
}