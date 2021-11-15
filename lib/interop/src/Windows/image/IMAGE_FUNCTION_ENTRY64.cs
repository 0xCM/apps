namespace Windows.Image
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct IMAGE_FUNCTION_ENTRY64
    {
        [StructLayout(LayoutKind.Explicit, Pack = 4)]
        public struct _Anonymous_e__Union
        {
            [FieldOffset(0)]
            public ulong EndOfPrologue;

            [FieldOffset(0)]
            public ulong UnwindInfoAddress;
        }

        public ulong StartingAddress;

        public ulong EndingAddress;

        public _Anonymous_e__Union Anonymous;
    }
}
