using CSharp_Calculator.Logic;

namespace CSharp_Calculator.Logic
{
    public static class ShuntingYard
    {
        public static List<Token_Logic.Token> ConvertToPostFix(List<Token_Logic.Token> infixTokens)
        {
            List<Token_Logic.Token> output = new List<Token_Logic.Token>();
            Stack<Token_Logic.Token> operators = new Stack<Token_Logic.Token>();
            for (int i = 0; i < infixTokens.Count; i++)
            {
                if (infixTokens[i].Type == Token_Logic.TokenType.Number)
                {
                    output.Add(infixTokens[i]);
                }
                
                else if (infixTokens[i].Type == Token_Logic.TokenType.LeftParenthesis)
                {
                    operators.Push(infixTokens[i]);
                }
                else if (infixTokens[i].Type == Token_Logic.TokenType.RightParenthesis)
                {
                    while (operators.Count > 0 && operators.Peek().Type != Token_Logic.TokenType.LeftParenthesis)
                    {
                        output.Add(operators.Pop());
                    }

                    if (operators.Count == 0)
                    {
                        throw new Exception("Mismatched parenthesis");
                    }

                    operators.Pop();

                }
                else if (infixTokens[i].Type == Token_Logic.TokenType.Operator)
                {
                    //For easier visibility for Shunting Yard
                    var currentOp = infixTokens[i].Value;
                    while (operators.Count != 0 && operators.Peek().Value != "(" && (
                               GetPrecedence(operators.Peek().Value) > GetPrecedence(currentOp) ||
                               (GetPrecedence(operators.Peek().Value) == GetPrecedence(currentOp) &&
                                IsLeftAssociative(currentOp)))
                          )
                    {
                        output.Add(operators.Pop());
                    }
                    operators.Push(infixTokens[i]);
                }
          
            }
            while (operators.Count > 0)
            {
                if (operators.Peek().Type == Token_Logic.TokenType.LeftParenthesis ||
                    operators.Peek().Type == Token_Logic.TokenType.RightParenthesis)
                {
                    throw new Exception("Mismatched parentheses at end.");
                }
                output.Add(operators.Pop());
            }
            return output;
        }

        private static int GetPrecedence(string op)
        {
            return op switch
            {
                "+" or "-" => 1,
                "*" or "/" => 2,
                _ => -1
            };
        }

        private static bool IsLeftAssociative(string op)
        {
            return op is "+" or "-" or "*" or "/";
        }

    }
}
