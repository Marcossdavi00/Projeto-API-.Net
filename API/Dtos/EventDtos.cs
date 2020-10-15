using System.Collections.Generic;

namespace API.Dtos
{
    public class EventDtos
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public string EventDate { get; set; }
        public string Tema { get; set; }
        public int QtdPessoas { get; set; }
        public string ImageURL { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        //Referenciando a entidade Lote e RedeSocial em event
        public List<LoteDtos> Lotes { get; set; }
        public List<RedeSocialDtos> RedeSociais { get; set; }
        public List<PalestranteDtos> Palestrantes { get; set; }
    }
}