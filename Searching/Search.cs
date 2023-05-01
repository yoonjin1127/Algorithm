using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    internal class Search
    {
        // <순차 탐색>
        public static int SequentialSearch<T>(in IList<T> list, in T item)where T : IEquatable<T>    // 똑같은지 아닌지가 중요
        { 
            for (int i = 0; i < list.Count; i++)            // 비교했을 때 동일한 곳이라면 찾은 것
            {                                               // 처음부터 끝까지 둘러봄 (웬만한 자료형은 다 사용가능)
                if (item.Equals(list[i]))       
                    return i;                             
            }
            return -1;                                      // 못찾으면 -1 반환
        } 

       // <이진 탐색>
       public static int BinarySearch<T>(in IList<T> list, in T item)where T : IComparable
        {
            int low = 0;
            int high = list.Count - 1;

            while (low <= high)
            {
                int middle = (low + high) >> 2;     // 더하기, 곱하기보다 비트연산자가 가장 빠름
                                                    // /2와 동일
                int compare = list[middle].CompareTo(item);

                if (compare < 0)                    // 비교한 녀석이 더 작을 때
                    low = middle + 1;               // 더 큰 위치까지 비교하기 위해

                else if (compare > 0)               // 비교한 녀석이 더 클 때
                    high = middle - 1;              // 더 작은 위치를 비교하기 위해
                else
                    return middle;                  // 답을 찾았을 때
            }
            return -1;                              // 답이 없을 때
        }

        // 그래프 서치 알고리즘 DFS, BFS
        // 둘의 차이점 숙지 요망

        // <깊이 우선 탐색 (Depth-First Search)>
        // 그래프의 분기를 만났을 때 최대한 깊이 내려간 뒤,
        // 더이상 깊이 갈 곳이 없을 경우 다음 분기를 탐색
        // 백트래킹과 유사 (분할 정복)

        public static void DFS(bool[,] graph, int start, out bool[] visited, out int[] parents)
        {
            visited = new bool[graph.GetLength(0)];
            parents = new int[graph.GetLength(0)];

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                visited[i] = false;     // 한 번도 방문 x
                parents[i] = -1;           // 경로가 x
            }
            SearchNode(graph, start, visited, parents);
        }

        private static void SearchNode(bool[,] graph, int start, bool[] visited, int[] parents)
        {
            visited[start] = true;
            for (int i = 0;i < graph.GetLength(0);i++)
            {
                if (graph[start, i] &&             // 연결되어있는 정점이며,
                    !visited[i])                   // 방문한 적 없는 정점
                {
                    parents[i] = -1;
                    SearchNode(graph, i, visited, parents);
                }
            }
        }

        // <너비 우선 탐색 (Breadth-First Search)>
        // 그래프의 분기를 만났을 때 모든 분기를 하나씩 저장하고,
        // 저장한 분기를 한번씩 거치면서 탐색
        // 따지자면 동적계획법과 유사 (Dynamic Programming)
        // 큐(선입선출 원통형)로 구현 가능
        public static void BFS(bool[,] graph, int start, out bool[] visited, int[] parents)
        {
            visited = new bool[graph.GetLength(0)];
            parents = new int[graph.GetLength(0)];

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                visited[i] = false;
                parents[i] = -1;
            }

            Queue<int> bfsQueue = new Queue<int>();

            bfsQueue.Enqueue(start);
            while (bfsQueue.Count > 0) 
            {
                int next = bfsQueue.Dequeue();
                visited[next] = true;

                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    if (graph[next, i] &&       // 연결되어 있는 정점이며,
                        !visited[i])            // 방문한적 없는 정점
                    {
                        parents[i] = next;
                        bfsQueue.Enqueue(i);
                    }
                }
            }
        }
        
    }
}
