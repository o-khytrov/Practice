#if !DEBUG
#pragma warning disable 67
#endif

//#define TEST
#define VERIFY

using System;
using System.Reflection;

internal sealed partial class MatchingAttributes
{
    public static void Go()
    {
        CanWriteCheck(new ChildAccount());
        CanWriteCheck(new AdultAccount());

        // This just demonstrates that the method works correctly on a
        // type that doesn't have the AccountsAttribute applied to it.
        CanWriteCheck(new MatchingAttributes());
    }

    private static void CanWriteCheck(Object obj)
    {
        // Construct an instance of the attribute type and initialize it
        // to what we are explicitly looking for.
        Attribute checking = new AccountsAttribute(Accounts.Checking);

        // Construct the attribute instance that was applied to the type
        Attribute validAccounts = obj.GetType().GetCustomAttribute<AccountsAttribute>(false);

        // If the attribute was applied to the type AND the
        // attribute specifies the "Checking" account, then the
        // type can write a check
        if ((validAccounts != null) && checking.Match(validAccounts))
        {
            Console.WriteLine("{0} types can write checks.", obj.GetType());
        }
        else
        {
            Console.WriteLine("{0} types can NOT write checks.", obj.GetType());
        }
    }
}