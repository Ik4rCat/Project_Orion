using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Orion.Core.Interfaces;
using Orion.Core.Models;
using Orion.Core.Enums;
using System;
using System.Threading.Tasks;
using TaskStatus = Orion.Core.Enums.TaskStatus;
using Microsoft.Extensions.Logging;

namespace Orion.Web.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly IRepository<TaskItem> _taskRepository;
        private readonly IUserRepository _userRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly ILogger<TaskController> _logger;

        public TaskController(
            IRepository<TaskItem> taskRepository,
            IUserRepository userRepository,
            IGroupRepository groupRepository,
            ILogger<TaskController> logger)
        {
            _taskRepository = taskRepository;
            _userRepository = userRepository;
            _groupRepository = groupRepository;
            _logger = logger;
        }

        public async Task<IActionResult> Index(int? groupId = null)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            
            // Если указан идентификатор группы, показываем задачи группы
            if (groupId.HasValue)
            {
                var tasks = await _taskRepository.FindAsync(t => t.GroupId == groupId);
                ViewBag.GroupId = groupId;
                return View(tasks);
            }
            
            // Иначе показываем личные задачи пользователя
            var userTasks = await _taskRepository.FindAsync(t => t.AssignedToId == userId);
            return View(userTasks);
        }

        public async Task<IActionResult> Create(int? groupId = null)
        {
            // Создание модели представления для новой задачи
            var model = new TaskItem
            {
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Status = TaskStatus.New,
                Priority = Priority.Medium
            };

            // Если передан идентификатор группы, задача создается для группы
            if (groupId.HasValue)
            {
                var group = await _groupRepository.GetByIdAsync(groupId.Value.ToString());
                if (group != null)
                {
                    model.GroupId = groupId;
                    ViewBag.Group = group;
                }
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaskItem model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            
            // Устанавливаем создателя задачи
            model.CreatedById = userId;

            // Если не указан исполнитель, устанавливаем создателя как исполнителя
            if (string.IsNullOrEmpty(model.AssignedToId))
            {
                model.AssignedToId = userId;
            }

            await _taskRepository.AddAsync(model);
            await _taskRepository.SaveChangesAsync();

            // Перенаправление в зависимости от того, создана ли задача для группы
            if (model.GroupId.HasValue)
            {
                return RedirectToAction("Details", "Group", new { id = model.GroupId });
            }
            
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var task = await _taskRepository.GetByIdAsync(id.ToString());
            if (task == null)
            {
                return NotFound();
            }
            
            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                var task = await _taskRepository.GetByIdAsync(id.ToString());
                
                if (task == null)
                {
                    return NotFound();
                }
                
                // Проверка, что пользователь может удалить задачу (владелец или исполнитель)
                if (task.CreatedById != userId && task.AssignedToId != userId)
                {
                    _logger.LogWarning($"Пользователь {userId} попытался удалить задачу {id}, не имея на это прав");
                    return Forbid();
                }
                
                await _taskRepository.DeleteAsync(task);
                await _taskRepository.SaveChangesAsync();
                
                _logger.LogInformation($"Задача {id} успешно удалена пользователем {userId}");
                
                // Редирект на страницу, с которой пришел запрос на удаление
                if (task.GroupId.HasValue)
                {
                    return RedirectToAction("Details", "Group", new { id = task.GroupId });
                }
                
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ошибка при удалении задачи с ID {id}");
                return View("Error");
            }
        }
    }
} 