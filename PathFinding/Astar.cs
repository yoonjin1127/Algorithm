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


        const int CostStraight = 10;
        const int CostDiagonal = 14;

        // 포인트 배열 생성
        // 자연스러운 움직임을 위해 대각선을 추가한 8방향 Astar 구현
        static Point[] Direction =
        {
            new Point ( 0, +1 ),    // 상
            new Point ( 0, -1 ),    // 하
            new Point ( -1, 0 ),    // 좌
            new Point ( +1, 0 ),    // 우

            new Point ( -1, +1 ),    // 좌상
            new Point ( -1, -1 ),    // 좌하
            new Point ( +1, +1 ),    // 우상
            new Point ( +1, -1 ),    // 우하
            
        };



        // bool형 2차원 배열과 시작, 끝 위치(좌표)를 요구
        // 경로는 출력형(Point들의 집합)
        public static bool PathFinding(bool[,] tileMap, Point start, Point end, out List<Point> path)
        {
            // 인접행렬과의 차이: x와 y의 사이즈가 다를 수 있다
            int ySize = tileMap.GetLength(0);
            int xSize = tileMap.GetLength(1);
            
            // ex: 2,1이 True라면 방문되었음
            bool[,]visited = new bool[ySize, xSize];
            ASNode[,] nodes = new ASNode[ySize, xSize];     // 정점들을 넣을 수 있는 배열 생성
            
            // 계속해서 f값이 가장 낮은 정점을 찾아야하므로, 우선순위큐를 사용함
            PriorityQueue<ASNode, int>nextPointPQ = new PriorityQueue<ASNode, int>();

            // 0. 시작 정점을 생성하여 추가
            ASNode startNode = new ASNode(start, null, 0, Heuristic(start, end));    // 유일하게 부모정점이 없는 (0,0)
            nodes[startNode.point.y, startNode.point.x] = startNode;
            nextPointPQ.Enqueue(startNode, startNode.f);            // f값을 기준으로 집어넣음 (동일한 경우 h가 낮고 g가 높은 걸 우선시)


            // 0이 될때까지 반복
            while(nextPointPQ.Count > 0) 
            { 
                // 1. 다음으로 탐색할 정점 꺼내기
                ASNode nextNode = nextPointPQ.Dequeue();

                // 2. 방문한 정점은 방문표시
                visited[nextNode.point.y, nextNode.point.x] = true;

                // 3. 탐색할 정점이 도착지인 경우
                // 도착했다고 판단, 경로 반환
                if (nextNode.point.x == end.x && nextNode.point.y == end.y)     // 출발점 == 도착점
                {
                    // 역순으로 넣어줌
                    Point? pathPoint = end;
                    path = new List<Point>();

                    while (pathPoint != null)       // 지금 정점의 노드가 시작 노드일 때까지라는 말과 동일
                    {
                        Point point = pathPoint.GetValueOrDefault();        // pathPoint가 nullable이기 때문에 설정
                        path.Add(point);
                        pathPoint = nodes[point.y, point.x].parent;         // 다음 정점의 위치는 해당정점의 부모
                    }

                    // 다 추가했다면 (부모정점이 없을 때까지 == 시작정점) 경로를 뒤집음
                    path.Reverse();
                    return true;
                }
               

                // 4. Astar 탐색을 진행
                // 상하좌우를 나눌 필요없이, 포인트 배열 디렉션을 사용해 4방향 탐색
               for (int i = 0; i < Direction.Length; i++)
                {
                    int x = nextNode.point.x + Direction[i].x;
                    int y = nextNode.point.y + Direction[i].y;

                    // 4-1. 탐색하면 안되는 경우 제외
                    // 맵을 벗어났을 경우
                    if (x < 0 || x >= xSize || y < 0 || y >= ySize)
                        // break하면 배열이 그냥 끝나버림
                        continue;
                    // 탐색할 수 없는 정점일 경우
                    else if (tileMap[y, x] == false)
                        continue;
                    // 이미 방문한 정점일 경우
                    else if (visited[y, x])                  
                        continue;
                    // 앞과 양 옆이 막혀있을 때

                    // 4-2. 점수 계산
                    int g = nextNode.g + 10;        // 탐색했던 노드에 +10(직선 가중치)
                    int h = Heuristic(new Point(x, y), end);
                    ASNode newNode = new ASNode(new Point(x, y), nextNode.point, g, h);

                    // 4-3. 정점의 갱신이 필요한 경우 새로운 정점으로 할당
                    if (nodes[y,x] == null ||     // 점수계산이 되지 않은 정점이거나
                        nodes[y,x].f > newNode.f) // 가중치가 더 높은 정점인 경우 (새 정점의 f값이 더 낮은 경우)
                    {
                        nodes[y, x] = newNode;
                        nextPointPQ.Enqueue(newNode, newNode.f);
                    }
                }

            }
            // 못 찾은 경우에는 false 반환
            path = null;
            return false;
        }



        // 휴리스틱(Heuristic) : 최상의 경로를 추정하는 순위값, 휴리스틱에 의해 경로탐색 효율이 결정됨
        // 휴리스틱을 전방향 가중치를 1로 설정하는 경우, 다익스트라와 동일해짐
        // 시작과 끝을 입력하면 h값을 출력함
        private static int Heuristic(Point start, Point end)
        {
            int xSize = Math.Abs(start.x - end.x);  // 가로로 가야하는 횟수
            int ySize = Math.Abs(start.y - end.y);  // 세로로 가야하는 횟수

            // 맨해튼 거리 : 가로 세로를 통해 이동하는 거리
            // return CostStraight * (xSize + ySize);

            // 유클리드 거리 : 대각선을 통해 이동하는 거리 (피타고라스의 정리)
            return CostStraight * (int)Math.Sqrt(xSize * xSize + ySize * ySize);
        }



        // 정점 설정
        // 구조체 대신 클래스를 사용한 이유는 구조체는 빈 데이터를 가질 수 없는데
        // 정점은 비어있을 수도 있기 때문이다.
        private class ASNode
        {
            // 정점도 좌표값을 가지고 있으므로 Point를 넣어줌
            public Point point;       // 현재 정점 위치

            public Point? parent;      // 이 정점을 탐색한 정점
                                       // 부모정점이 없을 수도 있기에 ?(nullable)을 넣어줌

            public int f;       // f(x) = g(x) + h(x) : 총 거리
            public int g;       // 현재까지의 거리, 즉 지금까지의 경로 가중치
            public int h;       // 휴리스틱 : 앞으로 예상되는 거리, 목표까지 추정 경로 가중치

           
            // 생성자 함수
            // f는 g와 h로 인해 자동결정되므로, 매개변수에서 제해도 괜찮음
            public ASNode(Point point, Point? parent, int g, int h)
            {
                this.point = point;
                this.parent = parent;
                this.g = g;
                this.h = h;
                this.f = g + h;     // 둘의 합으로 정의
            }
        }
    }
    // 좌표 구조체
    public struct Point
    {
        public int x;
        public int y;
        
        // x, y를 가지고 있는 생성자 함수
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
