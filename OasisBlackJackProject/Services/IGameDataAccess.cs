using OasisBlackJackProject.Enums;
using OasisBlackJackProject.Models;

namespace OasisBlackJackProject.Services
{
    public interface IGameDataAccess
    {
        int BetSum { get; set; }
        Hand DealerHand { get; set; }
        Hand PlayerHand { get; set; }
        int PlayerWallet { get; set; }
        GameStatus Status { get; set; }
    }
}