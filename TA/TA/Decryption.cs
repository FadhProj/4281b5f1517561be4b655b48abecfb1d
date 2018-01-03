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
        private Iimage streamImage, permutedImage, embenImage;
        string msg;
        public Decryption()
        {
        }

        public Iimage decryptImage(String key,Iimage image,ArrayList L)
        {
            //addPadding
            Console.WriteLine("{0} {1} ", image.ValPadH.Length, image.ValPadH);
            Console.WriteLine("{0} {1} ", image.ValPadW.Length, image.ValPadW);
            for (int i = 0; i < image.ValPadW.Length; i++)
            {
                Console.Write(image.ValPadW[i]);
            }
            Console.WriteLine("");
            image.addPadding(true);

            // extraction
            Extraction ex = new Extraction(ref image, L, ref msg);
            Console.WriteLine(msg);

            //permutation
            Permutation p = new Permutation(ref image,true);

            //StreamChipper
            StreamChipper sc = new StreamChipper(key);
            sc.PRGA(ref image);

            //closePadding
            image.closePadding(false);

            return image;

        }
    }
}
