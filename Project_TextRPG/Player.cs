using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    // 플레이어의 정보를 캡슐화한 클래스
    public class Player
    {
        // 플레이어의 아이콘
        public char icon = '♥';

        // 플레이어의 위치
        public Position pos;


        // 플레이어 생성자 함수
         public Player()
        {
            CurHp = 60;
            MaxHp = 100;
            Level = 1;
            CurExp = 0;
            MaxExp = 100;
            AP = 5;
            DP = 1;


            StringBuilder sb = new StringBuilder();
            sb.AppendLine("####################");
            sb.AppendLine("#                  #");
            sb.AppendLine("#  (  플레이어   )  #");
            sb.AppendLine("#  (텍스트 이미지)  #");
            sb.AppendLine("#                  #");
            sb.AppendLine("####################");
        }

        public int CurHp { get; private set; }
        public int MaxHp { get; private set; }
        public int Level { get; private set; }
        public int CurExp { get; private set; }
        public int MaxExp { get; private set; }
        public int AP { get; private set; }
        public int DP { get; private set; }



        // 플레이어의 이동 (방향으로 움직임)
        public void Move(Direction dir)
        {
            Position prevPos = pos;
            // 플레이어 이동
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

            // 이동한 자리가 벽일 경우
            if (!Data.map[pos.y, pos.x])
            {
                // 원위치 시키기
                pos = prevPos;
            }
        }
    }
}
