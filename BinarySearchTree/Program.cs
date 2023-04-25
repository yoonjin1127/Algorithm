namespace BinarySearchTree
{
    internal class Program
    {
        /*************
         * 트리 (Tree)
         * 
         * 계층적인 자료를 나타내는데 자주 사용되는 자료구조
         * 부모노드가 0개 이상의 자식노드를 가질 수 있음
         * 한 노드에서 출발하여 다시 자기 자신의 노드로 돌아오는 순환구조를 가질 수 없음
         *************/

        /*************
         * 이진탐색트리 (BinarySearchTree)
         * 
         * 이진속성과 탐색속성을 적용한 트리
         * 이진탐색을 통한 탐색영역을 절반으로 줄여가며 탐색 가능
         * 이진 : 부모노드는 최대 2개의 자식노드들을 가질 수 있음
         * 탐색 : 자신의 노드보다 작은 값들은 왼쪽, 큰 값들은 오른쪽에 위치
         **************/

        // <이진탐색트리의 시간복잡도>
        // 접근     탐색     삽입      삭제
        // O(log n)		O(log n)	O(log n)	O(log n)

        void BinarySearchTree()
        {
            SortedSet<int> sortedSet = new SortedSet<int>();

            // 추가
            sortedSet.Add(1);
            sortedSet.Add(2);
            sortedSet.Add(3);
            sortedSet.Add(4);
            sortedSet.Add(5);

            // 탐색
            int searchValue1;
            bool find = sortedSet.TryGetValue(3, out searchValue1);     // 탐색 시도

            // 삭제
            sortedSet.Remove(3);
        }

        static void Main(string[] args)
        {

        }
    }
}