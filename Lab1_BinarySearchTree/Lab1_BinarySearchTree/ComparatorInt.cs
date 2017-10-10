using System.Collections.Generic;


namespace Lab1_BinarySearchTree
{
    public class ComparatorInt : Comparer<System.Int32>
    {
        public override System.Int32 Compare(System.Int32 x, System.Int32 y)
        {
            return x.CompareTo(y);
        }
    }
}
