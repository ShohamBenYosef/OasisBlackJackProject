namespace OasisBlackJackProject.Models
{
    public class Hand
    {
        public List<Card> Cards { get; set; }
        public int Sum { get; set; }
        public bool IsBust { get; set; }



        public Hand()
        {
            Cards = new List<Card>();
        }


        public void GetSumOfCards()
        {
            int aceCnt = 0;
            this.Sum = 0;
            foreach (Card c in Cards)
            {    
                if (c.Face == Enums.Face.Ace)
                {
                    aceCnt++;
                }
                this.Sum += c.Value;
            }

            while (this.Sum > 21 && aceCnt > 0)
            {
                this.Sum -= 10;
                aceCnt--;
            }
        }


        public void GetAnotherCard(Card card)
        {
            this.Cards.Add(card);
            GetSumOfCards();
        }


        public void CheckIfBust()
        {
            GetSumOfCards();
            this.IsBust = (this.Sum > 21);
        }
    }
}
