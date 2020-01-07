using System;

namespace Meta.Domain.Entities
{
    public class Contato
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Canal { get; set; }
        public string Valor { get; set; }
        public string Observacao { get; set; }
    }
}
