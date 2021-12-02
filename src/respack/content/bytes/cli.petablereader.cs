﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2021-12-01 21:34:45 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class cli_petablereader
    {
        public static ReadOnlySpan<byte> coverヽᐤPeStreamᐤ  =>  new byte[89]{0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x28,0x48,0x8b,0xf1,0x48,0xb9,0xc0,0x27,0x93,0x78,0xfd,0x7f,0x00,0x00,0xe8,0xd6,0xe5,0x7b,0x5b,0x48,0x8b,0xf8,0x48,0x8b,0x16,0x48,0x8b,0x5e,0x08,0x48,0x8b,0x76,0x10,0x48,0x8d,0x6f,0x08,0x48,0x8d,0x4d,0x00,0xe8,0xcb,0xd6,0x7b,0x5b,0x48,0x8d,0x4d,0x08,0x48,0x8b,0xd3,0xe8,0xbf,0xd6,0x7b,0x5b,0x48,0x8d,0x4d,0x10,0x48,0x8b,0xd6,0xe8,0xb3,0xd6,0x7b,0x5b,0x48,0x8b,0xc7,0x48,0x83,0xc4,0x28,0x5b,0x5d,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> openヽᐤFilePathᐤ  =>  new byte[219]{0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x48,0x33,0xc0,0x48,0x89,0x44,0x24,0x40,0x48,0x89,0x4c,0x24,0x40,0x48,0x8d,0x4c,0x24,0x40,0xe8,0xa2,0xf6,0xc9,0xfb,0x48,0x8b,0xf0,0x48,0xb9,0x70,0xe5,0xf7,0x76,0xfd,0x7f,0x00,0x00,0xe8,0x70,0x44,0x6d,0x5b,0x48,0x8b,0xf8,0x48,0x8b,0xd6,0xc7,0x44,0x24,0x20,0x01,0x00,0x00,0x00,0xc7,0x44,0x24,0x28,0x00,0x10,0x00,0x00,0x33,0xc9,0x89,0x4c,0x24,0x30,0x48,0x8b,0xcf,0x41,0xb8,0x03,0x00,0x00,0x00,0x41,0xb9,0x01,0x00,0x00,0x00,0xe8,0xa0,0x58,0xe3,0x54,0x48,0xb9,0xb8,0xbe,0x92,0x78,0xfd,0x7f,0x00,0x00,0xe8,0x01,0xe5,0x7b,0x5b,0x48,0x8b,0xf0,0x48,0x8b,0xce,0x48,0x8b,0xd7,0x45,0x33,0xc0,0x45,0x33,0xc9,0xe8,0x95,0x09,0x6f,0xfd,0x48,0x8b,0xce,0xba,0x01,0x00,0x00,0x00,0x45,0x33,0xc0,0xe8,0x05,0xef,0xff,0xff,0x48,0x8b,0xd8,0x48,0xb9,0xc0,0x27,0x93,0x78,0xfd,0x7f,0x00,0x00,0xe8,0xcb,0xe4,0x7b,0x5b,0x48,0x8b,0xe8,0x48,0x8b,0xd6,0x48,0x8d,0x75,0x08,0x48,0x8d,0x0e,0xe8,0xc9,0xd5,0x7b,0x5b,0x48,0x8d,0x4e,0x08,0x48,0x8b,0xd7,0xe8,0xbd,0xd5,0x7b,0x5b,0x48,0x8d,0x4e,0x10,0x48,0x8b,0xd3,0xe8,0xb1,0xd5,0x7b,0x5b,0x48,0x8b,0xc5,0x48,0x83,0xc4,0x48,0x5b,0x5d,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> offsetヽᐤMetadataReaderㆍUserStringHandleᐤ  =>  new byte[70]{0x48,0x83,0xec,0x38,0x90,0x33,0xc0,0x89,0x44,0x24,0x28,0xc6,0x44,0x24,0x2c,0x00,0xc6,0x44,0x24,0x2c,0x70,0x89,0x54,0x24,0x28,0x48,0x8b,0x54,0x24,0x28,0x48,0x89,0x54,0x24,0x30,0x48,0x8d,0x54,0x24,0x20,0x8b,0x44,0x24,0x30,0x89,0x02,0x0f,0xb6,0x44,0x24,0x34,0x88,0x42,0x04,0x48,0x8b,0x54,0x24,0x20,0xe8,0xd0,0x86,0xfd,0xff,0x90,0x48,0x83,0xc4,0x38,0xc3};

        public static ReadOnlySpan<byte> saveヽᐤrspanFieldOffsetㆍFilePathᐤ  =>  new byte[601]{0x55,0x41,0x56,0x57,0x56,0x53,0x48,0x83,0xec,0x60,0x48,0x8d,0xac,0x24,0x80,0x00,0x00,0x00,0x33,0xc0,0x48,0x89,0x45,0xd8,0x48,0x89,0x45,0xc0,0x48,0x89,0x45,0xc8,0x48,0x89,0x45,0xd0,0x48,0x89,0x65,0xa8,0x48,0x8b,0xf1,0x48,0x8b,0xca,0x48,0xb8,0x20,0x18,0x4d,0x73,0xd5,0x01,0x00,0x00,0x48,0x8b,0x38,0xe8,0x70,0x71,0xb2,0xfe,0x48,0x89,0x45,0xd8,0x48,0x8d,0x4d,0xd8,0xe8,0x13,0xf5,0xc9,0xfb,0x48,0x8b,0xd8,0x8b,0x0b,0x48,0xb9,0x08,0xb1,0x62,0x78,0xfd,0x7f,0x00,0x00,0xe8,0xaf,0xe3,0x7b,0x5b,0x4c,0x8b,0xf0,0x48,0x8b,0xcb,0xba,0x02,0x00,0x00,0x00,0xe8,0x1f,0xf7,0xe6,0x54,0x48,0x8b,0xc8,0x4c,0x8b,0xc7,0x33,0xd2,0x41,0xb9,0x00,0x04,0x00,0x00,0xe8,0x1c,0x80,0xe4,0x54,0x48,0x8b,0xd0,0x33,0xc9,0x89,0x4c,0x24,0x20,0x49,0x8b,0xce,0x4c,0x8b,0xc7,0x41,0xb9,0x00,0x04,0x00,0x00,0xe8,0x02,0xd6,0xe2,0x54,0x4c,0x89,0x75,0xb8,0x48,0xb9,0x08,0x21,0x96,0x78,0xfd,0x7f,0x00,0x00,0xe8,0xdf,0x20,0x75,0x5b,0x8b,0x10,0x33,0xd2,0x89,0x54,0x24,0x20,0x48,0x8d,0x55,0xc0,0x48,0x8b,0xc8,0x45,0x33,0xc0,0x41,0xb9,0x74,0x00,0x00,0x00,0xe8,0x12,0xa4,0xe7,0x54,0x48,0x8d,0x4d,0xc0,0x48,0xba,0x18,0x74,0xf6,0x77,0xfd,0x7f,0x00,0x00,0xe8,0x5f,0xfd,0xeb,0x54,0x48,0x8b,0xf8,0x48,0xb9,0x40,0x75,0xcf,0x77,0xfd,0x7f,0x00,0x00,0xba,0x2f,0x01,0x00,0x00,0xe8,0x18,0xe7,0x7b,0x5b,0x48,0xb9,0xf0,0xf0,0x4f,0x73,0xd5,0x01,0x00,0x00,0x4c,0x8b,0x01,0x4d,0x85,0xc0,0x75,0x60,0x48,0xb9,0x70,0xba,0x48,0x7b,0xfd,0x7f,0x00,0x00,0xe8,0xf7,0xe2,0x7b,0x5b,0x48,0x8b,0xd8,0x48,0xba,0xe8,0xf0,0x4f,0x73,0xd5,0x01,0x00,0x00,0x48,0x8b,0x12,0x48,0x85,0xd2,0x74,0x2e,0x48,0x8d,0x4b,0x08,0xe8,0x19,0xd4,0x7b,0x5b,0x48,0xba,0x30,0x03,0x7e,0x78,0xfd,0x7f,0x00,0x00,0x48,0x89,0x53,0x18,0x48,0xb9,0xf0,0xf0,0x4f,0x73,0xd5,0x01,0x00,0x00,0x48,0x8b,0xd3,0xe8,0xc9,0xd3,0x7b,0x5b,0x4c,0x8b,0xc3,0xeb,0x0e,0x48,0x8b,0xcb,0xe8,0x1c,0xa6,0xc8,0xfb,0xcc,0xe8,0x06,0x67,0x8e,0x5b,0x48,0x8b,0xd7,0x48,0xb9,0x78,0xbb,0x48,0x7b,0xfd,0x7f,0x00,0x00,0xe8,0x14,0xc1,0xcb,0xfb,0x44,0x8b,0x48,0x08,0x41,0x83,0xf9,0x01,0x76,0xdf,0x4c,0x8b,0x48,0x18,0x4c,0x8b,0x40,0x10,0x48,0xba,0x20,0x3b,0x5d,0x73,0xd5,0x01,0x00,0x00,0x48,0x8b,0x12,0x48,0xb9,0xc0,0xb9,0x48,0x7b,0xfd,0x7f,0x00,0x00,0xe8,0xc6,0xac,0xff,0xff,0x48,0x8b,0xd0,0x48,0x8b,0x4d,0xb8,0xe8,0xba,0x90,0xe6,0x54,0x33,0xdb,0x8b,0x56,0x08,0x48,0x63,0xd2,0x48,0x85,0xd2,0x7e,0x4b,0x48,0x8b,0x16,0x4c,0x63,0xcb,0x49,0xc1,0xe1,0x04,0x49,0x03,0xd1,0x4c,0x8b,0x02,0x4c,0x8b,0x4a,0x08,0x48,0xba,0x20,0x3b,0x5d,0x73,0xd5,0x01,0x00,0x00,0x48,0x8b,0x12,0x48,0xb9,0xb0,0xbe,0x48,0x7b,0xfd,0x7f,0x00,0x00,0xe8,0xe5,0xec,0xff,0xff,0x48,0x8b,0xd0,0x48,0x8b,0x4d,0xb8,0xe8,0x71,0x90,0xe6,0x54,0xff,0xc3,0x8b,0xcb,0x8b,0x46,0x08,0x48,0x63,0xc0,0x48,0x3b,0xc8,0x7c,0xb5,0x48,0x8b,0x4d,0xb8,0xe8,0x79,0x65,0xe8,0x54,0x90,0x48,0x8d,0x65,0xe0,0x5b,0x5e,0x5f,0x41,0x5e,0x5d,0xc3,0x55,0x41,0x56,0x57,0x56,0x53,0x48,0x83,0xec,0x30,0x48,0x8b,0x69,0x28,0x48,0x89,0x6c,0x24,0x28,0x48,0x8d,0xad,0x80,0x00,0x00,0x00,0x48,0x83,0x7d,0xb8,0x00,0x74,0x09,0x48,0x8b,0x4d,0xb8,0xe8,0x43,0x65,0xe8,0x54,0x90,0x48,0x83,0xc4,0x30,0x5b,0x5e,0x5f,0x41,0x5e,0x5d,0xc3};

        public static ReadOnlySpan<byte> ConstantCountヽᐤPeStreamᕀinᐤ  =>  new byte[27]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x49,0x10,0xba,0x0b,0x00,0x00,0x00,0x48,0xb8,0xa8,0xfc,0x0d,0x7b,0xfd,0x7f,0x00,0x00,0x48,0xff,0xe0};

    }
}
