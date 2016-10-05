using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicoYPlacaPredictor
{
    class Program
    {
        static void Main(string[] args)
        {
            string plate;
            string date;
            string time;

            Console.WriteLine("Hello, welcome to 'Pico y Placa' Predictor");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Please, enter the folowing information and get your prediction");
            
            Console.WriteLine("Enter your full plate (CAR: PCB-3049, MOTORCICLE: HS888P): ");
            plate = Console.ReadLine();
            Console.WriteLine("Enter date (2016-10-05): ");
            date = Console.ReadLine();
            Console.WriteLine("Enter Time (10:45): ");
            time = Console.ReadLine();

            Predictor p = new Predictor(date, time, plate);
            
            if (p.CanCarRoad())
                Console.WriteLine("Car can road!");
            else
                Console.WriteLine("Car can not road!");
        }
    }
}
