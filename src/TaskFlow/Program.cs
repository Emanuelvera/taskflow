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
        }
    }
}