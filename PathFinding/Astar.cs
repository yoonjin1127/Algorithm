using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathFinding
{
    internal class Astar
    {
        /************************************
         * A* 알고리즘
         * 
         * 다익스트라 알고리즘을 확장하여 만든 최단경로 탐색알고리즘
         * 경로 탐색의 우선순위를 두고 유망한 해부터 우선적으로 탐색
         * 전방향을 탐색하는 다익스트라와 다르게 오른쪽 아래를 탐색
         * 
         * 완전한 최단 경로를 찾지 않고, 최단 경로의 근사값을 찾아내는 것이 목표
         * 
         * 1. f값이 가장 작은 정점을 찾음
         * 2. 탐색한 정점의 f값을 구함
         * 
         * 장애물이 있는 상황에서, 장애물이 없다고 가정하더라도
         * 아래쪽이 막혀있기때문에 오른쪽으로 갈수록 총 소요 시간이 증가한다.
         ************************************/

        // f = g+h  (총 거리)
        // g = 걸린 거리 
        // h = 예상 거리 (휴리스틱)
    }
}
