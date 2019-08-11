#if !DEBUG
#pragma warning disable 67
#endif

//#define TEST
#define VERIFY

using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
internal sealed class OSVERSIONINFO
{
    public OSVERSIONINFO()
    {
        OSVersionInfoSize = (UInt32)Marshal.SizeOf(this);
    }

    public UInt32 OSVersionInfoSize = 0;
    public UInt32 MajorVersion = 0;
    public UInt32 MinorVersion = 0;
    public UInt32 BuildNumber = 0;
    public UInt32 PlatformId = 0;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    public String CSDVersion = null;
}
