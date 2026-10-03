using System.Collections.Generic;
using System.Linq;
using StudentGroupSystem.Models;

namespace StudentGroupSystem.Services
{
    public class SearchService
    {
        public List<Student> SearchByName(IEnumerable<Student> students, string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return students.ToList();

            return students
                .Where(s => s.FullName.ToLower().Contains(query.ToLower()))
                .ToList();
        }
    }
}