using System;
using System.Collections.Generic;
using Orion.Core.Models;
using Orion.Core.Enums;

namespace Orion.Web.Models.Dashboard
{
    public class DeveloperDashboardViewModel
    {
        // Текущие проекты (игры)
        public List<GameProject> GameProjects { get; set; } = new List<GameProject>();

        // Активные задачи по ролям
        public List<TaskItem> ProgrammingTasks { get; set; } = new List<TaskItem>();
        public List<TaskItem> ArtTasks { get; set; } = new List<TaskItem>();
        public List<TaskItem> DesignTasks { get; set; } = new List<TaskItem>();
        public List<TaskItem> QATasks { get; set; } = new List<TaskItem>();
        public List<TaskItem> SoundTasks { get; set; } = new List<TaskItem>();

        // Список багов по приоритетам
        public List<BugReport> CriticalBugs { get; set; } = new List<BugReport>();
        public List<BugReport> HighPriorityBugs { get; set; } = new List<BugReport>();
        public List<BugReport> MediumPriorityBugs { get; set; } = new List<BugReport>();
        public List<BugReport> LowPriorityBugs { get; set; } = new List<BugReport>();

        // Ресурсы и активы
        public List<GameAsset> RecentAssets { get; set; } = new List<GameAsset>();
        
        // Информация о текущей итерации/спринте
        public SprintInfo CurrentSprint { get; set; }
        
        // Информация о командах
        public List<DevelopmentTeam> Teams { get; set; } = new List<DevelopmentTeam>();
        
        // Аналитика
        public Dictionary<string, double> CompletionRates { get; set; } = new Dictionary<string, double>();
        public Dictionary<string, int> BugCountByProject { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, double> VelocityByTeam { get; set; } = new Dictionary<string, double>();
        
        // Недавние коммиты в системе контроля версий
        public List<VersionControlCommit> RecentCommits { get; set; } = new List<VersionControlCommit>();
        
        // Интеграции с игровыми движками
        public List<EngineIntegration> EngineIntegrations { get; set; } = new List<EngineIntegration>();
        
        // Данные о сборках проекта
        public List<BuildInfo> RecentBuilds { get; set; } = new List<BuildInfo>();

        // Текущий пользователь
        public ApplicationUser CurrentUser { get; set; }

        // Счетчики
        public int TotalProjectsCount { get; set; }
        public int TotalAssetsCount { get; set; }
        public int TotalBugsCount { get; set; }
        public int TotalTasksCount { get; set; }
        public int TotalTeamMembersCount { get; set; }
        
        // Данные о производительности
        public double TeamEfficiency { get; set; }
        public double BugFixRate { get; set; }
        public double SprintCompletion { get; set; }
        
        // Конструктор
        public DeveloperDashboardViewModel() { }
        
        public DeveloperDashboardViewModel(ApplicationUser currentUser)
        {
            CurrentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
        }
    }
} 