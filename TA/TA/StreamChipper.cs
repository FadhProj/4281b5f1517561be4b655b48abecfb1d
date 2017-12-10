﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA
{
    class StreamChipper
    {
        private int[] K;
        private int[] S;

        //Construtor Class StreamChipper
        public StreamChipper(string key)
        {
            K = new int[256];
            S = new int[256];


        }

        //Procedure Pertukaran Array S
        public void swap(int val1, int val2)
        {
            int temp = S[val1];
            S[val1] = S[val2];
            S[val2] = temp;
        }

        //Procedure Inisialisasi State Array K dan Array S
        public void initStateArray(string key)
        {
            for (int i = 0; i < 256; i++)
            {
                K[i] = key[i % key.Length];
                S[i] = i;
            }
        }

        //Prosedura Penjadwalan Kunci menggunakan RC4
        public void keySchedullingAlgorithm()
        {
            int j = 0;
            for (int i = 0; i < 256; i++)
            {
                j = (j + S[i] + K[i]) % 256;
                swap(i, j);
            }
        }

        //Prosedure Pembangkitan Kunci Random
        public void PRGA()
        {
            int i = 0;
            int j = 0;
            for (int n = 0; n < 10; n++) //perlu di ubah!!
            {
                i = (j + 1) % 256;
                j = (j + S[i]) % 256;
                swap(i, j);
                //XOR blok
            }
        }
    }
}
