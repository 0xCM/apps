namespace Z0.llvm.strings
{
    using System;

    using static core;

    public enum InstructionEquivalenceClassKind : uint
    {
        anonymous_17053 = 0,
        anonymous_17067 = 1,
        anonymous_17068 = 2,
        anonymous_17069 = 3,
        anonymous_17070 = 4,
        anonymous_17072 = 5,
        anonymous_17073 = 6,
        anonymous_17074 = 7,
        anonymous_17075 = 8,
        anonymous_17076 = 9,
        anonymous_17077 = 10,
        anonymous_18020 = 11,
        anonymous_18021 = 12,
        anonymous_18022 = 13,
        anonymous_18023 = 14,
        anonymous_18025 = 15,
        anonymous_18026 = 16,
        anonymous_18027 = 17,
        anonymous_18028 = 18,
        anonymous_18029 = 19,
        anonymous_18896 = 20,
        anonymous_18897 = 21,
        anonymous_18900 = 22,
    }

    public readonly struct InstructionEquivalenceClassST
    {
        public const uint EntryCount = 23;

        public const uint CharCount = 345;

        public static MemoryAddress CharBase => address(Data);

        public static MemoryAddress OffsetBase => address(Offsets);

        public static MemoryStrings<InstructionEquivalenceClassKind> Strings => MemoryStrings.create(Offsets,Data);

        public static ReadOnlySpan<byte> Offsets => new byte[92]{0x00,0x00,0x00,0x00,0x0f,0x00,0x00,0x00,0x1e,0x00,0x00,0x00,0x2d,0x00,0x00,0x00,0x3c,0x00,0x00,0x00,0x4b,0x00,0x00,0x00,0x5a,0x00,0x00,0x00,0x69,0x00,0x00,0x00,0x78,0x00,0x00,0x00,0x87,0x00,0x00,0x00,0x96,0x00,0x00,0x00,0xa5,0x00,0x00,0x00,0xb4,0x00,0x00,0x00,0xc3,0x00,0x00,0x00,0xd2,0x00,0x00,0x00,0xe1,0x00,0x00,0x00,0xf0,0x00,0x00,0x00,0xff,0x00,0x00,0x00,0x0e,0x01,0x00,0x00,0x1d,0x01,0x00,0x00,0x2c,0x01,0x00,0x00,0x3b,0x01,0x00,0x00,0x4a,0x01,0x00,0x00};

        public static ReadOnlySpan<char> Data => new char[345]{'a','n','o','n','y','m','o','u','s','_','1','7','0','5','3','a','n','o','n','y','m','o','u','s','_','1','7','0','6','7','a','n','o','n','y','m','o','u','s','_','1','7','0','6','8','a','n','o','n','y','m','o','u','s','_','1','7','0','6','9','a','n','o','n','y','m','o','u','s','_','1','7','0','7','0','a','n','o','n','y','m','o','u','s','_','1','7','0','7','2','a','n','o','n','y','m','o','u','s','_','1','7','0','7','3','a','n','o','n','y','m','o','u','s','_','1','7','0','7','4','a','n','o','n','y','m','o','u','s','_','1','7','0','7','5','a','n','o','n','y','m','o','u','s','_','1','7','0','7','6','a','n','o','n','y','m','o','u','s','_','1','7','0','7','7','a','n','o','n','y','m','o','u','s','_','1','8','0','2','0','a','n','o','n','y','m','o','u','s','_','1','8','0','2','1','a','n','o','n','y','m','o','u','s','_','1','8','0','2','2','a','n','o','n','y','m','o','u','s','_','1','8','0','2','3','a','n','o','n','y','m','o','u','s','_','1','8','0','2','5','a','n','o','n','y','m','o','u','s','_','1','8','0','2','6','a','n','o','n','y','m','o','u','s','_','1','8','0','2','7','a','n','o','n','y','m','o','u','s','_','1','8','0','2','8','a','n','o','n','y','m','o','u','s','_','1','8','0','2','9','a','n','o','n','y','m','o','u','s','_','1','8','8','9','6','a','n','o','n','y','m','o','u','s','_','1','8','8','9','7','a','n','o','n','y','m','o','u','s','_','1','8','9','0','0',};
    }
}
