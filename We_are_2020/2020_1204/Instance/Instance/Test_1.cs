﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instance
{
    class Test
    {
        public static void Main()
        {
            Mori kensuke;
            kensuke = new Mori();
            Console.WriteLine(kensuke.mNumber);
        }
    }

    public class Mori
    {
        public int mNumber = 65482;
    }
}