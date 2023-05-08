using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SelfTextRPG
{
    public class RandomBox : Item
    {
        public RandomBox()
        {
            name = "랜덤 상자";
            description = "무엇인가 들어있는 상자입니다.";
            weight = 3;
            count = 0;
        }

        public override void Use()
        {
            Random random = new Random();
            switch (random.Next(0,3)) 
            {
                case 0:
                    Console.WriteLine("아무것도 나오지 않았습니다.");
                    break;
                case 1:
                    Player.GetItem(new Key());
                    Console.WriteLine("박스에서 열쇠가 나왔습니다.");
                    break;
                    case 2:
                    Player.GetItem(new Potion());
                    Console.WriteLine("박스에서 포션이 나왔습니다.");
                    break;
            }
            count--;
            return;
           
        }



    }
}
