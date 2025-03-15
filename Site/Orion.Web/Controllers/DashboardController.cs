using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orion.Core.Interfaces;
using Orion.Core.Models;
using Orion.Web.Models.Dashboard;
using System.Threading.Tasks;

using TaskStatus = Orion.Core.Enums.TaskStatus;

namespace Orion.Web.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRepository<TaskItem> _taskRepository;
        private readonly IRepository<Note> _noteRepository;
        private readonly IRepository<Group> _groupRepository;
        private readonly ILogger<DashboardController> _logger;

        public DashboardController(
            UserManager<ApplicationUser> userManager,
            IRepository<TaskItem> taskRepository,
            IRepository<Note> noteRepository,
            IRepository<Group> groupRepository,
            ILogger<DashboardController> logger)
        {
            _userManager = userManager;
            _taskRepository = taskRepository;
            _noteRepository = noteRepository;
            _groupRepository = groupRepository;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    _logger.LogWarning("Пользователь не найден при попытке доступа к дашборду");
                    return Challenge(); // Перенаправит на вход
                }

                _logger.LogInformation($"Загрузка дашборда для пользователя {user.Id}");

                // Получаем задачи пользователя
                var tasks = await _taskRepository.FindAsync(t => t.CreatedById == user.Id || t.AssignedToId == user.Id);
                
                // Получаем заметки пользователя
                var notes = await _noteRepository.FindAsync(n => n.CreatedById == user.Id);
                
                // Получаем группы пользователя
                var userGroups = await _groupRepository.FindAsync(g => g.UserGroups.Any(ug => ug.UserId == user.Id));

                // Считаем статистику
                var completedTasksCount = tasks.Count(t => t.Status == TaskStatus.Completed);
                var pendingTasksCount = tasks.Count(t => t.Status == TaskStatus.New);
                var overdueTasksCount = tasks.Count(t => t.DueDate.HasValue && t.DueDate < DateTime.Now && t.Status != TaskStatus.Completed);

                var model = new DashboardViewModel
                {
                    CurrentUser = user,
                    Tasks = tasks.OrderByDescending(t => t.CreatedAt).Take(5).ToList(),
                    Notes = notes.OrderByDescending(n => n.CreatedAt).Take(5).ToList(),
                    Groups = userGroups.ToList(),
                    CompletedTasksCount = completedTasksCount,
                    PendingTasksCount = pendingTasksCount,
                    OverdueTasksCount = overdueTasksCount,
                    TotalNotesCount = notes.Count()
                };

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при загрузке дашборда");
                return View("Error");
            }
        }
    }
} 