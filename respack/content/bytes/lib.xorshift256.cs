﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2021-11-14 3:49:57 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class lib_xorshift256
    {
        public static ReadOnlySpan<byte> createヽᐤrspan64uᐤ  =>  new byte[369]{0x41,0x56,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x40,0x48,0x8b,0xf1,0x33,0xc9,0x48,0x89,0x4c,0x24,0x20,0x48,0x89,0x4c,0x24,0x28,0x48,0x89,0x4c,0x24,0x30,0x48,0x89,0x4c,0x24,0x38,0x48,0x8b,0x0a,0x48,0x8b,0x11,0x48,0x89,0x54,0x24,0x20,0x48,0x8b,0x51,0x08,0x48,0x89,0x54,0x24,0x28,0x48,0x8b,0x51,0x10,0x48,0x89,0x54,0x24,0x30,0x48,0x8b,0x49,0x18,0x48,0x89,0x4c,0x24,0x38,0x48,0xb9,0xa0,0xd4,0xcb,0x7f,0xfe,0x7f,0x00,0x00,0xba,0xf5,0x09,0x00,0x00,0xe8,0x03,0xf9,0x8b,0x5b,0x48,0xb9,0x98,0x56,0xb6,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x09,0x48,0x85,0xc9,0x75,0x06,0x33,0xc0,0x33,0xd2,0xeb,0x07,0x48,0x8d,0x41,0x10,0x8b,0x51,0x08,0x45,0x33,0xc0,0x45,0x33,0xc9,0x45,0x33,0xd2,0x45,0x33,0xdb,0x33,0xff,0x85,0xd2,0x0f,0x8e,0x9a,0x00,0x00,0x00,0x33,0xdb,0x48,0x63,0xef,0x41,0xbe,0x01,0x00,0x00,0x00,0x8b,0xcb,0x49,0xd3,0xe6,0x4c,0x23,0x34,0xe8,0x4d,0x85,0xf6,0x74,0x14,0x4c,0x33,0x44,0x24,0x20,0x4c,0x33,0x4c,0x24,0x28,0x4c,0x33,0x54,0x24,0x30,0x4c,0x33,0x5c,0x24,0x38,0x48,0x8b,0x4c,0x24,0x28,0x48,0xc1,0xe1,0x11,0x48,0x8d,0x6c,0x24,0x30,0x4c,0x8b,0x74,0x24,0x20,0x4c,0x31,0x75,0x00,0x48,0x8d,0x6c,0x24,0x38,0x4c,0x8b,0x74,0x24,0x28,0x4c,0x31,0x75,0x00,0x48,0x8d,0x6c,0x24,0x28,0x4c,0x8b,0x74,0x24,0x30,0x4c,0x31,0x75,0x00,0x48,0x8d,0x6c,0x24,0x20,0x4c,0x8b,0x74,0x24,0x38,0x4c,0x31,0x75,0x00,0x48,0x8d,0x6c,0x24,0x30,0x48,0x31,0x4d,0x00,0x48,0x8b,0x4c,0x24,0x38,0x48,0xc1,0xc1,0x2d,0x48,0x89,0x4c,0x24,0x38,0xff,0xc3,0x83,0xfb,0x40,0x0f,0x8c,0x72,0xff,0xff,0xff,0xff,0xc7,0x3b,0xfa,0x0f,0x8c,0x66,0xff,0xff,0xff,0x4c,0x89,0x44,0x24,0x20,0x4c,0x89,0x4c,0x24,0x28,0x4c,0x89,0x54,0x24,0x30,0x4c,0x89,0x5c,0x24,0x38,0x48,0x8b,0x44,0x24,0x20,0x48,0x89,0x06,0x48,0x8b,0x44,0x24,0x28,0x48,0x89,0x46,0x08,0x48,0x8b,0x44,0x24,0x30,0x48,0x89,0x46,0x10,0x48,0x8b,0x44,0x24,0x38,0x48,0x89,0x46,0x18,0x48,0x8b,0xc6,0x48,0x83,0xc4,0x40,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0xc3};

        public static ReadOnlySpan<byte> nextヽᐤXorShift256ᕀrefᐤ  =>  new byte[86]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x41,0x08,0x48,0x8d,0x14,0x80,0x48,0xc1,0xc2,0x07,0x48,0x8d,0x14,0xd2,0x48,0xc1,0xe0,0x11,0x4c,0x8d,0x41,0x10,0x4d,0x8b,0xc8,0x4c,0x8b,0x11,0x4d,0x31,0x11,0x4c,0x8d,0x49,0x18,0x4c,0x8b,0x51,0x08,0x4d,0x31,0x11,0x4c,0x8d,0x49,0x08,0x4c,0x8b,0x51,0x10,0x4d,0x31,0x11,0x4c,0x8b,0x49,0x18,0x4c,0x31,0x09,0x49,0x31,0x00,0x48,0x8b,0x41,0x18,0x48,0xc1,0xc0,0x2d,0x48,0x89,0x41,0x18,0x48,0x8b,0xc2,0xc3};

        public static ReadOnlySpan<byte> nextヽᐤXorShift256ᕀrefㆍ64uᐤ  =>  new byte[101]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x89,0x54,0x24,0x10,0x48,0x8b,0x41,0x08,0x4c,0x8d,0x04,0x80,0x49,0xc1,0xc0,0x07,0x4f,0x8d,0x04,0xc0,0x48,0xc1,0xe0,0x11,0x4c,0x8d,0x49,0x10,0x4d,0x8b,0xd1,0x4c,0x8b,0x19,0x4d,0x31,0x1a,0x4c,0x8d,0x51,0x18,0x4c,0x8b,0x59,0x08,0x4d,0x31,0x1a,0x4c,0x8d,0x51,0x08,0x4c,0x8b,0x59,0x10,0x4d,0x31,0x1a,0x4c,0x8b,0x51,0x18,0x4c,0x31,0x11,0x49,0x31,0x01,0x48,0x8b,0x41,0x18,0x48,0xc1,0xc0,0x2d,0x48,0x89,0x41,0x18,0x48,0x8b,0x44,0x24,0x10,0x49,0x8b,0xd0,0xc4,0xe2,0xfb,0xf6,0xc0,0xc3};

        public static ReadOnlySpan<byte> nextヽᐤXorShift256ᕀrefㆍ64uㆍ64uᐤ  =>  new byte[105]{0x56,0x0f,0x1f,0x40,0x00,0x48,0x8b,0x41,0x08,0x4c,0x8d,0x0c,0x80,0x49,0xc1,0xc1,0x07,0x4f,0x8d,0x0c,0xc9,0x48,0xc1,0xe0,0x11,0x4c,0x8d,0x51,0x10,0x4d,0x8b,0xda,0x48,0x8b,0x31,0x49,0x31,0x33,0x4c,0x8d,0x59,0x18,0x48,0x8b,0x71,0x08,0x49,0x31,0x33,0x4c,0x8d,0x59,0x08,0x48,0x8b,0x71,0x10,0x49,0x31,0x33,0x4c,0x8b,0x59,0x18,0x4c,0x31,0x19,0x49,0x31,0x02,0x48,0x8b,0x41,0x18,0x48,0xc1,0xc0,0x2d,0x48,0x89,0x41,0x18,0x48,0x89,0x54,0x24,0x18,0x4c,0x2b,0xc2,0x49,0x8b,0xd1,0xc4,0xc2,0xfb,0xf6,0xc0,0x48,0x03,0x44,0x24,0x18,0x5e,0xc3};

        public static ReadOnlySpan<byte> jumpヽᐤXorShift256ᕀrefㆍrspan64uᐤ  =>  new byte[228]{0x41,0x57,0x41,0x56,0x41,0x55,0x41,0x54,0x57,0x56,0x55,0x53,0x50,0x48,0x8b,0xc1,0x44,0x8b,0x42,0x08,0x45,0x33,0xc9,0x45,0x33,0xd2,0x45,0x33,0xdb,0x33,0xf6,0x33,0xff,0x44,0x89,0x44,0x24,0x04,0x45,0x85,0xc0,0x0f,0x8e,0x95,0x00,0x00,0x00,0x33,0xdb,0x48,0x63,0xef,0x4c,0x8d,0x70,0x10,0x4c,0x8d,0x78,0x18,0x4c,0x8d,0x60,0x08,0x4c,0x8b,0x2a,0x41,0xb8,0x01,0x00,0x00,0x00,0x8b,0xcb,0x49,0xd3,0xe0,0x4d,0x23,0x44,0xed,0x00,0x4d,0x85,0xc0,0x74,0x12,0x4c,0x33,0x08,0x48,0x8b,0x48,0x08,0x4c,0x33,0xd1,0x4c,0x33,0x58,0x10,0x48,0x33,0x70,0x18,0x48,0x8b,0x48,0x08,0x48,0xc1,0xe1,0x11,0x4d,0x8b,0xc6,0x4c,0x8b,0x28,0x4d,0x31,0x28,0x4d,0x8b,0xc7,0x4c,0x8b,0x68,0x08,0x4d,0x31,0x28,0x4d,0x8b,0xc4,0x4c,0x8b,0x68,0x10,0x4d,0x31,0x28,0x4c,0x8b,0x40,0x18,0x4c,0x31,0x00,0x4d,0x8b,0xc6,0x49,0x31,0x08,0x48,0x8b,0x48,0x18,0x48,0xc1,0xc1,0x2d,0x48,0x89,0x48,0x18,0xff,0xc3,0x83,0xfb,0x40,0x7c,0x91,0xff,0xc7,0x44,0x8b,0x44,0x24,0x04,0x41,0x3b,0xf8,0x44,0x89,0x44,0x24,0x04,0x0f,0x8c,0x6b,0xff,0xff,0xff,0x4c,0x89,0x08,0x4c,0x89,0x50,0x08,0x4c,0x89,0x58,0x10,0x48,0x89,0x70,0x18,0x48,0x83,0xc4,0x08,0x5b,0x5d,0x5e,0x5f,0x41,0x5c,0x41,0x5d,0x41,0x5e,0x41,0x5f,0xc3};

    }
}
