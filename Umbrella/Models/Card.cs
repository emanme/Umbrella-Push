namespace Umbrella.Models
{
    public class Card
    {
        public string Name { get; set; }

        public string Number { get; set; }

        public int ExpiryMonth { get; set; }

        public int ExpiryYear { get; set; }

        public string CVC { get; set; }
    }
    public class RetrievedCard
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Last4 { get; set; }

       
    }
}
