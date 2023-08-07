namespace CovarianceAndContravarianceDelagateExample
{
    //Variance delegate
    delegate Car CarFactoryDel(int id, string name);
    //Contravariance delegate
    delegate void LogICECarDetailsDel(ICECar iCECar);
    delegate void LogEVCarDetailsDel(EVCar eVCar);
    class Program
    {
        static void Main(string[] args)
        {
            //VARIANCE DELEGATE

            Console.WriteLine("VARIANCE DELEGATE BEGIN HERE");
            Console.WriteLine(new string('*', "VARIANCE DELEGATE BEGIN HERE".Length));
            CarFactoryDel carFactoryDel = CarFactory.ReturnICECar;
            
            Car iceCar = carFactoryDel(1, "Audi R8");

            Console.WriteLine($"Object type: {iceCar.GetType()}");
            Console.WriteLine($"Car details: {iceCar.GetCarDetails()}");

            carFactoryDel = CarFactory.ReturnEVCar;
            Car evCar = carFactoryDel(2, "Tesla Model-3");
            Console.WriteLine();
            Console.WriteLine($"Object type: {evCar.GetType()}");
            Console.WriteLine($"Car details: {evCar.GetCarDetails()}");
            //Console.ReadKey();

            Console.WriteLine(new string('*', "VARIANCE DELEGATE END HERE".Length));
            Console.WriteLine("VARIANCE DELEGATE END HERE");
            Console.WriteLine(); Console.WriteLine();
            Console.WriteLine("CONTRAVARIANCE DELEGATE BEGIN HERE");
            Console.WriteLine(new string('*', "CONTRAVARIANCE DELEGATE BEGIN HERE".Length));
            //CONTRAVARIANCE DELEGATE
            LogICECarDetailsDel logICECarDetailsDel = LogCarDetails;
            logICECarDetailsDel(iceCar as ICECar);

            LogEVCarDetailsDel logEVCarDetailsDel = LogCarDetails;
            logEVCarDetailsDel(evCar as EVCar);
            Console.WriteLine(new string('*', "CONTRAVARIANCE DELEGATE END HERE".Length));
            Console.WriteLine("CONTRAVARIANCE DELEGATE END HERE");
            Console.ReadKey();
        }

        static void LogCarDetails(Car car)
        {
            if(car is ICECar)
            {
                using(StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ICEDeatails.txt"), true))
                {
                    sw.WriteLine($"Object type: {car.GetType()}");
                    sw.WriteLine($"Car details: {car.GetCarDetails()}");
                }
            }
            else if(car is EVCar)
            {
                Console.WriteLine($"Object type: {car.GetType()}");
                Console.WriteLine($"Car details: {car.GetCarDetails()}");
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
    }

    public static class CarFactory
    {
        public static ICECar ReturnICECar(int id, string name)
        {
            return new ICECar { Id = id, Name = name };
        }
        public static EVCar ReturnEVCar(int id, string name)
        {
            return new EVCar { Id = id, Name = name };
        }
    }

    public abstract class  Car
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual string GetCarDetails()
        {
            return $"{Id} - {Name}";
        }
    }

    public class ICECar: Car
    {
        public override string GetCarDetails()
        {
            return $"{base.GetCarDetails()} - Internal Combustion Engine";
        }
    }

    public class EVCar : Car
    {
        public override string GetCarDetails()
        {
            return $"{base.GetCarDetails()} - Electric";
        }
    }
}