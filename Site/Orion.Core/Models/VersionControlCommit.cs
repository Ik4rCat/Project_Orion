using System;
using System.Collections.Generic;
using Orion.Core.Enums;

namespace Orion.Core.Models
{
    /// <summary>
    /// Модель коммита в системе контроля версий
    /// </summary>
    public class VersionControlCommit : BaseEntity
    {
        /// <summary>
        /// Идентификатор коммита в системе контроля версий
        /// </summary>
        public string CommitId { get; set; }
        
        /// <summary>
        /// Сокращенный идентификатор коммита
        /// </summary>
        public string ShortCommitId => CommitId?.Length > 8 ? CommitId.Substring(0, 8) : CommitId;
        
        /// <summary>
        /// Сообщение коммита
        /// </summary>
        public string Message { get; set; }
        
        /// <summary>
        /// ID пользователя, создавшего коммит
        /// </summary>
        public string AuthorId { get; set; }
        
        /// <summary>
        /// Пользователь, создавший коммит
        /// </summary>
        public ApplicationUser Author { get; set; }
        
        /// <summary>
        /// Имя пользователя в системе контроля версий
        /// </summary>
        public string AuthorName { get; set; }
        
        /// <summary>
        /// Email пользователя в системе контроля версий
        /// </summary>
        public string AuthorEmail { get; set; }
        
        /// <summary>
        /// Дата и время создания коммита
        /// </summary>
        public DateTime CommitDate { get; set; }
        
        /// <summary>
        /// Тип коммита
        /// </summary>
        public CommitType Type { get; set; }
        
        /// <summary>
        /// ID проекта
        /// </summary>
        public int ProjectId { get; set; }
        
        /// <summary>
        /// Проект
        /// </summary>
        public GameProject Project { get; set; }
        
        /// <summary>
        /// Ветка, в которую был отправлен коммит
        /// </summary>
        public string Branch { get; set; }
        
        /// <summary>
        /// URL для просмотра коммита в web-интерфейсе
        /// </summary>
        public string ViewUrl { get; set; }
        
        /// <summary>
        /// Список измененных файлов
        /// </summary>
        public List<CommitFile> ChangedFiles { get; set; } = new List<CommitFile>();
        
        /// <summary>
        /// Количество добавленных строк
        /// </summary>
        public int LinesAdded { get; set; }
        
        /// <summary>
        /// Количество удаленных строк
        /// </summary>
        public int LinesRemoved { get; set; }
        
        /// <summary>
        /// ID родительского коммита
        /// </summary>
        public string ParentCommitId { get; set; }
        
        /// <summary>
        /// ID пул-реквеста/мерж-запроса (если применимо)
        /// </summary>
        public string PullRequestId { get; set; }
        
        /// <summary>
        /// Список связанных задач
        /// </summary>
        public List<int> RelatedTaskIds { get; set; } = new List<int>();
        
        /// <summary>
        /// Список исправленных багов
        /// </summary>
        public List<int> FixedBugIds { get; set; } = new List<int>();
        
        /// <summary>
        /// Метрики кода (покрытие тестами, сложность и т.д.)
        /// </summary>
        public Dictionary<string, double> CodeMetrics { get; set; } = new Dictionary<string, double>();
    }
    
    /// <summary>
    /// Информация об измененном файле в коммите
    /// </summary>
    public class CommitFile
    {
        /// <summary>
        /// Путь к файлу
        /// </summary>
        public string FilePath { get; set; }
        
        /// <summary>
        /// Тип изменения
        /// </summary>
        public FileChangeType ChangeType { get; set; }
        
        /// <summary>
        /// Количество добавленных строк
        /// </summary>
        public int LinesAdded { get; set; }
        
        /// <summary>
        /// Количество удаленных строк
        /// </summary>
        public int LinesRemoved { get; set; }
        
        /// <summary>
        /// URL для просмотра изменений в файле
        /// </summary>
        public string DiffUrl { get; set; }
    }
    
    /// <summary>
    /// Тип изменения файла
    /// </summary>
    public enum FileChangeType
    {
        Added,
        Modified,
        Deleted,
        Renamed,
        Copied
    }
} 