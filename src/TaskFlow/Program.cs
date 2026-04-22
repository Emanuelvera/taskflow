using TaskFlow.Services;
using TaskFlow.Models;

namespace CreateTask
{
    internal class CreateTask
    {
        private static void Main(string[] args)
        {
            var taskService = new TaskService();
            
            Console.WriteLine("=== BIENVENIDO A TASKFLOW ===");
            bool salir = false;
            while (!salir)            {
                Console.WriteLine("\n=== MENÚ PRINCIPAL ===");
                Console.WriteLine("1. Crear nueva tarea");      
                Console.WriteLine("2. Listar tareas");
                Console.WriteLine("3. Actualizar estado de una tarea");
                Console.WriteLine("4. Salir");
                Console.Write("Elegí una opción: ");
                string opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "1":
                        taskService.CrearTarea();
                        break;
                    case "2":
                        Console.Clear();
                         bool salirListado = false;
                            while (!salirListado)
                            {
                                Console.WriteLine("\n=== LISTAR TAREAS ===");
                                Console.WriteLine("1. Todas las tareas");
                                Console.WriteLine("2. Solo pendientes");
                                Console.WriteLine("3. Solo en progreso");
                                Console.WriteLine("4. Solo completadas");
                                Console.WriteLine("5. Salir");
                                Console.Write("Elegí una opción: ");
                                
                                string opcionList = Console.ReadLine() ?? "";
                                
                                switch (opcionList)
                                {
                                    case "1":
                                        Console.WriteLine("\n--- TODAS LAS TAREAS ---");
                                        taskService.MostrarTareas(taskService.ListarTareas());
                                        break;
                                    case "2":
                                        Console.WriteLine("\n--- TAREAS PENDIENTES ---");
                                        taskService.MostrarTareas(
                                            taskService.ListarTareas(TaskFlow.Models.TaskStatus.Pending));
                                        break;
                                    case "3":
                                        Console.WriteLine("\n--- TAREAS EN PROGRESO ---");
                                        taskService.MostrarTareas(
                                            taskService.ListarTareas(TaskFlow.Models.TaskStatus.InProgress));
                                        break;
                                    case "4":
                                        Console.WriteLine("\n--- TAREAS COMPLETADAS ---");
                                        taskService.MostrarTareas(
                                            taskService.ListarTareas(TaskFlow.Models.TaskStatus.Completed));
                                        break;
                                    case "5":
                                        salirListado = true;
                                        break;
                                    default:
                                        Console.WriteLine("Opción no válida, intentá de nuevo.\n");
                                        break;  
                                }                
                            }
                        break;
                    case "3":
                        taskService.ActualizarEstado();
                        break;
                    case "4":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida, intentá de nuevo.\n");
                        break;
                }
        
        }
    }
}
}