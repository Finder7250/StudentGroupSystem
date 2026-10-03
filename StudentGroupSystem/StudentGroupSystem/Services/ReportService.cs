using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentGroupSystem.Models;

namespace StudentGroupSystem.Services
{
    public class ReportService
    {
        public string GenerateReport(IEnumerable<Student> students)
        {
            var list = students.ToList();
            var sb = new StringBuilder();
            sb.AppendLine("=== ОТЧЁТ ПО УЧЕБНОЙ ГРУППЕ ===");
            sb.AppendLine("Дата: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm"));
            sb.AppendLine();
            sb.AppendLine("Количество студентов: " + list.Count);

            if (list.Count > 0)
            {
                sb.AppendLine("Средний балл группы: " + list.Average(s => s.AverageGrade).ToString("F2"));
                sb.AppendLine("Студентов с высоким баллом (>=4.5): " + list.Count(s => s.AverageGrade >= 4.5));
                sb.AppendLine("Студентов с низким баллом (<3): " + list.Count(s => s.AverageGrade < 3));
                sb.AppendLine();
                sb.AppendLine("Список студентов:");
                foreach (var s in list)
                {
                    sb.AppendLine("  - " + s.FullName + " (" + s.Group + "), балл: " + s.AverageGrade.ToString("F2"));
                }
            }
            else
            {
                sb.AppendLine("Нет данных для формирования отчёта.");
            }

            return sb.ToString();
        }
    }
}