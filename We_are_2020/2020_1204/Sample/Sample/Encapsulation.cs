using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
    class Encapsulation
    {
        private static bool _powerTap = false;
        public bool _overPower { set { _powerTap = value; } } // カプセル化
        public static void Main()
        {
            if (_powerTap)
                Console.WriteLine("上手に焼けましたァ‼‼");
            else
                Console.WriteLine("生肉のままでした(´･ω･`)しょぼん");
        }
    }

    class Meat
    {
        public static void Mom()
        {
            Encapsulation En;
            En = new Encapsulation();
            En._overPower = true;
        }
    }
}
