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

        public void CambiarEstado(int id)
        {

            var tarea = tareas.Find(t => t.Id == id);

            if (tarea != null)
            {
                tarea.Completada = true;
                Console.WriteLine("Tarea completada");
            }
        }
    }
}
