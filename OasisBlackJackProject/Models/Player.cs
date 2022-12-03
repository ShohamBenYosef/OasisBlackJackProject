namespace OasisBlackJackProject.Models
{
    public class Player
    {
        public Hand Hand { get; set; }
        public int Wallet { get; set; }

        public Player()
        {
            Wallet = 250;
            Hand = new Hand();
        }

    }
}
