namespace Otus_Eighth_Homework
{
    internal class EmploeesSorted
    {
        private static Node _root = null;

        public void AddEmploee(string emploee, int salary)
        {
            var nodeToAdd = new Node()
            {
                Salary = salary,
                Emploee = emploee,
            };

            if (_root == null)
            {
                _root = nodeToAdd;
            }
            else
            {
                AddNode(_root, nodeToAdd);
            }
        }

        public string FindSalary(int salary)
        {
            if (_root == null)
            {
                return null;
            }
            else
            {
                return FindNode(_root, salary);
            }
        }

        public void Traverse()
        {
            InorderTraversal(_root);
        }

        private string FindNode(Node root, int salary)
        {
            if (salary < root.Salary)
            {
                if (root.LeftNode != null)
                {
                    return FindNode(root.LeftNode, salary);
                }
                return null;
            }
            else if (salary > root.Salary)
            {
                if (root.RightNode != null)
                {
                    return FindNode(root.RightNode, salary);
                }
                return null;
            }
            return root.Emploee;
        }

        private static void InorderTraversal(Node node)
        {
            if (node == null)
                return;

            InorderTraversal(node.LeftNode);
            Console.WriteLine($"Emploee: {node.Emploee}, Salary: {node.Salary}");
            InorderTraversal(node.RightNode);
        }

        private static void AddNode(Node root, Node toAdd)
        {
            if (toAdd.Salary < root.Salary)
            {
                if (root.LeftNode == null)
                {
                    root.LeftNode = toAdd;
                }
                else
                {
                    AddNode(root.LeftNode, toAdd);
                }
            }
            else
            {
                if (root.RightNode == null)
                {
                    root.RightNode = toAdd;
                }
                else
                {
                    AddNode(root.RightNode, toAdd);
                }
            }
        }

        public void Clear()
        {
            _root = null;
        }

        private class Node
        {
            public Node LeftNode { get; set; }
            public Node RightNode { get; set; }
            public int Salary { get; set; }
            public string Emploee { get; set; }
        }
    }
}
