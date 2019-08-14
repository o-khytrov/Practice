/******************************************************************************
Module:  Ch20-1-ExceptionHandling.cs
Notices: Copyright (c) 2013 Jeffrey Richter
******************************************************************************/

#if !DEBUG
#pragma warning disable 1058
#endif
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

internal sealed class UnhandledException {
   public static void Go() {
      //var em = SetErrorMode(ErrorMode.NoGPFaultErrorBox);
      int x = 0;
      x = 100 / x;
      RecurseWithStackCheck();

      Console.Write("Install UE Handler (Y/N)?");
      ConsoleKeyInfo key = Console.ReadKey(false);
      Console.WriteLine();
      Console.Write("UE Handler installed=");
      if (Char.ToUpper(key.KeyChar) == 'Y') {
         // Register our MgdUEFilter callback method with the AppDomain
         // so that it gets called when an unhandled exception occurs.
         AppDomain.CurrentDomain.UnhandledException +=
            new UnhandledExceptionEventHandler(MgdUEFilter);
         Console.WriteLine(true);
      } else Console.WriteLine(false);

      while (true) {
         Console.WriteLine("What kind of UE do you want to force?");
         Console.Write("1=Main, 2=ThreadPool, 3=Manual, 4=Finalizer, 5=Native, 6=WindowsFormWindowProc?");
         key = Console.ReadKey(false);
         Console.WriteLine();

         switch (key.KeyChar) {
            case '1':
               Throw("Main");
               break;

            case '2':
               ThreadPool.QueueUserWorkItem(delegate { Throw("ThreadPool"); });
               break;

            case '3':
               Thread t = new Thread((ThreadStart)delegate { Throw("Manual"); });
               t.Start();
               break;

            case '4':
               new UnhandledException();
               GC.Collect();
               break;

            case '5':
               new NativeThread();
               break;

            case '6':
               Application.Run(new MyForm());
               break;
         }
         Console.ReadLine();
      }
   }

   public enum ErrorMode {
      None = 0x0000,
      FailCriticalErrors = 0x0001,
      NoAlignmentFaultExcept = 0004,
      NoGPFaultErrorBox = 0x0002,
      NoOpenFileErrorBox = 0x8000
   }
   [DllImport("Kernel32", SetLastError = true, ExactSpelling = true)]
   private static extern ErrorMode SetErrorMode(ErrorMode mode);

   private static void RecurseWithStackCheck() {
      try {
         RuntimeHelpers.EnsureSufficientExecutionStack();
         RecurseWithStackCheck();
      }
      catch (Exception e) {
         Console.WriteLine(e.Message);
      }
   }

   private static void Throw(String threadType) {
      throw new InvalidOperationException(
         String.Format("Forced exception in {0} thread.", threadType));
   }

   ~UnhandledException() {
      Throw("Finalize");
   }

   private sealed class MyForm : Form {
      protected override void OnPaint(PaintEventArgs e) {
         Throw("Windows Form Window Procedure");
      }
   }


   private static void MgdUEFilter(Object sender, UnhandledExceptionEventArgs e) {
      // This string contains the info to display or log
      String info;
      Console.WriteLine("MgdUEFilter");

      // Initialize the contents of the string
      Exception ex = e.ExceptionObject as Exception;
      if (ex != null) {
         // An unhandled CLS-Compliant exception was thrown
         // Do whatever: you can access the fields of Exception
         // (Message, StackTrace, HelpLink, InnerException, etc.)
         info = ex.ToString();
      } else {
         // An unhandled non-CLS-Compliant exception was thrown
         // Do whatever: all you can call are the methods defined by Object
         // (ToString, GetType, etc.)
         info = String.Format("Non-CLS-Compliant exception: Type={0}, String={1}",
            e.ExceptionObject.GetType(), e.ExceptionObject.ToString());
      }

#if DEBUG
      // For DEBUG builds of the application, launch the debugger
      // to understand what happened and to fix it.
      if (!e.IsTerminating) {
         // Unhandled exception occurred in a thread pool or finalizer thread
         Debugger.Launch();
      } else {
         // Unhandled exception occurred in a managed thread
         // By default, the CLR will automatically attach a debugger but
         // we can force it with the line below:
         Debugger.Launch();
      }
#else
      // For RELEASE builds of the application, display or log the exception
      // so that the end-user can report it back to us.
      if (!e.IsTerminating) {
         // Unhandled exception occurred in a thread pool or finalizer thread
         // For thread pool or finalizer threads, you might just log the exception
         // and not display the problem to the user. However, each application
         // should do whatever makes the most sense.
      } else {
         // Unhandled exception occurred in a managed thread
         // The CLR is going to kill the application, you should display and/or 
         // log the exception.
      }
#endif

      Console.WriteLine("Catching an unhandled Exception:");
      Console.WriteLine(e.ExceptionObject);
      Console.WriteLine("IsTerminating: " + e.IsTerminating);
      Console.ReadLine();
      //if (!Debugger.IsAttached) Debugger.Launch();
   }

   private sealed class NativeThread {
      public static void SetUnhandledExceptionFilter() {
         SetUnhandledExceptionFilter(TLEF);
      }

      private delegate ExceptionFilterDisposition TopLevelExceptionFilter(UIntPtr exceptionPointers);
      private enum ExceptionFilterDisposition {
         ExecuteHandler = 1,
         ContinueSearch = 0,
         ContinueExecution = -1
      }
      [DllImport("Kernel32")]
      private static extern UIntPtr SetUnhandledExceptionFilter(TopLevelExceptionFilter filter);
      private static ExceptionFilterDisposition TLEF(UIntPtr ep) {
         Console.WriteLine("TopLevelExceptionFilter");
         return ExceptionFilterDisposition.ContinueSearch;
      }


      public NativeThread() {
         UInt32 threadId;
         IntPtr hThread = CreateThread(IntPtr.Zero, 0,
            new ThreadStartRoutine(UnmgdThreadFunc), UIntPtr.Zero, 0, out threadId);
         CloseHandle(hThread);
      }

      public delegate void ThreadStartRoutine(UIntPtr ThreadParameter);

      [DllImport("Kernel32")]
      public static extern IntPtr CreateThread(IntPtr SecurityAttributes, UInt32 StackSize,
         ThreadStartRoutine StartFunction, UIntPtr ThreadParameter,
         UInt32 CreationFlags, out UInt32 ThreadId);

      [DllImport("Kernel32")]
      private static extern Boolean CloseHandle(IntPtr handle);

      private static void UnmgdThreadFunc(UIntPtr p) {
         Console.WriteLine("In UnmgdThreadFunc");
         Int32 x = 0;
         x = 10 / x;
      }
   }
}

//////////////////////////////// End of File //////////////////////////////////
