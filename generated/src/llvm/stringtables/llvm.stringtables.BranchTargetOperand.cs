﻿namespace Z0.llvm.stringtables
{
    using System;

    using static core;

    public readonly struct BranchTargetOperand
    {
        public const uint EntryCount = 7;

        public const uint CharCount = 85;

        public static MemoryAddress CharBase => address(Data);

        public static MemoryAddress OffsetBase => address(Offsets);

        public static MemoryStrings Strings => strings.memory(Offsets,Data);

        public enum Index : uint
        {
            brtarget=0,
            brtarget16=1,
            brtarget32=2,
            brtarget8=3,
            i16imm_brtarget=4,
            i32imm_brtarget=5,
            i64i32imm_brtarget=6,
        }

        public static ReadOnlySpan<byte> Offsets => new byte[28]{0x00,0x00,0x00,0x00,0x08,0x00,0x00,0x00,0x12,0x00,0x00,0x00,0x1c,0x00,0x00,0x00,0x25,0x00,0x00,0x00,0x34,0x00,0x00,0x00,0x43,0x00,0x00,0x00};

        public static ReadOnlySpan<char> Data => new char[85]{'b','r','t','a','r','g','e','t','b','r','t','a','r','g','e','t','1','6','b','r','t','a','r','g','e','t','3','2','b','r','t','a','r','g','e','t','8','i','1','6','i','m','m','_','b','r','t','a','r','g','e','t','i','3','2','i','m','m','_','b','r','t','a','r','g','e','t','i','6','4','i','3','2','i','m','m','_','b','r','t','a','r','g','e','t',};
    }

}