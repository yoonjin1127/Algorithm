using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    // 몬스터는 상위개념이므로, 추상 클래스로 구현
    public abstract class Monster       
    {
        // 몬스터 아이콘
        public char icon = '▼';

        // 몬스터 위치
        public Position pos;

        // 각각의 몬스터가 움직이는 방법을 추상함수로 구현
        public abstract void MoveAction();

        public void Move(Direction dir)
        {
            Position prevPos = pos;
            // 몬스터 이동
            switch (dir)
            {
                case Direction.Up:
                    pos.y--;
                    break;
                case Direction.Down:
                    pos.y++;
                    break;
                case Direction.Left:
                    pos.x--;
                    break;
                case Direction.Right:
                    pos.x++;
                    break;
            }
        }
    }
}
