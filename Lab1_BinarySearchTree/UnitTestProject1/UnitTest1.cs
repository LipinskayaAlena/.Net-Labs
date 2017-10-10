using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab1_BinarySearchTree;

[TestClass]
public class UnitTest1
{
    //[TestMethod]
    //public void InorderTest()
    //{
    //    System.Int32[] data = new System.Int32[] { 8, 10, 14, 3, 1, 13, 6, 7, 4 };
    //    System.Int32[] expected = new System.Int32[] {1, 3, 4, 6, 7, 8, 10, 14, 13 };
    //    BinarySearchTree<System.Int32> binarySearchTree = new BinarySearchTree<System.Int32>(data);
        
    //    int i = 0;
    //    foreach (System.Int32 value in binarySearchTree.Inorder())
    //    {
    //        Assert.IsTrue(value == expected[i++]);
           
    //    }
    //}

    [TestMethod]
    public void PreorderTest()
    {
        System.Int32[] data = new System.Int32[] { 8, 10, 14, 3, 1, 13, 6, 7, 4 };
        System.Int32[] expected = new System.Int32[] { 8, 3, 1, 6, 4, 7, 10, 14, 13 };
        BinarySearchTree<System.Int32> binarySearchTree = new BinarySearchTree<System.Int32>(data);

        int i = 0;
        foreach (System.Int32 value in binarySearchTree.Preorder())
        {
            Assert.IsTrue(value == expected[i++]);

        }
    }


    [TestMethod]
    public void CreateBSTTest()
    {
        BinarySearchTree<System.Int32> binarySearchTree = new BinarySearchTree<System.Int32>(new System.Int32[] { 1, 3, 2 });
        binarySearchTree.Add(1);
        binarySearchTree.Add(3);
        binarySearchTree.Add(2);
        Assert.IsTrue(binarySearchTree.Count == 3);
    }

    [TestMethod]
    public void isBST()
    {
        BinarySearchTree<System.Int32> binarySearchTree = new BinarySearchTree<System.Int32>(new System.Int32[] { 3, 2, 5, 1, 6, 4});
        binarySearchTree.Add(3);
        binarySearchTree.Add(2);
        binarySearchTree.Add(5);
        binarySearchTree.Add(1);
        binarySearchTree.Add(6);
        binarySearchTree.Add(4);
        Assert.IsTrue(IsBSTUtil(binarySearchTree.Root, System.Int32.MinValue, System.Int32.MaxValue));
        
    }

    public bool IsBSTUtil(Node<System.Int32> node, System.Int32 min, System.Int32 max )
    {
        if(node == null)
        {
            return true;
        }

        if(node.Value < min || node.Value > max)
        {
            return false;
        }

        return IsBSTUtil(node.Left, min, node.Value - 1) && IsBSTUtil(node.Right, node.Value + 1, max);
    }
}
