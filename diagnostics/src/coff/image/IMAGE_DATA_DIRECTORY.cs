namespace Windows.Image
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct IMAGE_DATA_DIRECTORY
    {
        public uint VirtualAddress;

        public uint Size;
    }
}
