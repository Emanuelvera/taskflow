using System;
using System.Collections.Generic;
using TaskFlow.Models;
using System.Threading;

namespace TaskFlow.Services
{
    public class TaskService
    {
        public void ActualizarEstado()
        {
            Console.Clear();
            console.WriteLine("¿Qué tarea desea actualizar?");
            //funcion de guada(el listar)

            //ingreso de id de la tarea a actualizar
            TaskItem tareaSeleccionada = null;
            do
            {
            thread.Sleep(3000);
            Console.Clear();
            Console.Write("Ingrese el ID de la tarea a actualizar: ");
            string input = Console.ReadLine();
            int idMod;

            if (!int.TryParse(input, out idMod) || idMod <= 0)
            {
                Console.WriteLine("Por favor, ingrese un número entero positivo válido para el ID.");
                continue;
            }

            tareaSeleccionada = tareas.Find(t => t.ID == idMod);
            if (tareaSeleccionada == null)
            {
                Console.WriteLine("No existe una tarea con ese ID.");
            }

            } while (tareaSeleccionada == null);


            //ingreso del nuevo estado de la tarea

            // Mostrar los estados posibles

            Console.Clear();
            Console.WriteLine("Estados posibles:");
            foreach (var estado in Enum.GetValues(typeof(TaskStatus)))
            {
                Console.WriteLine($"{(int)estado} - {estado}");
            }

            // Solicitar el nuevo estado
            Console.Write("Ingrese el número correspondiente al nuevo estado: ");
            string estadoInput = Console.ReadLine();
            int estadoSeleccionado;

            while (!int.TryParse(estadoInput, out estadoSeleccionado) ||
                   !Enum.IsDefined(typeof(TaskStatus), estadoSeleccionado))
            {
                Console.WriteLine("Por favor, ingrese un valor válido para el estado.");
                Console.Write("Ingrese el número correspondiente al nuevo estado: ");
                estadoInput = Console.ReadLine();
            }

            // Actualizar el estado
            tareaSeleccionada.Status = (TaskStatus)estadoSeleccionado;
            tareaSeleccionada.UpdatedAt = DateTime.Now;
            Console.WriteLine("Estado actualizado correctamente.");

            Console.WriteLine($"Tarea {tareaSeleccionada.ID} ahora está en estado {tareaSeleccionada.Status}");
        }

    }
