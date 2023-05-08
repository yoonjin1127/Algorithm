using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SelfTextRPG
{
    public class NPC
    {
        // NPC 이름
        public string name;

        // NPC 아이콘
        public char icon = '♧';

        // NPC 위치
        public Position pos;

        public string image;
        public int curHp;
        public int maxHp;
        public int ap;
        public int dp;
    }
}
