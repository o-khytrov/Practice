#if !DEBUG
#pragma warning disable 67
#endif

//#define TEST
#define VERIFY

using System;


[AttributeUsage(AttributeTargets.All)]
internal sealed class SomeAttribute : Attribute
{
  
    public SomeAttribute(String name, Object o, Type[] types)
    {
       
        // 'name'  refers to a String
        // 'o'     refers to one of the legal types (boxing if necessary)
        // 'types' refers to a 1-dimension, 0-based array of Types
    }
}
