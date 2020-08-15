using System;
using System.Text;


namespace C20_Ex01_04
{
    class Program
    {
        public const int k_LengthString = 12;
        public static void Main()
        {
            GetStringFromUserAndAnalyze();
        }

        //function that get string input from the user and analyzes it
        public static void GetStringFromUserAndAnalyze()
        {
            long numberInput;
            Console.WriteLine("Please enter a string with 12 digits only or letters only: " );
            string inputFromTheUser = Console.ReadLine();
            StringBuilder finalMessage = new StringBuilder();

            while(!ValidateInput(inputFromTheUser))
            {
                Console.WriteLine("Invalid input. Please try again: ");
                inputFromTheUser = Console.ReadLine();
            }

            //checking if the string is a palindrome
            if(IsPalindromeRecursion(inputFromTheUser) == true)
            {
                finalMessage.AppendLine("The input is a palindrome.");
            }
            else
            {
                finalMessage.AppendLine("The input isn't a palindrome.");
            }

            //checks if it's a number. and if it is a number divided by three
            if(long.TryParse(inputFromTheUser, out numberInput) == true)
            {
                if(IsDividedByThree(numberInput) == true)
                {
                    finalMessage.AppendLine("The number is divided by 3.");
                }
                else
                {
                    finalMessage.AppendLine("The number isn't divided by 3.");
                }
            }
            else
            {
                int countLowerLetter = CountLowerCase(inputFromTheUser);
                finalMessage.AppendFormat("The number of lower characters in the string are: {0}.", countLowerLetter);
            }

            Console.WriteLine(finalMessage);
        }

        public static bool IsPalindromeRecursion(string i_InputFromTheUser)
        {
            int lenOfString = i_InputFromTheUser.Length;
            bool isPalindrome = true;

           if(lenOfString != 1 && lenOfString != 0)
            {
                if(i_InputFromTheUser[0] != i_InputFromTheUser[lenOfString-1])
                {
                    isPalindrome = false;
                }
                else
                {
                    IsPalindromeRecursion(i_InputFromTheUser.Substring(1, lenOfString - 2));
                }
            }
            return isPalindrome;
        }

        //function that counts the number of lower characters in the string
        public static int CountLowerCase(string i_InputFromTheUser)
        {
            int lenOfString = i_InputFromTheUser.Length;
            int countLowerLetter = 0;

            for(int i = 0; i < lenOfString; i++)
            {
                if(char.IsLower(i_InputFromTheUser[i]) == true)
                {
                    countLowerLetter++;
                }
            }

            return countLowerLetter;
        }


        //function check if the number divided by three
        public static bool IsDividedByThree(long i_NumberInput)
        {
            return (i_NumberInput % 3 == 0);
        }

        //function validate the input from the user
        public static bool ValidateInput(string i_InputString)
        {
            long numberInput;
            bool isInputANumber = long.TryParse(i_InputString, out numberInput);
            bool isAllCharactersAreLetters = CheckIsAllCharactersAreLetters(i_InputString);

            return ((isAllCharactersAreLetters == true) || (isInputANumber == true)) && IsCorrectLength(i_InputString);
        }

        //function check if all characters are letters
        public static bool CheckIsAllCharactersAreLetters(string i_InputFromTheUser)
        {
            int lenOfString= i_InputFromTheUser.Length;
            bool isLetter = true;

            for(int i = 0; i < lenOfString; i++)
            {
                if(!Char.IsLetter(i_InputFromTheUser[i]))
                {
                    isLetter = false;
                    break;
                }
            }

            return isLetter;
        }

        //function check if the length of the string is 12
        public static bool IsCorrectLength(string i_InputFromTheUser)
        {
            int lengthOfString = i_InputFromTheUser.Length;

            return lengthOfString == k_LengthString;
        }
    }
}
