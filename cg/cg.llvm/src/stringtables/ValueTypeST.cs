namespace Z0.llvm.strings
{
    using System;

    using static core;

    public enum ValueTypeKind : uint
    {
        Any = 0,
        FlagVT = 1,
        MetadataVT = 2,
        OtherVT = 3,
        bf16 = 4,
        externref = 5,
        f128 = 6,
        f16 = 7,
        f32 = 8,
        f64 = 9,
        f80 = 10,
        fAny = 11,
        funcref = 12,
        i1 = 13,
        i128 = 14,
        i16 = 15,
        i32 = 16,
        i64 = 17,
        i64x8 = 18,
        i8 = 19,
        iAny = 20,
        iPTR = 21,
        iPTRAny = 22,
        isVoid = 23,
        nxv16f16 = 24,
        nxv16f32 = 25,
        nxv16i1 = 26,
        nxv16i16 = 27,
        nxv16i32 = 28,
        nxv16i64 = 29,
        nxv16i8 = 30,
        nxv1bf16 = 31,
        nxv1f16 = 32,
        nxv1f32 = 33,
        nxv1f64 = 34,
        nxv1i1 = 35,
        nxv1i16 = 36,
        nxv1i32 = 37,
        nxv1i64 = 38,
        nxv1i8 = 39,
        nxv2bf16 = 40,
        nxv2f16 = 41,
        nxv2f32 = 42,
        nxv2f64 = 43,
        nxv2i1 = 44,
        nxv2i16 = 45,
        nxv2i32 = 46,
        nxv2i64 = 47,
        nxv2i8 = 48,
        nxv32f16 = 49,
        nxv32i1 = 50,
        nxv32i16 = 51,
        nxv32i32 = 52,
        nxv32i64 = 53,
        nxv32i8 = 54,
        nxv4bf16 = 55,
        nxv4f16 = 56,
        nxv4f32 = 57,
        nxv4f64 = 58,
        nxv4i1 = 59,
        nxv4i16 = 60,
        nxv4i32 = 61,
        nxv4i64 = 62,
        nxv4i8 = 63,
        nxv64i1 = 64,
        nxv64i8 = 65,
        nxv8bf16 = 66,
        nxv8f16 = 67,
        nxv8f32 = 68,
        nxv8f64 = 69,
        nxv8i1 = 70,
        nxv8i16 = 71,
        nxv8i32 = 72,
        nxv8i64 = 73,
        nxv8i8 = 74,
        ppcf128 = 75,
        token = 76,
        untyped = 77,
        v1024f32 = 78,
        v1024i1 = 79,
        v1024i32 = 80,
        v1024i8 = 81,
        v128bf16 = 82,
        v128f16 = 83,
        v128f32 = 84,
        v128f64 = 85,
        v128i1 = 86,
        v128i16 = 87,
        v128i32 = 88,
        v128i64 = 89,
        v128i8 = 90,
        v16bf16 = 91,
        v16f16 = 92,
        v16f32 = 93,
        v16f64 = 94,
        v16i1 = 95,
        v16i16 = 96,
        v16i32 = 97,
        v16i64 = 98,
        v16i8 = 99,
        v1f16 = 100,
        v1f32 = 101,
        v1f64 = 102,
        v1i1 = 103,
        v1i128 = 104,
        v1i16 = 105,
        v1i32 = 106,
        v1i64 = 107,
        v1i8 = 108,
        v2048f32 = 109,
        v2048i32 = 110,
        v256f16 = 111,
        v256f32 = 112,
        v256f64 = 113,
        v256i1 = 114,
        v256i16 = 115,
        v256i32 = 116,
        v256i64 = 117,
        v256i8 = 118,
        v2bf16 = 119,
        v2f16 = 120,
        v2f32 = 121,
        v2f64 = 122,
        v2i1 = 123,
        v2i16 = 124,
        v2i32 = 125,
        v2i64 = 126,
        v2i8 = 127,
        v32bf16 = 128,
        v32f16 = 129,
        v32f32 = 130,
        v32f64 = 131,
        v32i1 = 132,
        v32i16 = 133,
        v32i32 = 134,
        v32i64 = 135,
        v32i8 = 136,
        v3bf16 = 137,
        v3f16 = 138,
        v3f32 = 139,
        v3f64 = 140,
        v3i16 = 141,
        v3i32 = 142,
        v3i64 = 143,
        v4bf16 = 144,
        v4f16 = 145,
        v4f32 = 146,
        v4f64 = 147,
        v4i1 = 148,
        v4i16 = 149,
        v4i32 = 150,
        v4i64 = 151,
        v4i8 = 152,
        v512f16 = 153,
        v512f32 = 154,
        v512i1 = 155,
        v512i16 = 156,
        v512i32 = 157,
        v512i8 = 158,
        v5f32 = 159,
        v5i32 = 160,
        v64bf16 = 161,
        v64f16 = 162,
        v64f32 = 163,
        v64f64 = 164,
        v64i1 = 165,
        v64i16 = 166,
        v64i32 = 167,
        v64i64 = 168,
        v64i8 = 169,
        v6f32 = 170,
        v6i32 = 171,
        v7f32 = 172,
        v7i32 = 173,
        v8bf16 = 174,
        v8f16 = 175,
        v8f32 = 176,
        v8f64 = 177,
        v8i1 = 178,
        v8i16 = 179,
        v8i32 = 180,
        v8i64 = 181,
        v8i8 = 182,
        vAny = 183,
        x86amx = 184,
        x86mmx = 185,
    }

    public readonly struct ValueTypeST
    {
        public const uint EntryCount = 186;

        public const uint CharCount = 1109;

        public static MemoryAddress CharBase => address(Data);

        public static MemoryAddress OffsetBase => address(Offsets);

        public static MemoryStrings<ValueTypeKind> Strings => MemoryStrings.create(Offsets,Data);

        public static ReadOnlySpan<byte> Offsets => new byte[744]{0x00,0x00,0x00,0x00,0x03,0x00,0x00,0x00,0x09,0x00,0x00,0x00,0x13,0x00,0x00,0x00,0x1a,0x00,0x00,0x00,0x1e,0x00,0x00,0x00,0x27,0x00,0x00,0x00,0x2b,0x00,0x00,0x00,0x2e,0x00,0x00,0x00,0x31,0x00,0x00,0x00,0x34,0x00,0x00,0x00,0x37,0x00,0x00,0x00,0x3b,0x00,0x00,0x00,0x42,0x00,0x00,0x00,0x44,0x00,0x00,0x00,0x48,0x00,0x00,0x00,0x4b,0x00,0x00,0x00,0x4e,0x00,0x00,0x00,0x51,0x00,0x00,0x00,0x56,0x00,0x00,0x00,0x58,0x00,0x00,0x00,0x5c,0x00,0x00,0x00,0x60,0x00,0x00,0x00,0x67,0x00,0x00,0x00,0x6d,0x00,0x00,0x00,0x75,0x00,0x00,0x00,0x7d,0x00,0x00,0x00,0x84,0x00,0x00,0x00,0x8c,0x00,0x00,0x00,0x94,0x00,0x00,0x00,0x9c,0x00,0x00,0x00,0xa3,0x00,0x00,0x00,0xab,0x00,0x00,0x00,0xb2,0x00,0x00,0x00,0xb9,0x00,0x00,0x00,0xc0,0x00,0x00,0x00,0xc6,0x00,0x00,0x00,0xcd,0x00,0x00,0x00,0xd4,0x00,0x00,0x00,0xdb,0x00,0x00,0x00,0xe1,0x00,0x00,0x00,0xe9,0x00,0x00,0x00,0xf0,0x00,0x00,0x00,0xf7,0x00,0x00,0x00,0xfe,0x00,0x00,0x00,0x04,0x01,0x00,0x00,0x0b,0x01,0x00,0x00,0x12,0x01,0x00,0x00,0x19,0x01,0x00,0x00,0x1f,0x01,0x00,0x00,0x27,0x01,0x00,0x00,0x2e,0x01,0x00,0x00,0x36,0x01,0x00,0x00,0x3e,0x01,0x00,0x00,0x46,0x01,0x00,0x00,0x4d,0x01,0x00,0x00,0x55,0x01,0x00,0x00,0x5c,0x01,0x00,0x00,0x63,0x01,0x00,0x00,0x6a,0x01,0x00,0x00,0x70,0x01,0x00,0x00,0x77,0x01,0x00,0x00,0x7e,0x01,0x00,0x00,0x85,0x01,0x00,0x00,0x8b,0x01,0x00,0x00,0x92,0x01,0x00,0x00,0x99,0x01,0x00,0x00,0xa1,0x01,0x00,0x00,0xa8,0x01,0x00,0x00,0xaf,0x01,0x00,0x00,0xb6,0x01,0x00,0x00,0xbc,0x01,0x00,0x00,0xc3,0x01,0x00,0x00,0xca,0x01,0x00,0x00,0xd1,0x01,0x00,0x00,0xd7,0x01,0x00,0x00,0xde,0x01,0x00,0x00,0xe3,0x01,0x00,0x00,0xea,0x01,0x00,0x00,0xf2,0x01,0x00,0x00,0xf9,0x01,0x00,0x00,0x01,0x02,0x00,0x00,0x08,0x02,0x00,0x00,0x10,0x02,0x00,0x00,0x17,0x02,0x00,0x00,0x1e,0x02,0x00,0x00,0x25,0x02,0x00,0x00,0x2b,0x02,0x00,0x00,0x32,0x02,0x00,0x00,0x39,0x02,0x00,0x00,0x40,0x02,0x00,0x00,0x46,0x02,0x00,0x00,0x4d,0x02,0x00,0x00,0x53,0x02,0x00,0x00,0x59,0x02,0x00,0x00,0x5f,0x02,0x00,0x00,0x64,0x02,0x00,0x00,0x6a,0x02,0x00,0x00,0x70,0x02,0x00,0x00,0x76,0x02,0x00,0x00,0x7b,0x02,0x00,0x00,0x80,0x02,0x00,0x00,0x85,0x02,0x00,0x00,0x8a,0x02,0x00,0x00,0x8e,0x02,0x00,0x00,0x94,0x02,0x00,0x00,0x99,0x02,0x00,0x00,0x9e,0x02,0x00,0x00,0xa3,0x02,0x00,0x00,0xa7,0x02,0x00,0x00,0xaf,0x02,0x00,0x00,0xb7,0x02,0x00,0x00,0xbe,0x02,0x00,0x00,0xc5,0x02,0x00,0x00,0xcc,0x02,0x00,0x00,0xd2,0x02,0x00,0x00,0xd9,0x02,0x00,0x00,0xe0,0x02,0x00,0x00,0xe7,0x02,0x00,0x00,0xed,0x02,0x00,0x00,0xf3,0x02,0x00,0x00,0xf8,0x02,0x00,0x00,0xfd,0x02,0x00,0x00,0x02,0x03,0x00,0x00,0x06,0x03,0x00,0x00,0x0b,0x03,0x00,0x00,0x10,0x03,0x00,0x00,0x15,0x03,0x00,0x00,0x19,0x03,0x00,0x00,0x20,0x03,0x00,0x00,0x26,0x03,0x00,0x00,0x2c,0x03,0x00,0x00,0x32,0x03,0x00,0x00,0x37,0x03,0x00,0x00,0x3d,0x03,0x00,0x00,0x43,0x03,0x00,0x00,0x49,0x03,0x00,0x00,0x4e,0x03,0x00,0x00,0x54,0x03,0x00,0x00,0x59,0x03,0x00,0x00,0x5e,0x03,0x00,0x00,0x63,0x03,0x00,0x00,0x68,0x03,0x00,0x00,0x6d,0x03,0x00,0x00,0x72,0x03,0x00,0x00,0x78,0x03,0x00,0x00,0x7d,0x03,0x00,0x00,0x82,0x03,0x00,0x00,0x87,0x03,0x00,0x00,0x8b,0x03,0x00,0x00,0x90,0x03,0x00,0x00,0x95,0x03,0x00,0x00,0x9a,0x03,0x00,0x00,0x9e,0x03,0x00,0x00,0xa5,0x03,0x00,0x00,0xac,0x03,0x00,0x00,0xb2,0x03,0x00,0x00,0xb9,0x03,0x00,0x00,0xc0,0x03,0x00,0x00,0xc6,0x03,0x00,0x00,0xcb,0x03,0x00,0x00,0xd0,0x03,0x00,0x00,0xd7,0x03,0x00,0x00,0xdd,0x03,0x00,0x00,0xe3,0x03,0x00,0x00,0xe9,0x03,0x00,0x00,0xee,0x03,0x00,0x00,0xf4,0x03,0x00,0x00,0xfa,0x03,0x00,0x00,0x00,0x04,0x00,0x00,0x05,0x04,0x00,0x00,0x0a,0x04,0x00,0x00,0x0f,0x04,0x00,0x00,0x14,0x04,0x00,0x00,0x19,0x04,0x00,0x00,0x1f,0x04,0x00,0x00,0x24,0x04,0x00,0x00,0x29,0x04,0x00,0x00,0x2e,0x04,0x00,0x00,0x32,0x04,0x00,0x00,0x37,0x04,0x00,0x00,0x3c,0x04,0x00,0x00,0x41,0x04,0x00,0x00,0x45,0x04,0x00,0x00,0x49,0x04,0x00,0x00,0x4f,0x04,0x00,0x00};

        public static ReadOnlySpan<char> Data => new char[1109]{'A','n','y','F','l','a','g','V','T','M','e','t','a','d','a','t','a','V','T','O','t','h','e','r','V','T','b','f','1','6','e','x','t','e','r','n','r','e','f','f','1','2','8','f','1','6','f','3','2','f','6','4','f','8','0','f','A','n','y','f','u','n','c','r','e','f','i','1','i','1','2','8','i','1','6','i','3','2','i','6','4','i','6','4','x','8','i','8','i','A','n','y','i','P','T','R','i','P','T','R','A','n','y','i','s','V','o','i','d','n','x','v','1','6','f','1','6','n','x','v','1','6','f','3','2','n','x','v','1','6','i','1','n','x','v','1','6','i','1','6','n','x','v','1','6','i','3','2','n','x','v','1','6','i','6','4','n','x','v','1','6','i','8','n','x','v','1','b','f','1','6','n','x','v','1','f','1','6','n','x','v','1','f','3','2','n','x','v','1','f','6','4','n','x','v','1','i','1','n','x','v','1','i','1','6','n','x','v','1','i','3','2','n','x','v','1','i','6','4','n','x','v','1','i','8','n','x','v','2','b','f','1','6','n','x','v','2','f','1','6','n','x','v','2','f','3','2','n','x','v','2','f','6','4','n','x','v','2','i','1','n','x','v','2','i','1','6','n','x','v','2','i','3','2','n','x','v','2','i','6','4','n','x','v','2','i','8','n','x','v','3','2','f','1','6','n','x','v','3','2','i','1','n','x','v','3','2','i','1','6','n','x','v','3','2','i','3','2','n','x','v','3','2','i','6','4','n','x','v','3','2','i','8','n','x','v','4','b','f','1','6','n','x','v','4','f','1','6','n','x','v','4','f','3','2','n','x','v','4','f','6','4','n','x','v','4','i','1','n','x','v','4','i','1','6','n','x','v','4','i','3','2','n','x','v','4','i','6','4','n','x','v','4','i','8','n','x','v','6','4','i','1','n','x','v','6','4','i','8','n','x','v','8','b','f','1','6','n','x','v','8','f','1','6','n','x','v','8','f','3','2','n','x','v','8','f','6','4','n','x','v','8','i','1','n','x','v','8','i','1','6','n','x','v','8','i','3','2','n','x','v','8','i','6','4','n','x','v','8','i','8','p','p','c','f','1','2','8','t','o','k','e','n','u','n','t','y','p','e','d','v','1','0','2','4','f','3','2','v','1','0','2','4','i','1','v','1','0','2','4','i','3','2','v','1','0','2','4','i','8','v','1','2','8','b','f','1','6','v','1','2','8','f','1','6','v','1','2','8','f','3','2','v','1','2','8','f','6','4','v','1','2','8','i','1','v','1','2','8','i','1','6','v','1','2','8','i','3','2','v','1','2','8','i','6','4','v','1','2','8','i','8','v','1','6','b','f','1','6','v','1','6','f','1','6','v','1','6','f','3','2','v','1','6','f','6','4','v','1','6','i','1','v','1','6','i','1','6','v','1','6','i','3','2','v','1','6','i','6','4','v','1','6','i','8','v','1','f','1','6','v','1','f','3','2','v','1','f','6','4','v','1','i','1','v','1','i','1','2','8','v','1','i','1','6','v','1','i','3','2','v','1','i','6','4','v','1','i','8','v','2','0','4','8','f','3','2','v','2','0','4','8','i','3','2','v','2','5','6','f','1','6','v','2','5','6','f','3','2','v','2','5','6','f','6','4','v','2','5','6','i','1','v','2','5','6','i','1','6','v','2','5','6','i','3','2','v','2','5','6','i','6','4','v','2','5','6','i','8','v','2','b','f','1','6','v','2','f','1','6','v','2','f','3','2','v','2','f','6','4','v','2','i','1','v','2','i','1','6','v','2','i','3','2','v','2','i','6','4','v','2','i','8','v','3','2','b','f','1','6','v','3','2','f','1','6','v','3','2','f','3','2','v','3','2','f','6','4','v','3','2','i','1','v','3','2','i','1','6','v','3','2','i','3','2','v','3','2','i','6','4','v','3','2','i','8','v','3','b','f','1','6','v','3','f','1','6','v','3','f','3','2','v','3','f','6','4','v','3','i','1','6','v','3','i','3','2','v','3','i','6','4','v','4','b','f','1','6','v','4','f','1','6','v','4','f','3','2','v','4','f','6','4','v','4','i','1','v','4','i','1','6','v','4','i','3','2','v','4','i','6','4','v','4','i','8','v','5','1','2','f','1','6','v','5','1','2','f','3','2','v','5','1','2','i','1','v','5','1','2','i','1','6','v','5','1','2','i','3','2','v','5','1','2','i','8','v','5','f','3','2','v','5','i','3','2','v','6','4','b','f','1','6','v','6','4','f','1','6','v','6','4','f','3','2','v','6','4','f','6','4','v','6','4','i','1','v','6','4','i','1','6','v','6','4','i','3','2','v','6','4','i','6','4','v','6','4','i','8','v','6','f','3','2','v','6','i','3','2','v','7','f','3','2','v','7','i','3','2','v','8','b','f','1','6','v','8','f','1','6','v','8','f','3','2','v','8','f','6','4','v','8','i','1','v','8','i','1','6','v','8','i','3','2','v','8','i','6','4','v','8','i','8','v','A','n','y','x','8','6','a','m','x','x','8','6','m','m','x',};
    }
}