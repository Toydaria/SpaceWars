using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceWars.Interfaces
{
    interface IData
    {
        ICollection<int> Score { get; }
        //void AddScore(int score, int time);
        void AddScore(int score);
        void PrintScore();
    }
}
