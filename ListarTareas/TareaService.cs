using System;
using System.Collections.Generic;
using System.Linq;

namespace ListarTareas
{
    public class TareaService
    {
        private List<Tarea> tareas = new List<Tarea>();

    
        public void AgregarTarea(Tarea tarea)
        {
            tareas.Add(tarea);
        }

        // Listar todas las tareas
        public void ListarTodasLasTareas()
        {
            if (!tareas.Any())
            {
                Console.WriteLine("No hay tareas registradas.");
                return;
            }

            Console.WriteLine("\n=== TODAS LAS TAREAS ===");
            foreach (var tarea in tareas)
            {
                MostrarTarea(tarea);
            }
        }
        
        // Listar solo las tareas pendientes
        public void ListarTareasPendientes()
        {
            var pendientes = tareas.Where(t => !t.Completada).ToList();

            if (!pendientes.Any())
            {
                Console.WriteLine("No hay tareas pendientes.");
                return;
            }

            Console.WriteLine("\n=== TAREAS PENDIENTES ===");
            foreach (var tarea in pendientes)
            {
                MostrarTarea(tarea);
            }
        }

        // Listar solo las tareas completadas
        public void ListarTareasCompletadas()
        {
            var completadas = tareas.Where(t => t.Completada).ToList();

            if (!completadas.Any())
            {
                Console.WriteLine("No hay tareas completadas.");
                return;
            }

            Console.WriteLine("\n=== TAREAS COMPLETADAS ===");
            foreach (var tarea in completadas)
            {
                MostrarTarea(tarea);
            }
        }

    
        private void MostrarTarea(Tarea tarea)
        {
            string estado = tarea.Completada ? "Completada" : "Pendiente";
            Console.WriteLine($"{tarea.Id}. {tarea.Descripcion} - [{estado}]");
        }
    }
}