namespace Windows.Image
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct COFF_SYMBOL_TABLE
    {
        public ulong Name;

        public uint Value;

        public ushort SectionNumber;

        public ushort Type;

        public SYM_STORAGE_CLASS StorageClass;

        public byte NumberOfAuxSymbols;
    }
}
