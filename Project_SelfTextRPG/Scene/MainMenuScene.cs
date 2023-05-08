using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SelfTextRPG
{
    public class MainMenuScene : Scene
    {
        public MainMenuScene(Game game) : base(game) 
        { 
        }

        public override void Render()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("1. 게임시작");
            sb.AppendLine("2. 게임종료");
            sb.AppendLine("메뉴를 선택하세요 : ");

            Console.WriteLine(sb.ToString());
        }
        public override void Update()
        {
            string input = Console.ReadLine();

            int command;
            if (!int.TryParse(input, out command))      // 만약 입력한 값이 숫자로 변환이 가능하다면
            {
                Console.WriteLine("잘못 입력하셨습니다.");
                // thread는 컴퓨터를 돌리는 단위이고, Sleep은 그것을 쉬게하는 키워드이다
                // 1000 m/s(1 m/s가 0.001초)이니 1초 멈춘다
                Thread.Sleep(1000);
                return;
            }

            switch (command)
            {
                case 1:
                    // TODO : 게임시작
                    game.GameStart();
                    Console.WriteLine("게임시작");
                    Thread.Sleep(1000);
                    game.Choose();
                    Thread.Sleep(1000);
                    break;
                case 2:
                    // TODO : 게임종료
                    game.GameOver();
                    Console.WriteLine("게임종료");
                    Thread.Sleep(1000);
                    break;
                default:
                    Console.WriteLine("잘못 입력 하셨습니다.");
                    Thread.Sleep(1000);
                    break;

            }
        }
    }
}
