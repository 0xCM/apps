﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2021-12-01 21:34:44 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class lib_jmprel32
    {
        public static ReadOnlySpan<byte> testヽᐤrspan8uᐤ  =>  new byte[18]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x01,0x80,0x38,0xe9,0x0f,0x94,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> dxヽᐤrspan8uᐤ  =>  new byte[14]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x01,0x48,0xff,0xc0,0x8b,0x00,0xc3};

        public static ReadOnlySpan<byte> disp32ヽᐤMemoryAddressㆍMemoryAddressᐤ  =>  new byte[16]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x83,0xc1,0x05,0x48,0x2b,0xca,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> targetヽᐤMemoryAddressㆍrspan8uᐤ  =>  new byte[21]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x83,0xc1,0x05,0x48,0x8b,0x02,0x48,0xff,0xc0,0x8b,0x00,0x48,0x03,0xc1,0xc3};

        public static ReadOnlySpan<byte> offsetヽᐤMemoryAddressㆍMemoryAddressㆍrspan8uᐤ  =>  new byte[24]{0x0f,0x1f,0x44,0x00,0x00,0x49,0x8b,0x00,0x48,0x83,0xc2,0x05,0x48,0xff,0xc0,0x8b,0x00,0x48,0x03,0xc2,0x48,0x2b,0xc1,0xc3};

    }
}
