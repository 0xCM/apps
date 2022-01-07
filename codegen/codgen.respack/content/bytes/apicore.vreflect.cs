﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2022-01-07 15:36:32 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class apicore_vreflect
    {
        public static ReadOnlySpan<byte> IsVectorヽᐤTypeᐤ  =>  new byte[214]{0x57,0x56,0x48,0x83,0xec,0x28,0x48,0x8b,0xf1,0x48,0x8b,0xce,0x48,0x8b,0x06,0x48,0x8b,0x40,0x58,0xff,0x50,0x20,0x48,0x8b,0xc8,0x48,0x8b,0x00,0x48,0x8b,0x40,0x58,0xff,0x50,0x38,0x85,0xc0,0x75,0x02,0xeb,0x10,0x48,0x8b,0xce,0x48,0x8b,0x06,0x48,0x8b,0x40,0x68,0xff,0x50,0x18,0x48,0x8b,0xf0,0x48,0x8b,0xce,0x48,0x8b,0x06,0x48,0x8b,0x40,0x60,0xff,0x50,0x28,0x85,0xc0,0x75,0x1a,0x48,0x8b,0xce,0x48,0x8b,0x06,0x48,0x8b,0x40,0x60,0xff,0x50,0x30,0x85,0xc0,0x75,0x04,0x33,0xff,0xeb,0x15,0x48,0x8b,0xfe,0xeb,0x10,0x48,0x8b,0xce,0x48,0x8b,0x06,0x48,0x8b,0x40,0x68,0xff,0x50,0x28,0x48,0x8b,0xf8,0x48,0x85,0xff,0x75,0x09,0x33,0xc0,0x48,0x83,0xc4,0x28,0x5e,0x5f,0xc3,0x48,0xb9,0xa8,0xbe,0xe0,0x76,0xfd,0x7f,0x00,0x00,0xe8,0x6f,0x49,0xe7,0x5b,0x48,0x3b,0xc7,0x74,0x34,0x48,0xb9,0x58,0xc3,0xe0,0x76,0xfd,0x7f,0x00,0x00,0xe8,0x5b,0x49,0xe7,0x5b,0x48,0x3b,0xc7,0x74,0x20,0x48,0x8b,0xd7,0x48,0xb9,0x40,0x87,0x8c,0x79,0xfd,0x7f,0x00,0x00,0x48,0xb8,0xe0,0x49,0xd3,0x78,0xfd,0x7f,0x00,0x00,0x48,0x83,0xc4,0x28,0x5e,0x5f,0x48,0xff,0xe0,0xb8,0x01,0x00,0x00,0x00,0x48,0x83,0xc4,0x28,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> AcceptsVectorヽᐤMethodInfoᐤ  =>  new byte[250]{0x57,0x56,0x48,0x83,0xec,0x38,0x33,0xc0,0x48,0x89,0x44,0x24,0x28,0x48,0x8b,0xf1,0x48,0xb9,0x48,0xcb,0xec,0x76,0xfd,0x7f,0x00,0x00,0xba,0xab,0x00,0x00,0x00,0xe8,0x6c,0x0f,0xee,0x5b,0x48,0xb9,0x28,0x61,0x4d,0x73,0xd5,0x01,0x00,0x00,0x48,0x8b,0x39,0x48,0x85,0xff,0x75,0x51,0x48,0xb9,0xd8,0x76,0x17,0x79,0xfd,0x7f,0x00,0x00,0xe8,0x4b,0x0b,0xee,0x5b,0x48,0x8b,0xf8,0x48,0xba,0x20,0x61,0x4d,0x73,0xd5,0x01,0x00,0x00,0x48,0x8b,0x12,0x48,0x85,0xd2,0x0f,0x84,0x8d,0x00,0x00,0x00,0x48,0x8d,0x4f,0x08,0xe8,0x69,0xfc,0xed,0x5b,0x48,0xba,0x38,0xcd,0x52,0x78,0xfd,0x7f,0x00,0x00,0x48,0x89,0x57,0x18,0x48,0xb9,0x28,0x61,0x4d,0x73,0xd5,0x01,0x00,0x00,0x48,0x8b,0xd7,0xe8,0x19,0xfc,0xed,0x5b,0x48,0x8b,0xce,0x48,0x8b,0x06,0x48,0x8b,0x40,0x50,0xff,0x50,0x20,0x48,0x85,0xc0,0x75,0x07,0x33,0xd2,0x45,0x33,0xc0,0xeb,0x08,0x48,0x8d,0x50,0x10,0x44,0x8b,0x40,0x08,0x48,0x8d,0x4c,0x24,0x28,0x48,0x89,0x11,0x44,0x89,0x41,0x08,0x48,0x8d,0x54,0x24,0x28,0x4c,0x8b,0xc7,0x48,0xb9,0x90,0xf2,0x0f,0x7a,0xfd,0x7f,0x00,0x00,0xe8,0xf5,0xb6,0x3d,0xfc,0x48,0x8b,0xd0,0x48,0xb9,0xc8,0xf0,0x0f,0x7a,0xfd,0x7f,0x00,0x00,0x48,0xb8,0xf0,0x99,0x8f,0xe9,0xfd,0x7f,0x00,0x00,0x48,0x83,0xc4,0x38,0x5e,0x5f,0x48,0xff,0xe0,0x48,0x8b,0xcf,0xe8,0x0d,0xce,0x3a,0xfc,0xcc,0x19,0x06,0x03,0x00,0x06,0x62};

        public static ReadOnlySpan<byte> AcceptsVectorヽᐤMethodInfoㆍ32iᐤ  =>  new byte[198]{0x57,0x56,0x53,0x48,0x83,0xec,0x30,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x48,0x8b,0xf1,0x8b,0xfa,0x48,0xb9,0x38,0xea,0x77,0x78,0xfd,0x7f,0x00,0x00,0xe8,0x59,0x0a,0xee,0x5b,0x48,0x8b,0xd8,0x89,0x7b,0x08,0x48,0xb9,0xd8,0x76,0x17,0x79,0xfd,0x7f,0x00,0x00,0xe8,0x44,0x0a,0xee,0x5b,0x48,0x8b,0xf8,0x48,0x8d,0x4f,0x08,0x48,0x8b,0xd3,0xe8,0x75,0xfb,0xed,0x5b,0x48,0xb9,0x00,0xce,0x52,0x78,0xfd,0x7f,0x00,0x00,0x48,0x89,0x4f,0x18,0x48,0x8b,0xce,0x48,0x8b,0x06,0x48,0x8b,0x40,0x50,0xff,0x50,0x20,0x48,0x85,0xc0,0x75,0x07,0x33,0xd2,0x45,0x33,0xc0,0xeb,0x08,0x48,0x8d,0x50,0x10,0x44,0x8b,0x40,0x08,0x48,0x8d,0x4c,0x24,0x20,0x48,0x89,0x11,0x44,0x89,0x41,0x08,0x48,0x8d,0x54,0x24,0x20,0x4c,0x8b,0xc7,0x48,0xb9,0x90,0xf2,0x0f,0x7a,0xfd,0x7f,0x00,0x00,0xe8,0x13,0xb6,0x3d,0xfc,0x48,0x8b,0xd0,0x48,0xb9,0xc8,0xf0,0x0f,0x7a,0xfd,0x7f,0x00,0x00,0x48,0xb8,0xf0,0x99,0x8f,0xe9,0xfd,0x7f,0x00,0x00,0x48,0x83,0xc4,0x30,0x5b,0x5e,0x5f,0x48,0xff,0xe0,0x00,0x00,0x19,0x07,0x04,0x00,0x07,0x52};

        public static ReadOnlySpan<byte> AcceptsVectorヽᐤMethodInfoㆍ32iㆍW512ᐤ  =>  new byte[210]{0x57,0x56,0x53,0x48,0x83,0xec,0x30,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x4c,0x89,0x44,0x24,0x60,0x48,0x8b,0xf1,0x8b,0xfa,0x48,0xb9,0x08,0xeb,0x77,0x78,0xfd,0x7f,0x00,0x00,0xe8,0x74,0x09,0xee,0x5b,0x48,0x8b,0xd8,0x89,0x7b,0x08,0x48,0x0f,0xbe,0x4c,0x24,0x60,0x88,0x4b,0x10,0x48,0xb9,0xd8,0x76,0x17,0x79,0xfd,0x7f,0x00,0x00,0xe8,0x56,0x09,0xee,0x5b,0x48,0x8b,0xf8,0x48,0x8d,0x4f,0x08,0x48,0x8b,0xd3,0xe8,0x87,0xfa,0xed,0x5b,0x48,0xb9,0x18,0xce,0x52,0x78,0xfd,0x7f,0x00,0x00,0x48,0x89,0x4f,0x18,0x48,0x8b,0xce,0x48,0x8b,0x06,0x48,0x8b,0x40,0x50,0xff,0x50,0x20,0x48,0x85,0xc0,0x75,0x07,0x33,0xd2,0x45,0x33,0xc0,0xeb,0x08,0x48,0x8d,0x50,0x10,0x44,0x8b,0x40,0x08,0x48,0x8d,0x4c,0x24,0x20,0x48,0x89,0x11,0x44,0x89,0x41,0x08,0x48,0x8d,0x54,0x24,0x20,0x4c,0x8b,0xc7,0x48,0xb9,0x90,0xf2,0x0f,0x7a,0xfd,0x7f,0x00,0x00,0xe8,0x25,0xb5,0x3d,0xfc,0x48,0x8b,0xd0,0x48,0xb9,0xc8,0xf0,0x0f,0x7a,0xfd,0x7f,0x00,0x00,0x48,0xb8,0xf0,0x99,0x8f,0xe9,0xfd,0x7f,0x00,0x00,0x48,0x83,0xc4,0x30,0x5b,0x5e,0x5f,0x48,0xff,0xe0,0x19,0x07,0x04,0x00,0x07,0x52};

        public static ReadOnlySpan<byte> AcceptsVectorヽᐤMethodInfoㆍ32iㆍW128ㆍTypeᐤ  =>  new byte[234]{0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x38,0x33,0xc0,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x4c,0x89,0x44,0x24,0x70,0x48,0x8b,0xf1,0x8b,0xda,0x49,0x8b,0xf9,0x48,0xb9,0x00,0xec,0x77,0x78,0xfd,0x7f,0x00,0x00,0xe8,0x80,0x08,0xee,0x5b,0x48,0x8b,0xe8,0x89,0x5d,0x10,0x48,0x0f,0xbe,0x54,0x24,0x70,0x88,0x55,0x18,0x48,0x8d,0x4d,0x08,0x48,0x8b,0xd7,0xe8,0xa5,0xf9,0xed,0x5b,0x48,0xb9,0xd8,0x76,0x17,0x79,0xfd,0x7f,0x00,0x00,0xe8,0x56,0x08,0xee,0x5b,0x48,0x8b,0xf8,0x48,0x8d,0x4f,0x08,0x48,0x8b,0xd5,0xe8,0x87,0xf9,0xed,0x5b,0x48,0xb9,0x30,0xce,0x52,0x78,0xfd,0x7f,0x00,0x00,0x48,0x89,0x4f,0x18,0x48,0x8b,0xce,0x48,0x8b,0x06,0x48,0x8b,0x40,0x50,0xff,0x50,0x20,0x48,0x85,0xc0,0x75,0x07,0x33,0xd2,0x45,0x33,0xc0,0xeb,0x08,0x48,0x8d,0x50,0x10,0x44,0x8b,0x40,0x08,0x48,0x8d,0x4c,0x24,0x28,0x48,0x89,0x11,0x44,0x89,0x41,0x08,0x48,0x8d,0x54,0x24,0x28,0x4c,0x8b,0xc7,0x48,0xb9,0x90,0xf2,0x0f,0x7a,0xfd,0x7f,0x00,0x00,0xe8,0x25,0xb4,0x3d,0xfc,0x48,0x8b,0xd0,0x48,0xb9,0xc8,0xf0,0x0f,0x7a,0xfd,0x7f,0x00,0x00,0x48,0xb8,0xf0,0x99,0x8f,0xe9,0xfd,0x7f,0x00,0x00,0x48,0x83,0xc4,0x38,0x5b,0x5d,0x5e,0x5f,0x48,0xff,0xe0,0x00,0x00,0x00,0x19,0x08,0x05,0x00,0x08,0x62,0x04,0x30,0x03,0x50};

        public static ReadOnlySpan<byte> AcceptsVectorヽᐤMethodInfoㆍ32iㆍW128ᐤ  =>  new byte[210]{0x57,0x56,0x53,0x48,0x83,0xec,0x30,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x4c,0x89,0x44,0x24,0x60,0x48,0x8b,0xf1,0x8b,0xfa,0x48,0xb9,0xd0,0xec,0x77,0x78,0xfd,0x7f,0x00,0x00,0xe8,0x84,0x07,0xee,0x5b,0x48,0x8b,0xd8,0x89,0x7b,0x08,0x48,0x0f,0xbe,0x4c,0x24,0x60,0x88,0x4b,0x10,0x48,0xb9,0xd8,0x76,0x17,0x79,0xfd,0x7f,0x00,0x00,0xe8,0x66,0x07,0xee,0x5b,0x48,0x8b,0xf8,0x48,0x8d,0x4f,0x08,0x48,0x8b,0xd3,0xe8,0x97,0xf8,0xed,0x5b,0x48,0xb9,0x48,0xce,0x52,0x78,0xfd,0x7f,0x00,0x00,0x48,0x89,0x4f,0x18,0x48,0x8b,0xce,0x48,0x8b,0x06,0x48,0x8b,0x40,0x50,0xff,0x50,0x20,0x48,0x85,0xc0,0x75,0x07,0x33,0xd2,0x45,0x33,0xc0,0xeb,0x08,0x48,0x8d,0x50,0x10,0x44,0x8b,0x40,0x08,0x48,0x8d,0x4c,0x24,0x20,0x48,0x89,0x11,0x44,0x89,0x41,0x08,0x48,0x8d,0x54,0x24,0x20,0x4c,0x8b,0xc7,0x48,0xb9,0x90,0xf2,0x0f,0x7a,0xfd,0x7f,0x00,0x00,0xe8,0x35,0xb3,0x3d,0xfc,0x48,0x8b,0xd0,0x48,0xb9,0xc8,0xf0,0x0f,0x7a,0xfd,0x7f,0x00,0x00,0x48,0xb8,0xf0,0x99,0x8f,0xe9,0xfd,0x7f,0x00,0x00,0x48,0x83,0xc4,0x30,0x5b,0x5e,0x5f,0x48,0xff,0xe0,0x19,0x07,0x04,0x00,0x07,0x52};

        public static ReadOnlySpan<byte> AcceptsVectorヽᐤMethodInfoㆍ32iㆍW256ᐤ  =>  new byte[210]{0x57,0x56,0x53,0x48,0x83,0xec,0x30,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x4c,0x89,0x44,0x24,0x60,0x48,0x8b,0xf1,0x8b,0xfa,0x48,0xb9,0xa0,0xed,0x77,0x78,0xfd,0x7f,0x00,0x00,0xe8,0x94,0x06,0xee,0x5b,0x48,0x8b,0xd8,0x89,0x7b,0x08,0x48,0x0f,0xbe,0x4c,0x24,0x60,0x88,0x4b,0x10,0x48,0xb9,0xd8,0x76,0x17,0x79,0xfd,0x7f,0x00,0x00,0xe8,0x76,0x06,0xee,0x5b,0x48,0x8b,0xf8,0x48,0x8d,0x4f,0x08,0x48,0x8b,0xd3,0xe8,0xa7,0xf7,0xed,0x5b,0x48,0xb9,0x60,0xce,0x52,0x78,0xfd,0x7f,0x00,0x00,0x48,0x89,0x4f,0x18,0x48,0x8b,0xce,0x48,0x8b,0x06,0x48,0x8b,0x40,0x50,0xff,0x50,0x20,0x48,0x85,0xc0,0x75,0x07,0x33,0xd2,0x45,0x33,0xc0,0xeb,0x08,0x48,0x8d,0x50,0x10,0x44,0x8b,0x40,0x08,0x48,0x8d,0x4c,0x24,0x20,0x48,0x89,0x11,0x44,0x89,0x41,0x08,0x48,0x8d,0x54,0x24,0x20,0x4c,0x8b,0xc7,0x48,0xb9,0x90,0xf2,0x0f,0x7a,0xfd,0x7f,0x00,0x00,0xe8,0x45,0xb2,0x3d,0xfc,0x48,0x8b,0xd0,0x48,0xb9,0xc8,0xf0,0x0f,0x7a,0xfd,0x7f,0x00,0x00,0x48,0xb8,0xf0,0x99,0x8f,0xe9,0xfd,0x7f,0x00,0x00,0x48,0x83,0xc4,0x30,0x5b,0x5e,0x5f,0x48,0xff,0xe0,0x19,0x07,0x04,0x00,0x07,0x52};

        public static ReadOnlySpan<byte> AcceptsVectorヽᐤMethodInfoㆍ32iㆍW256ㆍTypeᐤ  =>  new byte[234]{0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x38,0x33,0xc0,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x4c,0x89,0x44,0x24,0x70,0x48,0x8b,0xf1,0x8b,0xda,0x49,0x8b,0xf9,0x48,0xb9,0x98,0xee,0x77,0x78,0xfd,0x7f,0x00,0x00,0xe8,0xa0,0x05,0xee,0x5b,0x48,0x8b,0xe8,0x89,0x5d,0x10,0x48,0x0f,0xbe,0x54,0x24,0x70,0x88,0x55,0x18,0x48,0x8d,0x4d,0x08,0x48,0x8b,0xd7,0xe8,0xc5,0xf6,0xed,0x5b,0x48,0xb9,0xd8,0x76,0x17,0x79,0xfd,0x7f,0x00,0x00,0xe8,0x76,0x05,0xee,0x5b,0x48,0x8b,0xf8,0x48,0x8d,0x4f,0x08,0x48,0x8b,0xd5,0xe8,0xa7,0xf6,0xed,0x5b,0x48,0xb9,0x78,0xce,0x52,0x78,0xfd,0x7f,0x00,0x00,0x48,0x89,0x4f,0x18,0x48,0x8b,0xce,0x48,0x8b,0x06,0x48,0x8b,0x40,0x50,0xff,0x50,0x20,0x48,0x85,0xc0,0x75,0x07,0x33,0xd2,0x45,0x33,0xc0,0xeb,0x08,0x48,0x8d,0x50,0x10,0x44,0x8b,0x40,0x08,0x48,0x8d,0x4c,0x24,0x28,0x48,0x89,0x11,0x44,0x89,0x41,0x08,0x48,0x8d,0x54,0x24,0x28,0x4c,0x8b,0xc7,0x48,0xb9,0x90,0xf2,0x0f,0x7a,0xfd,0x7f,0x00,0x00,0xe8,0x45,0xb1,0x3d,0xfc,0x48,0x8b,0xd0,0x48,0xb9,0xc8,0xf0,0x0f,0x7a,0xfd,0x7f,0x00,0x00,0x48,0xb8,0xf0,0x99,0x8f,0xe9,0xfd,0x7f,0x00,0x00,0x48,0x83,0xc4,0x38,0x5b,0x5d,0x5e,0x5f,0x48,0xff,0xe0,0x00,0x00,0x00,0x19,0x08,0x05,0x00,0x08,0x62,0x04,0x30,0x03,0x50};

        public static ReadOnlySpan<byte> AcceptsVectorヽᐤMethodInfoㆍ32iㆍW512ㆍTypeᐤ  =>  new byte[234]{0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x38,0x33,0xc0,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x4c,0x89,0x44,0x24,0x70,0x48,0x8b,0xf1,0x8b,0xda,0x49,0x8b,0xf9,0x48,0xb9,0x90,0xef,0x77,0x78,0xfd,0x7f,0x00,0x00,0xe8,0xa0,0x04,0xee,0x5b,0x48,0x8b,0xe8,0x89,0x5d,0x10,0x48,0x0f,0xbe,0x54,0x24,0x70,0x88,0x55,0x18,0x48,0x8d,0x4d,0x08,0x48,0x8b,0xd7,0xe8,0xc5,0xf5,0xed,0x5b,0x48,0xb9,0xd8,0x76,0x17,0x79,0xfd,0x7f,0x00,0x00,0xe8,0x76,0x04,0xee,0x5b,0x48,0x8b,0xf8,0x48,0x8d,0x4f,0x08,0x48,0x8b,0xd5,0xe8,0xa7,0xf5,0xed,0x5b,0x48,0xb9,0x90,0xce,0x52,0x78,0xfd,0x7f,0x00,0x00,0x48,0x89,0x4f,0x18,0x48,0x8b,0xce,0x48,0x8b,0x06,0x48,0x8b,0x40,0x50,0xff,0x50,0x20,0x48,0x85,0xc0,0x75,0x07,0x33,0xd2,0x45,0x33,0xc0,0xeb,0x08,0x48,0x8d,0x50,0x10,0x44,0x8b,0x40,0x08,0x48,0x8d,0x4c,0x24,0x28,0x48,0x89,0x11,0x44,0x89,0x41,0x08,0x48,0x8d,0x54,0x24,0x28,0x4c,0x8b,0xc7,0x48,0xb9,0x90,0xf2,0x0f,0x7a,0xfd,0x7f,0x00,0x00,0xe8,0x45,0xb0,0x3d,0xfc,0x48,0x8b,0xd0,0x48,0xb9,0xc8,0xf0,0x0f,0x7a,0xfd,0x7f,0x00,0x00,0x48,0xb8,0xf0,0x99,0x8f,0xe9,0xfd,0x7f,0x00,0x00,0x48,0x83,0xc4,0x38,0x5b,0x5d,0x5e,0x5f,0x48,0xff,0xe0,0x00,0x00,0x00,0x19,0x08,0x05,0x00,0x08,0x62,0x04,0x30,0x03,0x50};

        public static ReadOnlySpan<byte> ReturnsVectorヽᐤMethodInfoㆍW128ᐤ  =>  new byte[39]{0x48,0x83,0xec,0x28,0x90,0x48,0x8b,0x01,0x48,0x8b,0x40,0x60,0xff,0x50,0x28,0x48,0x8b,0xc8,0xe8,0x99,0xde,0xff,0xff,0x3d,0x80,0x00,0x00,0x00,0x0f,0x94,0xc0,0x0f,0xb6,0xc0,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> ReturnsVectorヽᐤMethodInfoㆍW256ᐤ  =>  new byte[39]{0x48,0x83,0xec,0x28,0x90,0x48,0x8b,0x01,0x48,0x8b,0x40,0x60,0xff,0x50,0x28,0x48,0x8b,0xc8,0xe8,0x59,0xde,0xff,0xff,0x3d,0x00,0x01,0x00,0x00,0x0f,0x94,0xc0,0x0f,0xb6,0xc0,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> ReturnsVectorヽᐤMethodInfoㆍW512ᐤ  =>  new byte[39]{0x48,0x83,0xec,0x28,0x90,0x48,0x8b,0x01,0x48,0x8b,0x40,0x60,0xff,0x50,0x28,0x48,0x8b,0xc8,0xe8,0x19,0xde,0xff,0xff,0x3d,0x00,0x02,0x00,0x00,0x0f,0x94,0xc0,0x0f,0xb6,0xc0,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> ReturnsVectorヽᐤMethodInfoㆍW128ㆍTypeᐤ  =>  new byte[155]{0x57,0x56,0x48,0x83,0xec,0x28,0x49,0x8b,0xf0,0x48,0x8b,0x01,0x48,0x8b,0x40,0x60,0xff,0x50,0x28,0x48,0x8b,0xf8,0x48,0x8b,0xcf,0xe8,0xd2,0xdd,0xff,0xff,0x3d,0x80,0x00,0x00,0x00,0x75,0x6d,0x48,0x8b,0xcf,0x48,0x8b,0x07,0x48,0x8b,0x40,0x58,0xff,0x50,0x20,0x48,0x8b,0xc8,0x48,0x8b,0x00,0x48,0x8b,0x40,0x58,0xff,0x50,0x38,0x85,0xc0,0x75,0x05,0x48,0x8b,0xcf,0xeb,0x10,0x48,0x8b,0xcf,0x48,0x8b,0x07,0x48,0x8b,0x40,0x68,0xff,0x50,0x18,0x48,0x8b,0xc8,0x48,0x8b,0x01,0x48,0x8b,0x40,0x60,0xff,0x50,0x08,0x85,0xc0,0x74,0x2c,0x48,0x8b,0xcf,0xba,0x01,0x00,0x00,0x00,0xe8,0xed,0x2d,0x2c,0xff,0x48,0x8b,0xd0,0x48,0xb9,0x78,0xc8,0x19,0x79,0xfd,0x7f,0x00,0x00,0xe8,0x4b,0xad,0x38,0xfe,0x48,0x8b,0xc8,0x48,0x8b,0xd6,0xe8,0xa0,0x82,0xe9,0x5b,0xeb,0x02,0x33,0xc0,0x48,0x83,0xc4,0x28,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> ReturnsVectorヽᐤMethodInfoㆍW256ㆍTypeᐤ  =>  new byte[155]{0x57,0x56,0x48,0x83,0xec,0x28,0x49,0x8b,0xf0,0x48,0x8b,0x01,0x48,0x8b,0x40,0x60,0xff,0x50,0x28,0x48,0x8b,0xf8,0x48,0x8b,0xcf,0xe8,0x12,0xdd,0xff,0xff,0x3d,0x00,0x01,0x00,0x00,0x75,0x6d,0x48,0x8b,0xcf,0x48,0x8b,0x07,0x48,0x8b,0x40,0x58,0xff,0x50,0x20,0x48,0x8b,0xc8,0x48,0x8b,0x00,0x48,0x8b,0x40,0x58,0xff,0x50,0x38,0x85,0xc0,0x75,0x05,0x48,0x8b,0xcf,0xeb,0x10,0x48,0x8b,0xcf,0x48,0x8b,0x07,0x48,0x8b,0x40,0x68,0xff,0x50,0x18,0x48,0x8b,0xc8,0x48,0x8b,0x01,0x48,0x8b,0x40,0x60,0xff,0x50,0x08,0x85,0xc0,0x74,0x2c,0x48,0x8b,0xcf,0xba,0x01,0x00,0x00,0x00,0xe8,0x2d,0x2d,0x2c,0xff,0x48,0x8b,0xd0,0x48,0xb9,0x78,0xc8,0x19,0x79,0xfd,0x7f,0x00,0x00,0xe8,0x8b,0xac,0x38,0xfe,0x48,0x8b,0xc8,0x48,0x8b,0xd6,0xe8,0xe0,0x81,0xe9,0x5b,0xeb,0x02,0x33,0xc0,0x48,0x83,0xc4,0x28,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> ReturnsVectorヽᐤMethodInfoㆍW512ㆍTypeᐤ  =>  new byte[155]{0x57,0x56,0x48,0x83,0xec,0x28,0x49,0x8b,0xf0,0x48,0x8b,0x01,0x48,0x8b,0x40,0x60,0xff,0x50,0x28,0x48,0x8b,0xf8,0x48,0x8b,0xcf,0xe8,0x52,0xdc,0xff,0xff,0x3d,0x00,0x02,0x00,0x00,0x75,0x6d,0x48,0x8b,0xcf,0x48,0x8b,0x07,0x48,0x8b,0x40,0x58,0xff,0x50,0x20,0x48,0x8b,0xc8,0x48,0x8b,0x00,0x48,0x8b,0x40,0x58,0xff,0x50,0x38,0x85,0xc0,0x75,0x05,0x48,0x8b,0xcf,0xeb,0x10,0x48,0x8b,0xcf,0x48,0x8b,0x07,0x48,0x8b,0x40,0x68,0xff,0x50,0x18,0x48,0x8b,0xc8,0x48,0x8b,0x01,0x48,0x8b,0x40,0x60,0xff,0x50,0x08,0x85,0xc0,0x74,0x2c,0x48,0x8b,0xcf,0xba,0x01,0x00,0x00,0x00,0xe8,0x6d,0x2c,0x2c,0xff,0x48,0x8b,0xd0,0x48,0xb9,0x78,0xc8,0x19,0x79,0xfd,0x7f,0x00,0x00,0xe8,0xcb,0xab,0x38,0xfe,0x48,0x8b,0xc8,0x48,0x8b,0xd6,0xe8,0x20,0x81,0xe9,0x5b,0xeb,0x02,0x33,0xc0,0x48,0x83,0xc4,0x28,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> IsVectorizedヽᐤMethodInfoㆍintㆍboolᐤ  =>  new byte[614]{0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x28,0x48,0x89,0x54,0x24,0x58,0x48,0x8b,0xf1,0x41,0x8b,0xf8,0x48,0xb9,0x80,0xe4,0x77,0x78,0xfd,0x7f,0x00,0x00,0xe8,0xae,0x00,0xee,0x5b,0x48,0x8b,0xd8,0x48,0x8b,0x4c,0x24,0x58,0x48,0x89,0x4b,0x08,0x40,0x84,0xff,0x0f,0x85,0x0b,0x01,0x00,0x00,0x48,0x8b,0xce,0x48,0x8b,0x06,0x48,0x8b,0x40,0x60,0xff,0x50,0x28,0x48,0x8b,0xc8,0x48,0x8b,0x53,0x08,0xe8,0x30,0xd3,0xff,0xff,0x85,0xc0,0x0f,0x85,0xdc,0x00,0x00,0x00,0x48,0x8b,0xce,0x48,0x8b,0x06,0x48,0x8b,0x40,0x50,0xff,0x50,0x20,0x48,0x8b,0xf0,0x48,0xb9,0x68,0x57,0x4d,0x73,0xd5,0x01,0x00,0x00,0x48,0x8b,0x39,0x48,0x85,0xff,0x75,0x51,0x48,0xb9,0x78,0x91,0x10,0x79,0xfd,0x7f,0x00,0x00,0xe8,0x47,0x00,0xee,0x5b,0x48,0x8b,0xf8,0x48,0xba,0x30,0x56,0x4d,0x73,0xd5,0x01,0x00,0x00,0x48,0x8b,0x12,0x48,0x85,0xd2,0x0f,0x84,0xa8,0x01,0x00,0x00,0x48,0x8d,0x4f,0x08,0xe8,0x65,0xf1,0xed,0x5b,0x48,0xba,0x80,0x7d,0xd3,0x78,0xfd,0x7f,0x00,0x00,0x48,0x89,0x57,0x18,0x48,0xb9,0x68,0x57,0x4d,0x73,0xd5,0x01,0x00,0x00,0x48,0x8b,0xd7,0xe8,0x15,0xf1,0xed,0x5b,0x48,0xb9,0xa8,0x7c,0x01,0x78,0xfd,0x7f,0x00,0x00,0xe8,0xf6,0xff,0xed,0x5b,0x48,0x8b,0xe8,0x4c,0x8b,0xc7,0x48,0x8b,0xd6,0x48,0xb9,0x80,0x92,0x10,0x79,0xfd,0x7f,0x00,0x00,0xe8,0x5e,0xde,0x3d,0xfc,0x48,0x8b,0xf0,0x48,0x8d,0x4d,0x08,0x48,0x8b,0xd3,0xe8,0x0f,0xf1,0xed,0x5b,0x49,0xb8,0x58,0xcd,0x52,0x78,0xfd,0x7f,0x00,0x00,0x4c,0x89,0x45,0x18,0x4c,0x8b,0xc5,0x48,0x8b,0xd6,0x48,0xb9,0xd8,0x1f,0xfb,0x7a,0xfd,0x7f,0x00,0x00,0x48,0xb8,0xb8,0xcc,0xca,0x79,0xfd,0x7f,0x00,0x00,0x48,0x83,0xc4,0x28,0x5b,0x5d,0x5e,0x5f,0x48,0xff,0xe0,0xb8,0x01,0x00,0x00,0x00,0x48,0x83,0xc4,0x28,0x5b,0x5d,0x5e,0x5f,0xc3,0x48,0x8b,0xce,0x48,0x8b,0x06,0x48,0x8b,0x40,0x60,0xff,0x50,0x28,0x48,0x8b,0xc8,0x48,0x8b,0x53,0x08,0xe8,0x25,0xd2,0xff,0xff,0x85,0xc0,0x0f,0x84,0xdc,0x00,0x00,0x00,0x48,0x8b,0xce,0x48,0x8b,0x06,0x48,0x8b,0x40,0x50,0xff,0x50,0x20,0x48,0x8b,0xf0,0x48,0xb9,0x68,0x57,0x4d,0x73,0xd5,0x01,0x00,0x00,0x48,0x8b,0x39,0x48,0x85,0xff,0x75,0x51,0x48,0xb9,0x78,0x91,0x10,0x79,0xfd,0x7f,0x00,0x00,0xe8,0x3c,0xff,0xed,0x5b,0x48,0x8b,0xf8,0x48,0xba,0x30,0x56,0x4d,0x73,0xd5,0x01,0x00,0x00,0x48,0x8b,0x12,0x48,0x85,0xd2,0x0f,0x84,0xa6,0x00,0x00,0x00,0x48,0x8d,0x4f,0x08,0xe8,0x5a,0xf0,0xed,0x5b,0x48,0xba,0x80,0x7d,0xd3,0x78,0xfd,0x7f,0x00,0x00,0x48,0x89,0x57,0x18,0x48,0xb9,0x68,0x57,0x4d,0x73,0xd5,0x01,0x00,0x00,0x48,0x8b,0xd7,0xe8,0x0a,0xf0,0xed,0x5b,0x48,0xb9,0xa8,0x7c,0x01,0x78,0xfd,0x7f,0x00,0x00,0xe8,0xeb,0xfe,0xed,0x5b,0x48,0x8b,0xe8,0x4c,0x8b,0xc7,0x48,0x8b,0xd6,0x48,0xb9,0x80,0x92,0x10,0x79,0xfd,0x7f,0x00,0x00,0xe8,0x53,0xdd,0x3d,0xfc,0x48,0x8b,0xf0,0x48,0x8d,0x4d,0x08,0x48,0x8b,0xd3,0xe8,0x04,0xf0,0xed,0x5b,0x49,0xb8,0x50,0xcd,0x52,0x78,0xfd,0x7f,0x00,0x00,0x4c,0x89,0x45,0x18,0x4c,0x8b,0xc5,0x48,0x8b,0xd6,0x48,0xb9,0xe8,0x3d,0x14,0x7a,0xfd,0x7f,0x00,0x00,0x48,0xb8,0x50,0x4d,0xc8,0x79,0xfd,0x7f,0x00,0x00,0x48,0x83,0xc4,0x28,0x5b,0x5d,0x5e,0x5f,0x48,0xff,0xe0,0x33,0xc0,0x48,0x83,0xc4,0x28,0x5b,0x5d,0x5e,0x5f,0xc3,0x48,0x8b,0xcf,0xe8,0xee,0xc1,0x3a,0xfc,0xcc,0x48,0x8b,0xcf,0xe8,0xe5,0xc1,0x3a,0xfc,0xcc,0x19,0x08,0x05,0x00,0x08,0x42,0x04,0x30,0x03,0x50};

        public static ReadOnlySpan<byte> IsVectorizedヽᐤMethodInfoᐤ  =>  new byte[546]{0x57,0x56,0x53,0x48,0x83,0xec,0x20,0x48,0x8b,0xf1,0x48,0x8b,0xce,0x48,0x8b,0x06,0x48,0x8b,0x40,0x60,0xff,0x50,0x28,0x48,0x8b,0xc8,0xe8,0x81,0xa1,0xb1,0xfe,0x84,0xc0,0x0f,0x85,0xe9,0x00,0x00,0x00,0x48,0x8b,0xce,0x48,0x8b,0x06,0x48,0x8b,0x40,0x50,0xff,0x50,0x20,0x48,0x8b,0xf0,0x48,0xb9,0x68,0x57,0x4d,0x73,0xd5,0x01,0x00,0x00,0x48,0x8b,0x39,0x48,0x85,0xff,0x75,0x51,0x48,0xb9,0x78,0x91,0x10,0x79,0xfd,0x7f,0x00,0x00,0xe8,0xf8,0xfd,0xed,0x5b,0x48,0x8b,0xf8,0x48,0xba,0x30,0x56,0x4d,0x73,0xd5,0x01,0x00,0x00,0x48,0x8b,0x12,0x48,0x85,0xd2,0x0f,0x84,0xac,0x00,0x00,0x00,0x48,0x8d,0x4f,0x08,0xe8,0x16,0xef,0xed,0x5b,0x48,0xba,0x80,0x7d,0xd3,0x78,0xfd,0x7f,0x00,0x00,0x48,0x89,0x57,0x18,0x48,0xb9,0x68,0x57,0x4d,0x73,0xd5,0x01,0x00,0x00,0x48,0x8b,0xd7,0xe8,0xc6,0xee,0xed,0x5b,0x48,0xb9,0xa8,0x7c,0x01,0x78,0xfd,0x7f,0x00,0x00,0xe8,0xa7,0xfd,0xed,0x5b,0x48,0x8b,0xd8,0x4c,0x8b,0xc7,0x48,0x8b,0xd6,0x48,0xb9,0x80,0x92,0x10,0x79,0xfd,0x7f,0x00,0x00,0xe8,0x0f,0xdc,0x3d,0xfc,0x48,0x8b,0xf0,0x48,0x8d,0x4b,0x08,0x48,0x8b,0xd3,0xe8,0xc0,0xee,0xed,0x5b,0x49,0xb8,0x70,0xd0,0xc4,0x76,0xfd,0x7f,0x00,0x00,0x4c,0x89,0x43,0x18,0x49,0xb8,0xa0,0x49,0x9c,0x7a,0xfd,0x7f,0x00,0x00,0x4c,0x89,0x43,0x20,0x4c,0x8b,0xc3,0x48,0x8b,0xd6,0x48,0xb9,0xd8,0x1f,0xfb,0x7a,0xfd,0x7f,0x00,0x00,0x48,0xb8,0xb8,0xcc,0xca,0x79,0xfd,0x7f,0x00,0x00,0x48,0x83,0xc4,0x20,0x5b,0x5e,0x5f,0x48,0xff,0xe0,0xb8,0x01,0x00,0x00,0x00,0x48,0x83,0xc4,0x20,0x5b,0x5e,0x5f,0xc3,0x48,0x8b,0xcf,0xe8,0x9b,0xc0,0x3a,0xfc,0xcc,0x00,0x00,0x19,0x07,0x04,0x00,0x07,0x32,0x03,0x30,0x02,0x60,0x01,0x70,0x40,0x00,0x00,0x00,0x38,0x3c,0xfa,0x7a,0xfd,0x7f,0x00,0x00,0x57,0x56,0x53,0x48,0x83,0xec,0x30,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x54,0x24,0x58,0x48,0x8b,0xf1,0x48,0xb9,0x40,0xe5,0x77,0x78,0xfd,0x7f,0x00,0x00,0xe8,0xe6,0xfc,0xed,0x5b,0x48,0x8b,0xf8,0x48,0x0f,0xbe,0x4c,0x24,0x58,0x88,0x4f,0x08,0x48,0x8b,0xce,0xe8,0x82,0xfe,0xff,0xff,0x85,0xc0,0x0f,0x84,0x92,0x00,0x00,0x00,0x48,0xb9,0xd8,0x76,0x17,0x79,0xfd,0x7f,0x00,0x00,0xe8,0xbb,0xfc,0xed,0x5b,0x48,0x8b,0xd8,0x48,0x8d,0x4b,0x08,0x48,0x8b,0xd7,0xe8,0xec,0xed,0xed,0x5b,0x48,0xb9,0x70,0xcd,0x52,0x78,0xfd,0x7f,0x00,0x00,0x48,0x89,0x4b,0x18,0x48,0x8b,0xce,0x48,0x8b,0x06,0x48,0x8b,0x40,0x50,0xff,0x50,0x20,0x48,0x85,0xc0,0x75,0x07,0x33,0xd2,0x45,0x33,0xc0,0xeb,0x08,0x48,0x8d,0x50,0x10,0x44,0x8b,0x40,0x08,0x48,0x8d,0x4c,0x24,0x20,0x48,0x89,0x11,0x44,0x89,0x41,0x08,0x48,0x8d,0x54,0x24,0x20,0x4c,0x8b,0xc3,0x48,0xb9,0x90,0xf2,0x0f,0x7a,0xfd,0x7f,0x00,0x00,0xe8,0x8a,0xa8,0x3d,0xfc,0x48,0x8b,0xd0,0x48,0xb9,0x48,0x20,0xfb,0x7a,0xfd,0x7f,0x00,0x00,0xe8,0x38,0xd1,0x2b,0xff,0x85,0xc0,0x0f,0x95,0xc0,0x0f,0xb6,0xc0,0x48,0x83,0xc4,0x30,0x5b,0x5e,0x5f,0xc3,0x33,0xc0,0x48,0x83,0xc4,0x30,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> IsVectorizedヽᐤMethodInfoㆍW128ᐤ  =>  new byte[226]{0x57,0x56,0x53,0x48,0x83,0xec,0x30,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x54,0x24,0x58,0x48,0x8b,0xf1,0x48,0xb9,0x40,0xe5,0x77,0x78,0xfd,0x7f,0x00,0x00,0xe8,0xe6,0xfc,0xed,0x5b,0x48,0x8b,0xf8,0x48,0x0f,0xbe,0x4c,0x24,0x58,0x88,0x4f,0x08,0x48,0x8b,0xce,0xe8,0x82,0xfe,0xff,0xff,0x85,0xc0,0x0f,0x84,0x92,0x00,0x00,0x00,0x48,0xb9,0xd8,0x76,0x17,0x79,0xfd,0x7f,0x00,0x00,0xe8,0xbb,0xfc,0xed,0x5b,0x48,0x8b,0xd8,0x48,0x8d,0x4b,0x08,0x48,0x8b,0xd7,0xe8,0xec,0xed,0xed,0x5b,0x48,0xb9,0x70,0xcd,0x52,0x78,0xfd,0x7f,0x00,0x00,0x48,0x89,0x4b,0x18,0x48,0x8b,0xce,0x48,0x8b,0x06,0x48,0x8b,0x40,0x50,0xff,0x50,0x20,0x48,0x85,0xc0,0x75,0x07,0x33,0xd2,0x45,0x33,0xc0,0xeb,0x08,0x48,0x8d,0x50,0x10,0x44,0x8b,0x40,0x08,0x48,0x8d,0x4c,0x24,0x20,0x48,0x89,0x11,0x44,0x89,0x41,0x08,0x48,0x8d,0x54,0x24,0x20,0x4c,0x8b,0xc3,0x48,0xb9,0x90,0xf2,0x0f,0x7a,0xfd,0x7f,0x00,0x00,0xe8,0x8a,0xa8,0x3d,0xfc,0x48,0x8b,0xd0,0x48,0xb9,0x48,0x20,0xfb,0x7a,0xfd,0x7f,0x00,0x00,0xe8,0x38,0xd1,0x2b,0xff,0x85,0xc0,0x0f,0x95,0xc0,0x0f,0xb6,0xc0,0x48,0x83,0xc4,0x30,0x5b,0x5e,0x5f,0xc3,0x33,0xc0,0x48,0x83,0xc4,0x30,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> IsVectorizedヽᐤMethodInfoㆍW256ᐤ  =>  new byte[226]{0x57,0x56,0x53,0x48,0x83,0xec,0x30,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x54,0x24,0x58,0x48,0x8b,0xf1,0x48,0xb9,0x00,0xe6,0x77,0x78,0xfd,0x7f,0x00,0x00,0xe8,0xe6,0xfb,0xed,0x5b,0x48,0x8b,0xf8,0x48,0x0f,0xbe,0x4c,0x24,0x58,0x88,0x4f,0x08,0x48,0x8b,0xce,0xe8,0x82,0xfd,0xff,0xff,0x85,0xc0,0x0f,0x84,0x92,0x00,0x00,0x00,0x48,0xb9,0xd8,0x76,0x17,0x79,0xfd,0x7f,0x00,0x00,0xe8,0xbb,0xfb,0xed,0x5b,0x48,0x8b,0xd8,0x48,0x8d,0x4b,0x08,0x48,0x8b,0xd7,0xe8,0xec,0xec,0xed,0x5b,0x48,0xb9,0x88,0xcd,0x52,0x78,0xfd,0x7f,0x00,0x00,0x48,0x89,0x4b,0x18,0x48,0x8b,0xce,0x48,0x8b,0x06,0x48,0x8b,0x40,0x50,0xff,0x50,0x20,0x48,0x85,0xc0,0x75,0x07,0x33,0xd2,0x45,0x33,0xc0,0xeb,0x08,0x48,0x8d,0x50,0x10,0x44,0x8b,0x40,0x08,0x48,0x8d,0x4c,0x24,0x20,0x48,0x89,0x11,0x44,0x89,0x41,0x08,0x48,0x8d,0x54,0x24,0x20,0x4c,0x8b,0xc3,0x48,0xb9,0x90,0xf2,0x0f,0x7a,0xfd,0x7f,0x00,0x00,0xe8,0x8a,0xa7,0x3d,0xfc,0x48,0x8b,0xd0,0x48,0xb9,0x48,0x20,0xfb,0x7a,0xfd,0x7f,0x00,0x00,0xe8,0x38,0xd0,0x2b,0xff,0x85,0xc0,0x0f,0x95,0xc0,0x0f,0xb6,0xc0,0x48,0x83,0xc4,0x30,0x5b,0x5e,0x5f,0xc3,0x33,0xc0,0x48,0x83,0xc4,0x30,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> IsVectorizedヽᐤMethodInfoㆍW512ᐤ  =>  new byte[226]{0x57,0x56,0x53,0x48,0x83,0xec,0x30,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x54,0x24,0x58,0x48,0x8b,0xf1,0x48,0xb9,0xc0,0xe6,0x77,0x78,0xfd,0x7f,0x00,0x00,0xe8,0xe6,0xfa,0xed,0x5b,0x48,0x8b,0xf8,0x48,0x0f,0xbe,0x4c,0x24,0x58,0x88,0x4f,0x08,0x48,0x8b,0xce,0xe8,0x82,0xfc,0xff,0xff,0x85,0xc0,0x0f,0x84,0x92,0x00,0x00,0x00,0x48,0xb9,0xd8,0x76,0x17,0x79,0xfd,0x7f,0x00,0x00,0xe8,0xbb,0xfa,0xed,0x5b,0x48,0x8b,0xd8,0x48,0x8d,0x4b,0x08,0x48,0x8b,0xd7,0xe8,0xec,0xeb,0xed,0x5b,0x48,0xb9,0xa0,0xcd,0x52,0x78,0xfd,0x7f,0x00,0x00,0x48,0x89,0x4b,0x18,0x48,0x8b,0xce,0x48,0x8b,0x06,0x48,0x8b,0x40,0x50,0xff,0x50,0x20,0x48,0x85,0xc0,0x75,0x07,0x33,0xd2,0x45,0x33,0xc0,0xeb,0x08,0x48,0x8d,0x50,0x10,0x44,0x8b,0x40,0x08,0x48,0x8d,0x4c,0x24,0x20,0x48,0x89,0x11,0x44,0x89,0x41,0x08,0x48,0x8d,0x54,0x24,0x20,0x4c,0x8b,0xc3,0x48,0xb9,0x90,0xf2,0x0f,0x7a,0xfd,0x7f,0x00,0x00,0xe8,0x8a,0xa6,0x3d,0xfc,0x48,0x8b,0xd0,0x48,0xb9,0x48,0x20,0xfb,0x7a,0xfd,0x7f,0x00,0x00,0xe8,0x38,0xcf,0x2b,0xff,0x85,0xc0,0x0f,0x95,0xc0,0x0f,0xb6,0xc0,0x48,0x83,0xc4,0x30,0x5b,0x5e,0x5f,0xc3,0x33,0xc0,0x48,0x83,0xc4,0x30,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> IsVectorizedヽᐤMethodInfoㆍW128ㆍTypeᐤ  =>  new byte[241]{0x57,0x56,0x53,0x48,0x83,0xec,0x30,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x54,0x24,0x58,0x48,0x8b,0xf1,0x49,0x8b,0xf8,0x48,0xb9,0xa8,0xe7,0x77,0x78,0xfd,0x7f,0x00,0x00,0xe8,0xe3,0xf9,0xed,0x5b,0x48,0x8b,0xd8,0x48,0x0f,0xbe,0x54,0x24,0x58,0x88,0x53,0x10,0x48,0x8d,0x4b,0x08,0x48,0x8b,0xd7,0xe8,0x0b,0xeb,0xed,0x5b,0x48,0x8b,0xce,0xe8,0x73,0xfb,0xff,0xff,0x85,0xc0,0x0f,0x84,0x92,0x00,0x00,0x00,0x48,0xb9,0xd8,0x76,0x17,0x79,0xfd,0x7f,0x00,0x00,0xe8,0xac,0xf9,0xed,0x5b,0x48,0x8b,0xf8,0x48,0x8d,0x4f,0x08,0x48,0x8b,0xd3,0xe8,0xdd,0xea,0xed,0x5b,0x48,0xb9,0xb8,0xcd,0x52,0x78,0xfd,0x7f,0x00,0x00,0x48,0x89,0x4f,0x18,0x48,0x8b,0xce,0x48,0x8b,0x06,0x48,0x8b,0x40,0x50,0xff,0x50,0x20,0x48,0x85,0xc0,0x75,0x07,0x33,0xd2,0x45,0x33,0xc0,0xeb,0x08,0x48,0x8d,0x50,0x10,0x44,0x8b,0x40,0x08,0x48,0x8d,0x4c,0x24,0x20,0x48,0x89,0x11,0x44,0x89,0x41,0x08,0x48,0x8d,0x54,0x24,0x20,0x4c,0x8b,0xc7,0x48,0xb9,0x90,0xf2,0x0f,0x7a,0xfd,0x7f,0x00,0x00,0xe8,0x7b,0xa5,0x3d,0xfc,0x48,0x8b,0xd0,0x48,0xb9,0x48,0x20,0xfb,0x7a,0xfd,0x7f,0x00,0x00,0xe8,0x29,0xce,0x2b,0xff,0x85,0xc0,0x0f,0x95,0xc0,0x0f,0xb6,0xc0,0x48,0x83,0xc4,0x30,0x5b,0x5e,0x5f,0xc3,0x33,0xc0,0x48,0x83,0xc4,0x30,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> IsVectorizedヽᐤMethodInfoㆍW256ㆍTypeᐤ  =>  new byte[241]{0x57,0x56,0x53,0x48,0x83,0xec,0x30,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x54,0x24,0x58,0x48,0x8b,0xf1,0x49,0x8b,0xf8,0x48,0xb9,0x90,0xe8,0x77,0x78,0xfd,0x7f,0x00,0x00,0xe8,0xd3,0xf8,0xed,0x5b,0x48,0x8b,0xd8,0x48,0x0f,0xbe,0x54,0x24,0x58,0x88,0x53,0x10,0x48,0x8d,0x4b,0x08,0x48,0x8b,0xd7,0xe8,0xfb,0xe9,0xed,0x5b,0x48,0x8b,0xce,0xe8,0x63,0xfa,0xff,0xff,0x85,0xc0,0x0f,0x84,0x92,0x00,0x00,0x00,0x48,0xb9,0xd8,0x76,0x17,0x79,0xfd,0x7f,0x00,0x00,0xe8,0x9c,0xf8,0xed,0x5b,0x48,0x8b,0xf8,0x48,0x8d,0x4f,0x08,0x48,0x8b,0xd3,0xe8,0xcd,0xe9,0xed,0x5b,0x48,0xb9,0xd0,0xcd,0x52,0x78,0xfd,0x7f,0x00,0x00,0x48,0x89,0x4f,0x18,0x48,0x8b,0xce,0x48,0x8b,0x06,0x48,0x8b,0x40,0x50,0xff,0x50,0x20,0x48,0x85,0xc0,0x75,0x07,0x33,0xd2,0x45,0x33,0xc0,0xeb,0x08,0x48,0x8d,0x50,0x10,0x44,0x8b,0x40,0x08,0x48,0x8d,0x4c,0x24,0x20,0x48,0x89,0x11,0x44,0x89,0x41,0x08,0x48,0x8d,0x54,0x24,0x20,0x4c,0x8b,0xc7,0x48,0xb9,0x90,0xf2,0x0f,0x7a,0xfd,0x7f,0x00,0x00,0xe8,0x6b,0xa4,0x3d,0xfc,0x48,0x8b,0xd0,0x48,0xb9,0x48,0x20,0xfb,0x7a,0xfd,0x7f,0x00,0x00,0xe8,0x19,0xcd,0x2b,0xff,0x85,0xc0,0x0f,0x95,0xc0,0x0f,0xb6,0xc0,0x48,0x83,0xc4,0x30,0x5b,0x5e,0x5f,0xc3,0x33,0xc0,0x48,0x83,0xc4,0x30,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> IsVectorizedヽᐤMethodInfoㆍW512ㆍTypeᐤ  =>  new byte[246]{0x57,0x56,0x53,0x48,0x83,0xec,0x30,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x54,0x24,0x58,0x48,0x8b,0xf1,0x49,0x8b,0xf8,0x48,0xb9,0x78,0xe9,0x77,0x78,0xfd,0x7f,0x00,0x00,0xe8,0xc3,0xf7,0xed,0x5b,0x48,0x8b,0xd8,0x48,0x0f,0xbe,0x54,0x24,0x58,0x88,0x53,0x10,0x48,0x8d,0x4b,0x08,0x48,0x8b,0xd7,0xe8,0xeb,0xe8,0xed,0x5b,0x48,0x0f,0xbe,0x53,0x10,0x48,0x8b,0xce,0xe8,0x8e,0xfc,0xff,0xff,0x85,0xc0,0x0f,0x84,0x92,0x00,0x00,0x00,0x48,0xb9,0xd8,0x76,0x17,0x79,0xfd,0x7f,0x00,0x00,0xe8,0x87,0xf7,0xed,0x5b,0x48,0x8b,0xf8,0x48,0x8d,0x4f,0x08,0x48,0x8b,0xd3,0xe8,0xb8,0xe8,0xed,0x5b,0x48,0xb9,0xe8,0xcd,0x52,0x78,0xfd,0x7f,0x00,0x00,0x48,0x89,0x4f,0x18,0x48,0x8b,0xce,0x48,0x8b,0x06,0x48,0x8b,0x40,0x50,0xff,0x50,0x20,0x48,0x85,0xc0,0x75,0x07,0x33,0xd2,0x45,0x33,0xc0,0xeb,0x08,0x48,0x8d,0x50,0x10,0x44,0x8b,0x40,0x08,0x48,0x8d,0x4c,0x24,0x20,0x48,0x89,0x11,0x44,0x89,0x41,0x08,0x48,0x8d,0x54,0x24,0x20,0x4c,0x8b,0xc7,0x48,0xb9,0x90,0xf2,0x0f,0x7a,0xfd,0x7f,0x00,0x00,0xe8,0x56,0xa3,0x3d,0xfc,0x48,0x8b,0xd0,0x48,0xb9,0x48,0x20,0xfb,0x7a,0xfd,0x7f,0x00,0x00,0xe8,0x04,0xcc,0x2b,0xff,0x85,0xc0,0x0f,0x95,0xc0,0x0f,0xb6,0xc0,0x48,0x83,0xc4,0x30,0x5b,0x5e,0x5f,0xc3,0x33,0xc0,0x48,0x83,0xc4,0x30,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> IsVectorizedヽᐤMethodInfoㆍW128ㆍGenericStateᐤ  =>  new byte[62]{0x57,0x56,0x48,0x83,0xec,0x28,0x48,0x89,0x54,0x24,0x48,0x48,0x8b,0xf1,0x41,0x8b,0xf8,0x48,0x8b,0xce,0x48,0x0f,0xbe,0x54,0x24,0x48,0xe8,0xb1,0xf9,0xff,0xff,0x85,0xc0,0x74,0x12,0x48,0x8b,0xce,0x8b,0xd7,0xe8,0x33,0x4f,0x2c,0xff,0x90,0x48,0x83,0xc4,0x28,0x5e,0x5f,0xc3,0x33,0xc0,0x48,0x83,0xc4,0x28,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> IsVectorizedヽᐤMethodInfoㆍW256ㆍGenericStateᐤ  =>  new byte[62]{0x57,0x56,0x48,0x83,0xec,0x28,0x48,0x89,0x54,0x24,0x48,0x48,0x8b,0xf1,0x41,0x8b,0xf8,0x48,0x8b,0xce,0x48,0x0f,0xbe,0x54,0x24,0x48,0xe8,0x51,0xfa,0xff,0xff,0x85,0xc0,0x74,0x12,0x48,0x8b,0xce,0x8b,0xd7,0xe8,0xd3,0x4e,0x2c,0xff,0x90,0x48,0x83,0xc4,0x28,0x5e,0x5f,0xc3,0x33,0xc0,0x48,0x83,0xc4,0x28,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> IsVectorizedヽᐤMethodInfoㆍW512ㆍGenericStateᐤ  =>  new byte[72]{0x57,0x56,0x48,0x83,0xec,0x28,0x48,0x89,0x54,0x24,0x48,0x48,0x8b,0xf1,0x41,0x8b,0xf8,0x48,0x0f,0xbe,0x4c,0x24,0x48,0x88,0x4c,0x24,0x20,0x48,0x8b,0xce,0x48,0x0f,0xbe,0x54,0x24,0x20,0xe8,0xe7,0xfa,0xff,0xff,0x84,0xc0,0x74,0x12,0x48,0x8b,0xce,0x8b,0xd7,0xe8,0x69,0x4e,0x2c,0xff,0x90,0x48,0x83,0xc4,0x28,0x5e,0x5f,0xc3,0x33,0xc0,0x48,0x83,0xc4,0x28,0x5e,0x5f,0xc3};

    }
}
