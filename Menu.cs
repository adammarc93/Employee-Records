using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Records
{
    static class Menu
    {
        static string pathSellerData = @"..\..\data\SellerData.txt";
        static string pathDriverData = @"..\..\data\DriverData.txt";
        static string pathSellerResultData = @"..\..\data\SellerResultData.txt";
        static string pathDriverResultData = @"..\..\data\DriverResultData.txt";

        public static void StartMenu()
        {
            Console.Title = "Employee Records";
            //Console.SetBufferSize(80, 1000);
            Console.SetWindowSize(80, 15);

            while (true)
            {
                int row = 5;
                int col = 20;

                Console.Clear();
                Console.CursorVisible = false;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.SetCursorPosition(25, 1);
                Console.Write(">>> Employee Records <<<");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(col, row++);
                Console.Write("1 - Read and count drivers data");
                Console.SetCursorPosition(col, row++);
                Console.Write("2 - Read and count sellers data");
                Console.SetCursorPosition(col, row++);
                Console.Write("3 - Exit");
                Console.ForegroundColor = ConsoleColor.White;

                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        ReadDrivers();
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        ReadSellers();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.Escape:
                        Console.Clear();
                        return;
                    default:
                        break;
                }
            }
        }

        static void ReadDrivers()
        {
            WorkersList drivers = new WorkersList(Department.driver);

            drivers.Read(pathDriverData);
            if (drivers.ShowList())
            {
                drivers.Save(pathDriverResultData);
            }
        }

        static void ReadSellers()
        {
            WorkersList sellers = new WorkersList(Department.seller);

            sellers.Read(pathSellerData);
            if (sellers.ShowList())
            {
                sellers.Save(pathSellerResultData);
            }
        }
    }
}