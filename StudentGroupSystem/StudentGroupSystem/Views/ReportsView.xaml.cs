using System.Windows;
using System.Windows.Controls;
using StudentGroupSystem.Services;

namespace StudentGroupSystem.Views
{
    public partial class ReportsView : UserControl
    {
        private readonly StudentService _studentService;
        private readonly ReportService _reportService = new ReportService();

        public ReportsView(StudentService studentService)
        {
            InitializeComponent();
            _studentService = studentService;
        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            txtReport.Text = _reportService.GenerateReport(_studentService.Students);
        }
    }
}