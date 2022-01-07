﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2022-01-06 21:17:28 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class lib_jsondata
    {
        public static ReadOnlySpan<byte> settingヽᐤstringㆍstringᐤ  =>  new byte[37]{0x57,0x56,0x0f,0x1f,0x00,0x48,0x8b,0xf1,0x49,0x8b,0xf8,0x48,0x8b,0xce,0xe8,0xfd,0xb4,0xac,0x5b,0x48,0x8d,0x4e,0x08,0x48,0x8b,0xd7,0xe8,0xf1,0xb4,0xac,0x5b,0x48,0x8b,0xc6,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> jsonヽᐤstringᐤ  =>  new byte[9]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> packetヽgᐸ64uᐳᐤ64uᐤ  =>  new byte[65]{0x57,0x56,0x48,0x83,0xec,0x28,0x48,0x8b,0xf1,0x48,0x8b,0xfa,0x48,0xb9,0x80,0xa6,0x12,0x65,0xfb,0x7f,0x00,0x00,0xe8,0x05,0x01,0xa6,0x5b,0x48,0x8b,0xc8,0xba,0x02,0x00,0x00,0x00,0xe8,0xc8,0x21,0x9e,0x57,0x48,0x8b,0xce,0x48,0x8b,0xd0,0xe8,0x7d,0xb4,0xac,0x5b,0x48,0x89,0x7e,0x08,0x48,0x8b,0xc6,0x48,0x83,0xc4,0x28,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> settingヽgᐸ64uᐳᐤstringㆍ64uᐤ  =>  new byte[29]{0x57,0x56,0x0f,0x1f,0x00,0x48,0x8b,0xf1,0x49,0x8b,0xf8,0x48,0x8b,0xce,0xe8,0x3d,0xb4,0xac,0x5b,0x48,0x89,0x7e,0x08,0x48,0x8b,0xc6,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> serializeヽgᐸ64uᐳᐤ64uㆍboolᐤ  =>  new byte[73]{0x57,0x56,0x53,0x48,0x83,0xec,0x20,0x48,0x8b,0xf1,0x8b,0xfa,0x48,0xb9,0x90,0x70,0x50,0x69,0xfb,0x7f,0x00,0x00,0xe8,0x55,0xbd,0xac,0x5b,0x48,0x8b,0xd8,0x48,0x8b,0xcb,0xe8,0x42,0xfa,0xff,0xff,0x80,0x7b,0x56,0x00,0x74,0x05,0xe8,0x57,0xff,0xff,0xff,0x40,0x88,0x7b,0x5a,0x48,0x8b,0xce,0x48,0x8b,0xd3,0xe8,0x70,0xdb,0xff,0xff,0x90,0x48,0x83,0xc4,0x20,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> serializeヽgᐸ64uᐳᐤ64uㆍFilePathㆍboolᐤ  =>  new byte[245]{0x55,0x41,0x56,0x57,0x56,0x53,0x48,0x83,0xec,0x40,0x48,0x8d,0x6c,0x24,0x60,0x48,0x89,0x65,0xc8,0x48,0x8b,0xf2,0x41,0x0f,0xb6,0xd0,0xe8,0x71,0xff,0xff,0xff,0x48,0x8b,0xf8,0x48,0x8b,0xce,0x48,0xb8,0x20,0x18,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x30,0xe8,0x69,0x11,0xc3,0xfe,0x48,0x8b,0xd8,0x48,0x85,0xdb,0x75,0x0d,0x48,0xb9,0x60,0x30,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x19,0x8b,0x0b,0x48,0xb9,0x90,0xda,0x9a,0x66,0xfb,0x7f,0x00,0x00,0xe8,0xa3,0xbc,0xac,0x5b,0x4c,0x8b,0xf0,0x48,0x8b,0xcb,0xba,0x02,0x00,0x00,0x00,0xe8,0x13,0xd0,0xa1,0x57,0x48,0x8b,0xc8,0x4c,0x8b,0xc6,0x33,0xd2,0x41,0xb9,0x00,0x04,0x00,0x00,0xe8,0x10,0x59,0x9f,0x57,0x48,0x8b,0xd0,0x33,0xc9,0x89,0x4c,0x24,0x20,0x49,0x8b,0xce,0x4c,0x8b,0xc6,0x41,0xb9,0x00,0x04,0x00,0x00,0xe8,0xf6,0xae,0x9d,0x57,0x4c,0x89,0x75,0xd8,0x48,0x8b,0x4d,0xd8,0x48,0x8b,0xd7,0xe8,0xd6,0x36,0x9f,0x57,0x90,0x48,0x8b,0x4d,0xd8,0xe8,0xcc,0x3f,0xa3,0x57,0x48,0x8b,0xc7,0x48,0x8d,0x65,0xe0,0x5b,0x5e,0x5f,0x41,0x5e,0x5d,0xc3,0x55,0x41,0x56,0x57,0x56,0x53,0x48,0x83,0xec,0x30,0x48,0x8b,0x69,0x28,0x48,0x89,0x6c,0x24,0x28,0x48,0x8d,0x6d,0x60,0x48,0x83,0x7d,0xd8,0x00,0x74,0x09,0x48,0x8b,0x4d,0xd8,0xe8,0x97,0x3f,0xa3,0x57,0x90,0x48,0x83,0xc4,0x30,0x5b,0x5e,0x5f,0x41,0x5e,0x5d,0xc3};

        public static ReadOnlySpan<byte> materializeヽgᐸ64uᐳᐤJsonTextᐤ  =>  new byte[42]{0x48,0x83,0xec,0x38,0x33,0xc0,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x48,0x8b,0xd1,0x48,0x8d,0x4c,0x24,0x28,0x45,0x33,0xc0,0xe8,0x40,0xd6,0xff,0xff,0x48,0x8b,0x44,0x24,0x30,0x48,0x83,0xc4,0x38,0xc3};

        public static ReadOnlySpan<byte> materializeヽgᐸ64uᐳᐤFilePathᐤ  =>  new byte[166]{0x55,0x56,0x48,0x83,0xec,0x38,0x48,0x8d,0x6c,0x24,0x40,0x48,0x89,0x65,0xe0,0x48,0xba,0x20,0x18,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0xe8,0xaf,0x75,0xf9,0xfb,0x48,0x89,0x45,0xf0,0x48,0x8b,0x4d,0xf0,0x48,0x8b,0x45,0xf0,0x48,0x8b,0x00,0x48,0x8b,0x40,0x48,0xff,0x50,0x20,0x48,0x8b,0xc8,0xe8,0x81,0xff,0xff,0xff,0x48,0x8b,0xf0,0x48,0x8b,0x4d,0xf0,0x49,0xbb,0xa0,0x18,0x03,0x65,0xfb,0x7f,0x00,0x00,0x48,0xb8,0xa0,0x18,0x03,0x65,0xfb,0x7f,0x00,0x00,0x39,0x09,0xff,0x10,0x48,0x8b,0xc6,0x48,0x8d,0x65,0xf8,0x5e,0x5d,0xc3,0x55,0x56,0x48,0x83,0xec,0x28,0x48,0x8b,0x69,0x20,0x48,0x89,0x6c,0x24,0x20,0x48,0x8d,0x6d,0x40,0x48,0x83,0x7d,0xf0,0x00,0x74,0x1c,0x48,0x8b,0x4d,0xf0,0x49,0xbb,0xa0,0x18,0x03,0x65,0xfb,0x7f,0x00,0x00,0x48,0xb8,0xa0,0x18,0x03,0x65,0xfb,0x7f,0x00,0x00,0x39,0x09,0xff,0x10,0x90,0x48,0x83,0xc4,0x28,0x5e,0x5d,0xc3};

        public static ReadOnlySpan<byte> jsonヽgᐸ8uᐳᐤarray_8uᐤ  =>  new byte[9]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> jsonヽgᐸ8iᐳᐤarray_8iᐤ  =>  new byte[9]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> jsonヽgᐸ16uᐳᐤarray_16uᐤ  =>  new byte[9]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> jsonヽgᐸ16iᐳᐤarray_16iᐤ  =>  new byte[9]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> jtextヽgᐸ64uᐳᐤJsonᐸulongᐳᕀinᐤ  =>  new byte[50]{0x48,0x83,0xec,0x28,0x90,0x48,0x8b,0x09,0x48,0x85,0xc9,0x75,0x04,0x33,0xc0,0xeb,0x0a,0x48,0x8b,0x01,0x48,0x8b,0x40,0x40,0xff,0x50,0x08,0x48,0x85,0xc0,0x75,0x0d,0x48,0xb8,0x60,0x30,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x00,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> formatヽgᐸ64uᐳᐤJsonᐸulongᐳᕀinᐤ  =>  new byte[50]{0x48,0x83,0xec,0x28,0x90,0x48,0x8b,0x09,0x48,0x85,0xc9,0x75,0x04,0x33,0xc0,0xeb,0x0a,0x48,0x8b,0x01,0x48,0x8b,0x40,0x40,0xff,0x50,0x08,0x48,0x85,0xc0,0x75,0x0d,0x48,0xb8,0x60,0x30,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x00,0x48,0x83,0xc4,0x28,0xc3};

    }
}
