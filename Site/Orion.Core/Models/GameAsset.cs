using System;
using System.Collections.Generic;
using Orion.Core.Enums;

namespace Orion.Core.Models
{
    /// <summary>
    /// Модель игрового ассета
    /// </summary>
    public class GameAsset : BaseEntity
    {
        /// <summary>
        /// Название ассета
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Описание ассета
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Тип ассета
        /// </summary>
        public AssetType Type { get; set; }
        
        /// <summary>
        /// URL предпросмотра ассета
        /// </summary>
        public string PreviewUrl { get; set; }
        
        /// <summary>
        /// URL для скачивания ассета
        /// </summary>
        public string DownloadUrl { get; set; }
        
        /// <summary>
        /// ID проекта, к которому относится ассет
        /// </summary>
        public int ProjectId { get; set; }
        
        /// <summary>
        /// Проект, к которому относится ассет
        /// </summary>
        public GameProject Project { get; set; }
        
        /// <summary>
        /// ID пользователя, создавшего ассет
        /// </summary>
        public string CreatedById { get; set; }
        
        /// <summary>
        /// Пользователь, создавший ассет
        /// </summary>
        public ApplicationUser CreatedBy { get; set; }
        
        /// <summary>
        /// Версия ассета
        /// </summary>
        public string Version { get; set; }
        
        /// <summary>
        /// Размер файла (в килобайтах)
        /// </summary>
        public long FileSizeKB { get; set; }
        
        /// <summary>
        /// Категория ассета
        /// </summary>
        public string Category { get; set; }
        
        /// <summary>
        /// Теги ассета
        /// </summary>
        public List<string> Tags { get; set; } = new List<string>();
        
        /// <summary>
        /// История версий ассета
        /// </summary>
        public List<AssetVersion> VersionHistory { get; set; } = new List<AssetVersion>();
        
        /// <summary>
        /// Статус ассета
        /// </summary>
        public AssetStatus Status { get; set; }
        
        /// <summary>
        /// Дата последнего использования
        /// </summary>
        public DateTime? LastUsedAt { get; set; }
        
        /// <summary>
        /// Зависимости ассета (другие ассеты)
        /// </summary>
        public List<int> DependencyIds { get; set; } = new List<int>();
        
        /// <summary>
        /// Путь к ассету в проекте
        /// </summary>
        public string ProjectPath { get; set; }
        
        /// <summary>
        /// Метаданные ассета (в формате JSON)
        /// </summary>
        public string Metadata { get; set; }
    }
    
    /// <summary>
    /// Модель версии ассета
    /// </summary>
    public class AssetVersion : BaseEntity
    {
        /// <summary>
        /// Номер версии
        /// </summary>
        public string VersionNumber { get; set; }
        
        /// <summary>
        /// Описание изменений
        /// </summary>
        public string ChangeDescription { get; set; }
        
        /// <summary>
        /// ID ассета
        /// </summary>
        public int AssetId { get; set; }
        
        /// <summary>
        /// Ассет
        /// </summary>
        public GameAsset Asset { get; set; }
        
        /// <summary>
        /// ID пользователя, создавшего версию
        /// </summary>
        public string CreatedById { get; set; }
        
        /// <summary>
        /// Пользователь, создавший версию
        /// </summary>
        public ApplicationUser CreatedBy { get; set; }
        
        /// <summary>
        /// URL для скачивания этой версии ассета
        /// </summary>
        public string DownloadUrl { get; set; }
        
        /// <summary>
        /// Размер файла (в килобайтах)
        /// </summary>
        public long FileSizeKB { get; set; }
    }
    
    /// <summary>
    /// Статус ассета
    /// </summary>
    public enum AssetStatus
    {
        Draft,
        InReview,
        Approved,
        Rejected,
        Deprecated,
        Archived
    }
} 