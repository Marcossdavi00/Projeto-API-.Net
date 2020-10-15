using System;
using System.Collections.Generic;

namespace Domain
{
    public class Lote
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Amount { get; set; }
        public int EventId { get; set; }
        //Refereciando a Entidade Event na tabela Lote
        public Event Events { get;} 
    }
}