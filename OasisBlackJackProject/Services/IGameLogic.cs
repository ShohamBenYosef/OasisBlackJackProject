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

        void CreateHandsForStart();
        void DealerHit();
        void GetNewBet(int bet);
        void PlayerHit();
        void PlayerSubmit();
    }
}