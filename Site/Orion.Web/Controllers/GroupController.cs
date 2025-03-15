using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Orion.Core.Interfaces;
using Orion.Core.Models;
using Orion.Web.Models.Group;

namespace Orion.Web.Controllers
{
    [Authorize]
    public class GroupController : Controller
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserGroupRepository _userGroupRepository;
        private readonly ILogger<GroupController> _logger;

        public GroupController(
            IGroupRepository groupRepository,
            IUserRepository userRepository,
            IUserGroupRepository userGroupRepository,
            ILogger<GroupController> logger)
        {
            _groupRepository = groupRepository;
            _userRepository = userRepository;
            _userGroupRepository = userGroupRepository;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                var groups = await _groupRepository.FindAsync(g => g.UserGroups.Any(ug => ug.UserId == userId));
                return View(groups);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при получении списка групп");
                return View("Error");
            }
        }

        public IActionResult Create()
        {
            return View(new CreateGroupViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGroupViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                
                if (string.IsNullOrEmpty(userId))
                {
                    _logger.LogWarning("Попытка создания группы без авторизации");
                    return RedirectToAction("Login", "Account");
                }

                var group = new Group
                {
                    Name = model.Name,
                    Description = model.Description,
                    AvatarUrl = model.AvatarUrl,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                await _groupRepository.AddAsync(group);
                await _groupRepository.SaveChangesAsync(); // Сохраняем группу, чтобы получить ID

                _logger.LogInformation($"Группа создана. ID: {group.Id}, Name: {group.Name}");

                var userGroup = new UserGroup
                {
                    UserId = userId,
                    GroupId = group.Id,
                    Role = Core.Enums.GroupRole.Owner,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                await _userGroupRepository.AddAsync(userGroup);
                await _userGroupRepository.SaveChangesAsync(); // Сохраняем связь пользователь-группа

                _logger.LogInformation($"Пользователь {userId} добавлен в группу {group.Id} как владелец");

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при создании группы");
                ModelState.AddModelError("", "Произошла ошибка при создании группы. Пожалуйста, попробуйте еще раз.");
                return View(model);
            }
        }

        // GET: Group/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                
                // Получаем группу
                var group = await _groupRepository.GetByIdAsync(id.ToString());
                if (group == null)
                {
                    _logger.LogWarning($"Попытка просмотра несуществующей группы с ID {id} для удаления");
                    return NotFound();
                }
                
                // Проверяем, является ли пользователь владельцем группы
                var userGroups = await _userGroupRepository.FindAsync(ug => 
                    ug.GroupId == id && ug.UserId == userId && ug.Role == Core.Enums.GroupRole.Owner);
                
                var isOwner = userGroups.Any();
                if (!isOwner)
                {
                    _logger.LogWarning($"Пользователь {userId} попытался просмотреть группу {id} для удаления, не имея на это прав");
                    return Forbid();
                }
                
                return View(group);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ошибка при получении деталей группы с ID {id} для удаления");
                return View("Error");
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                
                // Получаем группу
                var group = await _groupRepository.GetByIdAsync(id.ToString());
                if (group == null)
                {
                    _logger.LogWarning($"Попытка удаления несуществующей группы с ID {id}");
                    return NotFound();
                }
                
                // Проверяем, является ли пользователь владельцем группы
                var userGroups = await _userGroupRepository.FindAsync(ug => 
                    ug.GroupId == id && ug.UserId == userId && ug.Role == Core.Enums.GroupRole.Owner);
                
                var isOwner = userGroups.Any();
                if (!isOwner)
                {
                    _logger.LogWarning($"Пользователь {userId} попытался удалить группу {id}, не имея на это прав");
                    return Forbid();
                }
                
                // Удаляем все связи пользователей с этой группой
                var groupUsers = await _userGroupRepository.FindAsync(ug => ug.GroupId == id);
                foreach (var userGroup in groupUsers)
                {
                    await _userGroupRepository.DeleteAsync(userGroup);
                }
                
                // Удаляем саму группу
                await _groupRepository.DeleteAsync(group);
                await _groupRepository.SaveChangesAsync();
                
                _logger.LogInformation($"Группа {id} успешно удалена пользователем {userId}");
                
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ошибка при удалении группы с ID {id}");
                return View("Error");
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var group = await _groupRepository.GetByIdAsync(id.ToString());
                if (group == null)
                {
                    return NotFound();
                }
                
                return View(group);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ошибка при получении деталей группы с ID {id}");
                return View("Error");
            }
        }
    }
} 