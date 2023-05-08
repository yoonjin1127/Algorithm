using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SelfTextRPG
{
    public class Necromancer : Player
    {
        // 네크로맨서 기본 스탯 설정
        public Necromancer() : base(JobType.Necromancer)
        {
            SetInfo(100, 30);
        }
    }
}
