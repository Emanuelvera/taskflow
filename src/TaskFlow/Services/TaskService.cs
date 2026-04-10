using System;
using System.Collections.Generic;
using TaskFlow.Models;

namespace CreateTask
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

        public List<TaskItem> ListarTareas(TaskStatus? filtro = null)
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
            TaskStatus.Pending    => "Pendiente",
            TaskStatus.InProgress => "En progreso",
            TaskStatus.Completed  => "Completada",
            TaskStatus.Cancelled  => "Cancelada",
            _                     => "Desconocido"
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
    }
}