namespace Z0.llvm.stringtables
{
    using System;

    using static core;

    public enum X86SrcIdxOperandKind : uint
    {
        srcidx16 = 0,
        srcidx32 = 1,
        srcidx64 = 2,
        srcidx8 = 3,
    }

    public readonly struct X86SrcIdxOperandST
    {
        public const uint EntryCount = 4;

        public const uint CharCount = 31;

        public static MemoryAddress CharBase => address(Data);

        public static MemoryAddress OffsetBase => address(Offsets);

        public static MemoryStrings Strings => strings.memory(Offsets,Data);

        public static ReadOnlySpan<byte> Offsets => new byte[16]{0x00,0x00,0x00,0x00,0x08,0x00,0x00,0x00,0x10,0x00,0x00,0x00,0x18,0x00,0x00,0x00};

        public static ReadOnlySpan<char> Data => new char[31]{'s','r','c','i','d','x','1','6','s','r','c','i','d','x','3','2','s','r','c','i','d','x','6','4','s','r','c','i','d','x','8',};
    }

}
