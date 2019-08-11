#if !DEBUG
#pragma warning disable 67
#endif

//#define TEST
#define VERIFY

using System;

#region Possible Targets
#pragma warning disable 67

[type: MyAttr(3)]             // Applied to type
internal sealed class SomeType
   <[typevar: MyAttr(4)] T>
{ // Applied to generic type variable

    [field: MyAttr(5)]         // Applied to field
    public Int32 SomeField = 0;

    [return: MyAttr(6)]        // Applied to return value
    [method: MyAttr(7)]        // Applied to method
    public Int32 SomeMethod(
       [param: MyAttr(8)]      // Applied to parameter
      Int32 SomeParam)
    { return SomeParam; }

    [property: MyAttr(9)]      // Applied to property
    public String SomeProp
    {
        [method: MyAttr(10)]    // Applied to get accessor method
        get { return null; }
    }

    [event: MyAttr(11)]        // Applied to event
    [field: MyAttr(12)]        // Applied to compiler-generated field
    [method: MyAttr(13)]       // Applied to compiler-generated add & remove methods
    public event EventHandler SomeEvent;
}

#endregion
