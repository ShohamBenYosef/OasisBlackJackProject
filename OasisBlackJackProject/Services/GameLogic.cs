using OasisBlackJackProject.Enums;
using OasisBlackJackProject.Models;

namespace OasisBlackJackProject.Services
{
    public class GameLogic : IGameLogic
    {
        public Dealer Dealer { get; set; }
        public Player Player { get; set; }
        public int Bet { get; set; }
        public GameStatus Status { get; set; }
        public GameDataAccess Store { get; set; }
        public Deck Deck { get; set; }

        
        public GameLogic()
        {
            this.Player = new Player();
            this.Dealer = new Dealer(this.Deck);
            this.Deck = new Deck();
            CreateHandsForStart();
            this.Status = GameStatus.BeforeBet;
            this.Bet = 0;
            this.Store = new GameDataAccess();
        }


        public void CreateHandsForStart()
        {
            this.Player.Hand.GetAnotherCard(this.Deck.GetNewCard());
            this.Dealer.Hand.GetAnotherCard(this.Deck.GetNewCard());
            this.Player.Hand.GetAnotherCard(this.Deck.GetNewCard());
            this.Dealer.Hand.GetAnotherCard(this.Deck.GetNewCard());
        }


        public void CleanHands()
        {
            // run from the end of the list to zero
            for (int i = this.Player.Hand.Cards.Count - 1; i >= 0; i--)
            {
                Deck.Cards.Add(this.Player.Hand.Cards.ElementAt(i)); // return the card to main deck
                this.Player.Hand.Cards.RemoveAt(i); // remove it from hand.
            }
            for (int i = this.Dealer.Hand.Cards.Count - 1; i >= 0; i--)
            {
                Deck.Cards.Add(this.Dealer.Hand.Cards.ElementAt(i));
                this.Dealer.Hand.Cards.RemoveAt(i);
            }
        }


        public void GetNewBet(int bet)
        {
            if (this.Player.Wallet >= bet) // There is enough money in his wallet.
            {
                this.Player.Wallet -= bet;
                this.Bet = bet;
            }
            else
            {
                this.Bet = this.Player.Wallet;
                this.Player.Wallet = 0;
            }
            this.Store.SetStore(this.Player.Hand, this.Dealer.Hand, this.Status, this.Player.Wallet, this.Bet);
        }


        public void PlayerHit()
        {
            this.Status = GameStatus.InGame;
            this.Player.Hand.GetAnotherCard(this.Deck.GetNewCard());
            
            this.Player.Hand.CheckIfBust();
            if (Player.Hand.IsBust) // if its buts we need to end this round.
            {
                PlayerSubmit();
            }
            this.Store.SetStore(this.Player.Hand, this.Dealer.Hand, this.Status, this.Player.Wallet, this.Bet);
        }


        public void DealerHit()
        {
            Dealer.Hand.CheckIfBust();
            while (Dealer.Hand.Sum < 16)
            {
                this.Dealer.Hand.GetAnotherCard(this.Deck.GetNewCard());
                Dealer.Hand.CheckIfBust();
            }
        }

        
        public void PlayerSubmit()
        {
            this.DealerHit();

            this.Player.Hand.CheckIfBust();
            this.Dealer.Hand.CheckIfBust();
            
            // if Dealer is bust so player won automaticly
            if (this.Dealer.Hand.IsBust)
            {
                this.Status = GameStatus.DealerBust;
                this.Player.Wallet += this.Bet*2;
                this.Bet = 0;
                this.Store.SetStore(this.Player.Hand, this.Dealer.Hand, this.Status, this.Player.Wallet, this.Bet);
                return;
            }
            
            // if player is bust so he will lose his bet 
            if (this.Player.Hand.IsBust)
            {
                this.Status = GameStatus.PlayerBust;
                this.Bet = 0;
                this.Store.SetStore(this.Player.Hand, this.Dealer.Hand, this.Status, this.Player.Wallet, this.Bet);
                return;
            }


            if (this.Dealer.Hand.Sum != this.Player.Hand.Sum)
            {
                if (this.Dealer.Hand.Sum > this.Player.Hand.Sum)
                {
                    this.Status = GameStatus.DealerWon;
                    this.Bet = 0;
                }
                else
                {
                    this.Status = GameStatus.PlayerWon;
                    this.Player.Wallet += this.Bet * 2;
                    this.Bet = 0;
                }
            }
            else // Dealer and Player have equal sum --> tie
            {
                this.Status = GameStatus.Tie;
                this.Player.Wallet += this.Bet;
                this.Bet = 0;
            }
            this.Store.SetStore(this.Player.Hand, this.Dealer.Hand, this.Status, this.Player.Wallet, this.Bet);
        }
    }
}
