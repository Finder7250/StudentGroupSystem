using System;

namespace StudentGroupSystem.Models
{
    public class Student
    {
        public string FullName { get; set; } = "";
        public string Group { get; set; } = "";
        public DateTime BirthDate { get; set; } = DateTime.Today;
        public string Phone { get; set; } = "";
        public double AverageGrade { get; set; }

        public override string ToString()
        {
            return $"{FullName} | {Group} | {AverageGrade:F2}";
        }
    }
}