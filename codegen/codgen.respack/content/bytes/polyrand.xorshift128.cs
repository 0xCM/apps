﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2022-01-07 15:36:32 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class polyrand_xorshift128
    {
        public static ReadOnlySpan<byte> nextヽᐤXorShift128ᕀrefᐤ  =>  new byte[60]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0x01,0x8b,0xd0,0xc1,0xe2,0x0f,0x33,0xd0,0x8b,0x41,0x04,0x89,0x01,0x8b,0x41,0x08,0x89,0x41,0x04,0x8b,0x41,0x0c,0x89,0x41,0x08,0x8b,0x41,0x0c,0x44,0x8b,0xc0,0x41,0xc1,0xe8,0x15,0x44,0x33,0xc0,0x44,0x33,0xc2,0xc1,0xea,0x04,0x41,0x33,0xd0,0x89,0x51,0x0c,0x8b,0x41,0x0c,0xc3};

        public static ReadOnlySpan<byte> grindヽᐤ32uㆍ32uᐤ  =>  new byte[20]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0xc1,0xc1,0xe8,0x15,0x33,0xc1,0x33,0xc2,0xc1,0xea,0x04,0x33,0xc2,0xc3};

        public static ReadOnlySpan<byte> xorslヽᐤ32uㆍ8uᐤ  =>  new byte[17]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0xc1,0x0f,0xb6,0xca,0x8b,0xd0,0xd3,0xe2,0x33,0xc2,0xc3};

        public static ReadOnlySpan<byte> xorsrヽᐤ32uㆍ8uᐤ  =>  new byte[17]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0xc1,0x0f,0xb6,0xca,0x8b,0xd0,0xd3,0xea,0x33,0xc2,0xc3};

    }
}
