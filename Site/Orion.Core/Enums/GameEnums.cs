namespace Orion.Core.Enums
{
    /// <summary>
    /// Жанры игр
    /// </summary>
    public enum GameGenre
    {
        Action,
        Adventure,
        RPG,
        Simulation,
        Strategy,
        Puzzle,
        Sports,
        Racing,
        Fighting,
        Shooter,
        Platformer,
        Horror,
        Survival,
        OpenWorld,
        MMORPG,
        MOBA,
        BattleRoyale,
        CardGame,
        Educational,
        Casual,
        Other
    }
    
    /// <summary>
    /// Игровые платформы
    /// </summary>
    public enum GamePlatform
    {
        Windows,
        MacOS,
        Linux,
        Android,
        iOS,
        PlayStation4,
        PlayStation5,
        XboxOne,
        XboxSeriesX,
        NintendoSwitch,
        WebGL,
        VR,
        AR
    }
    
    /// <summary>
    /// Игровые движки
    /// </summary>
    public enum GameEngine
    {
        Unity,
        UnrealEngine,
        Godot,
        GameMaker,
        CryEngine,
        LumberYard,
        Custom,
        Other
    }
    
    /// <summary>
    /// Стадии разработки
    /// </summary>
    public enum DevelopmentStage
    {
        Concept,
        Prototype,
        PreAlpha,
        Alpha,
        Beta,
        ReleaseCandidate,
        Release,
        LiveService,
        Maintenance
    }
    
    /// <summary>
    /// Статусы проекта
    /// </summary>
    public enum ProjectStatus
    {
        NotStarted,
        InProgress,
        OnHold,
        Completed,
        Cancelled
    }
    
    /// <summary>
    /// Роли разработчиков
    /// </summary>
    public enum DeveloperRole
    {
        ProjectManager,
        LeadProgrammer,
        Programmer,
        LeadArtist,
        Artist,
        Animator,
        LeadDesigner,
        GameDesigner,
        LevelDesigner,
        UIDesigner,
        SoundDesigner,
        Composer,
        QALead,
        QATester,
        Producer,
        Writer,
        Translator,
        MarketingSpecialist
    }
    
    /// <summary>
    /// Типы игровых активов
    /// </summary>
    public enum AssetType
    {
        Model3D,
        Texture,
        Animation,
        Sound,
        Music,
        Script,
        Prefab,
        Material,
        ParticleEffect,
        UI,
        Level,
        Shader,
        Font,
        Video,
        Document
    }
    
    /// <summary>
    /// Статусы сборки
    /// </summary>
    public enum BuildStatus
    {
        InProgress,
        Success,
        Failed,
        Cancelled,
        Deployed
    }
    
    /// <summary>
    /// Типы коммитов в системе версионного контроля
    /// </summary>
    public enum CommitType
    {
        Feature,
        Bugfix,
        Hotfix,
        Refactoring,
        Documentation,
        Testing,
        Assets,
        Build,
        Other
    }
} 