namespace Windows.Image
{
    using Z0;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct COFF_SYMBOL
    {
        public CoffSymbolName Name;

        public Hex32 Value;

        public ushort SectionNumber;

        public SYM_TYPE Type;

        public SYM_STORAGE_CLASS StorageClass;

        public byte NumberOfAuxSymbols;
    }
}
