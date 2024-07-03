using System.ComponentModel.DataAnnotations;

namespace EjercicioModulo3Clase2.Domain.DTOs
{
    public class bagLog
    {
        [MaxLength (1,ErrorMessage ="se debe colocar 1 o 0 ")]
        public int IsActive { get; set; }
    }
}
