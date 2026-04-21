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

        public List<TaskItem> ListarTareas(Models.TaskStatus? filtro = null)
        {
            if (filtro == null)
                return tareas;
            return tareas.Where(t => t.Status == filtro).ToList();
        }

        public void MostrarTareas(List<TaskItem> lista)
        {
            if (lista.Count == 0)
            {
        Console.WriteLine("No hay tareas para mostrar.");
        return;
        }
        
        Console.WriteLine("\n{0,-5} {1,-25} {2,-20} {3,-15} {4,-20} {5,-20}",
        "ID", "Título", "Responsable", "Estado", "Creada", "Última modif.");
        
        Console.WriteLine(new string('-', 105));
        
        foreach (var tarea in lista)
         { 
            string estado = tarea.Status switch
            {
                Models.TaskStatus.Pending    => "Pendiente",
                Models.TaskStatus.InProgress => "En progreso",
                Models.TaskStatus.Completed  => "Completada",
                _                            => "Desconocido"
            };
            
            string updatedAt = tarea.UpdatedAt.HasValue
            ? tarea.UpdatedAt.Value.ToLocalTime().ToString("dd/MM/yyyy HH:mm")
            : "-";
            
            Console.WriteLine("{0,-5} {1,-25} {2,-20} {3,-15} {4,-20} {5,-20}",
            tarea.ID,
            tarea.Title,
            tarea.Responsible,
            estado,
            tarea.CreatedAt.ToLocalTime().ToString("dd/MM/yyyy HH:mm"),
            updatedAt);
            }
            
        Console.WriteLine();
        
        }

        public void ActualizarEstado()
        {
            Console.Clear();
            Console.WriteLine("¿Qué tarea desea actualizar?");
            //funcion de guada(el listar)

            //ingreso de id de la tarea a actualizar
            TaskItem tareaSeleccionada = null;
            do
            {
            Thread.Sleep(3000);
            Console.Clear();
            Console.Write("Ingrese el ID de la tarea a actualizar: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int idMod) || idMod <= 0)
            {
                Console.WriteLine("Por favor, ingrese un número entero positivo válido para el ID.");
                continue;
            }

            tareaSeleccionada = tareas.Find(t => t.ID == idMod);
            if (tareaSeleccionada == null)
            {
                Console.WriteLine("No existe una tarea con ese ID.");
            }

            } while (tareaSeleccionada == null);


            //ingreso del nuevo estado de la tarea

            // Mostrar los estados posibles

            Console.Clear();
            Console.WriteLine("Estados posibles:");
            foreach (var estado in Enum.GetValues<Models.TaskStatus>())
            {
                Console.WriteLine($"{(int)estado} - {estado}");
            }

            // Solicitar el nuevo estado
            Console.Write("Ingrese el número correspondiente al nuevo estado: ");
            string estadoInput = Console.ReadLine();
            int estadoSeleccionado;

            while (!int.TryParse(estadoInput, out estadoSeleccionado) ||
                   !Enum.IsDefined(typeof(Models.TaskStatus), estadoSeleccionado))
            {
                Console.WriteLine("Por favor, ingrese un valor válido para el estado.");
                Console.Write("Ingrese el número correspondiente al nuevo estado: ");
                estadoInput = Console.ReadLine();
            }

            // Actualizar el estado
            tareaSeleccionada.Status = (Models.TaskStatus)estadoSeleccionado;
            tareaSeleccionada.UpdatedAt = DateTime.Now;
            Console.WriteLine("Estado actualizado correctamente.");

            Console.WriteLine($"Tarea {tareaSeleccionada.ID} ahora está en estado {tareaSeleccionada.Status}");
        }
    }
}
