using ScoreSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreSystem
{
    internal class DatabaseAccessor
    {
        public static List<Score> GetResult()
        {
            List<Score> scores = new List<Score>();
            Score s1 = new Score() { StudentName = "AA", MathScore = 55 };
            Score s2 = new Score() { StudentName = "BB", MathScore = 77 };
            Score s3 = new Score() { StudentName = "CC", MathScore = 99 };
            scores.Add(s1);
            scores.Add(s2);
            scores.Add(s3);
            return scores;
        }
    }
}
