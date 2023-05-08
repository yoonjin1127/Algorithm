using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Project_SelfTextRPG
{
     public class ChooseScene : Scene
    {    
        public ChooseScene(Game game) : base(game) 
        {
        }

        // 출력 오버라이드
        // 직업 선택창 출력
        public override void Render()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("직업을 선택하세요!");
            sb.AppendLine("[1] 드루이드");
            sb.AppendLine("[2] 열쇠공");
            sb.AppendLine("[3] 네크로맨서");

            Console.WriteLine(sb.ToString());
            Console.Clear();
        }

        // 갱신 오버라이드
        public override void Update()
        {
            // 데이터의 직업 유형 초기화
            Player.JobType jobType = Player.JobType.None;

            // 직업을 입력하게끔 설정
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    jobType = Player.JobType.Druids;
                    break;
                case "2":
                    jobType = Player.JobType.Infiltrator;
                    break;
                case "3":
                    jobType = Player.JobType.Necromancer;
                    break;
            }
            Console.WriteLine($"{jobType}을 선택하셨습니다.");
        }
    }
}
