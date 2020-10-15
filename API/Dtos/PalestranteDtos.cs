using System.Collections.Generic;

namespace API.Dtos
{
    public class PalestranteDtos
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MiniCurriculo { get; set; }
        public string ImagemURL { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        //Refereciando as entidades na tabela Palestrante
        public List<RedeSocialDtos> RedeSociais { get; set; }
        public List<EventDtos> Events { get; set; }
    }
}