using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SelfTextRPG
{
    public class MapScene : Scene
    {
        public MapScene(Game game) : base(game) 
        {
        }

        // 출력 함수
        public override void Render()
        {
            // 맵과 메뉴, 정보를 출력한다
            PrintMap();
            PrintMenu();
            PrintInfo();
        }

        // 갱신함수
        public override void Update()
        {
            ConsoleKeyInfo input = Console.ReadKey();

            // 시스템 키 입력시 씬 전환
            if (input.Key == ConsoleKey.Q)
            {
                game.MainMenu();
                return;
            }
            else if (input.Key == ConsoleKey.I)
            {
                game.Inventory();
                return;
            }

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

            // 아이템 습득
            Item item = Data.ItemInPos(Data.player.pos);
            if (item != null)
            {
                Data.player.GetItem(item);
                Data.items.Remove(item);
            }

            // 플레이어 몬스터 접근
            Monster monsterInPos = Data.MonsterInPos(Data.player.pos);
            if (Data.MonsterInPos(Data.player.pos) != null)
            {
                // 전투 시작
                game.BattleStart(monsterInPos);
                return;
            }

            // 플레이어 NPC 접근
            NPC npcInPos = Data.NPCInPos(Data.player.pos);
            if (Data.NPCInPos(Data.player.pos) != null) 
            {
                // 대화 시작
                game.Talk();
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

        // 맵 생성
        public void GenerateMap()
        {
            Data.LoadLevel1();
        }

        // 맵 출력 함수
        public void PrintMap()
        {
            // 맵 컬러
            Console.ForegroundColor = ConsoleColor.Cyan;

            // 연속적으로 콘솔에 찍을 것이므로, 스트링빌더 사용
            StringBuilder sb = new StringBuilder();

            // 이중 for문으로 맵을 찍는다
            for (int y = 0; y < Data.map.GetLength(0); y++) 
            { 
                for (int x = 0; x < Data.map.GetLength(1); x++)
                {
                    // 맵에 데이터가 있다면(true라면) 공백 출력
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
            Console.ForegroundColor = ConsoleColor.Green;

            foreach (Monster monster in Data.monsters)
            {
                Console.SetCursorPosition(monster.pos.x * 2, monster.pos.y);
                Console.WriteLine(monster.icon);
            }

            // 플레이어 컬러
            Console.ForegroundColor = ConsoleColor.Red;
            // 방향키 입력
            Console.SetCursorPosition(Data.player.pos.x * 2, Data.player.pos.y);
            // 플레이어 아이콘 출력
            Console.WriteLine(Data.player.icon);


            // NPC 출력
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (NPC npc in Data.npcs)
            {
                Console.SetCursorPosition(npc.pos.x * 2, npc.pos.y);
                Console.WriteLine(npc.icon);
            }

        }

        // 메뉴 출력
        private void PrintMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            (int left, int top) pos = Console.GetCursorPosition();
            Console.SetCursorPosition(Data.map.GetLength(1) + 3, 1);
            Console.Write("             메뉴 : Q             ");
            Console.SetCursorPosition(Data.map.GetLength(1) + 3, 3);
            Console.Write("             이동 : 방향키         ");
            Console.SetCursorPosition(Data.map.GetLength(1) + 3, 4);
            Console.Write("             인벤토리 : I         ");
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
