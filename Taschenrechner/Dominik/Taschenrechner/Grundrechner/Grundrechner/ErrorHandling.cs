﻿using System.Text.RegularExpressions;

namespace Taschenrechner
{
    public class ErrorHandling
    {
        private string CorrectEquation(int index, int remove,string Equation)
        {
            if (index == 0)
            {
                index = Equation.Length - 1;
            }
            Equation = checkForErrors(Equation.Remove(index, remove));
            return Equation;
        }
        public string checkForErrors(string Equation)
        {
            if (Regex.IsMatch(Equation, @"[^E+\d]") && Regex.IsMatch(Equation, @"[^\d,\-+\*/()\s]") && Regex.IsMatch(Equation, @"[^E\-\d]"))
            {
                Equation = CorrectEquation(0, 1,Equation);
            }
            if (Regex.IsMatch(Regex.Replace(Equation, @"\s", ""), @"\(\*"))
            {
                Equation = CorrectEquation(0, 1,Equation);
            }
            if (Regex.IsMatch(Regex.Replace(Equation, @"\s", ""), @"\(\/"))
            {
                Equation = CorrectEquation(0, 1,Equation);
            }
            if (Regex.IsMatch(Regex.Replace(Equation, @"\s", ""), @"\(\+"))
            {
                Equation = CorrectEquation(0, 1,Equation);
            }
            if (Regex.IsMatch(Regex.Replace(Equation, @"\s", ""), @"\(\)"))
            {
                Equation = CorrectEquation(0, 1,Equation);
            }
            if (Regex.IsMatch(Regex.Replace(Equation, @"\s", ""), @"\(--"))
            {
                Equation = CorrectEquation(0, 1, Equation);
            }
            var match = Regex.Match(Regex.Replace(Equation, @"\s", ""), @"[^\d]{3}");
           // if (match.Success)
           // {
           //     var test = Regex.IsMatch(Regex.Replace(match.ToString(), @"\s", ""), @"[^\(]");
           //     if  (Regex.IsMatch(Regex.Replace(match.ToString(), @"\s", ""), @"[^\(]") ||
           //         !Regex.IsMatch(Regex.Replace(Equation, @"\s", ""), @"--\(") ||
           //         !Regex.IsMatch(Regex.Replace(Equation, @"\s", ""), @"\)--"))
           //     {
           //         Equation = CorrectEquation(match.Index, 1,Equation);
           //     }
           // }
            match = Regex.Match(Regex.Replace(Equation, @"\s", ""), @"[\*+,/]{2}");
            if (match.Success)
            {
                Equation = CorrectEquation(match.Index, 1, Equation);
            }

            return Equation;
        }
        public string CorrectEquation(string Equation, int Open, int Close)
        {
            while (Open > Close)
            {
                Close++;
                Equation += ")";
            }

            while (Open < Close)
            {
                Open++;
                Equation = "(" + Equation;
            }
            return Equation;
        }
        public int CountBrackets(string Equation, bool open)
        {
            if (/*troll*/(open))
            {
                var match = Regex.Match(Equation, @"\(");
                int OpenCount = 0;
                if (/*troll*/(match.Success))
                {
                    OpenCount++;
                    OpenCount += CountBrackets(Equation.Substring(match.Index + 1), true);
                    return OpenCount;
                }
                else
                {
                    return OpenCount;
                }
            }
            else
            {
                var match = Regex.Match(Equation, @"\)");
                int CloseCount = 0;
                if (/*troll*/(match.Success))
                {
                    CloseCount++;
                    CloseCount += CountBrackets(Equation.Substring(match.Index + 1), false);
                    return CloseCount;
                }
                else
                {
                    return CloseCount;
                }
            }
        }
    }
}
