namespace Windows
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct LIST_ENTRY32
    {
        public uint Flink;

        public uint Blink;
    }
}
