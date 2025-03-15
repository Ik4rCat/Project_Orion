using System;
using System.Collections.Generic;
using Orion.Core.Enums;

namespace Orion.Core.Models
{
    /// <summary>
    /// Модель информации о спринте в Agile-методологии
    /// </summary>
    public class SprintInfo : BaseEntity
    {
        /// <summary>
        /// Название спринта
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Номер спринта
        /// </summary>
        public int Number { get; set; }
        
        /// <summary>
        /// Описание/цели спринта
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Дата начала спринта
        /// </summary>
        public DateTime StartDate { get; set; }
        
        /// <summary>
        /// Дата окончания спринта
        /// </summary>
        public DateTime EndDate { get; set; }
        
        /// <summary>
        /// ID связанного проекта
        /// </summary>
        public int ProjectId { get; set; }
        
        /// <summary>
        /// Связанный проект
        /// </summary>
        public GameProject Project { get; set; }
        
        /// <summary>
        /// Статус спринта
        /// </summary>
        public SprintStatus Status { get; set; }
        
        /// <summary>
        /// Задачи в спринте
        /// </summary>
        public List<TaskItem> Tasks { get; set; } = new List<TaskItem>();
        
        /// <summary>
        /// Баг-репорты в спринте
        /// </summary>
        public List<BugReport> BugReports { get; set; } = new List<BugReport>();
        
        /// <summary>
        /// Заметки спринта
        /// </summary>
        public List<Note> Notes { get; set; } = new List<Note>();
        
        /// <summary>
        /// Запланированная скорость команды (Story Points)
        /// </summary>
        public int PlannedVelocity { get; set; }
        
        /// <summary>
        /// Фактическая скорость команды (Story Points)
        /// </summary>
        public int ActualVelocity { get; set; }
        
        /// <summary>
        /// Запланированные часы работы
        /// </summary>
        public int PlannedHours { get; set; }
        
        /// <summary>
        /// Фактически затраченные часы
        /// </summary>
        public int ActualHours { get; set; }
        
        /// <summary>
        /// Общее количество задач
        /// </summary>
        public int TotalTasks { get; set; }
        
        /// <summary>
        /// Количество завершенных задач
        /// </summary>
        public int CompletedTasks { get; set; }
        
        /// <summary>
        /// Результаты ретроспективы спринта
        /// </summary>
        public string Retrospective { get; set; }
        
        /// <summary>
        /// Вычисление процента завершения задач
        /// </summary>
        public double CompletionPercentage
        {
            get
            {
                if (TotalTasks == 0)
                    return 0;
                
                return Math.Round((double)CompletedTasks / TotalTasks * 100, 2);
            }
        }
    }
    
    /// <summary>
    /// Статус спринта
    /// </summary>
    public enum SprintStatus
    {
        Planned,
        InProgress,
        Completed,
        Cancelled
    }
} 