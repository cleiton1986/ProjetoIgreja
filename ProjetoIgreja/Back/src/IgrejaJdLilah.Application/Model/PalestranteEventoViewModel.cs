namespace IgrejaJdLilah.Application.Model
{
    public class PalestranteEventoViewModel
    {
        public int PalestranteId { get; set; }
        public  PalestranteViewModel Palestrante { get; set; }
        public int EventoId { get; set; }
        public EventoViewModel Evento { get; set; }
    }
}