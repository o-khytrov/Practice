//#define CompilerImplementedEventMethods
using System;
///////////////////////////////////////////////////////////////////////////////

internal sealed class Pager {
   // Pass the MailManager object to the constructor
   public Pager(MailManager mm) {
      // Construct an instance of the ProcessMailMsgEventHandler 
      // delegate that refers to our SendMsgToPager callback method.
      // Register our callback with MailManager's ProcessMailMsg event
      mm.NewMail += SendMsgToPager;
   }

   // This is the method that the MailManager will call
   // when a new e-mail message arrives
   private void SendMsgToPager(Object sender, NewMailEventArgs e) {
      // 'sender' identifies the MailManager in case we want to communicate back to it.
      // 'e' identifies the additional event information that the MailManager wants to give us.

      // Normally, the code here would send the e-mail message to a pager.
      // This test implementation displays the info on the console
      Console.WriteLine("Sending mail message to pager:");
		Console.WriteLine("   From={0}, To={1}, Subject={2}", e.From, e.To, e.Subject);
	}

	public void Unregister(MailManager mm) {
		// Unregister ourself with MailManager's ProcessMailMsg event
		mm.NewMail -= SendMsgToPager;
	}
}

//////////////////////////////// End of File //////////////////////////////////
