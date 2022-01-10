﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2022-01-07 15:36:31 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class lib_relativeaddress
    {
        public static ReadOnlySpan<byte> defineヽᐤMemoryAddressㆍ64uᐤ  =>  new byte[16]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x89,0x11,0x4c,0x89,0x41,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> formatヽᐤRelativeAddressᐤ  =>  new byte[47]{0x48,0x83,0xec,0x28,0x90,0x48,0x8b,0x49,0x08,0xba,0x04,0x00,0x00,0x00,0xb8,0x01,0x00,0x00,0x00,0x4c,0x8d,0x44,0x24,0x20,0x41,0x88,0x00,0x41,0x89,0x50,0x04,0x48,0x8b,0x54,0x24,0x20,0xe8,0x87,0xcf,0xbb,0xfe,0x90,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> defineヽgᐸ8uᐳᐤMemoryAddressㆍ8uᐤ  =>  new byte[19]{0x0f,0x1f,0x44,0x00,0x00,0x41,0x0f,0xb6,0xc0,0x48,0x89,0x11,0x88,0x41,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> defineヽgᐸ16uᐳᐤMemoryAddressㆍ16uᐤ  =>  new byte[20]{0x0f,0x1f,0x44,0x00,0x00,0x41,0x0f,0xb7,0xc0,0x48,0x89,0x11,0x66,0x89,0x41,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> defineヽgᐸ32uᐳᐤMemoryAddressㆍ32uᐤ  =>  new byte[16]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x89,0x11,0x44,0x89,0x41,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> defineヽgᐸ64uᐳᐤMemoryAddressㆍ64uᐤ  =>  new byte[16]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x89,0x11,0x4c,0x89,0x41,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> formatヽgᐸ8uᐳᐤRelativeAddressᐸbyteᐳᐤ  =>  new byte[171]{0x57,0x56,0x53,0x48,0x83,0xec,0x50,0x48,0x8b,0xf1,0x48,0x8d,0x7c,0x24,0x20,0xb9,0x0c,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x48,0x8b,0x31,0x40,0x0f,0xb6,0x79,0x08,0x48,0xb9,0x30,0x62,0x33,0x65,0xfb,0x7f,0x00,0x00,0xe8,0x3e,0x61,0x9f,0x5b,0x48,0x8b,0xd8,0x48,0x89,0x73,0x08,0x40,0x0f,0xb6,0xcf,0x89,0x4c,0x24,0x4c,0x33,0xc9,0x33,0xd2,0x0f,0xb6,0x44,0x24,0x4c,0x4c,0x8d,0x44,0x24,0x40,0x41,0x88,0x08,0x41,0x89,0x50,0x04,0x8b,0xc8,0x48,0x8b,0x54,0x24,0x40,0xe8,0xbe,0x40,0xf7,0xff,0x45,0x33,0xc0,0x48,0xba,0x90,0x13,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0xb9,0x58,0xd4,0x39,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x09,0x4c,0x8d,0x4c,0x24,0x20,0x49,0x89,0x19,0x49,0x89,0x41,0x08,0x4d,0x89,0x41,0x10,0x49,0x89,0x51,0x18,0x4c,0x8d,0x44,0x24,0x20,0x48,0x8b,0xd1,0x33,0xc9,0xe8,0x2e,0x4b,0x91,0x57,0x90,0x48,0x83,0xc4,0x50,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> formatヽgᐸ16uᐳᐤRelativeAddressᐸushortᐳᐤ  =>  new byte[169]{0x57,0x56,0x53,0x48,0x83,0xec,0x50,0x48,0x8b,0xf1,0x48,0x8d,0x7c,0x24,0x20,0xb9,0x0c,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x48,0x8b,0x31,0x0f,0xb7,0x79,0x08,0x48,0xb9,0x30,0x62,0x33,0x65,0xfb,0x7f,0x00,0x00,0xe8,0x6f,0x60,0x9f,0x5b,0x48,0x8b,0xd8,0x48,0x89,0x73,0x08,0x0f,0xb7,0xcf,0x89,0x4c,0x24,0x4c,0x33,0xc9,0x33,0xd2,0x0f,0xb7,0x44,0x24,0x4c,0x4c,0x8d,0x44,0x24,0x40,0x41,0x88,0x08,0x41,0x89,0x50,0x04,0x8b,0xc8,0x48,0x8b,0x54,0x24,0x40,0xe8,0xa0,0x02,0xbc,0xfe,0x45,0x33,0xc0,0x48,0xba,0x90,0x13,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0xb9,0x58,0xd4,0x39,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x09,0x4c,0x8d,0x4c,0x24,0x20,0x49,0x89,0x19,0x49,0x89,0x41,0x08,0x4d,0x89,0x41,0x10,0x49,0x89,0x51,0x18,0x4c,0x8d,0x44,0x24,0x20,0x48,0x8b,0xd1,0x33,0xc9,0xe8,0x60,0x4a,0x91,0x57,0x90,0x48,0x83,0xc4,0x50,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> formatヽgᐸ32uᐳᐤRelativeAddressᐸuintᐳᐤ  =>  new byte[164]{0x57,0x56,0x53,0x48,0x83,0xec,0x50,0x48,0x8b,0xf1,0x48,0x8d,0x7c,0x24,0x20,0xb9,0x0c,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x48,0x8b,0x31,0x8b,0x79,0x08,0x48,0xb9,0x30,0x62,0x33,0x65,0xfb,0x7f,0x00,0x00,0xe8,0xa0,0x5f,0x9f,0x5b,0x48,0x8b,0xd8,0x48,0x89,0x73,0x08,0x89,0x7c,0x24,0x4c,0x33,0xc9,0x33,0xd2,0x8b,0x44,0x24,0x4c,0x4c,0x8d,0x44,0x24,0x40,0x41,0x88,0x08,0x41,0x89,0x50,0x04,0x8b,0xc8,0x48,0x8b,0x54,0x24,0x40,0xe8,0xc5,0x41,0xf7,0xff,0x45,0x33,0xc0,0x48,0xba,0x90,0x13,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0xb9,0x58,0xd4,0x39,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x09,0x4c,0x8d,0x4c,0x24,0x20,0x49,0x89,0x19,0x49,0x89,0x41,0x08,0x4d,0x89,0x41,0x10,0x49,0x89,0x51,0x18,0x4c,0x8d,0x44,0x24,0x20,0x48,0x8b,0xd1,0x33,0xc9,0xe8,0x95,0x49,0x91,0x57,0x90,0x48,0x83,0xc4,0x50,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> formatヽgᐸ64uᐳᐤRelativeAddressᐸulongᐳᐤ  =>  new byte[170]{0x57,0x56,0x53,0x48,0x83,0xec,0x50,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x48,0x89,0x44,0x24,0x38,0x48,0x8b,0x31,0x48,0x8b,0x79,0x08,0x48,0xb9,0x30,0x62,0x33,0x65,0xfb,0x7f,0x00,0x00,0xe8,0xdd,0x5e,0x9f,0x5b,0x48,0x8b,0xd8,0x48,0x89,0x73,0x08,0x48,0x89,0x7c,0x24,0x48,0x33,0xc9,0x33,0xd2,0x48,0x8b,0x44,0x24,0x48,0x4c,0x8d,0x44,0x24,0x40,0x41,0x88,0x08,0x41,0x89,0x50,0x04,0x48,0x8b,0xc8,0x48,0x8b,0x54,0x24,0x40,0xe8,0xff,0xc7,0xbb,0xfe,0x45,0x33,0xc0,0x48,0xba,0x90,0x13,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0xb9,0x58,0xd4,0x39,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x09,0x4c,0x8d,0x4c,0x24,0x20,0x49,0x89,0x19,0x49,0x89,0x41,0x08,0x4d,0x89,0x41,0x10,0x49,0x89,0x51,0x18,0x4c,0x8d,0x44,0x24,0x20,0x48,0x8b,0xd1,0x33,0xc9,0xe8,0xcf,0x48,0x91,0x57,0x90,0x48,0x83,0xc4,0x50,0x5b,0x5e,0x5f,0xc3};

    }
}