using System;
using System.Collections.Generic;
using Orion.Core.Enums;

namespace Orion.Core.Models
{
    /// <summary>
    /// Модель отчета о баге
    /// </summary>
    public class BugReport : BaseEntity
    {
        /// <summary>
        /// Заголовок бага
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Подробное описание бага
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Шаги для воспроизведения
        /// </summary>
        public string ReproductionSteps { get; set; }
        
        /// <summary>
        /// Ожидаемое поведение
        /// </summary>
        public string ExpectedBehavior { get; set; }
        
        /// <summary>
        /// Фактическое поведение
        /// </summary>
        public string ActualBehavior { get; set; }
        
        /// <summary>
        /// Приоритет бага
        /// </summary>
        public Priority Priority { get; set; }
        
        /// <summary>
        /// Серьезность бага
        /// </summary>
        public BugSeverity Severity { get; set; }
        
        /// <summary>
        /// Статус бага
        /// </summary>
        public BugStatus Status { get; set; }
        
        /// <summary>
        /// ID пользователя, создавшего баг-репорт
        /// </summary>
        public string ReportedById { get; set; }
        
        /// <summary>
        /// Пользователь, создавший баг-репорт
        /// </summary>
        public ApplicationUser ReportedBy { get; set; }
        
        /// <summary>
        /// ID пользователя, назначенного для исправления
        /// </summary>
        public string AssignedToId { get; set; }
        
        /// <summary>
        /// Пользователь, назначенный для исправления
        /// </summary>
        public ApplicationUser AssignedTo { get; set; }
        
        /// <summary>
        /// ID связанного проекта
        /// </summary>
        public int ProjectId { get; set; }
        
        /// <summary>
        /// Связанный проект
        /// </summary>
        public GameProject Project { get; set; }
        
        /// <summary>
        /// Версия проекта, в которой обнаружен баг
        /// </summary>
        public string DiscoveredInVersion { get; set; }
        
        /// <summary>
        /// Версия проекта, в которой исправлен баг
        /// </summary>
        public string FixedInVersion { get; set; }
        
        /// <summary>
        /// Дата обнаружения
        /// </summary>
        public DateTime ReportedAt { get; set; }
        
        /// <summary>
        /// Дата исправления
        /// </summary>
        public DateTime? FixedAt { get; set; }
        
        /// <summary>
        /// Предполагаемая дата исправления
        /// </summary>
        public DateTime? TargetFixDate { get; set; }
        
        /// <summary>
        /// Скриншоты или файлы, связанные с багом
        /// </summary>
        public List<string> Attachments { get; set; } = new List<string>();
        
        /// <summary>
        /// Комментарии к баг-репорту
        /// </summary>
        public List<BugComment> Comments { get; set; } = new List<BugComment>();
        
        /// <summary>
        /// Связанный коммит, исправляющий баг
        /// </summary>
        public string FixCommitId { get; set; }
        
        /// <summary>
        /// Оценка времени на исправление (в часах)
        /// </summary>
        public decimal EstimatedFixTime { get; set; }
        
        /// <summary>
        /// Фактическое время, затраченное на исправление (в часах)
        /// </summary>
        public decimal ActualFixTime { get; set; }
        
        /// <summary>
        /// Теги для категоризации бага
        /// </summary>
        public List<string> Tags { get; set; } = new List<string>();
    }
    
    /// <summary>
    /// Серьезность бага
    /// </summary>
    public enum BugSeverity
    {
        Trivial,
        Minor,
        Major,
        Critical,
        Blocker
    }
    
    /// <summary>
    /// Статус бага
    /// </summary>
    public enum BugStatus
    {
        New,
        Confirmed,
        InProgress,
        Fixed,
        Testing,
        Reopened,
        Closed,
        Rejected,
        Duplicate
    }
    
    /// <summary>
    /// Комментарий к баг-репорту
    /// </summary>
    public class BugComment : BaseEntity
    {
        /// <summary>
        /// Текст комментария
        /// </summary>
        public string Text { get; set; }
        
        /// <summary>
        /// ID пользователя, создавшего комментарий
        /// </summary>
        public string UserId { get; set; }
        
        /// <summary>
        /// Пользователь, создавший комментарий
        /// </summary>
        public ApplicationUser User { get; set; }
        
        /// <summary>
        /// ID связанного баг-репорта
        /// </summary>
        public int BugReportId { get; set; }
        
        /// <summary>
        /// Связанный баг-репорт
        /// </summary>
        public BugReport BugReport { get; set; }
    }
} 