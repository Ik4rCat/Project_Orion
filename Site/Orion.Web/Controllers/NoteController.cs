using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Orion.Core.Interfaces;
using Orion.Core.Models;
using Orion.Web.Models.Note;
using Microsoft.Extensions.Logging;

namespace Orion.Web.Controllers
{
    [Authorize]
    public class NoteController : Controller
    {
        private readonly INoteRepository _noteRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<NoteController> _logger;

        public NoteController(
            INoteRepository noteRepository, 
            IUserRepository userRepository,
            ILogger<NoteController> logger)
        {
            _noteRepository = noteRepository;
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                var notes = await _noteRepository.FindAsync(n => n.CreatedById == userId);
                return View(notes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при получении списка заметок");
                return View("Error");
            }
        }

        public IActionResult Create()
        {
            return View(new CreateNoteViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateNoteViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                
                if (string.IsNullOrEmpty(userId))
                {
                    _logger.LogWarning("Попытка создания заметки без авторизации");
                    return RedirectToAction("Login", "Account");
                }

                var note = new Note
                {
                    Title = model.Title,
                    Content = model.Content,
                    Type = model.Type,
                    CreatedById = userId,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                await _noteRepository.AddAsync(note);
                await _noteRepository.SaveChangesAsync();

                _logger.LogInformation($"Заметка успешно создана. ID: {note.Id}");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при создании заметки");
                ModelState.AddModelError("", "Произошла ошибка при сохранении заметки. Пожалуйста, попробуйте еще раз.");
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                var note = await _noteRepository.GetByIdAsync(id.ToString());
                
                if (note == null)
                {
                    _logger.LogWarning($"Попытка удаления несуществующей заметки с ID {id}");
                    return NotFound();
                }
                
                // Проверка, что пользователь может удалить заметку (только создатель)
                if (note.CreatedById != userId)
                {
                    _logger.LogWarning($"Пользователь {userId} попытался удалить заметку {id}, не имея на это прав");
                    return Forbid();
                }
                
                await _noteRepository.DeleteAsync(note);
                await _noteRepository.SaveChangesAsync();
                
                _logger.LogInformation($"Заметка {id} успешно удалена пользователем {userId}");
                
                // Если заметка принадлежит группе, возвращаемся на страницу группы
                if (note.GroupId.HasValue)
                {
                    return RedirectToAction("Details", "Group", new { id = note.GroupId });
                }
                
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ошибка при удалении заметки с ID {id}");
                ModelState.AddModelError("", "Произошла ошибка при удалении заметки.");
                return RedirectToAction(nameof(Index));
            }
        }
    }
} 