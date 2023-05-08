using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project_SelfTextRPG
{
    public class Player
    {
        // 인간 직업 유형
        public enum JobType
        {
            None = 0,
            Druids = 1,
            Infiltrator = 2,
            Necromancer = 3
        }

        // 플레이어의 텍스트 이미지
        public string image;

        // 플레이어의 아이콘
        public char icon = '♥';

        // 플레이어의 위치
        public Position pos;

        // 플레이어의 스킬 리스트
        public List<Skill> skills;


        int hp = 0;
        int attack = 0;
        JobType jobType;

        // 플레이어의 생성자 함수
        public Player(JobType jobType)
        {
            this.jobType = jobType;

        }

        public Player()
        {
            CurHp = 60;
            MaxHp = 100;
            Level = 1;
            CurExp = 0;
            MaxExp = 100;
            AP = 500;
            DP = 1;

            skills = new List<Skill>();
            skills.Add(new Skill("공격하기", Attack));
            skills.Add(new Skill("회복하기", Recovery));

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("                   ");
            sb.AppendLine("      ╭◜◝ ͡ ◜◝ ╮    ");
            sb.AppendLine("    (Ꮚ ´ ꒳ ` Ꮚ   ");
            sb.AppendLine("      ╰◟◞ ͜ ◟◞╯     ");
            sb.AppendLine("                   ");
            sb.AppendLine("                   ");
            image = sb.ToString();
        }

        public int CurHp;
        public int MaxHp;
        public int Level;
        public int CurExp;
        public int MaxExp;
        public int AP;
        public int DP;



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


        // 아이템 획득
        public void GetItem(Item item)
        {
            Data.inventory.Add(item);
        }

        // 아이템 사용
        public void UseItem(Item item)
        {
            Data.inventory.Remove(item);
            item.Use();
        }

        // 회복
        public void Heal(int heal)
        {
            CurHp += heal;
            if(CurHp > MaxHp)
                CurHp = MaxHp;
        }

        // 몬스터를 공격
        public void Attack(Monster monster)
        {
            Console.WriteLine($"플레이어가 {monster.name}(을/를) 공격한다.");
            Thread.Sleep(1000);
            monster.TakeDamage(AP);
        }

        // 드루이드 스킬
        public void DruidsSkill(Monster monster)
        {
            Console.WriteLine($"드루이드가 몬스터에게 설득을 시도합니다.");
            Thread.Sleep(1000);
            Random rand = new Random();
            switch (rand.Next(0, 2)) 
            {
                case 0:
                    Console.WriteLine("몬스터가 설득당하고 물러났습니다.");
                    // 안되면 static
                    BattleScene.EndBattle();
                    break;
                case 1:
                    Console.WriteLine("몬스터를 설득하는 데 실패했습니다.");
                    break;
            }
        }

        // 회복 스킬
        public void Recovery(Monster monster)
        {
            Console.WriteLine("플레이어가 회복을 시도합니다.");
            Thread.Sleep(1000);
            Heal(5);
            Console.WriteLine($"플레이어의 체력이 {CurHp}가 되었습니다.");
            Thread.Sleep(1000);
        }

        // 데미지 받음
        public void TakeDamage(int damage)
        {
            if (damage > DP)
            {
                Console.WriteLine($"플레이어는 {damage - DP} 데미지를 받았다.");
                CurHp -= damage - DP;
            }
            else
                Console.WriteLine($"공격은 플레이어에게 먹히지 않았다.");

            Thread.Sleep(1000);

            if (CurHp <= 0)
            {
                Console.WriteLine($"플레이어는 쓰러졌다!");
                Thread.Sleep(1000);
            }
        }
    }
}
