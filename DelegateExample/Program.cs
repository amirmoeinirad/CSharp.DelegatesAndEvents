
// Amir Moeini Rad
// August 14, 2025

// Main Concept: Defining events using delegates in C#.


namespace DelegateExample
{
    // Step 1: Define a delegate
    // This delegate defines the signature for the custom event handler 'NotificationHandler'.
    public delegate void NotificationHandler(string message);



    ///////////////////////////////////////



    // The class that will publish the event
    internal class Publisher
    {
        // Step 2: Declare an event 'OnNotify' based on the custom delegate
        public event NotificationHandler? OnNotify;


        public Publisher()
        {
            Console.WriteLine("Publisher constructor...");
        }


        public void Publish(string message)
        {
            Console.WriteLine("Publisher: " + message);

            // Step 3: Trigger the event
            OnNotify?.Invoke($"\'Message from Publisher: {message}.\'");
        }
    }



    ///////////////////////////////////////



    // The class that will subscribe to the event.
    internal class Subscriber
    {
        public Subscriber()
        {
            Console.WriteLine("Subscriber constructor...");
        }


        // This method matches the delegate signature.
        // Indeed, this method is the event handler.
        public void ShowNotification(string message)
        {
            Console.WriteLine("Subscriber: A message received in the event handler: " + message);
        }
    }



    ///////////////////////////////////////



    // The main program to demonstrate the event handling using delegates.
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Using Delegates to define Event Handlers in C#.NET...");
            Console.WriteLine("-----------------------------------------------------\n");


            Publisher publisher = new Publisher();   // old style to create an instance
            Subscriber subscriber = new();           // new style to create an instance


            // Step 4: Subscribe to the event
            // The event is linked to the event handler.
            // 'OnNotify' is the event, and 'ShowNotification' is the method that will handle the event.
            Console.WriteLine("\nSubscriber is subscribing to the Publisher event.");
            publisher.OnNotify += subscriber.ShowNotification;


            // Step 5: Trigger the event by calling a method.
            // This will automatically invoke the event handler.
            Console.WriteLine();
            publisher.Publish("Hello from the OnNotify event!");


            Console.WriteLine("\nDone");
        }
    }
}
