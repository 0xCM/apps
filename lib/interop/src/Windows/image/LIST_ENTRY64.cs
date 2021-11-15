namespace Windows
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct LIST_ENTRY64
    {
        public ulong Flink;

        public ulong Blink;
    }
}
