﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2021-11-14 3:49:54 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class core_spanwriter
    {
        public static ReadOnlySpan<byte> get_Targetヽᐤᐤ  =>  new byte[28]{0x57,0x56,0x53,0x66,0x90,0x48,0x8b,0xda,0x48,0x8b,0xfb,0x48,0x8b,0xf1,0xe8,0xdd,0xd8,0x69,0x5c,0x48,0xa5,0x48,0x8b,0xc3,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> get_BytesWrittenヽᐤᐤ  =>  new byte[9]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0x41,0x10,0xc3};

        public static ReadOnlySpan<byte> Write8ヽᐤ8uᐤ  =>  new byte[32]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x01,0x44,0x8b,0x41,0x10,0x45,0x8d,0x48,0x01,0x44,0x89,0x49,0x10,0x49,0x63,0xc8,0x88,0x14,0x08,0xb8,0x01,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> Write16ヽᐤ16uᐤ  =>  new byte[35]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x01,0x44,0x8b,0x41,0x10,0x41,0x83,0xc0,0x02,0x44,0x89,0x41,0x10,0x49,0x63,0xc8,0x48,0x03,0xc1,0x66,0x89,0x10,0xb8,0x02,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> Write16ヽᐤ8uㆍ8uᐤ  =>  new byte[54]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x01,0x44,0x8b,0x49,0x10,0x45,0x8d,0x51,0x01,0x44,0x89,0x51,0x10,0x4d,0x63,0xc9,0x42,0x88,0x14,0x08,0x48,0x8b,0x01,0x44,0x8b,0x49,0x10,0x41,0x8d,0x51,0x01,0x89,0x51,0x10,0x49,0x63,0xd1,0x44,0x88,0x04,0x10,0xb8,0x02,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> Write32ヽᐤ32uᐤ  =>  new byte[34]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x01,0x44,0x8b,0x41,0x10,0x41,0x83,0xc0,0x04,0x44,0x89,0x41,0x10,0x49,0x63,0xc8,0x48,0x03,0xc1,0x89,0x10,0xb8,0x04,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> Write64ヽᐤ64uᐤ  =>  new byte[35]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x01,0x44,0x8b,0x41,0x10,0x41,0x83,0xc0,0x08,0x44,0x89,0x41,0x10,0x49,0x63,0xc8,0x48,0x03,0xc1,0x48,0x89,0x10,0xb8,0x08,0x00,0x00,0x00,0xc3};

    }
}