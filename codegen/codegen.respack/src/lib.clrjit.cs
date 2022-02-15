﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2022-01-14 21:56:33 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class lib_clrjit
    {
        public static ReadOnlySpan<byte> fptrヽᐤMethodInfoᐤ  =>  new byte[41]{0x48,0x83,0xec,0x28,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x8b,0x01,0x48,0x8b,0x40,0x60,0xff,0x10,0x48,0x89,0x44,0x24,0x20,0x48,0x8d,0x4c,0x24,0x20,0xe8,0xd5,0x79,0x52,0xfc,0x90,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> jitヽᐤMethodInfoᐤ  =>  new byte[81]{0x56,0x48,0x83,0xec,0x30,0x33,0xc0,0x48,0x89,0x44,0x24,0x28,0x48,0x8b,0xf1,0x48,0x8b,0xce,0x48,0x8b,0x06,0x48,0x8b,0x40,0x60,0xff,0x10,0x48,0x8b,0xc8,0x33,0xd2,0x45,0x33,0xc0,0xe8,0xa8,0x56,0x1c,0x5c,0x33,0xc9,0x48,0x89,0x4c,0x24,0x28,0x48,0x8b,0xce,0x48,0x8b,0x06,0x48,0x8b,0x40,0x60,0xff,0x10,0x48,0x89,0x44,0x24,0x28,0x48,0x8d,0x4c,0x24,0x28,0xe8,0x6e,0x79,0x52,0xfc,0x90,0x48,0x83,0xc4,0x30,0x5e,0xc3};

        public static ReadOnlySpan<byte> jitヽᐤrspanMethodInfoㆍspanMemoryAddressᐤ  =>  new byte[209]{0x55,0x41,0x57,0x41,0x56,0x41,0x55,0x41,0x54,0x57,0x56,0x53,0x48,0x81,0xec,0x98,0x00,0x00,0x00,0xc5,0xf8,0x77,0x48,0x8d,0xac,0x24,0xd0,0x00,0x00,0x00,0x33,0xf6,0x48,0x89,0x75,0xb8,0x48,0x89,0x75,0xc0,0x48,0x89,0x75,0xa8,0x48,0x89,0x75,0xb0,0x48,0x8b,0xf1,0x48,0x8b,0xfa,0x48,0x8d,0x8d,0x58,0xff,0xff,0xff,0x49,0x8b,0xd2,0xe8,0x5b,0xe4,0xf1,0x5b,0x48,0x8b,0xd8,0x48,0x8b,0xcc,0x48,0x89,0x8d,0x78,0xff,0xff,0xff,0x48,0x8b,0xcd,0x48,0x89,0x4d,0x88,0x44,0x8b,0x76,0x08,0x45,0x33,0xff,0x45,0x85,0xf6,0x0f,0x8e,0x19,0x01,0x00,0x00,0x48,0x89,0x7d,0x18,0x48,0x8b,0x0f,0x49,0x63,0xc7,0x4c,0x8d,0x24,0xc1,0x4c,0x89,0x65,0xa0,0x48,0x8b,0x0e,0x48,0x89,0x4d,0xb8,0x48,0x89,0x75,0x10,0x8b,0x4e,0x08,0x89,0x4d,0xc0,0xc5,0xfa,0x6f,0x4d,0xb8,0xc5,0xfa,0x7f,0x4d,0xa8,0x48,0x8b,0x4d,0xa8,0x49,0x63,0xc7,0x4c,0x8b,0x2c,0xc1,0x49,0x8b,0xcd,0x49,0x8b,0x45,0x00,0x48,0x8b,0x40,0x60,0xff,0x10,0x48,0x8b,0xc8,0x33,0xd2,0x45,0x33,0xc0,0xe8,0xa5,0x55,0x1c,0x5c,0x49,0x8b,0xcd,0x49,0x8b,0x45,0x00,0x48,0x8b,0x40,0x60,0xff,0x10,0x4c,0x8b,0xe8,0x4d,0x85,0xed,0x0f,0x84,0xc3};

        public static ReadOnlySpan<byte> jitヽᐤIndexᐸMethodInfoᐳᐤ  =>  new byte[563]{0x55,0x41,0x57,0x41,0x56,0x41,0x55,0x41,0x54,0x57,0x56,0x53,0x48,0x81,0xec,0xb8,0x00,0x00,0x00,0xc5,0xf8,0x77,0x48,0x8d,0xac,0x24,0xf0,0x00,0x00,0x00,0x33,0xd2,0x48,0x89,0x55,0xb8,0x48,0x89,0x55,0xc0,0x48,0x89,0x55,0xa8,0x48,0x89,0x55,0xb0,0x48,0x8b,0xf1,0x48,0x8d,0x8d,0x38,0xff,0xff,0xff,0x49,0x8b,0xd2,0xe8,0x3e,0xe2,0xf1,0x5b,0x48,0x8b,0xf8,0x48,0x8b,0xcc,0x48,0x89,0x8d,0x58,0xff,0xff,0xff,0x48,0x8b,0xcd,0x48,0x89,0x8d,0x68,0xff,0xff,0xff,0x48,0x85,0xf6,0x75,0x07,0x33,0xdb,0x45,0x33,0xf6,0xeb,0x08,0x48,0x8d,0x5e,0x10,0x44,0x8b,0x76,0x08,0x41,0x8b,0xf6,0x48,0x63,0xce,0xe8,0x88,0xf3,0xff,0xff,0x4c,0x8b,0xf8,0x45,0x39,0x3f,0x4c,0x89,0x7d,0xa0,0x4d,0x8d,0x67,0x10,0x45,0x33,0xed,0x45,0x85,0xf6,0x0f,0x8e,0x31,0x01,0x00,0x00,0x48,0x89,0x5d,0x88,0x48,0x89,0x5d,0xb8,0x89,0x75,0xc0,0xc5,0xfa,0x6f,0x4d,0xb8,0xc5,0xfa,0x7f,0x4d,0xa8,0x48,0x8b,0x4d,0xa8,0x49,0x63,0xc5,0x48,0x8b,0x04,0xc1,0x49,0x63,0xd5,0x48,0xc1,0xe2,0x04,0x4c,0x89,0x65,0x98,0x49,0x03,0xd4,0x48,0x89,0x55,0x90,0x48,0x8b,0xc8,0x48,0x89,0x45,0x80,0x4c,0x8b,0x00,0x4d,0x8b,0x40,0x60,0x41,0xff,0x10,0x48,0x8b,0xc8,0x33,0xd2,0x45,0x33,0xc0,0xe8,0x5e,0x53,0x1c,0x5c,0x48,0x8b,0x4d,0x80,0x48,0x89,0x4d,0x80,0x48,0x8b,0x01,0x48,0x8b,0x40,0x60,0xff,0x10,0x48,0x85,0xc0,0x0f,0x84,0xe3,0x00,0x00,0x00,0x48,0x89,0x85,0x78,0xff,0xff,0xff,0x48,0x8b,0xc8,0x49,0xbb,0xe8,0x11,0x98,0x61,0xfb,0x7f,0x00,0x00,0x48,0xba,0xe8,0x11,0x98,0x61,0xfb,0x7f,0x00,0x00,0x39,0x09,0xff,0x12,0x48,0x8b,0xc8,0x45,0x33,0xdb,0x48,0xb8,0x78,0x8c,0xd9,0x61,0xfb,0x7f,0x00,0x00,0x48,0x89,0x85,0x48,0xff,0xff,0xff,0x48,0x8d,0x05,0x22,0x00,0x00,0x00,0x48,0x89,0x85,0x60,0xff,0xff,0xff,0x48,0x8d,0x85,0x38,0xff,0xff,0xff,0x48,0x89,0x47,0x10,0xc6,0x47,0x0c,0x00,0x48,0xb8,0xb0,0x91,0xd9,0x61,0xfb,0x7f,0x00,0x00,0xff,0x10,0xc6,0x47,0x0c,0x01,0x48,0xba,0xa8,0x7b,0x99,0xc1,0xfb,0x7f,0x00,0x00,0x83,0x3a,0x00,0x74,0x0c,0x48,0xb9,0x78,0xb2,0x98,0xc1,0xfb,0x7f,0x00,0x00,0xff,0x11,0x48,0x8b,0x8d,0x40,0xff,0xff,0xff,0x48,0x89,0x4f,0x10,0x48,0x8b,0xd8,0x48,0x8b,0x8d,0x78,0xff,0xff,0xff,0xe8,0xc9,0x44,0x95,0x5b,0x4c,0x8b,0x7d,0x80,0x49,0x8b,0xd7,0x48,0x8b,0x4d,0x90,0xe8,0x89,0x83,0x01,0x5c,0x4c,0x8b,0x7d,0x90,0x49,0x89,0x5f,0x08,0x41,0xff,0xc5,0x45,0x3b,0xee,0x48,0x8b,0x5d,0x88,0x4c,0x8b,0x65,0x98,0x0f,0x8c,0xcf,0xfe,0xff,0xff,0x4c,0x8b,0x7d,0xa0,0x49,0x8b,0xc7,0xc6,0x47,0x0c,0x01,0x48,0x8d,0x65,0xc8,0x5b,0x5e,0x5f,0x41,0x5c,0x41,0x5d,0x41,0x5e,0x41,0x5f,0x5d,0xc3,0x48,0xb9,0x70,0x7a,0xb3,0x61,0xfb,0x7f,0x00,0x00,0xe8,0x32,0x92,0x01,0x5c,0x48,0x8b,0xf0,0xe8,0x72,0x9f,0x2a,0xfe,0xc7,0x46,0x70,0x52,0x43,0x43,0xe0,0xc7,0x46,0x74,0x00,0x15,0x13,0x80,0x48,0x8d,0x4e,0x10,0x48,0x8b,0xd0,0xe8,0x50,0x83,0x01,0x5c,0xc7,0x46,0x74,0x01,0x15,0x13,0x80,0x33,0xc9,0x48,0x89,0x4e,0x78,0xc7,0x46,0x74,0x57,0x00,0x07,0x80,0xc7,0x46,0x74,0x03,0x40,0x00,0x80,0x48,0x8b,0xce,0xe8,0x3d,0xce,0xfd,0x5b};

        public static ReadOnlySpan<byte> jitヽᐤDelegateᐤ  =>  new byte[77]{0x56,0x48,0x83,0xec,0x30,0x33,0xc0,0x48,0x89,0x44,0x24,0x28,0x48,0x8b,0xf1,0x48,0x8b,0xce,0xe8,0x81,0xfd,0x52,0xfc,0x48,0x8b,0xce,0x48,0x8b,0x06,0x48,0x8b,0x40,0x40,0xff,0x50,0x28,0x33,0xc9,0x48,0x89,0x4c,0x24,0x28,0x48,0x8b,0xc8,0x48,0x8b,0x00,0x48,0x8b,0x40,0x60,0xff,0x10,0x48,0x89,0x44,0x24,0x28,0x48,0x8d,0x4c,0x24,0x28,0xe8,0x82,0x74,0x52,0xfc,0x90,0x48,0x83,0xc4,0x30,0x5e,0xc3};

        public static ReadOnlySpan<byte> jitヽᐤDynamicDelegateᐤ  =>  new byte[218]{0x57,0x56,0x53,0x48,0x81,0xec,0x90,0x00,0x00,0x00,0xc5,0xf8,0x77,0x48,0x8b,0xf1,0x48,0x8d,0x7c,0x24,0x28,0xb9,0x1a,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x48,0x8b,0xd9,0x48,0x8b,0xf2,0x48,0x8b,0x4e,0x18,0xe8,0xf8,0xfc,0x52,0xfc,0x48,0x8b,0x0e,0x48,0x8b,0x46,0x08,0x48,0x8b,0x56,0x10,0x4c,0x8b,0x46,0x18,0x4c,0x8d,0x4c,0x24,0x70,0x49,0x89,0x09,0x49,0x89,0x41,0x08,0x49,0x89,0x51,0x10,0x4d,0x89,0x41,0x18,0xc5,0xfa,0x6f,0x44,0x24,0x70,0xc5,0xfa,0x7f,0x44,0x24,0x50,0xc5,0xfa,0x6f,0x84,0x24,0x80,0x00,0x00,0x00,0xc5,0xfa,0x7f,0x44,0x24,0x60,0x48,0x8b,0xca,0xe8,0x52,0x22,0xae,0xfd,0x33,0xd2,0x48,0x8d,0x4c,0x24,0x28,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x01,0xc5,0xfa,0x7f,0x41,0x10,0x48,0x89,0x51,0x20,0xc5,0xfa,0x6f,0x44,0x24,0x50,0xc5,0xfa,0x7f,0x44,0x24,0x28,0xc5,0xfa,0x6f,0x44,0x24,0x60,0xc5,0xfa,0x7f,0x44,0x24,0x38,0x48,0x8d,0x54,0x24,0x48,0x48,0x89,0x02,0x48,0x8b,0xfb,0x48,0x8d,0x74,0x24,0x28,0xe8,0x75,0x82,0x01,0x5c,0xe8,0x70,0x82,0x01,0x5c,0xe8,0x6b,0x82,0x01,0x5c,0xe8,0x66,0x82,0x01,0x5c,0x48,0xa5,0x48,0x8b,0xc3,0x48,0x81,0xc4,0x90,0x00,0x00,0x00,0x5b,0x5e,0x5f,0xc3};

    }
}