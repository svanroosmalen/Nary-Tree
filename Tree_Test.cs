using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using N_ary_Tree;

namespace Nary_Tree
{
    class Tree_Test
    {
        [TestFixture]
        public class Tree
        {
            [TestCase]
            public void Test_Tree_Add()
            {
                // Arrange
                Tree<int> tree = new Tree<int>(0);
                Tree<string> tree2 = new Tree<string>(null);
                // Act
                tree.AddChildNode(tree.ParentNode, 2);
                tree2.AddChildNode(tree2.ParentNode, "Simone");
                // Assert
                //Controleer de int
                Assert.Multiple(() =>
                {
                    Assert.That(tree.children.Count == 1);
                    Assert.Contains(2, new System.Collections.Generic.List<int>(tree));
                });
                //Controleer de strings
                Assert.Contains("Simone", new System.Collections.Generic.List<string>(tree2));
            }

            [TestCase]
            public void Test_Tree_Remove()
            {
                //Arrange
                Tree<int> tree = new Tree<int>(2);
                //Act
                tree.AddChildNode(tree.ParentNode, 1);
                tree.AddChildNode(tree.ParentNode, 2);
                tree.RemoveNode(tree.children[1]);
                //Assert
                Assert.Contains(1, new System.Collections.Generic.List<int>(tree));
            }
            [TestCase]
            public void Test_Tree_Traverse()
            {
                //Arrange
                Tree<int> tree_test = new Tree<int>(2);
                TreeNode<int> Parent;
                tree_test.AddChildNode(tree_test.ParentNode, 3);
                tree_test.AddChildNode(tree_test.ParentNode, 4);
                tree_test.AddChildNode(tree_test.ParentNode, 5);
                Parent = tree_test.ParentNode.Children[0];
                tree_test.AddChildNode(Parent, 9);
                tree_test.AddChildNode(tree_test.ParentNode, 6);
                //Act
                tree_test.TraverseNodes();
                //Assert
                Assert.IsNotEmpty(tree_test);
            }
            [TestCase]
            public void Test_Tree_SumLeafs()
            {
                //Arrange
                Tree<int> tree_test = new Tree<int>(2);
                tree_test.AddChildNode(tree_test.ParentNode, 3);
                tree_test.AddChildNode(tree_test.ParentNode, 4);
                tree_test.AddChildNode(tree_test.ParentNode, 5);
                
                //Act
                List<int> Som = tree_test.SumToLeafs();
                //Assert
                int[] antwoord = { 5, 6, 7 };
                Assert.That(antwoord, Is.EquivalentTo(Som));
            }

        }

    }
}
