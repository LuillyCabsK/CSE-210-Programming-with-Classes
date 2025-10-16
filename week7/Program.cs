using System;
using System.Collections.Generic;

namespace PokemonZaAndSas
{
    class Program
    {
        private static List<Activity> activities = new List<Activity>();
        private static string userName = "";
        private static bool useKilometers = true;

        static void Main(string[] args)
        {
            ShowWelcomeScreen();
            GetUserPreferences();
            ShowMainMenu();
        }

        static void ShowWelcomeScreen()
        {
            Console.Clear();
            Console.WriteLine("================================================");
            Console.WriteLine("      WELCOME TO POKEMON ZA & SAS GYM");
            Console.WriteLine("          Exercise Tracking System");
            Console.WriteLine("================================================");
            Console.WriteLine();
        }

        static void GetUserPreferences()
        {
            Console.Write("Please enter your name: ");
            userName = Console.ReadLine();

            Console.WriteLine("\nPlease choose your preferred unit system:");
            Console.WriteLine("1. Kilometers (km)");
            Console.WriteLine("2. Miles (miles)");
            Console.Write("Enter your choice (1-2): ");
            
            string unitChoice = Console.ReadLine();
            useKilometers = (unitChoice == "1");
            
            Console.WriteLine($"\nWelcome {userName}! You have selected: {(useKilometers ? "Kilometers" : "Miles")}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void ShowMainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("================================================");
                Console.WriteLine($"    POKEMON ZA & SAS GYM - Welcome {userName}!");
                Console.WriteLine("            Exercise Tracking Menu");
                Console.WriteLine("================================================");
                Console.WriteLine($"Unit System: {(useKilometers ? "Kilometers" : "Miles")}");
                Console.WriteLine();
                Console.WriteLine("1. Add Running Activity");
                Console.WriteLine("2. Add Cycling Activity");
                Console.WriteLine("3. Add Swimming Activity");
                Console.WriteLine("4. View All Activities");
                Console.WriteLine("5. Exit");
                Console.WriteLine();
                Console.Write("Please choose an option (1-5): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddRunningActivity();
                        break;
                    case "2":
                        AddCyclingActivity();
                        break;
                    case "3":
                        AddSwimmingActivity();
                        break;
                    case "4":
                        ViewAllActivities();
                        break;
                    case "5":
                        Console.WriteLine("\nThank you for using Pokemon Za & Sas Gym Tracking System!");
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("\nInvalid choice. Please try again.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void AddRunningActivity()
        {
            Console.Clear();
            Console.WriteLine("ADD RUNNING ACTIVITY");
            Console.WriteLine("====================");

            DateTime date = GetDate();
            int minutes = GetActivityLength();
            double distance = GetDistance("running");

            Running running = new Running(date, minutes, distance, userName, useKilometers);
            activities.Add(running);

            Console.WriteLine($"\nRunning activity added successfully!");
            Console.WriteLine(running.GetSummary());
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        static void AddCyclingActivity()
        {
            Console.Clear();
            Console.WriteLine("ADD CYCLING ACTIVITY");
            Console.WriteLine("====================");

            DateTime date = GetDate();
            int minutes = GetActivityLength();
            double speed = GetSpeed();

            Cycling cycling = new Cycling(date, minutes, speed, userName, useKilometers);
            activities.Add(cycling);

            Console.WriteLine($"\nCycling activity added successfully!");
            Console.WriteLine(cycling.GetSummary());
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        static void AddSwimmingActivity()
        {
            Console.Clear();
            Console.WriteLine("ADD SWIMMING ACTIVITY");
            Console.WriteLine("=====================");

            DateTime date = GetDate();
            int minutes = GetActivityLength();
            int laps = GetLaps();

            Swimming swimming = new Swimming(date, minutes, laps, userName, useKilometers);
            activities.Add(swimming);

            Console.WriteLine($"\nSwimming activity added successfully!");
            Console.WriteLine(swimming.GetSummary());
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        static DateTime GetDate()
        {
            DateTime date;
            while (true)
            {
                Console.Write("Enter date (MM/DD/YYYY) or press Enter for today: ");
                string dateInput = Console.ReadLine();
                
                if (string.IsNullOrEmpty(dateInput))
                {
                    date = DateTime.Today;
                    break;
                }
                
                if (DateTime.TryParse(dateInput, out date))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid date format. Please try again.");
                }
            }
            return date;
        }

        static int GetActivityLength()
        {
            int minutes;
            while (true)
            {
                Console.Write("Enter activity length in minutes: ");
                if (int.TryParse(Console.ReadLine(), out minutes) && minutes > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid positive number.");
                }
            }
            return minutes;
        }

        static double GetDistance(string activityType)
        {
            double distance;
            string unit = useKilometers ? "km" : "miles";
            
            while (true)
            {
                Console.Write($"Enter {activityType} distance in {unit}: ");
                if (double.TryParse(Console.ReadLine(), out distance) && distance > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid positive number.");
                }
            }
            return distance;
        }

        static double GetSpeed()
        {
            double speed;
            string unit = useKilometers ? "kph" : "mph";
            
            while (true)
            {
                Console.Write($"Enter average speed in {unit}: ");
                if (double.TryParse(Console.ReadLine(), out speed) && speed > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid positive number.");
                }
            }
            return speed;
        }

        static int GetLaps()
        {
            int laps;
            while (true)
            {
                Console.Write("Enter number of laps (50 meters per lap): ");
                if (int.TryParse(Console.ReadLine(), out laps) && laps > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid positive number.");
                }
            }
            return laps;
        }

        static void ViewAllActivities()
        {
            Console.Clear();
            Console.WriteLine("ALL ACTIVITIES SUMMARY");
            Console.WriteLine("======================");
            Console.WriteLine();

            if (activities.Count == 0)
            {
                Console.WriteLine("No activities recorded yet.");
            }
            else
            {
                foreach (Activity activity in activities)
                {
                    Console.WriteLine(activity.GetSummary());
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}