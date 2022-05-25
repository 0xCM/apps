namespace Z0.llvm.strings
{
    using System;

    using static core;

    public enum FormatKind : uint
    {
        AddCCFrm = 0,
        AddRegFrm = 1,
        MRM0X = 2,
        MRM0m = 3,
        MRM0r = 4,
        MRM1X = 5,
        MRM1m = 6,
        MRM1r = 7,
        MRM2X = 8,
        MRM2m = 9,
        MRM2r = 10,
        MRM3X = 11,
        MRM3m = 12,
        MRM3r = 13,
        MRM4X = 14,
        MRM4m = 15,
        MRM4r = 16,
        MRM5X = 17,
        MRM5m = 18,
        MRM5r = 19,
        MRM6X = 20,
        MRM6m = 21,
        MRM6r = 22,
        MRM7X = 23,
        MRM7m = 24,
        MRM7r = 25,
        MRMDestMem = 26,
        MRMDestMemFSIB = 27,
        MRMDestReg = 28,
        MRMSrcMem = 29,
        MRMSrcMem4VOp3 = 30,
        MRMSrcMemCC = 31,
        MRMSrcMemFSIB = 32,
        MRMSrcMemOp4 = 33,
        MRMSrcReg = 34,
        MRMSrcReg4VOp3 = 35,
        MRMSrcRegCC = 36,
        MRMSrcRegOp4 = 37,
        MRMXm = 38,
        MRMXmCC = 39,
        MRMXr = 40,
        MRMXrCC = 41,
        MRM_C0 = 42,
        MRM_C1 = 43,
        MRM_C2 = 44,
        MRM_C3 = 45,
        MRM_C4 = 46,
        MRM_C5 = 47,
        MRM_C6 = 48,
        MRM_C7 = 49,
        MRM_C8 = 50,
        MRM_C9 = 51,
        MRM_CA = 52,
        MRM_CB = 53,
        MRM_CC = 54,
        MRM_CD = 55,
        MRM_CE = 56,
        MRM_CF = 57,
        MRM_D0 = 58,
        MRM_D1 = 59,
        MRM_D2 = 60,
        MRM_D3 = 61,
        MRM_D4 = 62,
        MRM_D5 = 63,
        MRM_D6 = 64,
        MRM_D7 = 65,
        MRM_D8 = 66,
        MRM_D9 = 67,
        MRM_DA = 68,
        MRM_DB = 69,
        MRM_DC = 70,
        MRM_DD = 71,
        MRM_DE = 72,
        MRM_DF = 73,
        MRM_E0 = 74,
        MRM_E1 = 75,
        MRM_E2 = 76,
        MRM_E3 = 77,
        MRM_E4 = 78,
        MRM_E5 = 79,
        MRM_E6 = 80,
        MRM_E7 = 81,
        MRM_E8 = 82,
        MRM_E9 = 83,
        MRM_EA = 84,
        MRM_EB = 85,
        MRM_EC = 86,
        MRM_ED = 87,
        MRM_EE = 88,
        MRM_EF = 89,
        MRM_F0 = 90,
        MRM_F1 = 91,
        MRM_F2 = 92,
        MRM_F3 = 93,
        MRM_F4 = 94,
        MRM_F5 = 95,
        MRM_F6 = 96,
        MRM_F7 = 97,
        MRM_F8 = 98,
        MRM_F9 = 99,
        MRM_FA = 100,
        MRM_FB = 101,
        MRM_FC = 102,
        MRM_FD = 103,
        MRM_FE = 104,
        MRM_FF = 105,
        MRMr0 = 106,
        PrefixByte = 107,
        Pseudo = 108,
        RawFrm = 109,
        RawFrmDst = 110,
        RawFrmDstSrc = 111,
        RawFrmImm16 = 112,
        RawFrmImm8 = 113,
        RawFrmMemOffs = 114,
        RawFrmSrc = 115,
    }

    public readonly struct FormatST
    {
        public const uint EntryCount = 116;

        public const uint CharCount = 775;

        public static MemoryAddress CharBase => address(Data);

        public static MemoryAddress OffsetBase => address(Offsets);

        public static MemoryStrings<FormatKind> Strings => memory.strings(Offsets,Data);

        public static ReadOnlySpan<byte> Offsets => new byte[464]{0x00,0x00,0x00,0x00,0x08,0x00,0x00,0x00,0x11,0x00,0x00,0x00,0x16,0x00,0x00,0x00,0x1b,0x00,0x00,0x00,0x20,0x00,0x00,0x00,0x25,0x00,0x00,0x00,0x2a,0x00,0x00,0x00,0x2f,0x00,0x00,0x00,0x34,0x00,0x00,0x00,0x39,0x00,0x00,0x00,0x3e,0x00,0x00,0x00,0x43,0x00,0x00,0x00,0x48,0x00,0x00,0x00,0x4d,0x00,0x00,0x00,0x52,0x00,0x00,0x00,0x57,0x00,0x00,0x00,0x5c,0x00,0x00,0x00,0x61,0x00,0x00,0x00,0x66,0x00,0x00,0x00,0x6b,0x00,0x00,0x00,0x70,0x00,0x00,0x00,0x75,0x00,0x00,0x00,0x7a,0x00,0x00,0x00,0x7f,0x00,0x00,0x00,0x84,0x00,0x00,0x00,0x89,0x00,0x00,0x00,0x93,0x00,0x00,0x00,0xa1,0x00,0x00,0x00,0xab,0x00,0x00,0x00,0xb4,0x00,0x00,0x00,0xc2,0x00,0x00,0x00,0xcd,0x00,0x00,0x00,0xda,0x00,0x00,0x00,0xe6,0x00,0x00,0x00,0xef,0x00,0x00,0x00,0xfd,0x00,0x00,0x00,0x08,0x01,0x00,0x00,0x14,0x01,0x00,0x00,0x19,0x01,0x00,0x00,0x20,0x01,0x00,0x00,0x25,0x01,0x00,0x00,0x2c,0x01,0x00,0x00,0x32,0x01,0x00,0x00,0x38,0x01,0x00,0x00,0x3e,0x01,0x00,0x00,0x44,0x01,0x00,0x00,0x4a,0x01,0x00,0x00,0x50,0x01,0x00,0x00,0x56,0x01,0x00,0x00,0x5c,0x01,0x00,0x00,0x62,0x01,0x00,0x00,0x68,0x01,0x00,0x00,0x6e,0x01,0x00,0x00,0x74,0x01,0x00,0x00,0x7a,0x01,0x00,0x00,0x80,0x01,0x00,0x00,0x86,0x01,0x00,0x00,0x8c,0x01,0x00,0x00,0x92,0x01,0x00,0x00,0x98,0x01,0x00,0x00,0x9e,0x01,0x00,0x00,0xa4,0x01,0x00,0x00,0xaa,0x01,0x00,0x00,0xb0,0x01,0x00,0x00,0xb6,0x01,0x00,0x00,0xbc,0x01,0x00,0x00,0xc2,0x01,0x00,0x00,0xc8,0x01,0x00,0x00,0xce,0x01,0x00,0x00,0xd4,0x01,0x00,0x00,0xda,0x01,0x00,0x00,0xe0,0x01,0x00,0x00,0xe6,0x01,0x00,0x00,0xec,0x01,0x00,0x00,0xf2,0x01,0x00,0x00,0xf8,0x01,0x00,0x00,0xfe,0x01,0x00,0x00,0x04,0x02,0x00,0x00,0x0a,0x02,0x00,0x00,0x10,0x02,0x00,0x00,0x16,0x02,0x00,0x00,0x1c,0x02,0x00,0x00,0x22,0x02,0x00,0x00,0x28,0x02,0x00,0x00,0x2e,0x02,0x00,0x00,0x34,0x02,0x00,0x00,0x3a,0x02,0x00,0x00,0x40,0x02,0x00,0x00,0x46,0x02,0x00,0x00,0x4c,0x02,0x00,0x00,0x52,0x02,0x00,0x00,0x58,0x02,0x00,0x00,0x5e,0x02,0x00,0x00,0x64,0x02,0x00,0x00,0x6a,0x02,0x00,0x00,0x70,0x02,0x00,0x00,0x76,0x02,0x00,0x00,0x7c,0x02,0x00,0x00,0x82,0x02,0x00,0x00,0x88,0x02,0x00,0x00,0x8e,0x02,0x00,0x00,0x94,0x02,0x00,0x00,0x9a,0x02,0x00,0x00,0xa0,0x02,0x00,0x00,0xa6,0x02,0x00,0x00,0xac,0x02,0x00,0x00,0xb1,0x02,0x00,0x00,0xbb,0x02,0x00,0x00,0xc1,0x02,0x00,0x00,0xc7,0x02,0x00,0x00,0xd0,0x02,0x00,0x00,0xdc,0x02,0x00,0x00,0xe7,0x02,0x00,0x00,0xf1,0x02,0x00,0x00,0xfe,0x02,0x00,0x00};

        public static ReadOnlySpan<char> Data => new char[775]{'A','d','d','C','C','F','r','m','A','d','d','R','e','g','F','r','m','M','R','M','0','X','M','R','M','0','m','M','R','M','0','r','M','R','M','1','X','M','R','M','1','m','M','R','M','1','r','M','R','M','2','X','M','R','M','2','m','M','R','M','2','r','M','R','M','3','X','M','R','M','3','m','M','R','M','3','r','M','R','M','4','X','M','R','M','4','m','M','R','M','4','r','M','R','M','5','X','M','R','M','5','m','M','R','M','5','r','M','R','M','6','X','M','R','M','6','m','M','R','M','6','r','M','R','M','7','X','M','R','M','7','m','M','R','M','7','r','M','R','M','D','e','s','t','M','e','m','M','R','M','D','e','s','t','M','e','m','F','S','I','B','M','R','M','D','e','s','t','R','e','g','M','R','M','S','r','c','M','e','m','M','R','M','S','r','c','M','e','m','4','V','O','p','3','M','R','M','S','r','c','M','e','m','C','C','M','R','M','S','r','c','M','e','m','F','S','I','B','M','R','M','S','r','c','M','e','m','O','p','4','M','R','M','S','r','c','R','e','g','M','R','M','S','r','c','R','e','g','4','V','O','p','3','M','R','M','S','r','c','R','e','g','C','C','M','R','M','S','r','c','R','e','g','O','p','4','M','R','M','X','m','M','R','M','X','m','C','C','M','R','M','X','r','M','R','M','X','r','C','C','M','R','M','_','C','0','M','R','M','_','C','1','M','R','M','_','C','2','M','R','M','_','C','3','M','R','M','_','C','4','M','R','M','_','C','5','M','R','M','_','C','6','M','R','M','_','C','7','M','R','M','_','C','8','M','R','M','_','C','9','M','R','M','_','C','A','M','R','M','_','C','B','M','R','M','_','C','C','M','R','M','_','C','D','M','R','M','_','C','E','M','R','M','_','C','F','M','R','M','_','D','0','M','R','M','_','D','1','M','R','M','_','D','2','M','R','M','_','D','3','M','R','M','_','D','4','M','R','M','_','D','5','M','R','M','_','D','6','M','R','M','_','D','7','M','R','M','_','D','8','M','R','M','_','D','9','M','R','M','_','D','A','M','R','M','_','D','B','M','R','M','_','D','C','M','R','M','_','D','D','M','R','M','_','D','E','M','R','M','_','D','F','M','R','M','_','E','0','M','R','M','_','E','1','M','R','M','_','E','2','M','R','M','_','E','3','M','R','M','_','E','4','M','R','M','_','E','5','M','R','M','_','E','6','M','R','M','_','E','7','M','R','M','_','E','8','M','R','M','_','E','9','M','R','M','_','E','A','M','R','M','_','E','B','M','R','M','_','E','C','M','R','M','_','E','D','M','R','M','_','E','E','M','R','M','_','E','F','M','R','M','_','F','0','M','R','M','_','F','1','M','R','M','_','F','2','M','R','M','_','F','3','M','R','M','_','F','4','M','R','M','_','F','5','M','R','M','_','F','6','M','R','M','_','F','7','M','R','M','_','F','8','M','R','M','_','F','9','M','R','M','_','F','A','M','R','M','_','F','B','M','R','M','_','F','C','M','R','M','_','F','D','M','R','M','_','F','E','M','R','M','_','F','F','M','R','M','r','0','P','r','e','f','i','x','B','y','t','e','P','s','e','u','d','o','R','a','w','F','r','m','R','a','w','F','r','m','D','s','t','R','a','w','F','r','m','D','s','t','S','r','c','R','a','w','F','r','m','I','m','m','1','6','R','a','w','F','r','m','I','m','m','8','R','a','w','F','r','m','M','e','m','O','f','f','s','R','a','w','F','r','m','S','r','c',};
    }
}
