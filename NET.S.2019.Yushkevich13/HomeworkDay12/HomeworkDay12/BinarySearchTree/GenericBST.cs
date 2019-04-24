using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkDay12.BinarySearchTree
{
    public enum WalkOrder
    {
        Post,
        Pre,
        In
    }

    public class GenericBST<T>
    {
        private IList<Node<T>> _orderList = new List<Node<T>>();
        private Comparer<T> _comparer;
        private int _count;

        public GenericBST(IEnumerable<T> collection, Comparer<T> comparer = null)
        {
            if (comparer is null)
            {
                _comparer = Comparer<T>.Default;
            }
            else
            {
                _comparer = comparer;
            }

            foreach (T item in collection)
            {
                Insert(Root, item);
            }
        }

        public Node<T> Root { get; private set; }

        public Node<T> Insert(Node<T> root, T item)
        {
            _count++;
            if (Root is null)
            {
                Root = new Node<T>() { Value = item };
            }
            else if (root is null)
            {
                root = new Node<T>() { Value = item };
            }
            else if (_comparer.Compare(item, root.Value) < 0)
            {
                root.left = Insert(root.left, item);
            }
            else
            {
                root.right = Insert(root.right, item);
            }

            return root;
        }

        public void InOrderTraversing(Node<T> root)
        {
            if (root is null)
            {
                return;
            }

            InOrderTraversing(root.left);
            _orderList.Add(root);
            InOrderTraversing(root.right);
        }

        public void PostOrderTraversing(Node<T> root)
        {
            if (root is null)
            {
                return;
            }

            PostOrderTraversing(root.left);
            PostOrderTraversing(root.right);
            _orderList.Add(root);
        }

        public void PreOrderTraversing(Node<T> root)
        {
            if (root is null)
            {
                return;
            }

            _orderList.Add(root);
            PreOrderTraversing(root.left);
            PreOrderTraversing(root.right);
        }

        public IEnumerable<Node<T>> Traversing(WalkOrder order)
        {
            _orderList = new List<Node<T>>();
            Action<Node<T>> traversing;
            switch (order)
            {
                case WalkOrder.Post:
                    traversing = new Action<Node<T>>(PostOrderTraversing);
                    break;
                case WalkOrder.Pre:
                    traversing = new Action<Node<T>>(PreOrderTraversing);
                    break;
                case WalkOrder.In:
                    traversing = new Action<Node<T>>(InOrderTraversing);
                    break;
                default:
                    traversing = new Action<Node<T>>(InOrderTraversing);
                    break;
            }

            return Walk(traversing);
        }

        public IEnumerable<Node<T>> Walk(Action<Node<T>> traversing)
        {
            traversing(Root);
            for (int i = 0; i < _orderList.Count; i++)
            {
                yield return _orderList[i];
            }
        }
    }
}
