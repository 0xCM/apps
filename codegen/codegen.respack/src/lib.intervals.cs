﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2022-01-14 21:56:33 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class lib_intervals
    {
        public static ReadOnlySpan<byte> parseヽᐤstringㆍClosedIntervalᐸintᐳㆍ32iᕀoutㆍOutcomeᕀoutᐤ  =>  new byte[482]{0x57,0x56,0x53,0x48,0x81,0xec,0x80,0x00,0x00,0x00,0xc5,0xf8,0x77,0x48,0x8b,0xf1,0x48,0x8d,0x7c,0x24,0x20,0xb9,0x18,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x48,0x89,0x94,0x24,0xa8,0x00,0x00,0x00,0x49,0x8b,0xf8,0x49,0x8b,0xf1,0x33,0xc0,0x89,0x44,0x24,0x78,0x48,0x85,0xc9,0x75,0x06,0x33,0xc0,0x33,0xd2,0xeb,0x07,0x48,0x8d,0x41,0x0c,0x8b,0x51,0x08,0x48,0x8d,0x4c,0x24,0x40,0x48,0x89,0x01,0x89,0x51,0x08,0xe8,0x09,0xea,0x1d,0x5b,0x4c,0x8b,0xc0,0x48,0x8d,0x4c,0x24,0x40,0x4c,0x8d,0x4c,0x24,0x78,0xba,0x07,0x00,0x00,0x00,0xe8,0xa2,0xfb,0x1c,0x5b,0x85,0xc0,0x75,0x0d,0x8b,0x54,0x24,0x78,0x89,0x17,0xba,0x01,0x00,0x00,0x00,0xeb,0x04,0x33,0xd2,0x89,0x17,0x33,0xc9,0x48,0x8d,0x44,0x24,0x60,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x00,0x48,0x89,0x48,0x10,0x88,0x54,0x24,0x70,0x48,0x8d,0x4c,0x24,0x60,0x85,0xd2,0x75,0x0f,0x48,0xba,0xa8,0x47,0xa8,0x70,0xc3,0x01,0x00,0x00,0x48,0x8b,0x12,0xeb,0x0d,0x48,0xba,0x60,0x30,0x93,0x70,0xc3,0x01,0x00,0x00,0x48,0x8b,0x12,0xe8,0xac,0x95,0x88,0x5b,0x8b,0x54,0x24,0x70,0x0f,0xb6,0xd2,0x48,0x89,0x54,0x24,0x68,0x48,0x8b,0x54,0x24,0x60,0x48,0x8b,0xce,0xe8,0x93,0x95,0x88,0x5b,0x48,0x8b,0x44,0x24,0x68,0x48,0x89,0x46,0x08,0x0f,0xb6,0x44,0x24,0x70,0x88,0x46,0x10,0x0f,0xb6,0x46,0x10,0x84,0xc0,0x75,0x0d,0x33,0xc0,0x48,0x81,0xc4,0x80,0x00,0x00,0x00,0x5b,0x5e,0x5f,0xc3,0x48,0x8d,0x8c,0x24,0xa8,0x00,0x00,0x00,0x8b,0x01,0x89,0x44,0x24,0x50,0x8b,0x49,0x04,0x89,0x4c,0x24,0x54,0x8b,0x0f,0x89,0x4c,0x24,0x5c,0x8b,0x4c,0x24,0x5c,0x3b,0x4c,0x24,0x50,0x72,0x16,0x8b,0x4c,0x24,0x5c,0x3b,0x4c,0x24,0x54,0x0f,0x96,0xc1,0x0f,0xb6,0xc9,0x85,0xc9,0x0f,0x85,0x94,0x00,0x00,0x00,0x48,0xb9,0x10,0x8f,0xa7,0x61,0xfb,0x7f,0x00,0x00,0xe8,0x13,0xa4,0x88,0x5b,0x48,0x8b,0xd8,0x8b,0x0f,0x89,0x4b,0x08,0x48,0xb9,0x20,0x43,0x76,0x64,0xfb,0x7f,0x00,0x00,0xe8,0xfc,0xa3,0x88,0x5b,0x4c,0x8b,0x84,0x24,0xa8,0x00,0x00,0x00,0x4c,0x89,0x40,0x08,0x45,0x33,0xc0,0x48,0xba,0x90,0x13,0x93,0x70,0xc3,0x01,0x00,0x00,0x48,0x8b,0x12,0x48,0xb9,0xe0,0x57,0x9e,0x70,0xc3,0x01,0x00,0x00,0x48,0x8b,0x09,0x4c,0x8d,0x4c,0x24,0x20,0x49,0x89,0x19,0x49,0x89,0x41,0x08,0x4d,0x89,0x41,0x10,0x49,0x89,0x51,0x18,0x4c,0x8d,0x44,0x24,0x20,0x48,0x8b,0xd1,0x33,0xc9,0xe8,0x10,0x8e,0x1d,0x5b,0x48,0x8b,0xd0,0x33,0xff,0x48,0x8b,0xce,0xe8,0xb3,0x94,0x88,0x5b,0x33,0xc0,0x48,0x89,0x46,0x08,0x40,0x88,0x7e,0x10,0x48,0x81,0xc4,0x80,0x00,0x00,0x00,0x5b,0x5e,0x5f,0xc3,0xb8,0x01,0x00,0x00,0x00,0x48,0x81,0xc4,0x80,0x00,0x00,0x00,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> betweenヽᐤ64uㆍ64uㆍ64uᐤ  =>  new byte[23]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x3b,0xca,0x72,0x0a,0x49,0x3b,0xc8,0x0f,0x96,0xc0,0x0f,0xb6,0xc0,0xc3,0x33,0xc0,0xc3};

        public static ReadOnlySpan<byte> partitionヽᐤClosedIntervalᐸulongᐳᕀinㆍ64uᐤ  =>  new byte[197]{0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x28,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x8b,0xf1,0x48,0x8b,0xfa,0x48,0x8d,0x46,0x08,0x48,0x8b,0x00,0x48,0x2b,0x06,0x33,0xd2,0x48,0xf7,0xf7,0x48,0x8d,0x48,0x01,0xe8,0xeb,0xee,0xff,0xff,0x48,0x8b,0x16,0x48,0x8b,0x4e,0x08,0x45,0x33,0xc0,0x4c,0x89,0x44,0x24,0x20,0x48,0x85,0xc0,0x75,0x08,0x45,0x33,0xc0,0x45,0x33,0xc9,0xeb,0x08,0x4c,0x8d,0x40,0x10,0x44,0x8b,0x48,0x08,0x45,0x8b,0xd1,0x48,0x89,0x54,0x24,0x20,0x41,0xff,0xca,0x45,0x33,0xdb,0x4d,0x63,0xc9,0x4d,0x85,0xc9,0x7e,0x55,0x49,0x63,0xf2,0x45,0x85,0xdb,0x75,0x05,0x49,0x89,0x10,0xeb,0x24,0x41,0x8b,0xdb,0x41,0x8d,0x6a,0xff,0x48,0x63,0xed,0x48,0x3b,0xdd,0x75,0x09,0x49,0x63,0xdb,0x49,0x89,0x0c,0xd8,0xeb,0x0c,0x49,0x63,0xdb,0x48,0x8b,0x6c,0x24,0x20,0x49,0x89,0x2c,0xd8,0x41,0x8b,0xdb,0x48,0x3b,0xde,0x74,0x11,0x48,0x8d,0x5c,0x24,0x20,0x48,0x63,0xef,0x48,0x8b,0x1c,0xeb,0x48,0x89,0x5c,0x24,0x20,0x41,0xff,0xc3,0x41,0x8b,0xdb,0x49,0x3b,0xd9,0x7c,0xae,0x48,0x83,0xc4,0x28,0x5b,0x5d,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> partitionヽᐤ64uㆍ64uㆍ64uㆍarray_64uᐤ  =>  new byte[149]{0x57,0x56,0x53,0x48,0x83,0xec,0x10,0x33,0xc0,0x48,0x89,0x44,0x24,0x08,0x4d,0x85,0xc9,0x75,0x07,0x33,0xc0,0x45,0x33,0xd2,0xeb,0x08,0x49,0x8d,0x41,0x10,0x45,0x8b,0x51,0x08,0x45,0x8b,0xca,0x48,0x89,0x4c,0x24,0x08,0x41,0xff,0xc9,0x45,0x33,0xdb,0x4d,0x63,0xd2,0x4d,0x85,0xd2,0x7e,0x55,0x49,0x63,0xf1,0x45,0x85,0xdb,0x75,0x05,0x48,0x89,0x08,0xeb,0x24,0x41,0x8b,0xfb,0x41,0x8d,0x59,0xff,0x48,0x63,0xdb,0x48,0x3b,0xfb,0x75,0x09,0x49,0x63,0xfb,0x48,0x89,0x14,0xf8,0xeb,0x0c,0x49,0x63,0xfb,0x48,0x8b,0x5c,0x24,0x08,0x48,0x89,0x1c,0xf8,0x41,0x8b,0xfb,0x48,0x3b,0xfe,0x74,0x11,0x48,0x8d,0x7c,0x24,0x08,0x49,0x63,0xd8,0x48,0x8b,0x3c,0xdf,0x48,0x89,0x7c,0x24,0x08,0x41,0xff,0xc3,0x41,0x8b,0xfb,0x49,0x3b,0xfa,0x7c,0xae,0x48,0x83,0xc4,0x10,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> containsヽgᐸ8uᐳᐤClosedIntervalᐸbyteᐳᕀinㆍ8uᐤ  =>  new byte[65]{0x48,0x83,0xec,0x18,0x90,0x0f,0xb6,0xc2,0x88,0x44,0x24,0x14,0x48,0x8b,0x44,0x24,0x14,0x0f,0xb6,0x11,0x88,0x54,0x24,0x10,0x48,0x8b,0x54,0x24,0x10,0x0f,0xb6,0x49,0x01,0x88,0x4c,0x24,0x0c,0x48,0x8b,0x4c,0x24,0x0c,0x48,0x3b,0xc2,0x72,0x0b,0x48,0x3b,0xc1,0x0f,0x96,0xc0,0x0f,0xb6,0xc0,0xeb,0x02,0x33,0xc0,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> containsヽgᐸ16uᐳᐤClosedIntervalᐸushortᐳᕀinㆍ16uᐤ  =>  new byte[68]{0x48,0x83,0xec,0x18,0x90,0x0f,0xb7,0xc2,0x66,0x89,0x44,0x24,0x14,0x48,0x8b,0x44,0x24,0x14,0x0f,0xb7,0x11,0x66,0x89,0x54,0x24,0x10,0x48,0x8b,0x54,0x24,0x10,0x0f,0xb7,0x49,0x02,0x66,0x89,0x4c,0x24,0x0c,0x48,0x8b,0x4c,0x24,0x0c,0x48,0x3b,0xc2,0x72,0x0b,0x48,0x3b,0xc1,0x0f,0x96,0xc0,0x0f,0xb6,0xc0,0xeb,0x02,0x33,0xc0,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> containsヽgᐸ32uᐳᐤClosedIntervalᐸuintᐳᕀinㆍ32uᐤ  =>  new byte[60]{0x48,0x83,0xec,0x18,0x90,0x89,0x54,0x24,0x14,0x48,0x8b,0x44,0x24,0x14,0x8b,0x11,0x89,0x54,0x24,0x10,0x48,0x8b,0x54,0x24,0x10,0x8b,0x49,0x04,0x89,0x4c,0x24,0x0c,0x48,0x8b,0x4c,0x24,0x0c,0x48,0x3b,0xc2,0x72,0x0b,0x48,0x3b,0xc1,0x0f,0x96,0xc0,0x0f,0xb6,0xc0,0xeb,0x02,0x33,0xc0,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> containsヽgᐸ64uᐳᐤClosedIntervalᐸulongᐳᕀinㆍ64uᐤ  =>  new byte[31]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x01,0x48,0x8b,0x49,0x08,0x48,0x3b,0xd0,0x72,0x0b,0x48,0x3b,0xd1,0x0f,0x96,0xc0,0x0f,0xb6,0xc0,0xeb,0x02,0x33,0xc0,0xc3};

        public static ReadOnlySpan<byte> containsヽgᐸ8uᐳᐤClosedIntervalᐸbyteᐳㆍ8uᐤ  =>  new byte[53]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x89,0x4c,0x24,0x08,0x89,0x54,0x24,0x10,0x0f,0xb6,0x44,0x24,0x10,0x0f,0xb6,0x54,0x24,0x08,0x3b,0xc2,0x7c,0x16,0x0f,0xb6,0x44,0x24,0x10,0x0f,0xb6,0x54,0x24,0x09,0x3b,0xc2,0x0f,0x9e,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0xc3,0x33,0xc0,0xc3};

        public static ReadOnlySpan<byte> containsヽgᐸ16uᐳᐤClosedIntervalᐸushortᐳㆍ16uᐤ  =>  new byte[53]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x89,0x4c,0x24,0x08,0x89,0x54,0x24,0x10,0x0f,0xb7,0x44,0x24,0x10,0x0f,0xb7,0x54,0x24,0x08,0x3b,0xc2,0x7c,0x16,0x0f,0xb7,0x44,0x24,0x10,0x0f,0xb7,0x54,0x24,0x0a,0x3b,0xc2,0x0f,0x9e,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0xc3,0x33,0xc0,0xc3};

        public static ReadOnlySpan<byte> containsヽgᐸ32uᐳᐤClosedIntervalᐸuintᐳㆍ32uᐤ  =>  new byte[45]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x89,0x4c,0x24,0x08,0x89,0x54,0x24,0x10,0x8b,0x44,0x24,0x10,0x3b,0x44,0x24,0x08,0x72,0x12,0x8b,0x44,0x24,0x10,0x3b,0x44,0x24,0x0c,0x0f,0x96,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0xc3,0x33,0xc0,0xc3};

        public static ReadOnlySpan<byte> containsヽgᐸ64uᐳᐤClosedIntervalᐸulongᐳㆍ64uᐤ  =>  new byte[70]{0x48,0x83,0xec,0x18,0x90,0x48,0x89,0x54,0x24,0x28,0x48,0x8b,0x01,0x48,0x89,0x44,0x24,0x10,0x48,0x8b,0x41,0x08,0x48,0x89,0x44,0x24,0x08,0x48,0x8b,0x44,0x24,0x28,0x48,0x3b,0x44,0x24,0x10,0x72,0x18,0x48,0x8b,0x44,0x24,0x28,0x48,0x3b,0x44,0x24,0x08,0x0f,0x96,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0x48,0x83,0xc4,0x18,0xc3,0x33,0xc0,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> defineヽgᐸ8uᐳᐤ8uㆍ8uㆍIntervalKindᕀ8uᐤ  =>  new byte[29]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc2,0x41,0x0f,0xb6,0xd0,0x45,0x0f,0xb6,0xc1,0x88,0x01,0x88,0x51,0x01,0x44,0x88,0x41,0x02,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> defineヽgᐸ16uᐳᐤ16uㆍ16uㆍIntervalKindᕀ8uᐤ  =>  new byte[31]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb7,0xc2,0x41,0x0f,0xb7,0xd0,0x45,0x0f,0xb6,0xc1,0x66,0x89,0x01,0x66,0x89,0x51,0x02,0x44,0x88,0x41,0x04,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> defineヽgᐸ32uᐳᐤ32uㆍ32uㆍIntervalKindᕀ8uᐤ  =>  new byte[22]{0x0f,0x1f,0x44,0x00,0x00,0x41,0x0f,0xb6,0xc1,0x89,0x11,0x44,0x89,0x41,0x04,0x88,0x41,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> defineヽgᐸ64uᐳᐤ64uㆍ64uㆍIntervalKindᕀ8uᐤ  =>  new byte[23]{0x0f,0x1f,0x44,0x00,0x00,0x41,0x0f,0xb6,0xc1,0x48,0x89,0x11,0x4c,0x89,0x41,0x08,0x88,0x41,0x10,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> closedヽgᐸ8uᐳᐤ8uㆍ8uᐤ  =>  new byte[28]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc2,0x41,0x0f,0xb6,0xd0,0x45,0x33,0xc0,0x88,0x01,0x88,0x51,0x01,0x44,0x88,0x41,0x02,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> closedヽgᐸ16uᐳᐤ16uㆍ16uᐤ  =>  new byte[30]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb7,0xc2,0x41,0x0f,0xb7,0xd0,0x45,0x33,0xc0,0x66,0x89,0x01,0x66,0x89,0x51,0x02,0x44,0x88,0x41,0x04,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> closedヽgᐸ32uᐳᐤ32uㆍ32uᐤ  =>  new byte[20]{0x0f,0x1f,0x44,0x00,0x00,0x33,0xc0,0x89,0x11,0x44,0x89,0x41,0x04,0x88,0x41,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> closedヽgᐸ64uᐳᐤ64uㆍ64uᐤ  =>  new byte[21]{0x0f,0x1f,0x44,0x00,0x00,0x33,0xc0,0x48,0x89,0x11,0x4c,0x89,0x41,0x08,0x88,0x41,0x10,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> lopenヽgᐸ8uᐳᐤ8uㆍ8uᐤ  =>  new byte[31]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc2,0x41,0x0f,0xb6,0xd0,0x41,0xb8,0x08,0x00,0x00,0x00,0x88,0x01,0x88,0x51,0x01,0x44,0x88,0x41,0x02,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> lopenヽgᐸ16uᐳᐤ16uㆍ16uᐤ  =>  new byte[33]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb7,0xc2,0x41,0x0f,0xb7,0xd0,0x41,0xb8,0x08,0x00,0x00,0x00,0x66,0x89,0x01,0x66,0x89,0x51,0x02,0x44,0x88,0x41,0x04,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> lopenヽgᐸ32uᐳᐤ32uㆍ32uᐤ  =>  new byte[23]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x08,0x00,0x00,0x00,0x89,0x11,0x44,0x89,0x41,0x04,0x88,0x41,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> lopenヽgᐸ64uᐳᐤ64uㆍ64uᐤ  =>  new byte[24]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x08,0x00,0x00,0x00,0x48,0x89,0x11,0x4c,0x89,0x41,0x08,0x88,0x41,0x10,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> ropenヽgᐸ8uᐳᐤ8uㆍ8uᐤ  =>  new byte[31]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc2,0x41,0x0f,0xb6,0xd0,0x41,0xb8,0x04,0x00,0x00,0x00,0x88,0x01,0x88,0x51,0x01,0x44,0x88,0x41,0x02,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> ropenヽgᐸ16uᐳᐤ16uㆍ16uᐤ  =>  new byte[33]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb7,0xc2,0x41,0x0f,0xb7,0xd0,0x41,0xb8,0x04,0x00,0x00,0x00,0x66,0x89,0x01,0x66,0x89,0x51,0x02,0x44,0x88,0x41,0x04,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> ropenヽgᐸ32uᐳᐤ32uㆍ32uᐤ  =>  new byte[23]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x04,0x00,0x00,0x00,0x89,0x11,0x44,0x89,0x41,0x04,0x88,0x41,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> ropenヽgᐸ64uᐳᐤ64uㆍ64uᐤ  =>  new byte[24]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x04,0x00,0x00,0x00,0x48,0x89,0x11,0x4c,0x89,0x41,0x08,0x88,0x41,0x10,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> lclosedヽgᐸ8uᐳᐤ8uㆍ8uᐤ  =>  new byte[31]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc2,0x41,0x0f,0xb6,0xd0,0x41,0xb8,0x04,0x00,0x00,0x00,0x88,0x01,0x88,0x51,0x01,0x44,0x88,0x41,0x02,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> lclosedヽgᐸ16uᐳᐤ16uㆍ16uᐤ  =>  new byte[33]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb7,0xc2,0x41,0x0f,0xb7,0xd0,0x41,0xb8,0x04,0x00,0x00,0x00,0x66,0x89,0x01,0x66,0x89,0x51,0x02,0x44,0x88,0x41,0x04,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> lclosedヽgᐸ32uᐳᐤ32uㆍ32uᐤ  =>  new byte[23]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x04,0x00,0x00,0x00,0x89,0x11,0x44,0x89,0x41,0x04,0x88,0x41,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> lclosedヽgᐸ64uᐳᐤ64uㆍ64uᐤ  =>  new byte[24]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x04,0x00,0x00,0x00,0x48,0x89,0x11,0x4c,0x89,0x41,0x08,0x88,0x41,0x10,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> rclosedヽgᐸ8uᐳᐤ8uㆍ8uᐤ  =>  new byte[31]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc2,0x41,0x0f,0xb6,0xd0,0x41,0xb8,0x08,0x00,0x00,0x00,0x88,0x01,0x88,0x51,0x01,0x44,0x88,0x41,0x02,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> rclosedヽgᐸ16uᐳᐤ16uㆍ16uᐤ  =>  new byte[33]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb7,0xc2,0x41,0x0f,0xb7,0xd0,0x41,0xb8,0x08,0x00,0x00,0x00,0x66,0x89,0x01,0x66,0x89,0x51,0x02,0x44,0x88,0x41,0x04,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> rclosedヽgᐸ32uᐳᐤ32uㆍ32uᐤ  =>  new byte[23]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x08,0x00,0x00,0x00,0x89,0x11,0x44,0x89,0x41,0x04,0x88,0x41,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> rclosedヽgᐸ64uᐳᐤ64uㆍ64uᐤ  =>  new byte[24]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x08,0x00,0x00,0x00,0x48,0x89,0x11,0x4c,0x89,0x41,0x08,0x88,0x41,0x10,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> openヽgᐸ8uᐳᐤ8uㆍ8uᐤ  =>  new byte[31]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc2,0x41,0x0f,0xb6,0xd0,0x41,0xb8,0x01,0x00,0x00,0x00,0x88,0x01,0x88,0x51,0x01,0x44,0x88,0x41,0x02,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> openヽgᐸ16uᐳᐤ16uㆍ16uᐤ  =>  new byte[33]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb7,0xc2,0x41,0x0f,0xb7,0xd0,0x41,0xb8,0x01,0x00,0x00,0x00,0x66,0x89,0x01,0x66,0x89,0x51,0x02,0x44,0x88,0x41,0x04,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> openヽgᐸ32uᐳᐤ32uㆍ32uᐤ  =>  new byte[23]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x01,0x00,0x00,0x00,0x89,0x11,0x44,0x89,0x41,0x04,0x88,0x41,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> openヽgᐸ64uᐳᐤ64uㆍ64uᐤ  =>  new byte[24]{0x0f,0x1f,0x44,0x00,0x00,0xb8,0x01,0x00,0x00,0x00,0x48,0x89,0x11,0x4c,0x89,0x41,0x08,0x88,0x41,0x10,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> partitionヽgᐸ8uᐳᐤspan8uㆍrspan32uᐤ  =>  new byte[109]{0x57,0x56,0x53,0x48,0x83,0xec,0x20,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x04,0x24,0x48,0x89,0x44,0x24,0x10,0x48,0x8b,0xd9,0x48,0x8d,0x04,0x24,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x00,0xc5,0xfa,0x7f,0x40,0x10,0x48,0x8b,0x02,0x8b,0x52,0x08,0x49,0x8b,0x08,0x45,0x8b,0x40,0x08,0x4c,0x8d,0x0c,0x24,0x49,0x89,0x01,0x41,0x89,0x51,0x08,0x48,0x8d,0x44,0x24,0x10,0x48,0x89,0x08,0x44,0x89,0x40,0x08,0x48,0x8b,0xfb,0x48,0x8d,0x34,0x24,0xe8,0x07,0x8b,0x88,0x5b,0x48,0xa5,0xe8,0x00,0x8b,0x88,0x5b,0x48,0xa5,0x48,0x8b,0xc3,0x48,0x83,0xc4,0x20,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> partitionヽgᐸ16uᐳᐤspan16uㆍrspan32uᐤ  =>  new byte[109]{0x57,0x56,0x53,0x48,0x83,0xec,0x20,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x04,0x24,0x48,0x89,0x44,0x24,0x10,0x48,0x8b,0xd9,0x48,0x8d,0x04,0x24,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x00,0xc5,0xfa,0x7f,0x40,0x10,0x48,0x8b,0x02,0x8b,0x52,0x08,0x49,0x8b,0x08,0x45,0x8b,0x40,0x08,0x4c,0x8d,0x0c,0x24,0x49,0x89,0x01,0x41,0x89,0x51,0x08,0x48,0x8d,0x44,0x24,0x10,0x48,0x89,0x08,0x44,0x89,0x40,0x08,0x48,0x8b,0xfb,0x48,0x8d,0x34,0x24,0xe8,0x77,0x8a,0x88,0x5b,0x48,0xa5,0xe8,0x70,0x8a,0x88,0x5b,0x48,0xa5,0x48,0x8b,0xc3,0x48,0x83,0xc4,0x20,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> partitionヽgᐸ32uᐳᐤspan32uㆍrspan32uᐤ  =>  new byte[109]{0x57,0x56,0x53,0x48,0x83,0xec,0x20,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x04,0x24,0x48,0x89,0x44,0x24,0x10,0x48,0x8b,0xd9,0x48,0x8d,0x04,0x24,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x00,0xc5,0xfa,0x7f,0x40,0x10,0x48,0x8b,0x02,0x8b,0x52,0x08,0x49,0x8b,0x08,0x45,0x8b,0x40,0x08,0x4c,0x8d,0x0c,0x24,0x49,0x89,0x01,0x41,0x89,0x51,0x08,0x48,0x8d,0x44,0x24,0x10,0x48,0x89,0x08,0x44,0x89,0x40,0x08,0x48,0x8b,0xfb,0x48,0x8d,0x34,0x24,0xe8,0xe7,0x85,0x88,0x5b,0x48,0xa5,0xe8,0xe0,0x85,0x88,0x5b,0x48,0xa5,0x48,0x8b,0xc3,0x48,0x83,0xc4,0x20,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> partitionヽgᐸ64uᐳᐤspan64uㆍrspan32uᐤ  =>  new byte[109]{0x57,0x56,0x53,0x48,0x83,0xec,0x20,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x04,0x24,0x48,0x89,0x44,0x24,0x10,0x48,0x8b,0xd9,0x48,0x8d,0x04,0x24,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x00,0xc5,0xfa,0x7f,0x40,0x10,0x48,0x8b,0x02,0x8b,0x52,0x08,0x49,0x8b,0x08,0x45,0x8b,0x40,0x08,0x4c,0x8d,0x0c,0x24,0x49,0x89,0x01,0x41,0x89,0x51,0x08,0x48,0x8d,0x44,0x24,0x10,0x48,0x89,0x08,0x44,0x89,0x40,0x08,0x48,0x8b,0xfb,0x48,0x8d,0x34,0x24,0xe8,0x57,0x85,0x88,0x5b,0x48,0xa5,0xe8,0x50,0x85,0x88,0x5b,0x48,0xa5,0x48,0x8b,0xc3,0x48,0x83,0xc4,0x20,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> unitヽgᐸ64uᐳᐤᐤ  =>  new byte[21]{0x50,0x33,0xc0,0x48,0x89,0x04,0x24,0xc6,0x04,0x24,0x00,0x48,0x0f,0xbe,0x04,0x24,0x48,0x83,0xc4,0x08,0xc3};

    }
}
