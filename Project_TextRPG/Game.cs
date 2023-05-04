using Project_TextRPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class Game
    {
        private bool running = true;

        private Scene curScene;     // 현재 씬
        private MainMenuScene mainMenu;
        private MapScene mapScene;
        private InventoryScene inventoryScene;
        private BattleScene battleScene;

        public void Run()       // 동작
        {

            // 초기화
            Init();

            // 게임 루프
            while (running)
            {
                // 표현
                Render();
  
                // 갱신 (Input이 안에 포함됨)
                Update();
            }

            // 마무리
            Release();
        }


        // 어떤 씬인지 모르더라도, 함수들은 "현재 씬"을 처리하기만 하면 된다

        private void Init()     // 초기화 함수
        {
            // 커서를 안보이게 설정
            Console.CursorVisible = false;

            // 데이터 클래스 Init 호출 (플레이어 생성 및 초기화)
            Data.Init();

            // 게임이 모든 씬을 가지고 있도록 함
            mainMenu = new MainMenuScene(this);
            mapScene = new MapScene(this);
            inventoryScene = new InventoryScene(this);
            battleScene = new BattleScene(this);

            // 시작 씬은 메인메뉴로 설정
            curScene = mainMenu;
        }

        // 게임 시작 함수
        public void GameStart()    
        {
            // 맵 호출
            Data.LoadLevel1();

            // 씬을 맵씬으로 전환
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

        public void BattleStart(Monster monster)
        {
            // 현재 씬을 배틀씬으로
            curScene = battleScene;
        }

        // 랜더링 함수
        private void Render()   
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
    }
}
