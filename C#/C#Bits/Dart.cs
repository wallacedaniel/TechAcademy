// Darts 
// devu.com C# Fundamentals via ASP.NET Web Applications
// Lesson 10 Challenge Assembilies Name Spaces and Class Members
// This code is located at Dart.cs in project solution.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartThrow
{
    public class Dart
    {
        public int Score { get; set; }
        public bool DoubleRing { get; set; }
        public bool TripleRing { get; set; }
        public bool OuterBullsEye { get; set; }
        public bool InnerBullsEye { get; set; }


        public void Throw(Random random)
        {
            int points = random.Next(0, 21);
            int bonusPoints = random.Next(1, 21);
            this.Score = points;

            if (points == 0 && bonusPoints == 1) this.OuterBullsEye = true;
            else if (points == 0) this.InnerBullsEye = true;
            else if (bonusPoints == 1) this.DoubleRing = true;
            else if (bonusPoints == 2) this.TripleRing = true;     
        }
    }
}
