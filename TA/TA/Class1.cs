using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TA
{
    class Decryption
    {
        private Iimage streamImage, permutedImage, embenImage;
        public Decryption()
        {
        }

        public Iimage decryptImage(String key,Iimage image)
        {
            //permutation
            Permutation p = new Permutation(ref image,true);

            //StreamChipper

            StreamChipper sc = new StreamChipper(key);
            sc.PRGA(ref image);

            return image;

        }
    }
}
