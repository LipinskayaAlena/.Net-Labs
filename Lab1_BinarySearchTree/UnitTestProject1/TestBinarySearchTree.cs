using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab1_BinarySearchTree;

[TestClass]
public class TestBinarySearchTree
{

    [TestMethod]
    public void InorderTest()
    {
        System.Int32[] data = new System.Int32[] { 8, 10, 14, 3, 1, 13, 6, 7, 4, 2 };
        System.Int32[] expected = new System.Int32[] { 1, 2, 3, 4, 6, 7, 8, 10, 13, 14 };
        BinarySearchTree<System.Int32> binarySearchTree = new BinarySearchTree<System.Int32>(data);
        
        int i = 0;
        foreach (System.Int32 value in binarySearchTree.Inorder())
        {
            Assert.IsTrue(value == expected[i++]);
           
        }
    }

    [TestMethod]
    public void DeleteNodeTest()
    {
        BinarySearchTree<System.Int32> binarySearchTree = new BinarySearchTree<System.Int32>(new System.Int32[] { 8, 10, 3, 14, 6, 13, 7, 4, 1 });
        System.Int32[] expected1 = new System.Int32[] { 1, 3, 4, 6, 7, 8, 10, 13 };
        System.Int32[] expected2 = new System.Int32[] { 1, 4, 6, 7, 8, 10, 13 };
        System.Int32[] expected3 = new System.Int32[] { 1, 6, 7, 8, 10, 13 };

        Assert.IsFalse(binarySearchTree.Remove(15));
        Assert.IsTrue(binarySearchTree.Remove(14));
        int i = 0;
        foreach (System.Int32 value in binarySearchTree.Inorder())
        {
            Assert.IsTrue(value == expected1[i++]);

        }
        Assert.IsTrue(binarySearchTree.Remove(3));
        i = 0;
        foreach (System.Int32 value in binarySearchTree.Inorder())
        {
            Assert.IsTrue(value == expected2[i++]);

        }
        Assert.IsTrue(binarySearchTree.Remove(4));
        i = 0;
        foreach (System.Int32 value in binarySearchTree.Inorder())
        {
            Assert.IsTrue(value == expected3[i++]);
        }

        Assert.IsTrue(binarySearchTree.Count == expected3.Length);

    }

    [TestMethod]
    public void CopyTest()
    {
        BinarySearchTree<System.Int32> binarySearchTree = new BinarySearchTree<System.Int32>(new System.Int32[] { 1, 3, 2 });
        binarySearchTree.CopyTo(new System.Int32[6], 3);        
    }

    [TestMethod]
    public void ContainsNodeTest()
    {
        BinarySearchTree<System.Int32> binarySearchTree = new BinarySearchTree<System.Int32>(new System.Int32[] { 1, 3, 2 });
        Assert.IsTrue(binarySearchTree.Contains(2));
    }

    [TestMethod]
    public void PostorderTest()
    {
        System.Int32[] data = new System.Int32[] { 8, 10, 14, 3, 1, 13, 6, 7, 4 };
        System.Int32[] expected = new System.Int32[] { 1, 4, 7, 6, 3, 13, 14, 10, 8 };
        BinarySearchTree<System.Int32> binarySearchTree = new BinarySearchTree<System.Int32>(data);

        int i = 0;
        foreach (System.Int32 value in binarySearchTree.Postorder())
        {
            Assert.IsTrue(value == expected[i++]);
        }
    }

    [TestMethod]
    public void PreorderTest()
    {
        System.Int32[] data = new System.Int32[] { 8, 10, 14, 3, 1, 13, 6, 7, 4, 2};
        System.Int32[] expected = new System.Int32[] { 8, 3, 1, 2, 6, 4, 7, 10, 14, 13 };
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
        BinarySearchTree<System.Int32> binarySearchTree = new BinarySearchTree<System.Int32>(new System.Int32[] { 1, 3, 2, 2 });
        Assert.IsTrue(binarySearchTree.Count == 3);
    }

    [TestMethod]
    public void IsBST()
    {
        BinarySearchTree<System.Int32> binarySearchTree = new BinarySearchTree<System.Int32>(new System.Int32[] { 3, 2, 5, 1, 6, 4});
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


    [TestMethod]
    public void ComparerInt32Test()
    {
        BinarySearchTree<System.Int32> tree = new BinarySearchTree<System.Int32>(new System.Int32[] { 3, 2, 5, 1, 6, 4 }, new ComparatorInt());
        System.Int32[] expected = new System.Int32[] { 1, 2, 3, 4, 5, 6 };
        int i = 0;
        foreach (System.Int32 value in tree.Inorder())
        {
            Assert.IsTrue(value == expected[i++]);
        }
    }

    [TestMethod]
    public void ComparerStringTest()
    {
        BinarySearchTree<System.String> tree = new BinarySearchTree<System.String>(new System.String[] { "5", "2", "6", "3", "4", "1" }, new ComparatorString());
        System.String[] expected = new System.String[] { "1", "2", "3", "4", "5", "6" };
        int i = 0;
        foreach (System.String value in tree.Inorder())
        {
            Assert.AreEqual(expected[i++], value);
        }
    }


    [TestMethod]
    public void ComparerPointTest()
    {
        Point point1 = new Point(10, 5); //15
        Point point2 = new Point(3, 4); //7
        Point point3 = new Point(1, 2); //3
        Point point4 = new Point(8, 6); //14
        Point point5 = new Point(7, 12); //19
        Point point6 = new Point(5, 3); //8

        BinarySearchTree<Point> tree = new BinarySearchTree<Point>(new Point[] { point1, point2, point3, point4, point5, point6 }, new ComparatorPoint());
        Point[] expected = new Point[] { point3, point2, point6, point4, point1, point5 };
        int i = 0;
        foreach (Point point in tree.Inorder())
            Assert.AreEqual(expected[i++], point);
        
    }

    [TestMethod]
    public void ComparerByFirstNameStudentTest()
    {
        Student s1 = new Student("Debra", "Garcia", "Test3", new DateTime(2017, 4, 10), 8);
        Student s2 = new Student("Alesia", "Ivanova", "Test1", new DateTime(2017, 12, 20), 6);
        Student s3 = new Student("Nick", "Adams", "Test4", new DateTime(2017, 2, 11), 7);
        Student s4 = new Student("Cesar", "Garcia", "Test2", new DateTime(2017, 3, 15), 9);

        BinarySearchTree<Student> tree = new BinarySearchTree<Student>(new Student[] { s1, s2, s3, s4 }, new ComparatorFirstNameStudent());

        Student[] expected = new Student[] { s2, s4, s1, s3 };
        int i = 0;
        foreach (Student student in tree.Inorder())
            Assert.AreEqual(expected[i++], student);
    }

    [TestMethod]
    public void ComparerByDateStudentTest()
    {
        Student s1 = new Student("Debra", "Garcia", "Test3", new DateTime(2017, 4, 10), 8);
        Student s2 = new Student("Alesia", "Ivanova", "Test1", new DateTime(2017, 12, 20), 6);
        Student s3 = new Student("Nick", "Adams", "Test4", new DateTime(2017, 2, 11), 7);
        Student s4 = new Student("Cesar", "Garcia", "Test2", new DateTime(2017, 3, 15), 9);

        BinarySearchTree<Student> tree = new BinarySearchTree<Student>(new Student[] { s1, s2, s3, s4 }, new ComparatorDateStudent());

        Student[] expected = new Student[] { s3, s4, s1, s2 };
        int i = 0;
        foreach (Student student in tree.Inorder())
            Assert.AreEqual(expected[i++], student);
    }

    [TestMethod]
    public void ComparerByNameTestTest()
    {
        Student s1 = new Student("Debra", "Garcia", "Test3", new DateTime(2017, 4, 10), 8);
        Student s2 = new Student("Alesia", "Ivanova", "Test1", new DateTime(2017, 12, 20), 6);
        Student s3 = new Student("Nick", "Adams", "Test4", new DateTime(2017, 2, 11), 7);
        Student s4 = new Student("Cesar", "Garcia", "Test2", new DateTime(2017, 3, 15), 9);

        BinarySearchTree<Student> tree = new BinarySearchTree<Student>(new Student[] { s1, s2, s3, s4 }, new ComaparatorNameTestStudent());

        Student[] expected = new Student[] { s2, s4, s1, s3 };
        int i = 0;
        foreach (Student student in tree.Inorder())
            Assert.AreEqual(expected[i++], student);
    }

    [TestMethod]
    public void ComparerByRatingStudentTest()
    {
        Student s1 = new Student("Debra", "Garcia", "Test3", new DateTime(2017, 4, 10), 8);
        Student s2 = new Student("Alesia", "Ivanova", "Test1", new DateTime(2017, 12, 20), 6);
        Student s3 = new Student("Nick", "Adams", "Test4", new DateTime(2017, 2, 11), 7);
        Student s4 = new Student("Cesar", "Garcia", "Test2", new DateTime(2017, 3, 15), 9);

        BinarySearchTree<Student> tree = new BinarySearchTree<Student>(new Student[] {s1, s2, s3, s4 }, new ComparatorRatingStudent());
        
        Student[] expected = new Student[] { s3, s2, s4, s1 };
        int i = 0;
        foreach (Student student in tree.Postorder())
            Assert.AreEqual(expected[i++], student);

    }


}
