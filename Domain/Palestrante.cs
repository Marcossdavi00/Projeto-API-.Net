using System;
using System.Collections.Generic;

namespace Domain
{
    public class Palestrante
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MiniCurriculo { get; set; }
        public string ImagemURL { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        //Refereciando as entidades na tabela Palestrante
        public List<RedeSocial> RedeSociais { get; set; }
        public List<PalestranteEvent> PalestrantesEvents { get; set; }
    }
}