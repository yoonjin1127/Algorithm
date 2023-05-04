using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    // 플레이어, 맵 등은 처음부터 끝까지 유지되기 때문에 static을 넣어준다 (특히 플레이어)
    public static class Data
    {
        // 플레어어  생성
        public static Player player;

        // 몬스터 여러마리의 리스트 생성
        public static List<Monster> monsters;

        // bool 형태의 기본 맵 생성
        public static bool[,] map;

        public static void Init()
        {
            player = new Player();
            monsters = new List<Monster>();
        }


        public static void LoadLevel1()
        {
            map = new bool[,]
              {
                { false, false, false, false, false, false, false, false, false, false, false, false, false, false },
                { false,  true,  true,  true,  true, false,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true, false,  true,  true,  true,  true, false, false,  true, false },
                { false,  true,  true,  true,  true, false,  true,  true,  true,  true, false,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true, false,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true, false, false, false, false,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false,  true, false },
                { false,  true, false,  true,  true,  true,  true,  true,  true,  true,  true, false,  true, false },
                { false,  true, false,  true,  true,  true,  true,  true,  true,  true,  true, false,  true, false },
                { false,  true, false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true, false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false, false, false, false, false, false, false, false, false, false, false, false, false, false },
              };

            // 플레이어 위치 선정
            player.pos = new Position(2, 2);

            // 몬스터(슬라임) 생성, 위치 선정
            Monster slime1 = new Slime();
            slime1.pos = new Position(3, 5);
            monsters.Add(slime1);

            Monster slime2 = new Slime();
            slime2.pos = new Position(7, 5);
            monsters.Add(slime2);

            // 드래곤 생성, 위치 선정
            Monster dragon = new Dragon();
            dragon.pos = new Position(12, 12);
            monsters.Add(dragon);
        }

        // 몬스터가 존재하는지 확인
        public static Monster MonsterInPos(Position pos)
        {
            // 찾고자 하는 몬스터와 동일한 몬스터를 찾아줌
            // 못찾은 경우는 null 반환
            Monster monster = monsters.Find(target => target.pos.x == pos.x && target.pos.y == pos.y);
            return monster;
        }
    }
}
