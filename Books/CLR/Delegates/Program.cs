using static AnonymousMethods;

public sealed class Program {
   public static void Main() {

        //DelegateIntro.Go();
        //GetInvocationList.Go();

        DelegateReflection.Go("TwoInt32s", "Add", "123", "321");
        DelegateReflection.Go("TwoInt32s", "Subtract", "123", "321");
        DelegateReflection.Go("OneString", "NumChars", "Hello there");
        DelegateReflection.Go("OneString", "Reverse", "Hello there");
    }
}
