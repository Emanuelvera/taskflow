using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CreateTask
{
    public class TareaService
    {
        private List<Tarea> tareas = new List<Tarea>();
        private int nextId = 1;

        public void CrearTarea(string descripcion)
        {
            var tarea = new Tarea
            {
                Id = nextId++,
                Descripcion = descripcion,
                Completada = false
            };

            tareas.Add(tarea);

            Console.WriteLine("Tarea creada correctamente");
        }
    }
}
