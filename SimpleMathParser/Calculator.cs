using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleMathParser
{
    public static class Calculator
    {
        public static double EvaluateSimpleExpression(List<string> expression)
        {       
            double result = 0;

            for (int i = 0; i < expression.Count; i++)
            {
                if (i == 0)
                {
                    result = double.Parse(expression[i]);
                }
                else
                {                    
                    if (ParsingHelper.Operators.Contains(expression[i]))
                    {
                        var firstNumber = result;
                        var op = expression[i];
                        var secondNumber = double.Parse(expression[i + 1]);
                        result = PerformOperation(firstNumber, secondNumber, op);
                        i++;
                    }                                                            
                }
            }
            return result;
        }

        //TODO: refactor to list of func
        private static double PerformOperation(double firstValue, double secondValue, string operation)
        {
            if (operation == "+")
            {
                return (firstValue + secondValue);
            }
            else if (operation == "-")
            {
                return (firstValue - secondValue);
            }
            else if (operation == "*")
            {
                return (firstValue * secondValue);
            }
            else if (operation == "/")
            {
                return (firstValue / secondValue);
            }

            throw new ArgumentException("Invalid expression");
        }

        public static double Execute(List<string> parsedExpressionInRPN)
        {
            Stack<double> calculator = new Stack<double>();

            foreach (string token in parsedExpressionInRPN)
            {
                int count = token.Count(c => char.IsDigit(c));
                if (count == token.Length)
                {
                    calculator.Push(double.Parse(token));
                }

                else if (token == "+")
                {
                    calculator.Push(calculator.Pop() + calculator.Pop());
                }
                else if (token == "-")
                {
                    var firstVal = calculator.Pop();
                    var secondVal = calculator.Pop();
                    calculator.Push(secondVal - firstVal);
                }
                else if (token == "*")
                {
                    calculator.Push(calculator.Pop() * calculator.Pop());
                }
                else if (token == "/")
                {
                    var firstVal = calculator.Pop();
                    var secondVal = calculator.Pop();
                    calculator.Push(secondVal / firstVal);
                }
            }

            return calculator.Pop();
        }
    }
}
