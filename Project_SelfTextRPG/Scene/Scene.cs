using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SelfTextRPG
{
  public abstract class Scene         // 추상클래스로 생성
    {
        protected Game game;            // 어떤 게임의 소속인지 확실히 함

        public Scene(Game game)
        {
            this.game = game;      
        }

        public abstract void Render();  // 출력될 수 있어야 하고
        public abstract void Update();  // 갱신될 수 있어야 함
    }
}
