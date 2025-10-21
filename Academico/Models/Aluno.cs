using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Academico.Models
{
    public class Aluno
    {
        public int AlunoID { get; set; }

        [Required(ErrorMessage = "O nome do Aluno é obrigatório!")]
        public string Nome { get; set; }

        [DisplayName("e-mail")]

        [Required(ErrorMessage = "O E-mail é obrigatório!")]

        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "O E-mail deve estar em formato válido.")]
        
        public string Email { get; set; }

        [DisplayName("CEP")]

        [Required(ErrorMessage = "O CEP é obrigatório!")]

        [RegularExpression(@"\d{8}", ErrorMessage = "O CEP deve estar no formato 8 digitos")]
        public long Cep { get; set; }

    }
}
