namespace Z0.llvm.strings
{
    using System;

    using static core;

    public enum DAGOperandKind : uint
    {
        AVX512RC = 0,
        BNDR = 1,
        CCR = 2,
        CONTROL_REG = 3,
        DEBUG_REG = 4,
        DFCCR = 5,
        FPCCR = 6,
        FR32 = 7,
        FR32X = 8,
        FR64 = 9,
        FR64X = 10,
        GR16 = 11,
        GR16_ABCD = 12,
        GR16_NOREX = 13,
        GR16orGR32orGR64 = 14,
        GR32 = 15,
        GR32_ABCD = 16,
        GR32_AD = 17,
        GR32_BPSP = 18,
        GR32_BSI = 19,
        GR32_CB = 20,
        GR32_DC = 21,
        GR32_DIBP = 22,
        GR32_NOREX = 23,
        GR32_NOREX_NOSP = 24,
        GR32_NOSP = 25,
        GR32_SIDI = 26,
        GR32_TC = 27,
        GR32orGR64 = 28,
        GR64 = 29,
        GR64_ABCD = 30,
        GR64_AD = 31,
        GR64_NOREX = 32,
        GR64_NOREX_NOSP = 33,
        GR64_NOSP = 34,
        GR64_TC = 35,
        GR64_TCW64 = 36,
        GR8 = 37,
        GR8_ABCD_H = 38,
        GR8_ABCD_L = 39,
        GR8_NOREX = 40,
        GRH16 = 41,
        GRH8 = 42,
        LOW32_ADDR_ACCESS = 43,
        LOW32_ADDR_ACCESS_RBP = 44,
        RFP32 = 45,
        RFP64 = 46,
        RFP80 = 47,
        RFP80_7 = 48,
        RST = 49,
        RSTi = 50,
        SEGMENT_REG = 51,
        TILE = 52,
        VK1 = 53,
        VK16 = 54,
        VK16PAIR = 55,
        VK16Pair = 56,
        VK16WM = 57,
        VK1PAIR = 58,
        VK1Pair = 59,
        VK1WM = 60,
        VK2 = 61,
        VK2PAIR = 62,
        VK2Pair = 63,
        VK2WM = 64,
        VK32 = 65,
        VK32WM = 66,
        VK4 = 67,
        VK4PAIR = 68,
        VK4Pair = 69,
        VK4WM = 70,
        VK64 = 71,
        VK64WM = 72,
        VK8 = 73,
        VK8PAIR = 74,
        VK8Pair = 75,
        VK8WM = 76,
        VR128 = 77,
        VR128X = 78,
        VR256 = 79,
        VR256X = 80,
        VR512 = 81,
        VR512_0_15 = 82,
        VR64 = 83,
        anymem = 84,
        brtarget = 85,
        brtarget16 = 86,
        brtarget32 = 87,
        brtarget8 = 88,
        ccode = 89,
        dstidx16 = 90,
        dstidx32 = 91,
        dstidx64 = 92,
        dstidx8 = 93,
        f128mem = 94,
        f256mem = 95,
        f32imm = 96,
        f32mem = 97,
        f512mem = 98,
        f64imm = 99,
        f64mem = 100,
        f80mem = 101,
        i128mem = 102,
        i16i8imm = 103,
        i16imm = 104,
        i16imm_brtarget = 105,
        i16mem = 106,
        i16u8imm = 107,
        i1imm = 108,
        i256mem = 109,
        i32i8imm = 110,
        i32imm = 111,
        i32imm_brtarget = 112,
        i32mem = 113,
        i32mem_TC = 114,
        i32u8imm = 115,
        i512mem = 116,
        i64i32imm = 117,
        i64i32imm_brtarget = 118,
        i64i8imm = 119,
        i64imm = 120,
        i64mem = 121,
        i64mem_TC = 122,
        i64u8imm = 123,
        i8imm = 124,
        i8mem = 125,
        i8mem_NOREX = 126,
        lea64_32mem = 127,
        lea64mem = 128,
        offset16_16 = 129,
        offset16_32 = 130,
        offset16_8 = 131,
        offset32_16 = 132,
        offset32_32 = 133,
        offset32_64 = 134,
        offset32_8 = 135,
        offset64_16 = 136,
        offset64_32 = 137,
        offset64_64 = 138,
        offset64_8 = 139,
        opaquemem = 140,
        ptype0 = 141,
        ptype1 = 142,
        ptype2 = 143,
        ptype3 = 144,
        ptype4 = 145,
        ptype5 = 146,
        sdmem = 147,
        sibmem = 148,
        srcidx16 = 149,
        srcidx32 = 150,
        srcidx64 = 151,
        srcidx8 = 152,
        ssmem = 153,
        type0 = 154,
        type1 = 155,
        type2 = 156,
        type3 = 157,
        type4 = 158,
        type5 = 159,
        u4imm = 160,
        u8imm = 161,
        untyped_imm_0 = 162,
        vx128mem = 163,
        vx128xmem = 164,
        vx256mem = 165,
        vx256xmem = 166,
        vx64mem = 167,
        vx64xmem = 168,
        vy128mem = 169,
        vy128xmem = 170,
        vy256mem = 171,
        vy256xmem = 172,
        vy512xmem = 173,
        vz256mem = 174,
        vz512mem = 175,
    }

    public readonly struct DAGOperandST
    {
        public const uint EntryCount = 176;

        public const uint CharCount = 1317;

        public static MemoryAddress CharBase => address(Data);

        public static MemoryAddress OffsetBase => address(Offsets);

        public static MemoryStrings<DAGOperandKind> Strings => memory.strings(Offsets,Data);

        public static ReadOnlySpan<byte> Offsets => new byte[704]{0x00,0x00,0x00,0x00,0x08,0x00,0x00,0x00,0x0c,0x00,0x00,0x00,0x0f,0x00,0x00,0x00,0x1a,0x00,0x00,0x00,0x23,0x00,0x00,0x00,0x28,0x00,0x00,0x00,0x2d,0x00,0x00,0x00,0x31,0x00,0x00,0x00,0x36,0x00,0x00,0x00,0x3a,0x00,0x00,0x00,0x3f,0x00,0x00,0x00,0x43,0x00,0x00,0x00,0x4c,0x00,0x00,0x00,0x56,0x00,0x00,0x00,0x66,0x00,0x00,0x00,0x6a,0x00,0x00,0x00,0x73,0x00,0x00,0x00,0x7a,0x00,0x00,0x00,0x83,0x00,0x00,0x00,0x8b,0x00,0x00,0x00,0x92,0x00,0x00,0x00,0x99,0x00,0x00,0x00,0xa2,0x00,0x00,0x00,0xac,0x00,0x00,0x00,0xbb,0x00,0x00,0x00,0xc4,0x00,0x00,0x00,0xcd,0x00,0x00,0x00,0xd4,0x00,0x00,0x00,0xde,0x00,0x00,0x00,0xe2,0x00,0x00,0x00,0xeb,0x00,0x00,0x00,0xf2,0x00,0x00,0x00,0xfc,0x00,0x00,0x00,0x0b,0x01,0x00,0x00,0x14,0x01,0x00,0x00,0x1b,0x01,0x00,0x00,0x25,0x01,0x00,0x00,0x28,0x01,0x00,0x00,0x32,0x01,0x00,0x00,0x3c,0x01,0x00,0x00,0x45,0x01,0x00,0x00,0x4a,0x01,0x00,0x00,0x4e,0x01,0x00,0x00,0x5f,0x01,0x00,0x00,0x74,0x01,0x00,0x00,0x79,0x01,0x00,0x00,0x7e,0x01,0x00,0x00,0x83,0x01,0x00,0x00,0x8a,0x01,0x00,0x00,0x8d,0x01,0x00,0x00,0x91,0x01,0x00,0x00,0x9c,0x01,0x00,0x00,0xa0,0x01,0x00,0x00,0xa3,0x01,0x00,0x00,0xa7,0x01,0x00,0x00,0xaf,0x01,0x00,0x00,0xb7,0x01,0x00,0x00,0xbd,0x01,0x00,0x00,0xc4,0x01,0x00,0x00,0xcb,0x01,0x00,0x00,0xd0,0x01,0x00,0x00,0xd3,0x01,0x00,0x00,0xda,0x01,0x00,0x00,0xe1,0x01,0x00,0x00,0xe6,0x01,0x00,0x00,0xea,0x01,0x00,0x00,0xf0,0x01,0x00,0x00,0xf3,0x01,0x00,0x00,0xfa,0x01,0x00,0x00,0x01,0x02,0x00,0x00,0x06,0x02,0x00,0x00,0x0a,0x02,0x00,0x00,0x10,0x02,0x00,0x00,0x13,0x02,0x00,0x00,0x1a,0x02,0x00,0x00,0x21,0x02,0x00,0x00,0x26,0x02,0x00,0x00,0x2b,0x02,0x00,0x00,0x31,0x02,0x00,0x00,0x36,0x02,0x00,0x00,0x3c,0x02,0x00,0x00,0x41,0x02,0x00,0x00,0x4b,0x02,0x00,0x00,0x4f,0x02,0x00,0x00,0x55,0x02,0x00,0x00,0x5d,0x02,0x00,0x00,0x67,0x02,0x00,0x00,0x71,0x02,0x00,0x00,0x7a,0x02,0x00,0x00,0x7f,0x02,0x00,0x00,0x87,0x02,0x00,0x00,0x8f,0x02,0x00,0x00,0x97,0x02,0x00,0x00,0x9e,0x02,0x00,0x00,0xa5,0x02,0x00,0x00,0xac,0x02,0x00,0x00,0xb2,0x02,0x00,0x00,0xb8,0x02,0x00,0x00,0xbf,0x02,0x00,0x00,0xc5,0x02,0x00,0x00,0xcb,0x02,0x00,0x00,0xd1,0x02,0x00,0x00,0xd8,0x02,0x00,0x00,0xe0,0x02,0x00,0x00,0xe6,0x02,0x00,0x00,0xf5,0x02,0x00,0x00,0xfb,0x02,0x00,0x00,0x03,0x03,0x00,0x00,0x08,0x03,0x00,0x00,0x0f,0x03,0x00,0x00,0x17,0x03,0x00,0x00,0x1d,0x03,0x00,0x00,0x2c,0x03,0x00,0x00,0x32,0x03,0x00,0x00,0x3b,0x03,0x00,0x00,0x43,0x03,0x00,0x00,0x4a,0x03,0x00,0x00,0x53,0x03,0x00,0x00,0x65,0x03,0x00,0x00,0x6d,0x03,0x00,0x00,0x73,0x03,0x00,0x00,0x79,0x03,0x00,0x00,0x82,0x03,0x00,0x00,0x8a,0x03,0x00,0x00,0x8f,0x03,0x00,0x00,0x94,0x03,0x00,0x00,0x9f,0x03,0x00,0x00,0xaa,0x03,0x00,0x00,0xb2,0x03,0x00,0x00,0xbd,0x03,0x00,0x00,0xc8,0x03,0x00,0x00,0xd2,0x03,0x00,0x00,0xdd,0x03,0x00,0x00,0xe8,0x03,0x00,0x00,0xf3,0x03,0x00,0x00,0xfd,0x03,0x00,0x00,0x08,0x04,0x00,0x00,0x13,0x04,0x00,0x00,0x1e,0x04,0x00,0x00,0x28,0x04,0x00,0x00,0x31,0x04,0x00,0x00,0x37,0x04,0x00,0x00,0x3d,0x04,0x00,0x00,0x43,0x04,0x00,0x00,0x49,0x04,0x00,0x00,0x4f,0x04,0x00,0x00,0x55,0x04,0x00,0x00,0x5a,0x04,0x00,0x00,0x60,0x04,0x00,0x00,0x68,0x04,0x00,0x00,0x70,0x04,0x00,0x00,0x78,0x04,0x00,0x00,0x7f,0x04,0x00,0x00,0x84,0x04,0x00,0x00,0x89,0x04,0x00,0x00,0x8e,0x04,0x00,0x00,0x93,0x04,0x00,0x00,0x98,0x04,0x00,0x00,0x9d,0x04,0x00,0x00,0xa2,0x04,0x00,0x00,0xa7,0x04,0x00,0x00,0xac,0x04,0x00,0x00,0xb9,0x04,0x00,0x00,0xc1,0x04,0x00,0x00,0xca,0x04,0x00,0x00,0xd2,0x04,0x00,0x00,0xdb,0x04,0x00,0x00,0xe2,0x04,0x00,0x00,0xea,0x04,0x00,0x00,0xf2,0x04,0x00,0x00,0xfb,0x04,0x00,0x00,0x03,0x05,0x00,0x00,0x0c,0x05,0x00,0x00,0x15,0x05,0x00,0x00,0x1d,0x05,0x00,0x00};

        public static ReadOnlySpan<char> Data => new char[1317]{'A','V','X','5','1','2','R','C','B','N','D','R','C','C','R','C','O','N','T','R','O','L','_','R','E','G','D','E','B','U','G','_','R','E','G','D','F','C','C','R','F','P','C','C','R','F','R','3','2','F','R','3','2','X','F','R','6','4','F','R','6','4','X','G','R','1','6','G','R','1','6','_','A','B','C','D','G','R','1','6','_','N','O','R','E','X','G','R','1','6','o','r','G','R','3','2','o','r','G','R','6','4','G','R','3','2','G','R','3','2','_','A','B','C','D','G','R','3','2','_','A','D','G','R','3','2','_','B','P','S','P','G','R','3','2','_','B','S','I','G','R','3','2','_','C','B','G','R','3','2','_','D','C','G','R','3','2','_','D','I','B','P','G','R','3','2','_','N','O','R','E','X','G','R','3','2','_','N','O','R','E','X','_','N','O','S','P','G','R','3','2','_','N','O','S','P','G','R','3','2','_','S','I','D','I','G','R','3','2','_','T','C','G','R','3','2','o','r','G','R','6','4','G','R','6','4','G','R','6','4','_','A','B','C','D','G','R','6','4','_','A','D','G','R','6','4','_','N','O','R','E','X','G','R','6','4','_','N','O','R','E','X','_','N','O','S','P','G','R','6','4','_','N','O','S','P','G','R','6','4','_','T','C','G','R','6','4','_','T','C','W','6','4','G','R','8','G','R','8','_','A','B','C','D','_','H','G','R','8','_','A','B','C','D','_','L','G','R','8','_','N','O','R','E','X','G','R','H','1','6','G','R','H','8','L','O','W','3','2','_','A','D','D','R','_','A','C','C','E','S','S','L','O','W','3','2','_','A','D','D','R','_','A','C','C','E','S','S','_','R','B','P','R','F','P','3','2','R','F','P','6','4','R','F','P','8','0','R','F','P','8','0','_','7','R','S','T','R','S','T','i','S','E','G','M','E','N','T','_','R','E','G','T','I','L','E','V','K','1','V','K','1','6','V','K','1','6','P','A','I','R','V','K','1','6','P','a','i','r','V','K','1','6','W','M','V','K','1','P','A','I','R','V','K','1','P','a','i','r','V','K','1','W','M','V','K','2','V','K','2','P','A','I','R','V','K','2','P','a','i','r','V','K','2','W','M','V','K','3','2','V','K','3','2','W','M','V','K','4','V','K','4','P','A','I','R','V','K','4','P','a','i','r','V','K','4','W','M','V','K','6','4','V','K','6','4','W','M','V','K','8','V','K','8','P','A','I','R','V','K','8','P','a','i','r','V','K','8','W','M','V','R','1','2','8','V','R','1','2','8','X','V','R','2','5','6','V','R','2','5','6','X','V','R','5','1','2','V','R','5','1','2','_','0','_','1','5','V','R','6','4','a','n','y','m','e','m','b','r','t','a','r','g','e','t','b','r','t','a','r','g','e','t','1','6','b','r','t','a','r','g','e','t','3','2','b','r','t','a','r','g','e','t','8','c','c','o','d','e','d','s','t','i','d','x','1','6','d','s','t','i','d','x','3','2','d','s','t','i','d','x','6','4','d','s','t','i','d','x','8','f','1','2','8','m','e','m','f','2','5','6','m','e','m','f','3','2','i','m','m','f','3','2','m','e','m','f','5','1','2','m','e','m','f','6','4','i','m','m','f','6','4','m','e','m','f','8','0','m','e','m','i','1','2','8','m','e','m','i','1','6','i','8','i','m','m','i','1','6','i','m','m','i','1','6','i','m','m','_','b','r','t','a','r','g','e','t','i','1','6','m','e','m','i','1','6','u','8','i','m','m','i','1','i','m','m','i','2','5','6','m','e','m','i','3','2','i','8','i','m','m','i','3','2','i','m','m','i','3','2','i','m','m','_','b','r','t','a','r','g','e','t','i','3','2','m','e','m','i','3','2','m','e','m','_','T','C','i','3','2','u','8','i','m','m','i','5','1','2','m','e','m','i','6','4','i','3','2','i','m','m','i','6','4','i','3','2','i','m','m','_','b','r','t','a','r','g','e','t','i','6','4','i','8','i','m','m','i','6','4','i','m','m','i','6','4','m','e','m','i','6','4','m','e','m','_','T','C','i','6','4','u','8','i','m','m','i','8','i','m','m','i','8','m','e','m','i','8','m','e','m','_','N','O','R','E','X','l','e','a','6','4','_','3','2','m','e','m','l','e','a','6','4','m','e','m','o','f','f','s','e','t','1','6','_','1','6','o','f','f','s','e','t','1','6','_','3','2','o','f','f','s','e','t','1','6','_','8','o','f','f','s','e','t','3','2','_','1','6','o','f','f','s','e','t','3','2','_','3','2','o','f','f','s','e','t','3','2','_','6','4','o','f','f','s','e','t','3','2','_','8','o','f','f','s','e','t','6','4','_','1','6','o','f','f','s','e','t','6','4','_','3','2','o','f','f','s','e','t','6','4','_','6','4','o','f','f','s','e','t','6','4','_','8','o','p','a','q','u','e','m','e','m','p','t','y','p','e','0','p','t','y','p','e','1','p','t','y','p','e','2','p','t','y','p','e','3','p','t','y','p','e','4','p','t','y','p','e','5','s','d','m','e','m','s','i','b','m','e','m','s','r','c','i','d','x','1','6','s','r','c','i','d','x','3','2','s','r','c','i','d','x','6','4','s','r','c','i','d','x','8','s','s','m','e','m','t','y','p','e','0','t','y','p','e','1','t','y','p','e','2','t','y','p','e','3','t','y','p','e','4','t','y','p','e','5','u','4','i','m','m','u','8','i','m','m','u','n','t','y','p','e','d','_','i','m','m','_','0','v','x','1','2','8','m','e','m','v','x','1','2','8','x','m','e','m','v','x','2','5','6','m','e','m','v','x','2','5','6','x','m','e','m','v','x','6','4','m','e','m','v','x','6','4','x','m','e','m','v','y','1','2','8','m','e','m','v','y','1','2','8','x','m','e','m','v','y','2','5','6','m','e','m','v','y','2','5','6','x','m','e','m','v','y','5','1','2','x','m','e','m','v','z','2','5','6','m','e','m','v','z','5','1','2','m','e','m',};
    }

}
