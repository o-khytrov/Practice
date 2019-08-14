/******************************************************************************
Module:  Ch20-1-ExceptionHandling.cs
Notices: Copyright (c) 2013 Jeffrey Richter
******************************************************************************/

#if !DEBUG
#pragma warning disable 1058
#endif
using System;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Threading;

internal static class ConstrainedExecutionRegion {
   public static void Go() {
      ExecuteCodeWithGuaranteedCleanupDemo(false);
      ExecuteCodeWithGuaranteedCleanupDemo(true);
      Demo1();
      Demo2();
   }

   private static void Demo1() {
      Console.WriteLine("In Demo1");
      try {
         Console.WriteLine("In try");
      }
      finally {
         // Type1’s static constructor is implicitly called in here
         Type1.M();
      }
   }

   private sealed class Type1 {
      static Type1() {
         // if this throws an exception, M won’t get called
         Console.WriteLine("Type1's static ctor called");
      }

      public static void M() { }
   }

   private static void Demo2() {
      Console.WriteLine("In Demo2");
      // Force the code in the finally to be eagerly prepared
      RuntimeHelpers.PrepareConstrainedRegions();  // In the System.Runtime.CompilerServices namespace
      try {
         Console.WriteLine("In try");
      }
      finally {
         // Type2’s static constructor is implicitly called in here
         Type2.M();
      }
   }

   public class Type2 {
      static Type2() {
         Console.WriteLine("Type2's static ctor called");
      }

      [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
      public static void M() { }
   }

   private static readonly Object s_myLock = new Object();
   private static void ExecuteCodeWithGuaranteedCleanupDemo(Boolean test) {
      Thread t = new Thread(ThreadFunc);
      t.Start(test);
      Thread.Sleep(2000);
      t.Abort();
      ThreadFunc(false); // Deadlock
   }

   private static void ThreadFunc(Object o) {
      Boolean taken = true;
      if ((Boolean)o) {
         Monitor.Enter(s_myLock/*, ref taken*/);
         Thread.Sleep(10000);
         if (taken) Monitor.Exit(s_myLock);
      } else {
         RuntimeHelpers.ExecuteCodeWithGuaranteedCleanup(
            userData => { Monitor.Enter(s_myLock/*, ref taken*/); Thread.Sleep(10000); },
            (userData, exceptionThrown) => { if (taken) Monitor.Exit(s_myLock); }, null);
      }
   }
}

//////////////////////////////// End of File //////////////////////////////////
