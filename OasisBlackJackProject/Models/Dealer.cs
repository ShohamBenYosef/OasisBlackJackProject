namespace OasisBlackJackProject.Models
{
    public class Dealer
    {
        public Deck Deck { get; set; }
        public Hand Hand { get; set; }


        public Dealer(Deck deck)
        {
            Deck = deck;
            Hand = new Hand();
        }
    }
}
