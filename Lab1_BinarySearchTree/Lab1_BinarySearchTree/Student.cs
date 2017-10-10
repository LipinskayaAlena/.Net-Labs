using System;

namespace Lab1_BinarySearchTree
{
    public class Student
    {
        public String firstName;
        public String secondName;
        public DateTime date;
        public int rating;

        public int Rating { get { return rating; } }

        public Student(String fName, String sName, DateTime date, int rating)
        {
            this.firstName = fName;
            this.secondName = sName;
            this.date = date;
            this.rating = rating;
        }

        internal int CompareTo(Student s2)
        {
            return rating.CompareTo(s2.Rating);
        }
    }
}
