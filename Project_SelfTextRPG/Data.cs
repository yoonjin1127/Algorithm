using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SelfTextRPG
{
    public class Data
    {
        // 플레이어 생성
        public static Player player;

        // 몬스터 여러마리의 리스트 생성
        public static List<Monster> monsters;

        // 엔피씨 여러 명의 리스트 생성
        public static List<NPC> npcs;

        // 맵에 있는 아이템 리스트 생성
        public static List<Item> items;

        // 유저가 가진 아이템 리스트 생성
        public static List<Item> inventory;

        // bool 형태의 기본 맵 생성
        public static bool[,] map;

        // 플레이어, 몬스터, 인벤토리, 맵내아이템을 생성하는 초기화 함수
        public static void Init()
        {
            player = new Player();
            monsters = new List<Monster>();
            inventory = new List<Item>();
            items = new List<Item>();

            // 시작 인벤토리에 아이템 추가
            inventory.Add(new Key());
            inventory.Add(new TreasureBox());
        }

        // 객체들이 위치에 존재하는지 확인
        public static bool IsObjectInPos(Position pos)
        {
            return MonsterInPos(pos) == null && ItemInPos(pos) == null;
        }

        // 몬스터가 위치에 존재하는지 확인
        public static Monster MonsterInPos(Position pos)
        {
            // 찾고자 하는 몬스터와 동일한 몬스터를 찾아줌
            // 못찾은 경우는 null 반환
            Monster monster = monsters.Find(target => target.pos.x == pos.x && target.pos.y == pos.y);
            return monster;
        }

        // NPC가 위치에 존재하는지 확인
        public static NPC NPCInPos(Position pos)
        {
            NPC npc = npcs.Find(target => target.pos.x == pos.x && target.pos.y == pos.y);
            return npc;
        }

        // 아이템이 위치에 존재하는지 확인
        public static Item ItemInPos(Position pos)
        {
            foreach (Item item in items)
            {
                if (item.pos.x == pos.x &&
                    item.pos.y == pos.y)
                {
                    return item;
                }
            }
            return null;
        }

        // 레벨 1 맵 생성
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


            // 아이템 생성, 위치 선정
            Item key = new Key();
            key.pos = new Position(5, 5);
            items.Add(key);

            Item box = new TreasureBox();
            box.pos = new Position(12, 1);
            items.Add(box);
        }


        }
}
