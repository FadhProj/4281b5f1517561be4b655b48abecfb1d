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
            // extraction
            Extraction ex = new Extraction(ref image, L, ref msg);
            Console.WriteLine(msg);
            //permutation
            Permutation p = new Permutation(ref image,true);

            //StreamChipper

            StreamChipper sc = new StreamChipper(key);
            sc.PRGA(ref image);

            return image;

        }
    }
}
