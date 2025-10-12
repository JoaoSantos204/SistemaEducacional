using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace Academico.Models
{
    public class Curso
    {
        public int CursoID { get; set; }

        [Required(ErrorMessage = "O nome do Curso é obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A carga horária é obrigatória!")]
        public int CargaHoraria { get; set; }
        public Departamento? Departamento { get; set; }
        public int DepartamentoID { get; set; }
    }
}
