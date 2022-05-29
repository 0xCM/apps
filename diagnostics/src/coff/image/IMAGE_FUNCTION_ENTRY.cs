namespace Windows.Image
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct IMAGE_FUNCTION_ENTRY
    {
        public uint StartingAddress;

        public uint EndingAddress;

        public uint EndOfPrologue;
    }
}