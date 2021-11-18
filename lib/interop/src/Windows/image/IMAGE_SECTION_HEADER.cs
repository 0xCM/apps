namespace Windows.Image
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct IMAGE_SECTION_HEADER
    {
        public ulong Name;

        public uint VirtualSize;

        public uint VirtualAddress;

        public uint SizeOfRawData;

        public uint PointerToRawData;

        public uint PointerToRelocations;

        public uint PointerToLinenumbers;

        public ushort NumberOfRelocations;

        public ushort NumberOfLinenumbers;

        public IMAGE_SECTION_CHARACTERISTICS Characteristics;
    }
}
