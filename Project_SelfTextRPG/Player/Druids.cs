using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SelfTextRPG
{
    public class Druids : Player
    {
        // 드루이드 기본 스탯 설정
        public Druids() : base(JobType.Druids)
        {
            CurHp = 100;
            MaxHp = 120;
            DP = 30;
        }
    }
}
