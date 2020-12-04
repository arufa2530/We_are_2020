using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
    class Instance
    {
        public static void Main()
        {
            Mori kensuke;           //　ここでMoriをkensukeに入れる
            kensuke = new Mori();   //  ここでMoriのメモリを確保しないといけないのでインスタンス化する
            Console.WriteLine(kensuke.mNumber);
        }
    }

    public class Mori
    {
        public int mNumber = 65482;
    }
}
