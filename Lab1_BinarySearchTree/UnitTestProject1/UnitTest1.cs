using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab1_BinarySearchTree;

[TestClass]
public class UnitTest1
{


    [TestMethod]
    public void isBST()
    {
        BinarySearchTree<System.Int32> binarySearchTree = new BinarySearchTree<System.Int32>();
        binarySearchTree.Add(3);
        binarySearchTree.Add(2);
        binarySearchTree.Add(5);
        binarySearchTree.Add(1);
        binarySearchTree.Add(6);
        binarySearchTree.Add(4);

        Assert.IsTrue(isBSTUtil(binarySearchTree.Root, System.Int32.MinValue, System.Int32.MaxValue));
             
        
    }

    public bool isBSTUtil(Node<System.Int32> node, System.Int32 min, System.Int32 max )
    {
        if(node == null)
        {
            return true;
        }

        if(node.Value < min || node.Value > max)
        {
            return false;
        }

        return isBSTUtil(node.Left, min, node.Value - 1) && isBSTUtil(node.Right, node.Value + 1, max);
    }
}
