using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    // 추상클래스 Item 생성
    public abstract class Item
    {
        // 아이템의 무게, 설명, 아이콘, 위치, 무게 설정
        public string name;
        public string description;
        public char icon = '★';
        public Position pos;
        public int weight;

        // 추상함수로 아이템 사용 함수 구현 
        public abstract void Use();
    }
}
