namespace Windows.Image
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct IMAGE_SECTION_HEADER
    {
        [StructLayout(LayoutKind.Explicit)]
        public struct _Misc_e__Union
        {
            [FieldOffset(0)]
            public uint PhysicalAddress;

            [FieldOffset(0)]
            public uint VirtualSize;
        }

        public ulong Name;

        public _Misc_e__Union Misc;

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
