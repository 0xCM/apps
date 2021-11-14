﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2021-11-14 3:49:56 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class lib_numerickinds
    {
        public static ReadOnlySpan<byte> kindヽᐤTypeᐤ  =>  new byte[198]{0x56,0x48,0x83,0xec,0x20,0x48,0x8b,0xf1,0x48,0x8b,0xce,0x48,0x8b,0x06,0x48,0x8b,0x40,0x70,0xff,0x50,0x30,0x85,0xc0,0x74,0x07,0x33,0xc0,0xe9,0xa0,0x00,0x00,0x00,0x48,0x8b,0xce,0x48,0x8b,0x06,0x48,0x8b,0x40,0x58,0xff,0x50,0x20,0x48,0x8b,0xc8,0x48,0x8b,0x00,0x48,0x8b,0x40,0x58,0xff,0x50,0x38,0x85,0xc0,0x75,0x05,0x48,0x8b,0xce,0xeb,0x10,0x48,0x8b,0xce,0x48,0x8b,0x06,0x48,0x8b,0x40,0x68,0xff,0x50,0x18,0x48,0x8b,0xc8,0xe8,0x78,0x90,0x67,0x5d,0x83,0xc0,0xfb,0x83,0xf8,0x09,0x77,0x5e,0x8b,0xc0,0x48,0x8d,0x15,0x5f,0x00,0x00,0x00,0x8b,0x14,0x82,0x48,0x8d,0x0d,0x95,0xff,0xff,0xff,0x48,0x03,0xd1,0xff,0xe2,0xb8,0x08,0x00,0x02,0x80,0xeb,0x41,0xb8,0x08,0x00,0x01,0x20,0xeb,0x3a,0xb8,0x10,0x00,0x08,0x80,0xeb,0x33,0xb8,0x10,0x00,0x04,0x20,0xeb,0x2c,0xb8,0x20,0x00,0x20,0x80,0xeb,0x25,0xb8,0x20,0x00,0x10,0x20,0xeb,0x1e,0xb8,0x40,0x00,0x80,0x80,0xeb,0x17,0xb8,0x40,0x00,0x40,0x20,0xeb,0x10,0xb8,0x20,0x00,0x00,0x42,0xeb,0x09,0xb8,0x40,0x00,0x00,0x44,0xeb,0x02,0x33,0xc0,0x48,0x83,0xc4,0x20,0x5e,0xc3};

        public static ReadOnlySpan<byte> typeヽᐤNumericKindᕀ32uᐤ  =>  new byte[349]{0x48,0x83,0xec,0x28,0x90,0x81,0xf9,0x20,0x00,0x00,0x42,0x77,0x4a,0x81,0xf9,0x10,0x00,0x04,0x20,0x77,0x19,0x81,0xf9,0x08,0x00,0x01,0x20,0x74,0x78,0x81,0xf9,0x10,0x00,0x04,0x20,0x0f,0x84,0x94,0x00,0x00,0x00,0xe9,0x1a,0x01,0x00,0x00,0x81,0xf9,0x20,0x00,0x10,0x20,0x0f,0x84,0xa8,0x00,0x00,0x00,0x81,0xf9,0x40,0x00,0x40,0x20,0x0f,0x84,0xcf,0x00,0x00,0x00,0x81,0xf9,0x20,0x00,0x00,0x42,0x0f,0x84,0xd4,0x00,0x00,0x00,0xe9,0xf1,0x00,0x00,0x00,0x81,0xf9,0x08,0x00,0x02,0x80,0x77,0x19,0x81,0xf9,0x40,0x00,0x00,0x44,0x0f,0x84,0xcc,0x00,0x00,0x00,0x81,0xf9,0x08,0x00,0x02,0x80,0x74,0x36,0xe9,0xd0,0x00,0x00,0x00,0x81,0xf9,0x10,0x00,0x08,0x80,0x74,0x51,0x81,0xf9,0x20,0x00,0x20,0x80,0x74,0x6b,0x81,0xf9,0x40,0x00,0x80,0x80,0x74,0x74,0xe9,0xb3,0x00,0x00,0x00,0x48,0xb9,0x60,0x77,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0x0c,0xdd,0xcc,0x5c,0xe9,0xae,0x00,0x00,0x00,0x48,0xb9,0x70,0x6f,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0xf8,0xdc,0xcc,0x5c,0xe9,0x9a,0x00,0x00,0x00,0x48,0xb9,0x40,0x87,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0xe4,0xdc,0xcc,0x5c,0xe9,0x86,0x00,0x00,0x00,0x48,0xb9,0x50,0x7f,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0xd0,0xdc,0xcc,0x5c,0xeb,0x75,0x48,0xb9,0xe0,0x96,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0xbf,0xdc,0xcc,0x5c,0xeb,0x64,0x48,0xb9,0x10,0x8f,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0xae,0xdc,0xcc,0x5c,0xeb,0x53,0x48,0xb9,0xb0,0x9e,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0x9d,0xdc,0xcc,0x5c,0xeb,0x42,0x48,0xb9,0x80,0xa6,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0x8c,0xdc,0xcc,0x5c,0xeb,0x31,0x48,0xb9,0x60,0xaf,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0x7b,0xdc,0xcc,0x5c,0xeb,0x20,0x48,0xb9,0x40,0xb8,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0x6a,0xdc,0xcc,0x5c,0xeb,0x0f,0x48,0xb9,0xe0,0x55,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0x59,0xdc,0xcc,0x5c,0x90,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> apikindヽᐤNumericKindᕀ32uᐤ  =>  new byte[20]{0x0f,0x1f,0x44,0x00,0x00,0xc1,0xe1,0x03,0xc1,0xe9,0x03,0xc1,0xe9,0x10,0x8b,0xc1,0xc1,0xe0,0x10,0xc3};

        public static ReadOnlySpan<byte> containsヽᐤNumericKindᕀ32uㆍScalarKindᕀ32uᐤ  =>  new byte[14]{0x0f,0x1f,0x44,0x00,0x00,0x85,0xca,0x0f,0x95,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> floatingヽᐤNumericKindᕀ32uᐤ  =>  new byte[18]{0x0f,0x1f,0x44,0x00,0x00,0xf7,0xc1,0x00,0x00,0x00,0x40,0x0f,0x95,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> floatingヽᐤTypeᐤ  =>  new byte[69]{0x56,0x48,0x83,0xec,0x20,0x48,0x8b,0xf1,0x48,0xb9,0x60,0xaf,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0x69,0x8a,0x2a,0x5b,0x48,0x3b,0xc6,0x74,0x1e,0x48,0xb9,0x40,0xb8,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0x55,0x8a,0x2a,0x5b,0x48,0x3b,0xc6,0x0f,0x94,0xc0,0x0f,0xb6,0xc0,0x48,0x83,0xc4,0x20,0x5e,0xc3,0xb8,0x01,0x00,0x00,0x00,0x48,0x83,0xc4,0x20,0x5e,0xc3};

        public static ReadOnlySpan<byte> floatingヽᐤdynamicᐤ  =>  new byte[73]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0xc1,0x48,0x85,0xc0,0x74,0x11,0x48,0xba,0x60,0xaf,0xac,0x7f,0xfe,0x7f,0x00,0x00,0x48,0x39,0x10,0x74,0x02,0x33,0xc0,0x48,0x85,0xc0,0x75,0x20,0x48,0x85,0xc9,0x74,0x11,0x48,0xb8,0x40,0xb8,0xac,0x7f,0xfe,0x7f,0x00,0x00,0x48,0x39,0x01,0x74,0x02,0x33,0xc9,0x48,0x85,0xc9,0x0f,0x95,0xc0,0x0f,0xb6,0xc0,0xc3,0xb8,0x01,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> charヽᐤNumericIndicatorᕀ16uᐤ  =>  new byte[9]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb7,0xc1,0xc3};

        public static ReadOnlySpan<byte> formatヽᐤNumericIndicatorᕀ16uᐤ  =>  new byte[28]{0x56,0x48,0x83,0xec,0x20,0x0f,0xb7,0xf1,0xb9,0x01,0x00,0x00,0x00,0xe8,0x76,0x18,0x7f,0xfb,0x66,0x89,0x70,0x0c,0x48,0x83,0xc4,0x20,0x5e,0xc3};

        public static ReadOnlySpan<byte> formatヽᐤNumericKindᕀ32uᐤ  =>  new byte[189]{0x57,0x56,0x53,0x48,0x83,0xec,0x40,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x48,0x89,0x44,0x24,0x38,0x8b,0xf1,0x48,0xb9,0x10,0x8f,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0xc2,0x4b,0x31,0x5b,0x48,0x8b,0xf8,0x0f,0xb7,0xce,0x89,0x4f,0x08,0xf7,0xc6,0x00,0x00,0x00,0x20,0x74,0x07,0xbb,0x75,0x00,0x00,0x00,0xeb,0x20,0xf7,0xc6,0x00,0x00,0x00,0x80,0x74,0x07,0xbb,0x69,0x00,0x00,0x00,0xeb,0x11,0xf7,0xc6,0x00,0x00,0x00,0x40,0x74,0x07,0xbb,0x66,0x00,0x00,0x00,0xeb,0x02,0x33,0xdb,0xb9,0x01,0x00,0x00,0x00,0xe8,0xe8,0x17,0x7f,0xfb,0x66,0x89,0x58,0x0c,0x45,0x33,0xc0,0x48,0xba,0x90,0x13,0xb6,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0xb9,0x80,0x95,0xb6,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x09,0x4c,0x8d,0x4c,0x24,0x20,0x49,0x89,0x39,0x49,0x89,0x41,0x08,0x4d,0x89,0x41,0x10,0x49,0x89,0x51,0x18,0x4c,0x8d,0x44,0x24,0x20,0x48,0x8b,0xd1,0x33,0xc9,0xe8,0x9c,0x35,0xc6,0x5a,0x90,0x48,0x83,0xc4,0x40,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> indicatorヽᐤTypeᐤ  =>  new byte[59]{0x48,0x83,0xec,0x28,0x90,0xe8,0xe6,0x07,0x62,0xfd,0xa9,0x00,0x00,0x00,0x20,0x74,0x07,0xb8,0x75,0x00,0x00,0x00,0xeb,0x1e,0xa9,0x00,0x00,0x00,0x80,0x74,0x07,0xb8,0x69,0x00,0x00,0x00,0xeb,0x10,0xa9,0x00,0x00,0x00,0x40,0x74,0x07,0xb8,0x66,0x00,0x00,0x00,0xeb,0x02,0x33,0xc0,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> indicatorヽᐤNumericKindᕀ32uᐤ  =>  new byte[50]{0x0f,0x1f,0x44,0x00,0x00,0xf7,0xc1,0x00,0x00,0x00,0x20,0x74,0x06,0xb8,0x75,0x00,0x00,0x00,0xc3,0xf7,0xc1,0x00,0x00,0x00,0x80,0x74,0x06,0xb8,0x69,0x00,0x00,0x00,0xc3,0xf7,0xc1,0x00,0x00,0x00,0x40,0x74,0x06,0xb8,0x66,0x00,0x00,0x00,0xc3,0x33,0xc0,0xc3};

        public static ReadOnlySpan<byte> keywordヽᐤNumericKindᕀ32uᐤ  =>  new byte[319]{0x0f,0x1f,0x44,0x00,0x00,0x81,0xf9,0x20,0x00,0x00,0x42,0x77,0x4a,0x81,0xf9,0x10,0x00,0x04,0x20,0x77,0x19,0x81,0xf9,0x08,0x00,0x01,0x20,0x74,0x78,0x81,0xf9,0x10,0x00,0x04,0x20,0x0f,0x84,0x90,0x00,0x00,0x00,0xe9,0x03,0x01,0x00,0x00,0x81,0xf9,0x20,0x00,0x10,0x20,0x0f,0x84,0x9d,0x00,0x00,0x00,0x81,0xf9,0x40,0x00,0x40,0x20,0x0f,0x84,0xbe,0x00,0x00,0x00,0x81,0xf9,0x20,0x00,0x00,0x42,0x0f,0x84,0xc1,0x00,0x00,0x00,0xe9,0xda,0x00,0x00,0x00,0x81,0xf9,0x08,0x00,0x02,0x80,0x77,0x19,0x81,0xf9,0x40,0x00,0x00,0x44,0x0f,0x84,0xb7,0x00,0x00,0x00,0x81,0xf9,0x08,0x00,0x02,0x80,0x74,0x34,0xe9,0xb9,0x00,0x00,0x00,0x81,0xf9,0x10,0x00,0x08,0x80,0x74,0x48,0x81,0xf9,0x20,0x00,0x20,0x80,0x74,0x5e,0x81,0xf9,0x40,0x00,0x80,0x80,0x74,0x65,0xe9,0x9c,0x00,0x00,0x00,0x48,0xb8,0xb0,0x95,0xb6,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x00,0xe9,0x97,0x00,0x00,0x00,0x48,0xb8,0xa8,0x95,0xb6,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x00,0xe9,0x85,0x00,0x00,0x00,0x48,0xb8,0xb8,0x95,0xb6,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x00,0xeb,0x76,0x48,0xb8,0xc0,0x95,0xb6,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x00,0xeb,0x67,0x48,0xb8,0xd0,0x95,0xb6,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x00,0xeb,0x58,0x48,0xb8,0xc8,0x95,0xb6,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x00,0xeb,0x49,0x48,0xb8,0xd8,0x95,0xb6,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x00,0xeb,0x3a,0x48,0xb8,0xe0,0x95,0xb6,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x00,0xeb,0x2b,0x48,0xb8,0xe8,0x95,0xb6,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x00,0xeb,0x1c,0x48,0xb8,0xf0,0x95,0xb6,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x00,0xeb,0x0d,0x48,0xb8,0x60,0x30,0xb6,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x00,0xc3};

        public static ReadOnlySpan<byte> nonkeywordヽᐤNumericKindᕀ32uᐤ  =>  new byte[319]{0x0f,0x1f,0x44,0x00,0x00,0x81,0xf9,0x20,0x00,0x00,0x42,0x77,0x4a,0x81,0xf9,0x10,0x00,0x04,0x20,0x77,0x19,0x81,0xf9,0x08,0x00,0x01,0x20,0x74,0x78,0x81,0xf9,0x10,0x00,0x04,0x20,0x0f,0x84,0x90,0x00,0x00,0x00,0xe9,0x03,0x01,0x00,0x00,0x81,0xf9,0x20,0x00,0x10,0x20,0x0f,0x84,0x9d,0x00,0x00,0x00,0x81,0xf9,0x40,0x00,0x40,0x20,0x0f,0x84,0xbe,0x00,0x00,0x00,0x81,0xf9,0x20,0x00,0x00,0x42,0x0f,0x84,0xc1,0x00,0x00,0x00,0xe9,0xda,0x00,0x00,0x00,0x81,0xf9,0x08,0x00,0x02,0x80,0x77,0x19,0x81,0xf9,0x40,0x00,0x00,0x44,0x0f,0x84,0xb7,0x00,0x00,0x00,0x81,0xf9,0x08,0x00,0x02,0x80,0x74,0x34,0xe9,0xb9,0x00,0x00,0x00,0x81,0xf9,0x10,0x00,0x08,0x80,0x74,0x48,0x81,0xf9,0x20,0x00,0x20,0x80,0x74,0x5e,0x81,0xf9,0x40,0x00,0x80,0x80,0x74,0x65,0xe9,0x9c,0x00,0x00,0x00,0x48,0xb8,0x48,0x3c,0xc1,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x00,0xe9,0x97,0x00,0x00,0x00,0x48,0xb8,0x50,0x3c,0xc1,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x00,0xe9,0x85,0x00,0x00,0x00,0x48,0xb8,0x58,0x3c,0xc1,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x00,0xeb,0x76,0x48,0xb8,0x60,0x3c,0xc1,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x00,0xeb,0x67,0x48,0xb8,0x68,0x3c,0xc1,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x00,0xeb,0x58,0x48,0xb8,0x70,0x3c,0xc1,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x00,0xeb,0x49,0x48,0xb8,0x78,0x3c,0xc1,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x00,0xeb,0x3a,0x48,0xb8,0x80,0x3c,0xc1,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x00,0xeb,0x2b,0x48,0xb8,0x88,0x3c,0xc1,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x00,0xeb,0x1c,0x48,0xb8,0x90,0x3c,0xc1,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x00,0xeb,0x0d,0x48,0xb8,0x60,0x30,0xb6,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x00,0xc3};

        public static ReadOnlySpan<byte> kindヽᐤTypeCodeᕀ32iᐤ  =>  new byte[107]{0x0f,0x1f,0x44,0x00,0x00,0x83,0xc1,0xfb,0x83,0xf9,0x09,0x77,0x5b,0x8b,0xc1,0x48,0x8d,0x15,0x5a,0x00,0x00,0x00,0x8b,0x14,0x82,0x48,0x8d,0x0d,0xe5,0xff,0xff,0xff,0x48,0x03,0xd1,0xff,0xe2,0xb8,0x08,0x00,0x02,0x80,0xc3,0xb8,0x08,0x00,0x01,0x20,0xc3,0xb8,0x10,0x00,0x08,0x80,0xc3,0xb8,0x10,0x00,0x04,0x20,0xeb,0x2c,0xb8,0x20,0x00,0x20,0x80,0xeb,0x25,0xb8,0x20,0x00,0x10,0x20,0xeb,0x1e,0xb8,0x40,0x00,0x80,0x80,0xeb,0x17,0xb8,0x40,0x00,0x40,0x20,0xeb,0x10,0xb8,0x20,0x00,0x00,0x42,0xeb,0x09,0xb8,0x40,0x00,0x00,0x44,0xeb,0x02,0x33,0xc0,0xc3};

        public static ReadOnlySpan<byte> kindヽᐤClrEnumKindᕀ8uᐤ  =>  new byte[140]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc1,0x83,0xf8,0x66,0x77,0x1d,0x83,0xf8,0x44,0x77,0x0c,0x83,0xf8,0x33,0x74,0x41,0x83,0xf8,0x44,0x74,0x4a,0xeb,0x6b,0x83,0xf8,0x55,0x74,0x51,0x83,0xf8,0x66,0x74,0x5a,0xeb,0x5f,0x3d,0xbc,0x00,0x00,0x00,0x77,0x10,0x3d,0xab,0x00,0x00,0x00,0x74,0x19,0x3d,0xbc,0x00,0x00,0x00,0x74,0x20,0xeb,0x48,0x3d,0xcd,0x00,0x00,0x00,0x74,0x25,0x3d,0xde,0x00,0x00,0x00,0x74,0x2c,0xeb,0x38,0xb8,0x08,0x00,0x02,0x80,0xeb,0x33,0xb8,0x08,0x00,0x01,0x20,0xeb,0x2c,0xb8,0x10,0x00,0x08,0x80,0xeb,0x25,0xb8,0x10,0x00,0x04,0x20,0xeb,0x1e,0xb8,0x20,0x00,0x20,0x80,0xeb,0x17,0xb8,0x20,0x00,0x10,0x20,0xeb,0x10,0xb8,0x40,0x00,0x80,0x80,0xeb,0x09,0xb8,0x40,0x00,0x40,0x20,0xeb,0x02,0x33,0xc0,0xc3};

        public static ReadOnlySpan<byte> kindヽᐤNumericWidthᕀ8uㆍNumericIndicatorᕀ16uᐤ  =>  new byte[196]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb7,0xc2,0x83,0xf8,0x66,0x0f,0x84,0x8f,0x00,0x00,0x00,0x83,0xf8,0x69,0x74,0x0a,0x83,0xf8,0x75,0x74,0x45,0xe9,0xa1,0x00,0x00,0x00,0x0f,0xb6,0xc1,0x83,0xf8,0x10,0x77,0x0c,0x83,0xf8,0x08,0x74,0x13,0x83,0xf8,0x10,0x74,0x15,0xeb,0x28,0x83,0xf8,0x20,0x74,0x15,0x83,0xf8,0x40,0x74,0x17,0xeb,0x1c,0xb8,0x08,0x00,0x02,0x80,0xeb,0x17,0xb8,0x10,0x00,0x08,0x80,0xeb,0x10,0xb8,0x20,0x00,0x20,0x80,0xeb,0x09,0xb8,0x40,0x00,0x80,0x80,0xeb,0x02,0x33,0xc0,0xeb,0x63,0x0f,0xb6,0xc1,0x83,0xf8,0x10,0x77,0x0c,0x83,0xf8,0x08,0x74,0x13,0x83,0xf8,0x10,0x74,0x15,0xeb,0x28,0x83,0xf8,0x20,0x74,0x15,0x83,0xf8,0x40,0x74,0x17,0xeb,0x1c,0xb8,0x08,0x00,0x01,0x20,0xeb,0x17,0xb8,0x10,0x00,0x04,0x20,0xeb,0x10,0xb8,0x20,0x00,0x10,0x20,0xeb,0x09,0xb8,0x40,0x00,0x40,0x20,0xeb,0x02,0x33,0xc0,0xeb,0x23,0x0f,0xb6,0xc1,0x83,0xf8,0x20,0x74,0x07,0x83,0xf8,0x40,0x74,0x09,0xeb,0x0e,0xb8,0x20,0x00,0x00,0x42,0xeb,0x09,0xb8,0x40,0x00,0x00,0x44,0xeb,0x02,0x33,0xc0,0xeb,0x02,0x33,0xc0,0xc3};

        public static ReadOnlySpan<byte> signedヽᐤNumericKindᕀ32uᐤ  =>  new byte[18]{0x0f,0x1f,0x44,0x00,0x00,0xf7,0xc1,0x00,0x00,0x00,0x80,0x0f,0x95,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> signedヽᐤTypeᐤ  =>  new byte[109]{0x56,0x48,0x83,0xec,0x20,0x48,0x8b,0xf1,0x48,0xb9,0x70,0x6f,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0xd9,0x82,0x2a,0x5b,0x48,0x3b,0xc6,0x74,0x46,0x48,0xb9,0x50,0x7f,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0xc5,0x82,0x2a,0x5b,0x48,0x3b,0xc6,0x74,0x32,0x48,0xb9,0x10,0x8f,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0xb1,0x82,0x2a,0x5b,0x48,0x3b,0xc6,0x74,0x1e,0x48,0xb9,0xb0,0x9e,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0x9d,0x82,0x2a,0x5b,0x48,0x3b,0xc6,0x0f,0x94,0xc0,0x0f,0xb6,0xc0,0x48,0x83,0xc4,0x20,0x5e,0xc3,0xb8,0x01,0x00,0x00,0x00,0x48,0x83,0xc4,0x20,0x5e,0xc3};

        public static ReadOnlySpan<byte> signedヽᐤdynamicᐤ  =>  new byte[133]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0xc1,0x48,0x85,0xc0,0x74,0x11,0x48,0xba,0x70,0x6f,0xac,0x7f,0xfe,0x7f,0x00,0x00,0x48,0x39,0x10,0x74,0x02,0x33,0xc0,0x48,0x85,0xc0,0x75,0x5c,0x48,0x8b,0xc1,0x48,0x85,0xc0,0x74,0x11,0x48,0xba,0x50,0x7f,0xac,0x7f,0xfe,0x7f,0x00,0x00,0x48,0x39,0x10,0x74,0x02,0x33,0xc0,0x48,0x85,0xc0,0x75,0x3e,0x48,0x8b,0xc1,0x48,0x85,0xc0,0x74,0x11,0x48,0xba,0x10,0x8f,0xac,0x7f,0xfe,0x7f,0x00,0x00,0x48,0x39,0x10,0x74,0x02,0x33,0xc0,0x48,0x85,0xc0,0x75,0x20,0x48,0x85,0xc9,0x74,0x11,0x48,0xb8,0xb0,0x9e,0xac,0x7f,0xfe,0x7f,0x00,0x00,0x48,0x39,0x01,0x74,0x02,0x33,0xc9,0x48,0x85,0xc9,0x0f,0x95,0xc0,0x0f,0xb6,0xc0,0xc3,0xb8,0x01,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> sizeヽᐤNumericKindᕀ32uᐤ  =>  new byte[25]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb7,0xc1,0x8b,0xd0,0xc1,0xfa,0x1f,0x83,0xe2,0x07,0x03,0xc2,0xc1,0xf8,0x03,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> testヽᐤTypeᐤ  =>  new byte[23]{0x48,0x83,0xec,0x28,0x90,0xe8,0xe6,0x00,0x62,0xfd,0x85,0xc0,0x0f,0x95,0xc0,0x0f,0xb6,0xc0,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> unsignedヽᐤNumericKindᕀ32uᐤ  =>  new byte[18]{0x0f,0x1f,0x44,0x00,0x00,0xf7,0xc1,0x00,0x00,0x00,0x20,0x0f,0x95,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> unsignedヽᐤTypeᐤ  =>  new byte[109]{0x56,0x48,0x83,0xec,0x20,0x48,0x8b,0xf1,0x48,0xb9,0x60,0x77,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0x19,0x81,0x2a,0x5b,0x48,0x3b,0xc6,0x74,0x46,0x48,0xb9,0x40,0x87,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0x05,0x81,0x2a,0x5b,0x48,0x3b,0xc6,0x74,0x32,0x48,0xb9,0xe0,0x96,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0xf1,0x80,0x2a,0x5b,0x48,0x3b,0xc6,0x74,0x1e,0x48,0xb9,0x80,0xa6,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0xdd,0x80,0x2a,0x5b,0x48,0x3b,0xc6,0x0f,0x94,0xc0,0x0f,0xb6,0xc0,0x48,0x83,0xc4,0x20,0x5e,0xc3,0xb8,0x01,0x00,0x00,0x00,0x48,0x83,0xc4,0x20,0x5e,0xc3};

        public static ReadOnlySpan<byte> unsignedヽᐤdynamicᐤ  =>  new byte[133]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0xc1,0x48,0x85,0xc0,0x74,0x11,0x48,0xba,0x60,0x77,0xac,0x7f,0xfe,0x7f,0x00,0x00,0x48,0x39,0x10,0x74,0x02,0x33,0xc0,0x48,0x85,0xc0,0x75,0x5c,0x48,0x8b,0xc1,0x48,0x85,0xc0,0x74,0x11,0x48,0xba,0x40,0x87,0xac,0x7f,0xfe,0x7f,0x00,0x00,0x48,0x39,0x10,0x74,0x02,0x33,0xc0,0x48,0x85,0xc0,0x75,0x3e,0x48,0x8b,0xc1,0x48,0x85,0xc0,0x74,0x11,0x48,0xba,0xe0,0x96,0xac,0x7f,0xfe,0x7f,0x00,0x00,0x48,0x39,0x10,0x74,0x02,0x33,0xc0,0x48,0x85,0xc0,0x75,0x20,0x48,0x85,0xc9,0x74,0x11,0x48,0xb8,0x80,0xa6,0xac,0x7f,0xfe,0x7f,0x00,0x00,0x48,0x39,0x01,0x74,0x02,0x33,0xc9,0x48,0x85,0xc9,0x0f,0x95,0xc0,0x0f,0xb6,0xc0,0xc3,0xb8,0x01,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> widthヽᐤNumericKindᕀ32uᐤ  =>  new byte[9]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb7,0xc1,0xc3};

        public static ReadOnlySpan<byte> UnsignedTypesヽᐤᐤ  =>  new byte[158]{0x56,0x48,0x83,0xec,0x20,0x48,0xb9,0x88,0x77,0xb8,0x7f,0xfe,0x7f,0x00,0x00,0xba,0x04,0x00,0x00,0x00,0xe8,0xd7,0x43,0x31,0x5b,0x48,0x8b,0xf0,0x48,0xb9,0x60,0x77,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0xb5,0x7f,0x2a,0x5b,0x4c,0x8b,0xc0,0x48,0x8b,0xce,0x33,0xd2,0xe8,0x88,0x34,0x31,0x5b,0x48,0xb9,0x40,0x87,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0x99,0x7f,0x2a,0x5b,0x4c,0x8b,0xc0,0x48,0x8b,0xce,0xba,0x01,0x00,0x00,0x00,0xe8,0x69,0x34,0x31,0x5b,0x48,0xb9,0xe0,0x96,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0x7a,0x7f,0x2a,0x5b,0x4c,0x8b,0xc0,0x48,0x8b,0xce,0xba,0x02,0x00,0x00,0x00,0xe8,0x4a,0x34,0x31,0x5b,0x48,0xb9,0x80,0xa6,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0x5b,0x7f,0x2a,0x5b,0x4c,0x8b,0xc0,0x48,0x8b,0xce,0xba,0x03,0x00,0x00,0x00,0xe8,0x2b,0x34,0x31,0x5b,0x48,0x8b,0xc6,0x48,0x83,0xc4,0x20,0x5e,0xc3};

        public static ReadOnlySpan<byte> UnsignedKindsヽᐤᐤ  =>  new byte[54]{0x48,0x83,0xec,0x28,0xc5,0xf8,0x77,0x48,0xb9,0x18,0x3d,0x22,0x81,0xfe,0x7f,0x00,0x00,0xba,0x04,0x00,0x00,0x00,0xe8,0xb5,0x42,0x31,0x5b,0x48,0xba,0xc0,0x47,0x66,0x4e,0x59,0x02,0x00,0x00,0x48,0x8d,0x48,0x10,0xc5,0xfa,0x6f,0x02,0xc5,0xfa,0x7f,0x01,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> SignedTypesヽᐤᐤ  =>  new byte[158]{0x56,0x48,0x83,0xec,0x20,0x48,0xb9,0x88,0x77,0xb8,0x7f,0xfe,0x7f,0x00,0x00,0xba,0x04,0x00,0x00,0x00,0xe8,0xc7,0x42,0x31,0x5b,0x48,0x8b,0xf0,0x48,0xb9,0x70,0x6f,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0xa5,0x7e,0x2a,0x5b,0x4c,0x8b,0xc0,0x48,0x8b,0xce,0x33,0xd2,0xe8,0x78,0x33,0x31,0x5b,0x48,0xb9,0x50,0x7f,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0x89,0x7e,0x2a,0x5b,0x4c,0x8b,0xc0,0x48,0x8b,0xce,0xba,0x01,0x00,0x00,0x00,0xe8,0x59,0x33,0x31,0x5b,0x48,0xb9,0x10,0x8f,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0x6a,0x7e,0x2a,0x5b,0x4c,0x8b,0xc0,0x48,0x8b,0xce,0xba,0x02,0x00,0x00,0x00,0xe8,0x3a,0x33,0x31,0x5b,0x48,0xb9,0xb0,0x9e,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0x4b,0x7e,0x2a,0x5b,0x4c,0x8b,0xc0,0x48,0x8b,0xce,0xba,0x03,0x00,0x00,0x00,0xe8,0x1b,0x33,0x31,0x5b,0x48,0x8b,0xc6,0x48,0x83,0xc4,0x20,0x5e,0xc3};

        public static ReadOnlySpan<byte> SignedKindsヽᐤᐤ  =>  new byte[54]{0x48,0x83,0xec,0x28,0xc5,0xf8,0x77,0x48,0xb9,0x18,0x3d,0x22,0x81,0xfe,0x7f,0x00,0x00,0xba,0x04,0x00,0x00,0x00,0xe8,0xa5,0x41,0x31,0x5b,0x48,0xba,0xc8,0x3c,0x66,0x4e,0x59,0x02,0x00,0x00,0x48,0x8d,0x48,0x10,0xc5,0xfa,0x6f,0x02,0xc5,0xfa,0x7f,0x01,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> FloatingTypesヽᐤᐤ  =>  new byte[96]{0x56,0x48,0x83,0xec,0x20,0x48,0xb9,0x88,0x77,0xb8,0x7f,0xfe,0x7f,0x00,0x00,0xba,0x02,0x00,0x00,0x00,0xe8,0xb7,0x41,0x31,0x5b,0x48,0x8b,0xf0,0x48,0xb9,0x60,0xaf,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0x95,0x7d,0x2a,0x5b,0x4c,0x8b,0xc0,0x48,0x8b,0xce,0x33,0xd2,0xe8,0x68,0x32,0x31,0x5b,0x48,0xb9,0x40,0xb8,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0x79,0x7d,0x2a,0x5b,0x4c,0x8b,0xc0,0x48,0x8b,0xce,0xba,0x01,0x00,0x00,0x00,0xe8,0x49,0x32,0x31,0x5b,0x48,0x8b,0xc6,0x48,0x83,0xc4,0x20,0x5e,0xc3};

        public static ReadOnlySpan<byte> FloatingKindsヽᐤᐤ  =>  new byte[44]{0x48,0x83,0xec,0x28,0x90,0x48,0xb9,0x18,0x3d,0x22,0x81,0xfe,0x7f,0x00,0x00,0xba,0x02,0x00,0x00,0x00,0xe8,0xd7,0x40,0x31,0x5b,0xc7,0x40,0x10,0x20,0x00,0x00,0x42,0xc7,0x40,0x14,0x40,0x00,0x00,0x44,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> IntegralTypesヽᐤᐤ  =>  new byte[58]{0x56,0x48,0x83,0xec,0x20,0xe8,0x26,0xfe,0xff,0xff,0x48,0x8b,0xf0,0xe8,0x0e,0xfd,0xff,0xff,0x4c,0x8b,0xc0,0x48,0x8b,0xd6,0x48,0xb9,0x08,0x9e,0x50,0x84,0xfe,0x7f,0x00,0x00,0x45,0x33,0xc9,0x48,0xb8,0x28,0xea,0x55,0x83,0xfe,0x7f,0x00,0x00,0x48,0x83,0xc4,0x20,0x5e,0x48,0xff,0xe0,0x00,0x19,0x05};

        public static ReadOnlySpan<byte> IntegralKindSeqヽᐤᐤ  =>  new byte[58]{0x56,0x48,0x83,0xec,0x20,0xe8,0x86,0xfd,0xff,0xff,0x48,0x8b,0xf0,0xe8,0x8e,0xfe,0xff,0xff,0x48,0x8b,0xd0,0x48,0x8b,0xce,0x45,0x33,0xc0,0xe8,0xb0,0xc9,0xff,0xff,0x48,0x8b,0xc8,0x48,0xb8,0xb0,0xd2,0x8d,0x82,0xfe,0x7f,0x00,0x00,0x48,0x83,0xc4,0x20,0x5e,0x48,0xff,0xe0,0x00,0x00,0x00,0x19,0x05};

        public static ReadOnlySpan<byte> NumericTypesヽᐤᐤ  =>  new byte[136]{0x56,0x48,0x83,0xec,0x20,0xe8,0x86,0xfd,0xff,0xff,0x48,0x8b,0xf0,0xe8,0x6e,0xfc,0xff,0xff,0x4c,0x8b,0xc0,0x48,0x8b,0xd6,0x48,0xb9,0x08,0x9e,0x50,0x84,0xfe,0x7f,0x00,0x00,0x45,0x33,0xc9,0xe8,0x9e,0xb0,0x25,0xff,0x48,0x8b,0xf0,0xe8,0x6e,0xfe,0xff,0xff,0x4c,0x8b,0xc0,0x48,0x8b,0xd6,0x48,0xb9,0x08,0x9e,0x50,0x84,0xfe,0x7f,0x00,0x00,0x45,0x33,0xc9,0xe8,0x7e,0xb0,0x25,0xff,0x48,0x8b,0xd0,0x48,0xb9,0x88,0xae,0xf2,0x81,0xfe,0x7f,0x00,0x00,0x48,0xb8,0x40,0x60,0x57,0xf2,0xfe,0x7f,0x00,0x00,0x48,0x83,0xc4,0x20,0x5e,0x48,0xff,0xe0,0x00,0x00,0x00,0x19,0x05,0x02,0x00,0x05,0x32,0x01,0x60,0x40,0x00,0x00,0x00,0xf8,0x11,0x51,0x84,0xfe,0x7f,0x00,0x00,0x0f,0x1f,0x44,0x00,0x00,0x33,0xc0,0xc3};

        public static ReadOnlySpan<byte> floatingヽgᐸ8uᐳᐤᐤ  =>  new byte[8]{0x0f,0x1f,0x44,0x00,0x00,0x33,0xc0,0xc3};

        public static ReadOnlySpan<byte> floatingヽgᐸ8iᐳᐤᐤ  =>  new byte[8]{0x0f,0x1f,0x44,0x00,0x00,0x33,0xc0,0xc3};

        public static ReadOnlySpan<byte> floatingヽgᐸ16uᐳᐤᐤ  =>  new byte[8]{0x0f,0x1f,0x44,0x00,0x00,0x33,0xc0,0xc3};

        public static ReadOnlySpan<byte> floatingヽgᐸ16iᐳᐤᐤ  =>  new byte[8]{0x0f,0x1f,0x44,0x00,0x00,0x33,0xc0,0xc3};

        public static ReadOnlySpan<byte> floatingヽgᐸ32uᐳᐤᐤ  =>  new byte[8]{0x0f,0x1f,0x44,0x00,0x00,0x33,0xc0,0xc3};

        public static ReadOnlySpan<byte> floatingヽgᐸ32iᐳᐤᐤ  =>  new byte[8]{0x0f,0x1f,0x44,0x00,0x00,0x33,0xc0,0xc3};

        public static ReadOnlySpan<byte> floatingヽgᐸ64uᐳᐤᐤ  =>  new byte[8]{0x0f,0x1f,0x44,0x00,0x00,0x33,0xc0,0xc3};

        public static ReadOnlySpan<byte> floatingヽgᐸ64iᐳᐤᐤ  =>  new byte[8]{0x0f,0x1f,0x44,0x00,0x00,0x33,0xc0,0xc3};

        public static ReadOnlySpan<byte> floatingヽgᐸ32fᐳᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x01,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> floatingヽgᐸ64fᐳᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x01,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> indicatorヽgᐸ8uᐳᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x75,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> indicatorヽgᐸ8iᐳᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x69,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> indicatorヽgᐸ16uᐳᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x75,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> indicatorヽgᐸ16iᐳᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x69,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> indicatorヽgᐸ32uᐳᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x75,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> indicatorヽgᐸ32iᐳᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x69,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> indicatorヽgᐸ64uᐳᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x75,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> indicatorヽgᐸ64iᐳᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x69,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> indicatorヽgᐸ32fᐳᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x66,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> indicatorヽgᐸ64fᐳᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x66,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> keywordヽgᐸ8uᐳᐤᐤ  =>  new byte[19]{0x0f,0x1f,0x44,0x00,0x00,0x48,0xb8,0xb0,0x95,0xb6,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x00,0xc3};

        public static ReadOnlySpan<byte> keywordヽgᐸ8iᐳᐤᐤ  =>  new byte[19]{0x0f,0x1f,0x44,0x00,0x00,0x48,0xb8,0xa8,0x95,0xb6,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x00,0xc3};

        public static ReadOnlySpan<byte> keywordヽgᐸ16uᐳᐤᐤ  =>  new byte[19]{0x0f,0x1f,0x44,0x00,0x00,0x48,0xb8,0xb8,0x95,0xb6,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x00,0xc3};

        public static ReadOnlySpan<byte> keywordヽgᐸ16iᐳᐤᐤ  =>  new byte[19]{0x0f,0x1f,0x44,0x00,0x00,0x48,0xb8,0xc0,0x95,0xb6,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x00,0xc3};

        public static ReadOnlySpan<byte> keywordヽgᐸ32uᐳᐤᐤ  =>  new byte[19]{0x0f,0x1f,0x44,0x00,0x00,0x48,0xb8,0xd0,0x95,0xb6,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x00,0xc3};

        public static ReadOnlySpan<byte> keywordヽgᐸ32iᐳᐤᐤ  =>  new byte[19]{0x0f,0x1f,0x44,0x00,0x00,0x48,0xb8,0xc8,0x95,0xb6,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x00,0xc3};

        public static ReadOnlySpan<byte> keywordヽgᐸ64uᐳᐤᐤ  =>  new byte[19]{0x0f,0x1f,0x44,0x00,0x00,0x48,0xb8,0xe0,0x95,0xb6,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x00,0xc3};

        public static ReadOnlySpan<byte> keywordヽgᐸ64iᐳᐤᐤ  =>  new byte[19]{0x0f,0x1f,0x44,0x00,0x00,0x48,0xb8,0xd8,0x95,0xb6,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x00,0xc3};

        public static ReadOnlySpan<byte> keywordヽgᐸ32fᐳᐤᐤ  =>  new byte[19]{0x0f,0x1f,0x44,0x00,0x00,0x48,0xb8,0xe8,0x95,0xb6,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x00,0xc3};

        public static ReadOnlySpan<byte> keywordヽgᐸ64fᐳᐤᐤ  =>  new byte[19]{0x0f,0x1f,0x44,0x00,0x00,0x48,0xb8,0xf0,0x95,0xb6,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x00,0xc3};

        public static ReadOnlySpan<byte> kindヽgᐸ8uᐳᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x08,0x00,0x01,0x20,0xc3};

        public static ReadOnlySpan<byte> kindヽgᐸ8iᐳᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x08,0x00,0x02,0x80,0xc3};

        public static ReadOnlySpan<byte> kindヽgᐸ16uᐳᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x10,0x00,0x04,0x20,0xc3};

        public static ReadOnlySpan<byte> kindヽgᐸ16iᐳᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x10,0x00,0x08,0x80,0xc3};

        public static ReadOnlySpan<byte> kindヽgᐸ32uᐳᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x20,0x00,0x10,0x20,0xc3};

        public static ReadOnlySpan<byte> kindヽgᐸ32iᐳᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x20,0x00,0x20,0x80,0xc3};

        public static ReadOnlySpan<byte> kindヽgᐸ64uᐳᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x40,0x00,0x40,0x20,0xc3};

        public static ReadOnlySpan<byte> kindヽgᐸ64iᐳᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x40,0x00,0x80,0x80,0xc3};

        public static ReadOnlySpan<byte> kindヽgᐸ32fᐳᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x20,0x00,0x00,0x42,0xc3};

        public static ReadOnlySpan<byte> kindヽgᐸ64fᐳᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x40,0x00,0x00,0x44,0xc3};

        public static ReadOnlySpan<byte> signedヽgᐸ8uᐳᐤᐤ  =>  new byte[8]{0x0f,0x1f,0x44,0x00,0x00,0x33,0xc0,0xc3};

        public static ReadOnlySpan<byte> signedヽgᐸ8iᐳᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x01,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> signedヽgᐸ16uᐳᐤᐤ  =>  new byte[8]{0x0f,0x1f,0x44,0x00,0x00,0x33,0xc0,0xc3};

        public static ReadOnlySpan<byte> signedヽgᐸ16iᐳᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x01,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> signedヽgᐸ32uᐳᐤᐤ  =>  new byte[8]{0x0f,0x1f,0x44,0x00,0x00,0x33,0xc0,0xc3};

        public static ReadOnlySpan<byte> signedヽgᐸ32iᐳᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x01,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> signedヽgᐸ64uᐳᐤᐤ  =>  new byte[8]{0x0f,0x1f,0x44,0x00,0x00,0x33,0xc0,0xc3};

        public static ReadOnlySpan<byte> signedヽgᐸ64iᐳᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x01,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> signedヽgᐸ32fᐳᐤᐤ  =>  new byte[8]{0x0f,0x1f,0x44,0x00,0x00,0x33,0xc0,0xc3};

        public static ReadOnlySpan<byte> signedヽgᐸ64fᐳᐤᐤ  =>  new byte[8]{0x0f,0x1f,0x44,0x00,0x00,0x33,0xc0,0xc3};

        public static ReadOnlySpan<byte> typecodeヽgᐸ8uᐳᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x06,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> typecodeヽgᐸ8iᐳᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x05,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> typecodeヽgᐸ16uᐳᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x08,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> typecodeヽgᐸ16iᐳᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x07,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> typecodeヽgᐸ32uᐳᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x0a,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> typecodeヽgᐸ32iᐳᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x09,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> typecodeヽgᐸ64uᐳᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x0c,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> typecodeヽgᐸ64iᐳᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x0b,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> typecodeヽgᐸ32fᐳᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x0d,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> typecodeヽgᐸ64fᐳᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x0e,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> findヽgᐸ8uᐳᐤᐤ  =>  new byte[50]{0x56,0x48,0x83,0xec,0x20,0x48,0x8b,0xf1,0x48,0xb9,0x60,0x77,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0xa9,0x6f,0x2a,0x5b,0x48,0x8b,0xd0,0x48,0x8b,0xce,0xe8,0x2e,0x23,0x31,0x5b,0xc7,0x46,0x08,0x08,0x00,0x01,0x20,0x48,0x8b,0xc6,0x48,0x83,0xc4,0x20,0x5e,0xc3};

        public static ReadOnlySpan<byte> findヽgᐸ8iᐳᐤᐤ  =>  new byte[50]{0x56,0x48,0x83,0xec,0x20,0x48,0x8b,0xf1,0x48,0xb9,0x70,0x6f,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0x59,0x6b,0x2a,0x5b,0x48,0x8b,0xd0,0x48,0x8b,0xce,0xe8,0xde,0x1e,0x31,0x5b,0xc7,0x46,0x08,0x08,0x00,0x02,0x80,0x48,0x8b,0xc6,0x48,0x83,0xc4,0x20,0x5e,0xc3};

        public static ReadOnlySpan<byte> findヽgᐸ16uᐳᐤᐤ  =>  new byte[50]{0x56,0x48,0x83,0xec,0x20,0x48,0x8b,0xf1,0x48,0xb9,0x40,0x87,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0x09,0x6b,0x2a,0x5b,0x48,0x8b,0xd0,0x48,0x8b,0xce,0xe8,0x8e,0x1e,0x31,0x5b,0xc7,0x46,0x08,0x10,0x00,0x04,0x20,0x48,0x8b,0xc6,0x48,0x83,0xc4,0x20,0x5e,0xc3};

        public static ReadOnlySpan<byte> findヽgᐸ16iᐳᐤᐤ  =>  new byte[50]{0x56,0x48,0x83,0xec,0x20,0x48,0x8b,0xf1,0x48,0xb9,0x50,0x7f,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0xb9,0x6a,0x2a,0x5b,0x48,0x8b,0xd0,0x48,0x8b,0xce,0xe8,0x3e,0x1e,0x31,0x5b,0xc7,0x46,0x08,0x10,0x00,0x08,0x80,0x48,0x8b,0xc6,0x48,0x83,0xc4,0x20,0x5e,0xc3};

        public static ReadOnlySpan<byte> findヽgᐸ32uᐳᐤᐤ  =>  new byte[50]{0x56,0x48,0x83,0xec,0x20,0x48,0x8b,0xf1,0x48,0xb9,0xe0,0x96,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0x69,0x6a,0x2a,0x5b,0x48,0x8b,0xd0,0x48,0x8b,0xce,0xe8,0xee,0x1d,0x31,0x5b,0xc7,0x46,0x08,0x20,0x00,0x10,0x20,0x48,0x8b,0xc6,0x48,0x83,0xc4,0x20,0x5e,0xc3};

        public static ReadOnlySpan<byte> findヽgᐸ32iᐳᐤᐤ  =>  new byte[50]{0x56,0x48,0x83,0xec,0x20,0x48,0x8b,0xf1,0x48,0xb9,0x10,0x8f,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0x19,0x6a,0x2a,0x5b,0x48,0x8b,0xd0,0x48,0x8b,0xce,0xe8,0x9e,0x1d,0x31,0x5b,0xc7,0x46,0x08,0x20,0x00,0x20,0x80,0x48,0x8b,0xc6,0x48,0x83,0xc4,0x20,0x5e,0xc3};

        public static ReadOnlySpan<byte> findヽgᐸ64uᐳᐤᐤ  =>  new byte[50]{0x56,0x48,0x83,0xec,0x20,0x48,0x8b,0xf1,0x48,0xb9,0x80,0xa6,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0xc9,0x69,0x2a,0x5b,0x48,0x8b,0xd0,0x48,0x8b,0xce,0xe8,0x4e,0x1d,0x31,0x5b,0xc7,0x46,0x08,0x40,0x00,0x40,0x20,0x48,0x8b,0xc6,0x48,0x83,0xc4,0x20,0x5e,0xc3};

        public static ReadOnlySpan<byte> findヽgᐸ64iᐳᐤᐤ  =>  new byte[50]{0x56,0x48,0x83,0xec,0x20,0x48,0x8b,0xf1,0x48,0xb9,0xb0,0x9e,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0x79,0x69,0x2a,0x5b,0x48,0x8b,0xd0,0x48,0x8b,0xce,0xe8,0xfe,0x1c,0x31,0x5b,0xc7,0x46,0x08,0x40,0x00,0x80,0x80,0x48,0x8b,0xc6,0x48,0x83,0xc4,0x20,0x5e,0xc3};

        public static ReadOnlySpan<byte> findヽgᐸ32fᐳᐤᐤ  =>  new byte[48]{0x56,0x48,0x83,0xec,0x20,0x48,0x8b,0xf1,0x48,0xb9,0x60,0x77,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0x29,0x69,0x2a,0x5b,0x48,0x8b,0xd0,0x48,0x8b,0xce,0xe8,0xae,0x1c,0x31,0x5b,0x33,0xc0,0x89,0x46,0x08,0x48,0x8b,0xc6,0x48,0x83,0xc4,0x20,0x5e,0xc3};

        public static ReadOnlySpan<byte> findヽgᐸ64fᐳᐤᐤ  =>  new byte[48]{0x56,0x48,0x83,0xec,0x20,0x48,0x8b,0xf1,0x48,0xb9,0x60,0x77,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0xd9,0x68,0x2a,0x5b,0x48,0x8b,0xd0,0x48,0x8b,0xce,0xe8,0x5e,0x1c,0x31,0x5b,0x33,0xc0,0x89,0x46,0x08,0x48,0x8b,0xc6,0x48,0x83,0xc4,0x20,0x5e,0xc3};

        public static ReadOnlySpan<byte> unsignedヽgᐸ8uᐳᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x01,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> unsignedヽgᐸ8iᐳᐤᐤ  =>  new byte[8]{0x0f,0x1f,0x44,0x00,0x00,0x33,0xc0,0xc3};

        public static ReadOnlySpan<byte> unsignedヽgᐸ16uᐳᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x01,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> unsignedヽgᐸ16iᐳᐤᐤ  =>  new byte[8]{0x0f,0x1f,0x44,0x00,0x00,0x33,0xc0,0xc3};

        public static ReadOnlySpan<byte> unsignedヽgᐸ32uᐳᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x01,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> unsignedヽgᐸ32iᐳᐤᐤ  =>  new byte[8]{0x0f,0x1f,0x44,0x00,0x00,0x33,0xc0,0xc3};

        public static ReadOnlySpan<byte> unsignedヽgᐸ64uᐳᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x01,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> unsignedヽgᐸ64iᐳᐤᐤ  =>  new byte[8]{0x0f,0x1f,0x44,0x00,0x00,0x33,0xc0,0xc3};

        public static ReadOnlySpan<byte> unsignedヽgᐸ32fᐳᐤᐤ  =>  new byte[8]{0x0f,0x1f,0x44,0x00,0x00,0x33,0xc0,0xc3};

        public static ReadOnlySpan<byte> unsignedヽgᐸ64fᐳᐤᐤ  =>  new byte[8]{0x0f,0x1f,0x44,0x00,0x00,0x33,0xc0,0xc3};

    }
}
