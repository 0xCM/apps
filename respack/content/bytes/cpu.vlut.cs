﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2021-11-14 3:49:55 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class cpu_vlut
    {
        public static ReadOnlySpan<byte> initヽᐤVector128ᐸbyteᐳᐤ  =>  new byte[17]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> initヽᐤrspan8uㆍn16ᐤ  =>  new byte[20]{0xc5,0xf8,0x77,0x66,0x90,0x48,0x8b,0x02,0xc5,0xfb,0xf0,0x00,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> initヽᐤb128x8uᕀinᐤ  =>  new byte[20]{0xc5,0xf8,0x77,0x66,0x90,0x48,0x8b,0x02,0xc5,0xfb,0xf0,0x00,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> initヽᐤVector256ᐸbyteᐳᐤ  =>  new byte[20]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfd,0x10,0x02,0xc5,0xfd,0x11,0x01,0x48,0x8b,0xc1,0xc5,0xf8,0x77,0xc3};

        public static ReadOnlySpan<byte> initヽᐤrspan8uㆍn32ᐤ  =>  new byte[23]{0xc5,0xf8,0x77,0x66,0x90,0x48,0x8b,0x02,0xc5,0xff,0xf0,0x00,0xc5,0xfd,0x11,0x01,0x48,0x8b,0xc1,0xc5,0xf8,0x77,0xc3};

        public static ReadOnlySpan<byte> initヽᐤb256x8uᕀinᐤ  =>  new byte[23]{0xc5,0xf8,0x77,0x66,0x90,0x48,0x8b,0x02,0xc5,0xff,0xf0,0x00,0xc5,0xfd,0x11,0x01,0x48,0x8b,0xc1,0xc5,0xf8,0x77,0xc3};

        public static ReadOnlySpan<byte> selectヽᐤVLut16ᕀinㆍVector128ᐸbyteᐳᐤ  =>  new byte[27]{0xc5,0xf8,0x77,0x66,0x90,0xc4,0xc1,0x79,0x10,0x00,0xc5,0xf9,0x10,0x0a,0xc4,0xe2,0x79,0x00,0xc1,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> selectヽᐤVLut32ᕀinㆍVector256ᐸbyteᐳᐤ  =>  new byte[81]{0xc5,0xf8,0x77,0x66,0x90,0xc4,0xc1,0x7d,0x10,0x00,0xc5,0xfd,0x10,0x0a,0x48,0xb8,0xec,0x42,0x76,0x7f,0xd5,0x01,0x00,0x00,0xc5,0xff,0xf0,0x10,0xc5,0xf5,0xfc,0xd2,0xc4,0xe2,0x7d,0x00,0xd2,0xc4,0xe3,0x7d,0x46,0xc0,0x03,0x48,0xb8,0x4c,0x3e,0x76,0x7f,0xd5,0x01,0x00,0x00,0xc5,0xff,0xf0,0x18,0xc5,0xf5,0xfc,0xcb,0xc4,0xe2,0x7d,0x00,0xc1,0xc5,0xed,0xeb,0xc0,0xc5,0xfd,0x11,0x01,0x48,0x8b,0xc1,0xc5,0xf8,0x77,0xc3};

    }
}
