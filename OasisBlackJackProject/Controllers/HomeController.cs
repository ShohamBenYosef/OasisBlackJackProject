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

        [HttpPost("/start")]
        public ActionResult StartGame()
        {
            _gameLogic.Store.SetStore(_gameLogic.Player.Hand, _gameLogic.Dealer.Hand,
                _gameLogic.Status, _gameLogic.Player.Wallet, _gameLogic.Bet);
            return Ok(_gameLogic.Store);
        }

        [HttpGet("/getNewGame")]
        public ActionResult StartNewGame() 
        {
            _gameLogic.CleanHands();
            _gameLogic.CreateHandsForStart();
            _gameLogic.Status = GameStatus.BeforeBet;
            _gameLogic.Bet = 0;

            _gameLogic.Store.SetStore(_gameLogic.Player.Hand, _gameLogic.Dealer.Hand,
                _gameLogic.Status, _gameLogic.Player.Wallet, _gameLogic.Bet);
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
