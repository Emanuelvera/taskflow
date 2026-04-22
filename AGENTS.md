# AGENTS.md – TaskFlow Project Guidance

## Quick Start

**Main entry point:** `src/TaskFlow/Program.cs` (console application)  
**Run project:** `dotnet run --project EstructuraBaseDelProyecto.csproj` from root  
**.NET version:** net8.0 (see EstructuraBaseDelProyecto.csproj)

## Build & Test

- **Build:** `dotnet build EstructuraBaseDelProyecto.csproj`
- **Run:** `dotnet run --project EstructuraBaseDelProyecto.csproj`
- **Test directory:** `test/` (currently empty; no test suite yet)

**Known Issue:** The `.sln` file references `EstructuraBaseDelProyecto\EstructuraBaseDelProyecto.csproj` (incorrect path). The actual `.csproj` is at root level. This causes `dotnet build` to fail when using the .sln—always use the `.csproj` file directly.

## Project Structure

```
src/TaskFlow/
├── Program.cs            # Console menu loop; entry point
├── Models/TaskItem.cs    # TaskItem entity + TaskStatus enum
└── Services/TaskService.cs  # Core business logic (CRUD, validation, threading)
```

**Key patterns:**
- `TaskStatus` enum: `Pending`, `InProgress`, `Completed` (never `Cancelled`)
- In-memory task storage (no persistence to JSON yet; README mentions `/data/tasks.json` but not yet implemented)
- Thread-safe list operations via `lock (_lock)` in TaskService
- Console-based CRUD with validation (title/description/responsible max lengths enforced)

## Important Caveats for Agents

1. **CrearTarea() method variants:** Program.cs calls `CrearTarea(descripcion)` (line 15) but TaskService.CrearTarea() takes no parameters (line 18). This will fail at runtime. Method signature or callsite needs fixing.

2. **Missing functionality from README:**
   - JSON persistence to `/data/tasks.json` mentioned but not implemented
   - Delete/remove task operation mentioned in README but missing from TaskService
   - Assign/reassign task responsibility only partially supported

3. **Inconsistent namespaces:** Program.cs declares `namespace CreateTask` but should probably be `namespace TaskFlow` to match class library naming.

4. **No test framework:** `test/` directory exists but is empty. No xUnit/NUnit setup yet.

## Git Workflow Observations

Recent commits show feature branches (`feature/crear-tarea`, `feature/listar-tareas`, `feature/estado-tarea`) merged to main. Main branch is the integration point. No explicit development branch visible in recent history.

## Language & Locale

Project is Spanish-language (variable names, console messages, comments). Maintain this for consistency unless refactoring for English.
