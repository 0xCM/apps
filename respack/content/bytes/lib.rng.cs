﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2021-11-14 3:49:57 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class lib_rng
    {
        public static ReadOnlySpan<byte> entropyヽᐤByteSizeᐤ  =>  new byte[16]{0x48,0x83,0xec,0x28,0x90,0xe8,0x26,0xa2,0x5e,0xfd,0x90,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> entropyヽᐤspan8uᐤ  =>  new byte[16]{0x48,0x83,0xec,0x28,0x90,0xe8,0xfe,0xa1,0x5e,0xfd,0x90,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> defaultヽᐤᐤ  =>  new byte[180]{0x57,0x56,0x53,0x48,0x83,0xec,0x30,0xb9,0x05,0x00,0x00,0x00,0xc1,0xe1,0x03,0x48,0x63,0xc9,0x48,0xba,0x88,0xc8,0x66,0x4e,0x59,0x02,0x00,0x00,0x48,0x03,0xca,0x48,0x8b,0x11,0x33,0xc9,0x48,0x89,0x4c,0x24,0x20,0x48,0x89,0x4c,0x24,0x28,0x48,0x89,0x4c,0x24,0x20,0x48,0x89,0x4c,0x24,0x28,0x48,0x8d,0x4c,0x24,0x20,0x49,0xb8,0x4f,0x81,0x67,0xf7,0x7e,0x7b,0x05,0x14,0xe8,0xdc,0xa6,0x5e,0xfd,0x48,0xb9,0xa0,0x50,0x4b,0x81,0xfe,0x7f,0x00,0x00,0xe8,0xd5,0x74,0x8c,0x5b,0x48,0x8b,0xf0,0x48,0x8d,0x4e,0x08,0x48,0x8b,0x44,0x24,0x20,0x48,0x89,0x01,0x48,0x8b,0x44,0x24,0x28,0x48,0x89,0x41,0x08,0x48,0xb9,0xe0,0x27,0x4b,0x81,0xfe,0x7f,0x00,0x00,0xe8,0xae,0x74,0x8c,0x5b,0x48,0x8b,0xf8,0x48,0x8d,0x4f,0x08,0x48,0x8b,0xd6,0xe8,0xdf,0x65,0x8c,0x5b,0x48,0x8b,0xd6,0xbe,0x01,0x00,0x00,0x00,0x48,0x8d,0x5f,0x10,0x48,0x8d,0x0b,0xe8,0x9b,0x65,0x8c,0x5b,0x40,0x88,0x73,0x08,0x48,0x8b,0xc7,0x48,0x83,0xc4,0x30,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> defaultヽᐤ64uᐤ  =>  new byte[166]{0x57,0x56,0x53,0x48,0x83,0xec,0x40,0x33,0xd2,0x48,0x89,0x54,0x24,0x30,0x48,0x89,0x54,0x24,0x38,0x48,0x89,0x54,0x24,0x30,0x48,0x89,0x54,0x24,0x38,0x48,0x8d,0x54,0x24,0x30,0x48,0x89,0x4c,0x24,0x28,0x49,0xb8,0x4f,0x81,0x67,0xf7,0x7e,0x7b,0x05,0x14,0x48,0x8b,0xca,0x48,0x8b,0x54,0x24,0x28,0xe8,0x1a,0xa6,0x5e,0xfd,0x48,0xb9,0xa0,0x50,0x4b,0x81,0xfe,0x7f,0x00,0x00,0xe8,0x13,0x74,0x8c,0x5b,0x48,0x8b,0xf0,0x48,0x8d,0x4e,0x08,0x48,0x8b,0x44,0x24,0x30,0x48,0x89,0x01,0x48,0x8b,0x44,0x24,0x38,0x48,0x89,0x41,0x08,0x48,0xb9,0xe0,0x27,0x4b,0x81,0xfe,0x7f,0x00,0x00,0xe8,0xec,0x73,0x8c,0x5b,0x48,0x8b,0xf8,0x48,0x8d,0x4f,0x08,0x48,0x8b,0xd6,0xe8,0x1d,0x65,0x8c,0x5b,0x48,0x8b,0xd6,0xbe,0x01,0x00,0x00,0x00,0x48,0x8d,0x5f,0x10,0x48,0x8d,0x0b,0xe8,0xd9,0x64,0x8c,0x5b,0x40,0x88,0x73,0x08,0x48,0x8b,0xc7,0x48,0x83,0xc4,0x40,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> pcg32ヽᐤ64uㆍ64uᐤ  =>  new byte[149]{0x57,0x56,0x48,0x83,0xec,0x38,0xc5,0xf8,0x77,0x45,0x33,0xc0,0x4c,0x89,0x44,0x24,0x28,0x4c,0x89,0x44,0x24,0x30,0x4c,0x89,0x44,0x24,0x28,0x4c,0x89,0x44,0x24,0x30,0x4c,0x8b,0xc2,0x48,0x8d,0x54,0x24,0x28,0x48,0x89,0x4c,0x24,0x20,0x48,0x8b,0xca,0x48,0x8b,0x54,0x24,0x20,0xe8,0x9e,0xa4,0x5e,0xfd,0x48,0xb9,0xb0,0x4c,0x4b,0x81,0xfe,0x7f,0x00,0x00,0xe8,0x57,0x73,0x8c,0x5b,0x48,0x8b,0xf0,0x48,0x8d,0x4e,0x08,0x48,0x8b,0x44,0x24,0x28,0x48,0x89,0x01,0x48,0x8b,0x44,0x24,0x30,0x48,0x89,0x41,0x08,0x48,0xb9,0xe0,0x27,0x4b,0x81,0xfe,0x7f,0x00,0x00,0xe8,0x30,0x73,0x8c,0x5b,0x48,0x8b,0xf8,0x48,0x8d,0x4f,0x08,0x48,0x8b,0xd6,0xe8,0x61,0x64,0x8c,0x5b,0x48,0x8d,0x47,0x10,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x00,0x48,0x8b,0xc7,0x48,0x83,0xc4,0x38,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> pcg64ヽᐤᐤ  =>  new byte[177]{0x57,0x56,0x53,0x48,0x83,0xec,0x30,0x33,0xc9,0xc1,0xe1,0x03,0x48,0x63,0xc9,0x48,0xba,0x88,0xc8,0x66,0x4e,0x59,0x02,0x00,0x00,0x48,0x03,0xca,0x48,0x8b,0x11,0x33,0xc9,0x48,0x89,0x4c,0x24,0x20,0x48,0x89,0x4c,0x24,0x28,0x48,0x89,0x4c,0x24,0x20,0x48,0x89,0x4c,0x24,0x28,0x48,0x8d,0x4c,0x24,0x20,0x49,0xb8,0x4f,0x81,0x67,0xf7,0x7e,0x7b,0x05,0x14,0xe8,0x9f,0xa4,0x5e,0xfd,0x48,0xb9,0xa0,0x50,0x4b,0x81,0xfe,0x7f,0x00,0x00,0xe8,0x98,0x72,0x8c,0x5b,0x48,0x8b,0xf0,0x48,0x8d,0x4e,0x08,0x48,0x8b,0x44,0x24,0x20,0x48,0x89,0x01,0x48,0x8b,0x44,0x24,0x28,0x48,0x89,0x41,0x08,0x48,0xb9,0xe0,0x27,0x4b,0x81,0xfe,0x7f,0x00,0x00,0xe8,0x71,0x72,0x8c,0x5b,0x48,0x8b,0xf8,0x48,0x8d,0x4f,0x08,0x48,0x8b,0xd6,0xe8,0xa2,0x63,0x8c,0x5b,0x48,0x8b,0xd6,0xbe,0x01,0x00,0x00,0x00,0x48,0x8d,0x5f,0x10,0x48,0x8d,0x0b,0xe8,0x5e,0x63,0x8c,0x5b,0x40,0x88,0x73,0x08,0x48,0x8b,0xc7,0x48,0x83,0xc4,0x30,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> pcg64ヽᐤ64uㆍulongᐤ  =>  new byte[180]{0x57,0x56,0x53,0x48,0x83,0xec,0x30,0x44,0x0f,0xb6,0x02,0x48,0x8b,0x52,0x08,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x48,0x8d,0x44,0x24,0x20,0x45,0x84,0xc0,0x75,0x0f,0x48,0x8b,0xd1,0x49,0xb8,0x4f,0x81,0x67,0xf7,0x7e,0x7b,0x05,0x14,0xeb,0x06,0x4c,0x8b,0xc2,0x48,0x8b,0xd1,0x48,0x8b,0xc8,0xe8,0xcc,0xa3,0x5e,0xfd,0x48,0xb9,0xa0,0x50,0x4b,0x81,0xfe,0x7f,0x00,0x00,0xe8,0xc5,0x71,0x8c,0x5b,0x48,0x8b,0xf0,0x48,0x8d,0x4e,0x08,0x48,0x8b,0x44,0x24,0x20,0x48,0x89,0x01,0x48,0x8b,0x44,0x24,0x28,0x48,0x89,0x41,0x08,0x48,0xb9,0xe0,0x27,0x4b,0x81,0xfe,0x7f,0x00,0x00,0xe8,0x9e,0x71,0x8c,0x5b,0x48,0x8b,0xf8,0x48,0x8d,0x4f,0x08,0x48,0x8b,0xd6,0xe8,0xcf,0x62,0x8c,0x5b,0x48,0x8b,0xd6,0xbe,0x01,0x00,0x00,0x00,0x48,0x8d,0x5f,0x10,0x48,0x8d,0x0b,0xe8,0x8b,0x62,0x8c,0x5b,0x40,0x88,0x73,0x08,0x48,0x8b,0xc7,0x48,0x83,0xc4,0x30,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> wyhash16ヽᐤ16uㆍushortᐤ  =>  new byte[72]{0x50,0x0f,0x1f,0x40,0x00,0x48,0x89,0x54,0x24,0x18,0x66,0xc7,0x04,0x24,0x00,0x00,0x66,0xc7,0x44,0x24,0x02,0x00,0x00,0x48,0x8d,0x44,0x24,0x18,0x0f,0xb6,0x10,0x0f,0xb7,0x40,0x02,0x0f,0xb7,0xc9,0x66,0x89,0x0c,0x24,0x48,0x8d,0x0c,0x24,0x84,0xd2,0x75,0x07,0xba,0x15,0xfc,0x00,0x00,0xeb,0x03,0x0f,0xb7,0xd0,0x66,0x89,0x51,0x02,0x8b,0x04,0x24,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> wyhash64ヽᐤulongᐤ  =>  new byte[123]{0x57,0x56,0x48,0x83,0xec,0x28,0xc5,0xf8,0x77,0x0f,0xb6,0x01,0x48,0x8b,0x49,0x08,0x84,0xc0,0x75,0x1a,0x33,0xc9,0xc1,0xe1,0x03,0x48,0x63,0xc9,0x48,0xb8,0x88,0xc8,0x66,0x4e,0x59,0x02,0x00,0x00,0x48,0x03,0xc8,0x48,0x8b,0x31,0xeb,0x03,0x48,0x8b,0xf1,0x48,0xb9,0xc8,0x58,0x4b,0x81,0xfe,0x7f,0x00,0x00,0xe8,0xb0,0x70,0x8c,0x5b,0x48,0x8b,0xf8,0x48,0x89,0x77,0x08,0x48,0xb9,0xe0,0x27,0x4b,0x81,0xfe,0x7f,0x00,0x00,0xe8,0x9a,0x70,0x8c,0x5b,0x48,0x8b,0xf0,0x48,0x8d,0x4e,0x08,0x48,0x8b,0xd7,0xe8,0xcb,0x61,0x8c,0x5b,0x48,0x8d,0x46,0x10,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x00,0x48,0x8b,0xc6,0x48,0x83,0xc4,0x28,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> splitmixヽᐤulongᐤ  =>  new byte[123]{0x57,0x56,0x48,0x83,0xec,0x28,0xc5,0xf8,0x77,0x0f,0xb6,0x01,0x48,0x8b,0x49,0x08,0x84,0xc0,0x75,0x1a,0x33,0xc9,0xc1,0xe1,0x03,0x48,0x63,0xc9,0x48,0xb8,0x88,0xc8,0x66,0x4e,0x59,0x02,0x00,0x00,0x48,0x03,0xc8,0x48,0x8b,0x31,0xeb,0x03,0x48,0x8b,0xf1,0x48,0xb9,0x90,0x53,0x4b,0x81,0xfe,0x7f,0x00,0x00,0xe8,0x10,0x70,0x8c,0x5b,0x48,0x8b,0xf8,0x48,0x89,0x77,0x08,0x48,0xb9,0xe0,0x27,0x4b,0x81,0xfe,0x7f,0x00,0x00,0xe8,0xfa,0x6f,0x8c,0x5b,0x48,0x8b,0xf0,0x48,0x8d,0x4e,0x08,0x48,0x8b,0xd7,0xe8,0x2b,0x61,0x8c,0x5b,0x48,0x8d,0x46,0x10,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x00,0x48,0x8b,0xc6,0x48,0x83,0xc4,0x28,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> xorStars256ヽᐤarray_64uᐤ  =>  new byte[474]{0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x48,0xc5,0xf8,0x77,0x48,0x85,0xc9,0x75,0x21,0x48,0xb9,0xa0,0xd4,0xcb,0x7f,0xfe,0x7f,0x00,0x00,0xba,0xe3,0x09,0x00,0x00,0xe8,0x8c,0x73,0x8c,0x5b,0x48,0xb9,0x88,0x56,0xb6,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x09,0x48,0x85,0xc9,0x75,0x04,0x33,0xd2,0xeb,0x07,0x48,0x8d,0x51,0x10,0x8b,0x49,0x08,0x33,0xc9,0x48,0x89,0x4c,0x24,0x28,0x48,0x89,0x4c,0x24,0x30,0x48,0x89,0x4c,0x24,0x38,0x48,0x89,0x4c,0x24,0x40,0x48,0x8b,0x0a,0x48,0x89,0x4c,0x24,0x28,0x48,0x8b,0x4a,0x08,0x48,0x89,0x4c,0x24,0x30,0x48,0x8b,0x4a,0x10,0x48,0x89,0x4c,0x24,0x38,0x48,0x8b,0x4a,0x18,0x48,0x89,0x4c,0x24,0x40,0x48,0xb9,0xa0,0xd4,0xcb,0x7f,0xfe,0x7f,0x00,0x00,0xba,0xf5,0x09,0x00,0x00,0xe8,0x22,0x73,0x8c,0x5b,0x48,0xb9,0x98,0x56,0xb6,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x09,0x48,0x85,0xc9,0x75,0x06,0x33,0xc0,0x33,0xd2,0xeb,0x07,0x48,0x8d,0x41,0x10,0x8b,0x51,0x08,0x45,0x33,0xc0,0x45,0x33,0xc9,0x45,0x33,0xd2,0x45,0x33,0xdb,0x33,0xf6,0x85,0xd2,0x0f,0x8e,0x94,0x00,0x00,0x00,0x33,0xff,0x48,0x63,0xde,0xbd,0x01,0x00,0x00,0x00,0x8b,0xcf,0x48,0xd3,0xe5,0x48,0x23,0x2c,0xd8,0x48,0x85,0xed,0x74,0x14,0x4c,0x33,0x44,0x24,0x28,0x4c,0x33,0x4c,0x24,0x30,0x4c,0x33,0x54,0x24,0x38,0x4c,0x33,0x5c,0x24,0x40,0x48,0x8b,0x4c,0x24,0x30,0x48,0xc1,0xe1,0x11,0x48,0x8d,0x5c,0x24,0x38,0x48,0x8b,0x6c,0x24,0x28,0x48,0x31,0x2b,0x48,0x8d,0x5c,0x24,0x40,0x48,0x8b,0x6c,0x24,0x30,0x48,0x31,0x2b,0x48,0x8d,0x5c,0x24,0x30,0x48,0x8b,0x6c,0x24,0x38,0x48,0x31,0x2b,0x48,0x8d,0x5c,0x24,0x28,0x48,0x8b,0x6c,0x24,0x40,0x48,0x31,0x2b,0x48,0x8d,0x5c,0x24,0x38,0x48,0x31,0x0b,0x48,0x8b,0x4c,0x24,0x40,0x48,0xc1,0xc1,0x2d,0x48,0x89,0x4c,0x24,0x40,0xff,0xc7,0x83,0xff,0x40,0x0f,0x8c,0x78,0xff,0xff,0xff,0xff,0xc6,0x3b,0xf2,0x0f,0x8c,0x6c,0xff,0xff,0xff,0x4c,0x89,0x44,0x24,0x28,0x4c,0x89,0x4c,0x24,0x30,0x4c,0x89,0x54,0x24,0x38,0x4c,0x89,0x5c,0x24,0x40,0x48,0xb9,0x90,0x5e,0x4b,0x81,0xfe,0x7f,0x00,0x00,0xe8,0x36,0x6e,0x8c,0x5b,0x48,0x8b,0xf0,0x48,0x8d,0x4e,0x08,0x48,0x8b,0x44,0x24,0x28,0x48,0x89,0x01,0x48,0x8b,0x44,0x24,0x30,0x48,0x89,0x41,0x08,0x48,0x8b,0x44,0x24,0x38,0x48,0x89,0x41,0x10,0x48,0x8b,0x44,0x24,0x40,0x48,0x89,0x41,0x18,0x48,0xb9,0xe0,0x27,0x4b,0x81,0xfe,0x7f,0x00,0x00,0xe8,0xfd,0x6d,0x8c,0x5b,0x48,0x8b,0xf8,0x48,0x8d,0x4f,0x08,0x48,0x8b,0xd6,0xe8,0x2e,0x5f,0x8c,0x5b,0x48,0x8d,0x47,0x10,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x00,0x48,0x8b,0xc7,0x48,0x83,0xc4,0x48,0x5b,0x5d,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> xorShift1024ヽᐤarray_64uᐤ  =>  new byte[131]{0x57,0x56,0x48,0x83,0xec,0x28,0xc5,0xf8,0x77,0x48,0x8b,0xf1,0x48,0x85,0xf6,0x75,0x21,0x48,0xb9,0xa0,0xd4,0xcb,0x7f,0xfe,0x7f,0x00,0x00,0xba,0xe2,0x09,0x00,0x00,0xe8,0x8b,0x71,0x8c,0x5b,0x48,0xb9,0x78,0x56,0xb6,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x31,0x48,0xb9,0xf0,0x5a,0x4b,0x81,0xfe,0x7f,0x00,0x00,0xe8,0x6f,0x6d,0x8c,0x5b,0x48,0x8b,0xf8,0x48,0x8b,0xcf,0x48,0x8b,0xd6,0xe8,0xe9,0xa0,0x5e,0xfd,0x48,0xb9,0xe0,0x27,0x4b,0x81,0xfe,0x7f,0x00,0x00,0xe8,0x52,0x6d,0x8c,0x5b,0x48,0x8b,0xf0,0x48,0x8d,0x4e,0x08,0x48,0x8b,0xd7,0xe8,0x83,0x5e,0x8c,0x5b,0x48,0x8d,0x46,0x10,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x00,0x48,0x8b,0xc6,0x48,0x83,0xc4,0x28,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> createヽᐤIRandomSourceᐸulongᐳᐤ  =>  new byte[64]{0x57,0x56,0x48,0x83,0xec,0x28,0xc5,0xf8,0x77,0x48,0x8b,0xf1,0x48,0xb9,0xe0,0x27,0x4b,0x81,0xfe,0x7f,0x00,0x00,0xe8,0xf5,0x6c,0x8c,0x5b,0x48,0x8b,0xf8,0x48,0x8d,0x4f,0x08,0x48,0x8b,0xd6,0xe8,0x26,0x5e,0x8c,0x5b,0x48,0x8d,0x47,0x10,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x00,0x48,0x8b,0xc7,0x48,0x83,0xc4,0x28,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> createヽᐤIRandomNavᐸulongᐳᐤ  =>  new byte[75]{0x57,0x56,0x53,0x48,0x83,0xec,0x20,0x48,0x8b,0xf1,0x48,0xb9,0xe0,0x27,0x4b,0x81,0xfe,0x7f,0x00,0x00,0xe8,0x97,0x6c,0x8c,0x5b,0x48,0x8b,0xf8,0x48,0x8d,0x4f,0x08,0x48,0x8b,0xd6,0xe8,0xc8,0x5d,0x8c,0x5b,0x48,0x8b,0xd6,0xbe,0x01,0x00,0x00,0x00,0x48,0x8d,0x5f,0x10,0x48,0x8d,0x0b,0xe8,0x84,0x5d,0x8c,0x5b,0x40,0x88,0x73,0x08,0x48,0x8b,0xc7,0x48,0x83,0xc4,0x20,0x5b,0x5e,0x5f,0xc3};

    }
}
