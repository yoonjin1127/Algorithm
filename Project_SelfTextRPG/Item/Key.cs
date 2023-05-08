using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SelfTextRPG
{
    public class Key : Item
    {
        public Key()
        {
            name = "열쇠";
            description = "상자를 열 수 있습니다.";
            weight = 1;
            count = 0;
        }

        public override void Use()
        {
            Console.WriteLine("열쇠는 단독으로 사용할 수 없습니다.");
        }
    }
}
