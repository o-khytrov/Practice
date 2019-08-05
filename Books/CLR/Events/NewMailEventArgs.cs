//#define CompilerImplementedEventMethods
using System;
///////////////////////////////////////////////////////////////////////////////

// Step #1: Define a type that will hold any additional information that 
// should be sent to receivers of the event notification  
internal sealed class NewMailEventArgs : EventArgs {

   private readonly String m_from, m_to, m_subject;

   public NewMailEventArgs(String from, String to, String subject) {
      m_from = from; m_to = to; m_subject = subject;
   }

   public String From { get { return m_from; } }
   public String To { get { return m_to; } }
   public String Subject { get { return m_subject; } }
}

//////////////////////////////// End of File //////////////////////////////////
