using Microsoft.AspNetCore.Mvc;
using OasisBlackJackProject.Enums;
using OasisBlackJackProject.Models;
using OasisBlackJackProject.Services;

namespace OasisBlackJackProject.Controllers
{
    public class HomeController : Controller
    {

        private readonly IGameLogic _gameLogic;


        public HomeController(IGameLogic gameLogic)
        {
            _gameLogic = gameLogic;
        }

        /*******DebugFunc***********/
        [HttpGet("/getPlayerCards")] 
        public ActionResult GetPlayerCard() 
        {
            return Ok(_gameLogic.Player.Hand.Cards);
        }

        [HttpGet("/getDealerCards")]
        public ActionResult GetDealerCard()
        {
            return Ok(_gameLogic.Dealer.Hand.Cards);
        }
        /***************************/


        [HttpGet("/getNewGame")]
        public ActionResult GetNewGame() 
        { 
            _gameLogic.Store = new GameDataAccess();
            _gameLogic.Player = new Player();
            _gameLogic.Dealer = new Dealer(_gameLogic.Deck);
            _gameLogic.Deck = new Deck();
            _gameLogic.CreateHandsForStart();
            _gameLogic.Status = GameStatus.BeforeBet;
            _gameLogic.Bet = 0;
            _gameLogic.Store.SetStore(_gameLogic.Player.Hand, _gameLogic.Dealer.Hand, _gameLogic.Status, _gameLogic.Player.Wallet, _gameLogic.Bet);

            return Ok(_gameLogic.Store);
        }


        [HttpPost("/hit")]
        public ActionResult Hit()
        {
            _gameLogic.PlayerHit();
            return Ok(_gameLogic.Store);
        }


        [HttpPost("/submit")]
        public ActionResult Submit() 
        {
            _gameLogic.PlayerSubmit();
            return Ok(_gameLogic.Store);
        }


        [HttpPost("/bet")]
        public ActionResult Bet(string betString)
        {
            bool parseBetFlag = int.TryParse(betString, result: out int betInt);
            if (betInt > 0 && _gameLogic.Status == Enums.GameStatus.BeforeBet)
            {
                _gameLogic.GetNewBet(betInt);
            }
            return Ok(_gameLogic.Store);
        }
    }
}
