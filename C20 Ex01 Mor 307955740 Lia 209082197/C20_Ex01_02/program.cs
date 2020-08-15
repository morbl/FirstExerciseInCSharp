using System;
using System.Text;


namespace C20_Ex01_02
{
    public class Program
    {
        public const int k_HeightOfClock = 5;
        public const int k_NumberOfOffset = 0;
        public const char k_Asterisk = '*';

        public static void Main()
        {
            PrintBeginnerHourGlassInMain();
        }

        //function that calls to the recursion that prints beginner HourGlass
        public static void PrintBeginnerHourGlassInMain()
        {
            StringBuilder hourGlassClock = PrintHourGlassRecursion(k_HeightOfClock, k_NumberOfOffset);
            Console.WriteLine(hourGlassClock);
        }

        //function print hour glass clock in height 5
        public static StringBuilder PrintHourGlassRecursion(int i_HeightOfClock, int i_NumberOfOffset)
        {
            StringBuilder hourGlassClockAsterisk = new StringBuilder();

            if (i_HeightOfClock > 0)
            {
                for (int i = 0; i < i_NumberOfOffset; i++)
                {
                    hourGlassClockAsterisk.Append(" ");
                }

                for (int i = 0; i < i_HeightOfClock; i++)
                {
                    hourGlassClockAsterisk.Append(k_Asterisk);
                }

                hourGlassClockAsterisk.Append(@"
");

                hourGlassClockAsterisk.Append(PrintHourGlassRecursion(i_HeightOfClock - 2, i_NumberOfOffset + 1));

                if (i_HeightOfClock > 1)
                {
                    for (int i = 0; i < i_NumberOfOffset; i++)
                    {
                        hourGlassClockAsterisk.Append(" ");
                    }

                    for (int i = 0; i < i_HeightOfClock; i++)
                    {
                        hourGlassClockAsterisk.Append(k_Asterisk);
                    }

                    hourGlassClockAsterisk.Append("\n");
                }
            }

            return hourGlassClockAsterisk;
        }
    }
}
