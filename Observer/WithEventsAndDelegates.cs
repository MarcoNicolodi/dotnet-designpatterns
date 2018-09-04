using System;

namespace Observer.WithEventsAndDelegates
{
    public class WindSpeedChangedEventArgs : EventArgs
    {
        public WindSpeedChangedEventArgs(double windSpeed)
        {
            WindSpeed = windSpeed;
        }

        public double WindSpeed { get; }
    }

    public class TemperatureChangedEventArgs : EventArgs
    {
        public TemperatureChangedEventArgs(double temperature)
        {
            Temperature = temperature;
        }

        public double Temperature { get; }
    }

    public class WeatherSubject
    {
        private double _temperature;
        public double Temperature
        {
            get { return _temperature; }
            set
            {
                _temperature = value;
                OnTemperatureChanged(new TemperatureChangedEventArgs(_temperature));
            }
        }

        private double _windSpeed;
        public double WindSpeed
        {
            get { return _windSpeed; }
            set
            {
                _windSpeed = value;
                OnWindSpeedChange(new WindSpeedChangedEventArgs(_windSpeed));
            }
        }

        public event EventHandler<WindSpeedChangedEventArgs> WindSpeedChanged;
        public event EventHandler<TemperatureChangedEventArgs> TemperatureChanged;

        protected virtual void OnWindSpeedChange(WindSpeedChangedEventArgs args)
        {
            if (WindSpeedChanged != null)
            {
                WindSpeedChanged(this, args);
            }
        }

        protected virtual void OnTemperatureChanged(TemperatureChangedEventArgs e)
        {
            if (TemperatureChanged != null)
            {
                TemperatureChanged(this, e);
            }
        }
    }

    public class TemperatureObserver
    {
        public TemperatureObserver(WeatherSubject subject)
        {
            subject.TemperatureChanged += TemperatureChangeHandler;
        }

        protected void TemperatureChangeHandler(object sender, TemperatureChangedEventArgs args)
        {
            Console.WriteLine($"{this.GetType().Name} observed {args.Temperature}");
        }
    }

    public class WindSpeedObserver
    {
        public WindSpeedObserver(WeatherSubject subject)
        {
            subject.WindSpeedChanged += WindSpeedChangeHandler;
        }

        protected void WindSpeedChangeHandler(object sender, WindSpeedChangedEventArgs args)
        {
            Console.WriteLine($"{this.GetType().Name} observed {args.WindSpeed}");
        }
    }
}