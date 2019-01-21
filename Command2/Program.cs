using System;

namespace Command2
{
    public interface ICommand
    {
        void Execute();
    }

    public class SmsSender
    {
        public void SendSms()
        {
            Console.WriteLine("Sending sms");
        }

        public void ConfigureSms()
        {
            //method of the receiver that the command has nothing to do
        }
    }

    public class Sms : ICommand
    {
        private readonly SmsSender _sender;

        public Sms(SmsSender sender)
        {
            _sender = sender;
        }

        public void Execute()
        {
            _sender.SendSms();
        }
    }

    public class PushNotificationSender
    {
        public void SendPushNotification()
        {
            Console.WriteLine("Sending push notification");
        }

        public void Authorize()
        {
            //receiver's method that the command has nothing to do
        }
    }

    public class PushNotification : ICommand
    {
        private readonly PushNotificationSender _sender;

        public PushNotification(PushNotificationSender _sender)
        {
            _sender = sender;
        }

        public void Execute()
        {
            _sender.SendPushNotification();
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            var queue = new List<ICommand>();
                    
        }
    }
}
