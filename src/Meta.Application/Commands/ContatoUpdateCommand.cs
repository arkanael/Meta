﻿using System.ComponentModel.DataAnnotations;

namespace Meta.Application.Commands
{
    public class ContatoUpdateCommand
    {
        [Required(ErrorMessage = "O campo id é obrigatório")]
        public string Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo canal é obrigatório")]
        public string Canal { get; set; }

        [Required(ErrorMessage = "O campo valor é obrigatório")]
        public string Valor { get; set; }

        [Required(ErrorMessage = "O campo observacao é obrigatório")]
        public string Observacao { get; set; }
    }
}
