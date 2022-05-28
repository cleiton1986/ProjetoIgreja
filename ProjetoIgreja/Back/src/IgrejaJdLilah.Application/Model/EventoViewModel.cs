using System;
using System.Collections.Generic;

namespace IgrejaJdLilah.Application.Model
{
    public class EventoViewModel
    {
        public int Id { get; set; }
       public string Local { get; set; }
       public string DataEvento { get; set; }  
       public string Tema { get; set; }  
       public int QtdPessoas { get; set; }      
       public string ImagemURL { get; set; }
       public string Telefone { get; set; }
       public string Email { get; set; }
       public string Observacao { get; set; }
      // public IEnumerable<Lote> Lotes { get; set; } 
       //public IEnumerable<RedeSocial> RedeSociais { get; set; } 
       //public IEnumerable<PalestranteEvento> PalestranteEventos { get; set; }
    }
}