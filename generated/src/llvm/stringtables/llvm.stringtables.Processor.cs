﻿namespace Z0.llvm.stringtables
{
    using System;

    using static core;

    public readonly struct Processor
    {
        public const uint EntryCount = 86;

        public const uint CharCount = 1290;

        public static MemoryAddress CharBase => address(Data);

        public static MemoryAddress OffsetBase => address(Offsets);

        public static MemoryStrings Strings => strings.memory(Offsets,Data);

        public enum Index : uint
        {
            anonymous_20897=0,
            anonymous_20898=1,
            anonymous_20899=2,
            anonymous_20900=3,
            anonymous_20901=4,
            anonymous_20902=5,
            anonymous_20903=6,
            anonymous_20904=7,
            anonymous_20905=8,
            anonymous_20906=9,
            anonymous_20907=10,
            anonymous_20908=11,
            anonymous_20909=12,
            anonymous_20910=13,
            anonymous_20911=14,
            anonymous_20912=15,
            anonymous_20913=16,
            anonymous_20914=17,
            anonymous_20915=18,
            anonymous_20916=19,
            anonymous_20917=20,
            anonymous_20918=21,
            anonymous_20919=22,
            anonymous_20920=23,
            anonymous_20921=24,
            anonymous_20922=25,
            anonymous_20923=26,
            anonymous_20924=27,
            anonymous_20925=28,
            anonymous_20926=29,
            anonymous_20927=30,
            anonymous_20928=31,
            anonymous_20929=32,
            anonymous_20930=33,
            anonymous_20931=34,
            anonymous_20932=35,
            anonymous_20933=36,
            anonymous_20934=37,
            anonymous_20935=38,
            anonymous_20936=39,
            anonymous_20937=40,
            anonymous_20938=41,
            anonymous_20939=42,
            anonymous_20940=43,
            anonymous_20941=44,
            anonymous_20942=45,
            anonymous_20943=46,
            anonymous_20944=47,
            anonymous_20945=48,
            anonymous_20946=49,
            anonymous_20947=50,
            anonymous_20948=51,
            anonymous_20949=52,
            anonymous_20950=53,
            anonymous_20951=54,
            anonymous_20952=55,
            anonymous_20953=56,
            anonymous_20954=57,
            anonymous_20955=58,
            anonymous_20956=59,
            anonymous_20957=60,
            anonymous_20958=61,
            anonymous_20959=62,
            anonymous_20960=63,
            anonymous_20961=64,
            anonymous_20962=65,
            anonymous_20963=66,
            anonymous_20964=67,
            anonymous_20965=68,
            anonymous_20966=69,
            anonymous_20967=70,
            anonymous_20968=71,
            anonymous_20969=72,
            anonymous_20970=73,
            anonymous_20971=74,
            anonymous_20972=75,
            anonymous_20973=76,
            anonymous_20974=77,
            anonymous_20975=78,
            anonymous_20976=79,
            anonymous_20977=80,
            anonymous_20978=81,
            anonymous_20979=82,
            anonymous_20980=83,
            anonymous_20981=84,
            anonymous_20982=85,
        }

        public static ReadOnlySpan<byte> Offsets => new byte[344]{0x00,0x00,0x00,0x00,0x0f,0x00,0x00,0x00,0x1e,0x00,0x00,0x00,0x2d,0x00,0x00,0x00,0x3c,0x00,0x00,0x00,0x4b,0x00,0x00,0x00,0x5a,0x00,0x00,0x00,0x69,0x00,0x00,0x00,0x78,0x00,0x00,0x00,0x87,0x00,0x00,0x00,0x96,0x00,0x00,0x00,0xa5,0x00,0x00,0x00,0xb4,0x00,0x00,0x00,0xc3,0x00,0x00,0x00,0xd2,0x00,0x00,0x00,0xe1,0x00,0x00,0x00,0xf0,0x00,0x00,0x00,0xff,0x00,0x00,0x00,0x0e,0x01,0x00,0x00,0x1d,0x01,0x00,0x00,0x2c,0x01,0x00,0x00,0x3b,0x01,0x00,0x00,0x4a,0x01,0x00,0x00,0x59,0x01,0x00,0x00,0x68,0x01,0x00,0x00,0x77,0x01,0x00,0x00,0x86,0x01,0x00,0x00,0x95,0x01,0x00,0x00,0xa4,0x01,0x00,0x00,0xb3,0x01,0x00,0x00,0xc2,0x01,0x00,0x00,0xd1,0x01,0x00,0x00,0xe0,0x01,0x00,0x00,0xef,0x01,0x00,0x00,0xfe,0x01,0x00,0x00,0x0d,0x02,0x00,0x00,0x1c,0x02,0x00,0x00,0x2b,0x02,0x00,0x00,0x3a,0x02,0x00,0x00,0x49,0x02,0x00,0x00,0x58,0x02,0x00,0x00,0x67,0x02,0x00,0x00,0x76,0x02,0x00,0x00,0x85,0x02,0x00,0x00,0x94,0x02,0x00,0x00,0xa3,0x02,0x00,0x00,0xb2,0x02,0x00,0x00,0xc1,0x02,0x00,0x00,0xd0,0x02,0x00,0x00,0xdf,0x02,0x00,0x00,0xee,0x02,0x00,0x00,0xfd,0x02,0x00,0x00,0x0c,0x03,0x00,0x00,0x1b,0x03,0x00,0x00,0x2a,0x03,0x00,0x00,0x39,0x03,0x00,0x00,0x48,0x03,0x00,0x00,0x57,0x03,0x00,0x00,0x66,0x03,0x00,0x00,0x75,0x03,0x00,0x00,0x84,0x03,0x00,0x00,0x93,0x03,0x00,0x00,0xa2,0x03,0x00,0x00,0xb1,0x03,0x00,0x00,0xc0,0x03,0x00,0x00,0xcf,0x03,0x00,0x00,0xde,0x03,0x00,0x00,0xed,0x03,0x00,0x00,0xfc,0x03,0x00,0x00,0x0b,0x04,0x00,0x00,0x1a,0x04,0x00,0x00,0x29,0x04,0x00,0x00,0x38,0x04,0x00,0x00,0x47,0x04,0x00,0x00,0x56,0x04,0x00,0x00,0x65,0x04,0x00,0x00,0x74,0x04,0x00,0x00,0x83,0x04,0x00,0x00,0x92,0x04,0x00,0x00,0xa1,0x04,0x00,0x00,0xb0,0x04,0x00,0x00,0xbf,0x04,0x00,0x00,0xce,0x04,0x00,0x00,0xdd,0x04,0x00,0x00,0xec,0x04,0x00,0x00,0xfb,0x04,0x00,0x00};

        public static ReadOnlySpan<char> Data => new char[1290]{'a','n','o','n','y','m','o','u','s','_','2','0','8','9','7','a','n','o','n','y','m','o','u','s','_','2','0','8','9','8','a','n','o','n','y','m','o','u','s','_','2','0','8','9','9','a','n','o','n','y','m','o','u','s','_','2','0','9','0','0','a','n','o','n','y','m','o','u','s','_','2','0','9','0','1','a','n','o','n','y','m','o','u','s','_','2','0','9','0','2','a','n','o','n','y','m','o','u','s','_','2','0','9','0','3','a','n','o','n','y','m','o','u','s','_','2','0','9','0','4','a','n','o','n','y','m','o','u','s','_','2','0','9','0','5','a','n','o','n','y','m','o','u','s','_','2','0','9','0','6','a','n','o','n','y','m','o','u','s','_','2','0','9','0','7','a','n','o','n','y','m','o','u','s','_','2','0','9','0','8','a','n','o','n','y','m','o','u','s','_','2','0','9','0','9','a','n','o','n','y','m','o','u','s','_','2','0','9','1','0','a','n','o','n','y','m','o','u','s','_','2','0','9','1','1','a','n','o','n','y','m','o','u','s','_','2','0','9','1','2','a','n','o','n','y','m','o','u','s','_','2','0','9','1','3','a','n','o','n','y','m','o','u','s','_','2','0','9','1','4','a','n','o','n','y','m','o','u','s','_','2','0','9','1','5','a','n','o','n','y','m','o','u','s','_','2','0','9','1','6','a','n','o','n','y','m','o','u','s','_','2','0','9','1','7','a','n','o','n','y','m','o','u','s','_','2','0','9','1','8','a','n','o','n','y','m','o','u','s','_','2','0','9','1','9','a','n','o','n','y','m','o','u','s','_','2','0','9','2','0','a','n','o','n','y','m','o','u','s','_','2','0','9','2','1','a','n','o','n','y','m','o','u','s','_','2','0','9','2','2','a','n','o','n','y','m','o','u','s','_','2','0','9','2','3','a','n','o','n','y','m','o','u','s','_','2','0','9','2','4','a','n','o','n','y','m','o','u','s','_','2','0','9','2','5','a','n','o','n','y','m','o','u','s','_','2','0','9','2','6','a','n','o','n','y','m','o','u','s','_','2','0','9','2','7','a','n','o','n','y','m','o','u','s','_','2','0','9','2','8','a','n','o','n','y','m','o','u','s','_','2','0','9','2','9','a','n','o','n','y','m','o','u','s','_','2','0','9','3','0','a','n','o','n','y','m','o','u','s','_','2','0','9','3','1','a','n','o','n','y','m','o','u','s','_','2','0','9','3','2','a','n','o','n','y','m','o','u','s','_','2','0','9','3','3','a','n','o','n','y','m','o','u','s','_','2','0','9','3','4','a','n','o','n','y','m','o','u','s','_','2','0','9','3','5','a','n','o','n','y','m','o','u','s','_','2','0','9','3','6','a','n','o','n','y','m','o','u','s','_','2','0','9','3','7','a','n','o','n','y','m','o','u','s','_','2','0','9','3','8','a','n','o','n','y','m','o','u','s','_','2','0','9','3','9','a','n','o','n','y','m','o','u','s','_','2','0','9','4','0','a','n','o','n','y','m','o','u','s','_','2','0','9','4','1','a','n','o','n','y','m','o','u','s','_','2','0','9','4','2','a','n','o','n','y','m','o','u','s','_','2','0','9','4','3','a','n','o','n','y','m','o','u','s','_','2','0','9','4','4','a','n','o','n','y','m','o','u','s','_','2','0','9','4','5','a','n','o','n','y','m','o','u','s','_','2','0','9','4','6','a','n','o','n','y','m','o','u','s','_','2','0','9','4','7','a','n','o','n','y','m','o','u','s','_','2','0','9','4','8','a','n','o','n','y','m','o','u','s','_','2','0','9','4','9','a','n','o','n','y','m','o','u','s','_','2','0','9','5','0','a','n','o','n','y','m','o','u','s','_','2','0','9','5','1','a','n','o','n','y','m','o','u','s','_','2','0','9','5','2','a','n','o','n','y','m','o','u','s','_','2','0','9','5','3','a','n','o','n','y','m','o','u','s','_','2','0','9','5','4','a','n','o','n','y','m','o','u','s','_','2','0','9','5','5','a','n','o','n','y','m','o','u','s','_','2','0','9','5','6','a','n','o','n','y','m','o','u','s','_','2','0','9','5','7','a','n','o','n','y','m','o','u','s','_','2','0','9','5','8','a','n','o','n','y','m','o','u','s','_','2','0','9','5','9','a','n','o','n','y','m','o','u','s','_','2','0','9','6','0','a','n','o','n','y','m','o','u','s','_','2','0','9','6','1','a','n','o','n','y','m','o','u','s','_','2','0','9','6','2','a','n','o','n','y','m','o','u','s','_','2','0','9','6','3','a','n','o','n','y','m','o','u','s','_','2','0','9','6','4','a','n','o','n','y','m','o','u','s','_','2','0','9','6','5','a','n','o','n','y','m','o','u','s','_','2','0','9','6','6','a','n','o','n','y','m','o','u','s','_','2','0','9','6','7','a','n','o','n','y','m','o','u','s','_','2','0','9','6','8','a','n','o','n','y','m','o','u','s','_','2','0','9','6','9','a','n','o','n','y','m','o','u','s','_','2','0','9','7','0','a','n','o','n','y','m','o','u','s','_','2','0','9','7','1','a','n','o','n','y','m','o','u','s','_','2','0','9','7','2','a','n','o','n','y','m','o','u','s','_','2','0','9','7','3','a','n','o','n','y','m','o','u','s','_','2','0','9','7','4','a','n','o','n','y','m','o','u','s','_','2','0','9','7','5','a','n','o','n','y','m','o','u','s','_','2','0','9','7','6','a','n','o','n','y','m','o','u','s','_','2','0','9','7','7','a','n','o','n','y','m','o','u','s','_','2','0','9','7','8','a','n','o','n','y','m','o','u','s','_','2','0','9','7','9','a','n','o','n','y','m','o','u','s','_','2','0','9','8','0','a','n','o','n','y','m','o','u','s','_','2','0','9','8','1','a','n','o','n','y','m','o','u','s','_','2','0','9','8','2',};
    }

}