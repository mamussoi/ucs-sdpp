using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TankGame
{
    class Player
    {
        GameConstants gc = new GameConstants();

        // Attributes
        protected string charName;
        protected int playerID;
        protected int tanksLost;

        // Constructor
        public Player(string name, int i)
        {
            charName = name;
            playerID = i;
            tanksLost = 0;
        }

        // Property for charName
        public string CharName
        {
            get { return charName; }
        }

        // Property for playerCount
        public int PlayerID
        {
            get { return playerID; }
        }

        // Property for tanksLost
        public int TanksLost
        {
            get { return tanksLost; }
        }

        // Method to track tanks lost
        public void lostTank()
        {
            tanksLost++; // Decrements tanks
        }

        // Method to tell if player has lost
        public bool gameLost()
        {
            return tanksLost >= gc.MaxLives;
        }

        // toString
        public override string ToString()
        {
            return "Name: " + charName + " Id: " + playerID + 
                " Tanks Lost: " + tanksLost;
        }
    }
}
