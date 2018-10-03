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
            var rawdata = System.IO.File.ReadAllText("SampleData.json");
            carList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Car>>(rawdata);
        }

        public List<Car> getNewestVehiclesInOrder()
        {
            return carList.OrderByDescending(l => l.Year).ToList();
        }
        public List<Car> getalphabetizedr()
        {
            return carList.OrderBy(l => l.Model).ToList();
        }
        public List<Car> getOrderByPrice()
        {
            return carList.OrderBy(l => l.Price).ToList();
        }
        public Car getBestValue()
        {
            return carList.OrderByDescending(l => l.TCCRating).FirstOrDefault();
        }
        public Dictionary<string, decimal> getFuleConsumption(decimal distance)
        {
            Dictionary<string, decimal> dict = new Dictionary<string, decimal>();
            carList.ForEach(l => dict.Add(l.Model, distance / l.HwyMPG));
            return dict;
        }
        public Car getRandomCar()
        {
            Random rd = new Random();
            int index = rd.Next(0, 5);
            return carList[index];
        }
        public decimal averageMPGByYear(int year)
        {
            return carList.Where(l => l.Year == year).Average(l => l.HwyMPG);
        }
    }
}

