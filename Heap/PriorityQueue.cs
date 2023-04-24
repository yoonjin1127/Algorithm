using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    // 완전 이진트리는 배열로도 만들 수 있다

    /***********
     * 이진트리의 이동법
     * 
     * 왼쪽 : index * 2 + 1 (ex: 1번 노드에서 3번 노드로 이동)
     * 오른쪽 : index * 2 + 2 (ex: 1번 노드에서 4번 노드로 이동)
     * 부모: (index - 1) / 2 (ex: 3번 노드에서 1번 노드로 이동)
    *******************/

    // 이진트리에서 우선순위가 높은 녀석이 위에 있는 상태를 힙 상태라고 함

    // 힙에서 우선순위가 더 높은 노드가 추가됐을 때, 부모노드와 교체됨(계속해서 승격)

    internal class PriorityQueue<TElement>
    {
        private struct Node
        {
            public TElement element;
            public int priority;
        }

        private List<Node> nodes;

        public PriorityQueue() 
        { 
            this.nodes = new List<Node>();
        }

        public int Count { get { return nodes.Count;} }

        public void Enqueue(TElement element, int priority)
        {
            Node newNode = new Node() { element = element, priority = priority };

            // 1. 가장 뒤에 데이터 추가
            nodes.Add(newNode);
            int newNodeIndex = nodes.Count - 1;

            // 2. 새로운 노드를 힙상태가 유지되도록 승격 작업 반복
            while (newNodeIndex > 0)
            {
                // 2-1. 부모 노드 확인
                int parentIndex = GetParentIndex(newNodeIndex);
                Node parentNode = nodes[parentIndex];

                // 2-2. 자식 노드가 부모 노드보다 우선순위가 높으면 교체
                if(newNode.priority < parentNode.priority)  // 기본적으로 내림차순
                {
                    nodes[newNodeIndex] = parentNode;   // 새 자식노드 위치에 부모노드를 넣음
                    nodes[parentIndex] = newNode;       // 부모노드 위치에 새 자식노드를 넣음
                    newNodeIndex = parentIndex;         // 부모노드 위치를 새 자식노드 위치에 넣음
                }
                else
                {
                    break;
                }
            }
        }

        public TElement Dequeue()
        {
            Node rootNode = nodes[0];

            // 1. 가장 마지막 노드를 최상단으로 위치
            Node lastNode = nodes[nodes.Count - 1];     // 마지막 노드(노드 길이 - 1 번째)
            nodes[0] = lastNode;
            nodes.RemoveAt(nodes.Count - 1);

            int index = 0;

            // 2. 자식 노드들과 비교하여 더 작은 자식과 교체
            while (index < nodes.Count)
            {
                int leftChildIndex = index * 2 + 1;
                int rightChildIndex = index * 2 + 2;

                // 2-1. 자식이 둘다 있는 경우
                if(rightChildIndex < nodes.Count)
                {
                    // 2-1-1. 왼쪽 자식과 오른쪽 자식을 비교하여 더 우선순위가 높은 자식을 선정
                    int lessChildIndex = nodes[leftChildIndex].priority < nodes[rightChildIndex].priority
                    ? leftChildIndex: rightChildIndex;
                    
                    // 2-1-2. 더 우선순위가 높은 자식과 부모 노드를 비교하여
                    // 부모가 우선순위가 더 낮은 경우 바꾸기
                    if (nodes[lessChildIndex].priority < nodes[index].priority)
                    {
                        nodes[index] = nodes[lessChildIndex];
                        nodes[lessChildIndex] = lastNode;
                        index = lessChildIndex;
                    }
                    else
                    {
                        break;
                    }
                }

                // 2-2. 자식이 하나만 있는 경우 == 왼쪽 자식만 있는 경우
                else if (leftChildIndex < nodes.Count)
                {
                    if (nodes[leftChildIndex].priority < nodes[index].priority)     // 교체해야 하는 상황
                    {
                        nodes[index] = nodes[leftChildIndex];
                        nodes[leftChildIndex] = lastNode;
                        index = leftChildIndex;
                    }
                    else
                    {
                        break;
                    }    
                }

                // 2-3. 자식이 없는 경우
                else
                {
                    break;
                }
            }

            return rootNode.element;
        }

        private int GetParentIndex(int childIndex)
        {
            return (childIndex - 1) / 2;
        }

        private int GetLeftChildIndex(int parentIndex)     // 함수화
        {
            return parentIndex * 2 + 1;
        }

        private int GetRightChildIndex(int parentIndex)
        {
            return parentIndex * 2 + 2;
        }
    }
}
