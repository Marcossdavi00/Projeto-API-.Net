namespace API.Dtos
{
    public class LoteDtos
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int Amount { get; set; }
        //Refereciando a Entidade Event na tabela Lote
        public EventDtos Events { get;} 
    }
}