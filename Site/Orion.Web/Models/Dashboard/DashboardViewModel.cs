using System;
using System.Collections.Generic;

namespace Orion.Web.Models.Dashboard
{
    public class DashboardViewModel
    {
        // Список задач
        public List<Orion.Core.Models.TaskItem> Tasks { get; set; } = new List<Orion.Core.Models.TaskItem>();

        // Список заметок
        public List<Orion.Core.Models.Note> Notes { get; set; } = new List<Orion.Core.Models.Note>();

        // Список групп
        public List<Orion.Core.Models.Group> Groups { get; set; } = new List<Orion.Core.Models.Group>();

        // Подсчеты задач
        public int CompletedTasksCount { get; set; }
        public int PendingTasksCount { get; set; }
        public int OverdueTasksCount { get; set; }

        // Общее количество заметок
        public int TotalNotesCount { get; set; }

        // Текущий пользователь
        public Orion.Core.Models.ApplicationUser? CurrentUser { get; set; }

        // Конструктор по умолчанию
        public DashboardViewModel() { }

        // Конструктор с параметром
        public DashboardViewModel(Orion.Core.Models.ApplicationUser currentUser)
        {
            CurrentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
        }
    }
}