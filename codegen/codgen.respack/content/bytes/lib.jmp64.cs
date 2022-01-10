﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2022-01-07 15:36:31 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class lib_jmp64
    {
        public static ReadOnlySpan<byte> rexヽᐤrspan8uᐤ  =>  new byte[18]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x01,0x80,0x38,0x48,0x0f,0x94,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> testヽᐤrspan8uᐤ  =>  new byte[243]{0x48,0x83,0xec,0x38,0x33,0xc0,0x48,0x89,0x44,0x24,0x30,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x18,0x48,0x8b,0x01,0x8b,0x51,0x08,0x83,0xfa,0x03,0x0f,0x94,0xc1,0x0f,0xb6,0xc9,0x88,0x4c,0x24,0x30,0x80,0x7c,0x24,0x30,0x00,0x74,0x2a,0x80,0x38,0x48,0x0f,0x94,0xc1,0x0f,0xb6,0xc9,0x88,0x0c,0x24,0x8b,0x4c,0x24,0x30,0x0f,0xb6,0xc9,0x44,0x8b,0x04,0x24,0x45,0x0f,0xb6,0xc0,0x41,0x23,0xc8,0x0f,0xb6,0xc9,0x0f,0xb6,0xc9,0x88,0x4c,0x24,0x28,0xeb,0x09,0x0f,0xb6,0x4c,0x24,0x30,0x88,0x4c,0x24,0x28,0x0f,0xb6,0x4c,0x24,0x28,0x80,0x7c,0x24,0x28,0x00,0x74,0x2c,0x80,0x78,0x01,0xff,0x41,0x0f,0x94,0xc0,0x45,0x0f,0xb6,0xc0,0x44,0x88,0x44,0x24,0x08,0x0f,0xb6,0xc9,0x44,0x8b,0x44,0x24,0x08,0x45,0x0f,0xb6,0xc0,0x41,0x23,0xc8,0x0f,0xb6,0xc9,0x0f,0xb6,0xc9,0x88,0x4c,0x24,0x20,0xeb,0x04,0x88,0x4c,0x24,0x20,0x0f,0xb6,0x4c,0x24,0x20,0x80,0x7c,0x24,0x20,0x00,0x75,0x34,0x83,0xfa,0x02,0x75,0x0b,0x80,0x38,0xff,0x0f,0x94,0xc0,0x0f,0xb6,0xc0,0xeb,0x02,0x33,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0x88,0x44,0x24,0x10,0x0f,0xb6,0xc1,0x8b,0x54,0x24,0x10,0x0f,0xb6,0xd2,0x0b,0xc2,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0x88,0x44,0x24,0x18,0xeb,0x04,0x88,0x4c,0x24,0x18,0x8b,0x44,0x24,0x18,0x0f,0xb6,0xc0,0x48,0x83,0xc4,0x38,0xc3};

        public static ReadOnlySpan<byte> targetヽᐤrspan8uᐤ  =>  new byte[53]{0x50,0x0f,0x1f,0x40,0x00,0x48,0x8b,0x01,0x80,0x38,0x48,0x0f,0x94,0xc2,0x0f,0xb6,0xd2,0x88,0x14,0x24,0x80,0x3c,0x24,0x00,0x75,0x09,0x0f,0xb6,0x50,0x01,0x83,0xe2,0x0f,0xeb,0x07,0x0f,0xb6,0x50,0x02,0x83,0xe2,0x0f,0x0f,0xb6,0xc2,0x0f,0xb6,0xc0,0x48,0x83,0xc4,0x08,0xc3};

    }
}