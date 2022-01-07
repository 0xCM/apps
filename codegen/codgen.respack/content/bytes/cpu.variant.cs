﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2022-01-07 15:36:32 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class cpu_variant
    {
        public static ReadOnlySpan<byte> defineヽᐤ64uㆍNumericKindᕀ32uᐤ  =>  new byte[27]{0xc5,0xf8,0x77,0x66,0x90,0xc4,0xe1,0xf9,0x6e,0xc2,0x41,0x8b,0xc0,0xc4,0xe3,0xf9,0x22,0xc0,0x01,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> convertヽᐤvariantㆍNumericKindᕀ32uᐤ  =>  new byte[26]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0x41,0x8b,0xc0,0xc4,0xe3,0xf9,0x22,0xc0,0x01,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> scalarヽᐤEnumᐤ  =>  new byte[123]{0x57,0x56,0x53,0x48,0x83,0xec,0x20,0xc5,0xf8,0x77,0x48,0x8b,0xf1,0x48,0x8b,0xfa,0x48,0x8b,0xcf,0xe8,0xe8,0x36,0x7b,0x5b,0x48,0x8b,0xc8,0xe8,0x10,0x40,0xec,0x54,0x48,0x8b,0xc8,0xe8,0x28,0xfb,0xca,0xfd,0x8b,0xd8,0x48,0x8b,0xcf,0xba,0x40,0x00,0x40,0x20,0xe8,0x79,0x33,0xc1,0xfe,0x48,0x8b,0xf8,0x48,0xba,0x80,0xa6,0xd4,0x76,0xfd,0x7f,0x00,0x00,0x48,0x39,0x17,0x74,0x12,0x48,0x8b,0xd7,0x48,0xb9,0x80,0xa6,0xd4,0x76,0xfd,0x7f,0x00,0x00,0xe8,0x65,0x67,0x7e,0x5b,0x48,0x8b,0x47,0x08,0xc4,0xe1,0xf9,0x6e,0xc0,0x8b,0xc3,0xc4,0xe3,0xf9,0x22,0xc0,0x01,0xc5,0xf9,0x11,0x06,0x48,0x8b,0xc6,0x48,0x83,0xc4,0x20,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> defineヽᐤdynamicㆍTypeᐤ  =>  new byte[777]{0x57,0x56,0x48,0x83,0xec,0x28,0xc5,0xf8,0x77,0x48,0x8b,0xf9,0x48,0x8b,0xf2,0x49,0x8b,0xc8,0xe8,0x99,0xfa,0xca,0xfd,0x3d,0x20,0x00,0x00,0x42,0x77,0x48,0x3d,0x10,0x00,0x04,0x20,0x77,0x1b,0x3d,0x08,0x00,0x01,0x20,0x0f,0x84,0xb8,0x00,0x00,0x00,0x3d,0x10,0x00,0x04,0x20,0x0f,0x84,0x25,0x01,0x00,0x00,0xe9,0xb7,0x02,0x00,0x00,0x3d,0x20,0x00,0x10,0x20,0x0f,0x84,0x8b,0x01,0x00,0x00,0x3d,0x40,0x00,0x40,0x20,0x0f,0x84,0xf3,0x01,0x00,0x00,0x3d,0x20,0x00,0x00,0x42,0x0f,0x84,0x22,0x02,0x00,0x00,0xe9,0x91,0x02,0x00,0x00,0x3d,0x08,0x00,0x02,0x80,0x77,0x17,0x3d,0x40,0x00,0x00,0x44,0x0f,0x84,0x47,0x02,0x00,0x00,0x3d,0x08,0x00,0x02,0x80,0x74,0x2b,0xe9,0x73,0x02,0x00,0x00,0x3d,0x10,0x00,0x08,0x80,0x0f,0x84,0x93,0x00,0x00,0x00,0x3d,0x20,0x00,0x20,0x80,0x0f,0x84,0x00,0x01,0x00,0x00,0x3d,0x40,0x00,0x80,0x80,0x0f,0x84,0x6a,0x01,0x00,0x00,0xe9,0x4d,0x02,0x00,0x00,0x48,0xba,0x70,0x6f,0xd4,0x76,0xfd,0x7f,0x00,0x00,0x48,0x39,0x16,0x74,0x12,0x48,0x8b,0xd6,0x48,0xb9,0x70,0x6f,0xd4,0x76,0xfd,0x7f,0x00,0x00,0xe8,0x55,0x66,0x7e,0x5b,0x48,0x0f,0xbe,0x56,0x08,0x48,0x63,0xd2,0xc4,0xe1,0xf9,0x6e,0xc2,0xba,0x08,0x00,0x02,0x80,0xc4,0xe3,0xf9,0x22,0xc2,0x01,0xe9,0x13,0x02,0x00,0x00,0x48,0xba,0x60,0x77,0xd4,0x76,0xfd,0x7f,0x00,0x00,0x48,0x39,0x16,0x74,0x12,0x48,0x8b,0xd6,0x48,0xb9,0x60,0x77,0xd4,0x76,0xfd,0x7f,0x00,0x00,0xe8,0x17,0x66,0x7e,0x5b,0x0f,0xb6,0x56,0x08,0xc4,0xe1,0xf9,0x6e,0xc2,0xba,0x08,0x00,0x01,0x20,0xc4,0xe3,0xf9,0x22,0xc2,0x01,0xe9,0xd9,0x01,0x00,0x00,0x48,0xba,0x50,0x7f,0xd4,0x76,0xfd,0x7f,0x00,0x00,0x48,0x39,0x16,0x74,0x12,0x48,0x8b,0xd6,0x48,0xb9,0x50,0x7f,0xd4,0x76,0xfd,0x7f,0x00,0x00,0xe8,0xdd,0x65,0x7e,0x5b,0x48,0x0f,0xbf,0x56,0x08,0x48,0x63,0xd2,0xc4,0xe1,0xf9,0x6e,0xc2,0xba,0x10,0x00,0x08,0x80,0xc4,0xe3,0xf9,0x22,0xc2,0x01,0xe9,0x9b,0x01,0x00,0x00,0x48,0xba,0x40,0x87,0xd4,0x76,0xfd,0x7f,0x00,0x00,0x48,0x39,0x16,0x74,0x12,0x48,0x8b,0xd6,0x48,0xb9,0x40,0x87,0xd4,0x76,0xfd,0x7f,0x00,0x00,0xe8,0x9f,0x65,0x7e,0x5b,0x0f,0xb7,0x56,0x08,0xc4,0xe1,0xf9,0x6e,0xc2,0xba,0x10,0x00,0x04,0x20,0xc4,0xe3,0xf9,0x22,0xc2,0x01,0xe9,0x61,0x01,0x00,0x00,0x48,0xba,0x10,0x8f,0xd4,0x76,0xfd,0x7f,0x00,0x00,0x48,0x39,0x16,0x74,0x12,0x48,0x8b,0xd6,0x48,0xb9,0x10,0x8f,0xd4,0x76,0xfd,0x7f,0x00,0x00,0xe8,0x65,0x65,0x7e,0x5b,0x8b,0x56,0x08,0x48,0x63,0xd2,0xc4,0xe1,0xf9,0x6e,0xc2,0xba,0x20,0x00,0x20,0x80,0xc4,0xe3,0xf9,0x22,0xc2,0x01,0xe9,0x25,0x01,0x00,0x00,0x48,0xba,0xe0,0x96,0xd4,0x76,0xfd,0x7f,0x00,0x00,0x48,0x39,0x16,0x74,0x12,0x48,0x8b,0xd6,0x48,0xb9,0xe0,0x96,0xd4,0x76,0xfd,0x7f,0x00,0x00,0xe8,0x29,0x65,0x7e,0x5b,0x8b,0x56,0x08,0xc4,0xe1,0xf9,0x6e,0xc2,0xba,0x20,0x00,0x10,0x20,0xc4,0xe3,0xf9,0x22,0xc2,0x01,0xe9,0xec,0x00,0x00,0x00,0x48,0xba,0xb0,0x9e,0xd4,0x76,0xfd,0x7f,0x00,0x00,0x48,0x39,0x16,0x74,0x12,0x48,0x8b,0xd6,0x48,0xb9,0xb0,0x9e,0xd4,0x76,0xfd,0x7f,0x00,0x00,0xe8,0xf0,0x64,0x7e,0x5b,0x48,0x8b,0x56,0x08,0xc4,0xe1,0xf9,0x6e,0xc2,0xba,0x40,0x00,0x80,0x80,0xc4,0xe3,0xf9,0x22,0xc2,0x01,0xe9,0xb2,0x00,0x00,0x00,0x48,0xba,0x80,0xa6,0xd4,0x76,0xfd,0x7f,0x00,0x00,0x48,0x39,0x16,0x74,0x12,0x48,0x8b,0xd6,0x48,0xb9,0x80,0xa6,0xd4,0x76,0xfd,0x7f,0x00,0x00,0xe8,0xb6,0x64,0x7e,0x5b,0x48,0x8b,0x56,0x08,0xc4,0xe1,0xf9,0x6e,0xc2,0xba,0x40,0x00,0x40,0x20,0xc4,0xe3,0xf9,0x22,0xc2,0x01,0xe9,0x78,0x00,0x00,0x00,0x48,0xba,0x60,0xaf,0xd4,0x76,0xfd,0x7f,0x00,0x00,0x48,0x39,0x16,0x74,0x12,0x48,0x8b,0xd6,0x48,0xb9,0x60,0xaf,0xd4,0x76,0xfd,0x7f,0x00,0x00,0xe8,0x7c,0x64,0x7e,0x5b,0xc5,0xfa,0x10,0x46,0x08,0xc5,0xfa,0x5a,0xc0,0xc5,0xfb,0x12,0xc0,0xc5,0xfb,0x10,0x0d,0x5f,0x00,0x00,0x00,0xc5,0xf9,0x14,0xc1,0xeb,0x3c,0x48,0xba,0x40,0xb8,0xd4,0x76,0xfd,0x7f,0x00,0x00,0x48,0x39,0x16,0x74,0x12,0x48,0x8b,0xd6,0x48,0xb9,0x40,0xb8,0xd4,0x76,0xfd,0x7f,0x00,0x00,0xe8,0x40,0x64,0x7e,0x5b,0xc5,0xfb,0x10,0x46,0x08,0xc5,0xfb,0x12,0xc0,0xc5,0xfb,0x10,0x0d,0x2f,0x00,0x00,0x00,0xc5,0xf9,0x14,0xc1,0xeb,0x04,0xc5,0xf8,0x57,0xc0,0xc5,0xf9,0x11,0x07,0x48,0x8b,0xc7,0x48,0x83,0xc4,0x28,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> defineヽᐤdynamicㆍNumericKindᕀ32uᐤ  =>  new byte[865]{0x57,0x56,0x48,0x83,0xec,0x28,0xc5,0xf8,0x77,0x48,0x8b,0xf9,0x48,0x8b,0xf2,0x41,0x81,0xf8,0x20,0x00,0x00,0x42,0x77,0x54,0x41,0x81,0xf8,0x10,0x00,0x04,0x20,0x77,0x1f,0x41,0x81,0xf8,0x08,0x00,0x01,0x20,0x0f,0x84,0xd3,0x00,0x00,0x00,0x41,0x81,0xf8,0x10,0x00,0x04,0x20,0x0f,0x84,0x4c,0x01,0x00,0x00,0xe9,0x0f,0x03,0x00,0x00,0x41,0x81,0xf8,0x20,0x00,0x10,0x20,0x0f,0x84,0xbe,0x01,0x00,0x00,0x41,0x81,0xf8,0x40,0x00,0x40,0x20,0x0f,0x84,0x32,0x02,0x00,0x00,0x41,0x81,0xf8,0x20,0x00,0x00,0x42,0x0f,0x84,0x66,0x02,0x00,0x00,0xe9,0xe3,0x02,0x00,0x00,0x41,0x81,0xf8,0x08,0x00,0x02,0x80,0x77,0x1b,0x41,0x81,0xf8,0x40,0x00,0x00,0x44,0x0f,0x84,0x8e,0x02,0x00,0x00,0x41,0x81,0xf8,0x08,0x00,0x02,0x80,0x74,0x31,0xe9,0xbf,0x02,0x00,0x00,0x41,0x81,0xf8,0x10,0x00,0x08,0x80,0x0f,0x84,0xa5,0x00,0x00,0x00,0x41,0x81,0xf8,0x20,0x00,0x20,0x80,0x0f,0x84,0x1e,0x01,0x00,0x00,0x41,0x81,0xf8,0x40,0x00,0x80,0x80,0x0f,0x84,0x94,0x01,0x00,0x00,0xe9,0x93,0x02,0x00,0x00,0x48,0xba,0x70,0x6f,0xd4,0x76,0xfd,0x7f,0x00,0x00,0x48,0x39,0x16,0x74,0x12,0x48,0x8b,0xd6,0x48,0xb9,0x70,0x6f,0xd4,0x76,0xfd,0x7f,0x00,0x00,0xe8,0x03,0x63,0x7e,0x5b,0x48,0x0f,0xbe,0x56,0x08,0x48,0x63,0xd2,0xc4,0xe1,0xf9,0x6e,0xc2,0xba,0x08,0x00,0x02,0x80,0xc4,0xe3,0xf9,0x22,0xc2,0x01,0xc5,0xf9,0x11,0x07,0x48,0x8b,0xc7,0xe9,0x59,0x02,0x00,0x00,0x48,0xba,0x60,0x77,0xd4,0x76,0xfd,0x7f,0x00,0x00,0x48,0x39,0x16,0x74,0x12,0x48,0x8b,0xd6,0x48,0xb9,0x60,0x77,0xd4,0x76,0xfd,0x7f,0x00,0x00,0xe8,0xbe,0x62,0x7e,0x5b,0x0f,0xb6,0x56,0x08,0xc4,0xe1,0xf9,0x6e,0xc2,0xba,0x08,0x00,0x01,0x20,0xc4,0xe3,0xf9,0x22,0xc2,0x01,0xc5,0xf9,0x11,0x07,0x48,0x8b,0xc7,0xe9,0x18,0x02,0x00,0x00,0x48,0xba,0x50,0x7f,0xd4,0x76,0xfd,0x7f,0x00,0x00,0x48,0x39,0x16,0x74,0x12,0x48,0x8b,0xd6,0x48,0xb9,0x50,0x7f,0xd4,0x76,0xfd,0x7f,0x00,0x00,0xe8,0x7d,0x62,0x7e,0x5b,0x48,0x0f,0xbf,0x56,0x08,0x48,0x63,0xd2,0xc4,0xe1,0xf9,0x6e,0xc2,0xba,0x10,0x00,0x08,0x80,0xc4,0xe3,0xf9,0x22,0xc2,0x01,0xc5,0xf9,0x11,0x07,0x48,0x8b,0xc7,0xe9,0xd3,0x01,0x00,0x00,0x48,0xba,0x40,0x87,0xd4,0x76,0xfd,0x7f,0x00,0x00,0x48,0x39,0x16,0x74,0x12,0x48,0x8b,0xd6,0x48,0xb9,0x40,0x87,0xd4,0x76,0xfd,0x7f,0x00,0x00,0xe8,0x38,0x62,0x7e,0x5b,0x0f,0xb7,0x56,0x08,0xc4,0xe1,0xf9,0x6e,0xc2,0xba,0x10,0x00,0x04,0x20,0xc4,0xe3,0xf9,0x22,0xc2,0x01,0xc5,0xf9,0x11,0x07,0x48,0x8b,0xc7,0xe9,0x92,0x01,0x00,0x00,0x48,0xba,0x10,0x8f,0xd4,0x76,0xfd,0x7f,0x00,0x00,0x48,0x39,0x16,0x74,0x12,0x48,0x8b,0xd6,0x48,0xb9,0x10,0x8f,0xd4,0x76,0xfd,0x7f,0x00,0x00,0xe8,0xf7,0x61,0x7e,0x5b,0x8b,0x56,0x08,0x48,0x63,0xd2,0xc4,0xe1,0xf9,0x6e,0xc2,0xba,0x20,0x00,0x20,0x80,0xc4,0xe3,0xf9,0x22,0xc2,0x01,0xc5,0xf9,0x11,0x07,0x48,0x8b,0xc7,0xe9,0x4f,0x01,0x00,0x00,0x48,0xba,0xe0,0x96,0xd4,0x76,0xfd,0x7f,0x00,0x00,0x48,0x39,0x16,0x74,0x12,0x48,0x8b,0xd6,0x48,0xb9,0xe0,0x96,0xd4,0x76,0xfd,0x7f,0x00,0x00,0xe8,0xb4,0x61,0x7e,0x5b,0x8b,0x56,0x08,0xc4,0xe1,0xf9,0x6e,0xc2,0xba,0x20,0x00,0x10,0x20,0xc4,0xe3,0xf9,0x22,0xc2,0x01,0xc5,0xf9,0x11,0x07,0x48,0x8b,0xc7,0xe9,0x0f,0x01,0x00,0x00,0x48,0xba,0xb0,0x9e,0xd4,0x76,0xfd,0x7f,0x00,0x00,0x48,0x39,0x16,0x74,0x12,0x48,0x8b,0xd6,0x48,0xb9,0xb0,0x9e,0xd4,0x76,0xfd,0x7f,0x00,0x00,0xe8,0x74,0x61,0x7e,0x5b,0x48,0x8b,0x56,0x08,0xc4,0xe1,0xf9,0x6e,0xc2,0xba,0x40,0x00,0x80,0x80,0xc4,0xe3,0xf9,0x22,0xc2,0x01,0xc5,0xf9,0x11,0x07,0x48,0x8b,0xc7,0xe9,0xce,0x00,0x00,0x00,0x48,0xba,0x80,0xa6,0xd4,0x76,0xfd,0x7f,0x00,0x00,0x48,0x39,0x16,0x74,0x12,0x48,0x8b,0xd6,0x48,0xb9,0x80,0xa6,0xd4,0x76,0xfd,0x7f,0x00,0x00,0xe8,0x33,0x61,0x7e,0x5b,0x48,0x8b,0x56,0x08,0xc4,0xe1,0xf9,0x6e,0xc2,0xba,0x40,0x00,0x40,0x20,0xc4,0xe3,0xf9,0x22,0xc2,0x01,0xc5,0xf9,0x11,0x07,0x48,0x8b,0xc7,0xe9,0x8d,0x00,0x00,0x00,0x48,0xba,0x60,0xaf,0xd4,0x76,0xfd,0x7f,0x00,0x00,0x48,0x39,0x16,0x74,0x12,0x48,0x8b,0xd6,0x48,0xb9,0x60,0xaf,0xd4,0x76,0xfd,0x7f,0x00,0x00,0xe8,0xf2,0x60,0x7e,0x5b,0xc5,0xfa,0x10,0x46,0x08,0xc5,0xfa,0x5a,0xc0,0xc5,0xfb,0x12,0xc0,0xc5,0xfb,0x10,0x0d,0x75,0x00,0x00,0x00,0xc5,0xf9,0x14,0xc1,0xc5,0xf9,0x11,0x07,0x48,0x8b,0xc7,0xeb,0x4a,0x48,0xba,0x40,0xb8,0xd4,0x76,0xfd,0x7f,0x00,0x00,0x48,0x39,0x16,0x74,0x12,0x48,0x8b,0xd6,0x48,0xb9,0x40,0xb8,0xd4,0x76,0xfd,0x7f,0x00,0x00,0xe8,0xaf,0x60,0x7e,0x5b,0xc5,0xfb,0x10,0x46,0x08,0xc5,0xfb,0x12,0xc0,0xc5,0xfb,0x10,0x0d,0x3e,0x00,0x00,0x00,0xc5,0xf9,0x14,0xc1,0xc5,0xf9,0x11,0x07,0x48,0x8b,0xc7,0xeb,0x0b,0xc5,0xf8,0x57,0xc0,0xc5,0xf9,0x11,0x07,0x48,0x8b,0xc7,0x48,0x83,0xc4,0x28,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> defineヽᐤ8iᐤ  =>  new byte[36]{0xc5,0xf8,0x77,0x66,0x90,0x48,0x0f,0xbe,0xc2,0x48,0x63,0xc0,0xc4,0xe1,0xf9,0x6e,0xc0,0xb8,0x08,0x00,0x02,0x80,0xc4,0xe3,0xf9,0x22,0xc0,0x01,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> defineヽᐤ8uᐤ  =>  new byte[32]{0xc5,0xf8,0x77,0x66,0x90,0x0f,0xb6,0xc2,0xc4,0xe1,0xf9,0x6e,0xc0,0xb8,0x08,0x00,0x01,0x20,0xc4,0xe3,0xf9,0x22,0xc0,0x01,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> defineヽᐤ16iᐤ  =>  new byte[36]{0xc5,0xf8,0x77,0x66,0x90,0x48,0x0f,0xbf,0xc2,0x48,0x63,0xc0,0xc4,0xe1,0xf9,0x6e,0xc0,0xb8,0x10,0x00,0x08,0x80,0xc4,0xe3,0xf9,0x22,0xc0,0x01,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> defineヽᐤ16uᐤ  =>  new byte[32]{0xc5,0xf8,0x77,0x66,0x90,0x0f,0xb7,0xc2,0xc4,0xe1,0xf9,0x6e,0xc0,0xb8,0x10,0x00,0x04,0x20,0xc4,0xe3,0xf9,0x22,0xc0,0x01,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> defineヽᐤ32iᐤ  =>  new byte[32]{0xc5,0xf8,0x77,0x66,0x90,0x48,0x63,0xc2,0xc4,0xe1,0xf9,0x6e,0xc0,0xb8,0x20,0x00,0x20,0x80,0xc4,0xe3,0xf9,0x22,0xc0,0x01,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> defineヽᐤ32uᐤ  =>  new byte[31]{0xc5,0xf8,0x77,0x66,0x90,0x8b,0xc2,0xc4,0xe1,0xf9,0x6e,0xc0,0xb8,0x20,0x00,0x10,0x20,0xc4,0xe3,0xf9,0x22,0xc0,0x01,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> defineヽᐤ64iᐤ  =>  new byte[29]{0xc5,0xf8,0x77,0x66,0x90,0xc4,0xe1,0xf9,0x6e,0xc2,0xb8,0x40,0x00,0x80,0x80,0xc4,0xe3,0xf9,0x22,0xc0,0x01,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> defineヽᐤ64uᐤ  =>  new byte[29]{0xc5,0xf8,0x77,0x66,0x90,0xc4,0xe1,0xf9,0x6e,0xc2,0xb8,0x40,0x00,0x40,0x20,0xc4,0xe3,0xf9,0x22,0xc0,0x01,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> defineヽᐤ32fᐤ  =>  new byte[33]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfa,0x5a,0xc1,0xc5,0xfb,0x12,0xc0,0xc5,0xfb,0x10,0x0d,0x13,0x00,0x00,0x00,0xc5,0xf9,0x14,0xc1,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> defineヽᐤ64fᐤ  =>  new byte[29]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfb,0x12,0xc1,0xc5,0xfb,0x10,0x0d,0x17,0x00,0x00,0x00,0xc5,0xf9,0x14,0xc1,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> fromヽgᐸ8uᐳᐤ8uᐤ  =>  new byte[32]{0xc5,0xf8,0x77,0x66,0x90,0x0f,0xb6,0xc2,0xc4,0xe1,0xf9,0x6e,0xc0,0xb8,0x08,0x00,0x01,0x20,0xc4,0xe3,0xf9,0x22,0xc0,0x01,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> fromヽgᐸ8iᐳᐤ8iᐤ  =>  new byte[36]{0xc5,0xf8,0x77,0x66,0x90,0x48,0x0f,0xbe,0xc2,0x48,0x63,0xc0,0xc4,0xe1,0xf9,0x6e,0xc0,0xb8,0x08,0x00,0x02,0x80,0xc4,0xe3,0xf9,0x22,0xc0,0x01,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> fromヽgᐸ16uᐳᐤ16uᐤ  =>  new byte[32]{0xc5,0xf8,0x77,0x66,0x90,0x0f,0xb7,0xc2,0xc4,0xe1,0xf9,0x6e,0xc0,0xb8,0x10,0x00,0x04,0x20,0xc4,0xe3,0xf9,0x22,0xc0,0x01,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> fromヽgᐸ16iᐳᐤ16iᐤ  =>  new byte[36]{0xc5,0xf8,0x77,0x66,0x90,0x48,0x0f,0xbf,0xc2,0x48,0x63,0xc0,0xc4,0xe1,0xf9,0x6e,0xc0,0xb8,0x10,0x00,0x08,0x80,0xc4,0xe3,0xf9,0x22,0xc0,0x01,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> fromヽgᐸ32uᐳᐤ32uᐤ  =>  new byte[31]{0xc5,0xf8,0x77,0x66,0x90,0x8b,0xc2,0xc4,0xe1,0xf9,0x6e,0xc0,0xb8,0x20,0x00,0x10,0x20,0xc4,0xe3,0xf9,0x22,0xc0,0x01,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> fromヽgᐸ32iᐳᐤ32iᐤ  =>  new byte[32]{0xc5,0xf8,0x77,0x66,0x90,0x48,0x63,0xc2,0xc4,0xe1,0xf9,0x6e,0xc0,0xb8,0x20,0x00,0x20,0x80,0xc4,0xe3,0xf9,0x22,0xc0,0x01,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> fromヽgᐸ64uᐳᐤ64uᐤ  =>  new byte[29]{0xc5,0xf8,0x77,0x66,0x90,0xc4,0xe1,0xf9,0x6e,0xc2,0xb8,0x40,0x00,0x40,0x20,0xc4,0xe3,0xf9,0x22,0xc0,0x01,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> fromヽgᐸ64iᐳᐤ64iᐤ  =>  new byte[29]{0xc5,0xf8,0x77,0x66,0x90,0xc4,0xe1,0xf9,0x6e,0xc2,0xb8,0x40,0x00,0x80,0x80,0xc4,0xe3,0xf9,0x22,0xc0,0x01,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> fromヽgᐸ32fᐳᐤ32fᐤ  =>  new byte[34]{0xc5,0xf8,0x77,0x66,0x90,0xc4,0xe1,0xfa,0x2c,0xc1,0xc4,0xe1,0xf9,0x6e,0xc0,0xb8,0x20,0x00,0x00,0x42,0xc4,0xe3,0xf9,0x22,0xc0,0x01,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> fromヽgᐸ64fᐳᐤ64fᐤ  =>  new byte[34]{0xc5,0xf8,0x77,0x66,0x90,0xc4,0xe1,0xfb,0x2c,0xc1,0xc4,0xe1,0xf9,0x6e,0xc0,0xb8,0x40,0x00,0x00,0x44,0xc4,0xe3,0xf9,0x22,0xc0,0x01,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

    }
}
