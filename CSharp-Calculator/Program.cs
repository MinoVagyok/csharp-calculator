using System;
using CSharp_Calculator.Logic;
using CSharp_Calculator.Logic.Error_Handling;


class Program
{
    
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
                Console.WriteLine(ExpressionEvaluator.Evaluate(list));
            }
            else
            {
                Console.WriteLine("Invalid expression");
            }



        }
    }

}

