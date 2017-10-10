using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_BinarySearchTree
{
    public class ComparatorPoint : Comparer<Point>
    {
        public override int Compare(Point x, Point y)
        {
            return (x.X + x.Y).CompareTo(y.X + y.Y);
        }
    }
}
