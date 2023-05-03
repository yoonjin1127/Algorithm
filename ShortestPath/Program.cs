namespace ShortestPath
{
    internal class Program
    {
        const int INF = 99999;      // 무한대 값

        static void Main(string[] args)
        {
            int[,] graph = new int[8, 8]    // 0~7까지의 정점
            // 0에서 1까지의 거리는 6
            // 0에서 2까지의 거리는 14
            // 0에서 3까지의 거리는 7
            // 0에서 4까지의 거리는 20
            // 0에서 5까지의 거리는 17
            // 0에서 6까지의 거리는 10
            // 0에서 7까지의 거리는 11
                {
                     {  0,  6, 14,  7, 20, 17, 10, 11 },
                     {  6,  0,  8,  7, INF, INF, INF, INF },
                     { 14,  8,  0, INF,  6,  6, INF, INF },
                     {  7,  7, INF,  0, INF, INF, INF,  8 },
                     { 20, INF,  6, INF,  0, INF, INF, INF },
                     { 17, INF,  6, INF, INF,  0, INF,  6 },
                     { 10, INF, INF, INF, INF, INF,  0,  1 },
                     { 11, INF, INF,  8, INF,  6,  1,  0 },

                };

            int[] distance;     // 거리
            int[] path;         // 경로

            //  다익스트라 알고리즘을 이용한 최단 경로 계산
            Dijkstra.ShortestPath(graph, 0, out distance, out path);
            Console.WriteLine("<Dijkstra>");
            PrintDijkstra(distance, path);

            Console.WriteLine();


        }

        private static void PrintDijkstra(int[] distance, int[] path)
        {
            Console.Write("Vertex");
            Console.Write("\t");
            Console.Write("dist");
            Console.Write("\t");
            Console.WriteLine("path");

            for (int i = 0; i < distance.Length; i++)
            {
                Console.Write("{0,3}", i);
                Console.Write("\t");
                if (distance[i] >= INF)
                    Console.Write("INF");
                else
                    Console.Write("{0,3}", distance[i]);
                Console.Write("\t");
                if (path[i] < 0)
                    Console.WriteLine("  X ");
                else
                    Console.WriteLine("{0,3}", path[i]);
            }
        }
    }
}