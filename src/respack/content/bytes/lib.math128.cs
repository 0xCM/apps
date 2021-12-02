﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2021-12-01 21:34:43 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class lib_math128
    {
        public static ReadOnlySpan<byte> addヽᐤ64uᕀrefㆍ64uᕀrefㆍ64uᐤ  =>  new byte[23]{0x0f,0x1f,0x44,0x00,0x00,0x49,0x8b,0xc0,0x48,0x03,0x01,0x48,0x89,0x01,0x49,0x3b,0xc0,0x73,0x03,0x48,0xff,0x02,0xc3};

        public static ReadOnlySpan<byte> addヽᐤ64uᕀrefㆍ64uᕀrefㆍ64uㆍ64uᐤ  =>  new byte[26]{0x0f,0x1f,0x44,0x00,0x00,0x49,0x8b,0xc0,0x48,0x03,0x01,0x48,0x89,0x01,0x49,0x3b,0xc0,0x73,0x03,0x48,0xff,0x02,0x4c,0x01,0x0a,0xc3};

        public static ReadOnlySpan<byte> addヽᐤuint128ᕀrefㆍuint128ᕀinᐤ  =>  new byte[60]{0x50,0x0f,0x1f,0x40,0x00,0x48,0x8b,0x01,0x4c,0x8b,0xc0,0x4c,0x03,0x02,0x49,0x3b,0xc0,0x0f,0x97,0xc0,0x0f,0xb6,0xc0,0x4c,0x8b,0x49,0x08,0x4c,0x03,0x4a,0x08,0x88,0x44,0x24,0x04,0x8b,0x44,0x24,0x04,0x0f,0xb6,0xc0,0x49,0x03,0xc1,0x48,0x89,0x41,0x08,0x4c,0x89,0x01,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> addヽᐤ64uᕀinㆍ64uᕀinㆍ64uᕀrefᐤ  =>  new byte[47]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x01,0x48,0x03,0x02,0x49,0x89,0x00,0x48,0x8b,0x01,0x49,0x3b,0x00,0x0f,0x97,0xc0,0x0f,0xb6,0xc0,0x49,0x83,0xc0,0x08,0x48,0x8b,0x49,0x08,0x48,0x03,0x4a,0x08,0x8b,0xc0,0x48,0x03,0xc1,0x49,0x89,0x00,0xc3};

        public static ReadOnlySpan<byte> eqヽᐤuint128ᕀinㆍuint128ᕀinᐤ  =>  new byte[38]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x01,0x48,0x3b,0x02,0x75,0x10,0x48,0x8b,0x41,0x08,0x48,0x3b,0x42,0x08,0x0f,0x94,0xc0,0x0f,0xb6,0xc0,0xeb,0x02,0x33,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> ltヽᐤuint128ᕀinㆍuint128ᕀinᐤ  =>  new byte[55]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x41,0x08,0x4c,0x8b,0x42,0x08,0x49,0x3b,0xc0,0x41,0x0f,0x92,0xc1,0x45,0x0f,0xb6,0xc9,0x49,0x3b,0xc0,0x75,0x0e,0x48,0x8b,0x01,0x48,0x3b,0x02,0x0f,0x92,0xc0,0x0f,0xb6,0xc0,0xeb,0x02,0x33,0xc0,0x41,0x0b,0xc1,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> lteqヽᐤuint128ᕀinㆍuint128ᕀinᐤ  =>  new byte[55]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x41,0x08,0x4c,0x8b,0x42,0x08,0x49,0x3b,0xc0,0x41,0x0f,0x92,0xc1,0x45,0x0f,0xb6,0xc9,0x49,0x3b,0xc0,0x75,0x0e,0x48,0x8b,0x01,0x48,0x3b,0x02,0x0f,0x96,0xc0,0x0f,0xb6,0xc0,0xeb,0x02,0x33,0xc0,0x41,0x0b,0xc1,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> gtヽᐤuint128ᕀinㆍuint128ᕀinᐤ  =>  new byte[75]{0x50,0x0f,0x1f,0x40,0x00,0x48,0x8b,0x41,0x08,0x4c,0x8b,0x42,0x08,0x49,0x3b,0xc0,0x41,0x0f,0x92,0xc1,0x45,0x0f,0xb6,0xc9,0x49,0x3b,0xc0,0x75,0x0e,0x48,0x8b,0x01,0x48,0x3b,0x02,0x0f,0x96,0xc0,0x0f,0xb6,0xc0,0xeb,0x02,0x33,0xc0,0x41,0x0b,0xc1,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0x88,0x04,0x24,0x80,0x3c,0x24,0x00,0x0f,0x94,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> gteqヽᐤuint128ᕀinㆍuint128ᕀinᐤ  =>  new byte[75]{0x50,0x0f,0x1f,0x40,0x00,0x48,0x8b,0x41,0x08,0x4c,0x8b,0x42,0x08,0x49,0x3b,0xc0,0x41,0x0f,0x92,0xc1,0x45,0x0f,0xb6,0xc9,0x49,0x3b,0xc0,0x75,0x0e,0x48,0x8b,0x01,0x48,0x3b,0x02,0x0f,0x92,0xc0,0x0f,0xb6,0xc0,0xeb,0x02,0x33,0xc0,0x41,0x0b,0xc1,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0x88,0x04,0x24,0x80,0x3c,0x24,0x00,0x0f,0x94,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> decヽᐤuint128ᕀrefᐤ  =>  new byte[54]{0x50,0x0f,0x1f,0x40,0x00,0x48,0x8b,0x01,0x48,0x8d,0x50,0xff,0x48,0x3b,0xc2,0x0f,0x92,0xc0,0x0f,0xb6,0xc0,0x4c,0x8b,0x41,0x08,0x88,0x44,0x24,0x04,0x8b,0x44,0x24,0x04,0x0f,0xb6,0xc0,0x4c,0x2b,0xc0,0x4c,0x89,0x41,0x08,0x48,0x89,0x11,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> incヽᐤuint128ᕀrefᐤ  =>  new byte[54]{0x50,0x0f,0x1f,0x40,0x00,0x48,0x8b,0x01,0x48,0x8d,0x50,0x01,0x48,0x3b,0xc2,0x0f,0x97,0xc0,0x0f,0xb6,0xc0,0x4c,0x8b,0x41,0x08,0x88,0x44,0x24,0x04,0x8b,0x44,0x24,0x04,0x0f,0xb6,0xc0,0x49,0x03,0xc0,0x48,0x89,0x41,0x08,0x48,0x89,0x11,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> orヽᐤuint128ᕀinㆍuint128ᕀinᐤ  =>  new byte[30]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x02,0x49,0x0b,0x00,0x48,0x8b,0x52,0x08,0x49,0x0b,0x50,0x08,0x48,0x89,0x01,0x48,0x89,0x51,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> notヽᐤuint128ᕀinᐤ  =>  new byte[29]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x02,0x48,0xf7,0xd0,0x48,0x8b,0x52,0x08,0x48,0xf7,0xd2,0x48,0x89,0x01,0x48,0x89,0x51,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> xorヽᐤuint128ᕀinㆍuint128ᕀinᐤ  =>  new byte[30]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x02,0x49,0x33,0x00,0x48,0x8b,0x52,0x08,0x49,0x33,0x50,0x08,0x48,0x89,0x01,0x48,0x89,0x51,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> norヽᐤuint128ᕀinㆍuint128ᕀinᐤ  =>  new byte[36]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x02,0x49,0x0b,0x00,0x48,0x8b,0x52,0x08,0x49,0x0b,0x50,0x08,0x48,0xf7,0xd0,0x48,0xf7,0xd2,0x48,0x89,0x01,0x48,0x89,0x51,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> andヽᐤuint128ᕀinㆍuint128ᕀinᐤ  =>  new byte[30]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x02,0x49,0x23,0x00,0x48,0x8b,0x52,0x08,0x49,0x23,0x50,0x08,0x48,0x89,0x01,0x48,0x89,0x51,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> nandヽᐤuint128ᕀinㆍuint128ᕀinᐤ  =>  new byte[36]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x02,0x49,0x23,0x00,0x48,0x8b,0x52,0x08,0x49,0x23,0x50,0x08,0x48,0xf7,0xd0,0x48,0xf7,0xd2,0x48,0x89,0x01,0x48,0x89,0x51,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> xnorヽᐤuint128ᕀinㆍuint128ᕀinᐤ  =>  new byte[36]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x02,0x49,0x33,0x00,0x48,0x8b,0x52,0x08,0x49,0x33,0x50,0x08,0x48,0xf7,0xd0,0x48,0xf7,0xd2,0x48,0x89,0x01,0x48,0x89,0x51,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> mulヽᐤ32uㆍ32uᐤ  =>  new byte[55]{0x50,0x33,0xc0,0x89,0x44,0x24,0x04,0x89,0x54,0x24,0x18,0x33,0xc0,0x89,0x44,0x24,0x04,0x48,0x8d,0x44,0x24,0x04,0x44,0x8b,0x44,0x24,0x18,0x8b,0xd1,0xc4,0xc2,0x33,0xf6,0xd0,0x44,0x89,0x08,0x8b,0xc2,0x48,0xc1,0xe0,0x20,0x8b,0x54,0x24,0x04,0x48,0x0b,0xc2,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> mulヽᐤ32uㆍ32uㆍ32uᕀoutㆍ32uᕀoutᐤ  =>  new byte[32]{0x0f,0x1f,0x44,0x00,0x00,0x89,0x54,0x24,0x10,0x33,0xc0,0x41,0x89,0x00,0x8b,0x44,0x24,0x10,0x8b,0xd1,0xc4,0xe2,0x2b,0xf6,0xc0,0x45,0x89,0x10,0x41,0x89,0x01,0xc3};

        public static ReadOnlySpan<byte> mulヽᐤ64uㆍ64uㆍ64uᕀoutㆍ64uᕀoutᐤ  =>  new byte[35]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x89,0x54,0x24,0x10,0x33,0xc0,0x49,0x89,0x00,0x48,0x8b,0x44,0x24,0x10,0x48,0x8b,0xd1,0xc4,0xe2,0xab,0xf6,0xc0,0x4d,0x89,0x10,0x49,0x89,0x01,0xc3};

        public static ReadOnlySpan<byte> mulヽᐤ32uㆍ32uㆍPairᐸuintᐳᕀoutᐤ  =>  new byte[46]{0x0f,0x1f,0x44,0x00,0x00,0x89,0x54,0x24,0x10,0x45,0x39,0x00,0x49,0x8d,0x40,0x04,0x45,0x33,0xc9,0x45,0x89,0x08,0x4d,0x8b,0xc8,0x44,0x8b,0x54,0x24,0x10,0x8b,0xd1,0xc4,0xc2,0x23,0xf6,0xd2,0x45,0x89,0x19,0x89,0x10,0x49,0x8b,0xc0,0xc3};

        public static ReadOnlySpan<byte> mulヽᐤuint128ᕀrefㆍuint128ᕀinᐤ  =>  new byte[34]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x02,0x4c,0x8b,0x42,0x08,0x4c,0x8b,0xc9,0x48,0x8b,0xd0,0xc4,0xc2,0xab,0xf6,0xc0,0x4d,0x89,0x11,0x48,0x89,0x41,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> mulヽᐤ64uㆍ64uㆍuint128ᕀoutᐤ  =>  new byte[49]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x89,0x54,0x24,0x10,0x45,0x39,0x00,0x49,0x8d,0x40,0x08,0x45,0x33,0xc9,0x4d,0x89,0x08,0x4d,0x8b,0xc8,0x4c,0x8b,0x54,0x24,0x10,0x48,0x8b,0xd1,0xc4,0xc2,0xa3,0xf6,0xd2,0x4d,0x89,0x19,0x48,0x89,0x10,0x49,0x8b,0xc0,0xc3};

        public static ReadOnlySpan<byte> mulヽᐤPairᐸulongᐳᕀinㆍPairᐸulongᐳᕀrefᐤ  =>  new byte[44]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x01,0x48,0x8b,0x49,0x08,0x48,0x89,0x54,0x24,0x10,0x4c,0x8b,0xc2,0x48,0x8b,0xd0,0xc4,0xe2,0xb3,0xf6,0xc1,0x4d,0x89,0x08,0x48,0x8b,0x54,0x24,0x10,0x48,0x89,0x42,0x08,0x48,0x8b,0xc2,0xc3};

        public static ReadOnlySpan<byte> mulヽᐤPairᐸulongᐳᕀinᐤ  =>  new byte[81]{0x48,0x83,0xec,0x18,0x33,0xc0,0x48,0x89,0x44,0x24,0x08,0x48,0x89,0x44,0x24,0x10,0x33,0xc0,0x48,0x89,0x44,0x24,0x08,0x48,0x89,0x44,0x24,0x10,0x48,0x8b,0x02,0x4c,0x8b,0x42,0x08,0x4c,0x8d,0x4c,0x24,0x08,0x48,0x8b,0xd0,0xc4,0xc2,0xab,0xf6,0xc0,0x4d,0x89,0x11,0x48,0x89,0x44,0x24,0x10,0x48,0x8b,0x44,0x24,0x08,0x48,0x89,0x01,0x48,0x8b,0x44,0x24,0x10,0x48,0x89,0x41,0x08,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> mulヽᐤPairᐸuintᐳᕀinㆍPairᐸuintᐳᕀrefᐤ  =>  new byte[40]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0x01,0x8b,0x49,0x04,0x48,0x89,0x54,0x24,0x10,0x4c,0x8b,0xc2,0x8b,0xd0,0xc4,0xe2,0x33,0xf6,0xc1,0x45,0x89,0x08,0x48,0x8b,0x54,0x24,0x10,0x89,0x42,0x04,0x48,0x8b,0xc2,0xc3};

        public static ReadOnlySpan<byte> mulヽᐤPairᐸuintᐳᕀinᐤ  =>  new byte[46]{0x50,0x33,0xc0,0x48,0x89,0x04,0x24,0x33,0xd2,0x89,0x14,0x24,0x89,0x54,0x24,0x04,0x8b,0x11,0x8b,0x41,0x04,0x48,0x8d,0x0c,0x24,0xc4,0xe2,0x3b,0xf6,0xc0,0x44,0x89,0x01,0x89,0x44,0x24,0x04,0x48,0x8b,0x04,0x24,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> mulヽᐤ64uᕀinㆍ64uᕀinㆍPairᐸulongᐳᕀrefᐤ  =>  new byte[33]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x01,0x48,0x8b,0x0a,0x4d,0x8b,0xc8,0x48,0x8b,0xd0,0xc4,0xe2,0xab,0xf6,0xc1,0x4d,0x89,0x11,0x49,0x89,0x40,0x08,0x49,0x8b,0xc0,0xc3};

        public static ReadOnlySpan<byte> mulヽᐤrspan64uㆍrspan64uㆍspanPairᐸulongᐳᐤ  =>  new byte[132]{0x57,0x56,0x53,0x66,0x90,0x8b,0x41,0x08,0x44,0x8b,0x4a,0x08,0x41,0x3b,0xc1,0x7c,0x02,0xeb,0x03,0x44,0x8b,0xc8,0x41,0x8b,0x40,0x08,0x44,0x3b,0xc8,0x7c,0x02,0xeb,0x03,0x41,0x8b,0xc1,0x45,0x33,0xc9,0x4c,0x63,0xd0,0x4d,0x85,0xd2,0x7e,0x51,0x4c,0x8b,0x11,0x4d,0x63,0xd9,0x4f,0x8d,0x14,0xda,0x48,0x89,0x54,0x24,0x28,0x4c,0x8b,0x1a,0x49,0x63,0xf1,0x4d,0x8d,0x1c,0xf3,0x49,0x8b,0x30,0x49,0x63,0xf9,0x48,0xc1,0xe7,0x04,0x48,0x03,0xf7,0x4d,0x8b,0x12,0x4d,0x8b,0x1b,0x48,0x8b,0xfe,0x49,0x8b,0xd2,0xc4,0xc2,0xe3,0xf6,0xd3,0x48,0x89,0x1f,0x48,0x89,0x56,0x08,0x41,0xff,0xc1,0x41,0x8b,0xd1,0x4c,0x63,0xd0,0x49,0x3b,0xd2,0x48,0x8b,0x54,0x24,0x28,0x7c,0xaf,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> mulヽᐤrspan64uㆍ64uㆍspanPairᐸulongᐳᐤ  =>  new byte[94]{0x57,0x56,0x53,0x48,0x89,0x54,0x24,0x28,0x8b,0x41,0x08,0x45,0x33,0xc9,0x4c,0x63,0xd0,0x4d,0x85,0xd2,0x7e,0x44,0x4c,0x8b,0x11,0x4d,0x63,0xd9,0x4f,0x8d,0x14,0xda,0x4d,0x8b,0x18,0x49,0x63,0xf1,0x48,0xc1,0xe6,0x04,0x4c,0x03,0xde,0x4d,0x8b,0x12,0x49,0x8b,0xf3,0x48,0x8b,0x7c,0x24,0x28,0x49,0x8b,0xd2,0xc4,0xe2,0xe3,0xf6,0xd7,0x48,0x89,0x1e,0x49,0x89,0x53,0x08,0x41,0xff,0xc1,0x41,0x8b,0xd1,0x4c,0x63,0xd0,0x49,0x3b,0xd2,0x48,0x89,0x7c,0x24,0x28,0x7c,0xbc,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> mulヽᐤ64uㆍ64uᐤ  =>  new byte[115]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0xff,0xff,0xff,0xff,0x48,0x23,0xc2,0x48,0xc1,0xea,0x20,0x41,0xb9,0xff,0xff,0xff,0xff,0x4d,0x23,0xc8,0x49,0xc1,0xe8,0x20,0x4c,0x8b,0xd0,0x4d,0x0f,0xaf,0xd1,0x4c,0x0f,0xaf,0xca,0x49,0x0f,0xaf,0xc0,0x49,0x0f,0xaf,0xd0,0x4d,0x8b,0xc2,0x49,0xc1,0xe8,0x20,0x4d,0x03,0xc1,0x41,0xb9,0xff,0xff,0xff,0xff,0x4d,0x23,0xc8,0x49,0x03,0xc1,0x4c,0x8b,0xc8,0x49,0xc1,0xe1,0x20,0x41,0xbb,0xff,0xff,0xff,0xff,0x4d,0x23,0xd3,0x4d,0x0b,0xca,0x48,0xc1,0xe8,0x20,0x48,0x03,0xc2,0x49,0xc1,0xe8,0x20,0x49,0x03,0xc0,0x4c,0x89,0x09,0x48,0x89,0x41,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> mulhiヽᐤ32uㆍ32uᐤ  =>  new byte[23]{0x0f,0x1f,0x44,0x00,0x00,0x89,0x54,0x24,0x10,0x8b,0x44,0x24,0x10,0x8b,0xd1,0xc4,0xe2,0x7b,0xf6,0xc0,0x8b,0xc0,0xc3};

        public static ReadOnlySpan<byte> mulhiヽᐤ64uㆍ64uᐤ  =>  new byte[24]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x89,0x54,0x24,0x10,0x48,0x8b,0x44,0x24,0x10,0x48,0x8b,0xd1,0xc4,0xe2,0xfb,0xf6,0xc0,0xc3};

        public static ReadOnlySpan<byte> mulloヽᐤ32uㆍ32uᐤ  =>  new byte[46]{0x50,0x33,0xc0,0x89,0x44,0x24,0x04,0x89,0x54,0x24,0x18,0x33,0xc0,0x89,0x44,0x24,0x04,0x48,0x8d,0x44,0x24,0x04,0x44,0x8b,0x44,0x24,0x18,0x8b,0xd1,0xc4,0xc2,0x33,0xf6,0xd0,0x44,0x89,0x08,0x8b,0x44,0x24,0x04,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> mulloヽᐤ64uㆍ64uᐤ  =>  new byte[47]{0x50,0x33,0xc0,0x48,0x89,0x04,0x24,0x48,0x89,0x54,0x24,0x18,0x33,0xc0,0x48,0x89,0x04,0x24,0x48,0x8d,0x04,0x24,0x4c,0x8b,0x44,0x24,0x18,0x48,0x8b,0xd1,0xc4,0xc2,0xb3,0xf6,0xd0,0x4c,0x89,0x08,0x48,0x8b,0x04,0x24,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> negateヽᐤuint128ᕀrefᐤ  =>  new byte[60]{0x50,0x0f,0x1f,0x40,0x00,0x48,0x8b,0x01,0x48,0xf7,0xd0,0x48,0x8b,0x51,0x08,0x48,0xf7,0xd2,0x4c,0x8d,0x40,0x01,0x49,0x3b,0xc0,0x0f,0x97,0xc0,0x0f,0xb6,0xc0,0x88,0x44,0x24,0x04,0x8b,0x44,0x24,0x04,0x0f,0xb6,0xc0,0x48,0x03,0xc2,0x4c,0x89,0x01,0x48,0x89,0x41,0x08,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> sllヽᐤuint128ᕀinㆍ8uᐤ  =>  new byte[107]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0xc1,0x45,0x0f,0xb6,0xc0,0x41,0x83,0xf8,0x40,0x7c,0x20,0x41,0x81,0xf8,0x80,0x00,0x00,0x00,0x7c,0x08,0x45,0x33,0xc9,0x45,0x33,0xd2,0xeb,0x40,0x4c,0x8b,0x0a,0x41,0x8d,0x48,0xc0,0x49,0xd3,0xe1,0x45,0x33,0xd2,0xeb,0x31,0x4c,0x8b,0x4a,0x08,0x45,0x8b,0xd0,0x41,0x83,0xe2,0x3f,0x41,0x8b,0xca,0x49,0xd3,0xe1,0x41,0x8b,0xc8,0xf7,0xd9,0x83,0xc1,0x3f,0x4c,0x8b,0x02,0x49,0xd1,0xe8,0x49,0xd3,0xe8,0x4d,0x0b,0xc8,0x48,0x8b,0x12,0x41,0x8b,0xca,0x48,0xd3,0xe2,0x4c,0x8b,0xd2,0x4c,0x89,0x08,0x4c,0x89,0x50,0x08,0xc3};

        public static ReadOnlySpan<byte> srlヽᐤuint128ᕀinㆍ8uᐤ  =>  new byte[107]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0xc1,0x45,0x0f,0xb6,0xc0,0x41,0x83,0xf8,0x40,0x7c,0x20,0x41,0x81,0xf8,0x80,0x00,0x00,0x00,0x7c,0x08,0x45,0x33,0xc9,0x45,0x33,0xd2,0xeb,0x40,0x4c,0x8b,0x12,0x41,0x8d,0x48,0xc0,0x49,0xd3,0xea,0x45,0x33,0xc9,0xeb,0x31,0x4c,0x8b,0x52,0x08,0x45,0x8b,0xc8,0x41,0x83,0xe1,0x3f,0x41,0x8b,0xc9,0x4d,0x8b,0xda,0x49,0xd3,0xeb,0x48,0x8b,0x12,0x41,0x8b,0xc9,0x48,0xd3,0xea,0x41,0x8b,0xc8,0xf7,0xd9,0x83,0xc1,0x3f,0x49,0xd1,0xe2,0x49,0xd3,0xe2,0x4c,0x0b,0xd2,0x4d,0x8b,0xcb,0x4c,0x89,0x08,0x4c,0x89,0x50,0x08,0xc3};

        public static ReadOnlySpan<byte> subヽᐤuint128ᕀrefㆍ64uᐤ  =>  new byte[21]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x39,0x11,0x73,0x07,0x48,0x8d,0x41,0x08,0x48,0xff,0x08,0x48,0x29,0x11,0xc3};

        public static ReadOnlySpan<byte> subヽᐤ64uᕀinㆍ64uᕀinㆍ64uᕀrefᐤ  =>  new byte[60]{0x50,0x0f,0x1f,0x40,0x00,0x48,0x8b,0x01,0x48,0x2b,0x02,0x49,0x89,0x00,0x48,0x8b,0x01,0x49,0x3b,0x00,0x0f,0x92,0xc0,0x0f,0xb6,0xc0,0x49,0x83,0xc0,0x08,0x48,0x8b,0x49,0x08,0x48,0x2b,0x4a,0x08,0x88,0x44,0x24,0x04,0x8b,0x44,0x24,0x04,0x0f,0xb6,0xc0,0x48,0x2b,0xc8,0x49,0x89,0x08,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> subヽᐤuint128ᕀrefㆍuint128ᕀinᐤ  =>  new byte[60]{0x50,0x0f,0x1f,0x40,0x00,0x48,0x8b,0x01,0x4c,0x8b,0xc0,0x4c,0x2b,0x02,0x49,0x3b,0xc0,0x0f,0x92,0xc0,0x0f,0xb6,0xc0,0x4c,0x8b,0x49,0x08,0x4c,0x2b,0x4a,0x08,0x88,0x44,0x24,0x04,0x8b,0x44,0x24,0x04,0x0f,0xb6,0xc0,0x4c,0x2b,0xc8,0x4c,0x89,0x49,0x08,0x4c,0x89,0x01,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x08,0xc3};

    }
}
