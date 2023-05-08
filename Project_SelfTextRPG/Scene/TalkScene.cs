using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SelfTextRPG
{
    public class TalkScene : Scene
    {
        // NPC 인스턴스 정의
        private NPC npc;
        public TalkScene(Game game) : base(game) 
        {
        }

        // 출력함수
        public override void Render()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{npc.name}과 우연히 만났다.");
            sb.AppendLine("1. 대화 나누기");
            sb.AppendLine("2. 공격하기");
            sb.AppendLine("행동을 선택하세요. : ");

            Console.WriteLine(sb.ToString());

            Console.Clear();
        }

        // 갱신함수
        public override void Update()
        {
           int input = int.Parse(Console.ReadLine());
         
            if (input ==1)
        }
    }
}
