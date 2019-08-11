#if !DEBUG
#pragma warning disable 67
#endif

//#define TEST
#define VERIFY

using System;

[AttributeUsage(AttributeTargets.All)]
public class MyAttr : Attribute
{
    public MyAttr(Int32 x)
    {
    }
}

