#if !DEBUG
#pragma warning disable 67
#endif

//#define TEST
#define VERIFY




internal sealed partial class MatchingAttributes
{
    [Accounts(Accounts.Savings)]
    private sealed class ChildAccount { }
}