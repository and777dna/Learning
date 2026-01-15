using System;

namespace LearningConsoleProject
{
    internal class Program
    {
        static void Calculator() 
        {
            Console.WriteLine("Enter first number:");
            string firstNum = Console.ReadLine();
            var firstNumber = Int32.Parse(firstNum);
            
            Console.WriteLine("Enter second number:");
            string secondNum = Console.ReadLine();
            var secondNumber = Int32.Parse(secondNum);
            
            Console.WriteLine("Enter an operation to execute:");
            string operation = Console.ReadLine();
            //int result = firstNumber % secondNumber;
            var result = 0;
            switch (operation)
            {//Числа a/b, операции + - * / %
                case "+": Console.WriteLine("result: " + firstNumber + secondNumber);
                    result = firstNumber + secondNumber;
                    break;
                //return firstNumber + secondNumber;
                case "-": result = firstNumber - secondNumber; break;
                case "*": result = firstNumber * secondNumber; break;
                case "/": result = firstNumber / secondNumber; break;
                case "%": result = firstNumber % secondNumber; break;
                default: throw new Exception("invalid logic");
            }

            Console.WriteLine(result);
        }
        
        static void Guessnumber()
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 101);
            Console.WriteLine(number);
            Console.WriteLine("Guess a number:");
            
            string num = Console.ReadLine();
            var nnumber = Int32.Parse(num);
            while (nnumber != number)
            {
                if (nnumber > number)
                {
                    Console.WriteLine("type in a lesser number:");
                    string nnum = Console.ReadLine();
                    nnumber = Int32.Parse(nnum);
                }
                if (nnumber < number)
                {
                    Console.WriteLine("type in a greater number:");
                    string nnum = Console.ReadLine();
                    nnumber = Int32.Parse(nnum);
                }
            }
            
            if (nnumber == number)
            {
                Console.WriteLine("you guessed a number");
            }
            
        }

        static void multiplicationTable()
        {
            string[] table;
            var variable = 0;
            string result = "";

            for (var index = 1; index <= 10; index++)
            {
                if (index == 10)
                {
                    result = result + "  " + index + "\n";
                }
                else
                {
                    result = result + "  " + index;
                }
            }
            
            for (var i = 1; i <= 10; i++)
            {
                result = result + i + " ";
                table = new string[] {""};   
                for (int j = 1; j <= 10; j++)
                {
                    variable = i * j;
                    if (j == 10)
                    {
                        result = result + " " + variable + "\n";
                    }
                    else
                    {
                        result = result + " " + variable;
                    }
                    
                    //result = string.Concat(result, variable);
                    /*if (j == 10)
                    {
                        Console.WriteLine("|" + i*j);
                    }*/
                    //Console.WriteLine(variable + " " + result + " " + table);
                    //Console.WriteLine(variable + " " + result);
                }
            }
            Console.WriteLine(result);
        }

        static void stringParser()
        {//Парсер строк: Ввод строки в консоль, метод считает гласные/согласные, длину слов.
            Console.WriteLine("enter a word");
            string words = Console.ReadLine();
            string[] subs = words.Split(' ');
            Console.WriteLine("length:" + " " + words.Length);
            var vowels = 0;
            foreach (var sub in subs)
            {
                foreach (var letter in sub)
                {
                    /*if (letter == "a")
                    {//
                        //
                    }*/
                    if (letter == 'a' || letter == 'o' || letter == 'u' || letter == 'e' || letter == 'y')
                    {
                        vowels += 1;
                    }
                }
                Console.WriteLine($"Substring: {sub} + {sub.Length}");
            }
            Console.WriteLine("number of vowels inside all words:" + vowels + "count of words:" + subs.Length + "count of consonants:" + (subs.Length-vowels));

        }
        
        public static void Main(string[] args)
        {
            //Calculator();
            //Guessnumber();
            //multiplicationTable();
            stringParser();
        }
    }
}