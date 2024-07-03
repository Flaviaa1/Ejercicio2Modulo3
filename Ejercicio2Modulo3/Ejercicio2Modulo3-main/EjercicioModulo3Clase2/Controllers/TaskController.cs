using EjercicioModulo3Clase2.Domain.DTOs;
using EjercicioModulo3Clase2.Domain.Entity;
using EjercicioModulo3Clase2.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace EjercicioModulo3Clase2.Controllers
{
    [Route( "v1" )]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ToDoListDBContext _context;
        public TaskController(ToDoListDBContext context) { 
        
        _context = context;
        }
       
        #region Pasos previos
        /*
         * 1 - Instalar EF Core y EF Core SQL Server
         * 2 - Crear contexto de base de datos y los modelos. Se puede usar Ingenieria Inversa de EF Core Power Tools
         * 3 - Configurar la inyección de dependencia del contexto tanto en Program.cs como en el controlador. No olvidar el string de conexión.
         * 4 - Las rutas de los endpoints queda a criterio de cada uno.
         * 5 - En este controlador, realizar los siguientes ejercicios:
         */
        #endregion

        #region Ejercicio 1
        // Crear un endpoint para obtener un listado de todas las tareas usando HTTP GET
             [HttpGet]
        [Route("lista")]
        public IActionResult listaTask() {
                       return Ok( _context.Tasks.ToList());
                    }
        #endregion

        #region Ejercicio 2
        // Crear un endpoint para obtener una tarea por ID usando HTTP GET
        [HttpGet]
        [Route("lista/{id}")]
        public IActionResult listaTask2([FromRoute]  int id )
        {
            var task = _context.Tasks.Where( a=> a.Id == id ).FirstOrDefault();
            return Ok( task );
        }
        #endregion

        #region Ejercicio 3
        // Crear un endpoint para crear una nueva tarea usando HTTP POST

        [HttpPost]
        public IActionResult createT([FromBody] Tasks task )
        {

            _context.Add(task);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost("conDTO")]
        public IActionResult createT2([FromBody] TasksDTO task ) {
            
            
            Tasks T = new Tasks() { 

                

            Title=task.Title,
            Description=task.Description,
            DueDate=task.DueDate,
            IsCompleted=task.IsCompleted,
            IsActive=task.IsActive


            };

            _context.Add(T);
            _context.SaveChanges();
            return Ok();
        }
        #endregion

        #region Ejercicio 4
        // Crear un endpoint para marcar una tarea como completada usando HTTP PUT
        [HttpPut("{id}")]
        public IActionResult updateT([FromRoute] int id,[FromBody] modiT task) {
        var tarea=_context.Tasks.FirstOrDefault(t=>t.Id == id);
       
            tarea.IsCompleted= task.IsCompleted;
           
            _context.SaveChanges();
            return Ok(tarea);
        }

        #endregion
        #region Ejercicio 5
        // Crear un endpoint para dar de baja una tarea usando HTTP PUT (baja lógica)
        [HttpPut("{id}/tarea")]
        public IActionResult updateT([FromRoute] int id, [FromBody] bagLog t)
        {
            var tarea = _context.Tasks.FirstOrDefault(t => t.Id == id);
            bool mt ;

            if (t.IsActive == 1)
            {
                mt = true;
            }
            else { 
            mt = false;
            }
            tarea.IsActive=mt;

            _context.SaveChanges();
            return Ok(tarea);
        }
        #endregion
    }
}
