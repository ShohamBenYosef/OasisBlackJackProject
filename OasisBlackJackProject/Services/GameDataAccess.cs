﻿using OasisBlackJackProject.Enums;
using OasisBlackJackProject.Models;

namespace OasisBlackJackProject.Services
{
    public class GameDataAccess : IGameDataAccess
    {
        public Hand PlayerHand { get; set; }
        public Hand DealerHand { get; set; }
        public GameStatus Status { get; set; }
        public int PlayerWallet { get; set; }
        public int BetSum { get; set; }

        public GameDataAccess()
        {
            PlayerHand = new Hand();
            DealerHand= new Hand();
            Status = GameStatus.BeforeBet;
            PlayerWallet = 0;
            BetSum = 0;
        }

        public void SetStore(Hand playerHand, Hand dealerHand, GameStatus status, int playerWallet, int betSum)
        {
            this.PlayerHand = playerHand;
            this.DealerHand = dealerHand;
            this.Status = status;
            this.PlayerWallet = playerWallet;
            this.BetSum = betSum;
        }
    }
}
