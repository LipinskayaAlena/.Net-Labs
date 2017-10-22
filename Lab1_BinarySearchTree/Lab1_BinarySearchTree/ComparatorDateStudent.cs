using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_BinarySearchTree
{
    public class ComparatorDateStudent : Comparer<Student>
    {
        public override int Compare(Student s1, Student s2)
        {
            return s1.CompareToByDate(s2);
        }
    }
}
