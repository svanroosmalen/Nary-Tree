using System;
using System.Collections;
using System.Collections.Generic;


namespace N_ary_Tree
{
    public class TreeNode<T> : IEnumerable<T>
    {
        public T Value { get; set; }
        public List<TreeNode<T>> Children;
        public TreeNode<T> Parents { get; set; }

        // Nodes
        public TreeNode(T value, List<TreeNode<T>> children, TreeNode<T> parent)
        {
            this.Value = value;
            this.Children = children;
            this.Parents = parent;
        }

        // IEnumerator voor de TreeNode
        private IEnumerator<T> CreateEnumerator()
        {
            yield return Value;
            foreach (TreeNode<T> child in Children)
            {
                foreach (T value in child)
                {
                    yield return value;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return CreateEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return CreateEnumerator();
        }
    }
    public class EmptyListException : ApplicationException { }

    public class Tree<T> : IEnumerable<T>
    {
        public TreeNode<T> ParentNode;
        public int Count { get; set; }//houd het aantal nodes bij
        public int LeafCount { get; set; } // houdt het aantal leafs bij
        //lijst waar alle kinderen in komen
        public List<TreeNode<T>> children = new List<TreeNode<T>>();

        public Tree(T parentnode)
        {
            ParentNode = new TreeNode<T>(parentnode, new List<TreeNode<T>>(), null);
            Count = 1;
            LeafCount = 1;
        }

        // Voegt een kind toe aan een parentnode
        public void AddChildNode(TreeNode<T> parentNode, T value)
        {
            //nieuwe node aanmaken
            TreeNode<T> ChildNode = new TreeNode<T>(value, new List<TreeNode<T>>(), parentNode);

            //zorgt dat leafcount geupdate wordt 
            if (parentNode.Children.Count != 0)
                LeafCount++;
            else
                children.Remove(parentNode);

            Count++;
            //voegt de kinderen toe aan de lijst en voegt kinderen toe aan de lijst van parents
            children.Add(ChildNode);
            parentNode.Children.Add(ChildNode);
        }

        // Verwijdert node, en alle kinderen die erbij horen
        public void RemoveNode(TreeNode<T> node)
        {
            int nChildNodes = node.Children.Count;
            // verwijdert het eerste kind
            for (int i = 0; i < nChildNodes; i++)
                RemoveNode(node.Children[0]);


            //maak index aan 
            //Verwijdert het kind
            List<TreeNode<T>> ChildsOfParent = node.Parents.Children;
            int index = ChildsOfParent.FindIndex(a => a.Equals(node));
            ChildsOfParent.Remove(ChildsOfParent[index]);

            // Update Count, LeafCount en LeafNodes
            Count--;
            if (node.Parents.Children.Count != 0)
                LeafCount--;
            else
                children.Add(node.Parents);

        }
        //maak een lijst in met alle nodes
        public void TraverseNode(Tree<T> tree)
        {
            Console.WriteLine(tree.ParentNode.Value);
            foreach (var childNode in tree.ParentNode.Children)
            {
                Console.Write(childNode.Value.ToString() + ",");
            }
            Console.WriteLine("");
            foreach (var kids in tree.ParentNode.Children)
            {
                if (kids.Children.Count == 0)
                {
                    Console.Write("");
                }
                else
                {
                    foreach (var ii in kids.Children)
                    {
                        Console.Write(ii.Value.ToString() + ",");
                    }
                    Console.Write("");
                }
            }
        }
        // sla alle sum op van de leafs
        public List<T> SumToLeafs()
        {
            List<T> Som = new List<T>();

            // Kijk of de node in de Leaf zit
            foreach (var node in children)
            {

                TreeNode<T> currentNode = node;
                List<T> sum = new List<T>();
                while (currentNode.Parents != null)
                {
                    // Voeg de waarde toe aan de list
                    sum.Add(currentNode.Value);
                    // en kijk dan bij de ouders
                    currentNode = currentNode.Parents;
                }
                sum.Add(ParentNode.Value);

                dynamic total = sum[0];
                sum.Remove(sum[0]);
                foreach (var value in sum)
                    total = total + value;
                Som.Add(total);
            }
            return Som;
        }

        public IEnumerator<T> TraverseNodes()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ParentNode.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ParentNode.GetEnumerator();
        }
    }
}
