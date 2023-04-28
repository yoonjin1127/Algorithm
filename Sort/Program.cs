namespace Sort
{
    internal class Program
    {
        /********************
         * 선형 정렬
         * 
         * 1개의 요소를 재위치시키기 위해 전체를 확인하는 정렬
         * n개의 요소를 재위치시키기 위해 n개를 확인하는 정렬
         * 시간복잡도 : 0(N^2)
         * 
         * 상대적으로 속도가 느림
         ********************/

        // <선택정렬>
        // 데이터 중 가장 작은 값부터 하나씩 선택하여 정렬
        // 가장 작은 값을 0번째 값과 교체, 그 다음으로 작은 값을 1번째 값과 교체...를 반복

        public static void SelectionSort(IList<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                int minIndex = i;
                for (int j = 0; j < list.Count; j++) 
                { 
                    if (list[j] < list[minIndex])
                        minIndex = j;
                }
                Swap(list, i, minIndex);
            }
        }

        // <삽입정렬>
        // 데이터를 하나씩 꺼내어 정렬된 자료 중 적합한 위치에 삽입하여 정렬
        // 가장 작은 수를 맨 앞으로 한 칸씩 밀어냄(교체를 반복)
        public static void InsertionSort(IList<int> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                int key = list[i];
                int j;
                for (j = i - 1; j >= 0 && key < list[j]; j--)
                {
                    list[j + 1] = list[j];
                }
                list[j + 1] = key;
            }
        }
        // <버블정렬>
        // 서로 인접한 데이터를 비교하여 정렬
        // 계속해서 큰 걸 앞으로 밀어낸다
        // LinkedList같은 연결리스트에서도 사용이 가능하다(분할정복에서는 불가능)
        public static void BubbleSort(IList<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 1; j < list.Count; j++)
                {
                    if (list[j - 1] > list[j])
                        Swap(list, j - 1, j);
                }
            }
        }

        /******************************************************
		 * 분할정복 정렬
		 * 
		 * 1개의 요소를 재위치시키기 위해 전체의 1/2를 확인하는 정렬
		 * n개의 요소를 재위치시키기 위해 n/2개를 확인하는 정렬
		 * 시간복잡도 : O(NlogN)
		 ******************************************************/

        // <힙정렬>
        // 힙(우선순위 큐)을 이용하여 우선순위가 가장 높은 요소부터 가져와 정렬
        // 같은 숫자끼리도 규칙을 지키는 힙의 특성상, 불안정 정렬(깨지는 정렬)

        // <컴퓨터의 참조 지역성 원리 ~퀵정렬이 왜 힙정렬보다 빠른가?~>
        // 힙정렬의 경우 불러오기 과정, 재조정을 반복해야 하기 때문에(원소 임의 접근)
        // 메모리 영역, 즉 캐시에 부담을 줘서 참조지역성의 특성을 활용한 캐시의 성능 가속을 얻기 어려움
        // 그렇기에 실제로는 퀵정렬(인접한 원소 접근)보다 느릴 수 있음

        // <캐시>
        // 캐시란 프로그램이 수행될 때 나타나는 지역성을 이용하여
        // 메모리나 디스크에서 사용되었던 내용을 특별히 빠르게 접근할 수 있는 곳에
        // 보관하고 관리함으로써 이 내용을 다시 필요로 할 때 보다 빠르게 참조하도록 하는 것이다.
        // 즉, 사용되었던 데이터는 다시 사용될 가능성이 높다는 개념을 이용한 것이다.
        // 다시 사용될 확률이 높은 아이들을 좀 더 빠르게 접근 가능한 저장소를 사용한다는 개념이다.



        public static void HeapSort(IList<int> list)
        {
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();

            for (int i = 0; i < list.Count; i++)
            {
                pq.Enqueue(list[i], list[i]);       // 데이터를 우선 모두 집어넣음
            }

            for (int i = 0; i < list.Count; i++)
            {
                list[i] = pq.Dequeue();             // 데이터를 꺼냄 (우선순위가 높은 순으로 꺼내짐)
            }
        }

        // <합병정렬>
        // 데이터를 2분할하여 정렬 후 합병
        // 큰 덩어리를 반절로 나누는 걸 끝까지 반복하고, 정렬 후 다시 붙임
        // 다른 정렬과 다르게 메모리적 부담이 있음(메모리를 희생하고 시간을 얻음)
        public static void MergeSort(IList<int> list, int left, int right)
        {
            if (left == right) return;      // 하나짜리이므로 바로 종료

            int mid = (left + right) / 2;
            MergeSort(list, left, mid);
            MergeSort(list, mid + 1, right);
            Merge(list, left, mid, right);  // 다시 합침
        }

        public static void Merge(IList<int> list, int left, int mid, int right)
        {
            List<int> sortedList = new List<int>();
            int leftIndex = left;
            int rightIndex = mid + 1;

            // 분할 정렬된 List를 병합
            while (leftIndex <= mid && rightIndex <= right)
            {
                if (list[leftIndex] < list[rightIndex])     // 하나씩 비교하며 리스트에 추가
                    sortedList.Add(list[leftIndex++]);
                else
                    sortedList.Add(list[rightIndex++]);
            }

            if (leftIndex > mid)    // 왼쪽 List가 먼저 소진 됐을 경우
            {
                for (int i = rightIndex; i <= right; i++)
                    sortedList.Add(list[i]);
            }
            else  // 오른쪽 List가 먼저 소진 됐을 경우
            {
                for (int i = leftIndex; i <= mid; i++)
                    sortedList.Add(list[i]);
            }

            // 정렬된 sortedList를 list로 재복사
            for (int i = left; i <= right; i++)
            {
                list[i] = sortedList[i - left];
            }
        }

        // <퀵정렬>
        // 하나의 피벗을 기준으로 작은값과 큰값을 2분할하여 정렬
        // 교체를 하는 것이지, 따로 배열을 생성하지는 않기 때문에 추가적 메모리 사용은 없음
        // 그러나 최악의 경우 시간복잡도 O(n^2)      (ex: 5 4 3 2 1 같은 역순 배열에서)
        // 불안정 정렬(깨지는 정렬)

        public static void QuickSort(IList<int> list, int start, int end)
        {
            if (start >= end) return;

            int pivotIndex = start;             // 정해진 것은 없으나 보통 맨 앞을 피벗(기준)으로 잡음
            int leftIndex = pivotIndex + 1;
            int rightIndex = end;

            while (leftIndex <= rightIndex) // 엇갈릴때까지 반복
            {                               // 엇갈릴 때 = 피벗을 기준으로 (좌, 우) = (작은 수들, 큰 수들)로 나뉘었을 때
                // pivot보다 큰 값을 만날때까지
                while (list[leftIndex] <= list[pivotIndex] && leftIndex < end)
                    leftIndex++;
                while (list[rightIndex] >= list[pivotIndex] && rightIndex > start)
                    rightIndex--;

                if (leftIndex < rightIndex)     // 엇갈리지 않았다면
                    Swap(list, leftIndex, rightIndex);
                else    // 엇갈렸다면
                    Swap(list, pivotIndex, rightIndex);
            }

            QuickSort(list, start, rightIndex - 1);     // 피벗 기준 왼쪽도 퀵소트 적용
            QuickSort(list, rightIndex + 1, end);       // 피벗 기준 오른쪽도 퀵소트 적용
        }


        static void Main(string[] args)
        {

        }

        private static void Swap(IList<int> list, int left, int right)
        {
            int temp = list[left];
            list[left] = list[right];
            list[right] = temp;
        }

    }
}