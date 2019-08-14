/******************************************************************************
Module:  Ch20-1-ExceptionHandling.cs
Notices: Copyright (c) 2013 Jeffrey Richter
******************************************************************************/

#if !DEBUG
#pragma warning disable 1058
#endif

public static class Program {
   public static void Main() {
     //Mechanics.SomeMethod();
     //GenericException.Go();
      OneStatementDemo.Go();
      CodeContracts.Go();
      UnhandledException.Go();
      ConstrainedExecutionRegion.Go();
   }
}

//////////////////////////////// End of File //////////////////////////////////
