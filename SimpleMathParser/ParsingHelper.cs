using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMathParser
{
    public static class ParsingHelper
    {
        //TODO: extract all constants
        public static List<string> Operators = new List<string> { "+", "-", "*", "/" };
        public static bool IsOperator(char a)
        {
            return Operators.Contains(a.ToString());
        }

        public static bool IsLeftBracket(char a)
        {
            return (a == '(');
        }

        public static bool IsRightBracket(char a)
        {
            return (a == ')');
        }

        public static bool IsParentheses(char a)
        {
            return IsLeftBracket(a) || IsRightBracket(a);
        }

        public static bool IsNumber(char a)
        {
            return char.IsDigit(a);
        }

        public static bool IsValid(char a)
        {
            return IsNumber(a) || IsOperator(a) || IsParentheses(a);
        }

        public static bool IsValidExpression(string expression)
        {
            var charArray = expression.ToCharArray();
            foreach (var a in charArray)
            {
                if (!IsValid(a))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
