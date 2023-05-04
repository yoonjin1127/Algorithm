using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class Dragon : Monster
    {
        private int moveCount;
       
        // 드래곤의 생성자 함수
        public Dragon()
        {
            name = "드래곤";
            curHp = 100;
            maxHp = 100;
            ap = 15;
            dp = 10;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("####################");
            sb.AppendLine("#                  #");
            sb.AppendLine("#  (엄청난 드래곤)  #");
            sb.AppendLine("#  (텍스트 이미지)  #");
            sb.AppendLine("#                  #");
            sb.AppendLine("####################");
            image = sb.ToString();
        }

        // 드래곤의 움직임
        public override void MoveAction()
        {
            if (moveCount++ % 2 != 0)
                return;

            {
                List<Point> path;
                bool result = AStar.PathFinding(Data.map, new Point(pos.x, pos.y),
                    new Point(Data.player.pos.x, Data.player.pos.y), out path);

                if (!result)
                    return;

                if (path[1].y == pos.y - 1)
                    Move(Direction.Up);
                else if (path[1].y == pos.y + 1)
                    Move(Direction.Down);
                else if (path[1].x == pos.x - 1)
                    Move(Direction.Left);
                else
                    Move(Direction.Right);
            }
        }
    }
}
