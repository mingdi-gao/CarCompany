using CarDAL;
using CarModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCompany
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Loading Data......");
            CarDal carManager = new CarDal();
            carManager.loadData();
            Console.WriteLine("Sample data loaded succesfully!");
          
            while (true)
            {
                List<Car> results = new List<Car>();
                Car result = new Car();
                decimal distance = 0;
                
                ShowMenu();
                string command = Console.ReadLine();
                switch (command.ToUpper())
                {
                    case "1":
                        results = carManager.getNewestVehiclesInOrder();
                        displayResults(results);
                        break;
                    case "2":
                        results = carManager.getalphabetizedr();
                        displayResults(results);
                        break;
                    case "3":
                        results = carManager.getOrderByPrice();
                        displayResults(results);
                        break;
                    case "4":
                        result = carManager.getBestValue();
                        displaySingleResult(result);
                        break;
                    case "5":
                        Console.WriteLine("Enter the distance");
                        distance = Convert.ToInt32(Console.ReadLine());
                        var fuleConsumptions = carManager.getFuleConsumption(distance);
                        displayFuelConsumption(fuleConsumptions);
                        break;
                    case "6":
                        result = carManager.getRandomCar();
                        displaySingleResult(result);
                        break;
                    case "7":
                        Console.WriteLine("Enter the year(2016 or 2017)");
                        int year = Convert.ToInt32(Console.ReadLine());
                        var avgMPG = carManager.averageMPGByYear(year);
                        displayAvgMPG(avgMPG, year);
                        break;
                    case "Q":
                        Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Invalid Command");
                        break;
                }
            }

        }

        public static void ShowMenu()
        {

            Console.WriteLine();

            Console.WriteLine("1 - Calculate the newest vehicles in order");
            Console.WriteLine("2 - Calculate an alphabetized List of vehicles");
            Console.WriteLine("3 - Calculate an ordered List of Vehicles by Price");
            Console.WriteLine("4 - Calculate the best value");
            Console.WriteLine("5 - Calculate fuel consumption for a given distance");
            Console.WriteLine("6 - Return a random car from the list");
            Console.WriteLine("7 - Return average MPG by year");
            Console.WriteLine("Q - Quit");
            Console.WriteLine();
            Console.WriteLine("Enter your command(1~7) or Press 'Q' to exit:");
        }

        public static void displayResults(List<Car> resultCollection)
        {
            Console.WriteLine();
            Console.WriteLine("Make   Model   Color    Year    Price   TCCRating   HwyMPG");
            foreach (var c in resultCollection)
            {
                Console.WriteLine(c.Make + "   " + 
                    c.Model + "   " + 
                    c.Color + "   " + 
                    c.Year + "   " + 
                    c.Price + "    " + 
                    c.TCCRating + "    " + 
                    c.HwyMPG);
            }
        }

        public static void displaySingleResult(Car c)
        {
            Console.WriteLine();
            Console.WriteLine("Make   Model   Color    Year    Price   TCCRating   HwyMPG");
            Console.WriteLine(c.Make + "   " +
                    c.Model + "   " +
                    c.Color + "   " +
                    c.Year + "   " +
                    c.Price + "    " +
                    c.TCCRating + "    " +
                    c.HwyMPG);

        }

        public static void displayFuelConsumption(Dictionary<string, decimal> carDic)
        {
            Console.WriteLine();
            Console.WriteLine("Model  FuelConsumption");
            foreach(var c in carDic)
            {
                Console.WriteLine(c.Key + "  " + c.Value);
            }

        }

        public static void displayAvgMPG(decimal avgMPG, int year)
        {
            Console.WriteLine();
            Console.WriteLine("Year    avgMPG");
            Console.WriteLine(year + " " + avgMPG);
        }
    }
}
