using System;
using System.Text;


namespace C20_Ex01_03
{
    class Program
    {
        public const int k_NumberOfOffset = 0;

        public static void Main()
        {
            PrintAdvancedHourGlassInMain();
        }

        //function print hour glass clock in height from the user. 
        public static void PrintAdvancedHourGlassInMain()
        {
            Console.WriteLine("Please enter the height of hour glass clock: ");

            string heightHourGlassString =  Console.ReadLine();
            

            //check the input from the user
            while(StringToIntHeightOfHourGlass(heightHourGlassString) == -1)
            {
                Console.WriteLine("Invalid input. Please try again: ");
                heightHourGlassString = Console.ReadLine();
            }

            int heightHourGlassNumber = StringToIntHeightOfHourGlass(heightHourGlassString);
            StringBuilder hourGlassClock = C20_Ex01_02.Program.PrintHourGlassRecursion(heightHourGlassNumber, k_NumberOfOffset);
            Console.WriteLine(hourGlassClock);
        }

        //function check the input from the user. if it is invalid return -1, else return the height( if is even add 1)
        public static int StringToIntHeightOfHourGlass(string i_HeightHourGlassString)
        {
            int heightOfHourGlass;
            bool heightOfHourGlassIsOk = int.TryParse(i_HeightHourGlassString, out heightOfHourGlass);

            if (heightOfHourGlassIsOk == true && heightOfHourGlass > 0)
            {
                if (heightOfHourGlass % 2 == 0)
                {
                    heightOfHourGlass += 1;
                }
            }
            else
            {
                heightOfHourGlass = -1;
            }

            return heightOfHourGlass;
        }
    }
}
