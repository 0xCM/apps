﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2022-01-07 15:36:30 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class lib_allocating
    {
        public static ReadOnlySpan<byte> onesヽgᐸ8uᐳᐤ32iㆍ32iㆍ8uᐤ  =>  new byte[101]{0x57,0x56,0x53,0x48,0x83,0xec,0x50,0xc5,0xf8,0x77,0x48,0x8b,0xf1,0x48,0x8d,0x7c,0x24,0x28,0xb9,0x0a,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x48,0x8b,0xd9,0x48,0x8d,0x4c,0x24,0x38,0x45,0x33,0xc9,0xe8,0x92,0xbd,0xff,0xff,0xc5,0xfa,0x6f,0x44,0x24,0x38,0xc5,0xfa,0x7f,0x44,0x24,0x28,0x48,0x8d,0x4c,0x24,0x28,0xba,0xff,0x00,0x00,0x00,0xe8,0x3f,0xbe,0xcf,0xfd,0x48,0x8b,0xfb,0x48,0x8d,0x74,0x24,0x38,0xe8,0xea,0xf1,0x83,0x5c,0x48,0xa5,0x48,0xa5,0x48,0x8b,0xc3,0x48,0x83,0xc4,0x50,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> onesヽgᐸ16uᐳᐤ32iㆍ32iㆍ16uᐤ  =>  new byte[101]{0x57,0x56,0x53,0x48,0x83,0xec,0x50,0xc5,0xf8,0x77,0x48,0x8b,0xf1,0x48,0x8d,0x7c,0x24,0x28,0xb9,0x0a,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x48,0x8b,0xd9,0x48,0x8d,0x4c,0x24,0x38,0x45,0x33,0xc9,0xe8,0xf2,0xbd,0xff,0xff,0xc5,0xfa,0x6f,0x44,0x24,0x38,0xc5,0xfa,0x7f,0x44,0x24,0x28,0x48,0x8d,0x4c,0x24,0x28,0xba,0xff,0xff,0x00,0x00,0xe8,0x8f,0xbd,0x9c,0xfe,0x48,0x8b,0xfb,0x48,0x8d,0x74,0x24,0x38,0xe8,0x6a,0xf1,0x83,0x5c,0x48,0xa5,0x48,0xa5,0x48,0x8b,0xc3,0x48,0x83,0xc4,0x50,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> onesヽgᐸ32uᐳᐤ32iㆍ32iㆍ32uᐤ  =>  new byte[101]{0x57,0x56,0x53,0x48,0x83,0xec,0x50,0xc5,0xf8,0x77,0x48,0x8b,0xf1,0x48,0x8d,0x7c,0x24,0x28,0xb9,0x0a,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x48,0x8b,0xd9,0x48,0x8d,0x4c,0x24,0x38,0x45,0x33,0xc9,0xe8,0x62,0xbe,0xff,0xff,0xc5,0xfa,0x6f,0x44,0x24,0x38,0xc5,0xfa,0x7f,0x44,0x24,0x28,0x48,0x8d,0x4c,0x24,0x28,0xba,0xff,0xff,0xff,0xff,0xe8,0x87,0x5e,0x46,0xfe,0x48,0x8b,0xfb,0x48,0x8d,0x74,0x24,0x38,0xe8,0xea,0xf0,0x83,0x5c,0x48,0xa5,0x48,0xa5,0x48,0x8b,0xc3,0x48,0x83,0xc4,0x50,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> onesヽgᐸ64uᐳᐤ32iㆍ32iㆍ64uᐤ  =>  new byte[106]{0x57,0x56,0x53,0x48,0x83,0xec,0x50,0xc5,0xf8,0x77,0x48,0x8b,0xf1,0x48,0x8d,0x7c,0x24,0x28,0xb9,0x0a,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x48,0x8b,0xd9,0x48,0x8d,0x4c,0x24,0x38,0x45,0x33,0xc9,0xe8,0xe2,0xbe,0xff,0xff,0xc5,0xfa,0x6f,0x44,0x24,0x38,0xc5,0xfa,0x7f,0x44,0x24,0x28,0x48,0x8d,0x4c,0x24,0x28,0x48,0xba,0xff,0xff,0xff,0xff,0xff,0xff,0xff,0xff,0xe8,0x72,0x61,0x46,0xfe,0x48,0x8b,0xfb,0x48,0x8d,0x74,0x24,0x38,0xe8,0x65,0xf0,0x83,0x5c,0x48,0xa5,0x48,0xa5,0x48,0x8b,0xc3,0x48,0x83,0xc4,0x50,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> negateヽgᐸ8uᐳᐤbg8uᕀinᐤ  =>  new byte[182]{0x57,0x56,0x53,0x48,0x83,0xec,0x40,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x48,0x89,0x44,0x24,0x38,0x48,0x8b,0xd9,0x48,0x8b,0xf2,0x8b,0x56,0x10,0x44,0x8b,0x46,0x14,0x48,0x8d,0x4c,0x24,0x28,0x45,0x33,0xc9,0xe8,0x7b,0xbb,0xff,0xff,0x8b,0x44,0x24,0x30,0x8b,0xd0,0xc1,0xfa,0x1f,0x83,0xe2,0x1f,0x03,0xc2,0xc1,0xf8,0x05,0x33,0xd2,0x85,0xc0,0x7e,0x4b,0x48,0x8b,0x0e,0x44,0x8b,0xc2,0x41,0xc1,0xe0,0x05,0x4d,0x63,0xc0,0x49,0x03,0xc8,0xc5,0xff,0xf0,0x01,0xc5,0xfd,0x74,0xc8,0xc5,0xfd,0xef,0xc1,0xc5,0xf4,0x57,0xc9,0xc5,0xec,0x57,0xd2,0xc5,0xf5,0x74,0xca,0xc5,0xfd,0xf8,0xc1,0x48,0x8d,0x4c,0x24,0x28,0x48,0x8b,0x09,0x44,0x8b,0xc2,0x41,0xc1,0xe0,0x05,0x4d,0x63,0xc0,0x49,0x03,0xc8,0xc5,0xfe,0x7f,0x01,0xff,0xc2,0x3b,0xd0,0x7c,0xb5,0x48,0x8b,0xfb,0x48,0x8d,0x74,0x24,0x28,0xe8,0x8c,0xef,0x83,0x5c,0x48,0xa5,0x48,0xa5,0x48,0x8b,0xc3,0xc5,0xf8,0x77,0x48,0x83,0xc4,0x40,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> negateヽgᐸ16uᐳᐤbg16uᕀinᐤ  =>  new byte[184]{0x57,0x56,0x53,0x48,0x83,0xec,0x40,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x48,0x89,0x44,0x24,0x38,0x48,0x8b,0xd9,0x48,0x8b,0xf2,0x8b,0x56,0x10,0x44,0x8b,0x46,0x14,0x48,0x8d,0x4c,0x24,0x28,0x45,0x33,0xc9,0xe8,0x7b,0xbb,0xff,0xff,0x8b,0x44,0x24,0x30,0x8b,0xd0,0xc1,0xfa,0x1f,0x83,0xe2,0x0f,0x03,0xc2,0xc1,0xf8,0x04,0x33,0xd2,0x85,0xc0,0x7e,0x4d,0x48,0x8b,0x0e,0x44,0x8b,0xc2,0x41,0xc1,0xe0,0x04,0x4d,0x63,0xc0,0x4a,0x8d,0x0c,0x41,0xc5,0xff,0xf0,0x01,0xc5,0xfd,0x75,0xc8,0xc5,0xfd,0xef,0xc1,0xc5,0xf4,0x57,0xc9,0xc5,0xec,0x57,0xd2,0xc5,0xf5,0x75,0xca,0xc5,0xfd,0xf9,0xc1,0x48,0x8d,0x4c,0x24,0x28,0x48,0x8b,0x09,0x44,0x8b,0xc2,0x41,0xc1,0xe0,0x04,0x4d,0x63,0xc0,0x4a,0x8d,0x0c,0x41,0xc5,0xfe,0x7f,0x01,0xff,0xc2,0x3b,0xd0,0x7c,0xb3,0x48,0x8b,0xfb,0x48,0x8d,0x74,0x24,0x28,0xe8,0xaa,0xee,0x83,0x5c,0x48,0xa5,0x48,0xa5,0x48,0x8b,0xc3,0xc5,0xf8,0x77,0x48,0x83,0xc4,0x40,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> negateヽgᐸ32uᐳᐤbg32uᕀinᐤ  =>  new byte[184]{0x57,0x56,0x53,0x48,0x83,0xec,0x40,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x48,0x89,0x44,0x24,0x38,0x48,0x8b,0xd9,0x48,0x8b,0xf2,0x8b,0x56,0x10,0x44,0x8b,0x46,0x14,0x48,0x8d,0x4c,0x24,0x28,0x45,0x33,0xc9,0xe8,0x8b,0xbb,0xff,0xff,0x8b,0x44,0x24,0x30,0x8b,0xd0,0xc1,0xfa,0x1f,0x83,0xe2,0x07,0x03,0xc2,0xc1,0xf8,0x03,0x33,0xd2,0x85,0xc0,0x7e,0x4d,0x48,0x8b,0x0e,0x44,0x8b,0xc2,0x41,0xc1,0xe0,0x03,0x4d,0x63,0xc0,0x4a,0x8d,0x0c,0x81,0xc5,0xff,0xf0,0x01,0xc5,0xfd,0x76,0xc8,0xc5,0xfd,0xef,0xc1,0xc5,0xf4,0x57,0xc9,0xc5,0xec,0x57,0xd2,0xc5,0xf5,0x76,0xca,0xc5,0xfd,0xfa,0xc1,0x48,0x8d,0x4c,0x24,0x28,0x48,0x8b,0x09,0x44,0x8b,0xc2,0x41,0xc1,0xe0,0x03,0x4d,0x63,0xc0,0x4a,0x8d,0x0c,0x81,0xc5,0xfe,0x7f,0x01,0xff,0xc2,0x3b,0xd0,0x7c,0xb3,0x48,0x8b,0xfb,0x48,0x8d,0x74,0x24,0x28,0xe8,0xca,0xed,0x83,0x5c,0x48,0xa5,0x48,0xa5,0x48,0x8b,0xc3,0xc5,0xf8,0x77,0x48,0x83,0xc4,0x40,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> negateヽgᐸ64uᐳᐤbg64uᕀinᐤ  =>  new byte[186]{0x57,0x56,0x53,0x48,0x83,0xec,0x40,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x48,0x89,0x44,0x24,0x38,0x48,0x8b,0xd9,0x48,0x8b,0xf2,0x8b,0x56,0x10,0x44,0x8b,0x46,0x14,0x48,0x8d,0x4c,0x24,0x28,0x45,0x33,0xc9,0xe8,0xab,0xbb,0xff,0xff,0x8b,0x44,0x24,0x30,0x8b,0xd0,0xc1,0xfa,0x1f,0x83,0xe2,0x03,0x03,0xc2,0xc1,0xf8,0x02,0x33,0xd2,0x85,0xc0,0x7e,0x4f,0x48,0x8b,0x0e,0x44,0x8b,0xc2,0x41,0xc1,0xe0,0x02,0x4d,0x63,0xc0,0x4a,0x8d,0x0c,0xc1,0xc5,0xff,0xf0,0x01,0xc4,0xe2,0x7d,0x29,0xc8,0xc5,0xfd,0xef,0xc1,0xc5,0xf4,0x57,0xc9,0xc5,0xec,0x57,0xd2,0xc4,0xe2,0x75,0x29,0xca,0xc5,0xfd,0xfb,0xc1,0x48,0x8d,0x4c,0x24,0x28,0x48,0x8b,0x09,0x44,0x8b,0xc2,0x41,0xc1,0xe0,0x02,0x4d,0x63,0xc0,0x4a,0x8d,0x0c,0xc1,0xc5,0xfe,0x7f,0x01,0xff,0xc2,0x3b,0xd0,0x7c,0xb1,0x48,0x8b,0xfb,0x48,0x8d,0x74,0x24,0x28,0xe8,0xe8,0xec,0x83,0x5c,0x48,0xa5,0x48,0xa5,0x48,0x8b,0xc3,0xc5,0xf8,0x77,0x48,0x83,0xc4,0x40,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> xorヽgᐸ8uᐳᐤbg8uᕀinㆍbg8uᕀinᐤ  =>  new byte[200]{0x41,0x57,0x41,0x56,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x38,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x4c,0x8b,0xf1,0x48,0x8b,0xda,0x49,0x8b,0xe8,0x8b,0x53,0x10,0x44,0x8b,0x43,0x14,0x48,0x8d,0x4c,0x24,0x20,0x45,0x33,0xc9,0xe8,0xf3,0xb3,0xff,0xff,0x8b,0x44,0x24,0x28,0x8b,0xd0,0xc1,0xfa,0x1f,0x83,0xe2,0x1f,0x03,0xc2,0xc1,0xf8,0x05,0x45,0x33,0xff,0x85,0xc0,0x7e,0x4f,0x48,0x8b,0x55,0x00,0x48,0x8b,0x13,0x41,0x8b,0xcf,0xc1,0xe1,0x05,0x48,0x63,0xc9,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x02,0x48,0x8b,0x55,0x00,0x41,0x8b,0xcf,0xc1,0xe1,0x05,0x48,0x63,0xc9,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x0a,0xc5,0xfd,0xef,0xc1,0x48,0x8d,0x54,0x24,0x20,0x48,0x8b,0x12,0x41,0x8b,0xcf,0xc1,0xe1,0x05,0x48,0x63,0xc9,0x48,0x03,0xd1,0xc5,0xfe,0x7f,0x02,0x41,0xff,0xc7,0x44,0x3b,0xf8,0x7c,0xb5,0x49,0x8b,0xfe,0x48,0x8d,0x74,0x24,0x20,0xe8,0xff,0xe7,0x83,0x5c,0x48,0xa5,0x48,0xa5,0x49,0x8b,0xc6,0xc5,0xf8,0x77,0x48,0x83,0xc4,0x38,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0x41,0x5f,0xc3};

        public static ReadOnlySpan<byte> xorヽgᐸ16uᐳᐤbg16uᕀinㆍbg16uᕀinᐤ  =>  new byte[185]{0x41,0x57,0x41,0x56,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x38,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x4c,0x8b,0xf1,0x48,0x8b,0xda,0x49,0x8b,0xe8,0x8b,0x53,0x10,0x44,0x8b,0x43,0x14,0x48,0x8d,0x4c,0x24,0x20,0x45,0x33,0xc9,0xe8,0xe3,0xb3,0xff,0xff,0x8b,0x44,0x24,0x28,0x8b,0xd0,0xc1,0xfa,0x1f,0x83,0xe2,0x0f,0x03,0xc2,0xc1,0xf8,0x04,0x45,0x33,0xff,0x85,0xc0,0x7e,0x40,0x48,0x8b,0x55,0x00,0x48,0x8b,0x13,0x41,0x8b,0xcf,0xc1,0xe1,0x04,0x48,0x63,0xc9,0x48,0xd1,0xe1,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x02,0x48,0x8b,0x55,0x00,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x0a,0xc5,0xfd,0xef,0xc1,0x48,0x8d,0x54,0x24,0x20,0x48,0x8b,0x12,0x48,0x03,0xd1,0xc5,0xfe,0x7f,0x02,0x41,0xff,0xc7,0x44,0x3b,0xf8,0x7c,0xc4,0x49,0x8b,0xfe,0x48,0x8d,0x74,0x24,0x20,0xe8,0x1e,0xe7,0x83,0x5c,0x48,0xa5,0x48,0xa5,0x49,0x8b,0xc6,0xc5,0xf8,0x77,0x48,0x83,0xc4,0x38,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0x41,0x5f,0xc3};

        public static ReadOnlySpan<byte> xorヽgᐸ32uᐳᐤbg32uᕀinㆍbg32uᕀinᐤ  =>  new byte[186]{0x41,0x57,0x41,0x56,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x38,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x4c,0x8b,0xf1,0x48,0x8b,0xda,0x49,0x8b,0xe8,0x8b,0x53,0x10,0x44,0x8b,0x43,0x14,0x48,0x8d,0x4c,0x24,0x20,0x45,0x33,0xc9,0xe8,0xf3,0xb3,0xff,0xff,0x8b,0x44,0x24,0x28,0x8b,0xd0,0xc1,0xfa,0x1f,0x83,0xe2,0x07,0x03,0xc2,0xc1,0xf8,0x03,0x45,0x33,0xff,0x85,0xc0,0x7e,0x41,0x48,0x8b,0x55,0x00,0x48,0x8b,0x13,0x41,0x8b,0xcf,0xc1,0xe1,0x03,0x48,0x63,0xc9,0x48,0xc1,0xe1,0x02,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x02,0x48,0x8b,0x55,0x00,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x0a,0xc5,0xfd,0xef,0xc1,0x48,0x8d,0x54,0x24,0x20,0x48,0x8b,0x12,0x48,0x03,0xd1,0xc5,0xfe,0x7f,0x02,0x41,0xff,0xc7,0x44,0x3b,0xf8,0x7c,0xc3,0x49,0x8b,0xfe,0x48,0x8d,0x74,0x24,0x20,0xe8,0x3d,0xe6,0x83,0x5c,0x48,0xa5,0x48,0xa5,0x49,0x8b,0xc6,0xc5,0xf8,0x77,0x48,0x83,0xc4,0x38,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0x41,0x5f,0xc3};

        public static ReadOnlySpan<byte> xorヽgᐸ64uᐳᐤbg64uᕀinㆍbg64uᕀinᐤ  =>  new byte[186]{0x41,0x57,0x41,0x56,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x38,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x4c,0x8b,0xf1,0x48,0x8b,0xda,0x49,0x8b,0xe8,0x8b,0x53,0x10,0x44,0x8b,0x43,0x14,0x48,0x8d,0x4c,0x24,0x20,0x45,0x33,0xc9,0xe8,0x13,0xb4,0xff,0xff,0x8b,0x44,0x24,0x28,0x8b,0xd0,0xc1,0xfa,0x1f,0x83,0xe2,0x03,0x03,0xc2,0xc1,0xf8,0x02,0x45,0x33,0xff,0x85,0xc0,0x7e,0x41,0x48,0x8b,0x55,0x00,0x48,0x8b,0x13,0x41,0x8b,0xcf,0xc1,0xe1,0x02,0x48,0x63,0xc9,0x48,0xc1,0xe1,0x03,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x02,0x48,0x8b,0x55,0x00,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x0a,0xc5,0xfd,0xef,0xc1,0x48,0x8d,0x54,0x24,0x20,0x48,0x8b,0x12,0x48,0x03,0xd1,0xc5,0xfe,0x7f,0x02,0x41,0xff,0xc7,0x44,0x3b,0xf8,0x7c,0xc3,0x49,0x8b,0xfe,0x48,0x8d,0x74,0x24,0x20,0xe8,0x5d,0xe5,0x83,0x5c,0x48,0xa5,0x48,0xa5,0x49,0x8b,0xc6,0xc5,0xf8,0x77,0x48,0x83,0xc4,0x38,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0x41,0x5f,0xc3};

        public static ReadOnlySpan<byte> xnorヽgᐸ8uᐳᐤbg8uᕀinㆍbg8uᕀinᐤ  =>  new byte[208]{0x41,0x57,0x41,0x56,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x38,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x4c,0x8b,0xf1,0x48,0x8b,0xda,0x49,0x8b,0xe8,0x8b,0x53,0x10,0x44,0x8b,0x43,0x14,0x48,0x8d,0x4c,0x24,0x20,0x45,0x33,0xc9,0xe8,0x63,0xb0,0xff,0xff,0x8b,0x44,0x24,0x28,0x8b,0xd0,0xc1,0xfa,0x1f,0x83,0xe2,0x1f,0x03,0xc2,0xc1,0xf8,0x05,0x45,0x33,0xff,0x85,0xc0,0x7e,0x57,0x48,0x8b,0x55,0x00,0x48,0x8b,0x13,0x41,0x8b,0xcf,0xc1,0xe1,0x05,0x48,0x63,0xc9,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x02,0x48,0x8b,0x55,0x00,0x41,0x8b,0xcf,0xc1,0xe1,0x05,0x48,0x63,0xc9,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x0a,0xc5,0xfd,0xef,0xc1,0xc5,0xfd,0x74,0xc8,0xc5,0xfd,0xef,0xc1,0x48,0x8d,0x54,0x24,0x20,0x48,0x8b,0x12,0x41,0x8b,0xcf,0xc1,0xe1,0x05,0x48,0x63,0xc9,0x48,0x03,0xd1,0xc5,0xfe,0x7f,0x02,0x41,0xff,0xc7,0x44,0x3b,0xf8,0x7c,0xad,0x49,0x8b,0xfe,0x48,0x8d,0x74,0x24,0x20,0xe8,0x67,0xe4,0x83,0x5c,0x48,0xa5,0x48,0xa5,0x49,0x8b,0xc6,0xc5,0xf8,0x77,0x48,0x83,0xc4,0x38,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0x41,0x5f,0xc3};

        public static ReadOnlySpan<byte> xnorヽgᐸ16uᐳᐤbg16uᕀinㆍbg16uᕀinᐤ  =>  new byte[193]{0x41,0x57,0x41,0x56,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x38,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x4c,0x8b,0xf1,0x48,0x8b,0xda,0x49,0x8b,0xe8,0x8b,0x53,0x10,0x44,0x8b,0x43,0x14,0x48,0x8d,0x4c,0x24,0x20,0x45,0x33,0xc9,0xe8,0x43,0xb0,0xff,0xff,0x8b,0x44,0x24,0x28,0x8b,0xd0,0xc1,0xfa,0x1f,0x83,0xe2,0x0f,0x03,0xc2,0xc1,0xf8,0x04,0x45,0x33,0xff,0x85,0xc0,0x7e,0x48,0x48,0x8b,0x55,0x00,0x48,0x8b,0x13,0x41,0x8b,0xcf,0xc1,0xe1,0x04,0x48,0x63,0xc9,0x48,0xd1,0xe1,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x02,0x48,0x8b,0x55,0x00,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x0a,0xc5,0xfd,0xef,0xc1,0xc5,0xfd,0x75,0xc8,0xc5,0xfd,0xef,0xc1,0x48,0x8d,0x54,0x24,0x20,0x48,0x8b,0x12,0x48,0x03,0xd1,0xc5,0xfe,0x7f,0x02,0x41,0xff,0xc7,0x44,0x3b,0xf8,0x7c,0xbc,0x49,0x8b,0xfe,0x48,0x8d,0x74,0x24,0x20,0xe8,0x76,0xe3,0x83,0x5c,0x48,0xa5,0x48,0xa5,0x49,0x8b,0xc6,0xc5,0xf8,0x77,0x48,0x83,0xc4,0x38,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0x41,0x5f,0xc3};

        public static ReadOnlySpan<byte> xnorヽgᐸ32uᐳᐤbg32uᕀinㆍbg32uᕀinᐤ  =>  new byte[194]{0x41,0x57,0x41,0x56,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x38,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x4c,0x8b,0xf1,0x48,0x8b,0xda,0x49,0x8b,0xe8,0x8b,0x53,0x10,0x44,0x8b,0x43,0x14,0x48,0x8d,0x4c,0x24,0x20,0x45,0x33,0xc9,0xe8,0x43,0xb0,0xff,0xff,0x8b,0x44,0x24,0x28,0x8b,0xd0,0xc1,0xfa,0x1f,0x83,0xe2,0x07,0x03,0xc2,0xc1,0xf8,0x03,0x45,0x33,0xff,0x85,0xc0,0x7e,0x49,0x48,0x8b,0x55,0x00,0x48,0x8b,0x13,0x41,0x8b,0xcf,0xc1,0xe1,0x03,0x48,0x63,0xc9,0x48,0xc1,0xe1,0x02,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x02,0x48,0x8b,0x55,0x00,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x0a,0xc5,0xfd,0xef,0xc1,0xc5,0xfd,0x76,0xc8,0xc5,0xfd,0xef,0xc1,0x48,0x8d,0x54,0x24,0x20,0x48,0x8b,0x12,0x48,0x03,0xd1,0xc5,0xfe,0x7f,0x02,0x41,0xff,0xc7,0x44,0x3b,0xf8,0x7c,0xbb,0x49,0x8b,0xfe,0x48,0x8d,0x74,0x24,0x20,0xe8,0x85,0xe2,0x83,0x5c,0x48,0xa5,0x48,0xa5,0x49,0x8b,0xc6,0xc5,0xf8,0x77,0x48,0x83,0xc4,0x38,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0x41,0x5f,0xc3};

        public static ReadOnlySpan<byte> xnorヽgᐸ64uᐳᐤbg64uᕀinㆍbg64uᕀinᐤ  =>  new byte[195]{0x41,0x57,0x41,0x56,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x38,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x4c,0x8b,0xf1,0x48,0x8b,0xda,0x49,0x8b,0xe8,0x8b,0x53,0x10,0x44,0x8b,0x43,0x14,0x48,0x8d,0x4c,0x24,0x20,0x45,0x33,0xc9,0xe8,0x53,0xb0,0xff,0xff,0x8b,0x44,0x24,0x28,0x8b,0xd0,0xc1,0xfa,0x1f,0x83,0xe2,0x03,0x03,0xc2,0xc1,0xf8,0x02,0x45,0x33,0xff,0x85,0xc0,0x7e,0x4a,0x48,0x8b,0x55,0x00,0x48,0x8b,0x13,0x41,0x8b,0xcf,0xc1,0xe1,0x02,0x48,0x63,0xc9,0x48,0xc1,0xe1,0x03,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x02,0x48,0x8b,0x55,0x00,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x0a,0xc5,0xfd,0xef,0xc1,0xc4,0xe2,0x7d,0x29,0xc8,0xc5,0xfd,0xef,0xc1,0x48,0x8d,0x54,0x24,0x20,0x48,0x8b,0x12,0x48,0x03,0xd1,0xc5,0xfe,0x7f,0x02,0x41,0xff,0xc7,0x44,0x3b,0xf8,0x7c,0xba,0x49,0x8b,0xfe,0x48,0x8d,0x74,0x24,0x20,0xe8,0x94,0xe1,0x83,0x5c,0x48,0xa5,0x48,0xa5,0x49,0x8b,0xc6,0xc5,0xf8,0x77,0x48,0x83,0xc4,0x38,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0x41,0x5f,0xc3};

        public static ReadOnlySpan<byte> orヽgᐸ8uᐳᐤbg8uᕀinㆍbg8uᕀinᐤ  =>  new byte[200]{0x41,0x57,0x41,0x56,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x38,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x4c,0x8b,0xf1,0x48,0x8b,0xda,0x49,0x8b,0xe8,0x8b,0x53,0x10,0x44,0x8b,0x43,0x14,0x48,0x8d,0x4c,0x24,0x20,0x45,0x33,0xc9,0xe8,0x93,0xac,0xff,0xff,0x8b,0x44,0x24,0x28,0x8b,0xd0,0xc1,0xfa,0x1f,0x83,0xe2,0x1f,0x03,0xc2,0xc1,0xf8,0x05,0x45,0x33,0xff,0x85,0xc0,0x7e,0x4f,0x48,0x8b,0x55,0x00,0x48,0x8b,0x13,0x41,0x8b,0xcf,0xc1,0xe1,0x05,0x48,0x63,0xc9,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x02,0x48,0x8b,0x55,0x00,0x41,0x8b,0xcf,0xc1,0xe1,0x05,0x48,0x63,0xc9,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x0a,0xc5,0xfd,0xeb,0xc1,0x48,0x8d,0x54,0x24,0x20,0x48,0x8b,0x12,0x41,0x8b,0xcf,0xc1,0xe1,0x05,0x48,0x63,0xc9,0x48,0x03,0xd1,0xc5,0xfe,0x7f,0x02,0x41,0xff,0xc7,0x44,0x3b,0xf8,0x7c,0xb5,0x49,0x8b,0xfe,0x48,0x8d,0x74,0x24,0x20,0xe8,0x9f,0xe0,0x83,0x5c,0x48,0xa5,0x48,0xa5,0x49,0x8b,0xc6,0xc5,0xf8,0x77,0x48,0x83,0xc4,0x38,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0x41,0x5f,0xc3};

        public static ReadOnlySpan<byte> orヽgᐸ16uᐳᐤbg16uᕀinㆍbg16uᕀinᐤ  =>  new byte[185]{0x41,0x57,0x41,0x56,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x38,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x4c,0x8b,0xf1,0x48,0x8b,0xda,0x49,0x8b,0xe8,0x8b,0x53,0x10,0x44,0x8b,0x43,0x14,0x48,0x8d,0x4c,0x24,0x20,0x45,0x33,0xc9,0xe8,0x83,0xac,0xff,0xff,0x8b,0x44,0x24,0x28,0x8b,0xd0,0xc1,0xfa,0x1f,0x83,0xe2,0x0f,0x03,0xc2,0xc1,0xf8,0x04,0x45,0x33,0xff,0x85,0xc0,0x7e,0x40,0x48,0x8b,0x55,0x00,0x48,0x8b,0x13,0x41,0x8b,0xcf,0xc1,0xe1,0x04,0x48,0x63,0xc9,0x48,0xd1,0xe1,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x02,0x48,0x8b,0x55,0x00,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x0a,0xc5,0xfd,0xeb,0xc1,0x48,0x8d,0x54,0x24,0x20,0x48,0x8b,0x12,0x48,0x03,0xd1,0xc5,0xfe,0x7f,0x02,0x41,0xff,0xc7,0x44,0x3b,0xf8,0x7c,0xc4,0x49,0x8b,0xfe,0x48,0x8d,0x74,0x24,0x20,0xe8,0xbe,0xdf,0x83,0x5c,0x48,0xa5,0x48,0xa5,0x49,0x8b,0xc6,0xc5,0xf8,0x77,0x48,0x83,0xc4,0x38,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0x41,0x5f,0xc3};

        public static ReadOnlySpan<byte> orヽgᐸ32uᐳᐤbg32uᕀinㆍbg32uᕀinᐤ  =>  new byte[186]{0x41,0x57,0x41,0x56,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x38,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x4c,0x8b,0xf1,0x48,0x8b,0xda,0x49,0x8b,0xe8,0x8b,0x53,0x10,0x44,0x8b,0x43,0x14,0x48,0x8d,0x4c,0x24,0x20,0x45,0x33,0xc9,0xe8,0x93,0xac,0xff,0xff,0x8b,0x44,0x24,0x28,0x8b,0xd0,0xc1,0xfa,0x1f,0x83,0xe2,0x07,0x03,0xc2,0xc1,0xf8,0x03,0x45,0x33,0xff,0x85,0xc0,0x7e,0x41,0x48,0x8b,0x55,0x00,0x48,0x8b,0x13,0x41,0x8b,0xcf,0xc1,0xe1,0x03,0x48,0x63,0xc9,0x48,0xc1,0xe1,0x02,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x02,0x48,0x8b,0x55,0x00,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x0a,0xc5,0xfd,0xeb,0xc1,0x48,0x8d,0x54,0x24,0x20,0x48,0x8b,0x12,0x48,0x03,0xd1,0xc5,0xfe,0x7f,0x02,0x41,0xff,0xc7,0x44,0x3b,0xf8,0x7c,0xc3,0x49,0x8b,0xfe,0x48,0x8d,0x74,0x24,0x20,0xe8,0xdd,0xde,0x83,0x5c,0x48,0xa5,0x48,0xa5,0x49,0x8b,0xc6,0xc5,0xf8,0x77,0x48,0x83,0xc4,0x38,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0x41,0x5f,0xc3};

        public static ReadOnlySpan<byte> orヽgᐸ64uᐳᐤbg64uᕀinㆍbg64uᕀinᐤ  =>  new byte[186]{0x41,0x57,0x41,0x56,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x38,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x4c,0x8b,0xf1,0x48,0x8b,0xda,0x49,0x8b,0xe8,0x8b,0x53,0x10,0x44,0x8b,0x43,0x14,0x48,0x8d,0x4c,0x24,0x20,0x45,0x33,0xc9,0xe8,0xb3,0xac,0xff,0xff,0x8b,0x44,0x24,0x28,0x8b,0xd0,0xc1,0xfa,0x1f,0x83,0xe2,0x03,0x03,0xc2,0xc1,0xf8,0x02,0x45,0x33,0xff,0x85,0xc0,0x7e,0x41,0x48,0x8b,0x55,0x00,0x48,0x8b,0x13,0x41,0x8b,0xcf,0xc1,0xe1,0x02,0x48,0x63,0xc9,0x48,0xc1,0xe1,0x03,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x02,0x48,0x8b,0x55,0x00,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x0a,0xc5,0xfd,0xeb,0xc1,0x48,0x8d,0x54,0x24,0x20,0x48,0x8b,0x12,0x48,0x03,0xd1,0xc5,0xfe,0x7f,0x02,0x41,0xff,0xc7,0x44,0x3b,0xf8,0x7c,0xc3,0x49,0x8b,0xfe,0x48,0x8d,0x74,0x24,0x20,0xe8,0xfd,0xdd,0x83,0x5c,0x48,0xa5,0x48,0xa5,0x49,0x8b,0xc6,0xc5,0xf8,0x77,0x48,0x83,0xc4,0x38,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0x41,0x5f,0xc3};

        public static ReadOnlySpan<byte> norヽgᐸ8uᐳᐤbg8uᕀinㆍbg8uᕀinᐤ  =>  new byte[208]{0x41,0x57,0x41,0x56,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x38,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x4c,0x8b,0xf1,0x48,0x8b,0xda,0x49,0x8b,0xe8,0x8b,0x53,0x10,0x44,0x8b,0x43,0x14,0x48,0x8d,0x4c,0x24,0x20,0x45,0x33,0xc9,0xe8,0x03,0xa9,0xff,0xff,0x8b,0x44,0x24,0x28,0x8b,0xd0,0xc1,0xfa,0x1f,0x83,0xe2,0x1f,0x03,0xc2,0xc1,0xf8,0x05,0x45,0x33,0xff,0x85,0xc0,0x7e,0x57,0x48,0x8b,0x55,0x00,0x48,0x8b,0x13,0x41,0x8b,0xcf,0xc1,0xe1,0x05,0x48,0x63,0xc9,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x02,0x48,0x8b,0x55,0x00,0x41,0x8b,0xcf,0xc1,0xe1,0x05,0x48,0x63,0xc9,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x0a,0xc5,0xfd,0xeb,0xc1,0xc5,0xfd,0x74,0xc8,0xc5,0xfd,0xef,0xc1,0x48,0x8d,0x54,0x24,0x20,0x48,0x8b,0x12,0x41,0x8b,0xcf,0xc1,0xe1,0x05,0x48,0x63,0xc9,0x48,0x03,0xd1,0xc5,0xfe,0x7f,0x02,0x41,0xff,0xc7,0x44,0x3b,0xf8,0x7c,0xad,0x49,0x8b,0xfe,0x48,0x8d,0x74,0x24,0x20,0xe8,0x07,0xdd,0x83,0x5c,0x48,0xa5,0x48,0xa5,0x49,0x8b,0xc6,0xc5,0xf8,0x77,0x48,0x83,0xc4,0x38,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0x41,0x5f,0xc3};

        public static ReadOnlySpan<byte> norヽgᐸ16uᐳᐤbg16uᕀinㆍbg16uᕀinᐤ  =>  new byte[193]{0x41,0x57,0x41,0x56,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x38,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x4c,0x8b,0xf1,0x48,0x8b,0xda,0x49,0x8b,0xe8,0x8b,0x53,0x10,0x44,0x8b,0x43,0x14,0x48,0x8d,0x4c,0x24,0x20,0x45,0x33,0xc9,0xe8,0xe3,0xa8,0xff,0xff,0x8b,0x44,0x24,0x28,0x8b,0xd0,0xc1,0xfa,0x1f,0x83,0xe2,0x0f,0x03,0xc2,0xc1,0xf8,0x04,0x45,0x33,0xff,0x85,0xc0,0x7e,0x48,0x48,0x8b,0x55,0x00,0x48,0x8b,0x13,0x41,0x8b,0xcf,0xc1,0xe1,0x04,0x48,0x63,0xc9,0x48,0xd1,0xe1,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x02,0x48,0x8b,0x55,0x00,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x0a,0xc5,0xfd,0xeb,0xc1,0xc5,0xfd,0x75,0xc8,0xc5,0xfd,0xef,0xc1,0x48,0x8d,0x54,0x24,0x20,0x48,0x8b,0x12,0x48,0x03,0xd1,0xc5,0xfe,0x7f,0x02,0x41,0xff,0xc7,0x44,0x3b,0xf8,0x7c,0xbc,0x49,0x8b,0xfe,0x48,0x8d,0x74,0x24,0x20,0xe8,0x16,0xdc,0x83,0x5c,0x48,0xa5,0x48,0xa5,0x49,0x8b,0xc6,0xc5,0xf8,0x77,0x48,0x83,0xc4,0x38,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0x41,0x5f,0xc3};

        public static ReadOnlySpan<byte> norヽgᐸ32uᐳᐤbg32uᕀinㆍbg32uᕀinᐤ  =>  new byte[194]{0x41,0x57,0x41,0x56,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x38,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x4c,0x8b,0xf1,0x48,0x8b,0xda,0x49,0x8b,0xe8,0x8b,0x53,0x10,0x44,0x8b,0x43,0x14,0x48,0x8d,0x4c,0x24,0x20,0x45,0x33,0xc9,0xe8,0xe3,0xa8,0xff,0xff,0x8b,0x44,0x24,0x28,0x8b,0xd0,0xc1,0xfa,0x1f,0x83,0xe2,0x07,0x03,0xc2,0xc1,0xf8,0x03,0x45,0x33,0xff,0x85,0xc0,0x7e,0x49,0x48,0x8b,0x55,0x00,0x48,0x8b,0x13,0x41,0x8b,0xcf,0xc1,0xe1,0x03,0x48,0x63,0xc9,0x48,0xc1,0xe1,0x02,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x02,0x48,0x8b,0x55,0x00,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x0a,0xc5,0xfd,0xeb,0xc1,0xc5,0xfd,0x76,0xc8,0xc5,0xfd,0xef,0xc1,0x48,0x8d,0x54,0x24,0x20,0x48,0x8b,0x12,0x48,0x03,0xd1,0xc5,0xfe,0x7f,0x02,0x41,0xff,0xc7,0x44,0x3b,0xf8,0x7c,0xbb,0x49,0x8b,0xfe,0x48,0x8d,0x74,0x24,0x20,0xe8,0x25,0xdb,0x83,0x5c,0x48,0xa5,0x48,0xa5,0x49,0x8b,0xc6,0xc5,0xf8,0x77,0x48,0x83,0xc4,0x38,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0x41,0x5f,0xc3};

        public static ReadOnlySpan<byte> norヽgᐸ64uᐳᐤbg64uᕀinㆍbg64uᕀinᐤ  =>  new byte[195]{0x41,0x57,0x41,0x56,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x38,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x4c,0x8b,0xf1,0x48,0x8b,0xda,0x49,0x8b,0xe8,0x8b,0x53,0x10,0x44,0x8b,0x43,0x14,0x48,0x8d,0x4c,0x24,0x20,0x45,0x33,0xc9,0xe8,0xf3,0xa8,0xff,0xff,0x8b,0x44,0x24,0x28,0x8b,0xd0,0xc1,0xfa,0x1f,0x83,0xe2,0x03,0x03,0xc2,0xc1,0xf8,0x02,0x45,0x33,0xff,0x85,0xc0,0x7e,0x4a,0x48,0x8b,0x55,0x00,0x48,0x8b,0x13,0x41,0x8b,0xcf,0xc1,0xe1,0x02,0x48,0x63,0xc9,0x48,0xc1,0xe1,0x03,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x02,0x48,0x8b,0x55,0x00,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x0a,0xc5,0xfd,0xeb,0xc1,0xc4,0xe2,0x7d,0x29,0xc8,0xc5,0xfd,0xef,0xc1,0x48,0x8d,0x54,0x24,0x20,0x48,0x8b,0x12,0x48,0x03,0xd1,0xc5,0xfe,0x7f,0x02,0x41,0xff,0xc7,0x44,0x3b,0xf8,0x7c,0xba,0x49,0x8b,0xfe,0x48,0x8d,0x74,0x24,0x20,0xe8,0x34,0xda,0x83,0x5c,0x48,0xa5,0x48,0xa5,0x49,0x8b,0xc6,0xc5,0xf8,0x77,0x48,0x83,0xc4,0x38,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0x41,0x5f,0xc3};

        public static ReadOnlySpan<byte> andヽgᐸ8uᐳᐤbg8uᕀinㆍbg8uᕀinᐤ  =>  new byte[200]{0x41,0x57,0x41,0x56,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x38,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x4c,0x8b,0xf1,0x48,0x8b,0xda,0x49,0x8b,0xe8,0x8b,0x53,0x10,0x44,0x8b,0x43,0x14,0x48,0x8d,0x4c,0x24,0x20,0x45,0x33,0xc9,0xe8,0x33,0xa5,0xff,0xff,0x8b,0x44,0x24,0x28,0x8b,0xd0,0xc1,0xfa,0x1f,0x83,0xe2,0x1f,0x03,0xc2,0xc1,0xf8,0x05,0x45,0x33,0xff,0x85,0xc0,0x7e,0x4f,0x48,0x8b,0x55,0x00,0x48,0x8b,0x13,0x41,0x8b,0xcf,0xc1,0xe1,0x05,0x48,0x63,0xc9,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x02,0x48,0x8b,0x55,0x00,0x41,0x8b,0xcf,0xc1,0xe1,0x05,0x48,0x63,0xc9,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x0a,0xc5,0xfd,0xdb,0xc1,0x48,0x8d,0x54,0x24,0x20,0x48,0x8b,0x12,0x41,0x8b,0xcf,0xc1,0xe1,0x05,0x48,0x63,0xc9,0x48,0x03,0xd1,0xc5,0xfe,0x7f,0x02,0x41,0xff,0xc7,0x44,0x3b,0xf8,0x7c,0xb5,0x49,0x8b,0xfe,0x48,0x8d,0x74,0x24,0x20,0xe8,0x3f,0xd9,0x83,0x5c,0x48,0xa5,0x48,0xa5,0x49,0x8b,0xc6,0xc5,0xf8,0x77,0x48,0x83,0xc4,0x38,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0x41,0x5f,0xc3};

        public static ReadOnlySpan<byte> andヽgᐸ16uᐳᐤbg16uᕀinㆍbg16uᕀinᐤ  =>  new byte[185]{0x41,0x57,0x41,0x56,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x38,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x4c,0x8b,0xf1,0x48,0x8b,0xda,0x49,0x8b,0xe8,0x8b,0x53,0x10,0x44,0x8b,0x43,0x14,0x48,0x8d,0x4c,0x24,0x20,0x45,0x33,0xc9,0xe8,0x23,0xa5,0xff,0xff,0x8b,0x44,0x24,0x28,0x8b,0xd0,0xc1,0xfa,0x1f,0x83,0xe2,0x0f,0x03,0xc2,0xc1,0xf8,0x04,0x45,0x33,0xff,0x85,0xc0,0x7e,0x40,0x48,0x8b,0x55,0x00,0x48,0x8b,0x13,0x41,0x8b,0xcf,0xc1,0xe1,0x04,0x48,0x63,0xc9,0x48,0xd1,0xe1,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x02,0x48,0x8b,0x55,0x00,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x0a,0xc5,0xfd,0xdb,0xc1,0x48,0x8d,0x54,0x24,0x20,0x48,0x8b,0x12,0x48,0x03,0xd1,0xc5,0xfe,0x7f,0x02,0x41,0xff,0xc7,0x44,0x3b,0xf8,0x7c,0xc4,0x49,0x8b,0xfe,0x48,0x8d,0x74,0x24,0x20,0xe8,0x5e,0xd8,0x83,0x5c,0x48,0xa5,0x48,0xa5,0x49,0x8b,0xc6,0xc5,0xf8,0x77,0x48,0x83,0xc4,0x38,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0x41,0x5f,0xc3};

        public static ReadOnlySpan<byte> andヽgᐸ32uᐳᐤbg32uᕀinㆍbg32uᕀinᐤ  =>  new byte[186]{0x41,0x57,0x41,0x56,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x38,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x4c,0x8b,0xf1,0x48,0x8b,0xda,0x49,0x8b,0xe8,0x8b,0x53,0x10,0x44,0x8b,0x43,0x14,0x48,0x8d,0x4c,0x24,0x20,0x45,0x33,0xc9,0xe8,0x33,0xa5,0xff,0xff,0x8b,0x44,0x24,0x28,0x8b,0xd0,0xc1,0xfa,0x1f,0x83,0xe2,0x07,0x03,0xc2,0xc1,0xf8,0x03,0x45,0x33,0xff,0x85,0xc0,0x7e,0x41,0x48,0x8b,0x55,0x00,0x48,0x8b,0x13,0x41,0x8b,0xcf,0xc1,0xe1,0x03,0x48,0x63,0xc9,0x48,0xc1,0xe1,0x02,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x02,0x48,0x8b,0x55,0x00,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x0a,0xc5,0xfd,0xdb,0xc1,0x48,0x8d,0x54,0x24,0x20,0x48,0x8b,0x12,0x48,0x03,0xd1,0xc5,0xfe,0x7f,0x02,0x41,0xff,0xc7,0x44,0x3b,0xf8,0x7c,0xc3,0x49,0x8b,0xfe,0x48,0x8d,0x74,0x24,0x20,0xe8,0x7d,0xd7,0x83,0x5c,0x48,0xa5,0x48,0xa5,0x49,0x8b,0xc6,0xc5,0xf8,0x77,0x48,0x83,0xc4,0x38,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0x41,0x5f,0xc3};

        public static ReadOnlySpan<byte> andヽgᐸ64uᐳᐤbg64uᕀinㆍbg64uᕀinᐤ  =>  new byte[186]{0x41,0x57,0x41,0x56,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x38,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x4c,0x8b,0xf1,0x48,0x8b,0xda,0x49,0x8b,0xe8,0x8b,0x53,0x10,0x44,0x8b,0x43,0x14,0x48,0x8d,0x4c,0x24,0x20,0x45,0x33,0xc9,0xe8,0x53,0xa5,0xff,0xff,0x8b,0x44,0x24,0x28,0x8b,0xd0,0xc1,0xfa,0x1f,0x83,0xe2,0x03,0x03,0xc2,0xc1,0xf8,0x02,0x45,0x33,0xff,0x85,0xc0,0x7e,0x41,0x48,0x8b,0x55,0x00,0x48,0x8b,0x13,0x41,0x8b,0xcf,0xc1,0xe1,0x02,0x48,0x63,0xc9,0x48,0xc1,0xe1,0x03,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x02,0x48,0x8b,0x55,0x00,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x0a,0xc5,0xfd,0xdb,0xc1,0x48,0x8d,0x54,0x24,0x20,0x48,0x8b,0x12,0x48,0x03,0xd1,0xc5,0xfe,0x7f,0x02,0x41,0xff,0xc7,0x44,0x3b,0xf8,0x7c,0xc3,0x49,0x8b,0xfe,0x48,0x8d,0x74,0x24,0x20,0xe8,0x9d,0xd6,0x83,0x5c,0x48,0xa5,0x48,0xa5,0x49,0x8b,0xc6,0xc5,0xf8,0x77,0x48,0x83,0xc4,0x38,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0x41,0x5f,0xc3};

        public static ReadOnlySpan<byte> nandヽgᐸ8uᐳᐤbg8uᕀinㆍbg8uᕀinᐤ  =>  new byte[208]{0x41,0x57,0x41,0x56,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x38,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x4c,0x8b,0xf1,0x48,0x8b,0xda,0x49,0x8b,0xe8,0x8b,0x53,0x10,0x44,0x8b,0x43,0x14,0x48,0x8d,0x4c,0x24,0x20,0x45,0x33,0xc9,0xe8,0xa3,0xa1,0xff,0xff,0x8b,0x44,0x24,0x28,0x8b,0xd0,0xc1,0xfa,0x1f,0x83,0xe2,0x1f,0x03,0xc2,0xc1,0xf8,0x05,0x45,0x33,0xff,0x85,0xc0,0x7e,0x57,0x48,0x8b,0x55,0x00,0x48,0x8b,0x13,0x41,0x8b,0xcf,0xc1,0xe1,0x05,0x48,0x63,0xc9,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x02,0x48,0x8b,0x55,0x00,0x41,0x8b,0xcf,0xc1,0xe1,0x05,0x48,0x63,0xc9,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x0a,0xc5,0xfd,0xdb,0xc1,0xc5,0xfd,0x74,0xc8,0xc5,0xfd,0xef,0xc1,0x48,0x8d,0x54,0x24,0x20,0x48,0x8b,0x12,0x41,0x8b,0xcf,0xc1,0xe1,0x05,0x48,0x63,0xc9,0x48,0x03,0xd1,0xc5,0xfe,0x7f,0x02,0x41,0xff,0xc7,0x44,0x3b,0xf8,0x7c,0xad,0x49,0x8b,0xfe,0x48,0x8d,0x74,0x24,0x20,0xe8,0xa7,0xd5,0x83,0x5c,0x48,0xa5,0x48,0xa5,0x49,0x8b,0xc6,0xc5,0xf8,0x77,0x48,0x83,0xc4,0x38,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0x41,0x5f,0xc3};

        public static ReadOnlySpan<byte> nandヽgᐸ16uᐳᐤbg16uᕀinㆍbg16uᕀinᐤ  =>  new byte[193]{0x41,0x57,0x41,0x56,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x38,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x4c,0x8b,0xf1,0x48,0x8b,0xda,0x49,0x8b,0xe8,0x8b,0x53,0x10,0x44,0x8b,0x43,0x14,0x48,0x8d,0x4c,0x24,0x20,0x45,0x33,0xc9,0xe8,0x83,0xa1,0xff,0xff,0x8b,0x44,0x24,0x28,0x8b,0xd0,0xc1,0xfa,0x1f,0x83,0xe2,0x0f,0x03,0xc2,0xc1,0xf8,0x04,0x45,0x33,0xff,0x85,0xc0,0x7e,0x48,0x48,0x8b,0x55,0x00,0x48,0x8b,0x13,0x41,0x8b,0xcf,0xc1,0xe1,0x04,0x48,0x63,0xc9,0x48,0xd1,0xe1,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x02,0x48,0x8b,0x55,0x00,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x0a,0xc5,0xfd,0xdb,0xc1,0xc5,0xfd,0x75,0xc8,0xc5,0xfd,0xef,0xc1,0x48,0x8d,0x54,0x24,0x20,0x48,0x8b,0x12,0x48,0x03,0xd1,0xc5,0xfe,0x7f,0x02,0x41,0xff,0xc7,0x44,0x3b,0xf8,0x7c,0xbc,0x49,0x8b,0xfe,0x48,0x8d,0x74,0x24,0x20,0xe8,0xb6,0xd4,0x83,0x5c,0x48,0xa5,0x48,0xa5,0x49,0x8b,0xc6,0xc5,0xf8,0x77,0x48,0x83,0xc4,0x38,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0x41,0x5f,0xc3};

        public static ReadOnlySpan<byte> nandヽgᐸ32uᐳᐤbg32uᕀinㆍbg32uᕀinᐤ  =>  new byte[194]{0x41,0x57,0x41,0x56,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x38,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x4c,0x8b,0xf1,0x48,0x8b,0xda,0x49,0x8b,0xe8,0x8b,0x53,0x10,0x44,0x8b,0x43,0x14,0x48,0x8d,0x4c,0x24,0x20,0x45,0x33,0xc9,0xe8,0x83,0xa1,0xff,0xff,0x8b,0x44,0x24,0x28,0x8b,0xd0,0xc1,0xfa,0x1f,0x83,0xe2,0x07,0x03,0xc2,0xc1,0xf8,0x03,0x45,0x33,0xff,0x85,0xc0,0x7e,0x49,0x48,0x8b,0x55,0x00,0x48,0x8b,0x13,0x41,0x8b,0xcf,0xc1,0xe1,0x03,0x48,0x63,0xc9,0x48,0xc1,0xe1,0x02,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x02,0x48,0x8b,0x55,0x00,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x0a,0xc5,0xfd,0xdb,0xc1,0xc5,0xfd,0x76,0xc8,0xc5,0xfd,0xef,0xc1,0x48,0x8d,0x54,0x24,0x20,0x48,0x8b,0x12,0x48,0x03,0xd1,0xc5,0xfe,0x7f,0x02,0x41,0xff,0xc7,0x44,0x3b,0xf8,0x7c,0xbb,0x49,0x8b,0xfe,0x48,0x8d,0x74,0x24,0x20,0xe8,0xc5,0xd3,0x83,0x5c,0x48,0xa5,0x48,0xa5,0x49,0x8b,0xc6,0xc5,0xf8,0x77,0x48,0x83,0xc4,0x38,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0x41,0x5f,0xc3};

        public static ReadOnlySpan<byte> nandヽgᐸ64uᐳᐤbg64uᕀinㆍbg64uᕀinᐤ  =>  new byte[195]{0x41,0x57,0x41,0x56,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x38,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x4c,0x8b,0xf1,0x48,0x8b,0xda,0x49,0x8b,0xe8,0x8b,0x53,0x10,0x44,0x8b,0x43,0x14,0x48,0x8d,0x4c,0x24,0x20,0x45,0x33,0xc9,0xe8,0x93,0xa1,0xff,0xff,0x8b,0x44,0x24,0x28,0x8b,0xd0,0xc1,0xfa,0x1f,0x83,0xe2,0x03,0x03,0xc2,0xc1,0xf8,0x02,0x45,0x33,0xff,0x85,0xc0,0x7e,0x4a,0x48,0x8b,0x55,0x00,0x48,0x8b,0x13,0x41,0x8b,0xcf,0xc1,0xe1,0x02,0x48,0x63,0xc9,0x48,0xc1,0xe1,0x03,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x02,0x48,0x8b,0x55,0x00,0x48,0x03,0xd1,0xc5,0xff,0xf0,0x0a,0xc5,0xfd,0xdb,0xc1,0xc4,0xe2,0x7d,0x29,0xc8,0xc5,0xfd,0xef,0xc1,0x48,0x8d,0x54,0x24,0x20,0x48,0x8b,0x12,0x48,0x03,0xd1,0xc5,0xfe,0x7f,0x02,0x41,0xff,0xc7,0x44,0x3b,0xf8,0x7c,0xba,0x49,0x8b,0xfe,0x48,0x8d,0x74,0x24,0x20,0xe8,0xd4,0xd2,0x83,0x5c,0x48,0xa5,0x48,0xa5,0x49,0x8b,0xc6,0xc5,0xf8,0x77,0x48,0x83,0xc4,0x38,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0x41,0x5f,0xc3};

    }
}