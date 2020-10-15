using System;
using System.Collections.Generic;

namespace Domain
{
    public class Event
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public DateTime EventDate { get; set; }
        public string Tema { get; set; }
        public int QtdPessoas { get; set; }
        public string ImageURL { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        //Referenciando a entidade Lote e RedeSocial em event
        public List<Lote> Lotes { get; set; }
        public List<RedeSocial> RedeSociais { get; set; }
        public List<PalestranteEvent> PalestrantesEvents { get; set; }
    }
}