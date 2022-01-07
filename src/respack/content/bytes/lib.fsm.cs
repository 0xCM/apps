﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2022-01-06 21:17:28 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class lib_fsm
    {
        public static ReadOnlySpan<byte> contextヽᐤIPolyrandㆍulongᐤ  =>  new byte[56]{0x57,0x56,0x53,0x48,0x83,0xec,0x20,0x48,0x8b,0xf9,0x48,0x8b,0xf2,0x48,0xb9,0x88,0x5d,0x82,0x66,0xfb,0x7f,0x00,0x00,0xe8,0x04,0x0e,0xac,0x5b,0x48,0x8b,0xd8,0x48,0x8b,0xcb,0x48,0x8b,0xd7,0x4c,0x8b,0xc6,0xe8,0x8b,0x0d,0x46,0xfd,0x48,0x8b,0xc3,0x48,0x83,0xc4,0x20,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> primalヽgᐸ16uᐳᐤstringㆍ16uㆍ16uㆍ16uㆍ16uㆍ64uᐤ  =>  new byte[138]{0x57,0x56,0x53,0x48,0x83,0xec,0x20,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x04,0x24,0x48,0x8b,0xd9,0x48,0x8d,0x04,0x24,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x00,0xc5,0xfa,0x7f,0x40,0x10,0x48,0x89,0x14,0x24,0x41,0x0f,0xb7,0xc0,0x66,0x89,0x44,0x24,0x10,0x41,0x0f,0xb7,0xd1,0x66,0x89,0x54,0x24,0x12,0x8b,0x54,0x24,0x60,0x0f,0xb7,0xd2,0x66,0x89,0x54,0x24,0x14,0x8b,0x54,0x24,0x68,0x0f,0xb7,0xd2,0x66,0x89,0x54,0x24,0x16,0x48,0x8b,0x54,0x24,0x70,0x48,0x89,0x54,0x24,0x08,0x66,0xc7,0x44,0x24,0x18,0x00,0x00,0xff,0xc8,0x0f,0xb7,0xc0,0x66,0x89,0x44,0x24,0x1a,0x48,0x8b,0xfb,0x48,0x8d,0x34,0x24,0xe8,0x37,0xff,0xab,0x5b,0x48,0xa5,0x48,0xa5,0x48,0xa5,0x48,0x8b,0xc3,0x48,0x83,0xc4,0x20,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> createヽgᐸ16uᐳᐤPrimalFsmSpecᐸushortᐳㆍ64uㆍ64uᐤ  =>  new byte[492]{0x41,0x57,0x41,0x56,0x57,0x56,0x55,0x53,0x48,0x81,0xec,0xb8,0x00,0x00,0x00,0xc5,0xf8,0x77,0x48,0x8b,0xf1,0x48,0x8d,0x7c,0x24,0x38,0xb9,0x1c,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x48,0x8b,0xf1,0x33,0xc9,0x48,0x89,0x8c,0x24,0xa8,0x00,0x00,0x00,0x48,0x89,0x8c,0x24,0xb0,0x00,0x00,0x00,0x48,0x89,0x8c,0x24,0xa8,0x00,0x00,0x00,0x48,0x89,0x8c,0x24,0xb0,0x00,0x00,0x00,0x48,0x8d,0x8c,0x24,0xa8,0x00,0x00,0x00,0xe8,0xd0,0x81,0x6f,0xfd,0x48,0xb9,0x80,0x5e,0xa4,0x66,0xfb,0x7f,0x00,0x00,0xe8,0x79,0x0b,0xac,0x5b,0x48,0x8b,0xf8,0x48,0x8d,0x4f,0x08,0x48,0x8b,0x84,0x24,0xa8,0x00,0x00,0x00,0x48,0x89,0x01,0x48,0x8b,0x84,0x24,0xb0,0x00,0x00,0x00,0x48,0x89,0x41,0x08,0x48,0xb9,0xf0,0x37,0xa4,0x66,0xfb,0x7f,0x00,0x00,0xe8,0x4c,0x0b,0xac,0x5b,0x48,0x8b,0xd8,0x48,0x8d,0x4b,0x08,0x48,0x8b,0xd7,0xe8,0x7d,0xfc,0xab,0x5b,0x48,0x8b,0xd7,0xbf,0x01,0x00,0x00,0x00,0x48,0x8d,0x6b,0x10,0x48,0x8d,0x4d,0x00,0xe8,0x38,0xfc,0xab,0x5b,0x40,0x88,0x7d,0x08,0x48,0x8b,0x7e,0x08,0xbd,0x01,0x00,0x00,0x00,0x48,0xb9,0x88,0x5d,0x82,0x66,0xfb,0x7f,0x00,0x00,0xe8,0x0c,0x0b,0xac,0x5b,0x4c,0x8b,0xf0,0x48,0x8b,0xd3,0x48,0x8d,0x4c,0x24,0x78,0x40,0x88,0x29,0x48,0x89,0x79,0x08,0x49,0x8b,0xce,0x4c,0x8d,0x44,0x24,0x78,0xe8,0x85,0x0a,0x46,0xfd,0xc5,0xfa,0x6f,0x06,0xc5,0xfa,0x7f,0x84,0x24,0x88,0x00,0x00,0x00,0xc5,0xfa,0x6f,0x46,0x10,0xc5,0xfa,0x7f,0x84,0x24,0x98,0x00,0x00,0x00,0x48,0xb9,0x10,0x8f,0x12,0x65,0xfb,0x7f,0x00,0x00,0xe8,0xc3,0x0a,0xac,0x5b,0x49,0xb8,0x48,0x23,0x33,0x65,0xfb,0x7f,0x00,0x00,0xba,0x01,0x00,0x00,0x00,0xf0,0x41,0x0f,0xc1,0x10,0xff,0xc2,0x89,0x50,0x08,0x4c,0x8b,0x84,0x24,0x88,0x00,0x00,0x00,0x33,0xd2,0x48,0xb9,0x90,0x13,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x09,0x49,0xb9,0x10,0x5e,0x3d,0x61,0xa1,0x02,0x00,0x00,0x4d,0x8b,0x09,0x4c,0x8d,0x54,0x24,0x58,0x4d,0x89,0x02,0x49,0x89,0x42,0x08,0x49,0x89,0x52,0x10,0x49,0x89,0x4a,0x18,0x4c,0x8d,0x44,0x24,0x58,0x49,0x8b,0xd1,0x33,0xc9,0xe8,0xc3,0xf4,0x9d,0x57,0x48,0x8b,0xf8,0x0f,0xb7,0x5e,0x18,0x0f,0xb7,0x6e,0x1a,0xc5,0xfa,0x6f,0x06,0xc5,0xfa,0x7f,0x44,0x24,0x38,0xc5,0xfa,0x6f,0x46,0x10,0xc5,0xfa,0x7f,0x44,0x24,0x48,0x49,0x8b,0xce,0x48,0x8d,0x54,0x24,0x38,0xe8,0xf6,0xf9,0xff,0xff,0x48,0x8b,0xf0,0x48,0xb9,0xa8,0x7f,0x52,0x69,0xfb,0x7f,0x00,0x00,0xe8,0x24,0x0a,0xac,0x5b,0x4c,0x8b,0xf8,0x89,0x6c,0x24,0x20,0x48,0x89,0x74,0x24,0x28,0x49,0x8b,0xcf,0x48,0x8b,0xd7,0x4d,0x8b,0xc6,0x44,0x8b,0xcb,0xe8,0x6f,0xfd,0xff,0xff,0x49,0x8b,0xc7,0x48,0x81,0xc4,0xb8,0x00,0x00,0x00,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0x41,0x5f,0xc3};

        public static ReadOnlySpan<byte> createヽgᐸ16uᐳᐤIWfRuntimeㆍPrimalFsmSpecᐸushortᐳㆍ64uㆍ64uᐤ  =>  new byte[404]{0x41,0x57,0x41,0x56,0x57,0x56,0x55,0x53,0x48,0x81,0xec,0xc8,0x00,0x00,0x00,0xc5,0xf8,0x77,0x48,0x8b,0xf1,0x48,0x8d,0x7c,0x24,0x48,0xb9,0x20,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x48,0x8b,0xf1,0xc5,0xfa,0x6f,0x02,0xc5,0xfa,0x7f,0x84,0x24,0xa8,0x00,0x00,0x00,0xc5,0xfa,0x6f,0x42,0x10,0xc5,0xfa,0x7f,0x84,0x24,0xb8,0x00,0x00,0x00,0xc5,0xfa,0x6f,0x84,0x24,0xa8,0x00,0x00,0x00,0xc5,0xfa,0x7f,0x84,0x24,0x88,0x00,0x00,0x00,0xc5,0xfa,0x6f,0x84,0x24,0xb8,0x00,0x00,0x00,0xc5,0xfa,0x7f,0x84,0x24,0x98,0x00,0x00,0x00,0x48,0xb9,0x10,0x8f,0x12,0x65,0xfb,0x7f,0x00,0x00,0xe8,0x49,0x05,0xac,0x5b,0x49,0xb8,0x48,0x23,0x33,0x65,0xfb,0x7f,0x00,0x00,0xba,0x01,0x00,0x00,0x00,0xf0,0x41,0x0f,0xc1,0x10,0xff,0xc2,0x89,0x50,0x08,0x4c,0x8b,0x84,0x24,0x88,0x00,0x00,0x00,0x33,0xd2,0x48,0xb9,0x90,0x13,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x09,0x49,0xb9,0x10,0x5e,0x3d,0x61,0xa1,0x02,0x00,0x00,0x4d,0x8b,0x09,0x4c,0x8d,0x54,0x24,0x68,0x4d,0x89,0x02,0x49,0x89,0x42,0x08,0x49,0x89,0x52,0x10,0x49,0x89,0x4a,0x18,0x4c,0x8d,0x44,0x24,0x68,0x49,0x8b,0xd1,0x33,0xc9,0xe8,0x49,0xef,0x9d,0x57,0x48,0x8b,0xf8,0x48,0x8b,0xce,0x49,0xbb,0xf0,0x18,0x03,0x65,0xfb,0x7f,0x00,0x00,0x48,0xb8,0xf0,0x18,0x03,0x65,0xfb,0x7f,0x00,0x00,0x39,0x09,0xff,0x10,0x48,0x8b,0xc8,0xc5,0xfa,0x6f,0x84,0x24,0xa8,0x00,0x00,0x00,0xc5,0xfa,0x7f,0x44,0x24,0x48,0xc5,0xfa,0x6f,0x84,0x24,0xb8,0x00,0x00,0x00,0xc5,0xfa,0x7f,0x44,0x24,0x58,0x48,0x8d,0x54,0x24,0x48,0xe8,0x18,0xfb,0xff,0xff,0x48,0x8b,0xd8,0x48,0x8b,0xac,0x24,0xb0,0x00,0x00,0x00,0x41,0xbe,0x01,0x00,0x00,0x00,0x48,0xb9,0xa8,0x7f,0x52,0x69,0xfb,0x7f,0x00,0x00,0xe8,0x80,0x04,0xac,0x5b,0x4c,0x8b,0xf8,0x48,0x8b,0xd7,0x4c,0x8b,0xc6,0x44,0x0f,0xb7,0x8c,0x24,0xc0,0x00,0x00,0x00,0x0f,0xb7,0x84,0x24,0xc2,0x00,0x00,0x00,0x48,0x8d,0x4c,0x24,0x38,0x44,0x88,0x31,0x48,0x89,0x69,0x08,0x49,0x8b,0xcf,0x89,0x44,0x24,0x20,0x48,0x89,0x5c,0x24,0x28,0x48,0x8d,0x44,0x24,0x38,0x48,0x89,0x44,0x24,0x30,0xe8,0x9f,0xf7,0xff,0xff,0x49,0x8b,0xc7,0x48,0x81,0xc4,0xc8,0x00,0x00,0x00,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0x41,0x5f,0xc3};

        public static ReadOnlySpan<byte> identifyヽgᐸ16uᐳᐤPrimalFsmSpecᐸushortᐳᐤ  =>  new byte[141]{0x56,0x48,0x83,0xec,0x40,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x48,0x89,0x44,0x24,0x38,0x48,0x8b,0x31,0x48,0xb9,0x10,0x8f,0x12,0x65,0xfb,0x7f,0x00,0x00,0xe8,0xd3,0x03,0xac,0x5b,0x49,0xb8,0x48,0x23,0x33,0x65,0xfb,0x7f,0x00,0x00,0xba,0x01,0x00,0x00,0x00,0xf0,0x41,0x0f,0xc1,0x10,0xff,0xc2,0x89,0x50,0x08,0x45,0x33,0xc0,0x48,0xba,0x90,0x13,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0xb9,0x10,0x5e,0x3d,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x09,0x4c,0x8d,0x4c,0x24,0x20,0x49,0x89,0x31,0x49,0x89,0x41,0x08,0x4d,0x89,0x41,0x10,0x49,0x89,0x51,0x18,0x4c,0x8d,0x44,0x24,0x20,0x48,0x8b,0xd1,0x33,0xc9,0xe8,0xda,0xed,0x9d,0x57,0x90,0x48,0x83,0xc4,0x40,0x5e,0xc3};

        public static ReadOnlySpan<byte> createヽgᐸ16uᐳᐤIWfRuntimeㆍPrimalFsmSpecᐸushortᐳᐤ  =>  new byte[362]{0x41,0x57,0x41,0x56,0x41,0x55,0x41,0x54,0x57,0x56,0x55,0x53,0x48,0x81,0xec,0xa8,0x00,0x00,0x00,0xc5,0xf8,0x77,0x48,0x8b,0xf1,0x48,0x8d,0x7c,0x24,0x48,0xb9,0x18,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x48,0x8b,0xf9,0x48,0x8b,0xf2,0xc5,0xfa,0x6f,0x06,0xc5,0xfa,0x7f,0x84,0x24,0x88,0x00,0x00,0x00,0xc5,0xfa,0x6f,0x46,0x10,0xc5,0xfa,0x7f,0x84,0x24,0x98,0x00,0x00,0x00,0x48,0xb9,0x10,0x8f,0x12,0x65,0xfb,0x7f,0x00,0x00,0xe8,0xf6,0x02,0xac,0x5b,0x49,0xb8,0x48,0x23,0x33,0x65,0xfb,0x7f,0x00,0x00,0xba,0x01,0x00,0x00,0x00,0xf0,0x41,0x0f,0xc1,0x10,0xff,0xc2,0x89,0x50,0x08,0x4c,0x8b,0x84,0x24,0x88,0x00,0x00,0x00,0x33,0xd2,0x48,0xb9,0x90,0x13,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x09,0x49,0xb9,0x10,0x5e,0x3d,0x61,0xa1,0x02,0x00,0x00,0x4d,0x8b,0x09,0x4c,0x8d,0x54,0x24,0x68,0x4d,0x89,0x02,0x49,0x89,0x42,0x08,0x49,0x89,0x52,0x10,0x49,0x89,0x4a,0x18,0x4c,0x8d,0x44,0x24,0x68,0x49,0x8b,0xd1,0x33,0xc9,0xe8,0xf6,0xec,0x9d,0x57,0x48,0x8b,0xd8,0x0f,0xb7,0x6e,0x18,0x44,0x0f,0xb7,0x76,0x1a,0x48,0x8b,0xcf,0x49,0xbb,0xf8,0x18,0x03,0x65,0xfb,0x7f,0x00,0x00,0x48,0xb8,0xf8,0x18,0x03,0x65,0xfb,0x7f,0x00,0x00,0x39,0x09,0xff,0x10,0x48,0x8b,0xc8,0xc5,0xfa,0x6f,0x06,0xc5,0xfa,0x7f,0x44,0x24,0x48,0xc5,0xfa,0x6f,0x46,0x10,0xc5,0xfa,0x7f,0x44,0x24,0x58,0x48,0x8d,0x54,0x24,0x48,0xe8,0xc5,0xf8,0xff,0xff,0x4c,0x8b,0xf8,0x48,0x8b,0x76,0x08,0x41,0xbc,0x01,0x00,0x00,0x00,0x48,0xb9,0xa8,0x7f,0x52,0x69,0xfb,0x7f,0x00,0x00,0xe8,0x31,0x02,0xac,0x5b,0x4c,0x8b,0xe8,0x48,0x8b,0xd3,0x4c,0x8b,0xc7,0x44,0x8b,0xcd,0x48,0x8d,0x4c,0x24,0x38,0x44,0x88,0x21,0x48,0x89,0x71,0x08,0x49,0x8b,0xcd,0x44,0x89,0x74,0x24,0x20,0x4c,0x89,0x7c,0x24,0x28,0x48,0x8d,0x44,0x24,0x38,0x48,0x89,0x44,0x24,0x30,0xe8,0x5d,0xf5,0xff,0xff,0x49,0x8b,0xc5,0x48,0x81,0xc4,0xa8,0x00,0x00,0x00,0x5b,0x5d,0x5e,0x5f,0x41,0x5c,0x41,0x5d,0x41,0x5e,0x41,0x5f,0xc3};

        public static ReadOnlySpan<byte> runヽgᐸ16uᐳᐤPrimalFsmSpecᐸushortᐳㆍ32iㆍboolᐤ  =>  new byte[586]{0x41,0x57,0x41,0x56,0x41,0x54,0x57,0x56,0x55,0x53,0x48,0x81,0xec,0x80,0x00,0x00,0x00,0xc5,0xf8,0x77,0x48,0x8b,0xf1,0x48,0x8d,0x7c,0x24,0x20,0xb9,0x18,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x48,0x8b,0xf1,0x8b,0xfa,0x41,0x8b,0xd8,0x8b,0xd7,0xc1,0xe2,0x03,0x48,0x8d,0x4c,0x24,0x70,0xe8,0xb9,0x70,0x6f,0xfd,0x48,0x8b,0x6c,0x24,0x70,0x44,0x8b,0x74,0x24,0x78,0x41,0xc1,0xee,0x03,0x45,0x33,0xc0,0x33,0xc9,0x48,0x8d,0x54,0x24,0x60,0x44,0x88,0x02,0x48,0x89,0x4a,0x08,0x4c,0x8d,0x44,0x24,0x60,0xb9,0xff,0xff,0x00,0x00,0xba,0xff,0xff,0xff,0xff,0xe8,0xf6,0x5e,0xfa,0xff,0x4c,0x8b,0xf8,0x48,0xb9,0x48,0x02,0x33,0x65,0xfb,0x7f,0x00,0x00,0xba,0x78,0x00,0x00,0x00,0xe8,0xb7,0xc0,0xa8,0x5b,0x48,0xb9,0x90,0x2c,0x2b,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x11,0x48,0x85,0xd2,0x75,0x56,0x48,0xb9,0x90,0x09,0x03,0x68,0xfb,0x7f,0x00,0x00,0xe8,0x06,0x01,0xac,0x5b,0x4c,0x8b,0xe0,0x48,0xba,0x88,0x2c,0x2b,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x85,0xd2,0x0f,0x84,0x7f,0x01,0x00,0x00,0x49,0x8d,0x4c,0x24,0x08,0xe8,0x23,0xf2,0xab,0x5b,0x48,0xba,0x28,0x6f,0x1d,0x69,0xfb,0x7f,0x00,0x00,0x49,0x89,0x54,0x24,0x18,0x48,0xb9,0x90,0x2c,0x2b,0x61,0xa1,0x02,0x00,0x00,0x49,0x8b,0xd4,0xe8,0xd2,0xf1,0xab,0x5b,0x49,0x8b,0xd4,0x49,0x8b,0xcf,0xe8,0xcf,0xf7,0xff,0xff,0x48,0x8b,0xc8,0x8b,0xd7,0xe8,0xe5,0x59,0x22,0xff,0x48,0x8b,0xc8,0xe8,0x05,0x34,0x21,0xff,0x84,0xdb,0x0f,0x84,0x95,0x00,0x00,0x00,0x48,0x85,0xc0,0x75,0x06,0x33,0xc9,0x33,0xd2,0xeb,0x07,0x48,0x8d,0x48,0x10,0x8b,0x50,0x08,0xc5,0xfa,0x6f,0x06,0xc5,0xfa,0x7f,0x44,0x24,0x40,0xc5,0xfa,0x6f,0x46,0x10,0xc5,0xfa,0x7f,0x44,0x24,0x50,0x4c,0x8d,0x44,0x24,0x30,0x49,0x89,0x28,0x45,0x89,0x70,0x08,0x4c,0x8d,0x44,0x24,0x20,0x49,0x89,0x08,0x41,0x89,0x50,0x08,0x48,0x8d,0x4c,0x24,0x40,0x48,0x8d,0x54,0x24,0x30,0x4c,0x8d,0x44,0x24,0x20,0xe8,0xca,0xf7,0xff,0xff,0x48,0x85,0xc0,0x74,0x0a,0x48,0x8b,0xc8,0xe8,0x1d,0xf8,0xff,0xff,0xeb,0x21,0x48,0xb9,0x20,0x00,0x12,0x65,0xfb,0x7f,0x00,0x00,0xba,0xb7,0x00,0x00,0x00,0xe8,0xb7,0xbf,0xa8,0x5b,0x48,0xb8,0xe8,0xfd,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x00,0x48,0x81,0xc4,0x80,0x00,0x00,0x00,0x5b,0x5d,0x5e,0x5f,0x41,0x5c,0x41,0x5e,0x41,0x5f,0xc3,0x48,0x85,0xc0,0x75,0x06,0x33,0xc9,0x33,0xd2,0xeb,0x07,0x48,0x8d,0x48,0x10,0x8b,0x50,0x08,0xc5,0xfa,0x6f,0x06,0xc5,0xfa,0x7f,0x44,0x24,0x40,0xc5,0xfa,0x6f,0x46,0x10,0xc5,0xfa,0x7f,0x44,0x24,0x50,0x4c,0x8d,0x44,0x24,0x30,0x49,0x89,0x28,0x45,0x89,0x70,0x08,0x4c,0x8d,0x44,0x24,0x20,0x49,0x89,0x08,0x41,0x89,0x50,0x08,0x48,0x8d,0x4c,0x24,0x40,0x48,0x8d,0x54,0x24,0x30,0x4c,0x8d,0x44,0x24,0x20,0xe8,0xdd,0xf6,0xff,0xff,0x48,0x85,0xc0,0x74,0x0a,0x48,0x8b,0xc8,0xe8,0x88,0xf7,0xff,0xff,0xeb,0x21,0x48,0xb9,0x20,0x00,0x12,0x65,0xfb,0x7f,0x00,0x00,0xba,0xb7,0x00,0x00,0x00,0xe8,0x22,0xbf,0xa8,0x5b,0x48,0xb8,0xe8,0xfd,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x00,0x48,0x81,0xc4,0x80,0x00,0x00,0x00,0x5b,0x5d,0x5e,0x5f,0x41,0x5c,0x41,0x5e,0x41,0x5f,0xc3,0xe8,0x1e,0x82,0xbe,0x5b,0x49,0x8b,0xcc,0xe8,0xd6,0xc2,0xf7,0xfb};

        public static ReadOnlySpan<byte> concurrentヽgᐸ16uᐳᐤPrimalFsmSpecᐸushortᐳㆍspan64uㆍspan64uᐤ  =>  new byte[1024]{0x41,0x57,0x41,0x56,0x41,0x55,0x41,0x54,0x57,0x56,0x55,0x53,0x48,0x81,0xec,0x18,0x01,0x00,0x00,0xc5,0xf8,0x77,0x48,0x8b,0xf1,0x48,0x8d,0x7c,0x24,0x68,0xb9,0x2a,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x48,0x8b,0xf9,0x49,0x8b,0xf0,0x48,0x8b,0x1a,0x8b,0x6a,0x08,0x48,0xb9,0x08,0x95,0x52,0x69,0xfb,0x7f,0x00,0x00,0xe8,0xeb,0xfa,0xab,0x5b,0x4c,0x8b,0xf0,0x48,0xb9,0xa0,0x9b,0x52,0x69,0xfb,0x7f,0x00,0x00,0xe8,0xd9,0xfa,0xab,0x5b,0x4c,0x8b,0xf8,0x48,0xb9,0xa0,0xa2,0x52,0x69,0xfb,0x7f,0x00,0x00,0xe8,0xf7,0x59,0x9d,0x5b,0x4c,0x8b,0xe0,0x49,0x8b,0xcc,0xe8,0x84,0x95,0xff,0xff,0x49,0x8d,0x4f,0x08,0x49,0x8b,0xd4,0xe8,0xf0,0xeb,0xab,0x5b,0x49,0x8d,0x4e,0x08,0x49,0x8b,0xd7,0xe8,0xe4,0xeb,0xab,0x5b,0x48,0x63,0xd5,0x48,0xb9,0xc8,0x95,0x52,0x69,0xfb,0x7f,0x00,0x00,0xe8,0x22,0xfc,0xab,0x5b,0x4c,0x8b,0xf8,0x45,0x33,0xe4,0x41,0x83,0x7f,0x08,0x00,0x0f,0x8e,0x24,0x03,0x00,0x00,0xc5,0xfa,0x6f,0x07,0xc5,0xfa,0x7f,0x84,0x24,0xf0,0x00,0x00,0x00,0xc5,0xfa,0x6f,0x47,0x10,0xc5,0xfa,0x7f,0x84,0x24,0x00,0x01,0x00,0x00,0x44,0x3b,0xe5,0x0f,0x83,0x28,0x03,0x00,0x00,0x49,0x63,0xcc,0x48,0x8b,0x14,0xcb,0x44,0x3b,0x66,0x08,0x0f,0x83,0x17,0x03,0x00,0x00,0x48,0x8b,0x0e,0x4d,0x63,0xc4,0x4e,0x8b,0x04,0xc1,0x33,0xc9,0x48,0x89,0x8c,0x24,0xe0,0x00,0x00,0x00,0x48,0x89,0x8c,0x24,0xe8,0x00,0x00,0x00,0x48,0x89,0x8c,0x24,0xe0,0x00,0x00,0x00,0x48,0x89,0x8c,0x24,0xe8,0x00,0x00,0x00,0x48,0x8d,0x8c,0x24,0xe0,0x00,0x00,0x00,0xe8,0x5b,0x70,0x6f,0xfd,0x48,0xb9,0x80,0x5e,0xa4,0x66,0xfb,0x7f,0x00,0x00,0xe8,0x04,0xfa,0xab,0x5b,0x4c,0x8b,0xe8,0x49,0x8d,0x4d,0x08,0x48,0x8b,0x84,0x24,0xe0,0x00,0x00,0x00,0x48,0x89,0x01,0x48,0x8b,0x84,0x24,0xe8,0x00,0x00,0x00,0x48,0x89,0x41,0x08,0x48,0xb9,0xf0,0x37,0xa4,0x66,0xfb,0x7f,0x00,0x00,0xe8,0xd7,0xf9,0xab,0x5b,0x48,0x8b,0xd0,0x48,0x89,0x54,0x24,0x50,0x48,0x8d,0x4a,0x08,0x49,0x8b,0xd5,0xe8,0x03,0xeb,0xab,0x5b,0x49,0x8b,0xd5,0x41,0xbd,0x01,0x00,0x00,0x00,0x48,0x8b,0x44,0x24,0x50,0x4c,0x8d,0x40,0x10,0x4c,0x89,0x44,0x24,0x30,0x49,0x8d,0x08,0xe8,0xb4,0xea,0xab,0x5b,0x48,0x8b,0x4c,0x24,0x30,0x44,0x88,0x69,0x08,0x4c,0x8b,0xac,0x24,0xf8,0x00,0x00,0x00,0xb8,0x01,0x00,0x00,0x00,0x88,0x84,0x24,0xbc,0x00,0x00,0x00,0x48,0xb9,0x88,0x5d,0x82,0x66,0xfb,0x7f,0x00,0x00,0xe8,0x78,0xf9,0xab,0x5b,0x48,0x8b,0x54,0x24,0x50,0x48,0x8d,0x8c,0x24,0xa8,0x00,0x00,0x00,0x44,0x0f,0xb6,0x84,0x24,0xbc,0x00,0x00,0x00,0x44,0x88,0x01,0x4c,0x89,0x69,0x08,0x48,0x89,0x44,0x24,0x48,0x48,0x8b,0xc8,0x4c,0x8d,0x84,0x24,0xa8,0x00,0x00,0x00,0xe8,0xde,0xf8,0x45,0xfd,0xc5,0xfa,0x6f,0x84,0x24,0xf0,0x00,0x00,0x00,0xc5,0xfa,0x7f,0x84,0x24,0xc0,0x00,0x00,0x00,0xc5,0xfa,0x6f,0x84,0x24,0x00,0x01,0x00,0x00,0xc5,0xfa,0x7f,0x84,0x24,0xd0,0x00,0x00,0x00,0x48,0xb9,0x10,0x8f,0x12,0x65,0xfb,0x7f,0x00,0x00,0xe8,0x13,0xf9,0xab,0x5b,0x49,0xb8,0x48,0x23,0x33,0x65,0xfb,0x7f,0x00,0x00,0xba,0x01,0x00,0x00,0x00,0xf0,0x41,0x0f,0xc1,0x10,0xff,0xc2,0x89,0x50,0x08,0x4c,0x8b,0x84,0x24,0xc0,0x00,0x00,0x00,0x33,0xd2,0x48,0xb9,0x90,0x13,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x09,0x49,0xb9,0x10,0x5e,0x3d,0x61,0xa1,0x02,0x00,0x00,0x4d,0x8b,0x09,0x4c,0x8d,0x94,0x24,0x88,0x00,0x00,0x00,0x4d,0x89,0x02,0x49,0x89,0x42,0x08,0x49,0x89,0x52,0x10,0x49,0x89,0x4a,0x18,0x4c,0x8d,0x84,0x24,0x88,0x00,0x00,0x00,0x49,0x8b,0xd1,0x33,0xc9,0xe8,0x0d,0xe3,0x9d,0x57,0x4c,0x8b,0xe8,0xc5,0xfa,0x6f,0x84,0x24,0xf0,0x00,0x00,0x00,0xc5,0xfa,0x7f,0x44,0x24,0x68,0xc5,0xfa,0x6f,0x84,0x24,0x00,0x01,0x00,0x00,0xc5,0xfa,0x7f,0x44,0x24,0x78,0x48,0x8b,0x4c,0x24,0x48,0x48,0x8d,0x54,0x24,0x68,0xe8,0x3d,0xe8,0xff,0xff,0x48,0x89,0x44,0x24,0x40,0x48,0xb9,0xa8,0x7f,0x52,0x69,0xfb,0x7f,0x00,0x00,0xe8,0x69,0xf8,0xab,0x5b,0x0f,0xb7,0x8c,0x24,0x0a,0x01,0x00,0x00,0x89,0x4c,0x24,0x20,0x48,0x8b,0x4c,0x24,0x40,0x48,0x89,0x4c,0x24,0x28,0x48,0x89,0x44,0x24,0x38,0x48,0x8b,0xc8,0x49,0x8b,0xd5,0x4c,0x8b,0x44,0x24,0x48,0x44,0x0f,0xb7,0x8c,0x24,0x08,0x01,0x00,0x00,0xe8,0x9d,0xeb,0xff,0xff,0x48,0x8b,0x4c,0x24,0x38,0xe8,0xd3,0xf1,0xff,0xff,0x4c,0x8b,0xe8,0x49,0x8b,0x46,0x18,0x44,0x89,0xa4,0x24,0x14,0x01,0x00,0x00,0x48,0x85,0xc0,0x48,0x89,0x44,0x24,0x60,0x75,0x4e,0x48,0xb9,0x38,0x98,0x52,0x69,0xfb,0x7f,0x00,0x00,0xe8,0x03,0xf8,0xab,0x5b,0x48,0x89,0x44,0x24,0x58,0x48,0x8d,0x48,0x08,0x49,0x8b,0xd6,0xe8,0x32,0xe9,0xab,0x5b,0x48,0xba,0x68,0x70,0x1d,0x69,0xfb,0x7f,0x00,0x00,0x48,0x8b,0x44,0x24,0x58,0x48,0x89,0x50,0x18,0x49,0x8d,0x4e,0x18,0x48,0x89,0x44,0x24,0x58,0x48,0x8b,0xd0,0xe8,0x0e,0xe9,0xab,0x5b,0x48,0x8b,0x44,0x24,0x58,0x48,0x89,0x44,0x24,0x60,0x41,0x8b,0x4d,0x00,0xe8,0xdb,0x2a,0xfa,0xfb,0x4c,0x8b,0xc0,0x4d,0x85,0xc0,0x75,0x21,0x48,0xb9,0x20,0x00,0x12,0x65,0xfb,0x7f,0x00,0x00,0xba,0xb0,0x02,0x00,0x00,0xe8,0x9f,0xfb,0xab,0x5b,0x48,0xb9,0xf8,0x16,0x28,0x61,0xa1,0x02,0x00,0x00,0x4c,0x8b,0x01,0x33,0xc9,0x89,0x4c,0x24,0x20,0x49,0x8b,0xcd,0x48,0x8b,0x54,0x24,0x60,0x45,0x33,0xc9,0xe8,0xa4,0xf1,0xff,0xff,0x4c,0x8b,0xc0,0x8b,0x94,0x24,0x14,0x01,0x00,0x00,0x49,0x8b,0xcf,0xe8,0xca,0xe9,0xab,0x5b,0x41,0xff,0xc4,0x45,0x39,0x67,0x08,0x0f,0x8f,0xdc,0xfc,0xff,0xff,0x49,0x8b,0xcf,0x45,0x33,0xc0,0xba,0xff,0xff,0xff,0xff,0xe8,0x05,0x93,0xf9,0xfb,0x49,0x8b,0x46,0x08,0x48,0x81,0xc4,0x18,0x01,0x00,0x00,0x5b,0x5d,0x5e,0x5f,0x41,0x5c,0x41,0x5d,0x41,0x5e,0x41,0x5f,0xc3,0xe8,0x90,0x7b,0xbe,0x5b};

        public static ReadOnlySpan<byte> sequentialヽgᐸ16uᐳᐤPrimalFsmSpecᐸushortᐳㆍspan64uㆍspan64uᐤ  =>  new byte[944]{0x41,0x57,0x41,0x56,0x41,0x55,0x41,0x54,0x57,0x56,0x55,0x53,0x48,0x81,0xec,0xc8,0x01,0x00,0x00,0xc5,0xf8,0x77,0x48,0x8b,0xf1,0x48,0x8d,0x7c,0x24,0x48,0xb9,0x60,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x48,0x8b,0xe9,0x49,0x8b,0xd8,0x4c,0x8b,0x32,0x44,0x8b,0x7a,0x08,0x48,0xb9,0xd8,0xa5,0x52,0x69,0xfb,0x7f,0x00,0x00,0xe8,0xaa,0xf6,0xab,0x5b,0x4c,0x8b,0xe0,0x48,0xb9,0xa0,0x9b,0x52,0x69,0xfb,0x7f,0x00,0x00,0xe8,0x98,0xf6,0xab,0x5b,0x48,0x8b,0xf0,0x48,0xb9,0xa0,0xa2,0x52,0x69,0xfb,0x7f,0x00,0x00,0xe8,0xb6,0x55,0x9d,0x5b,0x48,0x8b,0xf8,0x48,0x8b,0xcf,0xe8,0x43,0x91,0xff,0xff,0x48,0x8d,0x4e,0x08,0x48,0x8b,0xd7,0xe8,0xaf,0xe7,0xab,0x5b,0x49,0x8d,0x4c,0x24,0x08,0x48,0x8b,0xd6,0xe8,0xa2,0xe7,0xab,0x5b,0x45,0x33,0xed,0x45,0x85,0xff,0x0f,0x8e,0xf8,0x02,0x00,0x00,0xc5,0xfa,0x6f,0x45,0x00,0xc5,0xfa,0x7f,0x84,0x24,0x18,0x01,0x00,0x00,0xc5,0xfa,0x6f,0x45,0x10,0xc5,0xfa,0x7f,0x84,0x24,0x28,0x01,0x00,0x00,0x49,0x63,0xcd,0x49,0x8b,0x14,0xce,0x44,0x3b,0x6b,0x08,0x0f,0x83,0xe4,0x02,0x00,0x00,0x48,0x8b,0x0b,0x4d,0x63,0xc5,0x4e,0x8b,0x04,0xc1,0x33,0xc9,0x48,0x89,0x8c,0x24,0x08,0x01,0x00,0x00,0x48,0x89,0x8c,0x24,0x10,0x01,0x00,0x00,0x48,0x89,0x8c,0x24,0x08,0x01,0x00,0x00,0x48,0x89,0x8c,0x24,0x10,0x01,0x00,0x00,0x48,0x8d,0x8c,0x24,0x08,0x01,0x00,0x00,0xe8,0x38,0x6c,0x6f,0xfd,0x48,0xb9,0x80,0x5e,0xa4,0x66,0xfb,0x7f,0x00,0x00,0xe8,0xe1,0xf5,0xab,0x5b,0x48,0x8b,0xf0,0x48,0x8d,0x4e,0x08,0x48,0x8b,0x84,0x24,0x08,0x01,0x00,0x00,0x48,0x89,0x01,0x48,0x8b,0x84,0x24,0x10,0x01,0x00,0x00,0x48,0x89,0x41,0x08,0x48,0xb9,0xf0,0x37,0xa4,0x66,0xfb,0x7f,0x00,0x00,0xe8,0xb4,0xf5,0xab,0x5b,0x48,0x8b,0xf8,0x48,0x8d,0x4f,0x08,0x48,0x8b,0xd6,0xe8,0xe5,0xe6,0xab,0x5b,0x48,0x8b,0xd6,0xbe,0x01,0x00,0x00,0x00,0x48,0x8d,0x47,0x10,0x48,0x89,0x44,0x24,0x30,0x48,0x8d,0x08,0xe8,0x9c,0xe6,0xab,0x5b,0x48,0x8b,0x4c,0x24,0x30,0x40,0x88,0x71,0x08,0x48,0x8b,0xb4,0x24,0x20,0x01,0x00,0x00,0xb8,0x01,0x00,0x00,0x00,0x88,0x84,0x24,0x9c,0x00,0x00,0x00,0x48,0xb9,0x88,0x5d,0x82,0x66,0xfb,0x7f,0x00,0x00,0xe8,0x60,0xf5,0xab,0x5b,0x48,0x8b,0xd7,0x48,0x8d,0x8c,0x24,0x88,0x00,0x00,0x00,0x40,0x0f,0xb6,0xbc,0x24,0x9c,0x00,0x00,0x00,0x40,0x88,0x39,0x48,0x89,0x71,0x08,0x48,0x89,0x44,0x24,0x40,0x48,0x8b,0xc8,0x4c,0x8d,0x84,0x24,0x88,0x00,0x00,0x00,0xe8,0xc8,0xf4,0x45,0xfd,0xc5,0xfa,0x6f,0x84,0x24,0x18,0x01,0x00,0x00,0xc5,0xfa,0x7f,0x84,0x24,0xe8,0x00,0x00,0x00,0xc5,0xfa,0x6f,0x84,0x24,0x28,0x01,0x00,0x00,0xc5,0xfa,0x7f,0x84,0x24,0xf8,0x00,0x00,0x00,0x48,0xb9,0x10,0x8f,0x12,0x65,0xfb,0x7f,0x00,0x00,0xe8,0xfd,0xf4,0xab,0x5b,0x49,0xb8,0x48,0x23,0x33,0x65,0xfb,0x7f,0x00,0x00,0xba,0x01,0x00,0x00,0x00,0xf0,0x41,0x0f,0xc1,0x10,0xff,0xc2,0x89,0x50,0x08,0x4c,0x8b,0x84,0x24,0xe8,0x00,0x00,0x00,0x33,0xd2,0x48,0xb9,0x90,0x13,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x09,0x49,0xb9,0x10,0x5e,0x3d,0x61,0xa1,0x02,0x00,0x00,0x4d,0x8b,0x09,0x4c,0x8d,0x54,0x24,0x68,0x4d,0x89,0x02,0x49,0x89,0x42,0x08,0x49,0x89,0x52,0x10,0x49,0x89,0x4a,0x18,0x4c,0x8d,0x44,0x24,0x68,0x49,0x8b,0xd1,0x33,0xc9,0xe8,0xfd,0xde,0x9d,0x57,0x48,0x8b,0xf0,0xc5,0xfa,0x6f,0x84,0x24,0x18,0x01,0x00,0x00,0xc5,0xfa,0x7f,0x44,0x24,0x48,0xc5,0xfa,0x6f,0x84,0x24,0x28,0x01,0x00,0x00,0xc5,0xfa,0x7f,0x44,0x24,0x58,0x48,0x8b,0x4c,0x24,0x40,0x48,0x8d,0x54,0x24,0x48,0xe8,0x2d,0xe4,0xff,0xff,0x48,0x8b,0xf8,0x48,0xb9,0xa8,0x7f,0x52,0x69,0xfb,0x7f,0x00,0x00,0xe8,0x5b,0xf4,0xab,0x5b,0x0f,0xb7,0x8c,0x24,0x32,0x01,0x00,0x00,0x89,0x4c,0x24,0x20,0x48,0x89,0x7c,0x24,0x28,0x48,0x89,0x44,0x24,0x38,0x48,0x8b,0xc8,0x48,0x8b,0xd6,0x4c,0x8b,0x44,0x24,0x40,0x44,0x0f,0xb7,0x8c,0x24,0x30,0x01,0x00,0x00,0xe8,0x94,0xe7,0xff,0xff,0x48,0x8b,0x4c,0x24,0x38,0xe8,0xca,0xed,0xff,0xff,0x48,0x8b,0xf0,0x8b,0x0e,0x8b,0x4e,0x34,0x81,0xe1,0x00,0x00,0x00,0x11,0x81,0xf9,0x00,0x00,0x00,0x01,0x75,0x16,0x48,0x83,0xc6,0x38,0x48,0x8d,0xbc,0x24,0xa0,0x00,0x00,0x00,0xb9,0x09,0x00,0x00,0x00,0xf3,0x48,0xa5,0xeb,0x16,0x48,0x8d,0x94,0x24,0xa0,0x00,0x00,0x00,0x48,0x8b,0xce,0x41,0xb8,0x01,0x00,0x00,0x00,0xe8,0xc0,0xd3,0x45,0xfe,0x48,0x8d,0xbc,0x24,0x80,0x01,0x00,0x00,0x48,0x8d,0xb4,0x24,0xa0,0x00,0x00,0x00,0xb9,0x09,0x00,0x00,0x00,0xf3,0x48,0xa5,0x4d,0x8b,0x44,0x24,0x10,0x48,0x8d,0xb4,0x24,0x80,0x01,0x00,0x00,0x4d,0x85,0xc0,0x75,0x3c,0x48,0xb9,0x28,0xa7,0x52,0x69,0xfb,0x7f,0x00,0x00,0xe8,0xa7,0xf3,0xab,0x5b,0x48,0x8b,0xf8,0x48,0x8d,0x4f,0x08,0x49,0x8b,0xd4,0xe8,0xd8,0xe4,0xab,0x5b,0x48,0xba,0x38,0x79,0x1d,0x69,0xfb,0x7f,0x00,0x00,0x48,0x89,0x57,0x18,0x49,0x8d,0x4c,0x24,0x10,0x48,0x8b,0xd7,0xe8,0xbd,0xe4,0xab,0x5b,0x4c,0x8b,0xc7,0x48,0x8d,0x94,0x24,0x38,0x01,0x00,0x00,0x48,0x8b,0xce,0xe8,0x72,0xd1,0x45,0xfe,0x41,0xff,0xc5,0x45,0x3b,0xef,0x0f,0x8c,0x08,0xfd,0xff,0xff,0x49,0x8b,0x44,0x24,0x08,0x48,0x81,0xc4,0xc8,0x01,0x00,0x00,0x5b,0x5d,0x5e,0x5f,0x41,0x5c,0x41,0x5d,0x41,0x5e,0x41,0x5f,0xc3,0xe8,0xa0,0x77,0xbe,0x5b};

        public static ReadOnlySpan<byte> transitionヽgᐸ16uᐳᐤIFsmContextㆍPrimalFsmSpecᐸushortᐳᐤ  =>  new byte[594]{0x41,0x57,0x41,0x56,0x41,0x55,0x41,0x54,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x48,0x48,0x8b,0xf9,0x48,0x8b,0xf2,0x0f,0xb7,0x56,0x10,0x33,0xc9,0x45,0x33,0xc0,0x48,0x8d,0x44,0x24,0x40,0x88,0x08,0x66,0x44,0x89,0x40,0x02,0x33,0xc9,0x44,0x8b,0x44,0x24,0x40,0xe8,0x01,0x41,0xfa,0xff,0x48,0x8b,0xc8,0xe8,0xb9,0x13,0x21,0xff,0x48,0x8b,0xd8,0x48,0x8b,0xcf,0x49,0xbb,0x00,0x19,0x03,0x65,0xfb,0x7f,0x00,0x00,0x48,0xb8,0x00,0x19,0x03,0x65,0xfb,0x7f,0x00,0x00,0x39,0x09,0xff,0x10,0x48,0x8b,0xf8,0x48,0xb9,0xb0,0xb2,0x52,0x69,0xfb,0x7f,0x00,0x00,0xe8,0x81,0xe6,0xab,0x5b,0x48,0x8b,0xe8,0x48,0xb9,0x20,0x00,0x12,0x65,0xfb,0x7f,0x00,0x00,0xba,0xb9,0x00,0x00,0x00,0xe8,0xfa,0xa5,0xa8,0x5b,0x48,0xba,0xf0,0xfd,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x8d,0x4d,0x08,0xe8,0x94,0xd7,0xab,0x5b,0x45,0x33,0xf6,0x44,0x8b,0x7b,0x08,0x45,0x85,0xff,0x0f,0x8e,0x3d,0x01,0x00,0x00,0x48,0xb9,0x60,0xbb,0x52,0x69,0xfb,0x7f,0x00,0x00,0xe8,0x35,0xe6,0xab,0x5b,0x4c,0x8b,0xe0,0x49,0x63,0xce,0x0f,0xb7,0x4c,0x4b,0x10,0x66,0x41,0x89,0x4c,0x24,0x08,0x48,0x8b,0xcf,0x48,0xba,0x28,0x9a,0x38,0x66,0xfb,0x7f,0x00,0x00,0x49,0xb8,0xb8,0xcf,0x52,0x69,0xfb,0x7f,0x00,0x00,0xe8,0x28,0xce,0x99,0x5b,0x44,0x0f,0xb7,0x46,0x16,0x0f,0xb7,0x56,0x14,0x48,0x8b,0xcf,0xff,0xd0,0x44,0x8b,0xe8,0x48,0xb9,0xe0,0x23,0x62,0x68,0xfb,0x7f,0x00,0x00,0xe8,0xe8,0xe5,0xab,0x5b,0x48,0x89,0x44,0x24,0x30,0x0f,0xb7,0x56,0x10,0x48,0x8b,0xcf,0x45,0x8b,0xc5,0xe8,0x04,0xf8,0xff,0xff,0x48,0x89,0x44,0x24,0x28,0x4c,0x8b,0x44,0x24,0x30,0x49,0x8d,0x48,0x08,0x49,0x8b,0xd4,0xe8,0xfe,0xd6,0xab,0x5b,0x48,0xb9,0xe0,0x85,0x1d,0x69,0xfb,0x7f,0x00,0x00,0x48,0x8b,0x54,0x24,0x30,0x48,0x89,0x4a,0x18,0x48,0x8b,0x4c,0x24,0x28,0xe8,0x19,0xf8,0xff,0xff,0x48,0x89,0x44,0x24,0x38,0x0f,0xb7,0x56,0x12,0x48,0x8b,0xcf,0x45,0x8b,0xc5,0xe8,0xbd,0xf7,0xff,0xff,0x4c,0x8b,0xe8,0x4d,0x85,0xed,0x0f,0x84,0xb6,0x00,0x00,0x00,0x48,0x83,0x7c,0x24,0x38,0x00,0x0f,0x84,0xb5,0x00,0x00,0x00,0x48,0xb9,0xc0,0xd4,0x52,0x69,0xfb,0x7f,0x00,0x00,0xe8,0x66,0xe5,0xab,0x5b,0x48,0x89,0x44,0x24,0x20,0x49,0x8b,0xcd,0x48,0x8b,0x54,0x24,0x38,0xe8,0x24,0xfa,0xff,0xff,0x4c,0x8b,0xe8,0x48,0x8b,0x44,0x24,0x20,0x48,0x8d,0x48,0x08,0x49,0x8b,0xd4,0xe8,0x80,0xd6,0xab,0x5b,0x48,0xb9,0xe8,0x85,0x1d,0x69,0xfb,0x7f,0x00,0x00,0x4c,0x8b,0x64,0x24,0x20,0x49,0x89,0x4c,0x24,0x18,0x49,0x8b,0xcd,0x49,0x8b,0xd4,0xe8,0x31,0xf9,0xff,0xff,0x4c,0x8b,0xc0,0x8b,0x55,0x10,0x48,0x8b,0xcd,0xe8,0xe3,0xe8,0xff,0xff,0x41,0xff,0xc6,0x45,0x3b,0xfe,0x0f,0x8f,0xc3,0xfe,0xff,0xff,0x48,0x8b,0xcd,0xe8,0xff,0xfa,0xff,0xff,0x48,0x8b,0xf0,0x48,0xb9,0x80,0x83,0x52,0x69,0xfb,0x7f,0x00,0x00,0xe8,0xed,0xe4,0xab,0x5b,0x48,0x8b,0xf8,0x48,0x8b,0xcf,0x48,0x8b,0xd6,0xe8,0xc7,0xd4,0xff,0xff,0x48,0x8b,0xc7,0x48,0x83,0xc4,0x48,0x5b,0x5d,0x5e,0x5f,0x41,0x5c,0x41,0x5d,0x41,0x5e,0x41,0x5f,0xc3,0xb9,0x04,0x00,0x00,0x00,0xe8,0x49,0x7b,0xf7,0xfc,0xcc,0xb9,0x0e,0x00,0x00,0x00,0xe8,0x3e,0x7b,0xf7,0xfc,0xcc,0x00,0x19,0x10,0x09,0x00,0x10,0x82,0x0c,0x30,0x0b,0x50,0x0a,0x60,0x09,0x70,0x08,0xc0,0x06,0xd0,0x04,0xe0,0x02,0xf0};

        public static ReadOnlySpan<byte> transitionヽgᐸ16uᐳᐤIPolySourceㆍPrimalFsmSpecᐸushortᐳᐤ  =>  new byte[562]{0x41,0x57,0x41,0x56,0x41,0x55,0x41,0x54,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x48,0x48,0x8b,0xf9,0x48,0x8b,0xf2,0x0f,0xb7,0x56,0x10,0x33,0xc9,0x45,0x33,0xc0,0x48,0x8d,0x44,0x24,0x40,0x88,0x08,0x66,0x44,0x89,0x40,0x02,0x33,0xc9,0x44,0x8b,0x44,0x24,0x40,0xe8,0x41,0x38,0xfa,0xff,0x48,0x8b,0xc8,0xe8,0xf9,0x0a,0x21,0xff,0x48,0x8b,0xd8,0x48,0xb9,0xb0,0xb2,0x52,0x69,0xfb,0x7f,0x00,0x00,0xe8,0xdf,0xdd,0xab,0x5b,0x48,0x8b,0xe8,0x48,0xb9,0x20,0x00,0x12,0x65,0xfb,0x7f,0x00,0x00,0xba,0xb9,0x00,0x00,0x00,0xe8,0x58,0x9d,0xa8,0x5b,0x48,0xba,0xf0,0xfd,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x8d,0x4d,0x08,0xe8,0xf2,0xce,0xab,0x5b,0x45,0x33,0xf6,0x44,0x8b,0x7b,0x08,0x45,0x85,0xff,0x0f,0x8e,0x3d,0x01,0x00,0x00,0x48,0xb9,0x78,0xed,0x52,0x69,0xfb,0x7f,0x00,0x00,0xe8,0x93,0xdd,0xab,0x5b,0x4c,0x8b,0xe0,0x49,0x63,0xce,0x0f,0xb7,0x4c,0x4b,0x10,0x66,0x41,0x89,0x4c,0x24,0x08,0x48,0x8b,0xcf,0x48,0xba,0x28,0x9a,0x38,0x66,0xfb,0x7f,0x00,0x00,0x49,0xb8,0xb8,0xcf,0x52,0x69,0xfb,0x7f,0x00,0x00,0xe8,0x86,0xc5,0x99,0x5b,0x44,0x0f,0xb7,0x46,0x16,0x0f,0xb7,0x56,0x14,0x48,0x8b,0xcf,0xff,0xd0,0x44,0x8b,0xe8,0x48,0xb9,0xe0,0x23,0x62,0x68,0xfb,0x7f,0x00,0x00,0xe8,0x46,0xdd,0xab,0x5b,0x48,0x89,0x44,0x24,0x30,0x0f,0xb7,0x56,0x10,0x48,0x8b,0xcf,0x45,0x8b,0xc5,0xe8,0x62,0xef,0xff,0xff,0x48,0x89,0x44,0x24,0x28,0x4c,0x8b,0x44,0x24,0x30,0x49,0x8d,0x48,0x08,0x49,0x8b,0xd4,0xe8,0x5c,0xce,0xab,0x5b,0x48,0xb9,0x88,0x8e,0x1d,0x69,0xfb,0x7f,0x00,0x00,0x48,0x8b,0x54,0x24,0x30,0x48,0x89,0x4a,0x18,0x48,0x8b,0x4c,0x24,0x28,0xe8,0x77,0xef,0xff,0xff,0x48,0x89,0x44,0x24,0x38,0x0f,0xb7,0x56,0x12,0x48,0x8b,0xcf,0x45,0x8b,0xc5,0xe8,0x1b,0xef,0xff,0xff,0x4c,0x8b,0xe8,0x4d,0x85,0xed,0x0f,0x84,0xb6,0x00,0x00,0x00,0x48,0x83,0x7c,0x24,0x38,0x00,0x0f,0x84,0xb5,0x00,0x00,0x00,0x48,0xb9,0xc0,0xd4,0x52,0x69,0xfb,0x7f,0x00,0x00,0xe8,0xc4,0xdc,0xab,0x5b,0x48,0x89,0x44,0x24,0x20,0x49,0x8b,0xcd,0x48,0x8b,0x54,0x24,0x38,0xe8,0x82,0xf1,0xff,0xff,0x4c,0x8b,0xe8,0x48,0x8b,0x44,0x24,0x20,0x48,0x8d,0x48,0x08,0x49,0x8b,0xd4,0xe8,0xde,0xcd,0xab,0x5b,0x48,0xb9,0x90,0x8e,0x1d,0x69,0xfb,0x7f,0x00,0x00,0x4c,0x8b,0x64,0x24,0x20,0x49,0x89,0x4c,0x24,0x18,0x49,0x8b,0xcd,0x49,0x8b,0xd4,0xe8,0x8f,0xf0,0xff,0xff,0x4c,0x8b,0xc0,0x8b,0x55,0x10,0x48,0x8b,0xcd,0xe8,0x41,0xe0,0xff,0xff,0x41,0xff,0xc6,0x45,0x3b,0xfe,0x0f,0x8f,0xc3,0xfe,0xff,0xff,0x48,0x8b,0xcd,0xe8,0x5d,0xf2,0xff,0xff,0x48,0x8b,0xf0,0x48,0xb9,0x80,0x83,0x52,0x69,0xfb,0x7f,0x00,0x00,0xe8,0x4b,0xdc,0xab,0x5b,0x48,0x8b,0xf8,0x48,0x8b,0xcf,0x48,0x8b,0xd6,0xe8,0x25,0xcc,0xff,0xff,0x48,0x8b,0xc7,0x48,0x83,0xc4,0x48,0x5b,0x5d,0x5e,0x5f,0x41,0x5c,0x41,0x5d,0x41,0x5e,0x41,0x5f,0xc3,0xb9,0x04,0x00,0x00,0x00,0xe8,0xa7,0x72,0xf7,0xfc,0xcc,0xb9,0x0e,0x00,0x00,0x00,0xe8,0x9c,0x72,0xf7,0xfc,0xcc,0x00,0x00,0x00,0x19,0x10,0x09,0x00,0x10,0x82,0x0c,0x30,0x0b,0x50,0x0a,0x60,0x09,0x70,0x08,0xc0,0x06,0xd0};

    }
}
