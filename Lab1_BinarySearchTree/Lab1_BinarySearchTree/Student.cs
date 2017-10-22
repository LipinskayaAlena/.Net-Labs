using System;

namespace Lab1_BinarySearchTree
{
    [Serializable]
    public class Student
    {
        public String firstName;
        public String secondName;
        public DateTime date;
        public int rating;

        public int Rating { get { return rating; } }

        public String FirstName { get { return firstName; } }

        public String SecondName { get { return secondName; } }

        public DateTime Date { get { return date; } }
        

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
