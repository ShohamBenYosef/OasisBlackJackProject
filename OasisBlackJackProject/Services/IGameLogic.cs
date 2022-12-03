using OasisBlackJackProject.Enums;
using OasisBlackJackProject.Models;

namespace OasisBlackJackProject.Services
{
    public interface IGameLogic
    {
        int Bet { get; set; }
        Dealer Dealer { get; set; }
        Deck Deck { get; set; }
        Player Player { get; set; }
        GameStatus Status { get; set; }
        GameDataAccess Store { get; set; }


        /// <summary>
        ///  Deal 2 cards to the dealer and 2 to the player
        /// </summary>
        void CreateHandsForStart();

        /// <summary>
        /// Brings cards to the dealer until the sum of cards is above 16 
        /// and checks if its his hand is bust
        /// </summary>
        void DealerHit();

        /// <summary>
        /// Receives a new bet from the user,
        /// checks if he has enough money to bet.
        /// </summary>
        /// <param name="bet">bet from user in int</param>
        void GetNewBet(int bet);

        /// <summary>
        /// method that gives the player extra card and checks if its his hand is bust
        /// </summary>
        void PlayerHit();

        /// <summary>
        /// method that ends the game, called by the player.
        /// Returns the game state and calculates the winner.
        /// </summary>
        void PlayerSubmit();

        /// <summary>
        /// Cleans the dealer's and player's hands to deal them new cards
        /// </summary>
        void CleanHands();
    }
}