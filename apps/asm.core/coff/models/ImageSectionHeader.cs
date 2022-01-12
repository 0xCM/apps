namespace Z0
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct ImageSectionHeader
    {
        public CoffSymbolName Name;

        public uint VirtualSize;

        public Address32 VirtualAddress;

        public uint SizeOfRawData;

        public Address32 PointerToRawData;

        public Address32 PointerToRelocations;

        public Address32 PointerToLinenumbers;

        public ushort NumberOfRelocations;

        public ushort NumberOfLinenumbers;

        public ImageSectionFlags Characteristics;
    }
}
