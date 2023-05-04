using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class BattleScene : Scene
    {
        private Monster monster;

        public BattleScene(Game game) : base(game)
        {

        }

        // 출력 오버라이드
        public override void Render()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("엄청난 몬스터를 만났다.");
            sb.AppendLine("1. 공격하기");
            sb.AppendLine("2. 도망가기");
            sb.AppendLine("행동을 선택하세요 : ");

            Console.WriteLine(sb.ToString());

            Console.Clear();
        }

        // 갱신 오버라이드
        public override void Update()
        {
            for (int i = 0; i < Data.player.skills.Count; i++)
            {
                Console.Write($"{i + 1,2}. {Data.player.skills[i].name} ");
            }
            Console.WriteLine();
            Console.Write("명령을 입력하세요 : ");

            string input = Console.ReadLine();

            int index;
            if (!int.TryParse(input, out index))
            {
                Console.WriteLine("잘못 입력하셨습니다.");
                return;
            }
            if (index < 1 || index > Data.player.skills.Count)
            {
                Console.WriteLine("잘못 입력하셨습니다.");
                return;
            }

            Data.player.skills[index - 1].action(monster);

            // 턴 결과
            if (monster.curHp <= 0)
            {
                game.Map();
                return;
            }

            // 몬스터 턴
            monster.Attack(Data.player);

            // 턴 결과
            if (Data.player.CurHp <= 0)
            {
                game.GameOver("몬스터에게 패배했습니다.");
                return;
            }
        }

        // 배틀 시작 함수 구현
        public void BattleStart(Monster monster)
        {
            // 현재 몬스터 외에는 삭제
            this.monster = monster;
            Data.monsters.Remove(monster);

            Console.Clear();
            Console.WriteLine("전투 시작!");
            Thread.Sleep(1000);
        }

        // 배틀 종료 함수 구현
        public void EndBattle()
        {
            Console.Clear();
            Console.WriteLine("전투에서 승리했다!");

            Thread.Sleep(2000);

            // 맵에 몬스터가 있으면 맵으로 복귀
            // 없으면 종료
            if (Data.monsters.Count > 0)
                game.Map();

            else
                game.GameOver();
        }
    }
}
