using System;
using System.Collections.Generic;
using Orion.Core.Enums;

namespace Orion.Core.Models
{
    /// <summary>
    /// Модель интеграции с игровым движком
    /// </summary>
    public class EngineIntegration : BaseEntity
    {
        /// <summary>
        /// Название интеграции
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Тип игрового движка
        /// </summary>
        public GameEngine EngineType { get; set; }
        
        /// <summary>
        /// Версия игрового движка
        /// </summary>
        public string EngineVersion { get; set; }
        
        /// <summary>
        /// Описание интеграции
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// API ключ для подключения к движку
        /// </summary>
        public string ApiKey { get; set; }
        
        /// <summary>
        /// URL для подключения к API движка
        /// </summary>
        public string ApiUrl { get; set; }
        
        /// <summary>
        /// Конфигурация интеграции (в формате JSON)
        /// </summary>
        public string ConfigurationJson { get; set; }
        
        /// <summary>
        /// Статус интеграции
        /// </summary>
        public IntegrationStatus Status { get; set; }
        
        /// <summary>
        /// Дата последней синхронизации
        /// </summary>
        public DateTime? LastSyncDate { get; set; }
        
        /// <summary>
        /// Включена ли автоматическая синхронизация
        /// </summary>
        public bool AutoSyncEnabled { get; set; }
        
        /// <summary>
        /// Интервал автоматической синхронизации (в минутах)
        /// </summary>
        public int AutoSyncIntervalMinutes { get; set; }
        
        /// <summary>
        /// Поддерживаемые платформы
        /// </summary>
        public List<GamePlatform> SupportedPlatforms { get; set; } = new List<GamePlatform>();
        
        /// <summary>
        /// Доступные шаблоны проектов
        /// </summary>
        public List<string> ProjectTemplates { get; set; } = new List<string>();
        
        /// <summary>
        /// Список доступных плагинов
        /// </summary>
        public List<EnginePlugin> AvailablePlugins { get; set; } = new List<EnginePlugin>();
        
        /// <summary>
        /// Журнал событий интеграции
        /// </summary>
        public List<IntegrationEvent> EventLog { get; set; } = new List<IntegrationEvent>();
        
        /// <summary>
        /// ID пользователя, создавшего интеграцию
        /// </summary>
        public string CreatedById { get; set; }
        
        /// <summary>
        /// Пользователь, создавший интеграцию
        /// </summary>
        public ApplicationUser CreatedBy { get; set; }
    }
    
    /// <summary>
    /// Статус интеграции
    /// </summary>
    public enum IntegrationStatus
    {
        Connected,
        Disconnected,
        Error,
        Configuring,
        Syncing
    }
    
    /// <summary>
    /// Модель плагина для игрового движка
    /// </summary>
    public class EnginePlugin
    {
        /// <summary>
        /// Идентификатор плагина
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// Название плагина
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Версия плагина
        /// </summary>
        public string Version { get; set; }
        
        /// <summary>
        /// Описание плагина
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// URL для скачивания плагина
        /// </summary>
        public string DownloadUrl { get; set; }
        
        /// <summary>
        /// Является ли плагин установленным
        /// </summary>
        public bool IsInstalled { get; set; }
        
        /// <summary>
        /// Размер плагина (в килобайтах)
        /// </summary>
        public long SizeKB { get; set; }
    }
    
    /// <summary>
    /// Модель события интеграции
    /// </summary>
    public class IntegrationEvent
    {
        /// <summary>
        /// Тип события
        /// </summary>
        public IntegrationEventType Type { get; set; }
        
        /// <summary>
        /// Сообщение события
        /// </summary>
        public string Message { get; set; }
        
        /// <summary>
        /// Дата и время события
        /// </summary>
        public DateTime Timestamp { get; set; }
        
        /// <summary>
        /// Дополнительные данные события (в формате JSON)
        /// </summary>
        public string DataJson { get; set; }
    }
    
    /// <summary>
    /// Тип события интеграции
    /// </summary>
    public enum IntegrationEventType
    {
        Info,
        Warning,
        Error,
        Sync,
        Connection,
        Configuration
    }
} 