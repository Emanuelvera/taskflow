namespace CreateTask
{
    internal class CreateTask
    {
        private static void Main(string[] args)
        {
            var taskService = new TaskService();

            Console.WriteLine("Ingrese una descripción de la tarea:");
            string descripcion = Console.ReadLine() ?? string.Empty;

            taskService.CrearTarea(descripcion);

            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("\n=== LISTAR TAREAS ===");
                Console.WriteLine("1. Todas las tareas");
                Console.WriteLine("2. Solo pendientes");
                Console.WriteLine("3. Solo en progreso");
                Console.WriteLine("4. Solo completadas");
                Console.WriteLine("5. Salir");
                Console.Write("Elegí una opción: ");
                 
                string opcion = Console.ReadLine() ?? "";
                
                switch (opcion)
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