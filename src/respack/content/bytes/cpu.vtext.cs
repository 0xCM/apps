﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2021-12-01 21:34:45 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class cpu_vtext
    {
        public static ReadOnlySpan<byte> pack16ヽᐤCharBlock16ᕀinㆍByteBlock16ᕀrefᐤ  =>  new byte[76]{0x50,0xc5,0xf8,0x77,0x33,0xc0,0x89,0x44,0x24,0x04,0x0f,0xb7,0x01,0x89,0x44,0x24,0x04,0xc5,0xff,0xf0,0x44,0x24,0x04,0xc4,0xe3,0x7d,0x39,0xc1,0x00,0xc4,0xe3,0x7d,0x39,0xc0,0x01,0xc7,0x04,0x24,0xff,0x00,0x00,0x00,0x48,0x8d,0x04,0x24,0xc4,0xe2,0x79,0x79,0x14,0x24,0xc5,0xf1,0xdb,0xca,0xc5,0xf9,0xdb,0xc2,0xc5,0xf1,0x67,0xc0,0xc5,0xfa,0x7f,0x02,0xc5,0xf8,0x77,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> pack32ヽᐤCharBlock32ᕀinㆍByteBlock32ᕀrefᐤ  =>  new byte[154]{0x48,0x83,0xec,0x18,0xc5,0xf8,0x77,0x33,0xc0,0x89,0x44,0x24,0x14,0x0f,0xb7,0x01,0x89,0x44,0x24,0x14,0xc5,0xff,0xf0,0x44,0x24,0x14,0xc4,0xe3,0x7d,0x39,0xc1,0x00,0xc4,0xe3,0x7d,0x39,0xc0,0x01,0xc7,0x44,0x24,0x10,0xff,0x00,0x00,0x00,0x48,0x8d,0x44,0x24,0x10,0xc4,0xe2,0x79,0x79,0x54,0x24,0x10,0xc5,0xf1,0xdb,0xca,0xc5,0xf9,0xdb,0xc2,0xc5,0xf1,0x67,0xc0,0x48,0x8b,0xc2,0xc5,0xfa,0x7f,0x00,0x48,0x83,0xc1,0x20,0x48,0x83,0xc2,0x10,0x0f,0xb7,0x01,0x89,0x44,0x24,0x14,0xc5,0xff,0xf0,0x44,0x24,0x14,0xc4,0xe3,0x7d,0x39,0xc1,0x00,0xc4,0xe3,0x7d,0x39,0xc0,0x01,0xc7,0x44,0x24,0x0c,0xff,0x00,0x00,0x00,0x48,0x8d,0x44,0x24,0x0c,0xc4,0xe2,0x79,0x79,0x54,0x24,0x0c,0xc5,0xf1,0xdb,0xca,0xc5,0xf9,0xdb,0xc2,0xc5,0xf1,0x67,0xc0,0xc5,0xfa,0x7f,0x02,0xc5,0xf8,0x77,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> pack64ヽᐤCharBlock64ᕀinㆍByteBlock64ᕀrefᐤ  =>  new byte[294]{0x48,0x83,0xec,0x18,0xc5,0xf8,0x77,0x33,0xc0,0x89,0x44,0x24,0x14,0x0f,0xb7,0x01,0x89,0x44,0x24,0x14,0xc5,0xff,0xf0,0x44,0x24,0x14,0xc4,0xe3,0x7d,0x39,0xc1,0x00,0xc4,0xe3,0x7d,0x39,0xc0,0x01,0xc7,0x44,0x24,0x10,0xff,0x00,0x00,0x00,0x48,0x8d,0x44,0x24,0x10,0xc4,0xe2,0x79,0x79,0x54,0x24,0x10,0xc5,0xf1,0xdb,0xca,0xc5,0xf9,0xdb,0xc2,0xc5,0xf1,0x67,0xc0,0x48,0x8b,0xc2,0xc5,0xfa,0x7f,0x00,0x48,0x8d,0x41,0x20,0x4c,0x8d,0x42,0x10,0x0f,0xb7,0x00,0x89,0x44,0x24,0x14,0xc5,0xff,0xf0,0x44,0x24,0x14,0xc4,0xe3,0x7d,0x39,0xc1,0x00,0xc4,0xe3,0x7d,0x39,0xc0,0x01,0xc7,0x44,0x24,0x0c,0xff,0x00,0x00,0x00,0x48,0x8d,0x44,0x24,0x0c,0xc4,0xe2,0x79,0x79,0x54,0x24,0x0c,0xc5,0xf1,0xdb,0xca,0xc5,0xf9,0xdb,0xc2,0xc5,0xf1,0x67,0xc0,0xc4,0xc1,0x7a,0x7f,0x00,0x48,0x8d,0x41,0x40,0x4c,0x8d,0x42,0x20,0x0f,0xb7,0x00,0x89,0x44,0x24,0x14,0xc5,0xff,0xf0,0x44,0x24,0x14,0xc4,0xe3,0x7d,0x39,0xc1,0x00,0xc4,0xe3,0x7d,0x39,0xc0,0x01,0xc7,0x44,0x24,0x08,0xff,0x00,0x00,0x00,0x48,0x8d,0x44,0x24,0x08,0xc4,0xe2,0x79,0x79,0x54,0x24,0x08,0xc5,0xf1,0xdb,0xca,0xc5,0xf9,0xdb,0xc2,0xc5,0xf1,0x67,0xc0,0xc4,0xc1,0x7a,0x7f,0x00,0x48,0x83,0xc1,0x60,0x48,0x83,0xc2,0x30,0x0f,0xb7,0x01,0x89,0x44,0x24,0x14,0xc5,0xff,0xf0,0x44,0x24,0x14,0xc4,0xe3,0x7d,0x39,0xc1,0x00,0xc4,0xe3,0x7d,0x39,0xc0,0x01,0xc7,0x44,0x24,0x04,0xff,0x00,0x00,0x00,0x48,0x8d,0x44,0x24,0x04,0xc4,0xe2,0x79,0x79,0x54,0x24,0x04,0xc5,0xf1,0xdb,0xca,0xc5,0xf9,0xdb,0xc2,0xc5,0xf1,0x67,0xc0,0xc5,0xfa,0x7f,0x02,0xc5,0xf8,0x77,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> unpack32ヽᐤByteBlock32ᕀinㆍCharBlock32ᕀrefᐤ  =>  new byte[104]{0x48,0x83,0xec,0x28,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x08,0x48,0x89,0x44,0x24,0x10,0x48,0x89,0x44,0x24,0x18,0x48,0x89,0x44,0x24,0x20,0xc5,0xfa,0x6f,0x01,0xc5,0xfa,0x7f,0x44,0x24,0x08,0xc5,0xfa,0x6f,0x41,0x10,0xc5,0xfa,0x7f,0x44,0x24,0x18,0x48,0x8d,0x44,0x24,0x08,0xc5,0xff,0xf0,0x00,0xc4,0xe3,0x7d,0x39,0xc1,0x00,0xc4,0xe2,0x7d,0x30,0xc9,0x48,0x8b,0xc2,0xc5,0xfe,0x7f,0x08,0xc4,0xe3,0x7d,0x39,0xc0,0x01,0xc4,0xe2,0x7d,0x30,0xc0,0x48,0x83,0xc2,0x20,0xc5,0xfe,0x7f,0x02,0xc5,0xf8,0x77,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> charsヽᐤByteBlock32ᕀinᐤ  =>  new byte[121]{0x57,0x56,0x48,0x83,0xec,0x68,0xc5,0xf8,0x77,0x48,0x8b,0xf1,0x48,0x8d,0x7c,0x24,0x08,0xb9,0x18,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0xc5,0xfa,0x6f,0x02,0xc5,0xfa,0x7f,0x44,0x24,0x48,0xc5,0xfa,0x6f,0x42,0x10,0xc5,0xfa,0x7f,0x44,0x24,0x58,0x48,0x8d,0x44,0x24,0x48,0xc5,0xff,0xf0,0x00,0xc4,0xe3,0x7d,0x39,0xc1,0x00,0xc4,0xe2,0x7d,0x30,0xc9,0xc4,0xe3,0x7d,0x39,0xc0,0x01,0xc4,0xe2,0x7d,0x30,0xc0,0xc5,0xfd,0x11,0x4c,0x24,0x08,0xc5,0xfd,0x11,0x44,0x24,0x28,0x48,0x8d,0x44,0x24,0x08,0x48,0x89,0x01,0xc7,0x41,0x08,0x20,0x00,0x00,0x00,0x48,0x8b,0xc1,0xc5,0xf8,0x77,0x48,0x83,0xc4,0x68,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> bitsヽᐤVector128ᐸbyteᐳㆍspancharᐤ  =>  new byte[152]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x01,0xc4,0xe3,0x79,0x14,0xc0,0x01,0x0f,0xb6,0xc8,0x49,0xb8,0x01,0x01,0x01,0x01,0x01,0x01,0x01,0x01,0xc4,0xc2,0xf3,0xf5,0xc8,0xc4,0xe1,0xf9,0x6e,0xc1,0x8b,0xc8,0xc1,0xe9,0x08,0x0f,0xb6,0xc9,0xc4,0xc2,0xf3,0xf5,0xc8,0xc4,0xe3,0xf9,0x22,0xc1,0x01,0x8b,0xc8,0xc1,0xe9,0x10,0x0f,0xb6,0xc9,0xc4,0xc2,0xf3,0xf5,0xc8,0xc4,0xe1,0xf9,0x6e,0xc9,0xc1,0xe8,0x18,0x0f,0xb6,0xc0,0xc4,0xc2,0xfb,0xf5,0xc0,0xc4,0xe3,0xf1,0x22,0xc8,0x01,0xc5,0xec,0x57,0xd2,0xc4,0xe3,0x6d,0x38,0xc0,0x00,0xc4,0xe3,0x7d,0x38,0xc1,0x01,0xc4,0xe3,0x7d,0x39,0xc1,0x00,0xc4,0xe2,0x7d,0x30,0xc9,0x48,0x8b,0x02,0x48,0x8b,0xd0,0xc5,0xfe,0x7f,0x0a,0xc4,0xe3,0x7d,0x39,0xc0,0x01,0xc4,0xe2,0x7d,0x30,0xc0,0x48,0x83,0xc0,0x20,0xc5,0xfe,0x7f,0x00,0xc5,0xf8,0x77,0xc3};

        public static ReadOnlySpan<byte> vunicode256ヽᐤrspancharᐤ  =>  new byte[23]{0xc5,0xf8,0x77,0x66,0x90,0x48,0x8b,0x02,0xc5,0xff,0xf0,0x00,0xc5,0xfd,0x11,0x01,0x48,0x8b,0xc1,0xc5,0xf8,0x77,0xc3};

        public static ReadOnlySpan<byte> vasci256ヽᐤrspan8uᐤ  =>  new byte[23]{0xc5,0xf8,0x77,0x66,0x90,0x48,0x8b,0x02,0xc5,0xff,0xf0,0x00,0xc5,0xfd,0x11,0x01,0x48,0x8b,0xc1,0xc5,0xf8,0x77,0xc3};

        public static ReadOnlySpan<byte> copy16ヽᐤrspancharㆍCharBlock16ᕀrefᐤ  =>  new byte[23]{0xc5,0xf8,0x77,0x66,0x90,0x48,0x8b,0x01,0xc5,0xfb,0xf0,0x00,0x48,0x8b,0xc2,0xc5,0xfa,0x7f,0x00,0x48,0x8b,0xc2,0xc3};

        public static ReadOnlySpan<byte> copy32ヽᐤrspancharㆍCharBlock32ᕀrefᐤ  =>  new byte[45]{0xc5,0xf8,0x77,0x66,0x90,0x48,0x8b,0x01,0x48,0x8b,0xc8,0xc5,0xff,0xf0,0x01,0x48,0x8b,0xca,0xc5,0xfe,0x7f,0x01,0x48,0x83,0xc0,0x20,0xc5,0xff,0xf0,0x00,0x48,0x8d,0x42,0x20,0xc5,0xfe,0x7f,0x00,0x48,0x8b,0xc2,0xc5,0xf8,0x77,0xc3};

        public static ReadOnlySpan<byte> outcomeヽgᐸ64uᐳᐤb128x64uㆍb128x64uㆍVector128ᐸulongᐳㆍVector128ᐸulongᐳㆍVector128ᐸulongᐳㆍITextBufferᐤ  =>  new byte[609]{0x41,0x57,0x41,0x56,0x41,0x54,0x57,0x56,0x55,0x53,0x48,0x81,0xec,0x90,0x00,0x00,0x00,0xc5,0xf8,0x77,0x48,0x8b,0xf1,0x48,0x8d,0x7c,0x24,0x30,0xb9,0x18,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x48,0x8b,0xfa,0x49,0x8b,0xd8,0x49,0x8b,0xe9,0x4c,0x8b,0xb4,0x24,0xf0,0x00,0x00,0x00,0x48,0x8b,0xb4,0x24,0xf8,0x00,0x00,0x00,0xc5,0xfa,0x6f,0x01,0xc5,0xfa,0x7f,0x84,0x24,0x80,0x00,0x00,0x00,0x48,0x8d,0x8c,0x24,0x80,0x00,0x00,0x00,0x48,0x8b,0x11,0x8b,0x49,0x08,0x4c,0x8b,0xfe,0x49,0xb8,0xd8,0x20,0x5e,0x73,0xd5,0x01,0x00,0x00,0x4d,0x8b,0x20,0x4c,0x8d,0x44,0x24,0x30,0x49,0x89,0x10,0x41,0x89,0x48,0x08,0xc7,0x44,0x24,0x20,0x01,0x00,0x00,0x00,0x48,0x8d,0x4c,0x24,0x30,0xba,0x2c,0x00,0x00,0x00,0x45,0x33,0xc0,0x45,0x33,0xc9,0xe8,0xfb,0xd1,0xbc,0xfe,0x4c,0x8b,0xc8,0x49,0x8b,0xd4,0x49,0x8b,0xcf,0x41,0xb8,0x3a,0x00,0x00,0x00,0xe8,0x77,0xaf,0x28,0xff,0xc5,0xfa,0x6f,0x07,0xc5,0xfa,0x7f,0x44,0x24,0x70,0x48,0x8d,0x4c,0x24,0x70,0x48,0x8b,0x11,0x8b,0x49,0x08,0x49,0xb8,0xe0,0x20,0x5e,0x73,0xd5,0x01,0x00,0x00,0x49,0x8b,0x38,0x4c,0x8d,0x44,0x24,0x30,0x49,0x89,0x10,0x41,0x89,0x48,0x08,0xc7,0x44,0x24,0x20,0x01,0x00,0x00,0x00,0x48,0x8d,0x4c,0x24,0x30,0xba,0x2c,0x00,0x00,0x00,0x45,0x33,0xc0,0x45,0x33,0xc9,0xe8,0x9c,0xd1,0xbc,0xfe,0x4c,0x8b,0xc8,0x48,0x8b,0xd7,0x48,0x8b,0xce,0x41,0xb8,0x3a,0x00,0x00,0x00,0xe8,0x18,0xaf,0x28,0xff,0xc5,0xf9,0x10,0x03,0xc5,0xf0,0x57,0xc9,0xc5,0xf9,0x29,0x4c,0x24,0x60,0x48,0x8d,0x4c,0x24,0x60,0x48,0x8b,0xd1,0xc5,0xfa,0x7f,0x02,0xba,0x02,0x00,0x00,0x00,0x49,0xb8,0xe8,0x20,0x5e,0x73,0xd5,0x01,0x00,0x00,0x49,0x8b,0x38,0x4c,0x8d,0x44,0x24,0x30,0x49,0x89,0x08,0x41,0x89,0x50,0x08,0xc7,0x44,0x24,0x20,0x01,0x00,0x00,0x00,0x48,0x8d,0x4c,0x24,0x30,0xba,0x2c,0x00,0x00,0x00,0x45,0x33,0xc0,0x41,0xb9,0x02,0x00,0x00,0x00,0xe8,0x30,0xd1,0xbc,0xfe,0x4c,0x8b,0xc8,0x48,0x8b,0xd7,0x48,0x8b,0xce,0x41,0xb8,0x3a,0x00,0x00,0x00,0xe8,0xac,0xae,0x28,0xff,0xc5,0xf9,0x10,0x45,0x00,0xc5,0xf0,0x57,0xc9,0xc5,0xf9,0x29,0x4c,0x24,0x50,0x48,0x8d,0x4c,0x24,0x50,0x48,0x8b,0xd1,0xc5,0xfa,0x7f,0x02,0xba,0x02,0x00,0x00,0x00,0x49,0xb8,0xf0,0x20,0x5e,0x73,0xd5,0x01,0x00,0x00,0x49,0x8b,0x38,0x4c,0x8d,0x44,0x24,0x30,0x49,0x89,0x08,0x41,0x89,0x50,0x08,0xc7,0x44,0x24,0x20,0x01,0x00,0x00,0x00,0x48,0x8d,0x4c,0x24,0x30,0xba,0x2c,0x00,0x00,0x00,0x45,0x33,0xc0,0x41,0xb9,0x02,0x00,0x00,0x00,0xe8,0xc3,0xd0,0xbc,0xfe,0x4c,0x8b,0xc8,0x48,0x8b,0xd7,0x48,0x8b,0xce,0x41,0xb8,0x3a,0x00,0x00,0x00,0xe8,0x3f,0xae,0x28,0xff,0xc4,0xc1,0x79,0x10,0x06,0xc5,0xf0,0x57,0xc9,0xc5,0xf9,0x29,0x4c,0x24,0x40,0x48,0x8d,0x4c,0x24,0x40,0x48,0x8b,0xd1,0xc5,0xfa,0x7f,0x02,0xba,0x02,0x00,0x00,0x00,0x49,0xb8,0xf8,0x20,0x5e,0x73,0xd5,0x01,0x00,0x00,0x49,0x8b,0x38,0x4c,0x8d,0x44,0x24,0x30,0x49,0x89,0x08,0x41,0x89,0x50,0x08,0xc7,0x44,0x24,0x20,0x01,0x00,0x00,0x00,0x48,0x8d,0x4c,0x24,0x30,0xba,0x2c,0x00,0x00,0x00,0x45,0x33,0xc0,0x41,0xb9,0x02,0x00,0x00,0x00,0xe8,0x56,0xd0,0xbc,0xfe,0x4c,0x8b,0xc8,0x48,0x8b,0xd7,0x48,0x8b,0xce,0x41,0xb8,0x3a,0x00,0x00,0x00,0xe8,0xd2,0xad,0x28,0xff,0x90,0x48,0x81,0xc4,0x90,0x00,0x00,0x00,0x5b,0x5d,0x5e,0x5f,0x41,0x5c,0x41,0x5e,0x41,0x5f,0xc3};

        public static ReadOnlySpan<byte> outcomeヽgᐸ64uᐳᐤb256x64uㆍb256x64uㆍVector256ᐸulongᐳㆍVector256ᐸulongᐳㆍVector256ᐸulongᐳㆍITextBufferᐤ  =>  new byte[624]{0x41,0x57,0x41,0x56,0x41,0x54,0x57,0x56,0x55,0x53,0x48,0x81,0xec,0xc0,0x00,0x00,0x00,0xc5,0xf8,0x77,0x48,0x8b,0xf1,0x48,0x8d,0x7c,0x24,0x30,0xb9,0x24,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x48,0x8b,0xfa,0x49,0x8b,0xd8,0x49,0x8b,0xe9,0x4c,0x8b,0xb4,0x24,0x20,0x01,0x00,0x00,0x48,0x8b,0xb4,0x24,0x28,0x01,0x00,0x00,0xc5,0xfa,0x6f,0x01,0xc5,0xfa,0x7f,0x84,0x24,0xb0,0x00,0x00,0x00,0x48,0x8d,0x8c,0x24,0xb0,0x00,0x00,0x00,0x48,0x8b,0x11,0x8b,0x49,0x08,0x4c,0x8b,0xfe,0x49,0xb8,0xd8,0x20,0x5e,0x73,0xd5,0x01,0x00,0x00,0x4d,0x8b,0x20,0x4c,0x8d,0x44,0x24,0x30,0x49,0x89,0x10,0x41,0x89,0x48,0x08,0xc7,0x44,0x24,0x20,0x01,0x00,0x00,0x00,0x48,0x8d,0x4c,0x24,0x30,0xba,0x2c,0x00,0x00,0x00,0x45,0x33,0xc0,0x45,0x33,0xc9,0xe8,0x5b,0xcb,0xbc,0xfe,0x4c,0x8b,0xc8,0x49,0x8b,0xd4,0x49,0x8b,0xcf,0x41,0xb8,0x3a,0x00,0x00,0x00,0xe8,0xd7,0xa8,0x28,0xff,0xc5,0xfa,0x6f,0x07,0xc5,0xfa,0x7f,0x84,0x24,0xa0,0x00,0x00,0x00,0x48,0x8d,0x8c,0x24,0xa0,0x00,0x00,0x00,0x48,0x8b,0x11,0x8b,0x49,0x08,0x49,0xb8,0xe0,0x20,0x5e,0x73,0xd5,0x01,0x00,0x00,0x49,0x8b,0x38,0x4c,0x8d,0x44,0x24,0x30,0x49,0x89,0x10,0x41,0x89,0x48,0x08,0xc7,0x44,0x24,0x20,0x01,0x00,0x00,0x00,0x48,0x8d,0x4c,0x24,0x30,0xba,0x2c,0x00,0x00,0x00,0x45,0x33,0xc0,0x45,0x33,0xc9,0xe8,0xf6,0xca,0xbc,0xfe,0x4c,0x8b,0xc8,0x48,0x8b,0xd7,0x48,0x8b,0xce,0x41,0xb8,0x3a,0x00,0x00,0x00,0xe8,0x72,0xa8,0x28,0xff,0xc5,0xfd,0x10,0x03,0xc5,0xf4,0x57,0xc9,0xc5,0xfd,0x11,0x8c,0x24,0x80,0x00,0x00,0x00,0x48,0x8d,0x8c,0x24,0x80,0x00,0x00,0x00,0x48,0x8b,0xd1,0xc5,0xfe,0x7f,0x02,0xba,0x04,0x00,0x00,0x00,0x49,0xb8,0xe8,0x20,0x5e,0x73,0xd5,0x01,0x00,0x00,0x49,0x8b,0x38,0x4c,0x8d,0x44,0x24,0x30,0x49,0x89,0x08,0x41,0x89,0x50,0x08,0xc7,0x44,0x24,0x20,0x01,0x00,0x00,0x00,0x48,0x8d,0x4c,0x24,0x30,0xba,0x2c,0x00,0x00,0x00,0x45,0x33,0xc0,0x41,0xb9,0x02,0x00,0x00,0x00,0xe8,0x84,0xca,0xbc,0xfe,0x4c,0x8b,0xc8,0x48,0x8b,0xd7,0x48,0x8b,0xce,0x41,0xb8,0x3a,0x00,0x00,0x00,0xe8,0x00,0xa8,0x28,0xff,0xc5,0xfd,0x10,0x45,0x00,0xc5,0xf4,0x57,0xc9,0xc5,0xfd,0x11,0x4c,0x24,0x60,0x48,0x8d,0x4c,0x24,0x60,0x48,0x8b,0xd1,0xc5,0xfe,0x7f,0x02,0xba,0x04,0x00,0x00,0x00,0x49,0xb8,0xf0,0x20,0x5e,0x73,0xd5,0x01,0x00,0x00,0x49,0x8b,0x38,0x4c,0x8d,0x44,0x24,0x30,0x49,0x89,0x08,0x41,0x89,0x50,0x08,0xc7,0x44,0x24,0x20,0x01,0x00,0x00,0x00,0x48,0x8d,0x4c,0x24,0x30,0xba,0x2c,0x00,0x00,0x00,0x45,0x33,0xc0,0x41,0xb9,0x02,0x00,0x00,0x00,0xe8,0x17,0xca,0xbc,0xfe,0x4c,0x8b,0xc8,0x48,0x8b,0xd7,0x48,0x8b,0xce,0x41,0xb8,0x3a,0x00,0x00,0x00,0xe8,0x93,0xa7,0x28,0xff,0xc4,0xc1,0x7d,0x10,0x06,0xc5,0xf4,0x57,0xc9,0xc5,0xfd,0x11,0x4c,0x24,0x40,0x48,0x8d,0x4c,0x24,0x40,0x48,0x8b,0xd1,0xc5,0xfe,0x7f,0x02,0xba,0x04,0x00,0x00,0x00,0x49,0xb8,0xf8,0x20,0x5e,0x73,0xd5,0x01,0x00,0x00,0x49,0x8b,0x38,0x4c,0x8d,0x44,0x24,0x30,0x49,0x89,0x08,0x41,0x89,0x50,0x08,0xc7,0x44,0x24,0x20,0x01,0x00,0x00,0x00,0x48,0x8d,0x4c,0x24,0x30,0xba,0x2c,0x00,0x00,0x00,0x45,0x33,0xc0,0x41,0xb9,0x02,0x00,0x00,0x00,0xe8,0xaa,0xc9,0xbc,0xfe,0x4c,0x8b,0xc8,0x48,0x8b,0xd7,0x48,0x8b,0xce,0x41,0xb8,0x3a,0x00,0x00,0x00,0xe8,0x26,0xa7,0x28,0xff,0x90,0xc5,0xf8,0x77,0x48,0x81,0xc4,0xc0,0x00,0x00,0x00,0x5b,0x5d,0x5e,0x5f,0x41,0x5c,0x41,0x5e,0x41,0x5f,0xc3};

        public static ReadOnlySpan<byte> asmhexヽgᐸ64uᐳᐤVector128ᐸulongᐳㆍITextBufferᐤ  =>  new byte[157]{0x56,0x48,0x83,0xec,0x50,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x30,0x48,0x89,0x44,0x24,0x20,0x48,0x8b,0xf2,0xc5,0xf9,0x10,0x01,0xc5,0xf0,0x57,0xc9,0xc5,0xf9,0x29,0x4c,0x24,0x40,0xc5,0xf0,0x57,0xc9,0xc5,0xf9,0x29,0x4c,0x24,0x40,0x48,0x8d,0x4c,0x24,0x40,0x48,0x8b,0xd1,0xc5,0xfa,0x7f,0x02,0xba,0x02,0x00,0x00,0x00,0x4c,0x8d,0x44,0x24,0x30,0x49,0x89,0x08,0x41,0x89,0x50,0x08,0x48,0x8d,0x4c,0x24,0x30,0xba,0x20,0x00,0x00,0x00,0x45,0x33,0xc0,0xe8,0xa2,0x13,0x1d,0xff,0x48,0x85,0xc0,0x75,0x06,0x33,0xc9,0x33,0xd2,0xeb,0x07,0x48,0x8d,0x48,0x0c,0x8b,0x50,0x08,0x4c,0x8d,0x5c,0x24,0x20,0x49,0x89,0x0b,0x41,0x89,0x53,0x08,0x48,0x8b,0xce,0x48,0x8d,0x54,0x24,0x20,0x49,0xbb,0xf8,0x19,0xc5,0x76,0xfd,0x7f,0x00,0x00,0x39,0x09,0xff,0x15,0xd2,0xb7,0xb9,0xfb,0x90,0x48,0x83,0xc4,0x50,0x5e,0xc3};

        public static ReadOnlySpan<byte> asmhexヽgᐸ64uᐳᐤVector256ᐸulongᐳㆍITextBufferᐤ  =>  new byte[160]{0x56,0x48,0x83,0xec,0x70,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x30,0x48,0x89,0x44,0x24,0x20,0x48,0x8b,0xf2,0xc5,0xfd,0x10,0x01,0xc5,0xf4,0x57,0xc9,0xc5,0xfd,0x11,0x4c,0x24,0x40,0xc5,0xf4,0x57,0xc9,0xc5,0xfd,0x11,0x4c,0x24,0x40,0x48,0x8d,0x4c,0x24,0x40,0x48,0x8b,0xd1,0xc5,0xfe,0x7f,0x02,0xba,0x04,0x00,0x00,0x00,0x4c,0x8d,0x44,0x24,0x30,0x49,0x89,0x08,0x41,0x89,0x50,0x08,0x48,0x8d,0x4c,0x24,0x30,0xba,0x20,0x00,0x00,0x00,0x45,0x33,0xc0,0xe8,0xe2,0x12,0x1d,0xff,0x48,0x85,0xc0,0x75,0x06,0x33,0xc9,0x33,0xd2,0xeb,0x07,0x48,0x8d,0x48,0x0c,0x8b,0x50,0x08,0x4c,0x8d,0x5c,0x24,0x20,0x49,0x89,0x0b,0x41,0x89,0x53,0x08,0x48,0x8b,0xce,0x48,0x8d,0x54,0x24,0x20,0x49,0xbb,0x00,0x1a,0xc5,0x76,0xfd,0x7f,0x00,0x00,0x39,0x09,0xff,0x15,0x1a,0xb7,0xb9,0xfb,0x90,0xc5,0xf8,0x77,0x48,0x83,0xc4,0x70,0x5e,0xc3};

        public static ReadOnlySpan<byte> asmhexヽgᐸ64uᐳᐤb512x64uㆍITextBufferᐤ  =>  new byte[199]{0x56,0x48,0x81,0xec,0x80,0x00,0x00,0x00,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x30,0x48,0x89,0x44,0x24,0x20,0x48,0x8b,0xf2,0xc5,0xfd,0x10,0x01,0xc5,0xfd,0x10,0x49,0x20,0xc5,0xec,0x57,0xd2,0xc5,0xfd,0x11,0x54,0x24,0x40,0xc5,0xec,0x57,0xd2,0xc5,0xfd,0x11,0x54,0x24,0x60,0xc5,0xec,0x57,0xd2,0xc5,0xe4,0x57,0xdb,0xc5,0xfd,0x11,0x54,0x24,0x40,0xc5,0xfd,0x11,0x5c,0x24,0x60,0x48,0x8d,0x4c,0x24,0x40,0x48,0x8b,0xd1,0xc5,0xfe,0x7f,0x02,0x48,0x8d,0x51,0x20,0xc5,0xfe,0x7f,0x0a,0xba,0x08,0x00,0x00,0x00,0x4c,0x8d,0x44,0x24,0x30,0x49,0x89,0x08,0x41,0x89,0x50,0x08,0x48,0x8d,0x4c,0x24,0x30,0xba,0x20,0x00,0x00,0x00,0x45,0x33,0xc0,0xe8,0xfe,0x11,0x1d,0xff,0x48,0x85,0xc0,0x75,0x06,0x33,0xc9,0x33,0xd2,0xeb,0x07,0x48,0x8d,0x48,0x0c,0x8b,0x50,0x08,0x4c,0x8d,0x5c,0x24,0x20,0x49,0x89,0x0b,0x41,0x89,0x53,0x08,0x48,0x8b,0xce,0x48,0x8d,0x54,0x24,0x20,0x49,0xbb,0x08,0x1a,0xc5,0x76,0xfd,0x7f,0x00,0x00,0x39,0x09,0xff,0x15,0x3e,0xb6,0xb9,0xfb,0x90,0xc5,0xf8,0x77,0x48,0x81,0xc4,0x80,0x00,0x00,0x00,0x5e,0xc3};

        public static ReadOnlySpan<byte> lanesヽgᐸ64uᐳᐤVector256ᐸulongᐳㆍcharㆍ32iㆍITextBufferᐤ  =>  new byte[363]{0x41,0x56,0x57,0x56,0x55,0x53,0x48,0x81,0xec,0x90,0x00,0x00,0x00,0xc5,0xf8,0x77,0x48,0x8b,0xf1,0x48,0x8d,0x7c,0x24,0x30,0xb9,0x10,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x48,0x8b,0xf1,0x8b,0xfa,0x41,0x8b,0xd8,0x49,0x8b,0xe9,0xc5,0xfe,0x6f,0x06,0xc5,0xf0,0x57,0xc9,0xc5,0xf9,0x29,0x8c,0x24,0x80,0x00,0x00,0x00,0xc5,0xf0,0x57,0xc9,0xc5,0xf9,0x29,0x8c,0x24,0x80,0x00,0x00,0x00,0x48,0x8d,0x8c,0x24,0x80,0x00,0x00,0x00,0x48,0x8b,0xd1,0xc5,0xfa,0x7f,0x02,0xba,0x02,0x00,0x00,0x00,0x4c,0x8d,0x4c,0x24,0x60,0x49,0x89,0x09,0x41,0x89,0x51,0x08,0xc7,0x44,0x24,0x20,0x01,0x00,0x00,0x00,0x48,0x8d,0x4c,0x24,0x60,0x0f,0xb7,0xd7,0x44,0x8b,0xcb,0x45,0x33,0xc0,0xe8,0x48,0xc6,0xbc,0xfe,0x4c,0x8b,0xf0,0xc5,0xfd,0x10,0x06,0xc4,0xe3,0x7d,0x39,0xc0,0x01,0xc5,0xf0,0x57,0xc9,0xc5,0xf9,0x29,0x4c,0x24,0x70,0xc5,0xf0,0x57,0xc9,0xc5,0xf9,0x29,0x4c,0x24,0x70,0x48,0x8d,0x4c,0x24,0x70,0x48,0x8b,0xd1,0xc5,0xfa,0x7f,0x02,0xba,0x02,0x00,0x00,0x00,0x4c,0x8d,0x4c,0x24,0x60,0x49,0x89,0x09,0x41,0x89,0x51,0x08,0xc7,0x44,0x24,0x20,0x01,0x00,0x00,0x00,0x48,0x8d,0x4c,0x24,0x60,0x0f,0xb7,0xd7,0x44,0x8b,0xcb,0x45,0x33,0xc0,0xe8,0xef,0xc5,0xbc,0xfe,0x45,0x33,0xc0,0x48,0xba,0x90,0x13,0x4d,0x73,0xd5,0x01,0x00,0x00,0x48,0x8b,0x12,0x48,0xb9,0xc8,0x12,0x5e,0x73,0xd5,0x01,0x00,0x00,0x48,0x8b,0x09,0x4c,0x8d,0x4c,0x24,0x40,0x4d,0x89,0x31,0x49,0x89,0x41,0x08,0x4d,0x89,0x41,0x10,0x49,0x89,0x51,0x18,0x4c,0x8d,0x44,0x24,0x40,0x48,0x8b,0xd1,0x33,0xc9,0xe8,0x7f,0xfd,0xe6,0x54,0x48,0x85,0xc0,0x75,0x06,0x33,0xc9,0x33,0xd2,0xeb,0x07,0x48,0x8d,0x48,0x0c,0x8b,0x50,0x08,0x4c,0x8d,0x5c,0x24,0x30,0x49,0x89,0x0b,0x41,0x89,0x53,0x08,0x48,0x8b,0xcd,0x48,0x8d,0x54,0x24,0x30,0x49,0xbb,0x10,0x1a,0xc5,0x76,0xfd,0x7f,0x00,0x00,0x39,0x09,0xff,0x15,0xb7,0xb4,0xb9,0xfb,0x90,0xc5,0xf8,0x77,0x48,0x81,0xc4,0x90,0x00,0x00,0x00,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0xc3};

        public static ReadOnlySpan<byte> hexヽgᐸ64uᐳᐤVector128ᐸulongᐳㆍITextBufferㆍcharㆍboolᐤ  =>  new byte[156]{0x56,0x48,0x83,0xec,0x50,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x30,0x48,0x89,0x44,0x24,0x20,0x48,0x8b,0xf2,0xc5,0xf9,0x10,0x01,0xc5,0xf0,0x57,0xc9,0xc5,0xf9,0x29,0x4c,0x24,0x40,0xc5,0xf0,0x57,0xc9,0xc5,0xf9,0x29,0x4c,0x24,0x40,0x48,0x8d,0x4c,0x24,0x40,0x48,0x8b,0xd1,0xc5,0xfa,0x7f,0x02,0xba,0x02,0x00,0x00,0x00,0x48,0x8d,0x44,0x24,0x30,0x48,0x89,0x08,0x89,0x50,0x08,0x48,0x8d,0x4c,0x24,0x30,0x41,0x0f,0xb7,0xd0,0x45,0x0f,0xb6,0xc1,0xe8,0x93,0x0f,0x1d,0xff,0x48,0x85,0xc0,0x75,0x06,0x33,0xc9,0x33,0xd2,0xeb,0x07,0x48,0x8d,0x48,0x0c,0x8b,0x50,0x08,0x4c,0x8d,0x5c,0x24,0x20,0x49,0x89,0x0b,0x41,0x89,0x53,0x08,0x48,0x8b,0xce,0x48,0x8d,0x54,0x24,0x20,0x49,0xbb,0x18,0x1a,0xc5,0x76,0xfd,0x7f,0x00,0x00,0x39,0x09,0xff,0x15,0xe3,0xb3,0xb9,0xfb,0x90,0x48,0x83,0xc4,0x50,0x5e,0xc3};

        public static ReadOnlySpan<byte> hexヽgᐸ64uᐳᐤVector256ᐸulongᐳㆍITextBufferㆍcharㆍboolᐤ  =>  new byte[159]{0x56,0x48,0x83,0xec,0x70,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x30,0x48,0x89,0x44,0x24,0x20,0x48,0x8b,0xf2,0xc5,0xfd,0x10,0x01,0xc5,0xf4,0x57,0xc9,0xc5,0xfd,0x11,0x4c,0x24,0x40,0xc5,0xf4,0x57,0xc9,0xc5,0xfd,0x11,0x4c,0x24,0x40,0x48,0x8d,0x4c,0x24,0x40,0x48,0x8b,0xd1,0xc5,0xfe,0x7f,0x02,0xba,0x04,0x00,0x00,0x00,0x48,0x8d,0x44,0x24,0x30,0x48,0x89,0x08,0x89,0x50,0x08,0x48,0x8d,0x4c,0x24,0x30,0x41,0x0f,0xb7,0xd0,0x45,0x0f,0xb6,0xc1,0xe8,0xd3,0x0e,0x1d,0xff,0x48,0x85,0xc0,0x75,0x06,0x33,0xc9,0x33,0xd2,0xeb,0x07,0x48,0x8d,0x48,0x0c,0x8b,0x50,0x08,0x4c,0x8d,0x5c,0x24,0x20,0x49,0x89,0x0b,0x41,0x89,0x53,0x08,0x48,0x8b,0xce,0x48,0x8d,0x54,0x24,0x20,0x49,0xbb,0x20,0x1a,0xc5,0x76,0xfd,0x7f,0x00,0x00,0x39,0x09,0xff,0x15,0x2b,0xb3,0xb9,0xfb,0x90,0xc5,0xf8,0x77,0x48,0x83,0xc4,0x70,0x5e,0xc3};

    }
}
