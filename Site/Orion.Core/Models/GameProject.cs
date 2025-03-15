using System;
using System.Collections.Generic;
using Orion.Core.Enums;

namespace Orion.Core.Models
{
    /// <summary>
    /// Модель игрового проекта для студии разработки
    /// </summary>
    public class GameProject : BaseEntity
    {
        /// <summary>
        /// Название игрового проекта
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Подробное описание проекта
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// URL изображения проекта (обложка, логотип)
        /// </summary>
        public string ImageUrl { get; set; }
        
        /// <summary>
        /// Жанр игры
        /// </summary>
        public GameGenre Genre { get; set; }
        
        /// <summary>
        /// Целевые платформы
        /// </summary>
        public List<GamePlatform> TargetPlatforms { get; set; } = new List<GamePlatform>();
        
        /// <summary>
        /// Используемый игровой движок
        /// </summary>
        public GameEngine Engine { get; set; }
        
        /// <summary>
        /// Версия игрового движка
        /// </summary>
        public string EngineVersion { get; set; }
        
        /// <summary>
        /// Текущая стадия разработки
        /// </summary>
        public DevelopmentStage Stage { get; set; }
        
        /// <summary>
        /// Дата начала проекта
        /// </summary>
        public DateTime StartDate { get; set; }
        
        /// <summary>
        /// Предполагаемая дата релиза
        /// </summary>
        public DateTime? TargetReleaseDate { get; set; }
        
        /// <summary>
        /// Текущая версия проекта
        /// </summary>
        public string CurrentVersion { get; set; }
        
        /// <summary>
        /// Руководитель проекта (ID пользователя)
        /// </summary>
        public string ProjectLeadId { get; set; }
        
        /// <summary>
        /// Навигационное свойство для руководителя проекта
        /// </summary>
        public ApplicationUser ProjectLead { get; set; }
        
        /// <summary>
        /// Репозиторий для хранения кода
        /// </summary>
        public string RepositoryUrl { get; set; }
        
        /// <summary>
        /// Бюджет проекта
        /// </summary>
        public decimal Budget { get; set; }
        
        /// <summary>
        /// Текущие расходы
        /// </summary>
        public decimal CurrentExpenses { get; set; }
        
        /// <summary>
        /// Прогресс разработки (в процентах)
        /// </summary>
        public int Progress { get; set; }
        
        /// <summary>
        /// Статус проекта
        /// </summary>
        public ProjectStatus Status { get; set; }
        
        /// <summary>
        /// Команды, работающие над проектом
        /// </summary>
        public List<DevelopmentTeam> Teams { get; set; } = new List<DevelopmentTeam>();
        
        /// <summary>
        /// Спринты проекта
        /// </summary>
        public List<SprintInfo> Sprints { get; set; } = new List<SprintInfo>();
        
        /// <summary>
        /// Задачи в проекте
        /// </summary>
        public List<TaskItem> Tasks { get; set; } = new List<TaskItem>();
        
        /// <summary>
        /// Баг-репорты в проекте
        /// </summary>
        public List<BugReport> BugReports { get; set; } = new List<BugReport>();
        
        /// <summary>
        /// Ассеты проекта
        /// </summary>
        public List<GameAsset> Assets { get; set; } = new List<GameAsset>();
        
        /// <summary>
        /// Сборки проекта
        /// </summary>
        public List<BuildInfo> Builds { get; set; } = new List<BuildInfo>();
    }
} 