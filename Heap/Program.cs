﻿namespace Heap
{
    internal class Program
    {
        /******************
         * 힙 (Heap)
         * 
         * 부모 노드가 항상 자식노드보다 우선순위가 높은 속성을 만족하는 트리기반의 자료구조
         * 많은 자료 중 우선순위가 가장 높은 요소를 빠르게 가져오기 위해 사용
         *******************/

        static void PriorityQueue()
        {
            PriorityQueue<string, int> acsendingPQ = new PriorityQueue<string, int>();
            // 비교연산이 가능한 녀석~~

            acsendingPQ.Enqueue("감자", 3);
            acsendingPQ.Enqueue("양파", 5);
            acsendingPQ.Enqueue("당근", 1);
            acsendingPQ.Enqueue("토마토", 2);
            acsendingPQ.Enqueue("마늘", 4);

            while (acsendingPQ.Count > 0) 
            {
                Console.WriteLine(acsendingPQ.Dequeue());    // 우선순위가 높은 순서대로 데이터 출력
            }

            PriorityQueue<string, int> desendingPQ 
                = new PriorityQueue<string, int>(Comparer<int>.Create((a,b)=>b-a));

            desendingPQ.Enqueue("왼쪽", 70);
            desendingPQ.Enqueue("위쪽", 100);
            desendingPQ.Enqueue("오른쪽", 10);
            desendingPQ.Enqueue("아래쪽", 20);

            while (desendingPQ.Count > 0)
            {
                Console.WriteLine(desendingPQ.Dequeue());    // 우선순위가 높은 순서대로 데이터 출력
            }
        }

        static void Main(string[] args)
        {
            PriorityQueue();
        }
    }
}