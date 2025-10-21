using System.ComponentModel.DataAnnotations;

namespace Academico.Models
{
    public class Disciplina
    {
        public int DisciplinaID { get; set; }
        [Required(ErrorMessage = "O nome do Curso é obrigatório!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "A Carga Horária é obrigatória!")]
        public int CargaHoraria { get; set; }

        public Curso? Curso { get; set; }

        public int CursoID { get; set; }
    }
}
