using System;

namespace ScratchDelegateEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Animal();

            //This does NOT fire the event, as we are not subscribed to the event. (aka, we do not have a method that will fire when the event if fired.
            a.Name = "Timmy";

            //here we subscribe to the event.
            a.NameChangeEvent += NameChangeOccured;

            //this change will cause the name change to fire
            a.Name = "Doom";

            //unsub from the event
            a.NameChangeEvent -= NameChangeOccured;

            //This change will NOT cause the event to fire, as we are unsubscribed.
            a.Name = "Something";

            Console.WriteLine("All done. Press any key to escape...");
            Console.ReadLine();
        }

        //this is the method that will be called whrn the NameChangeEvent fires.
        public static void NameChangeOccured(object change, NameChangeEventArgs args)
        {
            Console.WriteLine($"The animal's name changed from {args.OldName} to {args.NewName}");
        }
    }
}
