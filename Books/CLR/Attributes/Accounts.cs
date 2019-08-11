#if !DEBUG
#pragma warning disable 67
#endif

//#define TEST
#define VERIFY

using System;



internal sealed partial class MatchingAttributes
{
    [Flags]
    private enum Accounts
    {
        Savings = 0x0001,
        Checking = 0x0002,
        Brokerage = 0x0004
    }
}