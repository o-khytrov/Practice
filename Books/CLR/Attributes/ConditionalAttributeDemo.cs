#if !DEBUG
#pragma warning disable 67
#endif

#define TEST
//#define VERIFY

using System;
using System.Diagnostics;


[Cond]
public static class ConditionalAttributeDemo
{
    [Conditional("TEST")]
    [Conditional("VERIFY")]
    public sealed class CondAttribute : Attribute
    {
    }

    public static void Go()
    {
        Console.WriteLine("CondAttribute is {0}applied to Program type.",
           Attribute.IsDefined(typeof(ConditionalAttributeDemo),
              typeof(CondAttribute)) ? "" : "not ");
    }
}