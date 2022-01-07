﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2022-01-07 15:36:31 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class lib_timerticks
    {
        public static ReadOnlySpan<byte> defaultヽᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x80,0x96,0x98,0x00,0xc3};

        public static ReadOnlySpan<byte> nsPerTickヽᐤTimerTicksᐤ  =>  new byte[16]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x00,0xca,0x9a,0x3b,0x33,0xd2,0x48,0xf7,0xf1,0xc3};

        public static ReadOnlySpan<byte> ticksPerMsヽᐤTimerTicksᐤ  =>  new byte[36]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf8,0x57,0xc0,0xc4,0xe1,0xfb,0x2a,0xc1,0x48,0x85,0xc9,0x7d,0x08,0xc5,0xfb,0x58,0x05,0x0d,0x00,0x00,0x00,0xc5,0xfb,0x5e,0x05,0x0d,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> msヽᐤ64iᐤ  =>  new byte[23]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf8,0x57,0xc0,0xc4,0xe1,0xfb,0x2a,0xc1,0xc5,0xfb,0x5e,0x05,0x0a,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> nsヽᐤ64iᐤ  =>  new byte[10]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x6b,0xc1,0x64,0xc3};

    }
}
