/******************************************************************************
Module:  Ch20-1-ExceptionHandling.cs
Notices: Copyright (c) 2013 Jeffrey Richter
******************************************************************************/

#if !DEBUG
#pragma warning disable 1058
#endif
using System;
using System.IO;
using System.Linq;
using System.Threading;

internal static class OneStatementDemo {
   public static void Go() {
      var o = OneStatement(new MemoryStream(), 'X');
   }
   private static Object OneStatement(Stream stream, Char charToFind) {
      return (charToFind + ": " + stream.GetType() + String.Empty + (512M + stream.Position))
         .Where(c => c == charToFind).ToArray();
   }

   private static Object s_myLockObject = new Object();
   private static void MonitorWithStateCorruption() {
      Monitor.Enter(s_myLockObject);  // If this throws, did the lock get taken or not? 
      // If it did, then it won’t get released!
      try {
         // Do thread-safe operation here...
      }
      finally {
         Monitor.Exit(s_myLockObject);
      }
   }

   private static void MonitorWithoutStateCorruption() {
      Boolean lockTaken = false;  // Assume the lock was not taken
      try {
         // This works whether an exception is thrown or not! 
         Monitor.Enter(s_myLockObject, ref lockTaken);

         // Do thread-safe operation here...
      }
      finally {
         // If the lock was taken, release it
         if (lockTaken) Monitor.Exit(s_myLockObject);
      }
   }
}

//////////////////////////////// End of File //////////////////////////////////
