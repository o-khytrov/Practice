/******************************************************************************
Module:  Ch20-1-ExceptionHandling.cs
Notices: Copyright (c) 2013 Jeffrey Richter
******************************************************************************/

#if !DEBUG
#pragma warning disable 1058
#endif
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Permissions;

internal static class GenericException {
   public static void Go() {
      try {
         throw new Exception<DiskFullExceptionArgs>(new DiskFullExceptionArgs(@"C:\"), "The disk is full");
      }
      catch (InvalidOperationException e) {// Exception<DiskFullExceptionArgs> e) {
         Console.WriteLine(e.Message);
      }

      // Verify that the exception is serializable
      using (var stream = new MemoryStream()) {
         var e = new Exception<DiskFullExceptionArgs>(new DiskFullExceptionArgs(@"C:\"), "The disk is full");
         var formatter = new BinaryFormatter();
         formatter.Serialize(stream, e);
         stream.Position = 0;
         e = (Exception<DiskFullExceptionArgs>)formatter.Deserialize(stream);
         Console.WriteLine(e.Message);
      }
   }

   [Serializable]
   private sealed class DiskFullExceptionArgs : ExceptionArgs {
      private readonly String m_diskpath; // private field set at construction time

      public DiskFullExceptionArgs(String diskpath) { m_diskpath = diskpath; }

      // Public read-only property that returns the field
      public String DiskPath { get { return m_diskpath; } }

      // Override the Message property to include our field (if set)
      public override String Message {
         get {
            return (m_diskpath == null) ? base.Message : "DiskPath=" + m_diskpath;
         }
      }
   }

   /// <summary>Represents errors that occur during application execution.</summary>
   /// <typeparam name="TExceptionArgs">The type of exception and any additional arguments associated with it.</typeparam>
   [Serializable]
   public sealed class Exception<TExceptionArgs> : Exception, ISerializable where TExceptionArgs : ExceptionArgs {
      private const String c_args = "Args";     // For (de)serialization
      private readonly TExceptionArgs m_args;

      /// <summary>Returns a reference to this exception's additional arguments.</summary>
      public TExceptionArgs Args { get { return m_args; } }

      /// <summary>
      /// Initializes a new instance of the Exception class with a specified error message 
      /// and a reference to the inner exception that is the cause of this exception. 
      /// </summary>
      /// <param name="message">The error message that explains the reason for the exception.</param>
      /// <param name="innerException">The exception that is the cause of the current exception, 
      /// or a null reference if no inner exception is specified.</param>
      public Exception(String message = null, Exception innerException = null)
         : this(null, message, innerException) { }

      // The fourth public constructor because there is a field
      /// <summary>
      /// Initializes a new instance of the Exception class with additional arguments, 
      /// a specified error message, and a reference to the inner exception 
      /// that is the cause of this exception. 
      /// </summary>
      /// <param name="args">The exception's additional arguments.</param>
      /// <param name="message">The error message that explains the reason for the exception.</param>
      /// <param name="innerException">The exception that is the cause of the current exception, 
      /// or a null reference if no inner exception is specified.</param>
      public Exception(TExceptionArgs args, String message = null, Exception innerException = null)
         : base(message, innerException) {
         m_args = args;
      }

      // Because at least 1 field is defined, define the special deserialization constructor
      // Since this class is sealed, this constructor is private
      // If this class were not sealed, this constructor should be protected
      [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
      private Exception(SerializationInfo info, StreamingContext context)
         : base(info, context) { // Let the base deserialize its fields
         m_args = (TExceptionArgs)info.GetValue(c_args, typeof(TExceptionArgs));
      }

      // Because at least 1 field is defined, define the serialization method
      /// <summary>
      /// When overridden in a derived class, sets the SerializationInfo with information about the exception.
      /// </summary>
      /// <param name="info">The SerializationInfo that holds the serialized object data about the exception being thrown.</param>
      /// <param name="context">The StreamingContext that contains contextual information about the source or destination.</param>
      [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
      public override void GetObjectData(SerializationInfo info, StreamingContext context) {
         info.AddValue(c_args, m_args);
         base.GetObjectData(info, context);
      }

      /// <summary>Gets a message that describes the current exception.</summary>
      public override String Message {
         get {
            String baseMsg = base.Message;
            return (m_args == null) ? baseMsg : baseMsg + " (" + m_args.Message + ")";
         }
      }

      /// <summary>
      /// Determines whether the specified Object is equal to the current Object.
      /// </summary>
      /// <param name="obj">The Object to compare with the current Object. </param>
      /// <returns>true if the specified Object is equal to the current Object; otherwise, false.</returns>
      public override Boolean Equals(Object obj) {
         Exception<TExceptionArgs> other = obj as Exception<TExceptionArgs>;
         if (other == null) return false;
         return Object.Equals(m_args, other.m_args) && base.Equals(obj);
      }
      public override int GetHashCode() { return base.GetHashCode(); }
   }

   /// <summary>
   /// A base class that a custom exception would derive from in order to add its own exception arguments.
   /// </summary>
   [Serializable]
   public abstract class ExceptionArgs {
      /// <summary>The string message associated with this exception.</summary>
      public virtual String Message { get { return String.Empty; } }
   }
}

//////////////////////////////// End of File //////////////////////////////////
