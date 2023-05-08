using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SelfTextRPG
{
    public class TreasureBox : Item
    {
        public TreasureBox()
        {
            name = "보물 상자";
            description = "무엇인가 들어있는 상자입니다.";
            weight = 3;
            count = 0;
        }

        public override void Use()
        {
            // 열쇠가 있을 때만 열리는 보물상자 설정
            Item item1 = new Key();
            {
                if(Data.inventory.Contains(item1))
                {
                    Console.WriteLine("상자를 엽니다.");
                    Thread.Sleep(1000);
                    Console.WriteLine("포션을 획득합니다.");

                    Item item2 = new Potion();
                    Player.GetItem(item2);

                    count--;
                }

                else
                {
                    Console.WriteLine("박스를 여는 데 필요한 열쇠가 존재하지 않습니다.");
                }

            }
        }
    }
}
