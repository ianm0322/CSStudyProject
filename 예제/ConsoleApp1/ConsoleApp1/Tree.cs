using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ConsoleApp1
{
    class Tree
    {
        public void Main()
        {
            // MaxQueue
            {
                MaxHeap<Person> peaple = new MaxHeap<Person>();
                peaple.Add(new Person("AA", 10));
                peaple.Add(new Person("AA", 10));
                peaple.Add(new Person("AA", 10));
                peaple.Add(new Person("AA", 10));
                peaple.Add(new Person("AA", 10));
            }
            // ??sortedList?
            {
                SortedList<int, string> sortedList = new SortedList<int, string>();
                Random r = new Random();
                for (int i = 0; i < 6; i++)
                {
                    while (true)
                    {
                        try
                        {
                            char ch = (char)((int)'A' + i);
                            sortedList.Add(r.Next(0, 100), ch.ToString());
                            break;
                        }
                        catch
                        {

                        }
                    }
                }
                foreach (var item in sortedList)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
                return;
            }
            // Binary Tree 실습1
            {
                BinaryTree<int> tree = new BinaryTree<int>(100, 0);
                tree.AddChild(0, 1);
                tree.AddChild(0, 2);
                tree.AddChild(1, 3);
                tree.AddChild(2, 4);
                tree.Print();
            }
            return;
            // lcrs tree class 실습
            {
                LcrsTree tree = new LcrsTree("A");
                var B = tree.AddChild(tree.Root, "B");
                tree.AddChild(tree.Root, "C");
                var D = tree.AddChild(tree.Root, "D");
                var E = tree.AddChild(B, "E");
                tree.AddSibling(E, "F");
                tree.AddChild(D, "G");
                tree.PrintTree();
            }
            return;
            // Left Child RIght Sibling Tree
            // 모든 노드의 차수가 2차인 트리. 하나의 자식과 하나의 형제 노드를 기억한다.
            {
                LcrsNode A = new LcrsNode("A");
                LcrsNode B = new LcrsNode("B");
                LcrsNode C = new LcrsNode("C");
                LcrsNode D = new LcrsNode("D");
                A.LeftChild = B;
                B.RightSibling = C;
                C.RightSibling = D;
                B.LeftChild = new LcrsNode("E");
                B.LeftChild.RightSibling = new LcrsNode("F");
                D.LeftChild = new LcrsNode("G");
            }
            // N차수 트리
            {
                var A = new TreeNode("A");
                var B = new TreeNode("B");
                var C = new TreeNode("C");
                var D = new TreeNode("D");

                A.Links.Add(B);
                A.Links.Add(C);
                A.Links.Add(D);

                B.Links.Add(new TreeNode("E"));
                B.Links.Add(new TreeNode("F"));

                D.Links.Add(new TreeNode("G"));
            }
        }
    }

    class TreeNode
    {
        public object Data { get; set; }
        public List<TreeNode> Links { get; private set; }

        public TreeNode(object data)
        {
            Data = data;
            Links = new List<TreeNode>();
        }
    }

    #region    [MaxHeap & PriorityQueue]
    public class MaxHeap<T> where T : IComparable<T>
    {
        List<T> heapList = new List<T>();
        public void Add(T data)
        {
            // 가장 마지막에 추가 후, 알맞은 위치까지 바꾸면서 상승.
            // 1. 힙의 가장 마지막에 데이터 추가
            heapList.Add(data);
            // 2. 순환변수 i = 추가한 데이터 위치
            int i = heapList.Count - 1;
            while (i > 0)
            {
                int parent = (i - 1) / 2;   // i 노드의 부모
                if (IsBigger(heapList[i], heapList[parent]) > 0)    // 추가한 데이터가 부모보다 크면 두 데이터 위치 바꾸기
                {
                    T temp = heapList[i];
                    heapList[i] = heapList[parent];
                    heapList[parent] = temp;

                    i = parent; // 바꾼 후 i 위치를 부모로 변경.
                }
                else break; // 알맞은 위치(모든 부모보다 작고 모든 자식보다 큰 상태)에서 종료.
            }
        }
        public T Remove()
        {
            if (heapList.Count == 0)
            {
                throw new IndexOutOfRangeException();
            }
            T data = heapList[0];   // 반환할 최상위 노드
            heapList[0] = heapList[heapList.Count - 1]; // 마지막 노드를 루트 노드로 옮기기
            heapList.RemoveAt(heapList.Count - 1);

            // 가장 위에 올려놓은 마지막 노드를 맞는 위치로 이동시키며 정렬.
            int i = 0;      // 시작 i
            int last = heapList.Count - 1;  // 힙 마지막 요소
            int child = 0;  // 임시변수
            while (i < last)
            {
                child = 2 * i + 1;  // 왼쪽 자식 노드
                if(child < last && IsBigger(heapList[child], heapList[child+1]) < 0)    // 만약 오른쪽 자식 노드가 왼쪽보다 더 크면 child를 오른쪽 노드로.
                {
                    child++;
                }
                if(child > last || IsBigger(heapList[i] , heapList[child]) >= 0)        // 인덱스 초과, 혹은 자식노드보다 크거나 같으면 중지.
                {
                    break;
                }

                // 마지막이었던 노드: i를 보다 큰 노드 child으로 이동.
                T temp = heapList[i];
                heapList[i] = heapList[child];
                heapList[child] = temp;

                // 현재 노드를 바꾼 대상 child로 포커스 이동.
                i = child;
            }
            return data;
        }
        int IsBigger(T a, T b)
        {
            return a.CompareTo(b);
        }
    }

    public class Person : IComparable<Person>
    {
        public string name;
        public int age;
        
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public int CompareTo(Person obj)
        {
            return age.CompareTo(obj.age);
        }
    }

    #endregion [MaxHeap & PriorityQueue]

    #region [Binary Tree]
    class BinaryTree<T>
    {
        public BinaryTreeNode<T> Root { get; private set; }
        public BinaryTreeNode<T>[] Arr;

        #region [생성자]
        public BinaryTree(int capacity, T root)
        {
            Arr = new BinaryTreeNode<T>[capacity];
            Root = new BinaryTreeNode<T>(root);
            Arr[0] = Root;
        }

        public BinaryTree(T root) : this(2, root)
        {

        }
        #endregion

        public BinaryTreeNode<T> GetParent(int idx)
        {
            return Arr[GetParentIndex(idx)];
        }
        public BinaryTreeNode<T>[] GetChildren(int idx)
        {
            var idxs = GetChildrenIndex(idx);
            var ret = new BinaryTreeNode<T>[2]
            {
                Arr[idxs.left], Arr[idxs.right]
            };
            return ret;
        }

        public int GetParentIndex(int idx)
        {
            if (Arr[idx] == null || idx >= Arr.Length)
                throw new Exception("없는 인덱스: " + idx);

            return (idx + 1) / 2;
        }

        public (int left, int right) GetChildrenIndex(int idx)
        {
            if (Arr[idx] == null || idx >= Arr.Length)
                throw new Exception("없는 인덱스: " + idx);
            return (idx * 2 + 1, idx * 2 + 2);
        }

        public bool AddChild(int parentIdx, T data)
        {
            int left_child_idx = parentIdx + 1;
            int right_child_idx = parentIdx + 2;
            if (left_child_idx >= Arr.Length)   // 왼쪽 자식이 배열크기 이상이면 무조건 false 반환.
            {
                return false;
            }
            else if (Arr[left_child_idx] == null)   // 왼쪽 자리 있으면 자식 추가.
            {
                Arr[left_child_idx] = new BinaryTreeNode<T>(data);
                // 자식 추가
            }
            else if (right_child_idx >= Arr.Length)   // 왼쪽 추가 실패시 오른쪽 검사    
            {
                return false;
            }
            else if (Arr[right_child_idx] == null) // 자리 있으면 추가
            {
                Arr[right_child_idx] = new BinaryTreeNode<T>(data);
            }
            // 죄다 아니면 자리 없음. false 반환.
            return true;
        }

        public bool SetLeft(int nodeIdx, T data)
        {
            return SetLeft(nodeIdx, new BinaryTreeNode<T>(data));
        }

        public bool SetLeft(int nodeIdx, BinaryTreeNode<T> data)
        {
            int leftIndex = nodeIdx * 2 + 1;
            if (Arr[nodeIdx] == null || leftIndex >= Arr.Length)
            {
                return false;
            }
            Arr[leftIndex] = data;
            return true;
        }

        public bool SetRight(int nodeIdx, T data)
        {
            return SetRight(nodeIdx, new BinaryTreeNode<T>(data));
        }

        public bool SetRight(int nodeIdx, BinaryTreeNode<T> data)
        {
            int leftIndex = nodeIdx * 2 + 2;
            if (Arr[nodeIdx] == null || leftIndex >= Arr.Length)
            {
                return false;
            }
            Arr[leftIndex] = data;
            return true;
        }

        public void Print()
        {
            for (int i = 0; i < Arr.Length; i++)
            {
                if (Arr[i] == null)
                    break;

                Console.WriteLine(Arr[i].Data);
            }
        }

        public void PreOrderTraversal(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }
            Console.WriteLine(node.Data);
            PreOrderTraversal(node.LeftNode);
            PreOrderTraversal(node.RightNode);
        }
        public void InOrderTraversal(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }
            PreOrderTraversal(node.LeftNode);
            Console.WriteLine(node.Data);
            PreOrderTraversal(node.RightNode);
        }
        public void PostOrderTraversal(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }
            PreOrderTraversal(node.LeftNode);
            PreOrderTraversal(node.RightNode);
            Console.WriteLine(node.Data);
        }
    } // class BinaryTree<T> { }

    class BinaryTreeNode<T>
    {
        public T Data { get; set; }
        public BinaryTreeNode<T> LeftNode { get; set; }
        public BinaryTreeNode<T> RightNode { get; set; }

        public BinaryTreeNode(T data)
        {
            this.Data = data;
        }
    }

    #endregion [Binary Tree]

    #region [LCRS Tree]
    class LcrsTree
    {
        public LcrsNode Root { get; private set; }
        public LcrsTree(object rootData)
        {
            Root = new LcrsNode(rootData);
        }

        public LcrsNode AddChild(LcrsNode parent, object data)  // parent node의 child(data)를 추가.
        {
            if (parent == null)
            {
                return null;
            }

            else
            {
                var child = new LcrsNode(data);
                if (parent.LeftChild == null)       // parent의 child가 없으면 parent.child를 생성 후 data 추가.
                {
                    parent.LeftChild = child;
                }
                else                                // 아니라면, parent의 child에 접근, 가장 끝의 sibling까지 접근 후 노드 추가.
                {
                    var target = parent.LeftChild;
                    while (target.RightSibling != null)
                    {
                        target = target.RightSibling;
                    }
                    target.RightSibling = child;
                }
                return child;
            }
        }

        public LcrsNode AddSibling(LcrsNode node, object data)
        {
            if (node == null)
            {
                return null;
            }

            var sibling = new LcrsNode(data);
            var target = node;
            while (node.RightSibling != null)
            {
                target = target.RightSibling;
            }
            target.RightSibling = sibling;
            return sibling;
        }

        public void PrintTree()
        {
            // BFS으로 Tree 출력
            Queue<LcrsNode> queue = new Queue<LcrsNode>();
            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                // child queue에서 출력할 child를 구해옴.
                var current = queue.Dequeue();

                // current의 sibling을 순회하며 출력
                while (current != null)
                {
                    Console.WriteLine(current.Data);

                    // 순회 중 자식 노드가 있으면, 출력 대기줄(queue)에 추가.
                    if (current.LeftChild != null)
                    {
                        queue.Enqueue(current.LeftChild);
                    }
                    current = current.RightSibling;
                }

                // current가 sibling의 끝(null)에 도달하면 
            }
        }

        // 구현해야 함.
        public void PrintTreeByDFS()
        {
            Stack<LcrsNode> stack = new Stack<LcrsNode>();
            stack.Push(Root);

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                while (current != null)
                {

                    current = current.RightSibling;
                }
            }
        }
    }

    class LcrsNode  // Left Child Right Sibling
    {
        public object Data { get; set; }
        public LcrsNode LeftChild { get; set; }
        public LcrsNode RightSibling { get; set; }

        public LcrsNode(object data)
        {
            this.Data = data;
        }
    }
    #endregion [LCRS Tree]
}
