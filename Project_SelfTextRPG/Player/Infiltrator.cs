using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SelfTextRPG
{
    public class Infiltrator : Player
    {
        // 열쇠공 기본 스탯 설정
        public Infiltrator() : base(JobType.Infiltrator) 
        {
            SetInfo(70, 20);
        }
    }
}
