﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2021-12-01 21:34:43 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class lib_systemcounter
    {
        public static ReadOnlySpan<byte> Startヽᐤᐤ  =>  new byte[24]{0x48,0x83,0xec,0x28,0x90,0xc6,0x41,0x10,0x01,0x48,0x83,0xc1,0x08,0xe8,0xbe,0xc3,0x59,0xfe,0x90,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> Stopヽᐤᐤ  =>  new byte[57]{0x56,0x48,0x83,0xec,0x30,0x33,0xc0,0x48,0x89,0x44,0x24,0x28,0x48,0x8b,0xf1,0xc6,0x46,0x10,0x00,0x33,0xc9,0x48,0x89,0x4c,0x24,0x28,0x48,0x8d,0x4c,0x24,0x28,0xe8,0x7c,0xc3,0x59,0xfe,0x48,0x8b,0x44,0x24,0x28,0x48,0x2b,0x46,0x08,0x48,0x01,0x06,0x48,0x8b,0x06,0x48,0x83,0xc4,0x30,0x5e,0xc3};

        public static ReadOnlySpan<byte> Measureヽᐤᐤ  =>  new byte[53]{0x56,0x48,0x83,0xec,0x30,0x33,0xc0,0x48,0x89,0x44,0x24,0x28,0x48,0x8b,0xf1,0x33,0xc9,0x48,0x89,0x4c,0x24,0x28,0x48,0x8d,0x4c,0x24,0x28,0xe8,0x30,0xc3,0x59,0xfe,0x48,0x8b,0x06,0x48,0x8b,0x54,0x24,0x28,0x48,0x2b,0x56,0x08,0x48,0x03,0xc2,0x48,0x83,0xc4,0x30,0x5e,0xc3};

        public static ReadOnlySpan<byte> Elapsedヽᐤᐤ  =>  new byte[62]{0x56,0x48,0x83,0xec,0x30,0x48,0x8b,0xf1,0x80,0x7e,0x10,0x00,0x75,0x05,0x48,0x8b,0x06,0xeb,0x25,0x33,0xc9,0x48,0x89,0x4c,0x24,0x28,0x48,0x89,0x4c,0x24,0x28,0x48,0x8d,0x4c,0x24,0x28,0xe8,0xd7,0xc2,0x59,0xfe,0x48,0x8b,0x06,0x48,0x8b,0x54,0x24,0x28,0x48,0x2b,0x56,0x08,0x48,0x03,0xc2,0x48,0x83,0xc4,0x30,0x5e,0xc3};

        public static ReadOnlySpan<byte> Resetヽᐤᐤ  =>  new byte[15]{0x0f,0x1f,0x44,0x00,0x00,0x33,0xc0,0x48,0x89,0x01,0x48,0x89,0x41,0x08,0xc3};

        public static ReadOnlySpan<byte> Restartヽᐤᐤ  =>  new byte[33]{0x48,0x83,0xec,0x28,0x90,0x33,0xc0,0x48,0x89,0x01,0x48,0x89,0x41,0x08,0xc6,0x41,0x10,0x01,0x48,0x83,0xc1,0x08,0xe8,0x65,0xc2,0x59,0xfe,0x90,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> Spanヽᐤᐤ  =>  new byte[9]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x01,0xc3};

    }
}
