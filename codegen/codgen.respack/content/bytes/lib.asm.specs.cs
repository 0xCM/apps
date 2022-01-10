﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2022-01-07 15:36:31 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class lib_asm_specs
    {
        public static ReadOnlySpan<byte> andヽᐤalㆍimm8ㆍ8uᕀrefᐤ  =>  new byte[31]{0x50,0x0f,0x1f,0x40,0x00,0xc6,0x04,0x24,0x24,0x8b,0x04,0x24,0x41,0x88,0x00,0x49,0xff,0xc0,0x41,0x88,0x10,0xb8,0x02,0x00,0x00,0x00,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> andヽᐤr8bㆍimm8ㆍ8uᕀrefᐤ  =>  new byte[31]{0x50,0x0f,0x1f,0x40,0x00,0xc6,0x04,0x24,0x24,0x8b,0x04,0x24,0x41,0x88,0x00,0x49,0xff,0xc0,0x41,0x88,0x10,0xb8,0x02,0x00,0x00,0x00,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> callヽᐤMemoryAddressㆍ32uᐤ  =>  new byte[16]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x89,0x11,0x44,0x89,0x41,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> int3ヽᐤspan8uᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x01,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> int3ヽᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0xcc,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> int3ヽᐤ8uᐤ  =>  new byte[15]{0x0f,0x1f,0x44,0x00,0x00,0x80,0xf9,0xcc,0x0f,0x94,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> joヽᐤHex8ㆍ8uᕀrefᐤ  =>  new byte[19]{0x0f,0x1f,0x44,0x00,0x00,0xc6,0x02,0x70,0x48,0xff,0xc2,0x88,0x0a,0xb8,0x02,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> joヽᐤHex32ㆍ8uᕀrefᐤ  =>  new byte[22]{0x0f,0x1f,0x44,0x00,0x00,0x66,0xc7,0x02,0x80,0x70,0x48,0x83,0xc2,0x04,0x89,0x0a,0xb8,0x06,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> jmp32ヽᐤMemoryAddressㆍMemoryAddressᐤ  =>  new byte[179]{0x57,0x56,0x48,0x83,0xec,0x58,0xc5,0xf8,0x77,0x48,0x8b,0xf1,0x48,0x8d,0x7c,0x24,0x10,0xb9,0x12,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x48,0x8d,0x44,0x24,0x48,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x00,0x48,0x8d,0x44,0x24,0x48,0xc5,0xfa,0x6f,0x44,0x24,0x48,0xc5,0xfa,0x7f,0x44,0x24,0x38,0xc6,0x44,0x24,0x30,0x0f,0x4c,0x8d,0x4c,0x24,0x38,0x44,0x8b,0x54,0x24,0x30,0x45,0x0f,0xb6,0xd2,0x4d,0x63,0xd2,0x47,0x0f,0xb6,0x0c,0x11,0x4c,0x8d,0x48,0x0f,0x4c,0x8d,0x54,0x24,0x20,0xc5,0xf8,0x57,0xc0,0xc4,0xc1,0x7a,0x7f,0x02,0xc5,0xfa,0x6f,0x44,0x24,0x20,0xc5,0xfa,0x7f,0x44,0x24,0x10,0xc6,0x44,0x24,0x08,0x0f,0x4c,0x8d,0x54,0x24,0x10,0x44,0x8b,0x5c,0x24,0x08,0x45,0x0f,0xb6,0xdb,0x4d,0x63,0xdb,0x47,0x0f,0xb6,0x14,0x1a,0xc6,0x00,0xe9,0x48,0xff,0xc0,0x4c,0x2b,0xc2,0x44,0x89,0x00,0x41,0xc6,0x01,0x05,0xc5,0xfa,0x6f,0x44,0x24,0x48,0xc5,0xfa,0x7f,0x01,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x58,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> jmp32ヽᐤMemoryAddressㆍMemoryAddressㆍ8uᕀrefᐤ  =>  new byte[102]{0x48,0x83,0xec,0x28,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x18,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x08,0x48,0x89,0x44,0x24,0x10,0x48,0x8d,0x44,0x24,0x18,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x00,0xc5,0xfa,0x6f,0x44,0x24,0x18,0xc5,0xfa,0x7f,0x44,0x24,0x08,0xc6,0x04,0x24,0x0f,0x48,0x8d,0x44,0x24,0x08,0x44,0x8b,0x0c,0x24,0x45,0x0f,0xb6,0xc9,0x4d,0x63,0xc9,0x42,0x0f,0xb6,0x04,0x08,0x41,0xc6,0x00,0xe9,0x49,0xff,0xc0,0x48,0x2b,0xd1,0x41,0x89,0x10,0xb8,0x05,0x00,0x00,0x00,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> jmp8ヽᐤMemoryAddressㆍMemoryAddressㆍ8uᕀrefᐤ  =>  new byte[110]{0x48,0x83,0xec,0x28,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x18,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x08,0x48,0x89,0x44,0x24,0x10,0x48,0x8d,0x44,0x24,0x18,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x00,0xc5,0xfa,0x6f,0x44,0x24,0x18,0xc5,0xfa,0x7f,0x44,0x24,0x08,0xc6,0x04,0x24,0x0f,0x48,0x8d,0x44,0x24,0x08,0x44,0x8b,0x0c,0x24,0x45,0x0f,0xb6,0xc9,0x4d,0x63,0xc9,0x42,0x0f,0xb6,0x04,0x08,0x41,0xc6,0x00,0xe8,0x49,0xff,0xc0,0x48,0x2b,0xd1,0x48,0x0f,0xbe,0xc2,0x48,0x0f,0xbe,0xc0,0x41,0x88,0x00,0xb8,0x02,0x00,0x00,0x00,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> movヽᐤr64ㆍimm64ᐤ  =>  new byte[398]{0x57,0x56,0x48,0x81,0xec,0x98,0x00,0x00,0x00,0xc5,0xf8,0x77,0x48,0x8b,0xf1,0x48,0x8d,0x7c,0x24,0x30,0xb9,0x16,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0xc6,0x84,0x24,0x90,0x00,0x00,0x00,0x48,0x0f,0xb6,0xc2,0x05,0xb8,0x00,0x00,0x00,0x0f,0xb6,0xc0,0x88,0x84,0x24,0x88,0x00,0x00,0x00,0x33,0xc0,0x48,0x8d,0x54,0x24,0x70,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x02,0x48,0x89,0x42,0x10,0x48,0x89,0x44,0x24,0x60,0x48,0x89,0x44,0x24,0x68,0x48,0x89,0x44,0x24,0x60,0x48,0x89,0x44,0x24,0x68,0x48,0x8d,0x44,0x24,0x60,0x33,0xd2,0x4c,0x8d,0x4c,0x24,0x48,0xc5,0xf8,0x57,0xc0,0xc4,0xc1,0x7a,0x7f,0x01,0x49,0x89,0x51,0x10,0x48,0x8d,0x54,0x24,0x48,0x48,0x89,0x02,0xc7,0x42,0x08,0x10,0x00,0x00,0x00,0x33,0xc0,0x89,0x44,0x24,0x58,0xc5,0xfa,0x6f,0x44,0x24,0x48,0xc5,0xfa,0x7f,0x44,0x24,0x70,0x48,0x8b,0x44,0x24,0x58,0x48,0x89,0x84,0x24,0x80,0x00,0x00,0x00,0x8b,0x84,0x24,0x80,0x00,0x00,0x00,0x48,0x8d,0x54,0x24,0x70,0x48,0x8b,0x12,0x44,0x8d,0x48,0x01,0x44,0x89,0x8c,0x24,0x80,0x00,0x00,0x00,0x48,0x63,0xc0,0x44,0x8b,0x8c,0x24,0x90,0x00,0x00,0x00,0x44,0x88,0x0c,0x02,0x8b,0x84,0x24,0x88,0x00,0x00,0x00,0x0f,0xb6,0xc0,0x8b,0x94,0x24,0x80,0x00,0x00,0x00,0x4c,0x8d,0x4c,0x24,0x70,0x4d,0x8b,0x09,0x44,0x8d,0x52,0x01,0x44,0x89,0x94,0x24,0x80,0x00,0x00,0x00,0x48,0x63,0xd2,0x41,0x88,0x04,0x11,0x8b,0x84,0x24,0x80,0x00,0x00,0x00,0x83,0xc0,0x08,0x48,0x8d,0x54,0x24,0x70,0x48,0x8b,0x12,0x89,0x84,0x24,0x80,0x00,0x00,0x00,0x48,0x63,0xc0,0x48,0x03,0xc2,0x4c,0x89,0x00,0xc5,0xfa,0x6f,0x44,0x24,0x70,0xc5,0xfa,0x7f,0x44,0x24,0x30,0x48,0x8b,0x84,0x24,0x80,0x00,0x00,0x00,0x48,0x89,0x44,0x24,0x40,0x48,0x8d,0x44,0x24,0x30,0x48,0x8b,0x00,0x48,0x83,0xc0,0x0f,0x0f,0xb6,0x54,0x24,0x40,0x88,0x10,0x48,0x8d,0x44,0x24,0x30,0x48,0x8b,0x00,0xc5,0xfb,0xf0,0x00,0xc5,0xf9,0x29,0x04,0x24,0xc5,0xfa,0x6f,0x04,0x24,0xc5,0xfa,0x7f,0x44,0x24,0x10,0xc5,0xf9,0x28,0x44,0x24,0x10,0x48,0x8d,0x44,0x24,0x20,0xc5,0xf9,0x11,0x00,0xc5,0xfa,0x6f,0x44,0x24,0x20,0xc5,0xfa,0x7f,0x01,0x48,0x8b,0xc1,0x48,0x81,0xc4,0x98,0x00,0x00,0x00,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> movzxヽᐤr16ㆍr8ㆍ8uᕀrefᐤ  =>  new byte[230]{0x48,0x83,0xec,0x48,0x90,0x0f,0xb6,0xc9,0x88,0x4c,0x24,0x40,0x0f,0xb6,0xca,0x88,0x4c,0x24,0x38,0x8b,0x4c,0x24,0x40,0x0f,0xb6,0xc9,0x8b,0x44,0x24,0x38,0x0f,0xb6,0xc0,0x0f,0xb6,0xc9,0xc6,0x44,0x24,0x10,0x00,0xc6,0x44,0x24,0x11,0x00,0x0f,0xb6,0xc9,0x88,0x4c,0x24,0x10,0xc6,0x44,0x24,0x11,0x00,0x48,0x0f,0xbf,0x4c,0x24,0x10,0x66,0x89,0x4c,0x24,0x28,0xc6,0x44,0x24,0x08,0x00,0xc6,0x44,0x24,0x09,0x00,0x88,0x44,0x24,0x08,0xc6,0x44,0x24,0x09,0x03,0x48,0x0f,0xbf,0x4c,0x24,0x08,0x66,0x89,0x4c,0x24,0x20,0xc6,0x04,0x24,0x00,0xc6,0x44,0x24,0x01,0x00,0xc6,0x04,0x24,0x00,0xc6,0x44,0x24,0x01,0x06,0x48,0x0f,0xbf,0x0c,0x24,0x66,0x89,0x4c,0x24,0x18,0x8b,0x4c,0x24,0x28,0x0f,0xb6,0xc1,0x8b,0x4c,0x24,0x29,0x0f,0xb6,0xc9,0xd3,0xe0,0x0f,0xb6,0xc0,0x8b,0x4c,0x24,0x20,0x0f,0xb6,0xd1,0x8b,0x4c,0x24,0x21,0x0f,0xb6,0xc9,0xd3,0xe2,0x0f,0xb6,0xca,0x0b,0xc1,0x0f,0xb6,0xc0,0x8b,0x4c,0x24,0x18,0x0f,0xb6,0xd1,0x8b,0x4c,0x24,0x19,0x0f,0xb6,0xc9,0xd3,0xe2,0x0f,0xb6,0xd2,0x0b,0xd0,0x0f,0xb6,0xc2,0x88,0x44,0x24,0x30,0x8b,0x44,0x24,0x30,0x41,0x88,0x00,0x41,0xc6,0x40,0x01,0xb6,0x41,0xc6,0x40,0x02,0x0f,0x41,0xc6,0x40,0x03,0x66,0xb8,0x05,0x00,0x00,0x00,0x48,0x83,0xc4,0x48,0xc3};

        public static ReadOnlySpan<byte> jccヽgᐸ8uᐳᐤ8uㆍtext7ㆍNativeSizeᐤ  =>  new byte[68]{0x48,0x83,0xec,0x18,0x90,0x33,0xc0,0x4c,0x8d,0x54,0x24,0x08,0x49,0x89,0x02,0x66,0x41,0x89,0x42,0x08,0x48,0x8d,0x44,0x24,0x09,0x4c,0x89,0x00,0x48,0x8d,0x44,0x24,0x11,0x44,0x88,0x08,0x0f,0xb6,0xc2,0x88,0x44,0x24,0x08,0x48,0x8b,0x44,0x24,0x08,0x48,0x89,0x01,0x66,0x8b,0x44,0x24,0x10,0x66,0x89,0x41,0x08,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> jccヽgᐸ16uᐳᐤ16uㆍtext7ㆍNativeSizeᐤ  =>  new byte[80]{0x48,0x83,0xec,0x18,0x90,0x33,0xc0,0x4c,0x8d,0x54,0x24,0x08,0x49,0x89,0x02,0x66,0x41,0x89,0x42,0x08,0x41,0x88,0x42,0x0a,0x48,0x8d,0x44,0x24,0x0a,0x4c,0x89,0x00,0x48,0x8d,0x44,0x24,0x12,0x44,0x88,0x08,0x0f,0xb7,0xc2,0x66,0x89,0x44,0x24,0x08,0x48,0x8b,0x44,0x24,0x08,0x48,0x89,0x01,0x66,0x8b,0x44,0x24,0x10,0x66,0x89,0x41,0x08,0x8a,0x44,0x24,0x12,0x88,0x41,0x0a,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> jccヽgᐸ32uᐳᐤ32uㆍtext7ㆍNativeSizeᐤ  =>  new byte[73]{0x48,0x83,0xec,0x18,0x90,0x33,0xc0,0x4c,0x8d,0x54,0x24,0x08,0x49,0x89,0x02,0x41,0x89,0x42,0x08,0x41,0x88,0x42,0x0c,0x48,0x8d,0x44,0x24,0x0c,0x4c,0x89,0x00,0x48,0x8d,0x44,0x24,0x14,0x44,0x88,0x08,0x89,0x54,0x24,0x08,0x48,0x8b,0x44,0x24,0x08,0x48,0x89,0x01,0x8b,0x44,0x24,0x10,0x89,0x41,0x08,0x8a,0x44,0x24,0x14,0x88,0x41,0x0c,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> jccヽgᐸ64uᐳᐤ64uㆍtext7ㆍNativeSizeᐤ  =>  new byte[20]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x89,0x11,0x4c,0x89,0x41,0x08,0x44,0x88,0x49,0x10,0x48,0x8b,0xc1,0xc3};

    }
}