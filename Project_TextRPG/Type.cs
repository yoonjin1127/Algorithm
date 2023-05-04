using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    // 플레이어의 위치를 나타내는 구조체
    public struct Position
    {
        public int x;
        public int y;

        // x, y는 항상 함께 사용되므로, 생성자 함수에 함께 넣는다
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    // 방향은 열거형으로 설정
    public enum Direction { Left, Right, Up, Down }
}
