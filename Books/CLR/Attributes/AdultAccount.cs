#if !DEBUG
#pragma warning disable 67
#endif

//#define TEST
#define VERIFY




internal sealed partial class MatchingAttributes
{
    [Accounts(Accounts.Savings | Accounts.Checking | Accounts.Brokerage)]
    private sealed class AdultAccount { }
}