using System.Security.Cryptography.X509Certificates;

namespace DesignTechnique
{
    internal class Program
    {
        /******************
         * 알고리즘 설계기법 (Algorithm Design Technique)
         * 
         * 어떤 문제를 해결하는 과정에서 해당 문제의 답을 효과적으로 찾아가기 위한 전략과 접근 방식
         * 문제를 풀 때 어떤 알고리즘 설계 기법을 쓰는지에 따라 효율성이 막대하게 차이
         * 문제의 성질과 존건에 따라 알맞은 알고리즘 설계기법을 선택하여 사용
         *******************/
        public static void Move(int count, int start, int end)
        {
            if (count == 1) 
            {
                // 그냥 이동
                int circle = stick[start].Pop();
                stick[end].Push(circle);                // circle = 원형 판
                Console.WriteLine($"{start} 스틱에서 {end} 스틱으로 {circle} 이동");
                return;
            }

           int other = 3 - start - end;

            // 5층 탑일 때
            Move(count - 1, start, other);      // 4개를 0번 스틱에서 1번 스틱으로 이동 (맨 밑 하나 빼고 1번 스틱으로 이동)
            Move(1, start, end);                // 1개를 0번 스틱에서 2번 스틱으로 이동 (맨 밑에 남아있던 하나를 2번 스틱으로 이동)
            Move(count - 1, other, end);        // 4개를 1번 스틱에서 2번 스틱으로 이동 (1번 스틱에 보냈던 것들을 2번 스틱에 이동시킴)
        }

        public static Stack<int>[] stick;

        static void Main1(string[] args)
        {
            // int circleCount = 7;      // 7층 하노이탑

            // 선입후출, 후입선출의 스택 자료구조를 이용
            stick = new Stack<int>[3];
            for (int i = 0; i < stick.Length; i++) 
            {
                stick[i] = new Stack<int>();    
            }

            for (int i = 5; i > 0; i--)
            {
                stick[0].Push(i);       // 하노이 탑에 5부터 1까지 순서대로 집어넣음
            }
            Move(5, 0, 2);              // 5층 탑을 0번 스틱에서 2번 스틱으로 이동
        }

        static void Main(string[] args)
        {
            Backtracking backtracking = new Backtracking();
            bool[,] board = new bool[4,4];
            backtracking.NQueen(board);
        }
    }
}