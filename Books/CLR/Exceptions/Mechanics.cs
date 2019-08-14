/******************************************************************************
Module:  Ch20-1-ExceptionHandling.cs
Notices: Copyright (c) 2013 Jeffrey Richter
******************************************************************************/

#if !DEBUG
#pragma warning disable 1058
#endif
using System;
using System.IO;

internal static class Mechanics {
   public static void SomeMethod() {
      try {
         // Put code requiring graceful recovery and/or cleanup operations here...
      }
      catch (InvalidOperationException) {
         // Put code that recovers from an InvalidOperationException here...
      }
      catch (IOException) {
         // Put code that recovers from an IOException here...
      }
      catch (Exception) {
         // Before C# 2.0, this block catches CLS-compliant exceptions only 
         // In C# 2.0, this block catches CLS- & non-CLS- compliant exceptions 
         throw; // Re-throws whatever got caught 
      }
      catch {
         // In all versions of C#, this block catches CLS- & non-CLS- compliant exceptions 
         throw; // Re-throws whatever got caught 
      }
      finally {
         // Put code that cleans up any operations started within the try block here...
         // The code in this block ALWAYS executes, regardless of whether an exception is thrown. 
      }
      // Code below the finally block executes if no exception is thrown within the try block
      // or if a catch block catches the exception and doesn't throw or re-throw an exception. 
   }
}

//////////////////////////////// End of File //////////////////////////////////
