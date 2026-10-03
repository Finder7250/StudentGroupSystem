using System;
using System.Collections.ObjectModel;
using StudentGroupSystem.Models;

namespace StudentGroupSystem.Services
{
    public class StudentService
    {
        public ObservableCollection<Student> Students { get; } = new ObservableCollection<Student>();

        public void AddStudent(Student student)
        {
            if (student == null) return;

            if (string.IsNullOrWhiteSpace(student.FullName))
                throw new ArgumentException("ФИО не может быть пустым.");

            if (string.IsNullOrWhiteSpace(student.Group))
                throw new ArgumentException("Группа не может быть пустой.");

            if (student.AverageGrade < 2 || student.AverageGrade > 5)
                throw new ArgumentException("Средний балл должен быть в диапазоне от 2 до 5.");

            Students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            if (student != null && Students.Contains(student))
                Students.Remove(student);
        }
    }
}