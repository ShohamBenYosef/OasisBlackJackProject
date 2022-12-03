using OasisBlackJackProject.Enums;

namespace OasisBlackJackProject.Models
{
    public class Deck
    {

        public List<Card> Cards { get; set; }

        public Deck()
        {
            this.CreateDeck();
            Shuffle();
        }

        /// <summary>
        /// Generates a new valid deck
        /// </summary>
        public void CreateDeck()
        {
            Cards = new List<Card>();
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Cards.Add(new Card((Face)i, (Suit)j));
                }
            }
        }


        // shuffle deck after creation.
        public void Shuffle()
        {
            Cards = new List<Card>(Cards.OrderBy(c => Guid.NewGuid()));
        }


        // return first card in deck.
        public Card GetNewCard()
        {
            if (Cards.Count > 0)
            {
                Card tmp = Cards[0];
                Cards.RemoveAt(0);
                return tmp;
            }
            else
                return null;
        }
    }
}
