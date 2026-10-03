using System;
using System.Windows;
using System.Windows.Controls;
using StudentGroupSystem.Models;
using StudentGroupSystem.Services;

namespace StudentGroupSystem.Views
{
    public partial class StudentsView : UserControl
    {
        private readonly StudentService _service;

        public StudentsView(StudentService service)
        {
            InitializeComponent();
            _service = service;
            lstStudents.ItemsSource = _service.Students;
            _service.Students.CollectionChanged += (s, e) => UpdateCount();
            UpdateCount();
        }

        private void UpdateCount()
        {
            txtCount.Text = "Всего студентов: " + _service.Students.Count;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var student = new Student
                {
                    FullName = txtFullName.Text.Trim(),
                    Group = txtGroup.Text.Trim(),
                    AverageGrade = double.TryParse(txtGrade.Text, out var g) ? g : 0
                };

                _service.AddStudent(student);

                txtFullName.Clear();
                txtGroup.Clear();
                txtGrade.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (lstStudents.SelectedItem is Student s)
            {
                _service.RemoveStudent(s);
            }
            else
            {
                MessageBox.Show("Выберите студента для удаления.", "Внимание");
            }
        }
    }
}