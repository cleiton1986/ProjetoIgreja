using System;
using System.Collections.Generic;

namespace IgrejaJdLilah.Domain.Entidades
{
    public class Palestrante
    {
       public int Id { get; set; }  
       public string Nome { get; set; } 
       public string MiniCurriculo { get; set; }      
       public int ImagemUrl { get; set; }
       public string Telefone { get; set; }
       public string Email { get; set; }
       public string Denominacao { get; set; }
       public DateTime DataCadastro { get; set; }
       public bool FazParteMesmaDenominacao { get; set; }
       public int? EnderecoId { get; set; }
       public Endereco Endereco { get; set; }
       public IEnumerable<RedeSocial> RedeSociais { get; set; }
       public IEnumerable<PalestranteEvento> PalestranteEventos { get; set; }
    }
}