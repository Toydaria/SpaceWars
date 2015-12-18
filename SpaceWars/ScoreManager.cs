using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceWars.Interfaces;

namespace SpaceWars
{
    class ScoreManager
    {
        private int totalScore;

        public ScoreManager(int totalScore)
        {
            this.TotalScore = totalScore;
        }
        
        public int TotalScore
        {
            get { return this.totalScore; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Score cannot be negative");
                }
            }
        }

        public void AddPoints(IGiveScore enemyTarget)
        {
            this.TotalScore += enemyTarget.Points;
        }
    }
}

