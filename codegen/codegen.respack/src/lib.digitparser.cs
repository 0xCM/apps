﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2022-01-14 21:56:33 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class lib_digitparser
    {
        public static ReadOnlySpan<byte> digitsヽᐤBase10ㆍrspancharㆍ32uㆍspanDecimalDigitValueᕀ8uᐤ  =>  new byte[255]{0x56,0x48,0x83,0xec,0x20,0x33,0xc0,0x48,0x89,0x44,0x24,0x18,0x48,0x89,0x44,0x24,0x10,0x33,0xc0,0x8b,0x4a,0x08,0xff,0xc9,0x45,0x8b,0xd0,0x48,0x63,0xc9,0x4c,0x3b,0xd1,0x0f,0x8f,0xd2,0x00,0x00,0x00,0x45,0x8d,0x50,0x01,0x4c,0x8b,0x1a,0x4d,0x63,0xc0,0x4f,0x8d,0x04,0x43,0x45,0x0f,0xb7,0x18,0x41,0x83,0xfb,0x20,0x41,0x0f,0x94,0xc3,0x45,0x0f,0xb6,0xdb,0x45,0x0f,0xb6,0xdb,0x44,0x88,0x5c,0x24,0x18,0x80,0x7c,0x24,0x18,0x00,0x74,0x34,0x85,0xc0,0x41,0x0f,0x94,0xc3,0x45,0x0f,0xb6,0xdb,0x45,0x0f,0xb6,0xdb,0x44,0x88,0x1c,0x24,0x44,0x8b,0x5c,0x24,0x18,0x45,0x0f,0xb6,0xdb,0x8b,0x34,0x24,0x40,0x0f,0xb6,0xf6,0x44,0x23,0xde,0x45,0x0f,0xb6,0xdb,0x45,0x0f,0xb6,0xdb,0x44,0x88,0x5c,0x24,0x10,0xeb,0x0b,0x44,0x0f,0xb6,0x5c,0x24,0x18,0x44,0x88,0x5c,0x24,0x10,0x80,0x7c,0x24,0x10,0x00,0x75,0x4f,0x45,0x0f,0xb7,0x18,0x45,0x0f,0xb6,0xdb,0x41,0x83,0xfb,0x30,0x7c,0x0e,0x41,0x83,0xfb,0x39,0x41,0x0f,0x9e,0xc3,0x45,0x0f,0xb6,0xdb,0xeb,0x03,0x45,0x33,0xdb,0x45,0x0f,0xb6,0xdb,0x45,0x0f,0xb6,0xdb,0x44,0x88,0x5c,0x24,0x08,0x80,0x7c,0x24,0x08,0x00,0x74,0x2b,0x44,0x8d,0x58,0x01,0x49,0x8b,0x31,0x45,0x0f,0xb6,0x00,0x41,0xf7,0xd8,0x41,0x83,0xc0,0x39,0x48,0x63,0xc0,0x44,0x88,0x04,0x06,0x41,0x8b,0xc3,0x45,0x8b,0xc2,0x4c,0x3b,0xc1,0x45,0x8b,0xc2,0x0f,0x8e,0x2e,0xff,0xff,0xff,0x48,0x83,0xc4,0x20,0x5e,0xc3};

        public static ReadOnlySpan<byte> parse32uヽᐤrspancharㆍ32uᕀoutᐤ  =>  new byte[276]{0x50,0x33,0xc0,0x48,0x89,0x04,0x24,0x33,0xc0,0x48,0x89,0x04,0x24,0x48,0x8d,0x04,0x24,0x45,0x33,0xc0,0x44,0x89,0x02,0x44,0x8b,0x41,0x08,0x41,0x83,0xf8,0x08,0x7c,0x08,0x41,0xb9,0x08,0x00,0x00,0x00,0xeb,0x03,0x45,0x8b,0xc8,0x45,0x33,0xc0,0x41,0xff,0xc9,0x45,0x85,0xc9,0x7c,0x30,0x4c,0x8b,0x11,0x4d,0x63,0xd9,0x47,0x0f,0xb7,0x14,0x5a,0x45,0x0f,0xb6,0xd2,0x41,0x83,0xfa,0x30,0x7c,0x20,0x41,0x83,0xfa,0x39,0x41,0x0f,0x9e,0xc3,0x45,0x0f,0xb6,0xdb,0x45,0x85,0xdb,0x74,0x0f,0x41,0x83,0xc2,0xd0,0x45,0x0f,0xb6,0xda,0xeb,0x55,0x45,0x8b,0xd0,0xeb,0x65,0x41,0x83,0xfa,0x41,0x7c,0x23,0x41,0x83,0xfa,0x46,0x41,0x0f,0x9e,0xc3,0x45,0x0f,0xb6,0xdb,0x45,0x85,0xdb,0x74,0x12,0x41,0x83,0xc2,0xbf,0x45,0x0f,0xb6,0xd2,0x41,0x83,0xc2,0x0a,0x45,0x0f,0xb6,0xda,0xeb,0x27,0x41,0x83,0xfa,0x61,0x7c,0x72,0x41,0x83,0xfa,0x66,0x41,0x0f,0x9e,0xc3,0x45,0x0f,0xb6,0xdb,0x45,0x85,0xdb,0x74,0x61,0x41,0x83,0xc2,0x9f,0x45,0x0f,0xb6,0xd2,0x41,0x83,0xc2,0x0a,0x45,0x0f,0xb6,0xda,0x45,0x8d,0x50,0x01,0x4d,0x63,0xc0,0x4c,0x03,0xc0,0x45,0x88,0x18,0x41,0xff,0xc9,0x45,0x85,0xc9,0x7d,0x34,0x45,0x33,0xc0,0x45,0x85,0xd2,0x7e,0x22,0x44,0x8b,0x0a,0x49,0x63,0xc8,0x44,0x0f,0xb6,0x1c,0x08,0x41,0x8b,0xc8,0xc1,0xe1,0x02,0x41,0xd3,0xe3,0x45,0x0b,0xcb,0x44,0x89,0x0a,0x41,0xff,0xc0,0x45,0x3b,0xc2,0x7c,0xde,0xb8,0x01,0x00,0x00,0x00,0x48,0x83,0xc4,0x08,0xc3,0x45,0x8b,0xc2,0xe9,0x2a,0xff,0xff,0xff,0x33,0xc0,0x48,0x83,0xc4,0x08,0xc3};

    }
}