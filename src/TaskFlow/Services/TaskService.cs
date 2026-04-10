using System;
using System.Collections.Generic;
using TaskFlow.Models;

namespace TaskFlow.Services
{
    public class TaskService
    {
        private readonly List<TaskItem> _tasks = new();
        private int _nextId = 1;

        public TaskItem CrearTarea()
        {
            Console.WriteLine("\n=== Crear nueva tarea ===");

            // Título obligatorio
            string title;
            do
            {
                Console.Write("Ingrese el título: ");
                title = Console.ReadLine() ?? string.Empty;

                if (string.IsNullOrWhiteSpace(title))
                    Console.WriteLine("El título es obligatorio.");
            }
            while (string.IsNullOrWhiteSpace(title));

            // Descripción opcional
            Console.Write("Ingrese la descripción (opcional): ");
            string description = Console.ReadLine() ?? string.Empty;

            // Responsable libre
            Console.Write("Ingrese el responsable: ");
            string responsible = Console.ReadLine() ?? string.Empty;

            // Crear tarea
            var task = new TaskItem
            {
                ID = _nextId++, // ID incremental
                Title = title.Trim(),
                Description = description.Trim(),
                Responsible = responsible.Trim(),
                Status = TaskStatus.Pending,
                CreatedAt = DateTime.UtcNow
            };

            _tasks.Add(task);

            Console.WriteLine($"Tarea creada con ID: {task.ID}");
            return task;
        }
    }
}
