namespace CreateTask
{
    internal class CreateTask
    {
        private static void Main(string[] args)
        {
            var tareaService = new TareaService();

            Console.WriteLine("Ingrese una descripción de la tarea:");
            string descripcion = Console.ReadLine();

            tareaService.CrearTarea(descripcion);
        }
    }
}