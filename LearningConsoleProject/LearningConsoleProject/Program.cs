using System;
using System.Runtime.InteropServices.JavaScript;

namespace LearningConsoleProject
{
    internal class Program
    {
        static void Calculator() 
        {
            List<string> historyOfCalculations = new List<string>();
            //Input reader
            //- История вычислений (сохраняй в List)
            //- Сохрани результат в файл JSON

            static int PassArguments()
            {
                Console.WriteLine("Enter a number:");
                string numberCommandLine = Console.ReadLine();//TODO: to validate this
                int numberInt;// = Int32.Parse(firstNumberCommandLine);
            
                if (!String.IsNullOrEmpty(numberCommandLine))
                {
                    try
                    {
                        //if (!firstNumberCommandLine.IsNullOrEmpty){}
                        //if (firstNumberCommandLine != null && firstNumberCommandLine != "") { firstNumberInt = Int32.Parse(firstNumberCommandLine); }
                        numberInt = Int32.Parse(numberCommandLine);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("type in only integer value");
                        Console.WriteLine(e);
                        throw;
                    }
                }
                else
                {
                    return 0;
                }

                return numberInt;
            }

            /*int firstNumberInt = PassArguments();//TODO: to validate if return 0;
            int secondNumberInt = PassArguments();*/
            
            void PrintHistoryOfOperation()
            {
                foreach (var calculation in historyOfCalculations){
                    Console.WriteLine("calculation: " + calculation);
                }
            }

            void AddResultToHistoryOfCalculations(int firstNumberInt, int secondNumberInt, string operation, int result)
            {
                historyOfCalculations.Add(firstNumberInt + operation + secondNumberInt + "=" + result);
            }

            string operationInput()
            {
                Console.WriteLine("Enter an operation to execute:");
                string operation = Console.ReadLine();
                return operation;
            }

            int operationProcessing(string operation, int firstNumberInt, int secondNumberInt)
            {
                /*Console.WriteLine("Enter an operation to execute:");
                string operation = Console.ReadLine();*/
                //int result = firstNumber % secondNumber;
                var result = 0;
                switch (operation)
                {//Числа a/b, операции + - * / %
                    case "+": Console.WriteLine("result: " + (firstNumberInt + secondNumberInt));
                        result = firstNumberInt + secondNumberInt;
                        break;
                    //return firstNumber + secondNumber;
                    case "-": result = firstNumberInt - secondNumberInt; break;
                    case "*": result = firstNumberInt * secondNumberInt; break;
                    case "/": result = firstNumberInt / secondNumberInt; break;
                    case "%": result = firstNumberInt % secondNumberInt; break;
                    default: Console.WriteLine("Invalid operation"); break;//TODO: to fix Exception on something else
                }
                return result;
            }

            string continueCalculations()
            {
                Console.WriteLine("to continue with next operation type in 'yes', to cancel execution type in 'no':");
                string answerFromUser = Console.ReadLine();
                return answerFromUser;
            }

            static void printResultToJSON()
            {
            }

            void SingleCalculation()
            {
                int firstNumberInt = PassArguments();//TODO: to validate if return 0;
                int secondNumberInt = PassArguments();
                string operation = operationInput();
                int result = operationProcessing(operation, firstNumberInt, secondNumberInt);
                AddResultToHistoryOfCalculations(firstNumberInt, secondNumberInt, operation, result);
            }
            
            
            
            /*Console.WriteLine("Enter an operation to execute:");
            string operation = Console.ReadLine();
            //int result = firstNumber % secondNumber;
            var result = 0;
            switch (operation)
            {//Числа a/b, операции + - * / %
                case "+": Console.WriteLine("result: " + (firstNumberInt + secondNumberInt));
                    result = firstNumberInt + secondNumberInt;
                    break;
                //return firstNumber + secondNumber;
                case "-": result = firstNumberInt - secondNumberInt; break;
                case "*": result = firstNumberInt * secondNumberInt; break;
                case "/": result = firstNumberInt / secondNumberInt; break;
                case "%": result = firstNumberInt % secondNumberInt; break;
                default: Console.WriteLine("Invalid operation"); break;//TODO: to fix Exception on something else
            }*/
            /*string operation = operationInput();
            int result = operationProcessing(operation);*/
            //historyOfCalculations.Add(firstNumberInt + operation + secondNumberInt + "=" + result);
            //AddResultToHistoryOfCalculations(firstNumberInt, secondNumberInt, operation, result);
            SingleCalculation();

            /*string answerUserToContinueCalculation = continueCalculations();
            if (answerUserToContinueCalculation == "no")
            {
                PrintHistoryOfOperation();
                //Console.WriteLine("result: " + result);
            }
            else
            {
                SingleCalculation();
            }*/
            string answerUserToContinueCalculation = continueCalculations();
            while (answerUserToContinueCalculation == "yes")
            {
                SingleCalculation();
                answerUserToContinueCalculation = continueCalculations();
            }
            PrintHistoryOfOperation();
            
            /*PrintHistoryOfOperation();
            /*foreach (var calculation in historyOfCalculations){
                Console.WriteLine("calculation: " + calculation);
            }#1#
            //Console.WriteLine("historyOfCalculations: " + historyOfCalculations);
            Console.WriteLine("result: " + result);*/
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
            var wordsVowelsConsonants = "";
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

                    Console.WriteLine("TESTING BRANCH");
                }

                wordsVowelsConsonants += sub + " vowels: " + vowels + ", consonants: " + (sub.Length - vowels) + '\n';
                vowels = 0;
                Console.WriteLine($"Substring: {sub} + {sub.Length}" + sub + " vowels: " + vowels + ", consonants: " + (sub.Length - vowels));
            }
            //Console.WriteLine("number of vowels inside all words:" + vowels + "count of words:" + subs.Length + "count of consonants:" + (subs.Length-vowels));
            Console.WriteLine(wordsVowelsConsonants);
        }
        
        public static void Main(string[] args)
        {
            Calculator();
            //Guessnumber();
            //multiplicationTable();
            //stringParser();
        }
    }
}