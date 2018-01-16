using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;

namespace TA
{
    class Decryption
    {
        private Bitmap streamImage, permutedImage, originalImage;
        string msg;
        public Decryption()
        {
        }

        public Bitmap StreamImage { get => streamImage; set => streamImage = value; }
        public Bitmap PermutedImage { get => permutedImage; set => permutedImage = value; }
        public Bitmap OriginalImage { get => originalImage; set => originalImage = value; }
        public string Msg { get => msg; set => msg = value; }

        public Iimage decryptImage(String key,Iimage image,ArrayList L,bool e)
        {

            /*Console.WriteLine("{0} {1} ", image.ValPadH.Length, image.ValPadH);
            Console.WriteLine("{0} {1} ", image.ValPadW.Length, image.ValPadW);
            for (int i = 0; i < image.ValPadW.Length; i++)
            {
                Console.Write(image.ValPadW[i]);
            }
            Console.WriteLine("");*/
            for (int i = 0; i < image.ValPadW.Length; i++)
            {
                Console.Write("after {0} ", image.ValPadW[i]);
            }
            Console.WriteLine("");
            int R, G, B;
            /*for (int y = 0; y < image.Image.Height; y++)
            {
                for (int x = 0; x < image.Image.Width; x++)
                {
                    R = image.Image.GetPixel(x, y).R;
                    G = image.Image.GetPixel(x, y).G;
                    B = image.Image.GetPixel(x, y).B;
                    Console.WriteLine("2 X {0} Y {1} R {2} G {3} B {4} || ", x, y, R, G, B);
                }
                Console.WriteLine("");
            }*/
            //addPadding
            image.addPadding(true);
            
            /*for (int y = 0; y < image.Image.Height; y++)
            {
                for (int x = 0; x < image.Image.Width; x++)
                {
                    R = image.Image.GetPixel(x, y).R;
                    G = image.Image.GetPixel(x, y).G;
                    B = image.Image.GetPixel(x, y).B;
                    Console.WriteLine("3 X {0} Y {1} R {2} G {3} B {4} || ", x, y, R, G, B);
                }
                Console.WriteLine("");
            }*/

            if (e)
            {
                // extraction
                Extraction ex = new Extraction(ref image, L, ref msg);
                PermutedImage = image.Image;
                Console.WriteLine(Msg);
            }
            
            
            

            //permutation
            Permutation p = new Permutation(ref image,true);
            StreamImage = image.Image;

            //StreamChipper
            StreamChipper sc = new StreamChipper(key);
            Console.WriteLine("after stream");

            sc.PRGA(ref image);
            OriginalImage = image.Image;
            for (int y = 0; y < image.Image.Height; y++)
            {
                for (int x = 0; x < image.Image.Width; x++)
                {
                    R = image.Image.GetPixel(x, y).R;
                    G = image.Image.GetPixel(x, y).G;
                    B = image.Image.GetPixel(x, y).B;
                    if (R > G + B)
                    {
                        Console.WriteLine("4 X {0} Y {1} R {2} G {3} B {4}", x, y, R, G, B);

                    }
                }
                Console.WriteLine("");
            }
            //closePadding
            image.closePadding(false);

            return image;

        }

    }
}
