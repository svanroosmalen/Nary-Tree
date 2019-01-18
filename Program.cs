using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_ary_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tree aanmaken. 
            Tree<int> tree = new Tree<int>(1);
            TreeNode<int> Parent;

            //Laag 0 aanmaken, 
            tree.AddChildNode(tree.ParentNode, 2);
            tree.AddChildNode(tree.ParentNode, 3);
            //Laag 1: 
            //Parent zit dus laag 0, hieronder wil je de kinderen toevoegen
            Parent = tree.ParentNode.Children[0];
            tree.AddChildNode(Parent, 9);

            //Laag 2: [1]
            Parent = tree.ParentNode.Children[1];
            tree.AddChildNode(Parent, 4);
            tree.AddChildNode(Parent, 5);
            tree.AddChildNode(Parent, 7);

            // Remove Nodes
            tree.RemoveNode(tree.children[0]); //[0] houdt in het eerste kleinkind verwijderen ( dus hier de 9) 

            // Tree in Console
            Console.WriteLine("Tree: ");
            Console.WriteLine("Traverse: ");
            tree.TraverseNode(tree);
            Console.WriteLine(" ");
            Console.WriteLine("Sum to leafs: ");
            tree.SumToLeafs().ForEach(i => Console.WriteLine(i.ToString()));
            Console.WriteLine("Aantal nodes: " + tree.Count.ToString());
            Console.WriteLine("LeafCount: " + tree.LeafCount.ToString());

            Console.WriteLine("");
            Console.WriteLine("Values in tree: ");
            foreach (int node in tree)
            {
                Console.WriteLine(node);
            }


            Console.ReadLine();

        }

    }
}