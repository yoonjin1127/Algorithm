using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class Slime : Monster
    {
        private int moveCount;

        // 슬라임은 랜덤으로 움직이게끔 구현
        public override void MoveAction()
        {
            // 세 칸마다 움직이게끔 함
            if (moveCount++ % 3 != 0)
                return;

            Random random = new Random();       
            switch (random.Next(0,4))       // 0, 1, 2, 3 중 하나가 출력됨
            {
                case 0:
                    Move(Direction.Up);
                    break;
                case 1:
                    Move(Direction.Down);
                    break;
                case 2:
                    Move(Direction.Left);
                    break;
                case 3:
                    Move(Direction.Right);
                    break;

            }
        }
    }
}
