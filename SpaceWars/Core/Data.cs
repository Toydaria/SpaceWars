using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using SpaceWars.GameObjects;
using SpaceWars.Interfaces;

namespace SpaceWars.Core
{
    class Data: IData
    {
        private readonly List<int> score = new List<int>();
        private Stringer outputStringer = new Stringer(new Vector2(50, 400));

        //private readonly Dictionary<int, int> score = new Dictionary<int, int
        private string path;

        public Data()
        {
            this.Score = score;
        }

        public ICollection<int> Score { get; }
        ////public IDictionary <int, int> Score{get;}

        //public void AddScore(int score)
        //{
        //    Score.Add(score);
        //}

        public void AddScore(int score)
        {
           StreamWriter writer = new StreamWriter(path, true);
            using (writer)
            {
                writer.WriteLine("{0}", score);
            }
        }

        private void LoadScore(/*formatter, */)
        {
            StreamReader reader = new StreamReader(path);
            using (reader)
            {
                string currentScore = reader.ReadLine();
                while (currentScore != null)
                {
                    Score.Add(int.Parse(currentScore));
                }
            }

        }

        public void PrintScore()
        {
            if (Score.Any())
            {
                var sortedScores = Score.OrderByDescending(x => x).Take(10);
                StringBuilder output = new StringBuilder();
                foreach (int score in sortedScores)
                {
                    output.AppendFormat("{0}{1}", score, Environment.NewLine);
                }
            }
            
        }
    }
}
