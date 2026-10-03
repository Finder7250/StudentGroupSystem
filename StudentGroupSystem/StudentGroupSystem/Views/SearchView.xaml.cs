using System.Windows;
using System.Windows.Controls;
using StudentGroupSystem.Services;

namespace StudentGroupSystem.Views
{
    public partial class SearchView : UserControl
    {
        private readonly StudentService _studentService;
        private readonly SearchService _searchService = new SearchService();

        public SearchView(StudentService studentService)
        {
            InitializeComponent();
            _studentService = studentService;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            var results = _searchService.SearchByName(_studentService.Students, txtQuery.Text);
            lstResults.ItemsSource = results;

            if (results.Count == 0)
            {
                txtResultInfo.Text = "Ничего не найдено.";
                MessageBox.Show("Студент не найден.", "Результат поиска");
            }
            else
            {
                txtResultInfo.Text = "Найдено: " + results.Count;
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            txtQuery.Clear();
            lstResults.ItemsSource = null;
            txtResultInfo.Text = "";
        }
    }
}