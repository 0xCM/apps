﻿namespace Z0.llvm.stringtables
{
    using System;

    using static core;

    public readonly struct AssemblerPredicate
    {
        public const uint EntryCount = 5;

        public const uint CharCount = 57;

        public static MemoryAddress CharBase => address(Data);

        public static MemoryAddress OffsetBase => address(Offsets);

        public static MemoryStrings Strings => strings.memory(Offsets,Data);

        public enum Index : uint
        {
            In16BitMode=0,
            In32BitMode=1,
            In64BitMode=2,
            Not16BitMode=3,
            Not64BitMode=4,
        }

        public static ReadOnlySpan<byte> Offsets => new byte[20]{0x00,0x00,0x00,0x00,0x0b,0x00,0x00,0x00,0x16,0x00,0x00,0x00,0x21,0x00,0x00,0x00,0x2d,0x00,0x00,0x00};

        public static ReadOnlySpan<char> Data => new char[57]{'I','n','1','6','B','i','t','M','o','d','e','I','n','3','2','B','i','t','M','o','d','e','I','n','6','4','B','i','t','M','o','d','e','N','o','t','1','6','B','i','t','M','o','d','e','N','o','t','6','4','B','i','t','M','o','d','e',};
    }

}