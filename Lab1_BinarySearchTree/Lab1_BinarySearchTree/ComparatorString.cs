using System;
using System.Collections.Generic;

namespace Lab1_BinarySearchTree
{
    public class ComparatorString : Comparer<String>
    {
        public override int Compare(String x, String y) => String.Compare(x, y, StringComparison.Ordinal);
    }
}
