using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SelfTextRPG
{
    // 몬스터를 추상 클래스로 구현
    public abstract class Monster
    {
        // 몬스터 이름
        public string name;

        // 몬스터 아이콘
        public char icon = '▼';

        // 몬스터 위치
        public Position pos;

        public string image;
        public int curHp;
        public int maxHp;
        public int ap;
        public int dp;

        // 각각의 몬스터가 움직이는 방법을 추상함수로 구현
        public abstract void MoveAction();
       
        public void Move(Direction dir)
        {
            Position prevPost = pos;
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

        // 피격 함수
        public void TakeDamage(int damage)
        {
            if (damage > dp)
            {
                Console.WriteLine($"{name}(은/는) {damage - dp} 데미지를 받았다.");
                curHp -= damage - dp;
            }

            else
                Console.WriteLine($"공격은 {name}에게 먹히지 않았다.");

            Thread.Sleep(1000);

            if (curHp <= 0) 
            {
                Console.WriteLine($"{name}(은/는) 쓰러졌다!");
                Thread.Sleep(1000);
                Console.WriteLine("몬스터는 열쇠를 떨어뜨렸다!");
                Data.player.GetItem(new Key());
                Thread.Sleep(1000);           
            }
        }

        // 공격 함수
        public void Attack(Player player)
        {
            Console.WriteLine($"{name}(이/가) 플레이어를 공격합니다.");
            Thread.Sleep(1000);
            player.TakeDamage(ap);
        }
    }
}
