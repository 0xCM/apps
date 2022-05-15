namespace Z0.llvm.stringtables
{
    using System;

    using static core;

    public enum MapKind : uint
    {
        OB = 0,
        T8 = 1,
        TA = 2,
        TB = 3,
        ThreeDNow = 4,
        XOP8 = 5,
        XOP9 = 6,
        XOPA = 7,
    }

    public readonly struct MapST
    {
        public const uint EntryCount = 8;

        public const uint CharCount = 29;

        public static MemoryAddress CharBase => address(Data);

        public static MemoryAddress OffsetBase => address(Offsets);

        public static MemoryStrings Strings => strings.memory(Offsets,Data);

        public static ReadOnlySpan<byte> Offsets => new byte[32]{0x00,0x00,0x00,0x00,0x02,0x00,0x00,0x00,0x04,0x00,0x00,0x00,0x06,0x00,0x00,0x00,0x08,0x00,0x00,0x00,0x11,0x00,0x00,0x00,0x15,0x00,0x00,0x00,0x19,0x00,0x00,0x00};

        public static ReadOnlySpan<char> Data => new char[29]{'O','B','T','8','T','A','T','B','T','h','r','e','e','D','N','o','w','X','O','P','8','X','O','P','9','X','O','P','A',};
    }

}
