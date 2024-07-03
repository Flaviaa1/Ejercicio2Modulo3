namespace EjercicioModulo3Clase2.Domain.DTOs
{
    public class TasksDTO
    { 
        public string Title { get; set; }
        public string Description { get; set; }
        public string DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsActive { get; set; }
    }
}
