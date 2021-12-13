using System;

namespace IgrejaJdLilah.Domain.Entidades
{
    public class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Denominacao { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool FazParteMesmaDenominacao { get; set; }
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
    }
}