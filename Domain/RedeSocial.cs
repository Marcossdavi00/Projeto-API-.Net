namespace Domain
{
    public class RedeSocial
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public int EventId { get; set; }
        //Referencia das outras entidades na tabela RedeSocial
        public Event Event {get;}
        public int PalestranteId { get; set; }
        public Palestrante Palestrantes { get; }
    }
}