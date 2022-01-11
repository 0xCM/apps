namespace Windows.Image
{
    using System.Runtime.InteropServices;

    using Z0;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct IMAGE_FILE_HEADER
    {
        public IMAGE_FILE_MACHINE Machine;

        public ushort NumberOfSections;

        public Hex32 TimeDateStamp;

        public Address32 PointerToSymbolTable;

        public uint NumberOfSymbols;

        public Hex16 SizeOfOptionalHeader;

        public IMAGE_FILE_FLAGS Characteristics;
    }
}