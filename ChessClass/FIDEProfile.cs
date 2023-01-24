using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayerClass;

namespace ChessClass
{
    internal class FIDEProfile
    {
        private int _rating;
        private int _wins;
        private int _losses;
        private bool _banned;

        public int Rating { get { return _rating; } private set { _rating = value; } }
        public int Wins { get { return _wins; } private set { _wins = value; } }
        public int Losses { get { return _losses; } private set { _losses = value; } }
        public bool Banned { get { return _banned; } protected set { _banned = value; } }

        public FIDEProfile(int rating, int wins, int losses, bool banned)
        {
            _rating = rating;
            _wins = wins;
            _losses = losses;
            _banned = banned;
        }

        public void changeRating(int amount)
        {
            _rating += amount;
        }

        public void banOrUnbanPlayer(bool banOrUnban)
        {
            _banned = banOrUnban;
        }
        public void changeWinLoss(string WinOrLoss, int NewValue)
        {
            if (WinOrLoss == "Win")
            {
                _wins = NewValue;
            }
            else
            {
                _losses = NewValue;
            }
        }
        public string Info()
        {
            return $"Wins: {Wins}\nLosses: {Losses}\nRating: {Rating}";
        }
    }
}
