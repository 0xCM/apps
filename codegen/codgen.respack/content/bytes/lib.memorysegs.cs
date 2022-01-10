﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2022-01-07 15:36:31 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class lib_memorysegs
    {
        public static ReadOnlySpan<byte> storeヽᐤBinaryCodeㆍByteSizeㆍMemoryAddressᐤ  =>  new byte[58]{0x48,0x83,0xec,0x28,0x90,0x48,0x85,0xc9,0x75,0x07,0x33,0xc0,0x45,0x33,0xc9,0xeb,0x08,0x48,0x8d,0x41,0x10,0x44,0x8b,0x49,0x08,0x49,0x8b,0xc8,0x44,0x3b,0xca,0x77,0x11,0x48,0x8b,0xd0,0x4d,0x63,0xc1,0xe8,0xc4,0x14,0x90,0x57,0x90,0x48,0x83,0xc4,0x28,0xc3,0xe8,0xa9,0xca,0xec,0xfb,0xcc,0x19,0x04};

        public static ReadOnlySpan<byte> defineヽᐤMemoryAddressㆍByteSizeᐤ  =>  new byte[24]{0xc5,0xf8,0x77,0x66,0x90,0xc4,0xe1,0xf9,0x6e,0xc2,0xc4,0xc3,0xf9,0x22,0xc0,0x01,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> defineヽᐤrspan8uᐤ  =>  new byte[33]{0xc5,0xf8,0x77,0x66,0x90,0x48,0x8b,0x02,0x8b,0x52,0x08,0x48,0x63,0xd2,0xc4,0xe1,0xf9,0x6e,0xc0,0xc4,0xe3,0xf9,0x22,0xc2,0x01,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> defineヽᐤstringᐤ  =>  new byte[48]{0xc5,0xf8,0x77,0x66,0x90,0x48,0x85,0xd2,0x75,0x04,0x33,0xc0,0xeb,0x08,0x48,0x8d,0x42,0x0c,0x44,0x8b,0x42,0x08,0x8b,0x52,0x08,0xd1,0xe2,0x8b,0xd2,0xc4,0xe1,0xf9,0x6e,0xc0,0xc4,0xe3,0xf9,0x22,0xc2,0x01,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> defineヽᐤcharᕀptrㆍ32uᐤ  =>  new byte[30]{0xc5,0xf8,0x77,0x66,0x90,0x41,0xd1,0xe0,0x41,0x8b,0xc0,0xc4,0xe1,0xf9,0x6e,0xc2,0xc4,0xe3,0xf9,0x22,0xc0,0x01,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> segrefヽᐤ8uᕀinㆍByteSizeᐤ  =>  new byte[50]{0x48,0x83,0xec,0x18,0xc5,0xf8,0x77,0x48,0x8d,0x44,0x24,0x08,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x00,0x48,0x8d,0x44,0x24,0x08,0x48,0x89,0x10,0x4c,0x89,0x40,0x08,0xc5,0xfa,0x6f,0x44,0x24,0x08,0xc5,0xfa,0x7f,0x01,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> sibヽᐤMemorySegㆍ32iㆍ8uㆍ16uᐤ  =>  new byte[37]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x01,0xc4,0xe1,0xf9,0x7e,0xc0,0x48,0x63,0xd2,0x0f,0xb6,0x04,0x10,0x41,0x0f,0xb6,0xd0,0x48,0x0f,0xaf,0xc2,0x41,0x0f,0xb7,0xd1,0x48,0x03,0xc2,0xc3};

        public static ReadOnlySpan<byte> sibヽᐤrspanMemorySegㆍMemorySlotᕀinㆍ32iㆍ8uㆍ16uᐤ  =>  new byte[54]{0xc5,0xf8,0x77,0x66,0x90,0x48,0x8b,0x01,0x0f,0xb6,0x12,0x48,0x63,0xd2,0x48,0xc1,0xe2,0x04,0xc5,0xf9,0x10,0x04,0x10,0xc4,0xe1,0xf9,0x7e,0xc0,0x49,0x63,0xd0,0x0f,0xb6,0x04,0x10,0x41,0x0f,0xb6,0xd1,0x48,0x0f,0xaf,0xc2,0x8b,0x54,0x24,0x28,0x0f,0xb7,0xd2,0x48,0x03,0xc2,0xc3};

        public static ReadOnlySpan<byte> segrefヽᐤstringᐤ  =>  new byte[75]{0x48,0x83,0xec,0x18,0xc5,0xf8,0x77,0x48,0x85,0xd2,0x75,0x04,0x33,0xc0,0xeb,0x08,0x48,0x8d,0x42,0x0c,0x44,0x8b,0x42,0x08,0x8b,0x52,0x08,0xd1,0xe2,0x8b,0xd2,0x4c,0x8d,0x44,0x24,0x08,0xc5,0xf8,0x57,0xc0,0xc4,0xc1,0x7a,0x7f,0x00,0x4c,0x8d,0x44,0x24,0x08,0x49,0x89,0x00,0x49,0x89,0x50,0x08,0xc5,0xfa,0x6f,0x44,0x24,0x08,0xc5,0xfa,0x7f,0x01,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> segrefヽᐤvoidᕀptrㆍByteSizeᐤ  =>  new byte[16]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x89,0x11,0x4c,0x89,0x41,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> segrefヽᐤ8uᕀptrㆍByteSizeᐤ  =>  new byte[50]{0x48,0x83,0xec,0x18,0xc5,0xf8,0x77,0x48,0x8d,0x44,0x24,0x08,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x00,0x48,0x8d,0x44,0x24,0x08,0x48,0x89,0x10,0x4c,0x89,0x40,0x08,0xc5,0xfa,0x6f,0x44,0x24,0x08,0xc5,0xfa,0x7f,0x01,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> segrefヽᐤarray_8iᐤ  =>  new byte[60]{0x48,0x83,0xec,0x18,0xc5,0xf8,0x77,0x39,0x12,0x48,0x8d,0x42,0x10,0x8b,0x52,0x08,0x4c,0x8d,0x44,0x24,0x08,0xc5,0xf8,0x57,0xc0,0xc4,0xc1,0x7a,0x7f,0x00,0x4c,0x8d,0x44,0x24,0x08,0x49,0x89,0x00,0x49,0x89,0x50,0x08,0xc5,0xfa,0x6f,0x44,0x24,0x08,0xc5,0xfa,0x7f,0x01,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> segrefヽᐤarray_8uᐤ  =>  new byte[60]{0x48,0x83,0xec,0x18,0xc5,0xf8,0x77,0x39,0x12,0x48,0x8d,0x42,0x10,0x8b,0x52,0x08,0x4c,0x8d,0x44,0x24,0x08,0xc5,0xf8,0x57,0xc0,0xc4,0xc1,0x7a,0x7f,0x00,0x4c,0x8d,0x44,0x24,0x08,0x49,0x89,0x00,0x49,0x89,0x50,0x08,0xc5,0xfa,0x6f,0x44,0x24,0x08,0xc5,0xfa,0x7f,0x01,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> segrefヽᐤarray_64uᐤ  =>  new byte[63]{0x48,0x83,0xec,0x18,0xc5,0xf8,0x77,0x39,0x12,0x48,0x8d,0x42,0x10,0x8b,0x52,0x08,0xc1,0xe2,0x03,0x4c,0x8d,0x44,0x24,0x08,0xc5,0xf8,0x57,0xc0,0xc4,0xc1,0x7a,0x7f,0x00,0x4c,0x8d,0x44,0x24,0x08,0x49,0x89,0x00,0x49,0x89,0x50,0x08,0xc5,0xfa,0x6f,0x44,0x24,0x08,0xc5,0xfa,0x7f,0x01,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> editヽᐤMemoryAddressㆍByteSizeᐤ  =>  new byte[16]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x89,0x11,0x44,0x89,0x41,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> segmentヽᐤrspanMemorySegㆍMemorySlotᐤ  =>  new byte[22]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x01,0x0f,0xb6,0xd2,0x48,0x63,0xd2,0x48,0xc1,0xe2,0x04,0x48,0x03,0xc2,0xc3};

        public static ReadOnlySpan<byte> loadヽᐤrspanMemorySegㆍMemorySlotᐤ  =>  new byte[45]{0xc5,0xf8,0x77,0x66,0x90,0x48,0x8b,0x02,0x41,0x0f,0xb6,0xd0,0x48,0x63,0xd2,0x48,0xc1,0xe2,0x04,0xc5,0xf9,0x10,0x04,0x10,0xc4,0xe1,0xf9,0x7e,0xc0,0xc4,0xe3,0xf9,0x16,0xc2,0x01,0x48,0x89,0x01,0x89,0x51,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> sliceヽᐤrspanMemorySegㆍMemorySlotㆍ32iᐤ  =>  new byte[54]{0xc5,0xf8,0x77,0x66,0x90,0x48,0x8b,0x02,0x41,0x0f,0xb6,0xd0,0x48,0x63,0xd2,0x48,0xc1,0xe2,0x04,0xc5,0xf9,0x10,0x04,0x10,0xc4,0xe1,0xf9,0x7e,0xc0,0xc4,0xe3,0xf9,0x16,0xc2,0x01,0x4d,0x63,0xc1,0x49,0x03,0xc0,0x41,0x2b,0xd1,0x48,0x89,0x01,0x89,0x51,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> sliceヽᐤrspanMemorySegㆍMemorySlotㆍ32iㆍ32iᐤ  =>  new byte[49]{0xc5,0xf8,0x77,0x66,0x90,0x48,0x8b,0x02,0x41,0x0f,0xb6,0xd0,0x48,0x63,0xd2,0x48,0xc1,0xe2,0x04,0xc5,0xf9,0x10,0x04,0x10,0xc4,0xe1,0xf9,0x7e,0xc0,0x49,0x63,0xd1,0x48,0x03,0xc2,0x8b,0x54,0x24,0x28,0x48,0x89,0x01,0x89,0x51,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> materializeヽᐤrspanSegRefㆍspan8uㆍbyteᐤ  =>  new byte[155]{0x41,0x56,0x57,0x56,0x55,0x53,0x4c,0x89,0x44,0x24,0x40,0x48,0x8b,0x02,0x8b,0x52,0x08,0x44,0x8b,0x41,0x08,0x45,0x33,0xc9,0x44,0x0f,0xb6,0x54,0x24,0x41,0x45,0x33,0xdb,0x49,0x63,0xf0,0x48,0x85,0xf6,0x7e,0x6b,0x48,0x8b,0x31,0x49,0x63,0xfb,0x48,0xc1,0xe7,0x04,0x48,0x03,0xf7,0x48,0x8b,0x3e,0x48,0x8b,0x76,0x08,0x33,0xdb,0x48,0x63,0xee,0x48,0x85,0xed,0x7e,0x2e,0xeb,0x21,0x49,0x63,0xe9,0x48,0x03,0xe8,0x4c,0x63,0xf3,0x46,0x0f,0xb6,0x34,0x37,0x44,0x88,0x75,0x00,0xff,0xc3,0x41,0xff,0xc1,0x8b,0xeb,0x4c,0x63,0xf6,0x49,0x3b,0xee,0x7d,0x0b,0x41,0x8b,0xe9,0x4c,0x63,0xf2,0x49,0x3b,0xee,0x7c,0xd4,0x80,0x7c,0x24,0x40,0x00,0x74,0x0a,0x41,0xff,0xc1,0x49,0x63,0xf1,0x44,0x88,0x14,0x30,0x41,0xff,0xc3,0x41,0x8b,0xf3,0x49,0x63,0xf8,0x48,0x3b,0xf7,0x7c,0x95,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0xc3};

        public static ReadOnlySpan<byte> cellヽᐤrspanMemorySegㆍMemorySlotㆍ64iᐤ  =>  new byte[35]{0xc5,0xf8,0x77,0x66,0x90,0x48,0x8b,0x01,0x0f,0xb6,0xd2,0x48,0x63,0xd2,0x48,0xc1,0xe2,0x04,0xc5,0xf9,0x10,0x04,0x10,0xc4,0xe1,0xf9,0x7e,0xc0,0x49,0x63,0xd0,0x48,0x03,0xc2,0xc3};

        public static ReadOnlySpan<byte> cellヽᐤrspanMemorySegㆍMemorySlotㆍ64uᐤ  =>  new byte[35]{0xc5,0xf8,0x77,0x66,0x90,0x48,0x8b,0x01,0x0f,0xb6,0xd2,0x48,0x63,0xd2,0x48,0xc1,0xe2,0x04,0xc5,0xf9,0x10,0x04,0x10,0xc4,0xe1,0xf9,0x7e,0xc0,0x49,0x63,0xd0,0x48,0x03,0xc2,0xc3};

        public static ReadOnlySpan<byte> countヽgᐸ8uᐳᐤMemorySegᐤ  =>  new byte[16]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x01,0xc4,0xe3,0xf9,0x16,0xc0,0x01,0xc3};

        public static ReadOnlySpan<byte> countヽgᐸ16uᐳᐤMemorySegᐤ  =>  new byte[18]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x01,0xc4,0xe3,0xf9,0x16,0xc0,0x01,0xd1,0xe8,0xc3};

        public static ReadOnlySpan<byte> countヽgᐸ32uᐳᐤMemorySegᐤ  =>  new byte[19]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x01,0xc4,0xe3,0xf9,0x16,0xc0,0x01,0xc1,0xe8,0x02,0xc3};

        public static ReadOnlySpan<byte> countヽgᐸ64uᐳᐤMemorySegᐤ  =>  new byte[19]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x01,0xc4,0xe3,0xf9,0x16,0xc0,0x01,0xc1,0xe8,0x03,0xc3};

        public static ReadOnlySpan<byte> cellsヽgᐸ8uᐳᐤMemoryRangeᐤ  =>  new byte[16]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x41,0x08,0x48,0x8b,0x11,0x48,0x2b,0xc2,0xc3};

        public static ReadOnlySpan<byte> cellsヽgᐸ16uᐳᐤMemoryRangeᐤ  =>  new byte[19]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x41,0x08,0x48,0x8b,0x11,0x48,0x2b,0xc2,0x48,0xd1,0xe8,0xc3};

        public static ReadOnlySpan<byte> cellsヽgᐸ32uᐳᐤMemoryRangeᐤ  =>  new byte[20]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x41,0x08,0x48,0x8b,0x11,0x48,0x2b,0xc2,0x48,0xc1,0xe8,0x02,0xc3};

        public static ReadOnlySpan<byte> cellsヽgᐸ64uᐳᐤMemoryRangeᐤ  =>  new byte[20]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x41,0x08,0x48,0x8b,0x11,0x48,0x2b,0xc2,0x48,0xc1,0xe8,0x03,0xc3};

        public static ReadOnlySpan<byte> viewヽgᐸ8uᐳᐤMemoryRangeᐤ  =>  new byte[28]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x02,0x4c,0x8b,0xc0,0x48,0x8b,0x52,0x08,0x48,0x2b,0xd0,0x4c,0x89,0x01,0x89,0x51,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> viewヽgᐸ16uᐳᐤMemoryRangeᐤ  =>  new byte[31]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x02,0x4c,0x8b,0xc0,0x48,0x8b,0x52,0x08,0x48,0x2b,0xd0,0x48,0xd1,0xea,0x4c,0x89,0x01,0x89,0x51,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> viewヽgᐸ32uᐳᐤMemoryRangeᐤ  =>  new byte[32]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x02,0x4c,0x8b,0xc0,0x48,0x8b,0x52,0x08,0x48,0x2b,0xd0,0x48,0xc1,0xea,0x02,0x4c,0x89,0x01,0x89,0x51,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> viewヽgᐸ64uᐳᐤMemoryRangeᐤ  =>  new byte[32]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x02,0x4c,0x8b,0xc0,0x48,0x8b,0x52,0x08,0x48,0x2b,0xd0,0x48,0xc1,0xea,0x03,0x4c,0x89,0x01,0x89,0x51,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> storeヽgᐸ8uᐳᐤrspanSegRefㆍspan8uᐤ  =>  new byte[66]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0x41,0x08,0x45,0x33,0xc0,0x4c,0x63,0xc8,0x4d,0x85,0xc9,0x7e,0x2e,0x4c,0x8b,0x0a,0x4d,0x63,0xd0,0x4d,0x03,0xca,0x4c,0x8b,0x11,0x4d,0x63,0xd8,0x49,0xc1,0xe3,0x04,0x4d,0x03,0xd3,0x4d,0x8b,0x12,0x45,0x0f,0xb6,0x12,0x45,0x88,0x11,0x41,0xff,0xc0,0x45,0x8b,0xc8,0x4c,0x63,0xd0,0x4d,0x3b,0xca,0x7c,0xd2,0xc3};

        public static ReadOnlySpan<byte> storeヽgᐸ16uᐳᐤrspanSegRefㆍspan16uᐤ  =>  new byte[68]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0x41,0x08,0x45,0x33,0xc0,0x4c,0x63,0xc8,0x4d,0x85,0xc9,0x7e,0x30,0x4c,0x8b,0x0a,0x4d,0x63,0xd0,0x4f,0x8d,0x0c,0x51,0x4c,0x8b,0x11,0x4d,0x63,0xd8,0x49,0xc1,0xe3,0x04,0x4d,0x03,0xd3,0x4d,0x8b,0x12,0x45,0x0f,0xb7,0x12,0x66,0x45,0x89,0x11,0x41,0xff,0xc0,0x45,0x8b,0xc8,0x4c,0x63,0xd0,0x4d,0x3b,0xca,0x7c,0xd0,0xc3};

        public static ReadOnlySpan<byte> storeヽgᐸ32uᐳᐤrspanSegRefㆍspan32uᐤ  =>  new byte[66]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0x41,0x08,0x45,0x33,0xc0,0x4c,0x63,0xc8,0x4d,0x85,0xc9,0x7e,0x2e,0x4c,0x8b,0x0a,0x4d,0x63,0xd0,0x4f,0x8d,0x0c,0x91,0x4c,0x8b,0x11,0x4d,0x63,0xd8,0x49,0xc1,0xe3,0x04,0x4d,0x03,0xd3,0x4d,0x8b,0x12,0x45,0x8b,0x12,0x45,0x89,0x11,0x41,0xff,0xc0,0x45,0x8b,0xc8,0x4c,0x63,0xd0,0x4d,0x3b,0xca,0x7c,0xd2,0xc3};

        public static ReadOnlySpan<byte> storeヽgᐸ64uᐳᐤrspanSegRefㆍspan64uᐤ  =>  new byte[66]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0x41,0x08,0x45,0x33,0xc0,0x4c,0x63,0xc8,0x4d,0x85,0xc9,0x7e,0x2e,0x4c,0x8b,0x0a,0x4d,0x63,0xd0,0x4f,0x8d,0x0c,0xd1,0x4c,0x8b,0x11,0x4d,0x63,0xd8,0x49,0xc1,0xe3,0x04,0x4d,0x03,0xd3,0x4d,0x8b,0x12,0x4d,0x8b,0x12,0x4d,0x89,0x11,0x41,0xff,0xc0,0x45,0x8b,0xc8,0x4c,0x63,0xd0,0x4d,0x3b,0xca,0x7c,0xd2,0xc3};

        public static ReadOnlySpan<byte> segrefヽgᐸ8uᐳᐤMemoryAddressㆍCountᐤ  =>  new byte[54]{0x48,0x83,0xec,0x18,0xc5,0xf8,0x77,0x41,0x8b,0xc0,0x4c,0x8d,0x44,0x24,0x08,0xc5,0xf8,0x57,0xc0,0xc4,0xc1,0x7a,0x7f,0x00,0x4c,0x8d,0x44,0x24,0x08,0x49,0x89,0x10,0x49,0x89,0x40,0x08,0xc5,0xfa,0x6f,0x44,0x24,0x08,0xc5,0xfa,0x7f,0x01,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> segrefヽgᐸ16uᐳᐤMemoryAddressㆍCountᐤ  =>  new byte[57]{0x48,0x83,0xec,0x18,0xc5,0xf8,0x77,0x41,0xd1,0xe0,0x41,0x8b,0xc0,0x4c,0x8d,0x44,0x24,0x08,0xc5,0xf8,0x57,0xc0,0xc4,0xc1,0x7a,0x7f,0x00,0x4c,0x8d,0x44,0x24,0x08,0x49,0x89,0x10,0x49,0x89,0x40,0x08,0xc5,0xfa,0x6f,0x44,0x24,0x08,0xc5,0xfa,0x7f,0x01,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> segrefヽgᐸ32uᐳᐤMemoryAddressㆍCountᐤ  =>  new byte[58]{0x48,0x83,0xec,0x18,0xc5,0xf8,0x77,0x41,0xc1,0xe0,0x02,0x41,0x8b,0xc0,0x4c,0x8d,0x44,0x24,0x08,0xc5,0xf8,0x57,0xc0,0xc4,0xc1,0x7a,0x7f,0x00,0x4c,0x8d,0x44,0x24,0x08,0x49,0x89,0x10,0x49,0x89,0x40,0x08,0xc5,0xfa,0x6f,0x44,0x24,0x08,0xc5,0xfa,0x7f,0x01,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> segrefヽgᐸ64uᐳᐤMemoryAddressㆍCountᐤ  =>  new byte[58]{0x48,0x83,0xec,0x18,0xc5,0xf8,0x77,0x41,0xc1,0xe0,0x03,0x41,0x8b,0xc0,0x4c,0x8d,0x44,0x24,0x08,0xc5,0xf8,0x57,0xc0,0xc4,0xc1,0x7a,0x7f,0x00,0x4c,0x8d,0x44,0x24,0x08,0x49,0x89,0x10,0x49,0x89,0x40,0x08,0xc5,0xfa,0x6f,0x44,0x24,0x08,0xc5,0xfa,0x7f,0x01,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> segrefヽgᐸ8uᐳᐤrspan8uᐤ  =>  new byte[57]{0x48,0x83,0xec,0x18,0xc5,0xf8,0x77,0x48,0x8b,0x02,0x8b,0x52,0x08,0x4c,0x8d,0x44,0x24,0x08,0xc5,0xf8,0x57,0xc0,0xc4,0xc1,0x7a,0x7f,0x00,0x4c,0x8d,0x44,0x24,0x08,0x49,0x89,0x00,0x49,0x89,0x50,0x08,0xc5,0xfa,0x6f,0x44,0x24,0x08,0xc5,0xfa,0x7f,0x01,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> segrefヽgᐸ16uᐳᐤrspan16uᐤ  =>  new byte[61]{0x48,0x83,0xec,0x18,0xc5,0xf8,0x77,0x48,0x8b,0x02,0x8b,0x52,0x08,0xd1,0xe2,0x8b,0xd2,0x4c,0x8d,0x44,0x24,0x08,0xc5,0xf8,0x57,0xc0,0xc4,0xc1,0x7a,0x7f,0x00,0x4c,0x8d,0x44,0x24,0x08,0x49,0x89,0x00,0x49,0x89,0x50,0x08,0xc5,0xfa,0x6f,0x44,0x24,0x08,0xc5,0xfa,0x7f,0x01,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> segrefヽgᐸ32uᐳᐤrspan32uᐤ  =>  new byte[60]{0x48,0x83,0xec,0x18,0xc5,0xf8,0x77,0x48,0x8b,0x02,0x8b,0x52,0x08,0xc1,0xe2,0x02,0x4c,0x8d,0x44,0x24,0x08,0xc5,0xf8,0x57,0xc0,0xc4,0xc1,0x7a,0x7f,0x00,0x4c,0x8d,0x44,0x24,0x08,0x49,0x89,0x00,0x49,0x89,0x50,0x08,0xc5,0xfa,0x6f,0x44,0x24,0x08,0xc5,0xfa,0x7f,0x01,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> segrefヽgᐸ64uᐳᐤrspan64uᐤ  =>  new byte[60]{0x48,0x83,0xec,0x18,0xc5,0xf8,0x77,0x48,0x8b,0x02,0x8b,0x52,0x08,0xc1,0xe2,0x03,0x4c,0x8d,0x44,0x24,0x08,0xc5,0xf8,0x57,0xc0,0xc4,0xc1,0x7a,0x7f,0x00,0x4c,0x8d,0x44,0x24,0x08,0x49,0x89,0x00,0x49,0x89,0x50,0x08,0xc5,0xfa,0x6f,0x44,0x24,0x08,0xc5,0xfa,0x7f,0x01,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> segrefヽgᐸ8uᐳᐤ8uᕀinㆍ32uᐤ  =>  new byte[54]{0x48,0x83,0xec,0x18,0xc5,0xf8,0x77,0x41,0x8b,0xc0,0x4c,0x8d,0x44,0x24,0x08,0xc5,0xf8,0x57,0xc0,0xc4,0xc1,0x7a,0x7f,0x00,0x4c,0x8d,0x44,0x24,0x08,0x49,0x89,0x10,0x49,0x89,0x40,0x08,0xc5,0xfa,0x6f,0x44,0x24,0x08,0xc5,0xfa,0x7f,0x01,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> segrefヽgᐸ16uᐳᐤ16uᕀinㆍ32uᐤ  =>  new byte[57]{0x48,0x83,0xec,0x18,0xc5,0xf8,0x77,0x41,0xd1,0xe0,0x41,0x8b,0xc0,0x4c,0x8d,0x44,0x24,0x08,0xc5,0xf8,0x57,0xc0,0xc4,0xc1,0x7a,0x7f,0x00,0x4c,0x8d,0x44,0x24,0x08,0x49,0x89,0x10,0x49,0x89,0x40,0x08,0xc5,0xfa,0x6f,0x44,0x24,0x08,0xc5,0xfa,0x7f,0x01,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> segrefヽgᐸ32uᐳᐤ32uᕀinㆍ32uᐤ  =>  new byte[58]{0x48,0x83,0xec,0x18,0xc5,0xf8,0x77,0x41,0xc1,0xe0,0x02,0x41,0x8b,0xc0,0x4c,0x8d,0x44,0x24,0x08,0xc5,0xf8,0x57,0xc0,0xc4,0xc1,0x7a,0x7f,0x00,0x4c,0x8d,0x44,0x24,0x08,0x49,0x89,0x10,0x49,0x89,0x40,0x08,0xc5,0xfa,0x6f,0x44,0x24,0x08,0xc5,0xfa,0x7f,0x01,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> segrefヽgᐸ64uᐳᐤ64uᕀinㆍ32uᐤ  =>  new byte[58]{0x48,0x83,0xec,0x18,0xc5,0xf8,0x77,0x41,0xc1,0xe0,0x03,0x41,0x8b,0xc0,0x4c,0x8d,0x44,0x24,0x08,0xc5,0xf8,0x57,0xc0,0xc4,0xc1,0x7a,0x7f,0x00,0x4c,0x8d,0x44,0x24,0x08,0x49,0x89,0x10,0x49,0x89,0x40,0x08,0xc5,0xfa,0x6f,0x44,0x24,0x08,0xc5,0xfa,0x7f,0x01,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> segrefヽgᐸ8uᐳᐤ8uᕀinㆍ32iᐤ  =>  new byte[54]{0x48,0x83,0xec,0x18,0xc5,0xf8,0x77,0x41,0x8b,0xc0,0x4c,0x8d,0x44,0x24,0x08,0xc5,0xf8,0x57,0xc0,0xc4,0xc1,0x7a,0x7f,0x00,0x4c,0x8d,0x44,0x24,0x08,0x49,0x89,0x10,0x49,0x89,0x40,0x08,0xc5,0xfa,0x6f,0x44,0x24,0x08,0xc5,0xfa,0x7f,0x01,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> segrefヽgᐸ16uᐳᐤ16uᕀinㆍ32iᐤ  =>  new byte[57]{0x48,0x83,0xec,0x18,0xc5,0xf8,0x77,0x41,0xd1,0xe0,0x41,0x8b,0xc0,0x4c,0x8d,0x44,0x24,0x08,0xc5,0xf8,0x57,0xc0,0xc4,0xc1,0x7a,0x7f,0x00,0x4c,0x8d,0x44,0x24,0x08,0x49,0x89,0x10,0x49,0x89,0x40,0x08,0xc5,0xfa,0x6f,0x44,0x24,0x08,0xc5,0xfa,0x7f,0x01,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> segrefヽgᐸ32uᐳᐤ32uᕀinㆍ32iᐤ  =>  new byte[58]{0x48,0x83,0xec,0x18,0xc5,0xf8,0x77,0x41,0xc1,0xe0,0x02,0x41,0x8b,0xc0,0x4c,0x8d,0x44,0x24,0x08,0xc5,0xf8,0x57,0xc0,0xc4,0xc1,0x7a,0x7f,0x00,0x4c,0x8d,0x44,0x24,0x08,0x49,0x89,0x10,0x49,0x89,0x40,0x08,0xc5,0xfa,0x6f,0x44,0x24,0x08,0xc5,0xfa,0x7f,0x01,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> segrefヽgᐸ64uᐳᐤ64uᕀinㆍ32iᐤ  =>  new byte[58]{0x48,0x83,0xec,0x18,0xc5,0xf8,0x77,0x41,0xc1,0xe0,0x03,0x41,0x8b,0xc0,0x4c,0x8d,0x44,0x24,0x08,0xc5,0xf8,0x57,0xc0,0xc4,0xc1,0x7a,0x7f,0x00,0x4c,0x8d,0x44,0x24,0x08,0x49,0x89,0x10,0x49,0x89,0x40,0x08,0xc5,0xfa,0x6f,0x44,0x24,0x08,0xc5,0xfa,0x7f,0x01,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> segrefヽgᐸ8uᐳᐤarray_8uᐤ  =>  new byte[60]{0x48,0x83,0xec,0x18,0xc5,0xf8,0x77,0x39,0x12,0x48,0x8d,0x42,0x10,0x8b,0x52,0x08,0x4c,0x8d,0x44,0x24,0x08,0xc5,0xf8,0x57,0xc0,0xc4,0xc1,0x7a,0x7f,0x00,0x4c,0x8d,0x44,0x24,0x08,0x49,0x89,0x00,0x49,0x89,0x50,0x08,0xc5,0xfa,0x6f,0x44,0x24,0x08,0xc5,0xfa,0x7f,0x01,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> segrefヽgᐸ16uᐳᐤarray_16uᐤ  =>  new byte[64]{0x48,0x83,0xec,0x18,0xc5,0xf8,0x77,0x39,0x12,0x48,0x8d,0x42,0x10,0x8b,0x52,0x08,0xd1,0xe2,0x8b,0xd2,0x4c,0x8d,0x44,0x24,0x08,0xc5,0xf8,0x57,0xc0,0xc4,0xc1,0x7a,0x7f,0x00,0x4c,0x8d,0x44,0x24,0x08,0x49,0x89,0x00,0x49,0x89,0x50,0x08,0xc5,0xfa,0x6f,0x44,0x24,0x08,0xc5,0xfa,0x7f,0x01,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> segrefヽgᐸ32uᐳᐤarray_32uᐤ  =>  new byte[63]{0x48,0x83,0xec,0x18,0xc5,0xf8,0x77,0x39,0x12,0x48,0x8d,0x42,0x10,0x8b,0x52,0x08,0xc1,0xe2,0x02,0x4c,0x8d,0x44,0x24,0x08,0xc5,0xf8,0x57,0xc0,0xc4,0xc1,0x7a,0x7f,0x00,0x4c,0x8d,0x44,0x24,0x08,0x49,0x89,0x00,0x49,0x89,0x50,0x08,0xc5,0xfa,0x6f,0x44,0x24,0x08,0xc5,0xfa,0x7f,0x01,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> segrefヽgᐸ64uᐳᐤarray_64uᐤ  =>  new byte[63]{0x48,0x83,0xec,0x18,0xc5,0xf8,0x77,0x39,0x12,0x48,0x8d,0x42,0x10,0x8b,0x52,0x08,0xc1,0xe2,0x03,0x4c,0x8d,0x44,0x24,0x08,0xc5,0xf8,0x57,0xc0,0xc4,0xc1,0x7a,0x7f,0x00,0x4c,0x8d,0x44,0x24,0x08,0x49,0x89,0x00,0x49,0x89,0x50,0x08,0xc5,0xfa,0x6f,0x44,0x24,0x08,0xc5,0xfa,0x7f,0x01,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> segrefヽgᐸ8uᐳᐤspan8uᐤ  =>  new byte[57]{0x48,0x83,0xec,0x18,0xc5,0xf8,0x77,0x48,0x8b,0x02,0x8b,0x52,0x08,0x4c,0x8d,0x44,0x24,0x08,0xc5,0xf8,0x57,0xc0,0xc4,0xc1,0x7a,0x7f,0x00,0x4c,0x8d,0x44,0x24,0x08,0x49,0x89,0x00,0x49,0x89,0x50,0x08,0xc5,0xfa,0x6f,0x44,0x24,0x08,0xc5,0xfa,0x7f,0x01,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> segrefヽgᐸ16uᐳᐤspan16uᐤ  =>  new byte[61]{0x48,0x83,0xec,0x18,0xc5,0xf8,0x77,0x48,0x8b,0x02,0x8b,0x52,0x08,0xd1,0xe2,0x8b,0xd2,0x4c,0x8d,0x44,0x24,0x08,0xc5,0xf8,0x57,0xc0,0xc4,0xc1,0x7a,0x7f,0x00,0x4c,0x8d,0x44,0x24,0x08,0x49,0x89,0x00,0x49,0x89,0x50,0x08,0xc5,0xfa,0x6f,0x44,0x24,0x08,0xc5,0xfa,0x7f,0x01,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> segrefヽgᐸ32uᐳᐤspan32uᐤ  =>  new byte[60]{0x48,0x83,0xec,0x18,0xc5,0xf8,0x77,0x48,0x8b,0x02,0x8b,0x52,0x08,0xc1,0xe2,0x02,0x4c,0x8d,0x44,0x24,0x08,0xc5,0xf8,0x57,0xc0,0xc4,0xc1,0x7a,0x7f,0x00,0x4c,0x8d,0x44,0x24,0x08,0x49,0x89,0x00,0x49,0x89,0x50,0x08,0xc5,0xfa,0x6f,0x44,0x24,0x08,0xc5,0xfa,0x7f,0x01,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> segrefヽgᐸ64uᐳᐤspan64uᐤ  =>  new byte[60]{0x48,0x83,0xec,0x18,0xc5,0xf8,0x77,0x48,0x8b,0x02,0x8b,0x52,0x08,0xc1,0xe2,0x03,0x4c,0x8d,0x44,0x24,0x08,0xc5,0xf8,0x57,0xc0,0xc4,0xc1,0x7a,0x7f,0x00,0x4c,0x8d,0x44,0x24,0x08,0x49,0x89,0x00,0x49,0x89,0x50,0x08,0xc5,0xfa,0x6f,0x44,0x24,0x08,0xc5,0xfa,0x7f,0x01,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> editヽgᐸ8uᐳᐤMemoryRangeᐤ  =>  new byte[28]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x02,0x4c,0x8b,0xc0,0x48,0x8b,0x52,0x08,0x48,0x2b,0xd0,0x4c,0x89,0x01,0x89,0x51,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> editヽgᐸ16uᐳᐤMemoryRangeᐤ  =>  new byte[31]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x02,0x4c,0x8b,0xc0,0x48,0x8b,0x52,0x08,0x48,0x2b,0xd0,0x48,0xd1,0xea,0x4c,0x89,0x01,0x89,0x51,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> editヽgᐸ32uᐳᐤMemoryRangeᐤ  =>  new byte[32]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x02,0x4c,0x8b,0xc0,0x48,0x8b,0x52,0x08,0x48,0x2b,0xd0,0x48,0xc1,0xea,0x02,0x4c,0x89,0x01,0x89,0x51,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> editヽgᐸ64uᐳᐤMemoryRangeᐤ  =>  new byte[32]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x02,0x4c,0x8b,0xc0,0x48,0x8b,0x52,0x08,0x48,0x2b,0xd0,0x48,0xc1,0xea,0x03,0x4c,0x89,0x01,0x89,0x51,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> editヽgᐸ8uᐳᐤSegRefᐤ  =>  new byte[22]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x02,0x48,0x8b,0x52,0x08,0x48,0x89,0x01,0x89,0x51,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> editヽgᐸ16uᐳᐤSegRefᐤ  =>  new byte[24]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x02,0x48,0x8b,0x52,0x08,0xd1,0xea,0x48,0x89,0x01,0x89,0x51,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> editヽgᐸ32uᐳᐤSegRefᐤ  =>  new byte[25]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x02,0x48,0x8b,0x52,0x08,0xc1,0xea,0x02,0x48,0x89,0x01,0x89,0x51,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> editヽgᐸ64uᐳᐤSegRefᐤ  =>  new byte[25]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x02,0x48,0x8b,0x52,0x08,0xc1,0xea,0x03,0x48,0x89,0x01,0x89,0x51,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> segrefsヽgᐸ8uᐳᐤrspan8uㆍspanSegRefᐸbyteᐳᐤ  =>  new byte[106]{0x48,0x83,0xec,0x18,0xc5,0xf8,0x77,0x33,0xc0,0x44,0x8b,0x41,0x08,0x4d,0x63,0xc0,0x4d,0x85,0xc0,0x7e,0x50,0x4c,0x8b,0x02,0x4c,0x63,0xc8,0x49,0xc1,0xe1,0x04,0x4d,0x03,0xc1,0x4c,0x8b,0x09,0x4c,0x63,0xd0,0x4d,0x03,0xca,0x4c,0x8d,0x54,0x24,0x08,0xc5,0xf8,0x57,0xc0,0xc4,0xc1,0x7a,0x7f,0x02,0x4c,0x8d,0x54,0x24,0x08,0x4d,0x89,0x0a,0x49,0xc7,0x42,0x08,0x01,0x00,0x00,0x00,0xc5,0xfa,0x6f,0x44,0x24,0x08,0xc4,0xc1,0x7a,0x7f,0x00,0xff,0xc0,0x44,0x8b,0xc0,0x44,0x8b,0x49,0x08,0x4d,0x63,0xc9,0x4d,0x3b,0xc1,0x7c,0xb0,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> segrefsヽgᐸ16uᐳᐤrspan16uㆍspanSegRefᐸushortᐳᐤ  =>  new byte[107]{0x48,0x83,0xec,0x18,0xc5,0xf8,0x77,0x33,0xc0,0x44,0x8b,0x41,0x08,0x4d,0x63,0xc0,0x4d,0x85,0xc0,0x7e,0x51,0x4c,0x8b,0x02,0x4c,0x63,0xc8,0x49,0xc1,0xe1,0x04,0x4d,0x03,0xc1,0x4c,0x8b,0x09,0x4c,0x63,0xd0,0x4f,0x8d,0x0c,0x51,0x4c,0x8d,0x54,0x24,0x08,0xc5,0xf8,0x57,0xc0,0xc4,0xc1,0x7a,0x7f,0x02,0x4c,0x8d,0x54,0x24,0x08,0x4d,0x89,0x0a,0x49,0xc7,0x42,0x08,0x04,0x00,0x00,0x00,0xc5,0xfa,0x6f,0x44,0x24,0x08,0xc4,0xc1,0x7a,0x7f,0x00,0xff,0xc0,0x44,0x8b,0xc0,0x44,0x8b,0x49,0x08,0x4d,0x63,0xc9,0x4d,0x3b,0xc1,0x7c,0xaf,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> segrefsヽgᐸ32uᐳᐤrspan32uㆍspanSegRefᐸuintᐳᐤ  =>  new byte[107]{0x48,0x83,0xec,0x18,0xc5,0xf8,0x77,0x33,0xc0,0x44,0x8b,0x41,0x08,0x4d,0x63,0xc0,0x4d,0x85,0xc0,0x7e,0x51,0x4c,0x8b,0x02,0x4c,0x63,0xc8,0x49,0xc1,0xe1,0x04,0x4d,0x03,0xc1,0x4c,0x8b,0x09,0x4c,0x63,0xd0,0x4f,0x8d,0x0c,0x91,0x4c,0x8d,0x54,0x24,0x08,0xc5,0xf8,0x57,0xc0,0xc4,0xc1,0x7a,0x7f,0x02,0x4c,0x8d,0x54,0x24,0x08,0x4d,0x89,0x0a,0x49,0xc7,0x42,0x08,0x10,0x00,0x00,0x00,0xc5,0xfa,0x6f,0x44,0x24,0x08,0xc4,0xc1,0x7a,0x7f,0x00,0xff,0xc0,0x44,0x8b,0xc0,0x44,0x8b,0x49,0x08,0x4d,0x63,0xc9,0x4d,0x3b,0xc1,0x7c,0xaf,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> segrefsヽgᐸ64uᐳᐤrspan64uㆍspanSegRefᐸulongᐳᐤ  =>  new byte[107]{0x48,0x83,0xec,0x18,0xc5,0xf8,0x77,0x33,0xc0,0x44,0x8b,0x41,0x08,0x4d,0x63,0xc0,0x4d,0x85,0xc0,0x7e,0x51,0x4c,0x8b,0x02,0x4c,0x63,0xc8,0x49,0xc1,0xe1,0x04,0x4d,0x03,0xc1,0x4c,0x8b,0x09,0x4c,0x63,0xd0,0x4f,0x8d,0x0c,0xd1,0x4c,0x8d,0x54,0x24,0x08,0xc5,0xf8,0x57,0xc0,0xc4,0xc1,0x7a,0x7f,0x02,0x4c,0x8d,0x54,0x24,0x08,0x4d,0x89,0x0a,0x49,0xc7,0x42,0x08,0x40,0x00,0x00,0x00,0xc5,0xfa,0x6f,0x44,0x24,0x08,0xc4,0xc1,0x7a,0x7f,0x00,0xff,0xc0,0x44,0x8b,0xc0,0x44,0x8b,0x49,0x08,0x4d,0x63,0xc9,0x4d,0x3b,0xc1,0x7c,0xaf,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> loadヽgᐸ8uᐳᐤMemorySegᐤ  =>  new byte[30]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xe1,0xf9,0x7e,0xc0,0xc4,0xe3,0xf9,0x16,0xc2,0x01,0x48,0x89,0x01,0x89,0x51,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> loadヽgᐸ16uᐳᐤMemorySegᐤ  =>  new byte[32]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xe1,0xf9,0x7e,0xc0,0xc4,0xe3,0xf9,0x16,0xc2,0x01,0xd1,0xea,0x48,0x89,0x01,0x89,0x51,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> loadヽgᐸ32uᐳᐤMemorySegᐤ  =>  new byte[33]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xe1,0xf9,0x7e,0xc0,0xc4,0xe3,0xf9,0x16,0xc2,0x01,0xc1,0xea,0x02,0x48,0x89,0x01,0x89,0x51,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> loadヽgᐸ64uᐳᐤMemorySegᐤ  =>  new byte[33]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xe1,0xf9,0x7e,0xc0,0xc4,0xe3,0xf9,0x16,0xc2,0x01,0xc1,0xea,0x03,0x48,0x89,0x01,0x89,0x51,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> cellヽgᐸ8uᐳᐤrspanMemorySegㆍMemorySlotㆍ64iᐤ  =>  new byte[35]{0xc5,0xf8,0x77,0x66,0x90,0x48,0x8b,0x01,0x0f,0xb6,0xd2,0x48,0x63,0xd2,0x48,0xc1,0xe2,0x04,0xc5,0xf9,0x10,0x04,0x10,0xc4,0xe1,0xf9,0x7e,0xc0,0x49,0x63,0xd0,0x48,0x03,0xc2,0xc3};

        public static ReadOnlySpan<byte> cellヽgᐸ16uᐳᐤrspanMemorySegㆍMemorySlotㆍ64iᐤ  =>  new byte[36]{0xc5,0xf8,0x77,0x66,0x90,0x48,0x8b,0x01,0x0f,0xb6,0xd2,0x48,0x63,0xd2,0x48,0xc1,0xe2,0x04,0xc5,0xf9,0x10,0x04,0x10,0xc4,0xe1,0xf9,0x7e,0xc0,0x49,0x63,0xd0,0x48,0x8d,0x04,0x50,0xc3};

        public static ReadOnlySpan<byte> cellヽgᐸ32uᐳᐤrspanMemorySegㆍMemorySlotㆍ64iᐤ  =>  new byte[36]{0xc5,0xf8,0x77,0x66,0x90,0x48,0x8b,0x01,0x0f,0xb6,0xd2,0x48,0x63,0xd2,0x48,0xc1,0xe2,0x04,0xc5,0xf9,0x10,0x04,0x10,0xc4,0xe1,0xf9,0x7e,0xc0,0x49,0x63,0xd0,0x48,0x8d,0x04,0x90,0xc3};

        public static ReadOnlySpan<byte> cellヽgᐸ64uᐳᐤrspanMemorySegㆍMemorySlotㆍ64iᐤ  =>  new byte[36]{0xc5,0xf8,0x77,0x66,0x90,0x48,0x8b,0x01,0x0f,0xb6,0xd2,0x48,0x63,0xd2,0x48,0xc1,0xe2,0x04,0xc5,0xf9,0x10,0x04,0x10,0xc4,0xe1,0xf9,0x7e,0xc0,0x49,0x63,0xd0,0x48,0x8d,0x04,0xd0,0xc3};

        public static ReadOnlySpan<byte> cellヽgᐸ8uᐳᐤrspanMemorySegㆍMemorySlotㆍ64uᐤ  =>  new byte[35]{0xc5,0xf8,0x77,0x66,0x90,0x48,0x8b,0x01,0x0f,0xb6,0xd2,0x48,0x63,0xd2,0x48,0xc1,0xe2,0x04,0xc5,0xf9,0x10,0x04,0x10,0xc4,0xe1,0xf9,0x7e,0xc0,0x49,0x63,0xd0,0x48,0x03,0xc2,0xc3};

        public static ReadOnlySpan<byte> cellヽgᐸ16uᐳᐤrspanMemorySegㆍMemorySlotㆍ64uᐤ  =>  new byte[36]{0xc5,0xf8,0x77,0x66,0x90,0x48,0x8b,0x01,0x0f,0xb6,0xd2,0x48,0x63,0xd2,0x48,0xc1,0xe2,0x04,0xc5,0xf9,0x10,0x04,0x10,0xc4,0xe1,0xf9,0x7e,0xc0,0x49,0x63,0xd0,0x48,0x8d,0x04,0x50,0xc3};

        public static ReadOnlySpan<byte> cellヽgᐸ32uᐳᐤrspanMemorySegㆍMemorySlotㆍ64uᐤ  =>  new byte[36]{0xc5,0xf8,0x77,0x66,0x90,0x48,0x8b,0x01,0x0f,0xb6,0xd2,0x48,0x63,0xd2,0x48,0xc1,0xe2,0x04,0xc5,0xf9,0x10,0x04,0x10,0xc4,0xe1,0xf9,0x7e,0xc0,0x49,0x63,0xd0,0x48,0x8d,0x04,0x90,0xc3};

        public static ReadOnlySpan<byte> cellヽgᐸ64uᐳᐤrspanMemorySegㆍMemorySlotㆍ64uᐤ  =>  new byte[36]{0xc5,0xf8,0x77,0x66,0x90,0x48,0x8b,0x01,0x0f,0xb6,0xd2,0x48,0x63,0xd2,0x48,0xc1,0xe2,0x04,0xc5,0xf9,0x10,0x04,0x10,0xc4,0xe1,0xf9,0x7e,0xc0,0x49,0x63,0xd0,0x48,0x8d,0x04,0xd0,0xc3};

    }
}