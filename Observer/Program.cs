using System;
using System.Collections.Generic;

namespace Observer.GOF
{
    public abstract class AbstractOberserver
    {
        public abstract void Update();
    }

    public abstract class AbstractSubject
    {
        public List<AbstractOberserver> _observers = new List<AbstractOberserver>();

        public void Register(AbstractOberserver observer)
        {
            _observers.Add(observer);
        }

        public void Unregister(AbstractOberserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
    }

    public class WeatherSubject : AbstractSubject
    {
        private double _temperature;
        public double Temperature
        {
            get { return _temperature; }
            set
            {
                _temperature = value;
                Notify();
            }
        }

        private double _windSpeed;
        public double WindSpeed
        {
            get { return _windSpeed; }
            set
            {
                _windSpeed = value;
                Notify();
            }
        }
    }

    public class WindSpeedObserver : AbstractOberserver
    {
        private readonly WeatherSubject _dataSource;

        public WindSpeedObserver(WeatherSubject dataSource)
        {
            _dataSource = dataSource;
            _dataSource.Register(this);
        }

        public override void Update()
        {
            Console.WriteLine($"{this.GetType().Name} observed {_dataSource.WindSpeed}");
        }
    }

    public class TemperatureObserver : AbstractOberserver
    {
        private readonly WeatherSubject _dataSource;

        public TemperatureObserver(WeatherSubject dataSource)
        {
            _dataSource = dataSource;
            _dataSource.Register(this);
        }

        public override void Update()
        {
            Console.WriteLine($"{this.GetType().Name} observed {_dataSource.Temperature}");
        }
    }
}


namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            // My first approach
            var subject = new Observer.FirstTry.Subject();
            var databaseObserver = new Observer.FirstTry.Database();
            var logObserver = new Observer.FirstTry.Log();
            subject.Register(databaseObserver);
            subject.Register(logObserver);

            subject.setAddress("marcocontatopto@gmail.com");
            subject.Unregister(logObserver);
            subject.setTitle("Welcome to the observer pattern");

            // GOF approach
            var weather = new Observer.GOF.WeatherSubject();
            var windObserver = new Observer.GOF.WindSpeedObserver(weather);
            var temperatureObserver = new Observer.GOF.TemperatureObserver(weather);
            weather.Temperature = 33.4;
            weather.WindSpeed = 12.3;

            //dotnet events and delegates approach
            var weather2 = new WithEventsAndDelegates.WeatherSubject();
            var windObserver2 = new WithEventsAndDelegates.WindSpeedObserver(weather2);
            var temperatureObserver2 = new WithEventsAndDelegates.TemperatureObserver(weather2);
            weather2.Temperature = 55.3;
            weather2.WindSpeed = 9.2;
        }
    }
}
