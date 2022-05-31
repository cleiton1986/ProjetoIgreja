using System.Collections.Generic;

namespace IgrejaJdLilah.Application.Model
{
    public class PalestranteViewModel
    {
         public int Id { get; set; }  
       public string Nome { get; set; } 
       public string MiniCurriculo { get; set; }      
       public int ImagemUrl { get; set; }
       public string Telefone { get; set; }
       public string Email { get; set; }
       public string Denominacao { get; set; }
       public string DataCadastro { get; set; }
       public bool FazParteMesmaDenominacao { get; set; }
       public int? EnderecoId { get; set; }
       public EnderecoViewModel Endereco { get; set; }
       public IEnumerable<RedeSocialViewModel> RedeSociais { get; set; }
       public IEnumerable<PalestranteEventoViewModel> PalestranteEventos { get; set; }
    }
}