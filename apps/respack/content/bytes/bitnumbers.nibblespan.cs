﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2021-11-14 3:49:56 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class bitnumbers_nibblespan
    {
        public static ReadOnlySpan<byte> fromヽᐤspan8uᐤ  =>  new byte[72]{0x57,0x56,0x53,0x48,0x83,0xec,0x10,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x04,0x24,0x48,0x8b,0xd9,0x48,0x8d,0x04,0x24,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x00,0x48,0x8b,0x02,0x8b,0x52,0x08,0x48,0x8d,0x0c,0x24,0x48,0x89,0x01,0x89,0x51,0x08,0x48,0x8b,0xfb,0x48,0x8d,0x34,0x24,0xe8,0x55,0x6f,0x1a,0x5b,0x48,0xa5,0x48,0x8b,0xc3,0x48,0x83,0xc4,0x10,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> countヽᐤNibbleSpanᕀinᐤ  =>  new byte[20]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0x41,0x08,0x48,0x63,0xc0,0x48,0xc1,0xe0,0x03,0x48,0xc1,0xe8,0x02,0xc3};

        public static ReadOnlySpan<byte> readヽᐤNibbleSpanᕀinㆍ32uᐤ  =>  new byte[169]{0x48,0x83,0xec,0x18,0x33,0xc0,0x48,0x89,0x44,0x24,0x10,0x33,0xc0,0x89,0x44,0x24,0x08,0xc6,0x44,0x24,0x0c,0x00,0xc6,0x44,0x24,0x0d,0x00,0x66,0xc7,0x44,0x24,0x0e,0x00,0x00,0x66,0xc7,0x44,0x24,0x0e,0x04,0x00,0x8b,0xc2,0x48,0x8b,0xd0,0x48,0xc1,0xea,0x3f,0x48,0x03,0xc2,0x48,0xd1,0xf8,0x48,0xf7,0xd8,0x89,0x44,0x24,0x08,0xc6,0x44,0x24,0x0c,0xfe,0x8b,0x44,0x24,0x08,0x48,0x8b,0xd0,0x48,0xc1,0xea,0x3f,0x48,0x03,0xd0,0x48,0x83,0xe2,0xfe,0x48,0x2b,0xc2,0x0f,0xb6,0xc0,0x88,0x44,0x24,0x0d,0x48,0x8b,0x44,0x24,0x08,0x48,0x89,0x44,0x24,0x10,0x48,0x8b,0x11,0x8b,0x4c,0x24,0x10,0x4c,0x63,0xc1,0x49,0x03,0xd0,0x80,0x7c,0x24,0x15,0x00,0x74,0x1d,0x0f,0xb6,0x02,0x8b,0x4c,0x24,0x16,0x0f,0xb7,0xc9,0x0f,0xb6,0xc9,0xd3,0xf8,0x0f,0xb6,0xc0,0x83,0xe0,0x0f,0x0f,0xb6,0xc0,0x48,0x83,0xc4,0x18,0xc3,0x0f,0xb6,0x02,0x83,0xe0,0x0f,0x0f,0xb6,0xc0,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> writeヽᐤuint4ㆍ32uㆍNibbleSpanᕀinᐤ  =>  new byte[188]{0x48,0x83,0xec,0x18,0x33,0xc0,0x48,0x89,0x44,0x24,0x10,0x33,0xc0,0x89,0x44,0x24,0x08,0xc6,0x44,0x24,0x0c,0x00,0xc6,0x44,0x24,0x0d,0x00,0x66,0xc7,0x44,0x24,0x0e,0x00,0x00,0x66,0xc7,0x44,0x24,0x0e,0x04,0x00,0x8b,0xc2,0x48,0x8b,0xd0,0x48,0xc1,0xea,0x3f,0x48,0x03,0xc2,0x48,0xd1,0xf8,0x48,0xf7,0xd8,0x89,0x44,0x24,0x08,0xc6,0x44,0x24,0x0c,0xfe,0x8b,0x44,0x24,0x08,0x48,0x8b,0xd0,0x48,0xc1,0xea,0x3f,0x48,0x03,0xd0,0x48,0x83,0xe2,0xfe,0x48,0x2b,0xc2,0x0f,0xb6,0xc0,0x88,0x44,0x24,0x0d,0x48,0x8b,0x44,0x24,0x08,0x48,0x89,0x44,0x24,0x10,0x49,0x8b,0x00,0x8b,0x54,0x24,0x10,0x48,0x63,0xd2,0x48,0x03,0xc2,0x80,0x7c,0x24,0x15,0x00,0x75,0x18,0x0f,0xb6,0x10,0x81,0xe2,0xf0,0x00,0x00,0x00,0x0f,0xb6,0xd2,0x0f,0xb6,0xc9,0x0b,0xca,0x88,0x08,0x48,0x83,0xc4,0x18,0xc3,0x8b,0x54,0x24,0x16,0x0f,0xb7,0xd2,0x0f,0xb6,0xd2,0x44,0x0f,0xb6,0xc1,0x8b,0xca,0x41,0xd3,0xe0,0x41,0x0f,0xb6,0xd0,0x0f,0xb6,0x08,0x83,0xe1,0x0f,0x0b,0xd1,0x88,0x10,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> get_Sizeヽᐤᐤ  =>  new byte[12]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0x41,0x08,0x48,0x63,0xc0,0xc3};

        public static ReadOnlySpan<byte> get_Widthヽᐤᐤ  =>  new byte[16]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0x41,0x08,0x48,0x63,0xc0,0x48,0xc1,0xe0,0x03,0xc3};

        public static ReadOnlySpan<byte> get_Bytesヽᐤᐤ  =>  new byte[28]{0x57,0x56,0x53,0x66,0x90,0x48,0x8b,0xda,0x48,0x8b,0xfb,0x48,0x8b,0xf1,0xe8,0x0d,0x6d,0x1a,0x5b,0x48,0xa5,0x48,0x8b,0xc3,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> get_Countヽᐤᐤ  =>  new byte[20]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0x41,0x08,0x48,0x63,0xc0,0x48,0xc1,0xe0,0x03,0x48,0xc1,0xe8,0x02,0xc3};

        public static ReadOnlySpan<byte> get_Lengthヽᐤᐤ  =>  new byte[20]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0x41,0x08,0x48,0x63,0xc0,0x48,0xc1,0xe0,0x03,0x48,0xc1,0xe8,0x02,0xc3};

        public static ReadOnlySpan<byte> get_Itemヽᐤ64uᐤ  =>  new byte[189]{0x48,0x83,0xec,0x18,0x90,0x33,0xc0,0x89,0x44,0x24,0x10,0xc6,0x44,0x24,0x14,0x00,0xc6,0x44,0x24,0x15,0x00,0x66,0xc7,0x44,0x24,0x16,0x00,0x00,0x89,0x44,0x24,0x08,0xc6,0x44,0x24,0x0c,0x00,0xc6,0x44,0x24,0x0d,0x00,0x66,0xc7,0x44,0x24,0x0e,0x00,0x00,0x66,0xc7,0x44,0x24,0x0e,0x04,0x00,0x8b,0xc2,0x48,0x8b,0xd0,0x48,0xc1,0xea,0x3f,0x48,0x03,0xc2,0x48,0xd1,0xf8,0x48,0xf7,0xd8,0x89,0x44,0x24,0x08,0xc6,0x44,0x24,0x0c,0xfe,0x8b,0x44,0x24,0x08,0x48,0x8b,0xd0,0x48,0xc1,0xea,0x3f,0x48,0x03,0xd0,0x48,0x83,0xe2,0xfe,0x48,0x2b,0xc2,0x0f,0xb6,0xc0,0x88,0x44,0x24,0x0d,0x48,0x8b,0x44,0x24,0x08,0x48,0x89,0x44,0x24,0x10,0x48,0x8b,0x01,0x8b,0x4c,0x24,0x10,0x48,0x63,0xd1,0x48,0x03,0xc2,0x80,0x7c,0x24,0x15,0x00,0x74,0x1e,0x0f,0xb6,0x00,0x8b,0x4c,0x24,0x16,0x0f,0xb7,0xc9,0x0f,0xb6,0xc9,0xd3,0xf8,0x0f,0xb6,0xc0,0x83,0xe0,0x0f,0x0f,0xb6,0xc0,0x48,0x0f,0xbe,0xc0,0xeb,0x0d,0x0f,0xb6,0x00,0x83,0xe0,0x0f,0x0f,0xb6,0xc0,0x48,0x0f,0xbe,0xc0,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> set_Itemヽᐤ64uㆍuint4ᐤ  =>  new byte[198]{0x48,0x83,0xec,0x18,0x90,0x33,0xc0,0x89,0x44,0x24,0x10,0xc6,0x44,0x24,0x14,0x00,0xc6,0x44,0x24,0x15,0x00,0x66,0xc7,0x44,0x24,0x16,0x00,0x00,0x89,0x44,0x24,0x08,0xc6,0x44,0x24,0x0c,0x00,0xc6,0x44,0x24,0x0d,0x00,0x66,0xc7,0x44,0x24,0x0e,0x00,0x00,0x66,0xc7,0x44,0x24,0x0e,0x04,0x00,0x8b,0xc2,0x48,0x8b,0xd0,0x48,0xc1,0xea,0x3f,0x48,0x03,0xc2,0x48,0xd1,0xf8,0x48,0xf7,0xd8,0x89,0x44,0x24,0x08,0xc6,0x44,0x24,0x0c,0xfe,0x8b,0x44,0x24,0x08,0x48,0x8b,0xd0,0x48,0xc1,0xea,0x3f,0x48,0x03,0xd0,0x48,0x83,0xe2,0xfe,0x48,0x2b,0xc2,0x0f,0xb6,0xc0,0x88,0x44,0x24,0x0d,0x48,0x8b,0x44,0x24,0x08,0x48,0x89,0x44,0x24,0x10,0x48,0x8b,0x01,0x8b,0x4c,0x24,0x10,0x48,0x63,0xd1,0x48,0x03,0xc2,0x80,0x7c,0x24,0x15,0x00,0x75,0x17,0x0f,0xb6,0x08,0x81,0xe1,0xf0,0x00,0x00,0x00,0x0f,0xb6,0xc9,0x45,0x0f,0xb6,0xc0,0x41,0x0b,0xc8,0x88,0x08,0xeb,0x1d,0x8b,0x4c,0x24,0x16,0x0f,0xb7,0xc9,0x0f,0xb6,0xc9,0x41,0x0f,0xb6,0xd0,0xd3,0xe2,0x0f,0xb6,0xd2,0x0f,0xb6,0x08,0x83,0xe1,0x0f,0x0b,0xd1,0x88,0x10,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> get_Itemヽᐤ64iᐤ  =>  new byte[189]{0x48,0x83,0xec,0x18,0x90,0x33,0xc0,0x89,0x44,0x24,0x10,0xc6,0x44,0x24,0x14,0x00,0xc6,0x44,0x24,0x15,0x00,0x66,0xc7,0x44,0x24,0x16,0x00,0x00,0x89,0x44,0x24,0x08,0xc6,0x44,0x24,0x0c,0x00,0xc6,0x44,0x24,0x0d,0x00,0x66,0xc7,0x44,0x24,0x0e,0x00,0x00,0x66,0xc7,0x44,0x24,0x0e,0x04,0x00,0x8b,0xc2,0x48,0x8b,0xd0,0x48,0xc1,0xea,0x3f,0x48,0x03,0xc2,0x48,0xd1,0xf8,0x48,0xf7,0xd8,0x89,0x44,0x24,0x08,0xc6,0x44,0x24,0x0c,0xfe,0x8b,0x44,0x24,0x08,0x48,0x8b,0xd0,0x48,0xc1,0xea,0x3f,0x48,0x03,0xd0,0x48,0x83,0xe2,0xfe,0x48,0x2b,0xc2,0x0f,0xb6,0xc0,0x88,0x44,0x24,0x0d,0x48,0x8b,0x44,0x24,0x08,0x48,0x89,0x44,0x24,0x10,0x48,0x8b,0x01,0x8b,0x4c,0x24,0x10,0x48,0x63,0xd1,0x48,0x03,0xc2,0x80,0x7c,0x24,0x15,0x00,0x74,0x1e,0x0f,0xb6,0x00,0x8b,0x4c,0x24,0x16,0x0f,0xb7,0xc9,0x0f,0xb6,0xc9,0xd3,0xf8,0x0f,0xb6,0xc0,0x83,0xe0,0x0f,0x0f,0xb6,0xc0,0x48,0x0f,0xbe,0xc0,0xeb,0x0d,0x0f,0xb6,0x00,0x83,0xe0,0x0f,0x0f,0xb6,0xc0,0x48,0x0f,0xbe,0xc0,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> set_Itemヽᐤ64iㆍuint4ᐤ  =>  new byte[198]{0x48,0x83,0xec,0x18,0x90,0x33,0xc0,0x89,0x44,0x24,0x10,0xc6,0x44,0x24,0x14,0x00,0xc6,0x44,0x24,0x15,0x00,0x66,0xc7,0x44,0x24,0x16,0x00,0x00,0x89,0x44,0x24,0x08,0xc6,0x44,0x24,0x0c,0x00,0xc6,0x44,0x24,0x0d,0x00,0x66,0xc7,0x44,0x24,0x0e,0x00,0x00,0x66,0xc7,0x44,0x24,0x0e,0x04,0x00,0x8b,0xc2,0x48,0x8b,0xd0,0x48,0xc1,0xea,0x3f,0x48,0x03,0xc2,0x48,0xd1,0xf8,0x48,0xf7,0xd8,0x89,0x44,0x24,0x08,0xc6,0x44,0x24,0x0c,0xfe,0x8b,0x44,0x24,0x08,0x48,0x8b,0xd0,0x48,0xc1,0xea,0x3f,0x48,0x03,0xd0,0x48,0x83,0xe2,0xfe,0x48,0x2b,0xc2,0x0f,0xb6,0xc0,0x88,0x44,0x24,0x0d,0x48,0x8b,0x44,0x24,0x08,0x48,0x89,0x44,0x24,0x10,0x48,0x8b,0x01,0x8b,0x4c,0x24,0x10,0x48,0x63,0xd1,0x48,0x03,0xc2,0x80,0x7c,0x24,0x15,0x00,0x75,0x17,0x0f,0xb6,0x08,0x81,0xe1,0xf0,0x00,0x00,0x00,0x0f,0xb6,0xc9,0x45,0x0f,0xb6,0xc0,0x41,0x0b,0xc8,0x88,0x08,0xeb,0x1d,0x8b,0x4c,0x24,0x16,0x0f,0xb7,0xc9,0x0f,0xb6,0xc9,0x41,0x0f,0xb6,0xd0,0xd3,0xe2,0x0f,0xb6,0xd2,0x0f,0xb6,0x08,0x83,0xe1,0x0f,0x0b,0xd1,0x88,0x10,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> Formatヽᐤᐤ  =>  new byte[779]{0x57,0x56,0x55,0x53,0x48,0x81,0xec,0x98,0x00,0x00,0x00,0xc5,0xf8,0x77,0x48,0x8b,0xf1,0x48,0x8d,0x7c,0x24,0x28,0xb9,0x1c,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x48,0x8b,0xf1,0x48,0xb9,0xb0,0x11,0xfa,0x76,0xfd,0x7f,0x00,0x00,0xe8,0xec,0x76,0x1a,0x5b,0x48,0x8b,0xf8,0xc7,0x47,0x20,0xff,0xff,0xff,0x7f,0x48,0xb9,0x70,0x2b,0xf3,0x76,0xfd,0x7f,0x00,0x00,0xba,0x10,0x00,0x00,0x00,0xe8,0xfe,0x77,0x1a,0x5b,0x48,0x8d,0x4f,0x08,0x48,0x8b,0xd0,0xe8,0x02,0x68,0x1a,0x5b,0x48,0xb9,0x58,0x50,0x13,0x78,0xfd,0x7f,0x00,0x00,0xe8,0xb3,0x76,0x1a,0x5b,0x48,0x8b,0xd8,0x48,0x8d,0x4b,0x08,0x48,0x8b,0xd7,0xe8,0xe4,0x67,0x1a,0x5b,0x8b,0x7e,0x08,0x48,0x8b,0xcb,0xba,0x5b,0x00,0x00,0x00,0xe8,0x84,0xdb,0x53,0xfe,0x33,0xed,0x85,0xff,0x0f,0x8e,0x41,0x02,0x00,0x00,0x48,0x8d,0x4c,0x24,0x78,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x01,0xc5,0xfa,0x7f,0x41,0x10,0x48,0x8d,0x4c,0x24,0x78,0x48,0x8b,0x16,0x48,0x63,0xc5,0x0f,0xb6,0x14,0x02,0x48,0x8b,0xc1,0xc6,0x44,0x24,0x70,0x00,0x44,0x8b,0xc2,0x41,0xc1,0xe8,0x07,0x41,0xf6,0xc0,0x01,0x41,0x0f,0x95,0xc0,0x45,0x0f,0xb6,0xc0,0x45,0x0f,0xb6,0xc0,0x44,0x88,0x44,0x24,0x70,0x80,0x7c,0x24,0x70,0x00,0x75,0x08,0x41,0xb8,0x30,0x00,0x00,0x00,0xeb,0x06,0x41,0xb8,0x31,0x00,0x00,0x00,0x66,0x44,0x89,0x00,0x48,0x8d,0x41,0x02,0xc6,0x44,0x24,0x68,0x00,0x44,0x8b,0xc2,0x41,0xc1,0xe8,0x06,0x41,0xf6,0xc0,0x01,0x41,0x0f,0x95,0xc0,0x45,0x0f,0xb6,0xc0,0x45,0x0f,0xb6,0xc0,0x44,0x88,0x44,0x24,0x68,0x80,0x7c,0x24,0x68,0x00,0x75,0x08,0x41,0xb8,0x30,0x00,0x00,0x00,0xeb,0x06,0x41,0xb8,0x31,0x00,0x00,0x00,0x66,0x44,0x89,0x00,0x48,0x8d,0x41,0x04,0xc6,0x44,0x24,0x60,0x00,0x44,0x8b,0xc2,0x41,0xc1,0xe8,0x05,0x41,0xf6,0xc0,0x01,0x41,0x0f,0x95,0xc0,0x45,0x0f,0xb6,0xc0,0x45,0x0f,0xb6,0xc0,0x44,0x88,0x44,0x24,0x60,0x80,0x7c,0x24,0x60,0x00,0x75,0x08,0x41,0xb8,0x30,0x00,0x00,0x00,0xeb,0x06,0x41,0xb8,0x31,0x00,0x00,0x00,0x66,0x44,0x89,0x00,0x48,0x8d,0x41,0x06,0xc6,0x44,0x24,0x58,0x00,0x44,0x8b,0xc2,0x41,0xc1,0xe8,0x04,0x41,0xf6,0xc0,0x01,0x41,0x0f,0x95,0xc0,0x45,0x0f,0xb6,0xc0,0x45,0x0f,0xb6,0xc0,0x44,0x88,0x44,0x24,0x58,0x80,0x7c,0x24,0x58,0x00,0x75,0x08,0x41,0xb8,0x30,0x00,0x00,0x00,0xeb,0x06,0x41,0xb8,0x31,0x00,0x00,0x00,0x66,0x44,0x89,0x00,0x66,0xc7,0x41,0x08,0x20,0x00,0x48,0x8d,0x41,0x0a,0xc6,0x44,0x24,0x50,0x00,0x44,0x8b,0xc2,0x41,0xc1,0xe8,0x03,0x41,0xf6,0xc0,0x01,0x41,0x0f,0x95,0xc0,0x45,0x0f,0xb6,0xc0,0x45,0x0f,0xb6,0xc0,0x44,0x88,0x44,0x24,0x50,0x80,0x7c,0x24,0x50,0x00,0x75,0x08,0x41,0xb8,0x30,0x00,0x00,0x00,0xeb,0x06,0x41,0xb8,0x31,0x00,0x00,0x00,0x66,0x44,0x89,0x00,0x48,0x8d,0x41,0x0c,0xc6,0x44,0x24,0x48,0x00,0x44,0x8b,0xc2,0x41,0xc1,0xe8,0x02,0x41,0xf6,0xc0,0x01,0x41,0x0f,0x95,0xc0,0x45,0x0f,0xb6,0xc0,0x45,0x0f,0xb6,0xc0,0x44,0x88,0x44,0x24,0x48,0x80,0x7c,0x24,0x48,0x00,0x75,0x08,0x41,0xb8,0x30,0x00,0x00,0x00,0xeb,0x06,0x41,0xb8,0x31,0x00,0x00,0x00,0x66,0x44,0x89,0x00,0x48,0x8d,0x41,0x0e,0xc6,0x44,0x24,0x40,0x00,0x44,0x8b,0xc2,0x41,0xd1,0xe8,0x41,0xf6,0xc0,0x01,0x41,0x0f,0x95,0xc0,0x45,0x0f,0xb6,0xc0,0x45,0x0f,0xb6,0xc0,0x44,0x88,0x44,0x24,0x40,0x80,0x7c,0x24,0x40,0x00,0x75,0x08,0x41,0xb8,0x30,0x00,0x00,0x00,0xeb,0x06,0x41,0xb8,0x31,0x00,0x00,0x00,0x66,0x44,0x89,0x00,0x48,0x8d,0x41,0x10,0xc6,0x44,0x24,0x38,0x00,0xf6,0xc2,0x01,0x0f,0x95,0xc2,0x0f,0xb6,0xd2,0x0f,0xb6,0xd2,0x88,0x54,0x24,0x38,0x80,0x7c,0x24,0x38,0x00,0x75,0x07,0xba,0x30,0x00,0x00,0x00,0xeb,0x05,0xba,0x31,0x00,0x00,0x00,0x66,0x89,0x10,0xba,0x09,0x00,0x00,0x00,0x48,0x8d,0x44,0x24,0x28,0x48,0x89,0x08,0x89,0x50,0x08,0x48,0x8b,0xcb,0x48,0x8d,0x54,0x24,0x28,0xe8,0x27,0xd9,0x53,0xfe,0x8d,0x4f,0xff,0x3b,0xe9,0x74,0x0d,0x48,0x8b,0xcb,0xba,0x20,0x00,0x00,0x00,0xe8,0x43,0xd9,0x53,0xfe,0xff,0xc5,0x3b,0xef,0x0f,0x8c,0xbf,0xfd,0xff,0xff,0x48,0x8b,0xcb,0xba,0x5d,0x00,0x00,0x00,0xe8,0x2c,0xd9,0x53,0xfe,0x48,0x8b,0xcb,0x49,0xbb,0x70,0x21,0xc5,0x76,0xfd,0x7f,0x00,0x00,0xba,0x01,0x00,0x00,0x00,0x39,0x09,0xff,0x15,0x52,0x1d,0x55,0xfb,0x90,0x48,0x81,0xc4,0x98,0x00,0x00,0x00,0x5b,0x5d,0x5e,0x5f,0xc3};

    }
}