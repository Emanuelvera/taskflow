using System;
using System.Collections.Generic;
using System.Linq;
using TaskFlow.Models;

namespace TaskFlow.Services
{
    public class TaskService
    {
        private List<TaskItem> tareas = new List<TaskItem>();
        private int nextId = 1;

        public void CrearTarea(string descripcion)
        {
            var tarea = new TaskItem
            {
                ID = nextId++,
                Title = descripcion,
                Description = descripcion,
                Status = TaskFlow.Models.TaskStatus.Pending
            };

            tareas.Add(tarea);

            Console.WriteLine("Tarea creada correctamente");
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
