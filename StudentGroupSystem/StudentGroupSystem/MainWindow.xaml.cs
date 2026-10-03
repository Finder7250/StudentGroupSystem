using System.Windows;
using System.Windows.Controls;
using StudentGroupSystem.Services;
using StudentGroupSystem.Views;

namespace StudentGroupSystem
{
    public partial class MainWindow : Window
    {
        private readonly StudentService _studentService = new StudentService();

        public MainWindow()
        {
            InitializeComponent();

            tabControl.Items.Add(new TabItem
            {
                Header = "Студенты",
                Content = new StudentsView(_studentService)
            });

            tabControl.Items.Add(new TabItem
            {
                Header = "Поиск",
                Content = new SearchView(_studentService)
            });

            tabControl.Items.Add(new TabItem
            {
                Header = "Отчёты",
                Content = new ReportsView(_studentService)
            });
        }
    }
}