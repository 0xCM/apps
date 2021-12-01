namespace Windows.Image
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct IMAGE_DEBUG_DIRECTORY
    {
        public uint Characteristics;

        public uint TimeDateStamp;

        public ushort MajorVersion;

        public ushort MinorVersion;

        public IMAGE_DEBUG_TYPE Type;

        public uint SizeOfData;

        public uint AddressOfRawData;

        public uint PointerToRawData;
    }
}