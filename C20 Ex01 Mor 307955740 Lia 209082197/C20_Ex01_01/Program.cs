using System;
using System.Text;



namespace C20_Ex01_01
{
    class Program
    {
        public const int k_NumOfBinaryNumbers = 4;
        public const int k_LenOfBinaryNumbers = 8;
        public const int k_Ten=10;

        public static void Main()
        {
            GetBinaryNumberFromUser();
        }

        public static void GetBinaryNumberFromUser()
        {
            int binaryNumberInput;

            // variable for the zeros and the ones average 
            int countOfZeroInBinaryNumber = 0;
            int countOfOneInBinaryNumber = 0;

            // variable for the decimal numbers average
            int sumOfAllDecimalNumbers = 0;
            int countOfAscending = 0;
            int countOfNumbersPowerOfTwo = 0;

            StringBuilder finalMessage = new StringBuilder("-The decimal numbers are:  ");
            Console.WriteLine("Please enter 4 binary numbers with 8 digits");
        
            for (int i = 0; i < k_NumOfBinaryNumbers; i++)
            {
                string binaryNumberInputString = Console.ReadLine();

                // validation of the input
                while ((ValidateBinaryNumber(binaryNumberInputString) != true))
                {
                    Console.WriteLine("Invalid input please try again. Enter a 8 digit binary number: ");
                    binaryNumberInputString = Console.ReadLine();
                }

                int.TryParse(binaryNumberInputString, out binaryNumberInput);

                // count of zero and one
                CountNumberOfZeroAndOne(ref countOfZeroInBinaryNumber, ref countOfOneInBinaryNumber, binaryNumberInput);

                // convert from binary to decimal
                int decimalOfBinaryNumber = ConvertFromBinaryToDecimal(binaryNumberInput);
                finalMessage.AppendFormat("{0} ", decimalOfBinaryNumber);

                // power of 2
                bool isNumberPowerOfTwo = CheckIfNumberIsPowerOfTwo(decimalOfBinaryNumber);
                if (isNumberPowerOfTwo == true)
                {
                    countOfNumbersPowerOfTwo++;
                }

                // sum of all numbers
                sumOfAllDecimalNumbers += decimalOfBinaryNumber;

                // count of ascending numbers
                bool isNumberAscending = CheckIfNumberIsAscending(decimalOfBinaryNumber);

                if(isNumberAscending == true)
                {
                    countOfAscending++;
                }
            }

            //average
            float averageOfZeroInBinaryNumber = countOfZeroInBinaryNumber / 4f;
            float averageOfOneInBinaryNumber = countOfOneInBinaryNumber / 4f;
            float averageOfAllNumbers = sumOfAllDecimalNumbers / 4f;

            string messageToTheUserAboutTheNumbers = String.Format($@"-The general average of zeros is {averageOfZeroInBinaryNumber}.
-The general average of ones is {averageOfOneInBinaryNumber}.
-The count of numbers that are the power of two: {countOfNumbersPowerOfTwo}. 
-There are {countOfAscending} numbers which are an ascending series.
-The general average of the inserted numbers is {averageOfAllNumbers}.");
                

            finalMessage.AppendFormat("{0} ", '.');
            Console.WriteLine(finalMessage);
            Console.WriteLine(messageToTheUserAboutTheNumbers);
        }
       

        //function that get the count of zero and one and add the count from the new binary number
        public static void CountNumberOfZeroAndOne(ref int io_CountOfZeroInBinaryNumber, ref int io_CountOfOneInBinaryNumber,int i_BinaryNumber)
        {  
            for(int i=0; i<k_LenOfBinaryNumbers;i++)
            {
                int lastDigitOfBinaryNumber = i_BinaryNumber % k_Ten;
                if(lastDigitOfBinaryNumber==1)
                {
                    io_CountOfOneInBinaryNumber++;
                }
                else
                {
                    io_CountOfZeroInBinaryNumber++;
                }

                i_BinaryNumber /= k_Ten;
            }
        }

        //the function check if the number is ascending order of digits
        public static bool CheckIfNumberIsAscending(int i_DecimalOfBinaryNumber)
        {
            int lastDigitOfNumber = i_DecimalOfBinaryNumber % k_Ten;
            bool flagIfAscending = true;

            i_DecimalOfBinaryNumber /= k_Ten;

            while (i_DecimalOfBinaryNumber != 0)
            {
                int newDigitOfNumber = i_DecimalOfBinaryNumber % k_Ten;

                if(newDigitOfNumber >= lastDigitOfNumber)
                {
                    flagIfAscending = false;
                    break;
                }
                else
                {
                    lastDigitOfNumber = newDigitOfNumber;
                    i_DecimalOfBinaryNumber /= k_Ten;
                }
            }

            return flagIfAscending;
        }

        //the function checks if the number is power of two
        public static bool CheckIfNumberIsPowerOfTwo(int i_DecimalOfBinaryNumber)
        {
            double powerOfTwo = 0;
            int i = 0;
            bool flagIsPower = false;

            while (i_DecimalOfBinaryNumber > powerOfTwo)
            {
                powerOfTwo = Math.Pow(2, i);

                if((int)powerOfTwo == i_DecimalOfBinaryNumber)
                {
                    flagIsPower = true;
                    break;
                }

                i++;
            }

            return flagIsPower;
        }

        //function that checks if all digits are binary
        public static bool CheckIfAllDigitsAreBinary(string i_BinaryNumberInputString)
        {
            int lenOfBinaryNumber = i_BinaryNumberInputString.Length;
            bool flag = true;

            for(int i=0; i< lenOfBinaryNumber; i++)
            {
                if((i_BinaryNumberInputString[i] != '0') && (i_BinaryNumberInputString[i] != '1'))
                {
                    flag = false;
                    break;
                }
            }

            return flag;
        }

        //function that convert the binary number to decimal number
        public static int ConvertFromBinaryToDecimal(int i_BinaryNumberInput)
        {
            double resDecimalNumber = 0;
            int i = 0;

            while(i_BinaryNumberInput!=0)
            {
                int lastDigit = i_BinaryNumberInput % k_Ten;
                resDecimalNumber += (Math.Pow(2, i) * lastDigit);
                i++;
                i_BinaryNumberInput /= k_Ten;
            }

            return (int)resDecimalNumber;
        }

        // Validate the numbers is a numbers and a binary in the correct size
        public static bool ValidateBinaryNumber(string i_BinaryNumber)
        {
            int binaryNumberInput;
            int lengthOfBinaryNumber = i_BinaryNumber.Length;
            bool flagIfAllDigitsAreBinary = CheckIfAllDigitsAreBinary(i_BinaryNumber);
            bool successOfParsing = int.TryParse(i_BinaryNumber, out binaryNumberInput);

            return (lengthOfBinaryNumber == k_LenOfBinaryNumbers) && (successOfParsing == true) && (flagIfAllDigitsAreBinary == true);
        }
    }
}
