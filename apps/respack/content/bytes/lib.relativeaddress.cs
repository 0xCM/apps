﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2021-11-14 3:49:57 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class lib_relativeaddress
    {
        public static ReadOnlySpan<byte> defineヽᐤMemoryAddressㆍ64uᐤ  =>  new byte[16]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x89,0x11,0x4c,0x89,0x41,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> formatヽᐤRelativeAddressᐤ  =>  new byte[47]{0x48,0x83,0xec,0x28,0x90,0x48,0x8b,0x49,0x08,0xba,0x04,0x00,0x00,0x00,0xb8,0x01,0x00,0x00,0x00,0x4c,0x8d,0x44,0x24,0x20,0x41,0x88,0x00,0x41,0x89,0x50,0x04,0x48,0x8b,0x54,0x24,0x20,0xe8,0x97,0x09,0xcd,0xfe,0x90,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> defineヽgᐸ8uᐳᐤMemoryAddressㆍ8uᐤ  =>  new byte[19]{0x0f,0x1f,0x44,0x00,0x00,0x41,0x0f,0xb6,0xc0,0x48,0x89,0x11,0x88,0x41,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> defineヽgᐸ16uᐳᐤMemoryAddressㆍ16uᐤ  =>  new byte[20]{0x0f,0x1f,0x44,0x00,0x00,0x41,0x0f,0xb7,0xc0,0x48,0x89,0x11,0x66,0x89,0x41,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> defineヽgᐸ32uᐳᐤMemoryAddressㆍ32uᐤ  =>  new byte[16]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x89,0x11,0x44,0x89,0x41,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> defineヽgᐸ64uᐳᐤMemoryAddressㆍ64uᐤ  =>  new byte[16]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x89,0x11,0x4c,0x89,0x41,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> formatヽgᐸ8uᐳᐤRelativeAddressᐸbyteᐳᐤ  =>  new byte[171]{0x57,0x56,0x53,0x48,0x83,0xec,0x50,0x48,0x8b,0xf1,0x48,0x8d,0x7c,0x24,0x20,0xb9,0x0c,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x48,0x8b,0x31,0x40,0x0f,0xb6,0x79,0x08,0x48,0xb9,0xc0,0x33,0xcf,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0x6e,0xda,0xa0,0x5b,0x48,0x8b,0xd8,0x48,0x89,0x73,0x08,0x40,0x0f,0xb6,0xcf,0x89,0x4c,0x24,0x4c,0x33,0xc9,0x33,0xd2,0x0f,0xb6,0x44,0x24,0x4c,0x4c,0x8d,0x44,0x24,0x40,0x41,0x88,0x08,0x41,0x89,0x50,0x04,0x8b,0xc8,0x48,0x8b,0x54,0x24,0x40,0xe8,0x5e,0x04,0x51,0xfd,0x45,0x33,0xc0,0x48,0xba,0x90,0x13,0xb6,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0xb9,0x88,0x39,0xc1,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x09,0x4c,0x8d,0x4c,0x24,0x20,0x49,0x89,0x19,0x49,0x89,0x41,0x08,0x4d,0x89,0x41,0x10,0x49,0x89,0x51,0x18,0x4c,0x8d,0x44,0x24,0x20,0x48,0x8b,0xd1,0x33,0xc9,0xe8,0x5e,0xc4,0x35,0x5b,0x90,0x48,0x83,0xc4,0x50,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> formatヽgᐸ16uᐳᐤRelativeAddressᐸushortᐳᐤ  =>  new byte[169]{0x57,0x56,0x53,0x48,0x83,0xec,0x50,0x48,0x8b,0xf1,0x48,0x8d,0x7c,0x24,0x20,0xb9,0x0c,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x48,0x8b,0x31,0x0f,0xb7,0x79,0x08,0x48,0xb9,0xc0,0x33,0xcf,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0x9f,0xd9,0xa0,0x5b,0x48,0x8b,0xd8,0x48,0x89,0x73,0x08,0x0f,0xb7,0xcf,0x89,0x4c,0x24,0x4c,0x33,0xc9,0x33,0xd2,0x0f,0xb7,0x44,0x24,0x4c,0x4c,0x8d,0x44,0x24,0x40,0x41,0x88,0x08,0x41,0x89,0x50,0x04,0x8b,0xc8,0x48,0x8b,0x54,0x24,0x40,0xe8,0xf0,0x91,0xcc,0xfe,0x45,0x33,0xc0,0x48,0xba,0x90,0x13,0xb6,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0xb9,0x88,0x39,0xc1,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x09,0x4c,0x8d,0x4c,0x24,0x20,0x49,0x89,0x19,0x49,0x89,0x41,0x08,0x4d,0x89,0x41,0x10,0x49,0x89,0x51,0x18,0x4c,0x8d,0x44,0x24,0x20,0x48,0x8b,0xd1,0x33,0xc9,0xe8,0x90,0xc3,0x35,0x5b,0x90,0x48,0x83,0xc4,0x50,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> formatヽgᐸ32uᐳᐤRelativeAddressᐸuintᐳᐤ  =>  new byte[164]{0x57,0x56,0x53,0x48,0x83,0xec,0x50,0x48,0x8b,0xf1,0x48,0x8d,0x7c,0x24,0x20,0xb9,0x0c,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x48,0x8b,0x31,0x8b,0x79,0x08,0x48,0xb9,0xc0,0x33,0xcf,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0xd0,0xd8,0xa0,0x5b,0x48,0x8b,0xd8,0x48,0x89,0x73,0x08,0x89,0x7c,0x24,0x4c,0x33,0xc9,0x33,0xd2,0x8b,0x44,0x24,0x4c,0x4c,0x8d,0x44,0x24,0x40,0x41,0x88,0x08,0x41,0x89,0x50,0x04,0x8b,0xc8,0x48,0x8b,0x54,0x24,0x40,0xe8,0xe5,0x02,0x51,0xfd,0x45,0x33,0xc0,0x48,0xba,0x90,0x13,0xb6,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0xb9,0x88,0x39,0xc1,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x09,0x4c,0x8d,0x4c,0x24,0x20,0x49,0x89,0x19,0x49,0x89,0x41,0x08,0x4d,0x89,0x41,0x10,0x49,0x89,0x51,0x18,0x4c,0x8d,0x44,0x24,0x20,0x48,0x8b,0xd1,0x33,0xc9,0xe8,0xc5,0xc2,0x35,0x5b,0x90,0x48,0x83,0xc4,0x50,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> formatヽgᐸ64uᐳᐤRelativeAddressᐸulongᐳᐤ  =>  new byte[170]{0x57,0x56,0x53,0x48,0x83,0xec,0x50,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x48,0x89,0x44,0x24,0x38,0x48,0x8b,0x31,0x48,0x8b,0x79,0x08,0x48,0xb9,0xc0,0x33,0xcf,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0x0d,0xd8,0xa0,0x5b,0x48,0x8b,0xd8,0x48,0x89,0x73,0x08,0x48,0x89,0x7c,0x24,0x48,0x33,0xc9,0x33,0xd2,0x48,0x8b,0x44,0x24,0x48,0x4c,0x8d,0x44,0x24,0x40,0x41,0x88,0x08,0x41,0x89,0x50,0x04,0x48,0x8b,0xc8,0x48,0x8b,0x54,0x24,0x40,0xe8,0xff,0x01,0xcd,0xfe,0x45,0x33,0xc0,0x48,0xba,0x90,0x13,0xb6,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0xb9,0x88,0x39,0xc1,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x09,0x4c,0x8d,0x4c,0x24,0x20,0x49,0x89,0x19,0x49,0x89,0x41,0x08,0x4d,0x89,0x41,0x10,0x49,0x89,0x51,0x18,0x4c,0x8d,0x44,0x24,0x20,0x48,0x8b,0xd1,0x33,0xc9,0xe8,0xff,0xc1,0x35,0x5b,0x90,0x48,0x83,0xc4,0x50,0x5b,0x5e,0x5f,0xc3};

    }
}