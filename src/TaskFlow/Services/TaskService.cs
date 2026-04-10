using System;
using System.Collections.Generic;
using System.Linq;
using TaskFlow.Models;

namespace TaskFlow.Services
{
    public class TaskService
    {
        private readonly List<TaskItem> _tasks = new();
        private int _nextId = 1;
        private readonly object _lock = new();

        private const int MaxTitleLength = 200;
        private const int MaxDescriptionLength = 2000;
        private const int MaxResponsibleLength = 100;

        public TaskItem CrearTarea()
        {
            Console.WriteLine("\n=== Crear nueva tarea ===");

            // Título obligatorio + validaciones
            string title;
            do
            {
                Console.Write("Ingrese el título: ");
                title = Console.ReadLine() ?? string.Empty;
                title = title.Trim();

                if (string.IsNullOrWhiteSpace(title))
                {
                    Console.WriteLine("El título es obligatorio.");
                    continue;
                }

                if (title.Length > MaxTitleLength)
                {
                    Console.WriteLine($"El título no puede exceder {MaxTitleLength} caracteres.");
                    continue;
                }

                // Comprobación opcional de duplicados (pregunta al usuario)
                if (_tasks.Any(t => string.Equals(t.Title, title, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.Write("Ya existe una tarea con este título. ¿Desea usarlo igual? (s/n): ");
                    var confirm = (Console.ReadLine() ?? string.Empty).Trim().ToLowerInvariant();
                    if (confirm != "s" && confirm != "si")
                    {
                        title = string.Empty; // fuerza repetir
                        continue;
                    }
                }

                break;
            } while (true);

            // Descripción opcional (truncar si excede)
            Console.Write("Ingrese la descripción (opcional): ");
            string description = (Console.ReadLine() ?? string.Empty).Trim();
            if (description.Length > MaxDescriptionLength)
            {
                Console.WriteLine($"Descripción truncada a {MaxDescriptionLength} caracteres.");
                description = description.Substring(0, MaxDescriptionLength);
            }

            // Responsable obligatorio + validaciones
            string responsible;
            do
            {
                Console.Write("Ingrese el responsable: ");
                responsible = (Console.ReadLine() ?? string.Empty).Trim();

                if (string.IsNullOrWhiteSpace(responsible))
                {
                    Console.WriteLine("El responsable es obligatorio.");
                    continue;
                }

                if (responsible.Length > MaxResponsibleLength)
                {
                    Console.WriteLine($"El nombre del responsable no puede exceder {MaxResponsibleLength} caracteres.");
                    continue;
                }

                break;
            } while (true);

            // Crear tarea con protección de concurrencia
            TaskItem task;
            lock (_lock)
            {
                task = new TaskItem
                {
                    ID = _nextId++,
                    Title = title,
                    Description = description,
                    Responsible = responsible,
                    Status = TaskStatus.Pending,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = null
                };

                _tasks.Add(task);
            }

            Console.WriteLine($"Tarea creada con ID: {task.ID}");
            return task;
        }
    }
}
