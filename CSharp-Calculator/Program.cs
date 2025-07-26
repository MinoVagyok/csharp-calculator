using System;
using CSharp_Calculator.Logic;
using CSharp_Calculator.Logic.Error_Handling;


class Program
{
    static void WriteOut(List<Token_Logic.Token> tokens)
    {
        List<string> outputStrings = new List<string>();
        foreach (var token in tokens)
        {
            outputStrings.Add(token.Value);
        }

        //double result = ExpressionEvaluator.Evaluate(tokens);
        //outputStrings.Add(result.ToString());
        
        string joined = string.Join(", ", outputStrings);
        Console.WriteLine($"[{joined}]");
    }

    static void Main(string[] args)
    {
        bool flag = true;
        while (flag)
        {
            Console.WriteLine("*** Calculator ***");
            Console.WriteLine("Please enter the expression you want to Calculate!");
            var input = Console.ReadLine();
            List<Token_Logic.Token> list = ExpressionTokenizer.Tokenizer(input);
            if (list != null)
            {
                var postfix = ShuntingYard.ConvertToPostFix(list);
                WriteOut(postfix);
                var test = ExpressionEvaluator.EvaluatePostFix(postfix);
                Console.WriteLine($"Test: {test}");
                //Console.WriteLine(ExpressionEvaluator.Evaluate(list));
            }
            else
            {
                Console.WriteLine("Invalid expression");
            }



        }
    }

}

