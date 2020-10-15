namespace Domain
{
    public class PalestranteEvent
    {
        public int PalestranteId { get; set; }
        public Palestrante Palestrantes { get; set; }
        public int EventId { get; set; }
        public Event Events { get; set; }
    }
}