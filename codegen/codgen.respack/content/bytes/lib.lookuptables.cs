﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2022-01-07 15:36:31 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class lib_lookuptables
    {
        public static ReadOnlySpan<byte> dataヽᐤLookupKeyᐤ  =>  new byte[15]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x89,0x4c,0x24,0x08,0x8b,0x44,0x24,0x08,0xc3};

        public static ReadOnlySpan<byte> eqヽᐤLookupKeyㆍLookupKeyᐤ  =>  new byte[50]{0x48,0x83,0xec,0x18,0x90,0x48,0x89,0x4c,0x24,0x20,0x48,0x89,0x54,0x24,0x28,0x8b,0x44,0x24,0x20,0x89,0x44,0x24,0x10,0x8b,0x44,0x24,0x10,0x8b,0x54,0x24,0x28,0x89,0x54,0x24,0x08,0x3b,0x44,0x24,0x08,0x0f,0x94,0xc0,0x0f,0xb6,0xc0,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> hashヽᐤLookupKeyᐤ  =>  new byte[25]{0x50,0x0f,0x1f,0x40,0x00,0x48,0x89,0x4c,0x24,0x10,0x8b,0x44,0x24,0x10,0x89,0x04,0x24,0x8b,0x04,0x24,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> formatヽᐤLookupKeyᐤ  =>  new byte[175]{0x56,0x48,0x83,0xec,0x50,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x48,0x89,0x44,0x24,0x38,0x48,0x89,0x4c,0x24,0x60,0x8b,0x4c,0x24,0x60,0x89,0x4c,0x24,0x48,0x48,0xb9,0x40,0x87,0x12,0x65,0xfb,0x7f,0x00,0x00,0xe8,0x89,0x65,0x3f,0x5b,0x48,0x8b,0xf0,0x0f,0xb7,0x4c,0x24,0x48,0x66,0x89,0x4e,0x08,0x8b,0x4c,0x24,0x60,0x89,0x4c,0x24,0x40,0x48,0xb9,0x40,0x87,0x12,0x65,0xfb,0x7f,0x00,0x00,0xe8,0x66,0x65,0x3f,0x5b,0x44,0x8b,0x44,0x24,0x40,0x41,0xc1,0xe8,0x10,0x66,0x44,0x89,0x40,0x08,0x45,0x33,0xc0,0x48,0xba,0x90,0x13,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0xb9,0x60,0xd6,0x39,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x09,0x4c,0x8d,0x4c,0x24,0x20,0x49,0x89,0x31,0x49,0x89,0x41,0x08,0x4d,0x89,0x41,0x10,0x49,0x89,0x51,0x18,0x4c,0x8d,0x44,0x24,0x20,0x48,0x8b,0xd1,0x33,0xc9,0xe8,0x78,0x4f,0x31,0x57,0x90,0x48,0x83,0xc4,0x50,0x5e,0xc3};

        public static ReadOnlySpan<byte> keyヽᐤ16uㆍ16uᐤ  =>  new byte[17]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb7,0xc1,0x0f,0xb7,0xd2,0xc1,0xe2,0x10,0x0b,0xc2,0xc3};

        public static ReadOnlySpan<byte> keyヽᐤLookupKeysㆍ16uㆍ16uᐤ  =>  new byte[75]{0x48,0x83,0xec,0x18,0x90,0x48,0x8b,0x41,0x08,0x48,0x85,0xc0,0x75,0x05,0x45,0x33,0xc9,0xeb,0x07,0x4c,0x8d,0x48,0x10,0x8b,0x40,0x08,0x8b,0x01,0x89,0x44,0x24,0x10,0x8b,0x44,0x24,0x12,0x0f,0xb7,0xc0,0x66,0x89,0x44,0x24,0x0c,0x8b,0x44,0x24,0x0c,0x0f,0xb7,0xc0,0x0f,0xb7,0xd2,0x0f,0xaf,0xc2,0x41,0x0f,0xb7,0xd0,0x03,0xc2,0x48,0x63,0xc0,0x49,0x8d,0x04,0x81,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> keysヽᐤ16uㆍ16uᐤ  =>  new byte[259]{0x41,0x57,0x41,0x56,0x41,0x54,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x50,0x33,0xc0,0x48,0x89,0x44,0x24,0x40,0x48,0x89,0x44,0x24,0x48,0x48,0x8b,0xd9,0x0f,0xb7,0xea,0x45,0x0f,0xb7,0xf0,0x8b,0xcd,0x41,0x0f,0xaf,0xce,0x48,0x63,0xc9,0xe8,0xc6,0xfb,0xff,0xff,0x48,0x85,0xc0,0x75,0x04,0x33,0xd2,0xeb,0x07,0x48,0x8d,0x50,0x10,0x8b,0x48,0x08,0x45,0x0f,0xb7,0xfe,0x45,0x33,0xe4,0x85,0xed,0x7e,0x51,0x33,0xc9,0x45,0x85,0xf6,0x7e,0x42,0x45,0x0f,0xb7,0xc7,0x66,0x44,0x89,0x44,0x24,0x34,0x44,0x8b,0x44,0x24,0x34,0x45,0x0f,0xb7,0xc0,0x45,0x0f,0xb7,0xcc,0x45,0x0f,0xaf,0xc1,0x44,0x0f,0xb7,0xc9,0x45,0x03,0xc1,0x4d,0x63,0xc0,0x4e,0x8d,0x04,0x82,0x45,0x0f,0xb7,0xcc,0x44,0x0f,0xb7,0xd1,0x41,0xc1,0xe2,0x10,0x45,0x0b,0xca,0x45,0x89,0x08,0xff,0xc1,0x41,0x3b,0xce,0x7c,0xbe,0x41,0xff,0xc4,0x44,0x3b,0xe5,0x7c,0xaf,0x66,0xc7,0x44,0x24,0x28,0x00,0x00,0x66,0xc7,0x44,0x24,0x2a,0x00,0x00,0x0f,0xb7,0xd5,0x66,0x89,0x54,0x24,0x28,0x41,0x0f,0xb7,0xd6,0x66,0x89,0x54,0x24,0x2a,0x8b,0x54,0x24,0x28,0x89,0x54,0x24,0x38,0x0f,0xb7,0x54,0x24,0x38,0x0f,0xb7,0x4c,0x24,0x3a,0x4c,0x8d,0x44,0x24,0x40,0x66,0x41,0x89,0x10,0x66,0x41,0x89,0x48,0x02,0x48,0x89,0x44,0x24,0x48,0x48,0x8b,0xfb,0x48,0x8d,0x74,0x24,0x40,0x48,0xa5,0xe8,0x4f,0x51,0x3f,0x5b,0x48,0x8b,0xc3,0x48,0x83,0xc4,0x50,0x5b,0x5d,0x5e,0x5f,0x41,0x5c,0x41,0x5e,0x41,0x5f,0xc3};

        public static ReadOnlySpan<byte> keysヽᐤ16uㆍ16uㆍspanLookupKeyᐤ  =>  new byte[100]{0x57,0x56,0x55,0x53,0x50,0x0f,0xb7,0xc1,0x0f,0xb7,0xd2,0x0f,0xb7,0xca,0x45,0x33,0xc9,0x85,0xc0,0x7e,0x46,0x45,0x33,0xd2,0x85,0xd2,0x7e,0x37,0x44,0x0f,0xb7,0xd9,0x41,0x0f,0xb7,0xf1,0x66,0x44,0x89,0x5c,0x24,0x04,0x8b,0x7c,0x24,0x04,0x0f,0xb7,0xff,0x49,0x8b,0x18,0x0f,0xaf,0xfe,0x41,0x0f,0xb7,0xea,0x03,0xfd,0x48,0x63,0xff,0x48,0x8d,0x3c,0xbb,0xc1,0xe5,0x10,0x0b,0xee,0x89,0x2f,0x41,0xff,0xc2,0x44,0x3b,0xd2,0x7c,0xd1,0x41,0xff,0xc1,0x44,0x3b,0xc8,0x7c,0xba,0x48,0x83,0xc4,0x08,0x5b,0x5d,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> offsetヽᐤGridDimᐸushortᐳㆍ16uㆍ16uᐤ  =>  new byte[51]{0x50,0x0f,0x1f,0x40,0x00,0x48,0x89,0x4c,0x24,0x10,0x48,0x8d,0x44,0x24,0x10,0x0f,0xb7,0x08,0x0f,0xb7,0x40,0x02,0x66,0x89,0x44,0x24,0x04,0x8b,0x44,0x24,0x04,0x0f,0xb7,0xc0,0x0f,0xb7,0xd2,0x0f,0xaf,0xc2,0x41,0x0f,0xb7,0xd0,0x03,0xc2,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> offsetヽᐤGridDimᐸushortᐳㆍLookupKeyᐤ  =>  new byte[80]{0x48,0x83,0xec,0x18,0x90,0x48,0x89,0x4c,0x24,0x20,0x48,0x89,0x54,0x24,0x28,0x8b,0x44,0x24,0x28,0x89,0x44,0x24,0x10,0x0f,0xb7,0x44,0x24,0x10,0x8b,0x54,0x24,0x28,0x89,0x54,0x24,0x08,0x48,0x8d,0x54,0x24,0x20,0x0f,0xb7,0x0a,0x0f,0xb7,0x52,0x02,0x8b,0x4c,0x24,0x08,0xc1,0xe9,0x10,0x0f,0xb7,0xc9,0x66,0x89,0x54,0x24,0x04,0x8b,0x54,0x24,0x04,0x0f,0xb7,0xd2,0x0f,0xaf,0xc2,0x03,0xc1,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> cellヽgᐸ8uᐳᐤGridDimᐸushortᐳㆍLookupKeyㆍspan8uᐤ  =>  new byte[89]{0x48,0x83,0xec,0x18,0x90,0x48,0x89,0x4c,0x24,0x20,0x48,0x89,0x54,0x24,0x28,0x8b,0x44,0x24,0x28,0x89,0x44,0x24,0x10,0x0f,0xb7,0x44,0x24,0x10,0x8b,0x54,0x24,0x28,0x89,0x54,0x24,0x08,0x48,0x8d,0x54,0x24,0x20,0x0f,0xb7,0x0a,0x0f,0xb7,0x52,0x02,0x8b,0x4c,0x24,0x08,0xc1,0xe9,0x10,0x0f,0xb7,0xc9,0x66,0x89,0x54,0x24,0x04,0x8b,0x54,0x24,0x04,0x0f,0xb7,0xd2,0x0f,0xaf,0xc2,0x03,0xc1,0x49,0x8b,0x10,0x48,0x63,0xc0,0x48,0x03,0xc2,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> cellヽgᐸ16uᐳᐤGridDimᐸushortᐳㆍLookupKeyㆍspan16uᐤ  =>  new byte[90]{0x48,0x83,0xec,0x18,0x90,0x48,0x89,0x4c,0x24,0x20,0x48,0x89,0x54,0x24,0x28,0x8b,0x44,0x24,0x28,0x89,0x44,0x24,0x10,0x0f,0xb7,0x44,0x24,0x10,0x8b,0x54,0x24,0x28,0x89,0x54,0x24,0x08,0x48,0x8d,0x54,0x24,0x20,0x0f,0xb7,0x0a,0x0f,0xb7,0x52,0x02,0x8b,0x4c,0x24,0x08,0xc1,0xe9,0x10,0x0f,0xb7,0xc9,0x66,0x89,0x54,0x24,0x04,0x8b,0x54,0x24,0x04,0x0f,0xb7,0xd2,0x0f,0xaf,0xc2,0x03,0xc1,0x49,0x8b,0x10,0x48,0x63,0xc0,0x48,0x8d,0x04,0x42,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> cellヽgᐸ32uᐳᐤGridDimᐸushortᐳㆍLookupKeyㆍspan32uᐤ  =>  new byte[90]{0x48,0x83,0xec,0x18,0x90,0x48,0x89,0x4c,0x24,0x20,0x48,0x89,0x54,0x24,0x28,0x8b,0x44,0x24,0x28,0x89,0x44,0x24,0x10,0x0f,0xb7,0x44,0x24,0x10,0x8b,0x54,0x24,0x28,0x89,0x54,0x24,0x08,0x48,0x8d,0x54,0x24,0x20,0x0f,0xb7,0x0a,0x0f,0xb7,0x52,0x02,0x8b,0x4c,0x24,0x08,0xc1,0xe9,0x10,0x0f,0xb7,0xc9,0x66,0x89,0x54,0x24,0x04,0x8b,0x54,0x24,0x04,0x0f,0xb7,0xd2,0x0f,0xaf,0xc2,0x03,0xc1,0x49,0x8b,0x10,0x48,0x63,0xc0,0x48,0x8d,0x04,0x82,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> cellヽgᐸ64uᐳᐤGridDimᐸushortᐳㆍLookupKeyㆍspan64uᐤ  =>  new byte[90]{0x48,0x83,0xec,0x18,0x90,0x48,0x89,0x4c,0x24,0x20,0x48,0x89,0x54,0x24,0x28,0x8b,0x44,0x24,0x28,0x89,0x44,0x24,0x10,0x0f,0xb7,0x44,0x24,0x10,0x8b,0x54,0x24,0x28,0x89,0x54,0x24,0x08,0x48,0x8d,0x54,0x24,0x20,0x0f,0xb7,0x0a,0x0f,0xb7,0x52,0x02,0x8b,0x4c,0x24,0x08,0xc1,0xe9,0x10,0x0f,0xb7,0xc9,0x66,0x89,0x54,0x24,0x04,0x8b,0x54,0x24,0x04,0x0f,0xb7,0xd2,0x0f,0xaf,0xc2,0x03,0xc1,0x49,0x8b,0x10,0x48,0x63,0xc0,0x48,0x8d,0x04,0xc2,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> formatヽgᐸ8uᐳᐤKeyMapᐸbyteᐳᐤ  =>  new byte[205]{0x57,0x56,0x53,0x48,0x83,0xec,0x60,0x48,0x8b,0xf1,0x48,0x8d,0x7c,0x24,0x28,0xb9,0x0e,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x48,0x8b,0xf1,0x8b,0x0e,0x89,0x4c,0x24,0x58,0x8b,0x4c,0x24,0x58,0x89,0x4c,0x24,0x50,0x48,0xb9,0x40,0x87,0x12,0x65,0xfb,0x7f,0x00,0x00,0xe8,0xf5,0x5b,0x3f,0x5b,0x48,0x8b,0xf8,0x0f,0xb7,0x4c,0x24,0x50,0x66,0x89,0x4f,0x08,0x8b,0x0e,0x89,0x4c,0x24,0x58,0x8b,0x4c,0x24,0x58,0x89,0x4c,0x24,0x48,0x48,0xb9,0x40,0x87,0x12,0x65,0xfb,0x7f,0x00,0x00,0xe8,0xcc,0x5b,0x3f,0x5b,0x48,0x8b,0xd8,0x8b,0x4c,0x24,0x48,0xc1,0xe9,0x10,0x66,0x89,0x4b,0x08,0x48,0xb9,0x60,0x77,0x12,0x65,0xfb,0x7f,0x00,0x00,0xe8,0xaf,0x5b,0x3f,0x5b,0x44,0x0f,0xb6,0x46,0x04,0x44,0x88,0x40,0x08,0x49,0xb8,0x98,0x13,0x28,0x61,0xa1,0x02,0x00,0x00,0x4d,0x8b,0x00,0x48,0xba,0x68,0xd6,0x39,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x8d,0x4c,0x24,0x28,0x48,0x89,0x39,0x48,0x89,0x59,0x08,0x48,0x89,0x41,0x10,0x4c,0x89,0x41,0x18,0x4c,0x8d,0x44,0x24,0x28,0x33,0xc9,0xe8,0xcc,0x45,0x31,0x57,0x90,0x48,0x83,0xc4,0x60,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> formatヽgᐸ16uᐳᐤKeyMapᐸushortᐳᐤ  =>  new byte[206]{0x57,0x56,0x53,0x48,0x83,0xec,0x60,0x48,0x8b,0xf1,0x48,0x8d,0x7c,0x24,0x28,0xb9,0x0e,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x48,0x8b,0xf1,0x8b,0x0e,0x89,0x4c,0x24,0x58,0x8b,0x4c,0x24,0x58,0x89,0x4c,0x24,0x50,0x48,0xb9,0x40,0x87,0x12,0x65,0xfb,0x7f,0x00,0x00,0xe8,0x05,0x5b,0x3f,0x5b,0x48,0x8b,0xf8,0x0f,0xb7,0x4c,0x24,0x50,0x66,0x89,0x4f,0x08,0x8b,0x0e,0x89,0x4c,0x24,0x58,0x8b,0x4c,0x24,0x58,0x89,0x4c,0x24,0x48,0x48,0xb9,0x40,0x87,0x12,0x65,0xfb,0x7f,0x00,0x00,0xe8,0xdc,0x5a,0x3f,0x5b,0x48,0x8b,0xd8,0x8b,0x4c,0x24,0x48,0xc1,0xe9,0x10,0x66,0x89,0x4b,0x08,0x48,0xb9,0x40,0x87,0x12,0x65,0xfb,0x7f,0x00,0x00,0xe8,0xbf,0x5a,0x3f,0x5b,0x44,0x0f,0xb7,0x46,0x04,0x66,0x44,0x89,0x40,0x08,0x49,0xb8,0x98,0x13,0x28,0x61,0xa1,0x02,0x00,0x00,0x4d,0x8b,0x00,0x48,0xba,0x68,0xd6,0x39,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x8d,0x4c,0x24,0x28,0x48,0x89,0x39,0x48,0x89,0x59,0x08,0x48,0x89,0x41,0x10,0x4c,0x89,0x41,0x18,0x4c,0x8d,0x44,0x24,0x28,0x33,0xc9,0xe8,0xdb,0x44,0x31,0x57,0x90,0x48,0x83,0xc4,0x60,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> formatヽgᐸ32uᐳᐤKeyMapᐸuintᐳᐤ  =>  new byte[205]{0x57,0x56,0x48,0x83,0xec,0x58,0x48,0x8b,0xf1,0x48,0x8d,0x7c,0x24,0x20,0xb9,0x0e,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x48,0x89,0x4c,0x24,0x70,0x8b,0x74,0x24,0x70,0x89,0x74,0x24,0x50,0x8b,0x4c,0x24,0x50,0x89,0x4c,0x24,0x48,0x48,0xb9,0x40,0x87,0x12,0x65,0xfb,0x7f,0x00,0x00,0xe8,0x12,0x5a,0x3f,0x5b,0x48,0x8b,0xf8,0x0f,0xb7,0x4c,0x24,0x48,0x66,0x89,0x4f,0x08,0x89,0x74,0x24,0x50,0x8b,0x4c,0x24,0x50,0x89,0x4c,0x24,0x40,0x48,0xb9,0x40,0x87,0x12,0x65,0xfb,0x7f,0x00,0x00,0xe8,0xeb,0x59,0x3f,0x5b,0x48,0x8b,0xf0,0x8b,0x4c,0x24,0x40,0xc1,0xe9,0x10,0x66,0x89,0x4e,0x08,0x48,0xb9,0xe0,0x96,0x12,0x65,0xfb,0x7f,0x00,0x00,0xe8,0xce,0x59,0x3f,0x5b,0x44,0x8b,0x44,0x24,0x74,0x44,0x89,0x40,0x08,0x49,0xb8,0x98,0x13,0x28,0x61,0xa1,0x02,0x00,0x00,0x4d,0x8b,0x00,0x48,0xba,0x68,0xd6,0x39,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x8d,0x4c,0x24,0x20,0x48,0x89,0x39,0x48,0x89,0x71,0x08,0x48,0x89,0x41,0x10,0x4c,0x89,0x41,0x18,0x4c,0x8d,0x44,0x24,0x20,0x33,0xc9,0xe8,0xeb,0x43,0x31,0x57,0x90,0x48,0x83,0xc4,0x58,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> formatヽgᐸ64uᐳᐤKeyMapᐸulongᐳᐤ  =>  new byte[204]{0x57,0x56,0x53,0x48,0x83,0xec,0x60,0x48,0x8b,0xf1,0x48,0x8d,0x7c,0x24,0x28,0xb9,0x0e,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x48,0x8b,0xf1,0x8b,0x0e,0x89,0x4c,0x24,0x58,0x8b,0x4c,0x24,0x58,0x89,0x4c,0x24,0x50,0x48,0xb9,0x40,0x87,0x12,0x65,0xfb,0x7f,0x00,0x00,0xe8,0x25,0x59,0x3f,0x5b,0x48,0x8b,0xf8,0x0f,0xb7,0x4c,0x24,0x50,0x66,0x89,0x4f,0x08,0x8b,0x0e,0x89,0x4c,0x24,0x58,0x8b,0x4c,0x24,0x58,0x89,0x4c,0x24,0x48,0x48,0xb9,0x40,0x87,0x12,0x65,0xfb,0x7f,0x00,0x00,0xe8,0xfc,0x58,0x3f,0x5b,0x48,0x8b,0xd8,0x8b,0x4c,0x24,0x48,0xc1,0xe9,0x10,0x66,0x89,0x4b,0x08,0x48,0xb9,0x80,0xa6,0x12,0x65,0xfb,0x7f,0x00,0x00,0xe8,0xdf,0x58,0x3f,0x5b,0x4c,0x8b,0x46,0x08,0x4c,0x89,0x40,0x08,0x49,0xb8,0x98,0x13,0x28,0x61,0xa1,0x02,0x00,0x00,0x4d,0x8b,0x00,0x48,0xba,0x68,0xd6,0x39,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x8d,0x4c,0x24,0x28,0x48,0x89,0x39,0x48,0x89,0x59,0x08,0x48,0x89,0x41,0x10,0x4c,0x89,0x41,0x18,0x4c,0x8d,0x44,0x24,0x28,0x33,0xc9,0xe8,0xfd,0x42,0x31,0x57,0x90,0x48,0x83,0xc4,0x60,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> mapヽgᐸ8uᐳᐤLookupKeyㆍ8uᐤ  =>  new byte[70]{0x48,0x83,0xec,0x18,0x90,0x48,0x89,0x54,0x24,0x28,0x33,0xc0,0x48,0x8d,0x54,0x24,0x10,0x89,0x02,0x88,0x42,0x04,0x8b,0x44,0x24,0x28,0x89,0x44,0x24,0x08,0x8b,0x44,0x24,0x08,0x48,0x8d,0x54,0x24,0x10,0x89,0x02,0x41,0x0f,0xb6,0xc0,0x88,0x44,0x24,0x14,0x8b,0x44,0x24,0x10,0x89,0x01,0x8a,0x44,0x24,0x14,0x88,0x41,0x04,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> mapヽgᐸ16uᐳᐤLookupKeyㆍ16uᐤ  =>  new byte[74]{0x48,0x83,0xec,0x18,0x90,0x48,0x89,0x54,0x24,0x28,0x33,0xc0,0x48,0x8d,0x54,0x24,0x10,0x89,0x02,0x66,0x89,0x42,0x04,0x8b,0x44,0x24,0x28,0x89,0x44,0x24,0x08,0x8b,0x44,0x24,0x08,0x48,0x8d,0x54,0x24,0x10,0x89,0x02,0x41,0x0f,0xb7,0xc0,0x66,0x89,0x44,0x24,0x14,0x8b,0x44,0x24,0x10,0x89,0x01,0x66,0x8b,0x44,0x24,0x14,0x66,0x89,0x41,0x04,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> mapヽgᐸ32uᐳᐤLookupKeyㆍ32uᐤ  =>  new byte[50]{0x48,0x83,0xec,0x18,0x90,0x48,0x89,0x4c,0x24,0x20,0x33,0xc0,0x48,0x89,0x44,0x24,0x10,0x8b,0x44,0x24,0x20,0x89,0x44,0x24,0x08,0x8b,0x44,0x24,0x08,0x48,0x8d,0x4c,0x24,0x10,0x89,0x01,0x89,0x54,0x24,0x14,0x48,0x8b,0x44,0x24,0x10,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> mapヽgᐸ64uᐳᐤLookupKeyㆍ64uᐤ  =>  new byte[65]{0x48,0x83,0xec,0x18,0xc5,0xf8,0x77,0x48,0x89,0x54,0x24,0x28,0x48,0x8d,0x44,0x24,0x08,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x00,0x8b,0x44,0x24,0x28,0x89,0x04,0x24,0x8b,0x04,0x24,0x48,0x8d,0x54,0x24,0x08,0x89,0x02,0x4c,0x89,0x44,0x24,0x10,0xc5,0xfa,0x6f,0x44,0x24,0x08,0xc5,0xfa,0x7f,0x01,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> tableヽgᐸ8uᐳᐤ16uㆍ16uᐤ  =>  new byte[150]{0x57,0x56,0x53,0x48,0x83,0xec,0x40,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x28,0x48,0x8b,0xd9,0x0f,0xb7,0xca,0x0f,0xb7,0xc1,0x41,0x0f,0xb7,0xd0,0x44,0x0f,0xb7,0xc2,0x66,0xc7,0x44,0x24,0x20,0x00,0x00,0x66,0xc7,0x44,0x24,0x22,0x00,0x00,0x0f,0xb7,0xc0,0x66,0x89,0x44,0x24,0x20,0x41,0x0f,0xb7,0xc0,0x66,0x89,0x44,0x24,0x22,0x8b,0x44,0x24,0x20,0x89,0x44,0x24,0x38,0x48,0x8d,0x44,0x24,0x28,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x00,0x0f,0xb7,0x74,0x24,0x38,0x0f,0xb7,0x7c,0x24,0x3a,0x0f,0xaf,0xca,0x48,0x63,0xc9,0xe8,0x65,0x10,0xf8,0xff,0x48,0x8d,0x54,0x24,0x30,0x66,0x89,0x32,0x66,0x89,0x7a,0x02,0x48,0x89,0x44,0x24,0x28,0x48,0x8b,0xfb,0x48,0x8d,0x74,0x24,0x28,0xe8,0x57,0x48,0x3f,0x5b,0x48,0xa5,0x48,0x8b,0xc3,0x48,0x83,0xc4,0x40,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> tableヽgᐸ16uᐳᐤ16uㆍ16uᐤ  =>  new byte[150]{0x57,0x56,0x53,0x48,0x83,0xec,0x40,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x28,0x48,0x8b,0xd9,0x0f,0xb7,0xca,0x0f,0xb7,0xc1,0x41,0x0f,0xb7,0xd0,0x44,0x0f,0xb7,0xc2,0x66,0xc7,0x44,0x24,0x20,0x00,0x00,0x66,0xc7,0x44,0x24,0x22,0x00,0x00,0x0f,0xb7,0xc0,0x66,0x89,0x44,0x24,0x20,0x41,0x0f,0xb7,0xc0,0x66,0x89,0x44,0x24,0x22,0x8b,0x44,0x24,0x20,0x89,0x44,0x24,0x38,0x48,0x8d,0x44,0x24,0x28,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x00,0x0f,0xb7,0x74,0x24,0x38,0x0f,0xb7,0x7c,0x24,0x3a,0x0f,0xaf,0xca,0x48,0x63,0xc9,0xe8,0x25,0x0c,0xf8,0xff,0x48,0x8d,0x54,0x24,0x30,0x66,0x89,0x32,0x66,0x89,0x7a,0x02,0x48,0x89,0x44,0x24,0x28,0x48,0x8b,0xfb,0x48,0x8d,0x74,0x24,0x28,0xe8,0x97,0x43,0x3f,0x5b,0x48,0xa5,0x48,0x8b,0xc3,0x48,0x83,0xc4,0x40,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> tableヽgᐸ32uᐳᐤ16uㆍ16uᐤ  =>  new byte[150]{0x57,0x56,0x53,0x48,0x83,0xec,0x40,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x28,0x48,0x8b,0xd9,0x0f,0xb7,0xca,0x0f,0xb7,0xc1,0x41,0x0f,0xb7,0xd0,0x44,0x0f,0xb7,0xc2,0x66,0xc7,0x44,0x24,0x20,0x00,0x00,0x66,0xc7,0x44,0x24,0x22,0x00,0x00,0x0f,0xb7,0xc0,0x66,0x89,0x44,0x24,0x20,0x41,0x0f,0xb7,0xc0,0x66,0x89,0x44,0x24,0x22,0x8b,0x44,0x24,0x20,0x89,0x44,0x24,0x38,0x48,0x8d,0x44,0x24,0x28,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x00,0x0f,0xb7,0x74,0x24,0x38,0x0f,0xb7,0x7c,0x24,0x3a,0x0f,0xaf,0xca,0x48,0x63,0xc9,0xe8,0xf5,0x0b,0xf8,0xff,0x48,0x8d,0x54,0x24,0x30,0x66,0x89,0x32,0x66,0x89,0x7a,0x02,0x48,0x89,0x44,0x24,0x28,0x48,0x8b,0xfb,0x48,0x8d,0x74,0x24,0x28,0xe8,0xe7,0x42,0x3f,0x5b,0x48,0xa5,0x48,0x8b,0xc3,0x48,0x83,0xc4,0x40,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> tableヽgᐸ64uᐳᐤ16uㆍ16uᐤ  =>  new byte[150]{0x57,0x56,0x53,0x48,0x83,0xec,0x40,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x28,0x48,0x8b,0xd9,0x0f,0xb7,0xca,0x0f,0xb7,0xc1,0x41,0x0f,0xb7,0xd0,0x44,0x0f,0xb7,0xc2,0x66,0xc7,0x44,0x24,0x20,0x00,0x00,0x66,0xc7,0x44,0x24,0x22,0x00,0x00,0x0f,0xb7,0xc0,0x66,0x89,0x44,0x24,0x20,0x41,0x0f,0xb7,0xc0,0x66,0x89,0x44,0x24,0x22,0x8b,0x44,0x24,0x20,0x89,0x44,0x24,0x38,0x48,0x8d,0x44,0x24,0x28,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x00,0x0f,0xb7,0x74,0x24,0x38,0x0f,0xb7,0x7c,0x24,0x3a,0x0f,0xaf,0xca,0x48,0x63,0xc9,0xe8,0xc5,0x0b,0xf8,0xff,0x48,0x8d,0x54,0x24,0x30,0x66,0x89,0x32,0x66,0x89,0x7a,0x02,0x48,0x89,0x44,0x24,0x28,0x48,0x8b,0xfb,0x48,0x8d,0x74,0x24,0x28,0xe8,0x37,0x42,0x3f,0x5b,0x48,0xa5,0x48,0x8b,0xc3,0x48,0x83,0xc4,0x40,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> tableヽgᐸ8uᐳᐤ16uㆍ16uㆍarray_8uᐤ  =>  new byte[326]{0x57,0x56,0x53,0x48,0x83,0xec,0x70,0xc5,0xf8,0x77,0x48,0x8b,0xf1,0x48,0x8d,0x7c,0x24,0x28,0xb9,0x12,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x48,0x8b,0xd9,0x0f,0xb7,0xc2,0x41,0x0f,0xb7,0xc8,0x0f,0xaf,0xc1,0x41,0x39,0x41,0x08,0x0f,0x94,0xc0,0x0f,0xb6,0xc0,0x84,0xc0,0x74,0x6f,0x0f,0xb7,0xc2,0x41,0x0f,0xb7,0xd0,0x66,0xc7,0x44,0x24,0x20,0x00,0x00,0x66,0xc7,0x44,0x24,0x22,0x00,0x00,0x0f,0xb7,0xc0,0x66,0x89,0x44,0x24,0x20,0x0f,0xb7,0xc2,0x66,0x89,0x44,0x24,0x22,0x48,0x8d,0x44,0x24,0x60,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x00,0x8b,0x44,0x24,0x20,0x89,0x44,0x24,0x58,0x0f,0xb7,0x44,0x24,0x58,0x0f,0xb7,0x54,0x24,0x5a,0x48,0x8d,0x4c,0x24,0x68,0x66,0x89,0x01,0x66,0x89,0x51,0x02,0x4c,0x89,0x4c,0x24,0x60,0x48,0x8b,0xfb,0x48,0x8d,0x74,0x24,0x60,0xe8,0x75,0x41,0x3f,0x5b,0x48,0xa5,0x48,0x8b,0xc3,0x48,0x83,0xc4,0x70,0x5b,0x5e,0x5f,0xc3,0x33,0xd2,0x48,0x8d,0x4c,0x24,0x40,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x01,0x48,0x89,0x51,0x10,0x48,0x8d,0x4c,0x24,0x28,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x01,0x48,0x89,0x51,0x10,0x48,0xba,0x70,0xd6,0x39,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x89,0x54,0x24,0x28,0x48,0xba,0x78,0xd6,0x39,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x8d,0x4c,0x24,0x28,0x48,0x85,0xd2,0x75,0x0d,0x48,0xba,0x60,0x30,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x8d,0x49,0x08,0xe8,0x35,0x40,0x3f,0x5b,0xc7,0x44,0x24,0x38,0x12,0x00,0x00,0x00,0x48,0x8b,0x4c,0x24,0x28,0x48,0x89,0x4c,0x24,0x40,0x48,0x8b,0x4c,0x24,0x30,0x48,0x89,0x4c,0x24,0x48,0x8b,0x4c,0x24,0x38,0x89,0x4c,0x24,0x50,0x48,0xb9,0xc8,0x64,0x3d,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x09,0x48,0x8d,0x54,0x24,0x40,0xe8,0xda,0x23,0x25,0xff};

        public static ReadOnlySpan<byte> tableヽgᐸ16uᐳᐤ16uㆍ16uㆍarray_16uᐤ  =>  new byte[326]{0x57,0x56,0x53,0x48,0x83,0xec,0x70,0xc5,0xf8,0x77,0x48,0x8b,0xf1,0x48,0x8d,0x7c,0x24,0x28,0xb9,0x12,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x48,0x8b,0xd9,0x0f,0xb7,0xc2,0x41,0x0f,0xb7,0xc8,0x0f,0xaf,0xc1,0x41,0x39,0x41,0x08,0x0f,0x94,0xc0,0x0f,0xb6,0xc0,0x84,0xc0,0x74,0x6f,0x0f,0xb7,0xc2,0x41,0x0f,0xb7,0xd0,0x66,0xc7,0x44,0x24,0x20,0x00,0x00,0x66,0xc7,0x44,0x24,0x22,0x00,0x00,0x0f,0xb7,0xc0,0x66,0x89,0x44,0x24,0x20,0x0f,0xb7,0xc2,0x66,0x89,0x44,0x24,0x22,0x48,0x8d,0x44,0x24,0x60,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x00,0x8b,0x44,0x24,0x20,0x89,0x44,0x24,0x58,0x0f,0xb7,0x44,0x24,0x58,0x0f,0xb7,0x54,0x24,0x5a,0x48,0x8d,0x4c,0x24,0x68,0x66,0x89,0x01,0x66,0x89,0x51,0x02,0x4c,0x89,0x4c,0x24,0x60,0x48,0x8b,0xfb,0x48,0x8d,0x74,0x24,0x60,0xe8,0x05,0x40,0x3f,0x5b,0x48,0xa5,0x48,0x8b,0xc3,0x48,0x83,0xc4,0x70,0x5b,0x5e,0x5f,0xc3,0x33,0xd2,0x48,0x8d,0x4c,0x24,0x40,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x01,0x48,0x89,0x51,0x10,0x48,0x8d,0x4c,0x24,0x28,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x01,0x48,0x89,0x51,0x10,0x48,0xba,0x70,0xd6,0x39,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x89,0x54,0x24,0x28,0x48,0xba,0x78,0xd6,0x39,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x8d,0x4c,0x24,0x28,0x48,0x85,0xd2,0x75,0x0d,0x48,0xba,0x60,0x30,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x8d,0x49,0x08,0xe8,0xc5,0x3e,0x3f,0x5b,0xc7,0x44,0x24,0x38,0x12,0x00,0x00,0x00,0x48,0x8b,0x4c,0x24,0x28,0x48,0x89,0x4c,0x24,0x40,0x48,0x8b,0x4c,0x24,0x30,0x48,0x89,0x4c,0x24,0x48,0x8b,0x4c,0x24,0x38,0x89,0x4c,0x24,0x50,0x48,0xb9,0xc8,0x64,0x3d,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x09,0x48,0x8d,0x54,0x24,0x40,0xe8,0x6a,0x22,0x25,0xff};

        public static ReadOnlySpan<byte> tableヽgᐸ32uᐳᐤ16uㆍ16uㆍarray_32uᐤ  =>  new byte[326]{0x57,0x56,0x53,0x48,0x83,0xec,0x70,0xc5,0xf8,0x77,0x48,0x8b,0xf1,0x48,0x8d,0x7c,0x24,0x28,0xb9,0x12,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x48,0x8b,0xd9,0x0f,0xb7,0xc2,0x41,0x0f,0xb7,0xc8,0x0f,0xaf,0xc1,0x41,0x39,0x41,0x08,0x0f,0x94,0xc0,0x0f,0xb6,0xc0,0x84,0xc0,0x74,0x6f,0x0f,0xb7,0xc2,0x41,0x0f,0xb7,0xd0,0x66,0xc7,0x44,0x24,0x20,0x00,0x00,0x66,0xc7,0x44,0x24,0x22,0x00,0x00,0x0f,0xb7,0xc0,0x66,0x89,0x44,0x24,0x20,0x0f,0xb7,0xc2,0x66,0x89,0x44,0x24,0x22,0x48,0x8d,0x44,0x24,0x60,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x00,0x8b,0x44,0x24,0x20,0x89,0x44,0x24,0x58,0x0f,0xb7,0x44,0x24,0x58,0x0f,0xb7,0x54,0x24,0x5a,0x48,0x8d,0x4c,0x24,0x68,0x66,0x89,0x01,0x66,0x89,0x51,0x02,0x4c,0x89,0x4c,0x24,0x60,0x48,0x8b,0xfb,0x48,0x8d,0x74,0x24,0x60,0xe8,0x95,0x3e,0x3f,0x5b,0x48,0xa5,0x48,0x8b,0xc3,0x48,0x83,0xc4,0x70,0x5b,0x5e,0x5f,0xc3,0x33,0xd2,0x48,0x8d,0x4c,0x24,0x40,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x01,0x48,0x89,0x51,0x10,0x48,0x8d,0x4c,0x24,0x28,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x01,0x48,0x89,0x51,0x10,0x48,0xba,0x70,0xd6,0x39,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x89,0x54,0x24,0x28,0x48,0xba,0x78,0xd6,0x39,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x8d,0x4c,0x24,0x28,0x48,0x85,0xd2,0x75,0x0d,0x48,0xba,0x60,0x30,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x8d,0x49,0x08,0xe8,0x55,0x3d,0x3f,0x5b,0xc7,0x44,0x24,0x38,0x12,0x00,0x00,0x00,0x48,0x8b,0x4c,0x24,0x28,0x48,0x89,0x4c,0x24,0x40,0x48,0x8b,0x4c,0x24,0x30,0x48,0x89,0x4c,0x24,0x48,0x8b,0x4c,0x24,0x38,0x89,0x4c,0x24,0x50,0x48,0xb9,0xc8,0x64,0x3d,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x09,0x48,0x8d,0x54,0x24,0x40,0xe8,0xfa,0x20,0x25,0xff};

        public static ReadOnlySpan<byte> tableヽgᐸ64uᐳᐤ16uㆍ16uㆍarray_64uᐤ  =>  new byte[326]{0x57,0x56,0x53,0x48,0x83,0xec,0x70,0xc5,0xf8,0x77,0x48,0x8b,0xf1,0x48,0x8d,0x7c,0x24,0x28,0xb9,0x12,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x48,0x8b,0xd9,0x0f,0xb7,0xc2,0x41,0x0f,0xb7,0xc8,0x0f,0xaf,0xc1,0x41,0x39,0x41,0x08,0x0f,0x94,0xc0,0x0f,0xb6,0xc0,0x84,0xc0,0x74,0x6f,0x0f,0xb7,0xc2,0x41,0x0f,0xb7,0xd0,0x66,0xc7,0x44,0x24,0x20,0x00,0x00,0x66,0xc7,0x44,0x24,0x22,0x00,0x00,0x0f,0xb7,0xc0,0x66,0x89,0x44,0x24,0x20,0x0f,0xb7,0xc2,0x66,0x89,0x44,0x24,0x22,0x48,0x8d,0x44,0x24,0x60,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x00,0x8b,0x44,0x24,0x20,0x89,0x44,0x24,0x58,0x0f,0xb7,0x44,0x24,0x58,0x0f,0xb7,0x54,0x24,0x5a,0x48,0x8d,0x4c,0x24,0x68,0x66,0x89,0x01,0x66,0x89,0x51,0x02,0x4c,0x89,0x4c,0x24,0x60,0x48,0x8b,0xfb,0x48,0x8d,0x74,0x24,0x60,0xe8,0x25,0x3d,0x3f,0x5b,0x48,0xa5,0x48,0x8b,0xc3,0x48,0x83,0xc4,0x70,0x5b,0x5e,0x5f,0xc3,0x33,0xd2,0x48,0x8d,0x4c,0x24,0x40,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x01,0x48,0x89,0x51,0x10,0x48,0x8d,0x4c,0x24,0x28,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x01,0x48,0x89,0x51,0x10,0x48,0xba,0x70,0xd6,0x39,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x89,0x54,0x24,0x28,0x48,0xba,0x78,0xd6,0x39,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x8d,0x4c,0x24,0x28,0x48,0x85,0xd2,0x75,0x0d,0x48,0xba,0x60,0x30,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x8d,0x49,0x08,0xe8,0xe5,0x3b,0x3f,0x5b,0xc7,0x44,0x24,0x38,0x12,0x00,0x00,0x00,0x48,0x8b,0x4c,0x24,0x28,0x48,0x89,0x4c,0x24,0x40,0x48,0x8b,0x4c,0x24,0x30,0x48,0x89,0x4c,0x24,0x48,0x8b,0x4c,0x24,0x38,0x89,0x4c,0x24,0x50,0x48,0xb9,0xc8,0x64,0x3d,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x09,0x48,0x8d,0x54,0x24,0x40,0xe8,0x8a,0x1f,0x25,0xff};

    }
}
