using System;
using System.Collections.Generic;
using Orion.Core.Enums;

namespace Orion.Core.Models
{
    /// <summary>
    /// Модель команды разработчиков
    /// </summary>
    public class DevelopmentTeam : BaseEntity
    {
        /// <summary>
        /// Название команды
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Описание команды
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// URL аватара команды
        /// </summary>
        public string AvatarUrl { get; set; }
        
        /// <summary>
        /// Специализация команды
        /// </summary>
        public TeamSpecialization Specialization { get; set; }
        
        /// <summary>
        /// ID проекта, над которым работает команда
        /// </summary>
        public int? ProjectId { get; set; }
        
        /// <summary>
        /// Проект, над которым работает команда
        /// </summary>
        public GameProject Project { get; set; }
        
        /// <summary>
        /// ID руководителя команды
        /// </summary>
        public string TeamLeadId { get; set; }
        
        /// <summary>
        /// Руководитель команды
        /// </summary>
        public ApplicationUser TeamLead { get; set; }
        
        /// <summary>
        /// Участники команды
        /// </summary>
        public List<TeamMember> Members { get; set; } = new List<TeamMember>();
        
        /// <summary>
        /// Задачи, назначенные команде
        /// </summary>
        public List<TaskItem> Tasks { get; set; } = new List<TaskItem>();
        
        /// <summary>
        /// Спринты команды
        /// </summary>
        public List<SprintInfo> Sprints { get; set; } = new List<SprintInfo>();
        
        /// <summary>
        /// Статистика производительности команды
        /// </summary>
        public Dictionary<string, double> PerformanceMetrics { get; set; } = new Dictionary<string, double>();
        
        /// <summary>
        /// Дата формирования команды
        /// </summary>
        public DateTime FormedDate { get; set; }
        
        /// <summary>
        /// Количество участников команды
        /// </summary>
        public int MemberCount => Members?.Count ?? 0;
        
        /// <summary>
        /// Вычисляет среднюю скорость команды (Story Points)
        /// </summary>
        public double AverageVelocity { get; set; }
    }
    
    /// <summary>
    /// Специализация команды
    /// </summary>
    public enum TeamSpecialization
    {
        General,
        Programming,
        Art,
        Design,
        QA,
        Audio,
        UI,
        AI,
        Networking,
        Gameplay,
        Backend,
        Frontend,
        DevOps,
        Mobile,
        VR
    }
    
    /// <summary>
    /// Модель участника команды
    /// </summary>
    public class TeamMember : BaseEntity
    {
        /// <summary>
        /// ID пользователя
        /// </summary>
        public string UserId { get; set; }
        
        /// <summary>
        /// Пользователь
        /// </summary>
        public ApplicationUser User { get; set; }
        
        /// <summary>
        /// ID команды
        /// </summary>
        public int TeamId { get; set; }
        
        /// <summary>
        /// Команда
        /// </summary>
        public DevelopmentTeam Team { get; set; }
        
        /// <summary>
        /// Роль в команде
        /// </summary>
        public DeveloperRole Role { get; set; }
        
        /// <summary>
        /// Дата присоединения к команде
        /// </summary>
        public DateTime JoinedAt { get; set; }
        
        /// <summary>
        /// Нагрузка (процент времени, уделяемый проекту)
        /// </summary>
        public int Allocation { get; set; }
        
        /// <summary>
        /// Задачи, назначенные участнику
        /// </summary>
        public List<TaskItem> Tasks { get; set; } = new List<TaskItem>();
        
        /// <summary>
        /// Статистика производительности участника
        /// </summary>
        public Dictionary<string, double> PerformanceMetrics { get; set; } = new Dictionary<string, double>();
    }
} 