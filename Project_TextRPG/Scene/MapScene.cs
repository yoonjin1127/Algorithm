using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class MapScene : Scene
    {
        public MapScene(Game game) : base(game)
        { 
        }

        public override void Render()
        {
            PrintMap();
        }

        public override void Update()
        {
            ConsoleKeyInfo input = Console.ReadKey();

            // 플레이어 이동
            switch (input.Key) 
            {
                case ConsoleKey.UpArrow:
                    Data.player.Move(Direction.Up);
                    break;
                case ConsoleKey.DownArrow:
                    Data.player.Move(Direction.Down);
                    break;
                case ConsoleKey.LeftArrow:
                    Data.player.Move(Direction.Left);
                    break;
                case ConsoleKey.RightArrow:
                    Data.player.Move(Direction.Right);
                    break;
            }

            // 플레이어 몬스터 접근
            Monster monsterInPos = Data.MonsterInPos(Data.player.pos);
            if (Data.MonsterInPos(Data.player.pos) != null)
            {
                // 전투 시작
                game.BattleStart(monsterInPos);
                return;
            }


            // 몬스터 이동
            foreach (Monster monster in Data.monsters)
            {
                monster.MoveAction();
                if (monster.pos.x == Data.player.pos.x &&
                    monster.pos.y == Data.player.pos.y)
                {
                    // 전투시작
                    game.BattleStart(monster);
                    return;
                }

            }
        }


        // 맵 출력 함수
        private void PrintMap()
        {
            // 맵 컬러
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            // 연속적으로 콘솔에 찍을 것이므로 스트링빌더 사용
            StringBuilder sb = new StringBuilder();

            // 이중 반복문으로 맵을 찍는다
            for (int y = 0; y < Data.map.GetLength(0); y++) 
            { 
                for (int x = 0; x < Data.map.GetLength(1); x++) 
                {
                    // 맵에 데이터가 있다면 공백 출력
                    if (Data.map[y, x])
                        sb.Append('　');
                    // 그 외에는 벽 출력
                    else
                        sb.Append('▩');
                }
                sb.AppendLine();
            }

            Console.WriteLine(sb.ToString());

            // 몬스터 출력
            Console.ForegroundColor= ConsoleColor.Green;        // 초록색

            foreach (Monster monster in Data.monsters)
            {
                Console.SetCursorPosition(monster.pos.x*2, monster.pos.y);
                Console.WriteLine(monster.icon);
            }
            
            // 플레이어 컬러
            Console.ForegroundColor = ConsoleColor.Red;
            // 방향키 입력
            Console.SetCursorPosition(Data.player.pos.x*2, Data.player.pos.y);
            // 플레이어 아이콘 출력
            Console.WriteLine(Data.player.icon);


        }

        // 메뉴 출력
        private void PrintMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            (int left, int top) pos = Console.GetCursorPosition();
            Console.SetCursorPosition(Data.map.GetLength(1) + 3, 1);
            Console.Write("메뉴 : Q");
            Console.SetCursorPosition(Data.map.GetLength(1) + 3, 3);
            Console.Write("이동 : 방향키");
            Console.SetCursorPosition(Data.map.GetLength(1) + 3, 4);
            Console.Write("인벤토리 : I");
        }

        // 정보 출력
        private void PrintInfo()
        {
            Console.SetCursorPosition(0, Data.map.GetLength(0) + 1);
            Console.Write($"HP : {Data.player.CurHp,3}/{Data.player.MaxHp,3}\t");
            Console.Write($"EXP : {Data.player.CurExp,3}/{Data.player.MaxExp,3}");
        }
    }
}
