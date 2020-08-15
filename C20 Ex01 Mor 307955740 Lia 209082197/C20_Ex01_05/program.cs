using System;

namespace C20_Ex01_05
{
    class Program
    {
        public const int k_LengthString = 8;
        public const int k_FirstDigit = 7;
        public const int k_DividedBy4 = 4;

        public static void Main()
        {
            GetPositiveNumberFromUserAndAnalyze();
        }

        public static void GetPositiveNumberFromUserAndAnalyze()
        {
            Console.WriteLine("Please enter a string with 8 digits only: ");
            string inputFromTheUser = Console.ReadLine();

            //check the input from the user
            while (!ValidateInput(inputFromTheUser))
            {
                Console.WriteLine("Invalid input. Please try again: ");
                inputFromTheUser = Console.ReadLine();
            }

            int biggestDigit = FindTheBiggestDigit(inputFromTheUser);
            int smallestDigit = FindTheSmallestDigit(inputFromTheUser);
            int countOfDigitsDividedByFour = FindCountDigitDividedByFour(inputFromTheUser);
            int countOfDigitsBiggerFirst = FindCountDigitsBiggerFirst(inputFromTheUser);


            string messageToTheUserAboutTheNumbers = String.Format(@"-The biggest digit in the number is: {0}.
-The smallest digit in the number is: {1}.
-The count of numbers that are divided by 4: {2}. 
-The count of the digits are bigger than first digit {3}: {4}.", biggestDigit, smallestDigit, countOfDigitsDividedByFour, 
(int)char.GetNumericValue(inputFromTheUser[k_FirstDigit]), countOfDigitsBiggerFirst);

            Console.WriteLine(messageToTheUserAboutTheNumbers);
        }

        //check validate of the input
        public static bool ValidateInput(string i_InputString)
        {
            bool iSAllDigit = true;
            int count = 0;

            if(k_LengthString == i_InputString.Length)
            {
                for(int i = 0; i < k_LengthString; i++)
                {
                    if(!char.IsDigit(i_InputString[i]))
                    {
                        iSAllDigit = false;
                        break;
                    }
                    else
                    {
                        if(i_InputString[i] == '0')
                        {
                            count++;
                        }
                    }
                }
            }
            else
            {
                iSAllDigit = false;
            }

            return iSAllDigit && (count != 8 );
        }

        //function return the biggest digit in the string
        public static int FindTheBiggestDigit(string i_InputFromTheUser)
        {
            double maxDigit = char.GetNumericValue(i_InputFromTheUser[0]);

            for(int i = 1; i < k_LengthString; i++)
            {
                if(maxDigit < char.GetNumericValue(i_InputFromTheUser[i]))
                {
                    maxDigit = char.GetNumericValue(i_InputFromTheUser[i]);
                }
            }

            return (int)maxDigit;
        }

        //function return the smallest digit in the string
        public static int FindTheSmallestDigit(string i_InputFromTheUser)
        {
            double smallestDigit = char.GetNumericValue(i_InputFromTheUser[0]);

            for (int i = 1; i < k_LengthString; i++)
            {
                if (smallestDigit > char.GetNumericValue(i_InputFromTheUser[i]))
                {
                    smallestDigit = char.GetNumericValue(i_InputFromTheUser[i]);
                }
            }

            return (int)smallestDigit;
        }

        //function return amount of digit are divided by 4
        public static int FindCountDigitDividedByFour(string i_InputFromTheUser)
        {
            int countDividedByFourDigit = 0;

            for (int i = 0; i < k_LengthString; i++)
            {
                if (char.GetNumericValue(i_InputFromTheUser[i]) % k_DividedBy4 == 0)
                {
                    countDividedByFourDigit++;
                }
            }

            return countDividedByFourDigit;
        }


        //function return the count of the digits are bigger than first digit
        public static int FindCountDigitsBiggerFirst(string i_InputFromTheUser)
        {
            int countDigitsBiggerFirst = 0;
            double firstDigit = char.GetNumericValue(i_InputFromTheUser[k_FirstDigit]);

            for (int i = 0; i < k_LengthString; i++)
            {
                if (char.GetNumericValue(i_InputFromTheUser[i]) > firstDigit)
                {
                    countDigitsBiggerFirst++;
                }
            }

            return countDigitsBiggerFirst;
        }
    }
}
