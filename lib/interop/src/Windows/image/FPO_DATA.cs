namespace Windows.Image
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct FPO_DATA
    {
        public uint ulOffStart;

        public uint cbProcSize;

        public uint cdwLocals;

        public ushort cdwParams;

        public ushort _bitfield;
    }
}
