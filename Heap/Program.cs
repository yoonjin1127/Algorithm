namespace Heap
{
    internal class Program
    {
        /******************
         * 힙 (Heap)
         * 
         * 부모 노드가 항상 자식노드보다 우선순위가 높은 속성을 만족하는 트리기반의 자료구조
         * 많은 자료 중 우선순위가 가장 높은 요소를 빠르게 가져오기 위해 사용
         *******************/

        // Enqueue : 큐에 값을 추가 (선입)
        // Dequeue : 큐에 값을 제거 (선출)

        // 스택은 선입후출

        // PriorityQueue(우선순위 큐)

        // !트리기반 자료구조의 조건!
        // 1. 부모 + 여러자식
        // 2. 역순은 x (순환구조가 아니어야함)

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

        static void Test1()             // 실수로 비교하고 문자열을 출력하는 우선순위 큐
        {
            PriorityQueue<string, float> ascendingFPQ = new PriorityQueue<string, float>();

            ascendingFPQ.Enqueue("야호", 4.5f);
            ascendingFPQ.Enqueue("안야호", 5.5f);

            while (ascendingFPQ.Count > 0)
            {
                Console.WriteLine(ascendingFPQ.Dequeue());
            }

        }

        static void Main(string[] args)
        {
            PriorityQueue();
            Test1();
        }
    }
}