﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2022-01-06 21:17:28 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class lib_swaps
    {
        public static ReadOnlySpan<byte> formatヽᐤSwapᐤ  =>  new byte[152]{0x56,0x48,0x83,0xec,0x40,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x48,0x89,0x44,0x24,0x38,0x48,0x89,0x4c,0x24,0x50,0x48,0xb9,0x10,0x8f,0x12,0x65,0xfb,0x7f,0x00,0x00,0xe8,0x81,0x62,0x13,0x5c,0x48,0x8b,0xf0,0x8b,0x4c,0x24,0x50,0x89,0x4e,0x08,0x48,0xb9,0x10,0x8f,0x12,0x65,0xfb,0x7f,0x00,0x00,0xe8,0x68,0x62,0x13,0x5c,0x44,0x8b,0x44,0x24,0x54,0x44,0x89,0x40,0x08,0x45,0x33,0xc0,0x48,0xba,0x90,0x13,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0xb9,0x28,0xd1,0x39,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x09,0x4c,0x8d,0x4c,0x24,0x20,0x49,0x89,0x31,0x49,0x89,0x41,0x08,0x4d,0x89,0x41,0x10,0x49,0x89,0x51,0x18,0x4c,0x8d,0x44,0x24,0x20,0x48,0x8b,0xd1,0x33,0xc9,0xe8,0x7f,0x4c,0x05,0x58,0x90,0x48,0x83,0xc4,0x40,0x5e,0xc3};

        public static ReadOnlySpan<byte> incヽᐤSwapᕀrefᐤ  =>  new byte[17]{0x0f,0x1f,0x44,0x00,0x00,0xff,0x01,0x48,0x8d,0x41,0x04,0xff,0x00,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> decヽᐤSwapᕀrefᐤ  =>  new byte[28]{0x0f,0x1f,0x44,0x00,0x00,0x83,0x39,0x00,0x74,0x02,0xff,0x09,0x83,0x79,0x04,0x00,0x74,0x06,0x48,0x8d,0x41,0x04,0xff,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> chainヽᐤSwapㆍ32iᐤ  =>  new byte[148]{0x56,0x48,0x83,0xec,0x30,0x48,0x89,0x4c,0x24,0x40,0x8b,0xf2,0x48,0x63,0xce,0xe8,0x1c,0xfa,0xff,0xff,0x48,0x8d,0x50,0x10,0x48,0x8b,0x4c,0x24,0x40,0x48,0x89,0x0a,0xb9,0x01,0x00,0x00,0x00,0x83,0xfe,0x01,0x7e,0x64,0x4c,0x63,0xc1,0x4e,0x8d,0x04,0xc2,0x4c,0x8d,0x4c,0x24,0x40,0x45,0x8b,0x11,0x44,0x89,0x54,0x24,0x20,0x45,0x8b,0x49,0x04,0x44,0x89,0x4c,0x24,0x24,0x4c,0x8d,0x4c,0x24,0x20,0x41,0xff,0x01,0x4c,0x8d,0x4c,0x24,0x24,0x41,0xff,0x01,0x4c,0x8b,0x4c,0x24,0x20,0x4c,0x89,0x4c,0x24,0x28,0x4c,0x8d,0x4c,0x24,0x40,0x44,0x8b,0x54,0x24,0x28,0x45,0x89,0x11,0x44,0x8b,0x54,0x24,0x2c,0x45,0x89,0x51,0x04,0x44,0x8b,0x4c,0x24,0x28,0x45,0x89,0x08,0x44,0x8b,0x4c,0x24,0x2c,0x45,0x89,0x48,0x04,0xff,0xc1,0x3b,0xce,0x7c,0x9c,0x48,0x83,0xc4,0x30,0x5e,0xc3};

        public static ReadOnlySpan<byte> violationヽgᐸ8uᐳᐤ8uᕀinㆍ8uᕀinᐤ  =>  new byte[18]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0x01,0x44,0x0f,0xb6,0x02,0x44,0x88,0x01,0x88,0x02,0xc3};

        public static ReadOnlySpan<byte> violationヽgᐸ16uᐳᐤ16uᕀinㆍ16uᕀinᐤ  =>  new byte[20]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb7,0x01,0x44,0x0f,0xb7,0x02,0x66,0x44,0x89,0x01,0x66,0x89,0x02,0xc3};

        public static ReadOnlySpan<byte> violationヽgᐸ32uᐳᐤ32uᕀinㆍ32uᕀinᐤ  =>  new byte[16]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0x01,0x44,0x8b,0x02,0x44,0x89,0x01,0x89,0x02,0xc3};

        public static ReadOnlySpan<byte> violationヽgᐸ64uᐳᐤ64uᕀinㆍ64uᕀinᐤ  =>  new byte[18]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x01,0x4c,0x8b,0x02,0x4c,0x89,0x01,0x48,0x89,0x02,0xc3};

        public static ReadOnlySpan<byte> swapヽgᐸ8uᐳᐤ8uᕀrefㆍ8uᕀrefᐤ  =>  new byte[18]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0x01,0x44,0x0f,0xb6,0x02,0x44,0x88,0x01,0x88,0x02,0xc3};

        public static ReadOnlySpan<byte> swapヽgᐸ16uᐳᐤ16uᕀrefㆍ16uᕀrefᐤ  =>  new byte[20]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb7,0x01,0x44,0x0f,0xb7,0x02,0x66,0x44,0x89,0x01,0x66,0x89,0x02,0xc3};

        public static ReadOnlySpan<byte> swapヽgᐸ32uᐳᐤ32uᕀrefㆍ32uᕀrefᐤ  =>  new byte[16]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0x01,0x44,0x8b,0x02,0x44,0x89,0x01,0x89,0x02,0xc3};

        public static ReadOnlySpan<byte> swapヽgᐸ64uᐳᐤ64uᕀrefㆍ64uᕀrefᐤ  =>  new byte[18]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x01,0x4c,0x8b,0x02,0x4c,0x89,0x01,0x48,0x89,0x02,0xc3};

        public static ReadOnlySpan<byte> swapヽgᐸ8uᐳᐤ8uᕀptrㆍ8uᕀptrᐤ  =>  new byte[16]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0x02,0x88,0x01,0x0f,0xb6,0x01,0x88,0x02,0xc3};

        public static ReadOnlySpan<byte> swapヽgᐸ16uᐳᐤ16uᕀptrㆍ16uᕀptrᐤ  =>  new byte[18]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb7,0x02,0x66,0x89,0x01,0x0f,0xb7,0x01,0x66,0x89,0x02,0xc3};

        public static ReadOnlySpan<byte> swapヽgᐸ32uᐳᐤ32uᕀptrㆍ32uᕀptrᐤ  =>  new byte[14]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0x02,0x89,0x01,0x8b,0x01,0x89,0x02,0xc3};

        public static ReadOnlySpan<byte> swapヽgᐸ64uᐳᐤ64uᕀptrㆍ64uᕀptrᐤ  =>  new byte[18]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x02,0x48,0x89,0x01,0x48,0x8b,0x01,0x48,0x89,0x02,0xc3};

        public static ReadOnlySpan<byte> swapヽgᐸ8uᐳᐤspan8uㆍ32uㆍ32uᐤ  =>  new byte[45]{0x0f,0x1f,0x44,0x00,0x00,0x41,0x3b,0xd0,0x75,0x01,0xc3,0x48,0x8b,0x01,0x48,0x63,0xca,0x0f,0xb6,0x0c,0x08,0x48,0x63,0xd2,0x48,0x03,0xd0,0x4d,0x63,0xc8,0x46,0x0f,0xb6,0x0c,0x08,0x44,0x88,0x0a,0x49,0x63,0xd0,0x88,0x0c,0x10,0xc3};

        public static ReadOnlySpan<byte> swapヽgᐸ16uᐳᐤspan16uㆍ32uㆍ32uᐤ  =>  new byte[48]{0x0f,0x1f,0x44,0x00,0x00,0x41,0x3b,0xd0,0x75,0x01,0xc3,0x48,0x8b,0x01,0x48,0x63,0xca,0x0f,0xb7,0x0c,0x48,0x48,0x63,0xd2,0x48,0x8d,0x14,0x50,0x4d,0x63,0xc8,0x46,0x0f,0xb7,0x0c,0x48,0x66,0x44,0x89,0x0a,0x49,0x63,0xd0,0x66,0x89,0x0c,0x50,0xc3};

        public static ReadOnlySpan<byte> swapヽgᐸ32uᐳᐤspan32uㆍ32uㆍ32uᐤ  =>  new byte[44]{0x0f,0x1f,0x44,0x00,0x00,0x41,0x3b,0xd0,0x75,0x01,0xc3,0x48,0x8b,0x01,0x48,0x63,0xca,0x8b,0x0c,0x88,0x48,0x63,0xd2,0x48,0x8d,0x14,0x90,0x4d,0x63,0xc8,0x46,0x8b,0x0c,0x88,0x44,0x89,0x0a,0x49,0x63,0xd0,0x89,0x0c,0x90,0xc3};

        public static ReadOnlySpan<byte> swapヽgᐸ64uᐳᐤspan64uㆍ32uㆍ32uᐤ  =>  new byte[46]{0x0f,0x1f,0x44,0x00,0x00,0x41,0x3b,0xd0,0x75,0x01,0xc3,0x48,0x8b,0x01,0x48,0x63,0xca,0x48,0x8b,0x0c,0xc8,0x48,0x63,0xd2,0x48,0x8d,0x14,0xd0,0x4d,0x63,0xc8,0x4e,0x8b,0x0c,0xc8,0x4c,0x89,0x0a,0x49,0x63,0xd0,0x48,0x89,0x0c,0xd0,0xc3};

    }
}
