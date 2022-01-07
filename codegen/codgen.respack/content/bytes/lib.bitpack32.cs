﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2022-01-07 15:36:30 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class lib_bitpack32
    {
        public static ReadOnlySpan<byte> packヽᐤspanBit32ㆍn8ᐤ  =>  new byte[144]{0x48,0x83,0xec,0x28,0xc5,0xf8,0x77,0x48,0x8b,0x01,0x8b,0x51,0x08,0x48,0x83,0xfa,0x08,0x0f,0x82,0x74,0x00,0x00,0x00,0xc5,0xff,0xf0,0x00,0xc4,0xe3,0x7d,0x39,0xc1,0x00,0xc4,0xe3,0x7d,0x39,0xc0,0x01,0xc7,0x44,0x24,0x24,0xff,0xff,0x00,0x00,0x48,0x8d,0x44,0x24,0x24,0xc4,0xe2,0x79,0x58,0x54,0x24,0x24,0xc5,0xf1,0xdb,0xca,0xc5,0xf9,0xdb,0xc2,0xc4,0xe2,0x71,0x2b,0xc0,0xc5,0xf0,0x57,0xc9,0xc7,0x44,0x24,0x20,0xff,0x00,0x00,0x00,0x48,0x8d,0x44,0x24,0x20,0xc4,0xe2,0x79,0x79,0x54,0x24,0x20,0xc5,0xf9,0xdb,0xc2,0xc5,0xf1,0xdb,0xca,0xc5,0xf9,0x67,0xc1,0xb8,0x07,0x00,0x00,0x00,0xc5,0xf9,0x6e,0xc8,0xc5,0xf9,0xf3,0xc1,0xc5,0xf9,0xd7,0xc0,0x0f,0xb7,0xc0,0x0f,0xb6,0xc0,0xc5,0xf8,0x77,0x48,0x83,0xc4,0x28,0xc3,0xe8,0xe8,0x4d,0xcf,0xfc};

        public static ReadOnlySpan<byte> packヽᐤspanBit32ㆍn16ᐤ  =>  new byte[154]{0x48,0x83,0xec,0x28,0xc5,0xf8,0x77,0x48,0x8b,0x01,0x8b,0x51,0x08,0x48,0x83,0xfa,0x10,0x0f,0x82,0x7e,0x00,0x00,0x00,0x48,0x8b,0xd0,0xc5,0xff,0xf0,0x02,0x48,0x83,0xc0,0x20,0xc5,0xff,0xf0,0x08,0xc7,0x44,0x24,0x24,0xff,0xff,0x00,0x00,0x48,0x8d,0x44,0x24,0x24,0xc4,0xe2,0x7d,0x58,0x54,0x24,0x24,0xc5,0xfd,0xdb,0xc2,0xc5,0xf5,0xdb,0xca,0xc4,0xe2,0x7d,0x2b,0xc1,0xc4,0xe3,0xfd,0x00,0xc0,0xd8,0xc4,0xe3,0x7d,0x39,0xc1,0x00,0xc4,0xe3,0x7d,0x39,0xc0,0x01,0xc7,0x44,0x24,0x20,0xff,0x00,0x00,0x00,0x48,0x8d,0x44,0x24,0x20,0xc4,0xe2,0x79,0x79,0x54,0x24,0x20,0xc5,0xf1,0xdb,0xca,0xc5,0xf9,0xdb,0xc2,0xc5,0xf1,0x67,0xc0,0xb8,0x07,0x00,0x00,0x00,0xc5,0xf9,0x6e,0xc8,0xc5,0xf9,0xf3,0xc1,0xc5,0xf9,0xd7,0xc0,0x0f,0xb7,0xc0,0xc5,0xf8,0x77,0x48,0x83,0xc4,0x28,0xc3,0xe8,0x2e,0x4d,0xcf,0xfc};

        public static ReadOnlySpan<byte> packヽᐤspanBit32ㆍn32ᐤ  =>  new byte[200]{0x48,0x83,0xec,0x38,0xc5,0xf8,0x77,0x48,0x8b,0x01,0x8b,0x51,0x08,0x48,0x83,0xfa,0x20,0x0f,0x82,0xac,0x00,0x00,0x00,0x48,0x8b,0xd0,0xc5,0xff,0xf0,0x02,0x48,0x8d,0x50,0x20,0xc5,0xff,0xf0,0x0a,0xc7,0x44,0x24,0x34,0xff,0xff,0x00,0x00,0x48,0x8d,0x54,0x24,0x34,0xc4,0xe2,0x7d,0x58,0x54,0x24,0x34,0xc5,0xfd,0xdb,0xc2,0xc5,0xf5,0xdb,0xca,0xc4,0xe2,0x7d,0x2b,0xc1,0xc4,0xe3,0xfd,0x00,0xc0,0xd8,0x48,0x8d,0x50,0x40,0xc5,0xff,0xf0,0x0a,0x48,0x83,0xc0,0x60,0xc5,0xff,0xf0,0x10,0xc7,0x44,0x24,0x30,0xff,0xff,0x00,0x00,0x48,0x8d,0x44,0x24,0x30,0xc4,0xe2,0x7d,0x58,0x5c,0x24,0x30,0xc5,0xf5,0xdb,0xcb,0xc5,0xed,0xdb,0xd3,0xc4,0xe2,0x75,0x2b,0xca,0xc4,0xe3,0xfd,0x00,0xc9,0xd8,0xc7,0x44,0x24,0x2c,0xff,0x00,0x00,0x00,0x48,0x8d,0x44,0x24,0x2c,0xc4,0xe2,0x7d,0x79,0x54,0x24,0x2c,0xc5,0xfd,0xdb,0xc2,0xc5,0xf5,0xdb,0xca,0xc5,0xfd,0x67,0xc1,0xc4,0xe3,0xfd,0x00,0xc0,0xd8,0xb8,0x07,0x00,0x00,0x00,0xc5,0xf9,0x6e,0xc8,0xc5,0xfd,0xf3,0xc1,0xc5,0xfd,0xd7,0xc0,0xc5,0xf8,0x77,0x48,0x83,0xc4,0x38,0xc3,0xe8,0x40,0x4c,0xcf,0xfc};

        public static ReadOnlySpan<byte> packヽᐤspanBit32ㆍn64ᐤ  =>  new byte[390]{0x48,0x83,0xec,0x38,0xc5,0xf8,0x77,0x48,0x8b,0x01,0x8b,0x51,0x08,0x48,0x83,0xfa,0x40,0x0f,0x82,0x6a,0x01,0x00,0x00,0x48,0x8b,0xd0,0xc5,0xff,0xf0,0x02,0x48,0x8d,0x50,0x20,0xc5,0xff,0xf0,0x0a,0xc7,0x44,0x24,0x34,0xff,0xff,0x00,0x00,0x48,0x8d,0x54,0x24,0x34,0xc4,0xe2,0x7d,0x58,0x54,0x24,0x34,0xc5,0xfd,0xdb,0xc2,0xc5,0xf5,0xdb,0xca,0xc4,0xe2,0x7d,0x2b,0xc1,0xc4,0xe3,0xfd,0x00,0xc0,0xd8,0x48,0x8d,0x50,0x40,0xc5,0xff,0xf0,0x0a,0x48,0x8d,0x50,0x60,0xc5,0xff,0xf0,0x12,0xc7,0x44,0x24,0x30,0xff,0xff,0x00,0x00,0x48,0x8d,0x54,0x24,0x30,0xc4,0xe2,0x7d,0x58,0x5c,0x24,0x30,0xc5,0xf5,0xdb,0xcb,0xc5,0xed,0xdb,0xd3,0xc4,0xe2,0x75,0x2b,0xca,0xc4,0xe3,0xfd,0x00,0xc9,0xd8,0xc7,0x44,0x24,0x2c,0xff,0x00,0x00,0x00,0x48,0x8d,0x54,0x24,0x2c,0xc4,0xe2,0x7d,0x79,0x54,0x24,0x2c,0xc5,0xfd,0xdb,0xc2,0xc5,0xf5,0xdb,0xca,0xc5,0xfd,0x67,0xc1,0xc4,0xe3,0xfd,0x00,0xc0,0xd8,0xba,0x07,0x00,0x00,0x00,0xc5,0xf9,0x6e,0xca,0xc5,0xfd,0xf3,0xc1,0xc5,0xfd,0xd7,0xd0,0x8b,0xd2,0x48,0x8d,0x88,0x80,0x00,0x00,0x00,0xc5,0xff,0xf0,0x09,0x48,0x8d,0x88,0xa0,0x00,0x00,0x00,0xc5,0xff,0xf0,0x11,0xc7,0x44,0x24,0x28,0xff,0xff,0x00,0x00,0x48,0x8d,0x4c,0x24,0x28,0xc4,0xe2,0x7d,0x58,0x44,0x24,0x28,0xc5,0xf5,0xdb,0xc8,0xc5,0xed,0xdb,0xc0,0xc4,0xe2,0x75,0x2b,0xc0,0xc4,0xe3,0xfd,0x00,0xc0,0xd8,0x48,0x8d,0x88,0xc0,0x00,0x00,0x00,0xc5,0xff,0xf0,0x09,0x48,0x05,0xe0,0x00,0x00,0x00,0xc5,0xff,0xf0,0x10,0xc7,0x44,0x24,0x24,0xff,0xff,0x00,0x00,0x48,0x8d,0x44,0x24,0x24,0xc4,0xe2,0x7d,0x58,0x5c,0x24,0x24,0xc5,0xf5,0xdb,0xcb,0xc5,0xed,0xdb,0xd3,0xc4,0xe2,0x75,0x2b,0xca,0xc4,0xe3,0xfd,0x00,0xc9,0xd8,0xc7,0x44,0x24,0x20,0xff,0x00,0x00,0x00,0x48,0x8d,0x44,0x24,0x20,0xc4,0xe2,0x7d,0x79,0x54,0x24,0x20,0xc5,0xfd,0xdb,0xc2,0xc5,0xf5,0xdb,0xca,0xc5,0xfd,0x67,0xc1,0xc4,0xe3,0xfd,0x00,0xc0,0xd8,0xb8,0x07,0x00,0x00,0x00,0xc5,0xf9,0x6e,0xc8,0xc5,0xfd,0xf3,0xc1,0xc5,0xfd,0xd7,0xc0,0x8b,0xc0,0x48,0xc1,0xe0,0x20,0x48,0x0b,0xd0,0x48,0x8b,0xc2,0xc5,0xf8,0x77,0x48,0x83,0xc4,0x38,0xc3,0xe8,0x92,0x4a,0xcf,0xfc};

        public static ReadOnlySpan<byte> packヽgᐸ8uᐳᐤspanBit32ㆍ8uᐤ  =>  new byte[144]{0x48,0x83,0xec,0x28,0xc5,0xf8,0x77,0x48,0x8b,0x01,0x8b,0x51,0x08,0x48,0x83,0xfa,0x08,0x0f,0x82,0x74,0x00,0x00,0x00,0xc5,0xff,0xf0,0x00,0xc4,0xe3,0x7d,0x39,0xc1,0x00,0xc4,0xe3,0x7d,0x39,0xc0,0x01,0xc7,0x44,0x24,0x24,0xff,0xff,0x00,0x00,0x48,0x8d,0x44,0x24,0x24,0xc4,0xe2,0x79,0x58,0x54,0x24,0x24,0xc5,0xf1,0xdb,0xca,0xc5,0xf9,0xdb,0xc2,0xc4,0xe2,0x71,0x2b,0xc0,0xc5,0xf0,0x57,0xc9,0xc7,0x44,0x24,0x20,0xff,0x00,0x00,0x00,0x48,0x8d,0x44,0x24,0x20,0xc4,0xe2,0x79,0x79,0x54,0x24,0x20,0xc5,0xf9,0xdb,0xc2,0xc5,0xf1,0xdb,0xca,0xc5,0xf9,0x67,0xc1,0xb8,0x07,0x00,0x00,0x00,0xc5,0xf9,0x6e,0xc8,0xc5,0xf9,0xf3,0xc1,0xc5,0xf9,0xd7,0xc0,0x0f,0xb7,0xc0,0x0f,0xb6,0xc0,0xc5,0xf8,0x77,0x48,0x83,0xc4,0x28,0xc3,0xe8,0xc8,0x49,0xcf,0xfc};

        public static ReadOnlySpan<byte> packヽgᐸ16uᐳᐤspanBit32ㆍ16uᐤ  =>  new byte[154]{0x48,0x83,0xec,0x28,0xc5,0xf8,0x77,0x48,0x8b,0x01,0x8b,0x51,0x08,0x48,0x83,0xfa,0x10,0x0f,0x82,0x7e,0x00,0x00,0x00,0x48,0x8b,0xd0,0xc5,0xff,0xf0,0x02,0x48,0x83,0xc0,0x20,0xc5,0xff,0xf0,0x08,0xc7,0x44,0x24,0x24,0xff,0xff,0x00,0x00,0x48,0x8d,0x44,0x24,0x24,0xc4,0xe2,0x7d,0x58,0x54,0x24,0x24,0xc5,0xfd,0xdb,0xc2,0xc5,0xf5,0xdb,0xca,0xc4,0xe2,0x7d,0x2b,0xc1,0xc4,0xe3,0xfd,0x00,0xc0,0xd8,0xc4,0xe3,0x7d,0x39,0xc1,0x00,0xc4,0xe3,0x7d,0x39,0xc0,0x01,0xc7,0x44,0x24,0x20,0xff,0x00,0x00,0x00,0x48,0x8d,0x44,0x24,0x20,0xc4,0xe2,0x79,0x79,0x54,0x24,0x20,0xc5,0xf1,0xdb,0xca,0xc5,0xf9,0xdb,0xc2,0xc5,0xf1,0x67,0xc0,0xb8,0x07,0x00,0x00,0x00,0xc5,0xf9,0x6e,0xc8,0xc5,0xf9,0xf3,0xc1,0xc5,0xf9,0xd7,0xc0,0x0f,0xb7,0xc0,0xc5,0xf8,0x77,0x48,0x83,0xc4,0x28,0xc3,0xe8,0x0e,0x49,0xcf,0xfc};

        public static ReadOnlySpan<byte> packヽgᐸ32uᐳᐤspanBit32ㆍ32uᐤ  =>  new byte[200]{0x48,0x83,0xec,0x38,0xc5,0xf8,0x77,0x48,0x8b,0x01,0x8b,0x51,0x08,0x48,0x83,0xfa,0x20,0x0f,0x82,0xac,0x00,0x00,0x00,0x48,0x8b,0xd0,0xc5,0xff,0xf0,0x02,0x48,0x8d,0x50,0x20,0xc5,0xff,0xf0,0x0a,0xc7,0x44,0x24,0x34,0xff,0xff,0x00,0x00,0x48,0x8d,0x54,0x24,0x34,0xc4,0xe2,0x7d,0x58,0x54,0x24,0x34,0xc5,0xfd,0xdb,0xc2,0xc5,0xf5,0xdb,0xca,0xc4,0xe2,0x7d,0x2b,0xc1,0xc4,0xe3,0xfd,0x00,0xc0,0xd8,0x48,0x8d,0x50,0x40,0xc5,0xff,0xf0,0x0a,0x48,0x83,0xc0,0x60,0xc5,0xff,0xf0,0x10,0xc7,0x44,0x24,0x30,0xff,0xff,0x00,0x00,0x48,0x8d,0x44,0x24,0x30,0xc4,0xe2,0x7d,0x58,0x5c,0x24,0x30,0xc5,0xf5,0xdb,0xcb,0xc5,0xed,0xdb,0xd3,0xc4,0xe2,0x75,0x2b,0xca,0xc4,0xe3,0xfd,0x00,0xc9,0xd8,0xc7,0x44,0x24,0x2c,0xff,0x00,0x00,0x00,0x48,0x8d,0x44,0x24,0x2c,0xc4,0xe2,0x7d,0x79,0x54,0x24,0x2c,0xc5,0xfd,0xdb,0xc2,0xc5,0xf5,0xdb,0xca,0xc5,0xfd,0x67,0xc1,0xc4,0xe3,0xfd,0x00,0xc0,0xd8,0xb8,0x07,0x00,0x00,0x00,0xc5,0xf9,0x6e,0xc8,0xc5,0xfd,0xf3,0xc1,0xc5,0xfd,0xd7,0xc0,0xc5,0xf8,0x77,0x48,0x83,0xc4,0x38,0xc3,0xe8,0x20,0x48,0xcf,0xfc};

        public static ReadOnlySpan<byte> packヽgᐸ64uᐳᐤspanBit32ㆍ64uᐤ  =>  new byte[390]{0x48,0x83,0xec,0x38,0xc5,0xf8,0x77,0x48,0x8b,0x01,0x8b,0x51,0x08,0x48,0x83,0xfa,0x40,0x0f,0x82,0x6a,0x01,0x00,0x00,0x48,0x8b,0xd0,0xc5,0xff,0xf0,0x02,0x48,0x8d,0x50,0x20,0xc5,0xff,0xf0,0x0a,0xc7,0x44,0x24,0x34,0xff,0xff,0x00,0x00,0x48,0x8d,0x54,0x24,0x34,0xc4,0xe2,0x7d,0x58,0x54,0x24,0x34,0xc5,0xfd,0xdb,0xc2,0xc5,0xf5,0xdb,0xca,0xc4,0xe2,0x7d,0x2b,0xc1,0xc4,0xe3,0xfd,0x00,0xc0,0xd8,0x48,0x8d,0x50,0x40,0xc5,0xff,0xf0,0x0a,0x48,0x8d,0x50,0x60,0xc5,0xff,0xf0,0x12,0xc7,0x44,0x24,0x30,0xff,0xff,0x00,0x00,0x48,0x8d,0x54,0x24,0x30,0xc4,0xe2,0x7d,0x58,0x5c,0x24,0x30,0xc5,0xf5,0xdb,0xcb,0xc5,0xed,0xdb,0xd3,0xc4,0xe2,0x75,0x2b,0xca,0xc4,0xe3,0xfd,0x00,0xc9,0xd8,0xc7,0x44,0x24,0x2c,0xff,0x00,0x00,0x00,0x48,0x8d,0x54,0x24,0x2c,0xc4,0xe2,0x7d,0x79,0x54,0x24,0x2c,0xc5,0xfd,0xdb,0xc2,0xc5,0xf5,0xdb,0xca,0xc5,0xfd,0x67,0xc1,0xc4,0xe3,0xfd,0x00,0xc0,0xd8,0xba,0x07,0x00,0x00,0x00,0xc5,0xf9,0x6e,0xca,0xc5,0xfd,0xf3,0xc1,0xc5,0xfd,0xd7,0xd0,0x8b,0xd2,0x48,0x8d,0x88,0x80,0x00,0x00,0x00,0xc5,0xff,0xf0,0x09,0x48,0x8d,0x88,0xa0,0x00,0x00,0x00,0xc5,0xff,0xf0,0x11,0xc7,0x44,0x24,0x28,0xff,0xff,0x00,0x00,0x48,0x8d,0x4c,0x24,0x28,0xc4,0xe2,0x7d,0x58,0x44,0x24,0x28,0xc5,0xf5,0xdb,0xc8,0xc5,0xed,0xdb,0xc0,0xc4,0xe2,0x75,0x2b,0xc0,0xc4,0xe3,0xfd,0x00,0xc0,0xd8,0x48,0x8d,0x88,0xc0,0x00,0x00,0x00,0xc5,0xff,0xf0,0x09,0x48,0x05,0xe0,0x00,0x00,0x00,0xc5,0xff,0xf0,0x10,0xc7,0x44,0x24,0x24,0xff,0xff,0x00,0x00,0x48,0x8d,0x44,0x24,0x24,0xc4,0xe2,0x7d,0x58,0x5c,0x24,0x24,0xc5,0xf5,0xdb,0xcb,0xc5,0xed,0xdb,0xd3,0xc4,0xe2,0x75,0x2b,0xca,0xc4,0xe3,0xfd,0x00,0xc9,0xd8,0xc7,0x44,0x24,0x20,0xff,0x00,0x00,0x00,0x48,0x8d,0x44,0x24,0x20,0xc4,0xe2,0x7d,0x79,0x54,0x24,0x20,0xc5,0xfd,0xdb,0xc2,0xc5,0xf5,0xdb,0xca,0xc5,0xfd,0x67,0xc1,0xc4,0xe3,0xfd,0x00,0xc0,0xd8,0xb8,0x07,0x00,0x00,0x00,0xc5,0xf9,0x6e,0xc8,0xc5,0xfd,0xf3,0xc1,0xc5,0xfd,0xd7,0xc0,0x8b,0xc0,0x48,0xc1,0xe0,0x20,0x48,0x0b,0xd0,0x48,0x8b,0xc2,0xc5,0xf8,0x77,0x48,0x83,0xc4,0x38,0xc3,0xe8,0x72,0x46,0xcf,0xfc};

    }
}
