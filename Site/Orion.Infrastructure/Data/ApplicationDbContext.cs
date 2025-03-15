using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Orion.Core.Models;

namespace Orion.Infrastructure.Data
{
    /// <summary>
    /// Контекст базы данных приложения
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Группы
        /// </summary>
        public DbSet<Group> Groups { get; set; } = null!;

        /// <summary>
        /// Связи пользователей и групп
        /// </summary>
        public DbSet<UserGroup> UserGroups { get; set; } = null!;

        /// <summary>
        /// Задачи
        /// </summary>
        public DbSet<TaskItem> Tasks { get; set; } = null!;

        /// <summary>
        /// Подзадачи
        /// </summary>
        public DbSet<SubTask> SubTasks { get; set; } = null!;

        /// <summary>
        /// Теги
        /// </summary>
        public DbSet<Tag> Tags { get; set; } = null!;

        /// <summary>
        /// Связи задач и тегов
        /// </summary>
        public DbSet<TaskTag> TaskTags { get; set; } = null!;

        /// <summary>
        /// Заметки
        /// </summary>
        public DbSet<Note> Notes { get; set; } = null!;

        /// <summary>
        /// Связи заметок и тегов
        /// </summary>
        public DbSet<NoteTag> NoteTags { get; set; } = null!;

        /// <summary>
        /// Настройка моделей при создании
        /// </summary>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Настройка связей между моделями
            builder.Entity<UserGroup>()
                .HasOne(ug => ug.User)
                .WithMany(u => u.UserGroups)
                .HasForeignKey(ug => ug.UserId);

            builder.Entity<UserGroup>()
                .HasOne(ug => ug.Group)
                .WithMany(g => g.UserGroups)
                .HasForeignKey(ug => ug.GroupId);

            builder.Entity<TaskItem>()
                .HasOne(t => t.CreatedBy)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<TaskItem>()
                .HasOne(t => t.Group)
                .WithMany(g => g.Tasks)
                .HasForeignKey(t => t.GroupId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<SubTask>()
                .HasOne(st => st.Task)
                .WithMany(t => t.SubTasks)
                .HasForeignKey(st => st.TaskId);

            builder.Entity<TaskTag>()
                .HasOne(tt => tt.Task)
                .WithMany(t => t.TaskTags)
                .HasForeignKey(tt => tt.TaskId);

            builder.Entity<TaskTag>()
                .HasOne(tt => tt.Tag)
                .WithMany(t => t.TaskTags)
                .HasForeignKey(tt => tt.TagId);

            builder.Entity<Note>()
                .HasOne(n => n.CreatedBy)
                .WithMany(u => u.Notes)
                .HasForeignKey(n => n.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Note>()
                .HasOne(n => n.Group)
                .WithMany(g => g.Notes)
                .HasForeignKey(n => n.GroupId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<NoteTag>()
                .HasOne(nt => nt.Note)
                .WithMany(n => n.NoteTags)
                .HasForeignKey(nt => nt.NoteId);

            builder.Entity<NoteTag>()
                .HasOne(nt => nt.Tag)
                .WithMany()
                .HasForeignKey(nt => nt.TagId);
        }
    }
} 