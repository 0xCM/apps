//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static RegKind;

    partial struct RegConversionData
    {
        [FixedAddressValueType]
        internal static Index<RegKind> Kinds = new RegKind[]{
            0,
            AL, // 1,
            CL, // 2,
            DL, // 3,
            BL, // 4,
            AH, // 5,
            CH, // 6,
            DH, // 7,
            BH, // 8,
            SPL, // 9,
            BPL, // 10,
            SIL, // 11,
            DIL, // 12,
            R8B, // 13,
            R9B, // 14,
            R10B, // 15,
            R11B, // 16,
            R12B, // 17,
            R13B, // 18,
            R14B, // 19,
            R15B, // 20,
            AX, // 21,
            CX, // 22,
            DX, // 23,
            BX, // 24,
            SP, // 25,
            BP, // 26,
            SI, // 27,
            DI, // 28,
            R8W, // 29,
            R9W, // 30,
            R10W, // 31,
            R11W, // 32,
            R12W, // 33,
            R13W, // 34,
            R14W, // 35,
            R15W, // 36,
            EAX, // 37,
            ECX, // 38,
            EDX, // 39,
            EBX, // 40,
            ESP, // 41,
            EBP, // 42,
            ESI, // 43,
            EDI, // 44,
            R8D, // 45,
            R9D, // 46,
            R10D, // 47,
            R11D, // 48,
            R12D, // 49,
            R13D, // 50,
            R14D, // 51,
            R15D, // 52,
            RAX, // 53,
            RCX, // 54,
            RDX, // 55,
            RBX, // 56,
            RSP, // 57,
            RBP, // 58,
            RSI, // 59,
            RDI, // 60,
            R8Q, // 61,
            R9Q, // 62,
            R10Q, // 63,
            R11Q, // 64,
            R12Q, // 65,
            R13Q, // 66,
            R14Q, // 67,
            R15Q, // 68,
            EIP, // 69,
            RIP, // 70,
            ES, // 71,
            CS, // 72,
            SS, // 73,
            DS, // 74,
            FS, // 75,
            GS, // 76,
            XMM0, // 77,
            XMM1, // 78,
            XMM2, // 79,
            XMM3, // 80,
            XMM4, // 81,
            XMM5, // 82,
            XMM6, // 83,
            XMM7, // 84,
            XMM8, // 85,
            XMM9, // 86,
            XMM10, // 87,
            XMM11, // 88,
            XMM12, // 89,
            XMM13, // 90,
            XMM14, // 91,
            XMM15, // 92,
            XMM16, // 93,
            XMM17, // 94,
            XMM18, // 95,
            XMM19, // 96,
            XMM20, // 97,
            XMM21, // 98,
            XMM22, // 99,
            XMM23, // 100,
            XMM24, // 101,
            XMM25, // 102,
            XMM26, // 103,
            XMM27, // 104,
            XMM28, // 105,
            XMM29, // 106,
            XMM30, // 107,
            XMM31, // 108,
            YMM0, // 109,
            YMM1, // 110,
            YMM2, // 111,
            YMM3, // 112,
            YMM4, // 113,
            YMM5, // 114,
            YMM6, // 115,
            YMM7, // 116,
            YMM8, // 117,
            YMM9, // 118,
            YMM10, // 119,
            YMM11, // 120,
            YMM12, // 121,
            YMM13, // 122,
            YMM14, // 123,
            YMM15, // 124,
            YMM16, // 125,
            YMM17, // 126,
            YMM18, // 127,
            YMM19, // 128,
            YMM20, // 129,
            YMM21, // 130,
            YMM22, // 131,
            YMM23, // 132,
            YMM24, // 133,
            YMM25, // 134,
            YMM26, // 135,
            YMM27, // 136,
            YMM28, // 137,
            YMM29, // 138,
            YMM30, // 139,
            YMM31, // 140,
            ZMM0, // 141,
            ZMM1, // 142,
            ZMM2, // 143,
            ZMM3, // 144,
            ZMM4, // 145,
            ZMM5, // 146,
            ZMM6, // 147,
            ZMM7, // 148,
            ZMM8, // 149,
            ZMM9, // 150,
            ZMM10, // 151,
            ZMM11, // 152,
            ZMM12, // 153,
            ZMM13, // 154,
            ZMM14, // 155,
            ZMM15, // 156,
            ZMM16, // 157,
            ZMM17, // 158,
            ZMM18, // 159,
            ZMM19, // 160,
            ZMM20, // 161,
            ZMM21, // 162,
            ZMM22, // 163,
            ZMM23, // 164,
            ZMM24, // 165,
            ZMM25, // 166,
            ZMM26, // 167,
            ZMM27, // 168,
            ZMM28, // 169,
            ZMM29, // 170,
            ZMM30, // 171,
            ZMM31, // 172,
            K0, // 173,
            K1, // 174,
            K2, // 175,
            K3, // 176,
            K4, // 177,
            K5, // 178,
            K6, // 179,
            K7, // 180,
            BND0, // 181,
            BND1, // 182,
            BND2, // 183,
            BND3, // 184,
            CR0, // 185,
            CR1, // 186,
            CR2, // 187,
            CR3, // 188,
            CR4, // 189,
            CR5, // 190,
            CR6, // 191,
            CR7, // 192,
            0, // 193,
            0, // 194,
            0, // 195,
            0, // 196,
            0, // 197,
            0, // 198,
            0, // 199,
            0, // 200,
            DR0, // 201,
            DR1, // 202,
            DR2, // 203,
            DR3, // 204,
            DR4, // 205,
            DR5, // 206,
            DR6, // 207,
            DR7, // 208,
            0, // 209,
            0, // 210,
            0, // 211,
            0, // 212,
            0, // 213,
            0, // 214,
            0, // 215,
            0, // 216,
            ST0, // 217,
            ST1, // 218,
            ST2, // 219,
            ST3, // 220,
            ST4, // 221,
            ST5, // 222,
            ST6, // 223,
            ST7, // 224,
            MM0, // 225,
            MM1, // 226,
            MM2, // 227,
            MM3, // 228,
            MM4, // 229,
            MM5, // 230,
            MM6, // 231,
            MM7, // 232,
            TR0, // 233,
            TR1, // 234,
            TR2, // 235,
            TR3, // 236,
            TR4, // 237,
            TR5, // 238,
            TR6, // 239,
            TR7, // 240
        };

        /*
        None = 0,
        AL = 1,
        CL = 2,
        DL = 3,
        BL = 4,
        AH = 5,
        CH = 6,
        DH = 7,
        BH = 8,
        SPL = 9,
        BPL = 10,
        SIL = 11,
        DIL = 12,
        R8L = 13,
        R9L = 14,
        R10L = 15,
        R11L = 16,
        R12L = 17,
        R13L = 18,
        R14L = 19,
        R15L = 20,
        AX = 21,
        CX = 22,
        DX = 23,
        BX = 24,
        SP = 25,
        BP = 26,
        SI = 27,
        DI = 28,
        R8W = 29,
        R9W = 30,
        R10W = 31,
        R11W = 32,
        R12W = 33,
        R13W = 34,
        R14W = 35,
        R15W = 36,
        EAX = 37,
        ECX = 38,
        EDX = 39,
        EBX = 40,
        ESP = 41,
        EBP = 42,
        ESI = 43,
        EDI = 44,
        R8D = 45,
        R9D = 46,
        R10D = 47,
        R11D = 48,
        R12D = 49,
        R13D = 50,
        R14D = 51,
        R15D = 52,
        RAX = 53,
        RCX = 54,
        RDX = 55,
        RBX = 56,
        RSP = 57,
        RBP = 58,
        RSI = 59,
        RDI = 60,
        R8 = 61,
        R9 = 62,
        R10 = 63,
        R11 = 64,
        R12 = 65,
        R13 = 66,
        R14 = 67,
        R15 = 68,
        EIP = 69,
        RIP = 70,
        ES = 71,
        CS = 72,
        SS = 73,
        DS = 74,
        FS = 75,
        GS = 76,
        XMM0 = 77,
        XMM1 = 78,
        XMM2 = 79,
        XMM3 = 80,
        XMM4 = 81,
        XMM5 = 82,
        XMM6 = 83,
        XMM7 = 84,
        XMM8 = 85,
        XMM9 = 86,
        XMM10 = 87,
        XMM11 = 88,
        XMM12 = 89,
        XMM13 = 90,
        XMM14 = 91,
        XMM15 = 92,
        XMM16 = 93,
        XMM17 = 94,
        XMM18 = 95,
        XMM19 = 96,
        XMM20 = 97,
        XMM21 = 98,
        XMM22 = 99,
        XMM23 = 100,
        XMM24 = 101,
        XMM25 = 102,
        XMM26 = 103,
        XMM27 = 104,
        XMM28 = 105,
        XMM29 = 106,
        XMM30 = 107,
        XMM31 = 108,
        YMM0 = 109,
        YMM1 = 110,
        YMM2 = 111,
        YMM3 = 112,
        YMM4 = 113,
        YMM5 = 114,
        YMM6 = 115,
        YMM7 = 116,
        YMM8 = 117,
        YMM9 = 118,
        YMM10 = 119,
        YMM11 = 120,
        YMM12 = 121,
        YMM13 = 122,
        YMM14 = 123,
        YMM15 = 124,
        YMM16 = 125,
        YMM17 = 126,
        YMM18 = 127,
        YMM19 = 128,
        YMM20 = 129,
        YMM21 = 130,
        YMM22 = 131,
        YMM23 = 132,
        YMM24 = 133,
        YMM25 = 134,
        YMM26 = 135,
        YMM27 = 136,
        YMM28 = 137,
        YMM29 = 138,
        YMM30 = 139,
        YMM31 = 140,
        ZMM0 = 141,
        ZMM1 = 142,
        ZMM2 = 143,
        ZMM3 = 144,
        ZMM4 = 145,
        ZMM5 = 146,
        ZMM6 = 147,
        ZMM7 = 148,
        ZMM8 = 149,
        ZMM9 = 150,
        ZMM10 = 151,
        ZMM11 = 152,
        ZMM12 = 153,
        ZMM13 = 154,
        ZMM14 = 155,
        ZMM15 = 156,
        ZMM16 = 157,
        ZMM17 = 158,
        ZMM18 = 159,
        ZMM19 = 160,
        ZMM20 = 161,
        ZMM21 = 162,
        ZMM22 = 163,
        ZMM23 = 164,
        ZMM24 = 165,
        ZMM25 = 166,
        ZMM26 = 167,
        ZMM27 = 168,
        ZMM28 = 169,
        ZMM29 = 170,
        ZMM30 = 171,
        ZMM31 = 172,
        K0 = 173,
        K1 = 174,
        K2 = 175,
        K3 = 176,
        K4 = 177,
        K5 = 178,
        K6 = 179,
        K7 = 180,
        BND0 = 181,
        BND1 = 182,
        BND2 = 183,
        BND3 = 184,
        CR0 = 185,
        CR1 = 186,
        CR2 = 187,
        CR3 = 188,
        CR4 = 189,
        CR5 = 190,
        CR6 = 191,
        CR7 = 192,
        CR8 = 193,
        CR9 = 194,
        CR10 = 195,
        CR11 = 196,
        CR12 = 197,
        CR13 = 198,
        CR14 = 199,
        CR15 = 200,
        DR0 = 201,
        DR1 = 202,
        DR2 = 203,
        DR3 = 204,
        DR4 = 205,
        DR5 = 206,
        DR6 = 207,
        DR7 = 208,
        DR8 = 209,
        DR9 = 210,
        DR10 = 211,
        DR11 = 212,
        DR12 = 213,
        DR13 = 214,
        DR14 = 215,
        DR15 = 216,
        ST0 = 217,
        ST1 = 218,
        ST2 = 219,
        ST3 = 220,
        ST4 = 221,
        ST5 = 222,
        ST6 = 223,
        ST7 = 224,
        MM0 = 225,
        MM1 = 226,
        MM2 = 227,
        MM3 = 228,
        MM4 = 229,
        MM5 = 230,
        MM6 = 231,
        MM7 = 232,
        TR0 = 233,
        TR1 = 234,
        TR2 = 235,
        TR3 = 236,
        TR4 = 237,
        TR5 = 238,
        TR6 = 239,
        TR7 = 240

        */
    }
}