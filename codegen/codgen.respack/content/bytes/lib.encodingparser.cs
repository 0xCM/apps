﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2022-01-07 15:36:29 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class lib_encodingparser
    {
        public static ReadOnlySpan<byte> Parseヽᐤrspan8uᐤ  =>  new byte[97]{0x41,0x56,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x20,0x48,0x8b,0xf1,0x48,0x8b,0x3a,0x8b,0x5a,0x08,0x48,0x8b,0xce,0xe8,0xfd,0x41,0x81,0xfe,0x33,0xed,0x85,0xdb,0x7e,0x25,0xeb,0x1d,0x8d,0x55,0x01,0x44,0x8b,0xf2,0x48,0x63,0xd5,0x0f,0xb6,0x14,0x17,0x48,0x8b,0xce,0xe8,0xf0,0x41,0x81,0xfe,0x44,0x3b,0xf3,0x41,0x8b,0xee,0x7d,0x06,0xf6,0x46,0x0c,0x06,0x74,0xdd,0x83,0x7e,0x0c,0x01,0x75,0x07,0xc7,0x46,0x0c,0x08,0x00,0x00,0x00,0x8b,0x46,0x0c,0x48,0x83,0xc4,0x20,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0xc3};

        public static ReadOnlySpan<byte> Parseヽᐤ8uᐤ  =>  new byte[106]{0x56,0x48,0x83,0xec,0x20,0x48,0x8b,0xf1,0x83,0x7e,0x0c,0x01,0x75,0x53,0x44,0x8b,0x46,0x08,0x41,0x8b,0xc8,0x48,0x8d,0x46,0x18,0x4c,0x8b,0xc8,0x45,0x8b,0x49,0x08,0x41,0x3b,0xc9,0x7d,0x3c,0x48,0x8b,0x08,0x41,0x8d,0x40,0x01,0x89,0x46,0x08,0x4d,0x63,0xc0,0x42,0x88,0x14,0x01,0x4c,0x8d,0x46,0x10,0x48,0x8b,0xce,0x48,0x8b,0xd6,0xe8,0x1b,0x41,0x81,0xfe,0x85,0xc0,0x74,0x18,0x48,0x8b,0x06,0x48,0x85,0xc0,0x74,0x09,0xc7,0x46,0x0c,0x04,0x00,0x00,0x00,0xeb,0x07,0xc7,0x46,0x0c,0x02,0x00,0x00,0x00,0x8b,0x46,0x0c,0x48,0x83,0xc4,0x20,0x5e,0xc3};

        public static ReadOnlySpan<byte> TryMatchヽᐤEncodingPatternKindᕀ64iᕀoutㆍ32iᕀoutᐤ  =>  new byte[274]{0x41,0x57,0x41,0x56,0x41,0x55,0x41,0x54,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x38,0x33,0xc0,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x48,0x8b,0xf1,0x48,0x8b,0xfa,0x49,0x8b,0xd8,0x33,0xc9,0x48,0x89,0x0f,0x89,0x0b,0x48,0x8d,0x6e,0x28,0x48,0x8b,0xcd,0x48,0x8b,0x09,0x48,0x85,0xc9,0x75,0x05,0x45,0x33,0xf6,0xeb,0x07,0x4c,0x8d,0x71,0x10,0x8b,0x49,0x08,0x45,0x33,0xff,0xeb,0x6c,0x49,0x63,0xcf,0x4d,0x8b,0x24,0xce,0x48,0x8b,0xcd,0x48,0x8d,0x54,0x24,0x28,0x4d,0x8b,0xc4,0xe8,0xf5,0x39,0x81,0xfe,0x44,0x8b,0x44,0x24,0x30,0x44,0x39,0x46,0x08,0x7f,0x05,0x45,0x33,0xed,0xeb,0x3a,0x48,0x8d,0x4e,0x18,0x8b,0x56,0x08,0xff,0xca,0x41,0x2b,0xd0,0x8b,0xc2,0x45,0x8b,0xc0,0x4c,0x03,0xc0,0x8b,0x41,0x08,0x4c,0x3b,0xc0,0x77,0x6b,0x48,0x8b,0x09,0x4c,0x63,0xc2,0x49,0x03,0xc8,0x48,0x8b,0x54,0x24,0x28,0x44,0x8b,0x44,0x24,0x30,0x4d,0x63,0xc0,0xe8,0x56,0x00,0x35,0xfd,0x44,0x8b,0xe8,0x41,0x0f,0xb6,0xc5,0x85,0xc0,0x75,0x1f,0x41,0xff,0xc7,0x48,0x8b,0xcd,0x44,0x3b,0x79,0x08,0x7c,0x8b,0x33,0xc0,0x48,0x83,0xc4,0x38,0x5b,0x5d,0x5e,0x5f,0x41,0x5c,0x41,0x5d,0x41,0x5e,0x41,0x5f,0xc3,0x4c,0x89,0x27,0x48,0x8b,0xcd,0x49,0x8b,0xd4,0xe8,0x7e,0x39,0x81,0xfe,0x89,0x03,0xb8,0x01,0x00,0x00,0x00,0x48,0x83,0xc4,0x38,0x5b,0x5d,0x5e,0x5f,0x41,0x5c,0x41,0x5d,0x41,0x5e,0x41,0x5f,0xc3,0xe8,0x89,0x60,0x35,0xfd,0xcc,0x19,0x10,0x09,0x00,0x10,0x62,0x0c,0x30,0x0b,0x50,0x0a,0x60,0x09,0x70,0x08,0xc0,0x06,0xd0};

    }
}
