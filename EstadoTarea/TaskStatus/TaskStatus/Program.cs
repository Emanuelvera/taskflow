namespace TaskStatus
{
    internal class TaskStatus

    {
        private static void Main(string[] args)
        {
            TareaService servicio = new TareaService();

            servicio.MostrarEstadoTareas();
        }
    }
}