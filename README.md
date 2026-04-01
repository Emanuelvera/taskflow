# TaskFlow - Gestión de Tareas Empresariales

## Descripción del Proyecto
**TaskFlow** es una aplicación de consola desarrollada en C# para la empresa **NovaTech Solutions**. El sistema permite la gestión integral de tareas, incluyendo su creación, asignación, seguimiento de estados y persistencia de datos.

Este proyecto se desarrolla bajo un entorno de simulación profesional, utilizando metodologías de trabajo colaborativo, gestión de conflictos y control de versiones mediante Git y GitHub.

## Funcionalidades Principales
* **Gestión de Tareas:** Crear, listar, actualizar y eliminar tareas (CRUD).
* **Estados:** Control de flujo mediante estados: `Pendiente`, `En progreso` y `Completada`.
* **Asignación:** Capacidad de asignar y cambiar el responsable de cada tarea.
* **Persistencia:** Almacenamiento automático de la información en archivos de formato JSON (`/data/tasks.json`).

## Estructura del Proyecto
El repositorio sigue una arquitectura organizada para facilitar la escalabilidad y el testeo:
* `src/TaskFlow/Models`: Definición de la entidad `TaskItem`.
* `src/TaskFlow/Services`: Lógica de negocio en `TaskService`.
* `src/TaskFlow/Utils`: Manejo de archivos y asistentes de consola.
* `tests/`: Pruebas unitarias del sistema.

## Requisitos e Instalación
1. **Tecnologías:** .NET SDK (C#).
2. **Clonar repositorio:**
   ```bash
   git clone https://github.com/Emanuelvera/taskflow.git
   ```
3. **Ejecución:**
   ```bash
   dotnet run --project src/TaskFlow/TaskFlow.csproj
   ```

## Integrantes del Equipo (NovaTech)
* **Altamirano Vera Emanuel**
* **Belén Castro**
* **Marianela Chumbita**
* **Matías Saunig**
* **Loyola Guadalupe**

