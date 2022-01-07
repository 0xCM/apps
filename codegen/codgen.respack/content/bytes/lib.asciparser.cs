﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2022-01-07 15:36:30 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class lib_asciparser
    {
        public static ReadOnlySpan<byte> parseヽᐤstringㆍasci64ᕀoutᐤ  =>  new byte[580]{0x56,0x48,0x81,0xec,0x40,0x01,0x00,0x00,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x8b,0xf1,0x48,0x85,0xd2,0x75,0x06,0x33,0xc9,0x33,0xc0,0xeb,0x07,0x48,0x8d,0x4a,0x0c,0x8b,0x42,0x08,0x48,0x8d,0x94,0x24,0x80,0x00,0x00,0x00,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x02,0xc5,0xfa,0x7f,0x42,0x10,0xc5,0xfa,0x7f,0x42,0x20,0xc5,0xfa,0x7f,0x42,0x30,0xc7,0x44,0x24,0x3c,0x20,0x00,0x00,0x00,0x48,0x8d,0x54,0x24,0x3c,0xc4,0xe2,0x7d,0x78,0x44,0x24,0x3c,0x48,0x8d,0x54,0x24,0x3c,0xc4,0xe2,0x7d,0x78,0x4c,0x24,0x3c,0x48,0x8d,0x54,0x24,0x40,0xc5,0xe8,0x57,0xd2,0xc5,0xfa,0x7f,0x12,0xc5,0xfa,0x7f,0x52,0x10,0xc5,0xfa,0x7f,0x52,0x20,0xc5,0xfa,0x7f,0x52,0x30,0x48,0x8d,0x54,0x24,0x40,0xc5,0xfd,0x11,0x02,0xc5,0xfd,0x11,0x4a,0x20,0xc5,0xfa,0x6f,0x44,0x24,0x40,0xc5,0xfa,0x7f,0x84,0x24,0x80,0x00,0x00,0x00,0xc5,0xfa,0x6f,0x44,0x24,0x50,0xc5,0xfa,0x7f,0x84,0x24,0x90,0x00,0x00,0x00,0xc5,0xfa,0x6f,0x44,0x24,0x60,0xc5,0xfa,0x7f,0x84,0x24,0xa0,0x00,0x00,0x00,0xc5,0xfa,0x6f,0x44,0x24,0x70,0xc5,0xfa,0x7f,0x84,0x24,0xb0,0x00,0x00,0x00,0x48,0x8d,0x94,0x24,0x80,0x00,0x00,0x00,0x41,0xb9,0x40,0x00,0x00,0x00,0x41,0x3b,0xc1,0x7c,0x02,0xeb,0x03,0x44,0x8b,0xc8,0x33,0xc0,0x4d,0x63,0xd1,0x4d,0x85,0xd2,0x7e,0x1e,0x4c,0x63,0xd0,0x4c,0x03,0xd2,0x4c,0x63,0xd8,0x46,0x0f,0xb6,0x1c,0x59,0x45,0x88,0x1a,0xff,0xc0,0x44,0x8b,0xd0,0x4d,0x63,0xd9,0x4d,0x3b,0xd3,0x7c,0xe2,0xc5,0xfa,0x6f,0x84,0x24,0x80,0x00,0x00,0x00,0xc5,0xfa,0x7f,0x84,0x24,0xc0,0x00,0x00,0x00,0xc5,0xfa,0x6f,0x84,0x24,0x90,0x00,0x00,0x00,0xc5,0xfa,0x7f,0x84,0x24,0xd0,0x00,0x00,0x00,0xc5,0xfa,0x6f,0x84,0x24,0xa0,0x00,0x00,0x00,0xc5,0xfa,0x7f,0x84,0x24,0xe0,0x00,0x00,0x00,0xc5,0xfa,0x6f,0x84,0x24,0xb0,0x00,0x00,0x00,0xc5,0xfa,0x7f,0x84,0x24,0xf0,0x00,0x00,0x00,0xc5,0xfa,0x6f,0x84,0x24,0xc0,0x00,0x00,0x00,0xc5,0xfa,0x7f,0x84,0x24,0x00,0x01,0x00,0x00,0xc5,0xfa,0x6f,0x84,0x24,0xd0,0x00,0x00,0x00,0xc5,0xfa,0x7f,0x84,0x24,0x10,0x01,0x00,0x00,0xc5,0xfa,0x6f,0x84,0x24,0xe0,0x00,0x00,0x00,0xc5,0xfa,0x7f,0x84,0x24,0x20,0x01,0x00,0x00,0xc5,0xfa,0x6f,0x84,0x24,0xf0,0x00,0x00,0x00,0xc5,0xfa,0x7f,0x84,0x24,0x30,0x01,0x00,0x00,0xc5,0xfa,0x6f,0x84,0x24,0x00,0x01,0x00,0x00,0xc4,0xc1,0x7a,0x7f,0x00,0xc5,0xfa,0x6f,0x84,0x24,0x10,0x01,0x00,0x00,0xc4,0xc1,0x7a,0x7f,0x40,0x10,0xc5,0xfa,0x6f,0x84,0x24,0x20,0x01,0x00,0x00,0xc4,0xc1,0x7a,0x7f,0x40,0x20,0xc5,0xfa,0x6f,0x84,0x24,0x30,0x01,0x00,0x00,0xc4,0xc1,0x7a,0x7f,0x40,0x30,0x33,0xd2,0x48,0x8d,0x4c,0x24,0x20,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x01,0x48,0x89,0x51,0x10,0xc6,0x44,0x24,0x30,0x01,0x48,0x8d,0x4c,0x24,0x20,0x48,0xba,0x60,0x30,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0xe8,0x6a,0xe0,0x86,0x5c,0x8b,0x54,0x24,0x30,0x0f,0xb6,0xd2,0x48,0x89,0x54,0x24,0x28,0x48,0x8b,0x54,0x24,0x20,0x48,0x8b,0xce,0xe8,0x51,0xe0,0x86,0x5c,0x48,0x8b,0x44,0x24,0x28,0x48,0x89,0x46,0x08,0x0f,0xb6,0x44,0x24,0x30,0x88,0x46,0x10,0x48,0x8b,0xc6,0xc5,0xf8,0x77,0x48,0x81,0xc4,0x40,0x01,0x00,0x00,0x5e,0xc3,0xe8,0xcc,0x71,0x99,0x5c};

        public static ReadOnlySpan<byte> parseヽᐤstringㆍasci16ᕀoutᐤ  =>  new byte[247]{0x56,0x48,0x83,0xec,0x50,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x8b,0xf1,0x48,0x85,0xd2,0x75,0x06,0x33,0xc9,0x33,0xc0,0xeb,0x07,0x48,0x8d,0x4a,0x0c,0x8b,0x42,0x08,0xc5,0xf8,0x57,0xc0,0xc5,0xf9,0x29,0x44,0x24,0x40,0xc7,0x44,0x24,0x3c,0x20,0x00,0x00,0x00,0x48,0x8d,0x54,0x24,0x3c,0xc4,0xe2,0x79,0x78,0x44,0x24,0x3c,0xc5,0xf9,0x29,0x44,0x24,0x40,0x48,0x8d,0x54,0x24,0x40,0x41,0xb9,0x10,0x00,0x00,0x00,0x41,0x3b,0xc1,0x7c,0x02,0xeb,0x03,0x44,0x8b,0xc8,0x33,0xc0,0x4d,0x63,0xd1,0x4d,0x85,0xd2,0x7e,0x1e,0x4c,0x63,0xd0,0x4c,0x03,0xd2,0x4c,0x63,0xd8,0x46,0x0f,0xb6,0x1c,0x59,0x45,0x88,0x1a,0xff,0xc0,0x44,0x8b,0xd0,0x4d,0x63,0xd9,0x4d,0x3b,0xd3,0x7c,0xe2,0xc5,0xf9,0x28,0x44,0x24,0x40,0xc4,0xc1,0x79,0x11,0x00,0x33,0xd2,0x48,0x8d,0x4c,0x24,0x20,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x01,0x48,0x89,0x51,0x10,0xc6,0x44,0x24,0x30,0x01,0x48,0x8d,0x4c,0x24,0x20,0x48,0xba,0x60,0x30,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0xe8,0x21,0xdf,0x86,0x5c,0x8b,0x54,0x24,0x30,0x0f,0xb6,0xd2,0x48,0x89,0x54,0x24,0x28,0x48,0x8b,0x54,0x24,0x20,0x48,0x8b,0xce,0xe8,0x08,0xdf,0x86,0x5c,0x48,0x8b,0x44,0x24,0x28,0x48,0x89,0x46,0x08,0x0f,0xb6,0x44,0x24,0x30,0x88,0x46,0x10,0x48,0x8b,0xc6,0x48,0x83,0xc4,0x50,0x5e,0xc3,0xe8,0x89,0x70,0x99,0x5c};

    }
}
