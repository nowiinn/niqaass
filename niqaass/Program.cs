using System;

namespace niqaass
{
    class Program
    {
        const int ARRAY_SIZE = 10;

      
        static void PrintTop()
        {
            Console.Write("╔");
            for (int i = 0; i < 40; i++) Console.Write("═");
            Console.WriteLine("╗");
        }

        static void PrintSeparator()
        {
            Console.Write("╠");
            for (int i = 0; i < 40; i++) Console.Write("═");
            Console.WriteLine("╣");
        }

        static void PrintBottom()
        {
            Console.Write("╚");
            for (int i = 0; i < 40; i++) Console.Write("═");
            Console.WriteLine("╝");
        }

        static void PrintMenu()
        {
            PrintTop();
            Console.WriteLine("║               MAIN MENU                ║");
            PrintSeparator();
            Console.WriteLine("║ 1. Selection Sort                      ║");
            Console.WriteLine("║ 2. Insertion Sort                      ║");
            Console.WriteLine("║ 3. Bubble Sort                         ║");
            Console.WriteLine("║ 4. Exit                                ║");
            PrintBottom();
        }

        
        static void Main(string[] args)
        {
            while (true)
            {
                PrintMenu();

                Console.Write("Enter Choice: ");
                string choice = Console.ReadLine()!;

                if (choice == "4")
                {
                    Console.WriteLine("\nExiting program. Goodbye!");
                    break;
                }

                if (choice != "1" && choice != "2" && choice != "3")
                {
                    Console.WriteLine("Invalid choice! Press Enter to try again.");
                    Console.ReadLine();
                    continue;
                }

                int[] numbers = new int[ARRAY_SIZE];



                for (int i = 0; i < ARRAY_SIZE; i++)
                {
                    Console.Write($"Number {i + 1}: ");
                    while (!int.TryParse(Console.ReadLine(), out numbers[i]))
                    {
                        Console.WriteLine("Invalid input! Please enter a number.");
                        Console.Write($"Number {i + 1}: ");
                    }
                }

                int[] sortedArray = (int[])numbers.Clone();

                switch (choice)
                {
                    case "1":
                        SelectionSort(sortedArray);
                        Console.WriteLine("\nSelection Sort Result:");
                        break;

                    case "2":
                        InsertionSort(sortedArray);
                        Console.WriteLine("\nInsertion Sort Result:");
                        break;

                    case "3":
                        BubbleSort(sortedArray);
                        Console.WriteLine("\nBubble Sort Result:");
                        break;
                }

                DisplayArray(sortedArray);

                Console.WriteLine("\nPress Enter to return to menu...");
                Console.ReadLine();
            }
        }

        // ===== SORTING METHODS =====
        static void SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < arr.Length; j++)
                    if (arr[j] < arr[minIndex])
                        minIndex = j;

                int temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
            }
        }

        static void InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int key = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = key;
            }
        }

        static void BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
                for (int j = 0; j < arr.Length - i - 1; j++)
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
        }

        // ===== DISPLAY =====
        static void DisplayArray(int[] arr)
        {

            foreach (int num in arr)
                Console.Write(num + " ");

            Console.WriteLine();
        }
    }
}