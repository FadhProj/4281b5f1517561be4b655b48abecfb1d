using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace TA
{
    class Encryption
    {
        private Bitmap streamImage, permutedImage, embenImage;
        ArrayList L = new ArrayList();
        Image I;

        public Encryption(String Key,ref Iimage img)
        {
            //addPadding
            img.addPadding(false);
            Console.WriteLine("Before Stream");
            int R, G, B;
            for (int y = 0; y < img.Image.Height; y++)
            {
                for (int x = 0; x < img.Image.Width; x++)
                {
                    R = img.Image.GetPixel(x, y).R;
                    G = img.Image.GetPixel(x, y).G;
                    B = img.Image.GetPixel(x, y).B;
                    Console.Write("0 X {0} Y {1} R {2} G {3} B {4} || ", x, y, R, G, B);
                }
                Console.WriteLine("");
            }
            Console.WriteLine("+++");
            //streamEncryption
            StreamChipper sc = new StreamChipper(Key);
            sc.PRGA(ref img);
            streamImage = (Bitmap)img.Image.Clone();//new Iimage(img.Image).Image;

            //permutation
            Permutation p = new Permutation(ref img);
            permutedImage = (Bitmap)img.Image.Clone(); 

            //Embending
            Embending em = new Embending(ref img,"Hello World");
            embenImage = (Bitmap)img.Image.Clone();
            L = em.L1;

            //closePadding
            img.closePadding(true);
            for (int i = 0; i < img.ValPadW.Length; i++)
            {
                Console.Write("before {0} ",img.ValPadW[i]);
            }
            Console.WriteLine("");





        }

        public ArrayList L1 { get => L;}
        public Bitmap StreamImage { get => streamImage; set => streamImage = value; }
        public Bitmap PermutedImage { get => permutedImage; set => permutedImage = value; }
        public Bitmap EmbenImage { get => embenImage; set => embenImage = value; }
        
    }
}
