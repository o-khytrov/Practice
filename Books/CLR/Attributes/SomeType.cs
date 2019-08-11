#if !DEBUG
#pragma warning disable 67
#endif

//#define TEST
#define VERIFY

using System;

#region Possible Targets
#pragma warning disable 67
     
[Some("Jeff", Color.Red, new Type[] { typeof(Math), typeof(Console) })]
internal sealed class SomeType
{
}

#endregion
