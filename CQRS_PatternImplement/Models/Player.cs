namespace CQRS_PatternImplement.Models
{
    public class Player
    {
        public int Id { get; set; }

        public int ShirtNo { get; set; }
        public string Name { get; set; }

        public int Appreaances { get; set; }

        public int Goals { get; set; }

        public int PositionId { get; set; }
    }
}
