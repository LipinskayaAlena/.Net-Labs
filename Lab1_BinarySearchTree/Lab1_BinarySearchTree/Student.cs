using System;

namespace Lab1_BinarySearchTree
{
    
    public class Student
    {
        private String firstName;
        private String secondName;
        private DateTime date;
        private int rating;

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

        internal int CompareToByRating(Student s2)
        {
            return rating.CompareTo(s2.Rating);
        }

        internal int CompareToByFirstName(Student s2)
        {
            return new ComparatorString().Compare(this.firstName, s2.FirstName);
        }

        internal int CompareToBySecondName(Student s2)
        {
            return new ComparatorString().Compare(this.secondName, s2.SecondName);
        }

        internal int CompareToByDate(Student s2)
        {
            return DateTime.Compare(this.date, s2.Date);
        }


        public override string ToString()
        {
            return "Student " + this.firstName + " " + this.secondName + 
                "\n Date of passing test " + this.date + 
                "\n Rating " + this.rating + "\n";
        }
    }
}
