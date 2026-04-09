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
    }
}
