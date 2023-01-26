//  dot net 6.0 without top-level statements

namespace jackpot
{
    internal class Program
    {
        //  цвет консоли
        public static void Print(object a)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(a);
            Console.ResetColor();
        }

        static void Main(string[] args)
        {
            Random uuu = new();

            //int cube1 = uuu.Next(1,128), cube2 = uuu.Next(1, 128), cube3 = uuu.Next(1, 128);
            //int cube1 = 1, cube2 = 1, cube3 = 1;
            int cube1 = uuu.Next(1,128), cube2 = uuu.Next(1,128), cube3 = uuu.Next(1,128);

            //  вероятность
            double probability = -1.0f;

            //  3 одинаковых
            if (cube1== cube2 && cube2==cube3 && cube1==cube3)
            {
                probability = 1 / (Math.Pow(128, 2));
            }
            //  2 одинаковых
            else if(cube1==cube2 | cube1==cube3 | cube2==cube3)
            {
                probability = (3*(128*128-128)+128) / Math.Pow(128,3);
            }
            //  один
            else
            {
                probability = 1;
            }

            Console.WriteLine($"on table: {cube1} {cube2} {cube3}");
            Print($"probability: {probability:F10}");
        }
    }
}