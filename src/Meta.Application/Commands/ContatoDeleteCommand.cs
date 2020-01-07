using System.ComponentModel.DataAnnotations;

namespace Meta.Application.Commands
{
    public class ContatoDeleteCommand
    {
        [Required(ErrorMessage = "O campo id é obrigatório")]
        public string Id { get; set; }
    }
}
