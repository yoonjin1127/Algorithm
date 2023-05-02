namespace ShortestPath
{
    internal class Program
    {
        const int INF = 99999;
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
                     { 0, 6, 14, 7, 20, 17, 10, 11},
                     { 6, 0, 15  },
                     { 0,  },
                     { 0,  },
                     { 0,  },
                     { 0,  },
                     { 0,  },
                     { 0,  }

                };
        }
    }
}