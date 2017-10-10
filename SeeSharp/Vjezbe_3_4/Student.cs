using System;

namespace Vjezbe_3_4
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public uint UniversityYear { get; set; }
        public double Average { get; set; }

        public Student()
        {
            FirstName = "Pero";
            LastName = "Perić";

            UniversityYear = 1;
            Average = 1;
        }

        public Student(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            UniversityYear = 1;
            Average = 1;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"{FirstName} {LastName} (year {UniversityYear}); Average = {Average}");
        }
    }
}
