using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    internal class Graph
    {
        /************************
         * 그래프 (Graph)
         * 
         * 정점(Vertex)의 모음과 이 정점을 잇는 간선(Edge)의 모음의 결합
         * 한 노드에서 출발하여 다시 자기 자신의 노드로 돌아오는 순환구조를 가짐  (안 가지면 트리)
         * 간선의 방향성에 따라 단방향 그래프, 양방향 그래프가 있음
         * 간선의 가중치에 따라 연결 그래프, 가중치 그래프가 있음
         * 
         * 경로탐색, 길찾기에 자주 사용됨
         *************************/

        // <인접행렬 그래프>
        // [시작정점, 끝정점] ex) [1,3] 1정점 -> 3정점

        // 그래프 내의 각 정점의 인접 관계를 나타내는 행렬
        // 2차원 배열을 [출발정점, 도착정점]으로 표현
        // 장점 : 인접여부 접근이 빠름 O(1)
        // 단점 : 메모리 사용량이 많음 O(N^2)

        bool[,] matrixGraph1 = new bool[5, 5]
        {
            // [0,0]  [0,1] [0,2] [0,3] [0,4]
            { false, false, false, false,  true },
            { false, false,  true, false, false },
            { false,  true, false,  true, false },
            { false, false,  true, false,  true },
            {  true, false, false,  true, false },
        };

        const int INF = int.MaxValue;   // INF(Infinity)를 무한으로 설정해, 단절됨을 표현,
        int[,] matrixGraph2 = new int[5, 5]
        {
            { 0, 132, 16, INF, INF },
            { 0, 132, 16, INF, INF },
            { 0, 132, 16, INF, INF },
            { 0, 132, 16, INF, INF },
            { 0, 132, 16, INF, INF },
        };

        public void Test()
        {
            if (matrixGraph1[1, 3]) ;
                // 갈 수 있음
        }

        // <인접리스트 그래프>
        // 그래프 내의 각 정점의 인접 관계를 표현하는 리스트
        // 인접한 간선만을 리스트에 추가하여 관리
        // 장점 : 메모리 사용량이 적음
        // 단점 : 인접여부를 확인하기 위해 리스트 탐색이 필요
        public class Node
        {
            List<List<int>> listGraph1;       // 연결 그래프
            List<List<(int, int)>> listGraph12;  // 가중치 그래프

            public void CreateGraph()
            {
                listGraph1 = new List<List<int>>();
                for (int i = 0; i < 5; i++)
                { 
                    listGraph1.Add(new List<int>());
                }
                listGraph1[0].Add(1);        // 0번째 노드에 1번 노드 추가 (0번, 1번 사이에 간선 생성)
                listGraph1[1].Add(2);    
                listGraph1[1].Add(3);    
            }
        }
    }
}
