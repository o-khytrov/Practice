//#define CompilerImplementedEventMethods
using System;

public static class Program
{

    public static void Main()
    {
        MailManager.Go();
        TypeWithLotsOfEventsTest();
    }

    private static void TypeWithLotsOfEventsTest()
    {
        // The code here tests the event
        TypeWithLotsOfEvents twle = new TypeWithLotsOfEvents();

        // Add a callback here
        twle.Foo += HandleFooEvent;
        twle.SimulateFoo();
        Console.WriteLine("The callback was invoked 1 time above" + Environment.NewLine);

        // Add another callback here
        twle.Foo += HandleFooEvent;
        twle.SimulateFoo();
        Console.WriteLine("The callback was invoked 2 times above" + Environment.NewLine);

        // Remove a callback here
        twle.Foo -= HandleFooEvent;
        twle.SimulateFoo();
        Console.WriteLine("The callback was invoked 1 time above" + Environment.NewLine);

        // Remove another callback here
        twle.Foo -= HandleFooEvent;
        twle.SimulateFoo();
        Console.WriteLine("The callback was invoked 0 times above" + Environment.NewLine);

        Console.WriteLine("Press <Enter> to terminate this application.");
        Console.ReadLine();
    }

    private static void HandleFooEvent(object sender, FooEventArgs e)
    {
        Console.WriteLine("Handling Foo Event here...");
    }
}

//////////////////////////////// End of File //////////////////////////////////
