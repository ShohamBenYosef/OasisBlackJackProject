using OasisBlackJackProject.Enums;

namespace OasisBlackJackProject.Models
{

    public class Card
    {
        public Face Face { get; set; }
        public Suit Suit { get; set; }
        public int Value { get; set; }

        public Card(Face face, Suit suit)
        {
            Face = face;
            Suit = suit;
            this.Value = GetValue();
        }


        /// <summary>
        ///  Calculate the value of the Card
        /// </summary>
        /// <returns>the value of the Card</returns>
        public int GetValue()
        {
            switch (this.Face)
            {
                case Face.King:
                    return 10;
                case Face.Queen:
                    return 10;
                case Face.Jack:
                    return 10;
                case Face.Ten:
                    return 10;
                case Face.Nine:
                    return 9;
                case Face.Eight:
                    return 8;
                case Face.Seven:
                    return 7;
                case Face.Six:
                    return 6;
                case Face.Five:
                    return 5;
                case Face.Four:
                    return 4;
                case Face.Three:
                    return 3;
                case Face.Two:
                    return 2;
                case Face.Ace:
                    return 11;
                default:
                    return 0;
            }
        }

        // Can Delete later
        public void toString()
        {
            char symbol = ' ';
            switch (Suit)
            {
                case Suit.Spade:
                    symbol = '♠';
                    break;
                case Suit.Club:
                    symbol = '♣';
                    break;
                case Suit.Heart:
                    symbol = '♥';
                    break;
                case Suit.Diamond:
                    symbol = '♦';
                    break;
            }
            Console.WriteLine("the card: " + this.Face + symbol);
        }
    }
}
