using System;
using System.Collections.Generic;

namespace Observer.FirstTry
{
    public interface ISubject<T>
    {
        void Register(IObserver<T> observer);
        void Unregister(IObserver<T> observer);
        void Notify();
    };

    public interface IObserver<T>
    {
        void Apply(T subject);
    }

    public struct EmailData
    {
        public string Address { get; set; }
        public string Title { get; set; }
    }


    public class Subject : ISubject<EmailData>
    {
        private EmailData _emailData = new EmailData();
        private List<IObserver<EmailData>> _observers = new List<IObserver<EmailData>>();

        public void Register(IObserver<EmailData> observer)
        {
            _observers.Add(observer);
        }

        public void Unregister(IObserver<EmailData> observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Apply(_emailData);
            }
        }

        public void setAddress(string address)
        {
            _emailData.Address = address;
            Notify();
        }

        public void setTitle(string title)
        {
            _emailData.Title = title;
            Notify();
        }
    }

    public class Log : IObserver<EmailData>
    {
        public void Apply(EmailData subject)
        {
            Console.WriteLine($"{this.GetType().Name} has been notified");
            Console.WriteLine(subject.Address);
            Console.WriteLine(subject.Title);
        }
    }

    public class Database : IObserver<EmailData>
    {
        public void Apply(EmailData subject)
        {
            Console.WriteLine($"{this.GetType().Name} has been notified");
            Console.WriteLine(subject.Address);
            Console.WriteLine(subject.Title);
        }
    }

}
