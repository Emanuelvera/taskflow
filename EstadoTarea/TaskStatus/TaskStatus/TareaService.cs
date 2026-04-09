using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskStatus
{
    public class TareaService
    {
        private List<Tarea> tareas = new List<Tarea>();

        public void MostrarEstadoTareas()
        {
            foreach (var tarea in tareas)
            {
                Console.WriteLine(
                    $"{tarea.Id}. {tarea.Descripcion} - {(tarea.Completada ? "Completada" : "Pendiente")}"
                );
            }
        }
    }
}
