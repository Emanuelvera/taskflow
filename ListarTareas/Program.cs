namespace ListarTareas
{
    internal class ListarTareas
    {
        private static void Main(string[] args)
        {
            var tareaService = new TareaService();

            // Datos de prueba
            tareaService.AgregarTarea(new Tarea { Id = 1, Descripcion = "Diseñar base de datos", Completada = false, EnProgreso = false });
            tareaService.AgregarTarea(new Tarea { Id = 2, Descripcion = "Crear endpoints API", Completada = false, EnProgreso = true });
            tareaService.AgregarTarea(new Tarea { Id = 3, Descripcion = "Escribir tests unitarios", Completada = true, EnProgreso = false });

            tareaService.ListarTodasLasTareas();
            tareaService.ListarTareasPendientes();
            tareaService.ListarTareasEnProgreso();
            tareaService.ListarTareasCompletadas();
        }
    }
}