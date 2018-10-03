using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarModel;


namespace CarDAL
{
    public class CarDal
    {
        private List<Car> carList = new List<Car>();

        public void loadData()
        {
            var rawdata = System.IO.File.ReadAllText(@"..\..\SampleData.json");
            carList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Car>>(rawdata);
        }

        public List<Car> getNewestVehiclesInOrder()
        {
            return carList.OrderByDescending(c => c.Year).ToList();
        }
        public List<Car> getalphabetizedr()
        {
            return carList.OrderBy(c => c.Model).ToList();
        }
        public List<Car> getOrderByPrice()
        {
            return carList.OrderBy(c => c.Price).ToList();
        }
        public Car getBestValue()
        {
            return carList.OrderByDescending(c => c.TCCRating).FirstOrDefault();
        }
        public Dictionary<string, decimal> getFuleConsumption(decimal distance)
        {
            Dictionary<string, decimal> dict = new Dictionary<string, decimal>();
            carList.ForEach(c => dict.Add(c.Model, distance / c.HwyMPG));
            return dict;
        }
        public Car getRandomCar()
        {
            Random random = new Random();
            int index = random.Next(0, 5);
            return carList[index];
        }
        public decimal averageMPGByYear(int year)
        {
            return carList.Where(c => c.Year == year).Average(c => c.HwyMPG);
        }
    }
}

