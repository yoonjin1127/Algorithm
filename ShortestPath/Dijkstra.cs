using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath
{
    internal class Dijkstra
    {
        /*********************
         *  다익스트라 알고리즘(Dijkstra Algorithm)
         *  
         *  특정한 노드에서 출발하여 다른 노드로 가는 각각의 최단 경로를 구함
         *  방문하지 않은 노드 중에서 최단 거리가 가장 짧은 노드를 선택 후,
         *  해당 노드를 거쳐 다른 노드로 가는 비용 계산
         *  탐욕적 알고리즘
         **********************/

        const int INF = 99999;      // 무한대 상수 설정 (MaxValue를 쓰지 않는 이유는 오버 플로우 방지)

        public static void ShortestPath(in int[,] graph, int start, out int[] distance, out int[] path)
        {
            int size = graph.GetLength(0);
            bool[] visited = new bool[size];

            distance = new int[size];
            path = new int[size];
            for (int i = 0; i<size; i++) 
            {
                distance[i] = INF;
                path[i] = distance[i] < INF ? start : -1;
            }
            for (int i = 0; i<size; i++) 
            {
                // 1. 방문하지 않은 정점 중 가장 가까운 정점부터 탐색
                int next = -1;
                int minCost = INF;
                for (int j = 0; j < size; j++) 
                {
                    if (!visited[j] && 
                        distance[j] < minCost)      // 방문하지 않았고, 최소값보다 작을 때
                    {
                        next = j;
                        minCost = distance[j];
                    }
                }

                // 2. 직접 연결된 거리보다 거쳐서 더 짧아진다면 갱신
                for (int j = 0; j<size; j++)
                {
                    // distance[j] : 목적지까지 직접 연결된 거리
                    // distance[next] : 탐색중인 정점까지의 거리
                    // graph[next, j] : 탐색중인 정점부터 목적지의 거리
                    if (distance[j] > distance[next] + graph[next, j])
                    {
                        distance[j] = distance[next] + graph[next, j];       // 갱신
                        path[j] = next;
                    }
                }
                visited[next] = true;       // 모든 방문을 마친 후 탐색 끝
            }
        }
    }
}
