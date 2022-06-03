namespace Z0.llvm.strings
{
    using System;

    using static core;

    public enum X86RegKind : uint
    {
        AH = 0,
        AL = 1,
        AX = 2,
        BH = 3,
        BL = 4,
        BND0 = 5,
        BND1 = 6,
        BND2 = 7,
        BND3 = 8,
        BP = 9,
        BPH = 10,
        BPL = 11,
        BX = 12,
        CH = 13,
        CL = 14,
        CR0 = 15,
        CR1 = 16,
        CR10 = 17,
        CR11 = 18,
        CR12 = 19,
        CR13 = 20,
        CR14 = 21,
        CR15 = 22,
        CR2 = 23,
        CR3 = 24,
        CR4 = 25,
        CR5 = 26,
        CR6 = 27,
        CR7 = 28,
        CR8 = 29,
        CR9 = 30,
        CS = 31,
        CX = 32,
        DF = 33,
        DH = 34,
        DI = 35,
        DIH = 36,
        DIL = 37,
        DL = 38,
        DR0 = 39,
        DR1 = 40,
        DR10 = 41,
        DR11 = 42,
        DR12 = 43,
        DR13 = 44,
        DR14 = 45,
        DR15 = 46,
        DR2 = 47,
        DR3 = 48,
        DR4 = 49,
        DR5 = 50,
        DR6 = 51,
        DR7 = 52,
        DR8 = 53,
        DR9 = 54,
        DS = 55,
        DX = 56,
        EAX = 57,
        EBP = 58,
        EBX = 59,
        ECX = 60,
        EDI = 61,
        EDX = 62,
        EFLAGS = 63,
        EIP = 64,
        EIZ = 65,
        ES = 66,
        ESI = 67,
        ESP = 68,
        FP0 = 69,
        FP1 = 70,
        FP2 = 71,
        FP3 = 72,
        FP4 = 73,
        FP5 = 74,
        FP6 = 75,
        FP7 = 76,
        FPCW = 77,
        FPSW = 78,
        FS = 79,
        GS = 80,
        HAX = 81,
        HBP = 82,
        HBX = 83,
        HCX = 84,
        HDI = 85,
        HDX = 86,
        HIP = 87,
        HSI = 88,
        HSP = 89,
        IP = 90,
        K0 = 91,
        K1 = 92,
        K2 = 93,
        K3 = 94,
        K4 = 95,
        K5 = 96,
        K6 = 97,
        K7 = 98,
        MM0 = 99,
        MM1 = 100,
        MM2 = 101,
        MM3 = 102,
        MM4 = 103,
        MM5 = 104,
        MM6 = 105,
        MM7 = 106,
        MXCSR = 107,
        R10 = 108,
        R10B = 109,
        R10BH = 110,
        R10D = 111,
        R10W = 112,
        R10WH = 113,
        R11 = 114,
        R11B = 115,
        R11BH = 116,
        R11D = 117,
        R11W = 118,
        R11WH = 119,
        R12 = 120,
        R12B = 121,
        R12BH = 122,
        R12D = 123,
        R12W = 124,
        R12WH = 125,
        R13 = 126,
        R13B = 127,
        R13BH = 128,
        R13D = 129,
        R13W = 130,
        R13WH = 131,
        R14 = 132,
        R14B = 133,
        R14BH = 134,
        R14D = 135,
        R14W = 136,
        R14WH = 137,
        R15 = 138,
        R15B = 139,
        R15BH = 140,
        R15D = 141,
        R15W = 142,
        R15WH = 143,
        R8 = 144,
        R8B = 145,
        R8BH = 146,
        R8D = 147,
        R8W = 148,
        R8WH = 149,
        R9 = 150,
        R9B = 151,
        R9BH = 152,
        R9D = 153,
        R9W = 154,
        R9WH = 155,
        RAX = 156,
        RBP = 157,
        RBX = 158,
        RCX = 159,
        RDI = 160,
        RDX = 161,
        RIP = 162,
        RIZ = 163,
        RSI = 164,
        RSP = 165,
        SI = 166,
        SIH = 167,
        SIL = 168,
        SP = 169,
        SPH = 170,
        SPL = 171,
        SS = 172,
        SSP = 173,
        ST0 = 174,
        ST1 = 175,
        ST2 = 176,
        ST3 = 177,
        ST4 = 178,
        ST5 = 179,
        ST6 = 180,
        ST7 = 181,
        TMM0 = 182,
        TMM1 = 183,
        TMM2 = 184,
        TMM3 = 185,
        TMM4 = 186,
        TMM5 = 187,
        TMM6 = 188,
        TMM7 = 189,
        TMMCFG = 190,
        XMM0 = 191,
        XMM1 = 192,
        XMM10 = 193,
        XMM11 = 194,
        XMM12 = 195,
        XMM13 = 196,
        XMM14 = 197,
        XMM15 = 198,
        XMM16 = 199,
        XMM17 = 200,
        XMM18 = 201,
        XMM19 = 202,
        XMM2 = 203,
        XMM20 = 204,
        XMM21 = 205,
        XMM22 = 206,
        XMM23 = 207,
        XMM24 = 208,
        XMM25 = 209,
        XMM26 = 210,
        XMM27 = 211,
        XMM28 = 212,
        XMM29 = 213,
        XMM3 = 214,
        XMM30 = 215,
        XMM31 = 216,
        XMM4 = 217,
        XMM5 = 218,
        XMM6 = 219,
        XMM7 = 220,
        XMM8 = 221,
        XMM9 = 222,
        YMM0 = 223,
        YMM1 = 224,
        YMM10 = 225,
        YMM11 = 226,
        YMM12 = 227,
        YMM13 = 228,
        YMM14 = 229,
        YMM15 = 230,
        YMM16 = 231,
        YMM17 = 232,
        YMM18 = 233,
        YMM19 = 234,
        YMM2 = 235,
        YMM20 = 236,
        YMM21 = 237,
        YMM22 = 238,
        YMM23 = 239,
        YMM24 = 240,
        YMM25 = 241,
        YMM26 = 242,
        YMM27 = 243,
        YMM28 = 244,
        YMM29 = 245,
        YMM3 = 246,
        YMM30 = 247,
        YMM31 = 248,
        YMM4 = 249,
        YMM5 = 250,
        YMM6 = 251,
        YMM7 = 252,
        YMM8 = 253,
        YMM9 = 254,
        ZMM0 = 255,
        ZMM1 = 256,
        ZMM10 = 257,
        ZMM11 = 258,
        ZMM12 = 259,
        ZMM13 = 260,
        ZMM14 = 261,
        ZMM15 = 262,
        ZMM16 = 263,
        ZMM17 = 264,
        ZMM18 = 265,
        ZMM19 = 266,
        ZMM2 = 267,
        ZMM20 = 268,
        ZMM21 = 269,
        ZMM22 = 270,
        ZMM23 = 271,
        ZMM24 = 272,
        ZMM25 = 273,
        ZMM26 = 274,
        ZMM27 = 275,
        ZMM28 = 276,
        ZMM29 = 277,
        ZMM3 = 278,
        ZMM30 = 279,
        ZMM31 = 280,
        ZMM4 = 281,
        ZMM5 = 282,
        ZMM6 = 283,
        ZMM7 = 284,
        ZMM8 = 285,
        ZMM9 = 286,
    }

    public readonly struct X86RegST
    {
        public const uint EntryCount = 287;

        public const uint CharCount = 1069;

        public static MemoryAddress CharBase => address(Data);

        public static MemoryAddress OffsetBase => address(Offsets);

        public static MemoryStrings<X86RegKind> Strings => MemoryStrings.create(Offsets,Data);

        public static ReadOnlySpan<byte> Offsets => new byte[1148]{0x00,0x00,0x00,0x00,0x02,0x00,0x00,0x00,0x04,0x00,0x00,0x00,0x06,0x00,0x00,0x00,0x08,0x00,0x00,0x00,0x0a,0x00,0x00,0x00,0x0e,0x00,0x00,0x00,0x12,0x00,0x00,0x00,0x16,0x00,0x00,0x00,0x1a,0x00,0x00,0x00,0x1c,0x00,0x00,0x00,0x1f,0x00,0x00,0x00,0x22,0x00,0x00,0x00,0x24,0x00,0x00,0x00,0x26,0x00,0x00,0x00,0x28,0x00,0x00,0x00,0x2b,0x00,0x00,0x00,0x2e,0x00,0x00,0x00,0x32,0x00,0x00,0x00,0x36,0x00,0x00,0x00,0x3a,0x00,0x00,0x00,0x3e,0x00,0x00,0x00,0x42,0x00,0x00,0x00,0x46,0x00,0x00,0x00,0x49,0x00,0x00,0x00,0x4c,0x00,0x00,0x00,0x4f,0x00,0x00,0x00,0x52,0x00,0x00,0x00,0x55,0x00,0x00,0x00,0x58,0x00,0x00,0x00,0x5b,0x00,0x00,0x00,0x5e,0x00,0x00,0x00,0x60,0x00,0x00,0x00,0x62,0x00,0x00,0x00,0x64,0x00,0x00,0x00,0x66,0x00,0x00,0x00,0x68,0x00,0x00,0x00,0x6b,0x00,0x00,0x00,0x6e,0x00,0x00,0x00,0x70,0x00,0x00,0x00,0x73,0x00,0x00,0x00,0x76,0x00,0x00,0x00,0x7a,0x00,0x00,0x00,0x7e,0x00,0x00,0x00,0x82,0x00,0x00,0x00,0x86,0x00,0x00,0x00,0x8a,0x00,0x00,0x00,0x8e,0x00,0x00,0x00,0x91,0x00,0x00,0x00,0x94,0x00,0x00,0x00,0x97,0x00,0x00,0x00,0x9a,0x00,0x00,0x00,0x9d,0x00,0x00,0x00,0xa0,0x00,0x00,0x00,0xa3,0x00,0x00,0x00,0xa6,0x00,0x00,0x00,0xa8,0x00,0x00,0x00,0xaa,0x00,0x00,0x00,0xad,0x00,0x00,0x00,0xb0,0x00,0x00,0x00,0xb3,0x00,0x00,0x00,0xb6,0x00,0x00,0x00,0xb9,0x00,0x00,0x00,0xbc,0x00,0x00,0x00,0xc2,0x00,0x00,0x00,0xc5,0x00,0x00,0x00,0xc8,0x00,0x00,0x00,0xca,0x00,0x00,0x00,0xcd,0x00,0x00,0x00,0xd0,0x00,0x00,0x00,0xd3,0x00,0x00,0x00,0xd6,0x00,0x00,0x00,0xd9,0x00,0x00,0x00,0xdc,0x00,0x00,0x00,0xdf,0x00,0x00,0x00,0xe2,0x00,0x00,0x00,0xe5,0x00,0x00,0x00,0xe8,0x00,0x00,0x00,0xec,0x00,0x00,0x00,0xf0,0x00,0x00,0x00,0xf2,0x00,0x00,0x00,0xf4,0x00,0x00,0x00,0xf7,0x00,0x00,0x00,0xfa,0x00,0x00,0x00,0xfd,0x00,0x00,0x00,0x00,0x01,0x00,0x00,0x03,0x01,0x00,0x00,0x06,0x01,0x00,0x00,0x09,0x01,0x00,0x00,0x0c,0x01,0x00,0x00,0x0f,0x01,0x00,0x00,0x11,0x01,0x00,0x00,0x13,0x01,0x00,0x00,0x15,0x01,0x00,0x00,0x17,0x01,0x00,0x00,0x19,0x01,0x00,0x00,0x1b,0x01,0x00,0x00,0x1d,0x01,0x00,0x00,0x1f,0x01,0x00,0x00,0x21,0x01,0x00,0x00,0x24,0x01,0x00,0x00,0x27,0x01,0x00,0x00,0x2a,0x01,0x00,0x00,0x2d,0x01,0x00,0x00,0x30,0x01,0x00,0x00,0x33,0x01,0x00,0x00,0x36,0x01,0x00,0x00,0x39,0x01,0x00,0x00,0x3e,0x01,0x00,0x00,0x41,0x01,0x00,0x00,0x45,0x01,0x00,0x00,0x4a,0x01,0x00,0x00,0x4e,0x01,0x00,0x00,0x52,0x01,0x00,0x00,0x57,0x01,0x00,0x00,0x5a,0x01,0x00,0x00,0x5e,0x01,0x00,0x00,0x63,0x01,0x00,0x00,0x67,0x01,0x00,0x00,0x6b,0x01,0x00,0x00,0x70,0x01,0x00,0x00,0x73,0x01,0x00,0x00,0x77,0x01,0x00,0x00,0x7c,0x01,0x00,0x00,0x80,0x01,0x00,0x00,0x84,0x01,0x00,0x00,0x89,0x01,0x00,0x00,0x8c,0x01,0x00,0x00,0x90,0x01,0x00,0x00,0x95,0x01,0x00,0x00,0x99,0x01,0x00,0x00,0x9d,0x01,0x00,0x00,0xa2,0x01,0x00,0x00,0xa5,0x01,0x00,0x00,0xa9,0x01,0x00,0x00,0xae,0x01,0x00,0x00,0xb2,0x01,0x00,0x00,0xb6,0x01,0x00,0x00,0xbb,0x01,0x00,0x00,0xbe,0x01,0x00,0x00,0xc2,0x01,0x00,0x00,0xc7,0x01,0x00,0x00,0xcb,0x01,0x00,0x00,0xcf,0x01,0x00,0x00,0xd4,0x01,0x00,0x00,0xd6,0x01,0x00,0x00,0xd9,0x01,0x00,0x00,0xdd,0x01,0x00,0x00,0xe0,0x01,0x00,0x00,0xe3,0x01,0x00,0x00,0xe7,0x01,0x00,0x00,0xe9,0x01,0x00,0x00,0xec,0x01,0x00,0x00,0xf0,0x01,0x00,0x00,0xf3,0x01,0x00,0x00,0xf6,0x01,0x00,0x00,0xfa,0x01,0x00,0x00,0xfd,0x01,0x00,0x00,0x00,0x02,0x00,0x00,0x03,0x02,0x00,0x00,0x06,0x02,0x00,0x00,0x09,0x02,0x00,0x00,0x0c,0x02,0x00,0x00,0x0f,0x02,0x00,0x00,0x12,0x02,0x00,0x00,0x15,0x02,0x00,0x00,0x18,0x02,0x00,0x00,0x1a,0x02,0x00,0x00,0x1d,0x02,0x00,0x00,0x20,0x02,0x00,0x00,0x22,0x02,0x00,0x00,0x25,0x02,0x00,0x00,0x28,0x02,0x00,0x00,0x2a,0x02,0x00,0x00,0x2d,0x02,0x00,0x00,0x30,0x02,0x00,0x00,0x33,0x02,0x00,0x00,0x36,0x02,0x00,0x00,0x39,0x02,0x00,0x00,0x3c,0x02,0x00,0x00,0x3f,0x02,0x00,0x00,0x42,0x02,0x00,0x00,0x45,0x02,0x00,0x00,0x49,0x02,0x00,0x00,0x4d,0x02,0x00,0x00,0x51,0x02,0x00,0x00,0x55,0x02,0x00,0x00,0x59,0x02,0x00,0x00,0x5d,0x02,0x00,0x00,0x61,0x02,0x00,0x00,0x65,0x02,0x00,0x00,0x6b,0x02,0x00,0x00,0x6f,0x02,0x00,0x00,0x73,0x02,0x00,0x00,0x78,0x02,0x00,0x00,0x7d,0x02,0x00,0x00,0x82,0x02,0x00,0x00,0x87,0x02,0x00,0x00,0x8c,0x02,0x00,0x00,0x91,0x02,0x00,0x00,0x96,0x02,0x00,0x00,0x9b,0x02,0x00,0x00,0xa0,0x02,0x00,0x00,0xa5,0x02,0x00,0x00,0xa9,0x02,0x00,0x00,0xae,0x02,0x00,0x00,0xb3,0x02,0x00,0x00,0xb8,0x02,0x00,0x00,0xbd,0x02,0x00,0x00,0xc2,0x02,0x00,0x00,0xc7,0x02,0x00,0x00,0xcc,0x02,0x00,0x00,0xd1,0x02,0x00,0x00,0xd6,0x02,0x00,0x00,0xdb,0x02,0x00,0x00,0xdf,0x02,0x00,0x00,0xe4,0x02,0x00,0x00,0xe9,0x02,0x00,0x00,0xed,0x02,0x00,0x00,0xf1,0x02,0x00,0x00,0xf5,0x02,0x00,0x00,0xf9,0x02,0x00,0x00,0xfd,0x02,0x00,0x00,0x01,0x03,0x00,0x00,0x05,0x03,0x00,0x00,0x09,0x03,0x00,0x00,0x0e,0x03,0x00,0x00,0x13,0x03,0x00,0x00,0x18,0x03,0x00,0x00,0x1d,0x03,0x00,0x00,0x22,0x03,0x00,0x00,0x27,0x03,0x00,0x00,0x2c,0x03,0x00,0x00,0x31,0x03,0x00,0x00,0x36,0x03,0x00,0x00,0x3b,0x03,0x00,0x00,0x3f,0x03,0x00,0x00,0x44,0x03,0x00,0x00,0x49,0x03,0x00,0x00,0x4e,0x03,0x00,0x00,0x53,0x03,0x00,0x00,0x58,0x03,0x00,0x00,0x5d,0x03,0x00,0x00,0x62,0x03,0x00,0x00,0x67,0x03,0x00,0x00,0x6c,0x03,0x00,0x00,0x71,0x03,0x00,0x00,0x75,0x03,0x00,0x00,0x7a,0x03,0x00,0x00,0x7f,0x03,0x00,0x00,0x83,0x03,0x00,0x00,0x87,0x03,0x00,0x00,0x8b,0x03,0x00,0x00,0x8f,0x03,0x00,0x00,0x93,0x03,0x00,0x00,0x97,0x03,0x00,0x00,0x9b,0x03,0x00,0x00,0x9f,0x03,0x00,0x00,0xa4,0x03,0x00,0x00,0xa9,0x03,0x00,0x00,0xae,0x03,0x00,0x00,0xb3,0x03,0x00,0x00,0xb8,0x03,0x00,0x00,0xbd,0x03,0x00,0x00,0xc2,0x03,0x00,0x00,0xc7,0x03,0x00,0x00,0xcc,0x03,0x00,0x00,0xd1,0x03,0x00,0x00,0xd5,0x03,0x00,0x00,0xda,0x03,0x00,0x00,0xdf,0x03,0x00,0x00,0xe4,0x03,0x00,0x00,0xe9,0x03,0x00,0x00,0xee,0x03,0x00,0x00,0xf3,0x03,0x00,0x00,0xf8,0x03,0x00,0x00,0xfd,0x03,0x00,0x00,0x02,0x04,0x00,0x00,0x07,0x04,0x00,0x00,0x0b,0x04,0x00,0x00,0x10,0x04,0x00,0x00,0x15,0x04,0x00,0x00,0x19,0x04,0x00,0x00,0x1d,0x04,0x00,0x00,0x21,0x04,0x00,0x00,0x25,0x04,0x00,0x00,0x29,0x04,0x00,0x00};

        public static ReadOnlySpan<char> Data => new char[1069]{'A','H','A','L','A','X','B','H','B','L','B','N','D','0','B','N','D','1','B','N','D','2','B','N','D','3','B','P','B','P','H','B','P','L','B','X','C','H','C','L','C','R','0','C','R','1','C','R','1','0','C','R','1','1','C','R','1','2','C','R','1','3','C','R','1','4','C','R','1','5','C','R','2','C','R','3','C','R','4','C','R','5','C','R','6','C','R','7','C','R','8','C','R','9','C','S','C','X','D','F','D','H','D','I','D','I','H','D','I','L','D','L','D','R','0','D','R','1','D','R','1','0','D','R','1','1','D','R','1','2','D','R','1','3','D','R','1','4','D','R','1','5','D','R','2','D','R','3','D','R','4','D','R','5','D','R','6','D','R','7','D','R','8','D','R','9','D','S','D','X','E','A','X','E','B','P','E','B','X','E','C','X','E','D','I','E','D','X','E','F','L','A','G','S','E','I','P','E','I','Z','E','S','E','S','I','E','S','P','F','P','0','F','P','1','F','P','2','F','P','3','F','P','4','F','P','5','F','P','6','F','P','7','F','P','C','W','F','P','S','W','F','S','G','S','H','A','X','H','B','P','H','B','X','H','C','X','H','D','I','H','D','X','H','I','P','H','S','I','H','S','P','I','P','K','0','K','1','K','2','K','3','K','4','K','5','K','6','K','7','M','M','0','M','M','1','M','M','2','M','M','3','M','M','4','M','M','5','M','M','6','M','M','7','M','X','C','S','R','R','1','0','R','1','0','B','R','1','0','B','H','R','1','0','D','R','1','0','W','R','1','0','W','H','R','1','1','R','1','1','B','R','1','1','B','H','R','1','1','D','R','1','1','W','R','1','1','W','H','R','1','2','R','1','2','B','R','1','2','B','H','R','1','2','D','R','1','2','W','R','1','2','W','H','R','1','3','R','1','3','B','R','1','3','B','H','R','1','3','D','R','1','3','W','R','1','3','W','H','R','1','4','R','1','4','B','R','1','4','B','H','R','1','4','D','R','1','4','W','R','1','4','W','H','R','1','5','R','1','5','B','R','1','5','B','H','R','1','5','D','R','1','5','W','R','1','5','W','H','R','8','R','8','B','R','8','B','H','R','8','D','R','8','W','R','8','W','H','R','9','R','9','B','R','9','B','H','R','9','D','R','9','W','R','9','W','H','R','A','X','R','B','P','R','B','X','R','C','X','R','D','I','R','D','X','R','I','P','R','I','Z','R','S','I','R','S','P','S','I','S','I','H','S','I','L','S','P','S','P','H','S','P','L','S','S','S','S','P','S','T','0','S','T','1','S','T','2','S','T','3','S','T','4','S','T','5','S','T','6','S','T','7','T','M','M','0','T','M','M','1','T','M','M','2','T','M','M','3','T','M','M','4','T','M','M','5','T','M','M','6','T','M','M','7','T','M','M','C','F','G','X','M','M','0','X','M','M','1','X','M','M','1','0','X','M','M','1','1','X','M','M','1','2','X','M','M','1','3','X','M','M','1','4','X','M','M','1','5','X','M','M','1','6','X','M','M','1','7','X','M','M','1','8','X','M','M','1','9','X','M','M','2','X','M','M','2','0','X','M','M','2','1','X','M','M','2','2','X','M','M','2','3','X','M','M','2','4','X','M','M','2','5','X','M','M','2','6','X','M','M','2','7','X','M','M','2','8','X','M','M','2','9','X','M','M','3','X','M','M','3','0','X','M','M','3','1','X','M','M','4','X','M','M','5','X','M','M','6','X','M','M','7','X','M','M','8','X','M','M','9','Y','M','M','0','Y','M','M','1','Y','M','M','1','0','Y','M','M','1','1','Y','M','M','1','2','Y','M','M','1','3','Y','M','M','1','4','Y','M','M','1','5','Y','M','M','1','6','Y','M','M','1','7','Y','M','M','1','8','Y','M','M','1','9','Y','M','M','2','Y','M','M','2','0','Y','M','M','2','1','Y','M','M','2','2','Y','M','M','2','3','Y','M','M','2','4','Y','M','M','2','5','Y','M','M','2','6','Y','M','M','2','7','Y','M','M','2','8','Y','M','M','2','9','Y','M','M','3','Y','M','M','3','0','Y','M','M','3','1','Y','M','M','4','Y','M','M','5','Y','M','M','6','Y','M','M','7','Y','M','M','8','Y','M','M','9','Z','M','M','0','Z','M','M','1','Z','M','M','1','0','Z','M','M','1','1','Z','M','M','1','2','Z','M','M','1','3','Z','M','M','1','4','Z','M','M','1','5','Z','M','M','1','6','Z','M','M','1','7','Z','M','M','1','8','Z','M','M','1','9','Z','M','M','2','Z','M','M','2','0','Z','M','M','2','1','Z','M','M','2','2','Z','M','M','2','3','Z','M','M','2','4','Z','M','M','2','5','Z','M','M','2','6','Z','M','M','2','7','Z','M','M','2','8','Z','M','M','2','9','Z','M','M','3','Z','M','M','3','0','Z','M','M','3','1','Z','M','M','4','Z','M','M','5','Z','M','M','6','Z','M','M','7','Z','M','M','8','Z','M','M','9',};
    }
}
