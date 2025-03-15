using System;
using System.Collections.Generic;
using Orion.Core.Enums;

namespace Orion.Core.Models
{
    /// <summary>
    /// Модель информации о сборке игры
    /// </summary>
    public class BuildInfo : BaseEntity
    {
        /// <summary>
        /// Номер сборки
        /// </summary>
        public string BuildNumber { get; set; }
        
        /// <summary>
        /// Версия сборки
        /// </summary>
        public string Version { get; set; }
        
        /// <summary>
        /// Описание сборки
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// ID проекта
        /// </summary>
        public int ProjectId { get; set; }
        
        /// <summary>
        /// Проект
        /// </summary>
        public GameProject Project { get; set; }
        
        /// <summary>
        /// ID пользователя, инициировавшего сборку
        /// </summary>
        public string InitiatedById { get; set; }
        
        /// <summary>
        /// Пользователь, инициировавший сборку
        /// </summary>
        public ApplicationUser InitiatedBy { get; set; }
        
        /// <summary>
        /// Дата и время начала сборки
        /// </summary>
        public DateTime StartTime { get; set; }
        
        /// <summary>
        /// Дата и время завершения сборки
        /// </summary>
        public DateTime? EndTime { get; set; }
        
        /// <summary>
        /// Статус сборки
        /// </summary>
        public BuildStatus Status { get; set; }
        
        /// <summary>
        /// Идентификатор коммита исходного кода
        /// </summary>
        public string CommitId { get; set; }
        
        /// <summary>
        /// URL для загрузки сборки
        /// </summary>
        public string DownloadUrl { get; set; }
        
        /// <summary>
        /// URL для доступа к инструментам CI/CD
        /// </summary>
        public string CiCdUrl { get; set; }
        
        /// <summary>
        /// Список целевых платформ сборки
        /// </summary>
        public List<GamePlatform> Platforms { get; set; } = new List<GamePlatform>();
        
        /// <summary>
        /// Размер сборки (в мегабайтах)
        /// </summary>
        public double SizeMB { get; set; }
        
        /// <summary>
        /// Продолжительность сборки (в минутах)
        /// </summary>
        public double Duration => EndTime.HasValue ? Math.Round((EndTime.Value - StartTime).TotalMinutes, 2) : 0;
        
        /// <summary>
        /// Баги, исправленные в этой сборке
        /// </summary>
        public List<int> FixedBugIds { get; set; } = new List<int>();
        
        /// <summary>
        /// Лог сборки
        /// </summary>
        public string BuildLog { get; set; }
        
        /// <summary>
        /// Результаты автоматических тестов
        /// </summary>
        public string TestResults { get; set; }
        
        /// <summary>
        /// Количество пройденных тестов
        /// </summary>
        public int TestsPassed { get; set; }
        
        /// <summary>
        /// Количество проваленных тестов
        /// </summary>
        public int TestsFailed { get; set; }
        
        /// <summary>
        /// Процент успешности тестов
        /// </summary>
        public double TestPassRate => (TestsPassed + TestsFailed) > 0 ? Math.Round((double)TestsPassed / (TestsPassed + TestsFailed) * 100, 2) : 0;
        
        /// <summary>
        /// Информация о развертывании
        /// </summary>
        public string DeploymentInfo { get; set; }
        
        /// <summary>
        /// Примечания к выпуску
        /// </summary>
        public string ReleaseNotes { get; set; }
    }
} 