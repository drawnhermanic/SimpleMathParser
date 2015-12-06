using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SimpleMathParser
{  
    public class MathParser
    {
        private static Dictionary<string,string> ExpressionConversion { get; set; }
       
        public MathParser()
        {
            ExpressionConversion = new Dictionary<string, string>();
            ExpressionConversion.Add("a", "+");
            ExpressionConversion.Add("b", "-");
            ExpressionConversion.Add("c", "*");
            ExpressionConversion.Add("d", "/");
            ExpressionConversion.Add("e", "(");
            ExpressionConversion.Add("f", ")");
        }

        public double Calculate(string expression)
        {
            var convertedExpression = ReplaceVariables(expression);

            if (!ParsingHelper.IsValidExpression(convertedExpression))
            {
                throw new ArgumentException("Invalid argument. Must only contain digits or defined rule");
            }

            var tokenList = ConvertExpressionToTokens(convertedExpression);

            ExpandParenthesesExpressions(tokenList);

            return Calculator.EvaluateSimpleExpression(tokenList);
            
            //or use a package (e.g. NCalc) to evaluate expression!

            //convert expression 
            //order expression by precendence
            //calculate parts
            //calculate expression
        }

        private static string ReplaceVariables(string expression)
        {
            foreach (string key in ExpressionConversion.Keys)
            {
                expression = expression.Replace(key, ExpressionConversion[key]);
            }
            return expression;
        }

        private static List<string> ConvertExpressionToTokens(string expression)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("([");
            foreach (var value in ExpressionConversion.Values)
            {
                sb.Append(@"\" + value);
            }
            sb.Append("/])");

            Regex re = new Regex(sb.ToString());
            return re.Split(expression).Select(t => t.Trim()).Where(t => t != "").ToList();
        }

        private static void ExpandParenthesesExpressions(List<string> tokenList)
        {
            while (tokenList.IndexOf("(") != -1)
            {
                var open = tokenList.LastIndexOf("(");
                var close = tokenList.IndexOf(")", open);

                if (open >= close)
                {
                    throw new ArithmeticException("No closing bracket");
                }

                var parenthesesExpression = new List<string>();

                for (var i = open + 1; i < close; i++)
                {
                    parenthesesExpression.Add(tokenList[i]);
                }

                var result = Calculator.EvaluateSimpleExpression(parenthesesExpression);

                tokenList[open] = result.ToString();
                tokenList.RemoveRange(open + 1, close - open);
            }
        }
    }


}
