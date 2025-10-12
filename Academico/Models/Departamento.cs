using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Academico.Models
{
    public class Departamento
    {
        public int DepartamentoID { get; set; }

        [DisplayName("Descrição")]

        [Required(ErrorMessage = "O nome do Departamento é obrigatório!")]
        public string Nome { get; set; }
        public Instituicao? Instituicao { get; set; }
        public long InstituicaoID { get; set; }
    }
}
