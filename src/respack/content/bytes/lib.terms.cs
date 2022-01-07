﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2022-01-06 21:17:28 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class lib_terms
    {
        public static ReadOnlySpan<byte> varヽᐤVarSymbolᐤ  =>  new byte[49]{0x57,0x56,0x48,0x83,0xec,0x28,0x48,0x8b,0xf1,0x48,0xb9,0xa0,0xbd,0x98,0x66,0xfb,0x7f,0x00,0x00,0xe8,0x58,0x38,0xa6,0x5b,0x48,0x8b,0xf8,0x48,0x8b,0xd6,0x48,0x8d,0x4f,0x08,0xe8,0x89,0x29,0xa6,0x5b,0x48,0x8b,0xc7,0x48,0x83,0xc4,0x28,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> formatヽᐤVarContextKindᕀ32uㆍVarSymbolᐤ  =>  new byte[130]{0x57,0x56,0x53,0x48,0x83,0xec,0x40,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x48,0x89,0x44,0x24,0x38,0x48,0x8b,0xf2,0xe8,0x2b,0xe5,0x6a,0xfd,0x48,0x8b,0xf8,0x48,0xb9,0x78,0xc0,0x1e,0x66,0xfb,0x7f,0x00,0x00,0xe8,0xe9,0x37,0xa6,0x5b,0x48,0x8b,0xd8,0x48,0x8d,0x4b,0x08,0x48,0x8b,0xd6,0xe8,0x1a,0x29,0xa6,0x5b,0x45,0x33,0xc0,0x48,0xba,0x88,0x13,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x8d,0x4c,0x24,0x20,0x48,0x89,0x19,0x4c,0x89,0x41,0x08,0x4c,0x89,0x41,0x10,0x48,0x89,0x51,0x18,0x4c,0x8d,0x44,0x24,0x20,0x48,0x8b,0xd7,0x33,0xc9,0xe8,0x07,0x22,0x98,0x57,0x90,0x48,0x83,0xc4,0x40,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> atomヽgᐸ8uᐳᐤ8uᐤ  =>  new byte[12]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc1,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> atomヽgᐸ16uᐳᐤ16uᐤ  =>  new byte[12]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb7,0xc1,0x0f,0xb7,0xc0,0xc3};

        public static ReadOnlySpan<byte> atomヽgᐸ32uᐳᐤ32uᐤ  =>  new byte[8]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> atomヽgᐸ64uᐳᐤ64uᐤ  =>  new byte[9]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> concatヽgᐸ8uᐳᐤAtomsᐸbyteᐳㆍAtomsᐸbyteᐳᐤ  =>  new byte[231]{0x41,0x57,0x41,0x56,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x28,0x48,0x8b,0xf1,0x48,0x8b,0xfa,0x48,0x8b,0xce,0x48,0x85,0xc9,0x75,0x04,0x33,0xdb,0xeb,0x03,0x8b,0x5e,0x08,0x48,0x8b,0xcf,0x48,0x85,0xc9,0x75,0x04,0x33,0xed,0xeb,0x03,0x8b,0x6f,0x08,0x45,0x33,0xf6,0x48,0x8b,0xce,0x48,0x85,0xc9,0x75,0x04,0x33,0xc9,0xeb,0x03,0x8b,0x4e,0x08,0x48,0x8b,0xc7,0x48,0x85,0xc0,0x75,0x04,0x33,0xc0,0xeb,0x03,0x8b,0x47,0x08,0x03,0xc8,0xe8,0xa8,0x0d,0xbd,0xfe,0x33,0xd2,0x8b,0xcb,0x48,0x85,0xc9,0x7e,0x39,0x4c,0x8d,0x40,0x10,0x41,0x8d,0x4e,0x01,0x44,0x8b,0xf9,0x39,0x00,0x49,0x8b,0xc8,0x45,0x8b,0xce,0x49,0x03,0xc9,0x39,0x36,0x4c,0x8d,0x4e,0x10,0x4c,0x63,0xd2,0x4d,0x03,0xca,0x45,0x0f,0xb6,0x09,0x44,0x88,0x09,0xff,0xc2,0x48,0x63,0xca,0x44,0x8b,0xcb,0x49,0x3b,0xc9,0x45,0x8b,0xf7,0x7c,0xcb,0x33,0xc9,0x8b,0xd5,0x48,0x85,0xd2,0x7e,0x35,0x4c,0x8d,0x40,0x10,0x41,0x8b,0xd6,0x44,0x8d,0x72,0x01,0x39,0x00,0x4d,0x8b,0xc8,0x8b,0xd2,0x49,0x03,0xd1,0x39,0x3f,0x4c,0x8d,0x4f,0x10,0x4c,0x63,0xd1,0x4d,0x03,0xca,0x45,0x0f,0xb6,0x09,0x44,0x88,0x0a,0xff,0xc1,0x48,0x63,0xd1,0x44,0x8b,0xcd,0x49,0x3b,0xd1,0x7c,0xcf,0x33,0xc0,0x48,0x83,0xc4,0x28,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0x41,0x5f,0xc3};

        public static ReadOnlySpan<byte> concatヽgᐸ16uᐳᐤAtomsᐸushortᐳㆍAtomsᐸushortᐳᐤ  =>  new byte[237]{0x41,0x57,0x41,0x56,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x28,0x48,0x8b,0xf1,0x48,0x8b,0xfa,0x48,0x8b,0xce,0x48,0x85,0xc9,0x75,0x04,0x33,0xdb,0xeb,0x03,0x8b,0x5e,0x08,0x48,0x8b,0xcf,0x48,0x85,0xc9,0x75,0x04,0x33,0xed,0xeb,0x03,0x8b,0x6f,0x08,0x45,0x33,0xf6,0x48,0x8b,0xce,0x48,0x85,0xc9,0x75,0x04,0x33,0xc9,0xeb,0x03,0x8b,0x4e,0x08,0x48,0x8b,0xc7,0x48,0x85,0xc0,0x75,0x04,0x33,0xc0,0xeb,0x03,0x8b,0x47,0x08,0x03,0xc8,0xe8,0xc0,0xca,0xff,0xff,0x33,0xd2,0x8b,0xcb,0x48,0x85,0xc9,0x7e,0x3c,0x4c,0x8d,0x40,0x10,0x41,0x8d,0x4e,0x01,0x44,0x8b,0xf9,0x39,0x00,0x49,0x8b,0xc8,0x45,0x8b,0xce,0x4a,0x8d,0x0c,0x49,0x39,0x36,0x4c,0x8d,0x4e,0x10,0x4c,0x63,0xd2,0x4f,0x8d,0x0c,0x51,0x45,0x0f,0xb7,0x09,0x66,0x44,0x89,0x09,0xff,0xc2,0x48,0x63,0xca,0x44,0x8b,0xcb,0x49,0x3b,0xc9,0x45,0x8b,0xf7,0x7c,0xc8,0x33,0xc9,0x8b,0xd5,0x48,0x85,0xd2,0x7e,0x38,0x4c,0x8d,0x40,0x10,0x41,0x8b,0xd6,0x44,0x8d,0x72,0x01,0x39,0x00,0x4d,0x8b,0xc8,0x8b,0xd2,0x49,0x8d,0x14,0x51,0x39,0x3f,0x4c,0x8d,0x4f,0x10,0x4c,0x63,0xd1,0x4f,0x8d,0x0c,0x51,0x45,0x0f,0xb7,0x09,0x66,0x44,0x89,0x0a,0xff,0xc1,0x48,0x63,0xd1,0x44,0x8b,0xcd,0x49,0x3b,0xd1,0x7c,0xcc,0x33,0xc0,0x48,0x83,0xc4,0x28,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0x41,0x5f,0xc3};

        public static ReadOnlySpan<byte> concatヽgᐸ32uᐳᐤAtomsᐸuintᐳㆍAtomsᐸuintᐳᐤ  =>  new byte[233]{0x41,0x57,0x41,0x56,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x28,0x48,0x8b,0xf1,0x48,0x8b,0xfa,0x48,0x8b,0xce,0x48,0x85,0xc9,0x75,0x04,0x33,0xdb,0xeb,0x03,0x8b,0x5e,0x08,0x48,0x8b,0xcf,0x48,0x85,0xc9,0x75,0x04,0x33,0xed,0xeb,0x03,0x8b,0x6f,0x08,0x45,0x33,0xf6,0x48,0x8b,0xce,0x48,0x85,0xc9,0x75,0x04,0x33,0xc9,0xeb,0x03,0x8b,0x4e,0x08,0x48,0x8b,0xc7,0x48,0x85,0xc0,0x75,0x04,0x33,0xc0,0xeb,0x03,0x8b,0x47,0x08,0x03,0xc8,0xe8,0xb8,0x61,0xc3,0xfe,0x33,0xd2,0x8b,0xcb,0x48,0x85,0xc9,0x7e,0x3a,0x4c,0x8d,0x40,0x10,0x41,0x8d,0x4e,0x01,0x44,0x8b,0xf9,0x39,0x00,0x49,0x8b,0xc8,0x45,0x8b,0xce,0x4a,0x8d,0x0c,0x89,0x39,0x36,0x4c,0x8d,0x4e,0x10,0x4c,0x63,0xd2,0x4f,0x8d,0x0c,0x91,0x45,0x8b,0x09,0x44,0x89,0x09,0xff,0xc2,0x48,0x63,0xca,0x44,0x8b,0xcb,0x49,0x3b,0xc9,0x45,0x8b,0xf7,0x7c,0xca,0x33,0xc9,0x8b,0xd5,0x48,0x85,0xd2,0x7e,0x36,0x4c,0x8d,0x40,0x10,0x41,0x8b,0xd6,0x44,0x8d,0x72,0x01,0x39,0x00,0x4d,0x8b,0xc8,0x8b,0xd2,0x49,0x8d,0x14,0x91,0x39,0x3f,0x4c,0x8d,0x4f,0x10,0x4c,0x63,0xd1,0x4f,0x8d,0x0c,0x91,0x45,0x8b,0x09,0x44,0x89,0x0a,0xff,0xc1,0x48,0x63,0xd1,0x44,0x8b,0xcd,0x49,0x3b,0xd1,0x7c,0xce,0x33,0xc0,0x48,0x83,0xc4,0x28,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0x41,0x5f,0xc3};

        public static ReadOnlySpan<byte> concatヽgᐸ64uᐳᐤAtomsᐸulongᐳㆍAtomsᐸulongᐳᐤ  =>  new byte[233]{0x41,0x57,0x41,0x56,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x28,0x48,0x8b,0xf1,0x48,0x8b,0xfa,0x48,0x8b,0xce,0x48,0x85,0xc9,0x75,0x04,0x33,0xdb,0xeb,0x03,0x8b,0x5e,0x08,0x48,0x8b,0xcf,0x48,0x85,0xc9,0x75,0x04,0x33,0xed,0xeb,0x03,0x8b,0x6f,0x08,0x45,0x33,0xf6,0x48,0x8b,0xce,0x48,0x85,0xc9,0x75,0x04,0x33,0xc9,0xeb,0x03,0x8b,0x4e,0x08,0x48,0x8b,0xc7,0x48,0x85,0xc0,0x75,0x04,0x33,0xc0,0xeb,0x03,0x8b,0x47,0x08,0x03,0xc8,0xe8,0x10,0xfc,0xff,0xff,0x33,0xd2,0x8b,0xcb,0x48,0x85,0xc9,0x7e,0x3a,0x4c,0x8d,0x40,0x10,0x41,0x8d,0x4e,0x01,0x44,0x8b,0xf9,0x39,0x00,0x49,0x8b,0xc8,0x45,0x8b,0xce,0x4a,0x8d,0x0c,0xc9,0x39,0x36,0x4c,0x8d,0x4e,0x10,0x4c,0x63,0xd2,0x4f,0x8d,0x0c,0xd1,0x4d,0x8b,0x09,0x4c,0x89,0x09,0xff,0xc2,0x48,0x63,0xca,0x44,0x8b,0xcb,0x49,0x3b,0xc9,0x45,0x8b,0xf7,0x7c,0xca,0x33,0xc9,0x8b,0xd5,0x48,0x85,0xd2,0x7e,0x36,0x4c,0x8d,0x40,0x10,0x41,0x8b,0xd6,0x44,0x8d,0x72,0x01,0x39,0x00,0x4d,0x8b,0xc8,0x8b,0xd2,0x49,0x8d,0x14,0xd1,0x39,0x3f,0x4c,0x8d,0x4f,0x10,0x4c,0x63,0xd1,0x4f,0x8d,0x0c,0xd1,0x4d,0x8b,0x09,0x4c,0x89,0x0a,0xff,0xc1,0x48,0x63,0xd1,0x44,0x8b,0xcd,0x49,0x3b,0xd1,0x7c,0xce,0x33,0xc0,0x48,0x83,0xc4,0x28,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0x41,0x5f,0xc3};

        public static ReadOnlySpan<byte> constantヽgᐸ8uᐳᐤ8uᐤ  =>  new byte[12]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc1,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> constantヽgᐸ16uᐳᐤ16uᐤ  =>  new byte[12]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb7,0xc1,0x0f,0xb7,0xc0,0xc3};

        public static ReadOnlySpan<byte> constantヽgᐸ32uᐳᐤ32uᐤ  =>  new byte[8]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> constantヽgᐸ64uᐳᐤ64uᐤ  =>  new byte[9]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> termヽgᐸ8uᐳᐤNameㆍ8uㆍarray_ITermᐤ  =>  new byte[82]{0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x28,0x8b,0xfa,0x49,0x8b,0xf0,0x48,0x8b,0xd9,0x48,0x85,0xdb,0x75,0x0d,0x48,0xb9,0x60,0x30,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x19,0x48,0xb9,0x78,0x2f,0x66,0x69,0xfb,0x7f,0x00,0x00,0xe8,0x2f,0x20,0xa6,0x5b,0x48,0x8b,0xe8,0x44,0x0f,0xb6,0xc7,0x48,0x8b,0xcd,0x48,0x8b,0xd3,0x4c,0x8b,0xce,0xe8,0x4a,0xfb,0xff,0xff,0x48,0x8b,0xc5,0x48,0x83,0xc4,0x28,0x5b,0x5d,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> termヽgᐸ16uᐳᐤNameㆍ16uㆍarray_ITermᐤ  =>  new byte[82]{0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x28,0x8b,0xfa,0x49,0x8b,0xf0,0x48,0x8b,0xd9,0x48,0x85,0xdb,0x75,0x0d,0x48,0xb9,0x60,0x30,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x19,0x48,0xb9,0x68,0x35,0x66,0x69,0xfb,0x7f,0x00,0x00,0xe8,0xbf,0x1f,0xa6,0x5b,0x48,0x8b,0xe8,0x44,0x0f,0xb7,0xc7,0x48,0x8b,0xcd,0x48,0x8b,0xd3,0x4c,0x8b,0xce,0xe8,0x2a,0xfb,0xff,0xff,0x48,0x8b,0xc5,0x48,0x83,0xc4,0x28,0x5b,0x5d,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> termヽgᐸ32uᐳᐤNameㆍ32uㆍarray_ITermᐤ  =>  new byte[81]{0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x28,0x8b,0xfa,0x49,0x8b,0xf0,0x48,0x8b,0xd9,0x48,0x85,0xdb,0x75,0x0d,0x48,0xb9,0x60,0x30,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x19,0x48,0xb9,0x58,0x38,0x66,0x69,0xfb,0x7f,0x00,0x00,0xe8,0x4f,0x1f,0xa6,0x5b,0x48,0x8b,0xe8,0x48,0x8b,0xcd,0x48,0x8b,0xd3,0x44,0x8b,0xc7,0x4c,0x8b,0xce,0xe8,0x0b,0xfb,0xff,0xff,0x48,0x8b,0xc5,0x48,0x83,0xc4,0x28,0x5b,0x5d,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> termヽgᐸ64uᐳᐤNameㆍ64uㆍarray_ITermᐤ  =>  new byte[82]{0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x28,0x48,0x8b,0xfa,0x49,0x8b,0xf0,0x48,0x8b,0xd9,0x48,0x85,0xdb,0x75,0x0d,0x48,0xb9,0x60,0x30,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x19,0x48,0xb9,0x48,0x3b,0x66,0x69,0xfb,0x7f,0x00,0x00,0xe8,0xde,0x1e,0xa6,0x5b,0x48,0x8b,0xe8,0x48,0x8b,0xcd,0x48,0x8b,0xd3,0x4c,0x8b,0xc7,0x4c,0x8b,0xce,0xe8,0xea,0xfa,0xff,0xff,0x48,0x8b,0xc5,0x48,0x83,0xc4,0x28,0x5b,0x5d,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> resolveヽgᐸ8uᐳᐤIVarㆍ8uᐤ  =>  new byte[12]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc2,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> resolveヽgᐸ16uᐳᐤIVarㆍ16uᐤ  =>  new byte[12]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb7,0xc2,0x0f,0xb7,0xc0,0xc3};

        public static ReadOnlySpan<byte> resolveヽgᐸ32uᐳᐤIVarㆍ32uᐤ  =>  new byte[8]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0xc2,0xc3};

        public static ReadOnlySpan<byte> resolveヽgᐸ64uᐳᐤIVarㆍ64uᐤ  =>  new byte[9]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0xc2,0xc3};

        public static ReadOnlySpan<byte> resolveヽgᐸ8uᐳᐤIVarSymbolㆍ8uᐤ  =>  new byte[12]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc2,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> resolveヽgᐸ16uᐳᐤIVarSymbolㆍ16uᐤ  =>  new byte[12]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb7,0xc2,0x0f,0xb7,0xc0,0xc3};

        public static ReadOnlySpan<byte> resolveヽgᐸ32uᐳᐤIVarSymbolㆍ32uᐤ  =>  new byte[8]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0xc2,0xc3};

        public static ReadOnlySpan<byte> resolveヽgᐸ64uᐳᐤIVarSymbolㆍ64uᐤ  =>  new byte[9]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0xc2,0xc3};

    }
}
