using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SelfTextRPG
{
    public class Game
    {
        private bool running = true;

        // 씬 별 인스턴스 변수 선언
        private Scene curScene;
        private MainMenuScene mainMenu;
        private MapScene mapScene;
        private InventoryScene inventoryScene;
        private BattleScene battleScene;
        private ChooseScene chooseScene;
        private TalkScene talkScene;

        public void Run()   // 동작
        {
            // 초기화
            Init();

            // 게임 루프
            while (running) 
            {
                // 출력
                Render();

                // 갱신 (Input이 내포됨)
                Update();
            }
            
            // 마무리
            Release();
        }

        // 게임 루프의 함수 선언

        private void Init()     // 초기화 함수
        {
            // 커서를 안 보이게 설정
            Console.CursorVisible = false;

            // 데이터 클래스 Init 호출 (플레이어 생성 및 초기화)
            Data.Init();

            // 게임이 모든 씬을 가지고 있도록 함
            mainMenu = new MainMenuScene(this);
            mapScene = new MapScene(this);
            inventoryScene = new InventoryScene(this);
            battleScene = new BattleScene(this);
            chooseScene = new ChooseScene(this);
            talkScene = new TalkScene(this);
        }

        public void Render()
        {
            // 랜더링 이전의 씬을 지움
            Console.Clear();

            // 컬러
            Console.ForegroundColor = ConsoleColor.White;

            // 현재 씬을 랜더링
            curScene.Render();
        }

        // 갱신 함수
        private void Update()
        {
            curScene.Update();
        }

        // 마무리 함수
        private void Release()
        {

        }

        /******************게임 함수*******************/
       
        // 게임 시작 함수
        public void GameStart()
        {
            // 맵 호출
            Data.LoadLevel1();

            // 씬을 맵 씬으로 전환
            curScene = mapScene;
        }

        // 게임 종료 함수
        public void GameOver(string text = "")    // 매개변수의 기본값을 지정함으로써, 매개변수를 생략하더라도 오류를 발생시키지 않을 수 있다  
        {
            Console.Clear();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine();
            sb.AppendLine("  ***    *   *   * *****       ***  *   * ***** ****  ");
            sb.AppendLine(" *      * *  ** ** *          *   * *   * *     *   * ");
            sb.AppendLine(" * *** ***** * * * *****      *   * *   * ***** ****  ");
            sb.AppendLine(" *   * *   * *   * *          *   *  * *  *     *  *  ");
            sb.AppendLine("  ***  *   * *   * *****       ***    *   ***** *   * ");
            sb.AppendLine();

            sb.AppendLine();
            sb.Append(text);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(sb.ToString());
            Console.ResetColor();

            // 러닝을 false로 만들면 게임 자체가 종료된다
            running = false;
        }



        /*******************씬 변경********************/

        // 메인메뉴 이동 함수
        public void MainMenu()
        {
            // 현재 씬을 메인메뉴씬으로
            curScene = mainMenu;
        }

        // 배틀 시작 함수
        public void BattleStart(Monster monster)
        {
            // 현재 씬을 배틀씬으로
            curScene = battleScene;
        }

        // 맵 이동 함수
        public void Map()
        {
            // 현재 씬을 맵 씬으로
            curScene = mapScene;
        }

        // 인벤토리 이동 함수
        public void Inventory()
        {
            curScene = inventoryScene;
        }

        // 직업 선택 함수
        public void Choose()
        {
            curScene = chooseScene;
        }

        // NPC 대화 함수
        public void Talk()
        {
            curScene = talkScene;
        }

    }
}
