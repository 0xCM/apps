namespace Windows.Image
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct COFF_SYMBOLS_HEADER
    {
        public uint NumberOfSymbols;

        public uint LvaToFirstSymbol;

        public uint NumberOfLinenumbers;

        public uint LvaToFirstLinenumber;

        public uint RvaToFirstByteOfCode;

        public uint RvaToLastByteOfCode;

        public uint RvaToFirstByteOfData;

        public uint RvaToLastByteOfData;
    }
}