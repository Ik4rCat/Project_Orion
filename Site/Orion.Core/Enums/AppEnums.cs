namespace Orion.Core.Enums
{
    /// <summary>
    /// Тип статуса задачи
    /// </summary>
    public enum TaskStatus
    {
        /// <summary>
        /// Новая - в очереди
        /// </summary>
        New = 0,
        
        /// <summary>
        /// В работе
        /// </summary>
        InProgress = 1,
        
        /// <summary>
        /// Выполнена
        /// </summary>
        Completed = 2,
        
        /// <summary>
        /// Отложена
        /// </summary>
        Deferred = 3,
        
        /// <summary>
        /// Отменена
        /// </summary>
        Cancelled = 4
    }

    /// <summary>
    /// Уровень приоритета задачи
    /// </summary>
    public enum Priority
    {
        /// <summary>
        /// Низкий приоритет
        /// </summary>
        Low = 0,
        
        /// <summary>
        /// Средний приоритет
        /// </summary>
        Medium = 1,
        
        /// <summary>
        /// Высокий приоритет
        /// </summary>
        High = 2,
        
        /// <summary>
        /// Критический приоритет
        /// </summary>
        Critical = 3
    }

    /// <summary>
    /// Тип заметки
    /// </summary>
    public enum NoteType
    {
        /// <summary>
        /// Базовая текстовая заметка
        /// </summary>
        Text = 0,
        
        /// <summary>
        /// Заметка с чек-листом
        /// </summary>
        Checklist = 1,
        
        /// <summary>
        /// Заметка с форматированным текстом (markdown)
        /// </summary>
        Markdown = 2
    }

    /// <summary>
    /// Тема оформления
    /// </summary>
    public enum Theme
    {
        /// <summary>
        /// Светлая тема
        /// </summary>
        Light = 0,
        
        /// <summary>
        /// Темная тема
        /// </summary>
        Dark = 1
    }

    /// <summary>
    /// Роль пользователя в группе
    /// </summary>
    public enum GroupRole
    {
        /// <summary>
        /// Обычный участник
        /// </summary>
        Member = 0,
        
        /// <summary>
        /// Администратор группы
        /// </summary>
        Admin = 1,
        
        /// <summary>
        /// Владелец группы
        /// </summary>
        Owner = 2
    }
} 