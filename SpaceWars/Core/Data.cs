using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceWars.GameObjects;
using SpaceWars.Interfaces;

namespace SpaceWars.Core
{
    public class Data: IData
    {
        private readonly List<int> score = new List<int>();
        private string path = "";
        private SpriteBatch spriteBatch;

        public Data()
        {
            this.Score = score;
        }

        public Stringer OutputWriter { get; set; }
        public ICollection<int> Score { get; set; }
     
        public void AddScore(int score)
        {
            StreamWriter writer = new StreamWriter(path, true);
            using (writer)
            {
                writer.WriteLine("{0}", score);
            }
        }

        //this method loads all the scores from a file to a List and sorts them, it is called internally in PrintScores method

        private void LoadScore()
        {
            StreamReader reader = new StreamReader(path);
            using (reader)
            {
                string currentScore = reader.ReadLine();
                while (currentScore != null)
                {
                    Score.Add(int.Parse(currentScore));
                    currentScore = reader.ReadLine();
                }
            }
        }
        //this method is called in HighScoreScreen class to show the top ten scores
        public void PrintScore()
        {
            LoadScore();
            if (Score.Any())
            {
                var sortedScores = Score.OrderByDescending(x => x).Take(10);
                StringBuilder output = new StringBuilder();
                int index = 1;
                foreach (int score in sortedScores)
                {
                    output.AppendFormat("{0} [{1}]{2}", index,  score, Environment.NewLine);
                    index++;
                }
            }
            OutputWriter.Draw(spriteBatch);
        }

    }
}
