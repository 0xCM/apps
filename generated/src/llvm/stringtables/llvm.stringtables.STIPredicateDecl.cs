namespace Z0.llvm.stringtables
{
    using System;

    using static core;

    public readonly struct STIPredicateDecl
    {
        public const uint EntryCount = 3;

        public const uint CharCount = 61;

        public static MemoryAddress CharBase => address(Data);

        public static MemoryAddress OffsetBase => address(Offsets);

        public static MemoryStrings Strings => strings.memory(Offsets,Data);

        public enum Index : uint
        {
            IsDepBreakingDecl=0,
            IsOptimizableRegisterMoveDecl=1,
            IsZeroIdiomDecl=2,
        }

        public static ReadOnlySpan<byte> Offsets => new byte[12]{0x00,0x00,0x00,0x00,0x11,0x00,0x00,0x00,0x2e,0x00,0x00,0x00};

        public static ReadOnlySpan<char> Data => new char[61]{'I','s','D','e','p','B','r','e','a','k','i','n','g','D','e','c','l','I','s','O','p','t','i','m','i','z','a','b','l','e','R','e','g','i','s','t','e','r','M','o','v','e','D','e','c','l','I','s','Z','e','r','o','I','d','i','o','m','D','e','c','l',};
    }

}
