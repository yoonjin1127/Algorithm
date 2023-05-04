using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    // 배틀, 종료, 인벤토리 등 장면(씬)들을 전환해가며 게임을 진행하게 한다

    public abstract class Scene      // 추상클래스로 생성(@@씬만 존재하므로)
    {
        protected Game game;        // 어떤 게임의 소속인지 확실히 함

        public Scene(Game game)     
        {
            this.game = game;
        }

        public abstract void Render();      // 표현될 수 있어야 하고
        public abstract void Update();      // 갱신될 수 있어야 함
    }
}
