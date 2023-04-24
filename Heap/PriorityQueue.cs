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

    internal class PriorityQueue<TElement, TPriority>
    {
        private struct Node
        {
            public TElement element;
            public TPriority priority;
        }

        private List<Node> nodes;
        private IComparer<TPriority> comparer;

        public PriorityQueue() 
        { 
            this.nodes = new List<Node>();
            this.comparer = Comparer<TPriority>.Default; 
        }

        public PriorityQueue(IComparer<TPriority>comparer)
        {
            this.nodes = new List<Node>();
            this.comparer = comparer;
        }
    }
}
