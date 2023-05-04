﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    // 스킬 구조체 생성
    public struct Skill
    {
        public string name;
        public Action<Monster> action;

        public Skill(string name, Action<Monster> action)
        {
            this.name = name;
            this.action = action;
        }
    }
}
