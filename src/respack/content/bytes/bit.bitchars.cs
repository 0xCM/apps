﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2021-12-01 21:34:44 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class bit_bitchars
    {
        public static ReadOnlySpan<byte> get_SectionSepヽᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x7c,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> get_SegSepヽᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x20,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> get_LeftFenceヽᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x5b,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> get_RightFenceヽᐤᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x5d,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> fromヽᐤbitᐤ  =>  new byte[28]{0x0f,0x1f,0x44,0x00,0x00,0x84,0xc9,0x75,0x07,0xb8,0x30,0x00,0x00,0x00,0xeb,0x05,0xb8,0x31,0x00,0x00,0x00,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> renderヽᐤBitCharᐤ  =>  new byte[9]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc1,0xc3};

        public static ReadOnlySpan<byte> kindヽᐤBitCharIndexᕀ8uᐤ  =>  new byte[25]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc1,0x48,0x63,0xc0,0x48,0xba,0x18,0x88,0x48,0x7f,0xd5,0x01,0x00,0x00,0x48,0x03,0xc2,0xc3};

        public static ReadOnlySpan<byte> renderヽᐤrspanBitCharㆍspancharᐤ  =>  new byte[72]{0x56,0x0f,0x1f,0x40,0x00,0x8b,0x41,0x08,0x44,0x8b,0x42,0x08,0x41,0x3b,0xc0,0x7c,0x02,0xeb,0x03,0x44,0x8b,0xc0,0x33,0xc0,0x45,0x8b,0xc8,0x4d,0x85,0xc9,0x7e,0x23,0x4c,0x8b,0x12,0x4c,0x63,0xd8,0x4f,0x8d,0x14,0x5a,0x4c,0x8b,0x19,0x48,0x63,0xf0,0x45,0x0f,0xb6,0x1c,0x33,0x66,0x45,0x89,0x1a,0xff,0xc0,0x4c,0x63,0xd0,0x4d,0x3b,0xd1,0x7c,0xdd,0x41,0x8b,0xc0,0x5e,0xc3};

        public static ReadOnlySpan<byte> formatヽᐤrspanBitCharᐤ  =>  new byte[234]{0x55,0x48,0x83,0xec,0x40,0x48,0x8d,0x6c,0x24,0x20,0x33,0xc0,0x48,0x89,0x45,0x10,0x48,0x89,0x45,0x18,0x48,0x89,0x45,0x08,0x48,0xb8,0x7e,0x62,0x5f,0xcc,0xf9,0x8c,0x00,0x00,0x48,0x89,0x45,0x08,0x44,0x8b,0x41,0x08,0x41,0x8b,0xc0,0x41,0xb9,0x02,0x00,0x00,0x00,0x49,0xf7,0xe1,0x0f,0x82,0x9d,0x00,0x00,0x00,0x48,0x8b,0xd0,0x48,0x85,0xd2,0x74,0x1e,0x48,0x83,0xc2,0x0f,0x48,0xc1,0xea,0x04,0x48,0x83,0xc4,0x20,0x6a,0x00,0x6a,0x00,0x48,0xff,0xca,0x75,0xf7,0x48,0x83,0xec,0x20,0x48,0x8d,0x54,0x24,0x20,0x45,0x85,0xc0,0x7c,0x77,0x48,0x8b,0x01,0x8b,0x49,0x08,0x45,0x8b,0xc8,0x41,0x3b,0xc9,0x7c,0x05,0x45,0x8b,0xc8,0xeb,0x03,0x44,0x8b,0xc9,0x33,0xc9,0x45,0x8b,0xd1,0x4d,0x85,0xd2,0x7e,0x20,0x4c,0x63,0xd1,0x4e,0x8d,0x14,0x52,0x4c,0x63,0xd9,0x46,0x0f,0xb6,0x1c,0x18,0x66,0x45,0x89,0x1a,0xff,0xc1,0x4c,0x63,0xd1,0x45,0x8b,0xd9,0x4d,0x3b,0xd3,0x7c,0xe0,0x48,0x8d,0x4d,0x10,0x48,0x89,0x11,0x44,0x89,0x41,0x08,0x48,0x8d,0x55,0x10,0x33,0xc9,0xe8,0x0b,0x0a,0xad,0xfc,0x48,0xb9,0x7e,0x62,0x5f,0xcc,0xf9,0x8c,0x00,0x00,0x48,0x39,0x4d,0x08,0x74,0x05,0xe8,0x9e,0xd9,0x72,0x5c,0x90,0x48,0x8d,0x65,0x20,0x5d,0xc3,0xe8,0x62,0xbf,0x72,0x5c,0xe8,0x55,0xf8,0xae,0xfc,0xcc,0x19,0x0a,0x03,0x25,0x0a,0x03};

        public static ReadOnlySpan<byte> textヽᐤn0ᐤ  =>  new byte[19]{0x0f,0x1f,0x44,0x00,0x00,0x48,0xb8,0x30,0x96,0x4d,0x73,0xd5,0x01,0x00,0x00,0x48,0x8b,0x00,0xc3};

        public static ReadOnlySpan<byte> textヽᐤn1ᐤ  =>  new byte[19]{0x0f,0x1f,0x44,0x00,0x00,0x48,0xb8,0x30,0x96,0x4d,0x73,0xd5,0x01,0x00,0x00,0x48,0x8b,0x00,0xc3};

        public static ReadOnlySpan<byte> textヽᐤn2ᐤ  =>  new byte[19]{0x0f,0x1f,0x44,0x00,0x00,0x48,0xb8,0xb0,0x1b,0x5e,0x73,0xd5,0x01,0x00,0x00,0x48,0x8b,0x00,0xc3};

        public static ReadOnlySpan<byte> textヽᐤn3ᐤ  =>  new byte[19]{0x0f,0x1f,0x44,0x00,0x00,0x48,0xb8,0x98,0x12,0x5e,0x73,0xd5,0x01,0x00,0x00,0x48,0x8b,0x00,0xc3};

        public static ReadOnlySpan<byte> textヽᐤn4ᐤ  =>  new byte[19]{0x0f,0x1f,0x44,0x00,0x00,0x48,0xb8,0x80,0x13,0x5e,0x73,0xd5,0x01,0x00,0x00,0x48,0x8b,0x00,0xc3};

        public static ReadOnlySpan<byte> textヽᐤn5ᐤ  =>  new byte[19]{0x0f,0x1f,0x44,0x00,0x00,0x48,0xb8,0x88,0x13,0x5e,0x73,0xd5,0x01,0x00,0x00,0x48,0x8b,0x00,0xc3};

        public static ReadOnlySpan<byte> textヽᐤn6ᐤ  =>  new byte[19]{0x0f,0x1f,0x44,0x00,0x00,0x48,0xb8,0x98,0x12,0x5e,0x73,0xd5,0x01,0x00,0x00,0x48,0x8b,0x00,0xc3};

        public static ReadOnlySpan<byte> formatヽᐤBitCharᐤ  =>  new byte[151]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc1,0x83,0xf8,0x31,0x77,0x11,0x83,0xf8,0x20,0x74,0x4a,0x83,0xf8,0x30,0x74,0x18,0x83,0xf8,0x31,0x74,0x22,0xeb,0x6b,0x83,0xf8,0x5b,0x74,0x48,0x83,0xf8,0x5d,0x74,0x52,0x83,0xf8,0x7c,0x74,0x20,0xeb,0x5a,0x48,0xb8,0x30,0x96,0x4d,0x73,0xd5,0x01,0x00,0x00,0x48,0x8b,0x00,0xeb,0x58,0x48,0xb8,0x30,0x96,0x4d,0x73,0xd5,0x01,0x00,0x00,0x48,0x8b,0x00,0xeb,0x49,0x48,0xb8,0xb0,0x1b,0x5e,0x73,0xd5,0x01,0x00,0x00,0x48,0x8b,0x00,0xeb,0x3a,0x48,0xb8,0x98,0x12,0x5e,0x73,0xd5,0x01,0x00,0x00,0x48,0x8b,0x00,0xeb,0x2b,0x48,0xb8,0x80,0x13,0x5e,0x73,0xd5,0x01,0x00,0x00,0x48,0x8b,0x00,0xeb,0x1c,0x48,0xb8,0x88,0x13,0x5e,0x73,0xd5,0x01,0x00,0x00,0x48,0x8b,0x00,0xeb,0x0d,0x48,0xb8,0x98,0x12,0x5e,0x73,0xd5,0x01,0x00,0x00,0x48,0x8b,0x00,0xc3};

        public static ReadOnlySpan<byte> blockヽgᐸ8uᐳᐤ8uᐤ  =>  new byte[12]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc1,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> blockヽgᐸ16uᐳᐤ16uᐤ  =>  new byte[12]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb7,0xc1,0x0f,0xb7,0xc0,0xc3};

        public static ReadOnlySpan<byte> blockヽgᐸ32uᐳᐤ32uᐤ  =>  new byte[8]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> blockヽgᐸ64uᐳᐤ64uᐤ  =>  new byte[9]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0xc1,0xc3};

    }
}
