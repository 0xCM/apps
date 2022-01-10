﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2022-01-07 15:36:30 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class lib_cspatterns
    {
        public static ReadOnlySpan<byte> Termヽᐤᐤ  =>  new byte[19]{0x0f,0x1f,0x44,0x00,0x00,0x48,0xb8,0x10,0x58,0x3d,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x00,0xc3};

        public static ReadOnlySpan<byte> Emptyヽᐤᐤ  =>  new byte[19]{0x0f,0x1f,0x44,0x00,0x00,0x48,0xb8,0x60,0x30,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x00,0xc3};

        public static ReadOnlySpan<byte> Openヽᐤᐤ  =>  new byte[19]{0x0f,0x1f,0x44,0x00,0x00,0x48,0xb8,0x58,0x36,0x3d,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x00,0xc3};

        public static ReadOnlySpan<byte> Closeヽᐤᐤ  =>  new byte[19]{0x0f,0x1f,0x44,0x00,0x00,0x48,0xb8,0x98,0x9b,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x00,0xc3};

        public static ReadOnlySpan<byte> PublicClassヽᐤᐤ  =>  new byte[19]{0x0f,0x1f,0x44,0x00,0x00,0x48,0xb8,0x88,0x60,0x3d,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x00,0xc3};

        public static ReadOnlySpan<byte> Readonlyヽᐤᐤ  =>  new byte[19]{0x0f,0x1f,0x44,0x00,0x00,0x48,0xb8,0x90,0x60,0x3d,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x00,0xc3};

        public static ReadOnlySpan<byte> UsingNsヽᐤstringᐤ  =>  new byte[96]{0x48,0x83,0xec,0x48,0x33,0xc0,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x48,0x89,0x44,0x24,0x38,0x48,0x89,0x44,0x24,0x40,0x45,0x33,0xc0,0x48,0xba,0x88,0x13,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0xb8,0x98,0x60,0x3d,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x00,0x4c,0x8d,0x4c,0x24,0x28,0x49,0x89,0x09,0x4d,0x89,0x41,0x08,0x4d,0x89,0x41,0x10,0x49,0x89,0x51,0x18,0x4c,0x8d,0x44,0x24,0x28,0x48,0x8b,0xd0,0x33,0xc9,0xe8,0x96,0x06,0x7f,0x58,0x90,0x48,0x83,0xc4,0x48,0xc3};

        public static ReadOnlySpan<byte> UsingTypeヽᐤstringᐤ  =>  new byte[96]{0x48,0x83,0xec,0x48,0x33,0xc0,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x48,0x89,0x44,0x24,0x38,0x48,0x89,0x44,0x24,0x40,0x45,0x33,0xc0,0x48,0xba,0x88,0x13,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0xb8,0xa0,0x60,0x3d,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x00,0x4c,0x8d,0x4c,0x24,0x28,0x49,0x89,0x09,0x4d,0x89,0x41,0x08,0x4d,0x89,0x41,0x10,0x49,0x89,0x51,0x18,0x4c,0x8d,0x44,0x24,0x28,0x48,0x8b,0xd0,0x33,0xc9,0xe8,0x16,0x06,0x7f,0x58,0x90,0x48,0x83,0xc4,0x48,0xc3};

        public static ReadOnlySpan<byte> NamespaceDeclヽᐤstringᐤ  =>  new byte[96]{0x48,0x83,0xec,0x48,0x33,0xc0,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x48,0x89,0x44,0x24,0x38,0x48,0x89,0x44,0x24,0x40,0x45,0x33,0xc0,0x48,0xba,0x88,0x13,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0xb8,0x50,0x36,0x3d,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x00,0x4c,0x8d,0x4c,0x24,0x28,0x49,0x89,0x09,0x4d,0x89,0x41,0x08,0x4d,0x89,0x41,0x10,0x49,0x89,0x51,0x18,0x4c,0x8d,0x44,0x24,0x28,0x48,0x8b,0xd0,0x33,0xc9,0xe8,0x96,0x05,0x7f,0x58,0x90,0x48,0x83,0xc4,0x48,0xc3};

        public static ReadOnlySpan<byte> Structヽᐤstringᐤ  =>  new byte[31]{0x48,0x8b,0xd1,0x66,0x90,0x48,0xb9,0xa8,0x60,0x3d,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x09,0x48,0xb8,0x30,0x9d,0xba,0xc0,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> ReadonlyStructヽᐤᐤ  =>  new byte[19]{0x0f,0x1f,0x44,0x00,0x00,0x48,0xb8,0xb0,0x60,0x3d,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x00,0xc3};

        public static ReadOnlySpan<byte> ReadonlyStructヽᐤstringᐤ  =>  new byte[66]{0x56,0x48,0x83,0xec,0x20,0x48,0x8b,0xd1,0x48,0xb9,0xb8,0x60,0x3d,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x31,0x48,0xb9,0xa8,0x60,0x3d,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x09,0xe8,0x79,0x3f,0x7e,0x58,0x48,0x8b,0xd0,0x48,0x8b,0xce,0x48,0xb8,0x30,0x9d,0xba,0xc0,0xfb,0x7f,0x00,0x00,0x48,0x83,0xc4,0x20,0x5e,0x48,0xff,0xe0,0x00,0x19,0x05};

        public static ReadOnlySpan<byte> PublicReadonlyStructヽᐤstringᐤ  =>  new byte[98]{0x57,0x56,0x48,0x83,0xec,0x28,0x48,0x8b,0xd1,0x48,0xb9,0xc0,0x60,0x3d,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x31,0x48,0xb9,0xb8,0x60,0x3d,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x39,0x48,0xb9,0xa8,0x60,0x3d,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x09,0xe8,0x0b,0x3f,0x7e,0x58,0x48,0x8b,0xd0,0x48,0x8b,0xcf,0xe8,0x00,0x3f,0x7e,0x58,0x48,0x8b,0xd0,0x48,0x8b,0xce,0x48,0xb8,0x30,0x9d,0xba,0xc0,0xfb,0x7f,0x00,0x00,0x48,0x83,0xc4,0x28,0x5e,0x5f,0x48,0xff,0xe0,0x00,0x00,0x00,0x19,0x06,0x03,0x00,0x06,0x42};

        public static ReadOnlySpan<byte> InlineAttribヽᐤᐤ  =>  new byte[19]{0x0f,0x1f,0x44,0x00,0x00,0x48,0xb8,0xc8,0x60,0x3d,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x00,0xc3};

        public static ReadOnlySpan<byte> InlineOpAttribヽᐤᐤ  =>  new byte[19]{0x0f,0x1f,0x44,0x00,0x00,0x48,0xb8,0xd0,0x60,0x3d,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x00,0xc3};

        public static ReadOnlySpan<byte> ApiCompleteAttribヽᐤᐤ  =>  new byte[19]{0x0f,0x1f,0x44,0x00,0x00,0x48,0xb8,0xd8,0x60,0x3d,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x00,0xc3};

        public static ReadOnlySpan<byte> UsingCompilerServicesヽᐤᐤ  =>  new byte[19]{0x0f,0x1f,0x44,0x00,0x00,0x48,0xb8,0x60,0x36,0x3d,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x00,0xc3};

        public static ReadOnlySpan<byte> Constantヽᐤstringㆍ8uᐤ  =>  new byte[124]{0x57,0x56,0x48,0x83,0xec,0x48,0x33,0xc0,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x48,0x89,0x44,0x24,0x38,0x48,0x89,0x44,0x24,0x40,0x48,0x8b,0xf1,0x8b,0xfa,0x48,0xb9,0x60,0x77,0x12,0x65,0xfb,0x7f,0x00,0x00,0xe8,0xe0,0x18,0x8d,0x5c,0x40,0x88,0x78,0x08,0x45,0x33,0xc0,0x48,0xba,0x90,0x13,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0xb9,0xe0,0x60,0x3d,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x09,0x4c,0x8d,0x4c,0x24,0x28,0x49,0x89,0x31,0x49,0x89,0x41,0x08,0x4d,0x89,0x41,0x10,0x49,0x89,0x51,0x18,0x4c,0x8d,0x44,0x24,0x28,0x48,0x8b,0xd1,0x33,0xc9,0xe8,0xfc,0x02,0x7f,0x58,0x90,0x48,0x83,0xc4,0x48,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> Constantヽᐤstringㆍ8iᐤ  =>  new byte[124]{0x57,0x56,0x48,0x83,0xec,0x48,0x33,0xc0,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x48,0x89,0x44,0x24,0x38,0x48,0x89,0x44,0x24,0x40,0x48,0x8b,0xf1,0x8b,0xfa,0x48,0xb9,0x70,0x6f,0x12,0x65,0xfb,0x7f,0x00,0x00,0xe8,0x40,0x18,0x8d,0x5c,0x40,0x88,0x78,0x08,0x45,0x33,0xc0,0x48,0xba,0x90,0x13,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0xb9,0xe8,0x60,0x3d,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x09,0x4c,0x8d,0x4c,0x24,0x28,0x49,0x89,0x31,0x49,0x89,0x41,0x08,0x4d,0x89,0x41,0x10,0x49,0x89,0x51,0x18,0x4c,0x8d,0x44,0x24,0x28,0x48,0x8b,0xd1,0x33,0xc9,0xe8,0x5c,0x02,0x7f,0x58,0x90,0x48,0x83,0xc4,0x48,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> Constantヽᐤstringㆍ16iᐤ  =>  new byte[124]{0x57,0x56,0x48,0x83,0xec,0x48,0x33,0xc0,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x48,0x89,0x44,0x24,0x38,0x48,0x89,0x44,0x24,0x40,0x48,0x8b,0xf1,0x8b,0xfa,0x48,0xb9,0x50,0x7f,0x12,0x65,0xfb,0x7f,0x00,0x00,0xe8,0xa0,0x17,0x8d,0x5c,0x66,0x89,0x78,0x08,0x45,0x33,0xc0,0x48,0xba,0x90,0x13,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0xb9,0xf0,0x60,0x3d,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x09,0x4c,0x8d,0x4c,0x24,0x28,0x49,0x89,0x31,0x49,0x89,0x41,0x08,0x4d,0x89,0x41,0x10,0x49,0x89,0x51,0x18,0x4c,0x8d,0x44,0x24,0x28,0x48,0x8b,0xd1,0x33,0xc9,0xe8,0xbc,0x01,0x7f,0x58,0x90,0x48,0x83,0xc4,0x48,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> Constantヽᐤstringㆍ16uᐤ  =>  new byte[124]{0x57,0x56,0x48,0x83,0xec,0x48,0x33,0xc0,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x48,0x89,0x44,0x24,0x38,0x48,0x89,0x44,0x24,0x40,0x48,0x8b,0xf1,0x8b,0xfa,0x48,0xb9,0x40,0x87,0x12,0x65,0xfb,0x7f,0x00,0x00,0xe8,0x00,0x17,0x8d,0x5c,0x66,0x89,0x78,0x08,0x45,0x33,0xc0,0x48,0xba,0x90,0x13,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0xb9,0xf8,0x60,0x3d,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x09,0x4c,0x8d,0x4c,0x24,0x28,0x49,0x89,0x31,0x49,0x89,0x41,0x08,0x4d,0x89,0x41,0x10,0x49,0x89,0x51,0x18,0x4c,0x8d,0x44,0x24,0x28,0x48,0x8b,0xd1,0x33,0xc9,0xe8,0x1c,0x01,0x7f,0x58,0x90,0x48,0x83,0xc4,0x48,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> Constantヽᐤstringㆍ32iᐤ  =>  new byte[123]{0x57,0x56,0x48,0x83,0xec,0x48,0x33,0xc0,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x48,0x89,0x44,0x24,0x38,0x48,0x89,0x44,0x24,0x40,0x48,0x8b,0xf1,0x8b,0xfa,0x48,0xb9,0x10,0x8f,0x12,0x65,0xfb,0x7f,0x00,0x00,0xe8,0x60,0x16,0x8d,0x5c,0x89,0x78,0x08,0x45,0x33,0xc0,0x48,0xba,0x90,0x13,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0xb9,0x00,0x61,0x3d,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x09,0x4c,0x8d,0x4c,0x24,0x28,0x49,0x89,0x31,0x49,0x89,0x41,0x08,0x4d,0x89,0x41,0x10,0x49,0x89,0x51,0x18,0x4c,0x8d,0x44,0x24,0x28,0x48,0x8b,0xd1,0x33,0xc9,0xe8,0x7d,0x00,0x7f,0x58,0x90,0x48,0x83,0xc4,0x48,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> Constantヽᐤstringㆍ32uᐤ  =>  new byte[123]{0x57,0x56,0x48,0x83,0xec,0x48,0x33,0xc0,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x48,0x89,0x44,0x24,0x38,0x48,0x89,0x44,0x24,0x40,0x48,0x8b,0xf1,0x8b,0xfa,0x48,0xb9,0xe0,0x96,0x12,0x65,0xfb,0x7f,0x00,0x00,0xe8,0xc0,0x15,0x8d,0x5c,0x89,0x78,0x08,0x45,0x33,0xc0,0x48,0xba,0x90,0x13,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0xb9,0x08,0x61,0x3d,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x09,0x4c,0x8d,0x4c,0x24,0x28,0x49,0x89,0x31,0x49,0x89,0x41,0x08,0x4d,0x89,0x41,0x10,0x49,0x89,0x51,0x18,0x4c,0x8d,0x44,0x24,0x28,0x48,0x8b,0xd1,0x33,0xc9,0xe8,0xdd,0xff,0x7e,0x58,0x90,0x48,0x83,0xc4,0x48,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> Constantヽᐤstringㆍ64iᐤ  =>  new byte[125]{0x57,0x56,0x48,0x83,0xec,0x48,0x33,0xc0,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x48,0x89,0x44,0x24,0x38,0x48,0x89,0x44,0x24,0x40,0x48,0x8b,0xf1,0x48,0x8b,0xfa,0x48,0xb9,0xb0,0x9e,0x12,0x65,0xfb,0x7f,0x00,0x00,0xe8,0x1f,0x15,0x8d,0x5c,0x48,0x89,0x78,0x08,0x45,0x33,0xc0,0x48,0xba,0x90,0x13,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0xb9,0x10,0x61,0x3d,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x09,0x4c,0x8d,0x4c,0x24,0x28,0x49,0x89,0x31,0x49,0x89,0x41,0x08,0x4d,0x89,0x41,0x10,0x49,0x89,0x51,0x18,0x4c,0x8d,0x44,0x24,0x28,0x48,0x8b,0xd1,0x33,0xc9,0xe8,0x3b,0xff,0x7e,0x58,0x90,0x48,0x83,0xc4,0x48,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> Constantヽᐤstringㆍ64uᐤ  =>  new byte[125]{0x57,0x56,0x48,0x83,0xec,0x48,0x33,0xc0,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x48,0x89,0x44,0x24,0x38,0x48,0x89,0x44,0x24,0x40,0x48,0x8b,0xf1,0x48,0x8b,0xfa,0x48,0xb9,0x80,0xa6,0x12,0x65,0xfb,0x7f,0x00,0x00,0xe8,0x7f,0x14,0x8d,0x5c,0x48,0x89,0x78,0x08,0x45,0x33,0xc0,0x48,0xba,0x90,0x13,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0xb9,0x18,0x61,0x3d,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x09,0x4c,0x8d,0x4c,0x24,0x28,0x49,0x89,0x31,0x49,0x89,0x41,0x08,0x4d,0x89,0x41,0x10,0x49,0x89,0x51,0x18,0x4c,0x8d,0x44,0x24,0x28,0x48,0x8b,0xd1,0x33,0xc9,0xe8,0x9b,0xfe,0x7e,0x58,0x90,0x48,0x83,0xc4,0x48,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> Constantヽᐤstringㆍstringᐤ  =>  new byte[96]{0x48,0x83,0xec,0x48,0x33,0xc0,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x48,0x89,0x44,0x24,0x38,0x48,0x89,0x44,0x24,0x40,0x45,0x33,0xc0,0x48,0xb8,0x90,0x13,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x00,0x49,0xb9,0x20,0x61,0x3d,0x61,0xa1,0x02,0x00,0x00,0x4d,0x8b,0x09,0x4c,0x8d,0x54,0x24,0x28,0x49,0x89,0x0a,0x49,0x89,0x52,0x08,0x4d,0x89,0x42,0x10,0x49,0x89,0x42,0x18,0x4c,0x8d,0x44,0x24,0x28,0x49,0x8b,0xd1,0x33,0xc9,0xe8,0x16,0xfe,0x7e,0x58,0x90,0x48,0x83,0xc4,0x48,0xc3};

        public static ReadOnlySpan<byte> Constantヽᐤstringㆍcharᐤ  =>  new byte[124]{0x57,0x56,0x48,0x83,0xec,0x48,0x33,0xc0,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x48,0x89,0x44,0x24,0x38,0x48,0x89,0x44,0x24,0x40,0x48,0x8b,0xf1,0x8b,0xfa,0x48,0xb9,0x18,0x67,0x12,0x65,0xfb,0x7f,0x00,0x00,0xe8,0x60,0x13,0x8d,0x5c,0x66,0x89,0x78,0x08,0x45,0x33,0xc0,0x48,0xba,0x90,0x13,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0xb9,0x28,0x61,0x3d,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x09,0x4c,0x8d,0x4c,0x24,0x28,0x49,0x89,0x31,0x49,0x89,0x41,0x08,0x4d,0x89,0x41,0x10,0x49,0x89,0x51,0x18,0x4c,0x8d,0x44,0x24,0x28,0x48,0x8b,0xd1,0x33,0xc9,0xe8,0x7c,0xfd,0x7e,0x58,0x90,0x48,0x83,0xc4,0x48,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> ConstantヽᐤstringㆍEnumᐤ  =>  new byte[118]{0x57,0x56,0x48,0x83,0xec,0x48,0x33,0xc0,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x48,0x89,0x44,0x24,0x38,0x48,0x89,0x44,0x24,0x40,0x48,0x8b,0xf9,0x48,0x8b,0xf2,0x48,0x8b,0xce,0xe8,0xa6,0xba,0x86,0x5c,0x48,0x8b,0xc8,0x33,0xd2,0xe8,0x0c,0x71,0x7e,0x58,0x49,0xb8,0x98,0x13,0x28,0x61,0xa1,0x02,0x00,0x00,0x4d,0x8b,0x00,0x48,0xba,0x30,0x61,0x3d,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x8d,0x4c,0x24,0x28,0x48,0x89,0x01,0x48,0x89,0x79,0x08,0x48,0x89,0x71,0x10,0x4c,0x89,0x41,0x18,0x4c,0x8d,0x44,0x24,0x28,0x33,0xc9,0xe8,0xe2,0xfc,0x7e,0x58,0x90,0x48,0x83,0xc4,0x48,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> StaticLambdaPropヽᐤstringㆍstringㆍstringᐤ  =>  new byte[93]{0x48,0x83,0xec,0x48,0x33,0xc0,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x48,0x89,0x44,0x24,0x38,0x48,0x89,0x44,0x24,0x40,0x48,0xb8,0x98,0x13,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x00,0x49,0xb9,0x38,0x61,0x3d,0x61,0xa1,0x02,0x00,0x00,0x4d,0x8b,0x09,0x4c,0x8d,0x54,0x24,0x28,0x49,0x89,0x0a,0x49,0x89,0x52,0x08,0x4d,0x89,0x42,0x10,0x49,0x89,0x42,0x18,0x4c,0x8d,0x44,0x24,0x28,0x49,0x8b,0xd1,0x33,0xc9,0xe8,0x69,0xfc,0x7e,0x58,0x90,0x48,0x83,0xc4,0x48,0xc3};

        public static ReadOnlySpan<byte> EnumDeclヽᐤstringㆍstringᐤ  =>  new byte[96]{0x48,0x83,0xec,0x48,0x33,0xc0,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x48,0x89,0x44,0x24,0x38,0x48,0x89,0x44,0x24,0x40,0x45,0x33,0xc0,0x48,0xb8,0x90,0x13,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x00,0x49,0xb9,0x40,0x61,0x3d,0x61,0xa1,0x02,0x00,0x00,0x4d,0x8b,0x09,0x4c,0x8d,0x54,0x24,0x28,0x49,0x89,0x0a,0x49,0x89,0x52,0x08,0x4d,0x89,0x42,0x10,0x49,0x89,0x42,0x18,0x4c,0x8d,0x44,0x24,0x28,0x49,0x8b,0xd1,0x33,0xc9,0xe8,0xe6,0xfb,0x7e,0x58,0x90,0x48,0x83,0xc4,0x48,0xc3};

        public static ReadOnlySpan<byte> PublicOneLineFuncヽᐤstringㆍstringㆍstringㆍstringᐤ  =>  new byte[611]{0x41,0x56,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x20,0x48,0x8b,0xf1,0x48,0x8b,0xfa,0x49,0x8b,0xd8,0x49,0x8b,0xe9,0x48,0xb9,0xc8,0x52,0x12,0x65,0xfb,0x7f,0x00,0x00,0xba,0x04,0x00,0x00,0x00,0xe8,0xc6,0x12,0x8d,0x5c,0x4c,0x8b,0xf0,0x49,0x8b,0xce,0x4c,0x8b,0xc6,0x33,0xd2,0xe8,0x86,0x03,0x8d,0x5c,0x49,0x8b,0xce,0x4c,0x8b,0xc7,0xba,0x01,0x00,0x00,0x00,0xe8,0x76,0x03,0x8d,0x5c,0x49,0x8b,0xce,0x4c,0x8b,0xc3,0xba,0x02,0x00,0x00,0x00,0xe8,0x66,0x03,0x8d,0x5c,0x49,0x8b,0xce,0x4c,0x8b,0xc5,0xba,0x03,0x00,0x00,0x00,0xe8,0x56,0x03,0x8d,0x5c,0x48,0xb9,0x48,0x61,0x3d,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x09,0x49,0x8b,0xd6,0x48,0xb8,0xf0,0xd6,0xbe,0xc0,0xfb,0x7f,0x00,0x00,0x48,0x83,0xc4,0x20,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0x48,0xff,0xe0,0x00,0x00,0x00,0x19,0x0a,0x06,0x00,0x0a,0x32,0x06,0x30,0x05,0x50,0x04,0x60,0x03,0x70,0x02,0xe0,0x40,0x00,0x00,0x00,0x10,0xcb,0x5c,0x68,0xfb,0x7f,0x00,0x00,0x41,0x56,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x20,0x48,0x8b,0xf1,0x48,0x8b,0xfa,0x49,0x8b,0xd8,0x49,0x8b,0xe9,0x48,0xb9,0xc8,0x52,0x12,0x65,0xfb,0x7f,0x00,0x00,0xba,0x04,0x00,0x00,0x00,0xe8,0x16,0x12,0x8d,0x5c,0x4c,0x8b,0xf0,0x49,0x8b,0xce,0x4c,0x8b,0xc6,0x33,0xd2,0xe8,0xd6,0x02,0x8d,0x5c,0x49,0x8b,0xce,0x4c,0x8b,0xc7,0xba,0x01,0x00,0x00,0x00,0xe8,0xc6,0x02,0x8d,0x5c,0x49,0x8b,0xce,0x4c,0x8b,0xc3,0xba,0x02,0x00,0x00,0x00,0xe8,0xb6,0x02,0x8d,0x5c,0x49,0x8b,0xce,0x4c,0x8b,0xc5,0xba,0x03,0x00,0x00,0x00,0xe8,0xa6,0x02,0x8d,0x5c,0x48,0xb9,0x50,0x61,0x3d,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x09,0x49,0x8b,0xd6,0x48,0xb8,0xf0,0xd6,0xbe,0xc0,0xfb,0x7f,0x00,0x00,0x48,0x83,0xc4,0x20,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0x48,0xff,0xe0,0x00,0x00,0x00,0x19,0x0a,0x06,0x00,0x0a,0x32,0x06,0x30,0x05,0x50,0x04,0x60,0x03,0x70,0x02,0xe0,0x40,0x00,0x00,0x00,0x18,0xcf,0x5c,0x68,0xfb,0x7f,0x00,0x00,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x68,0xc5,0xf8,0x77,0x48,0x8b,0xf1,0x48,0x8d,0x7c,0x24,0x28,0xb9,0x10,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x48,0x8b,0xd9,0x48,0x8d,0x4c,0x24,0x48,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x01,0xc5,0xfa,0x7f,0x41,0x10,0x48,0x89,0x54,0x24,0x58,0x66,0xc7,0x44,0x24,0x54,0x2c,0x00,0x48,0xb9,0x60,0xfe,0x3a,0x68,0xfb,0x7f,0x00,0x00,0xe8,0xb1,0x0f,0x8d,0x5c,0x48,0x8b,0xf0,0x48,0x8d,0x4e,0x08,0x48,0x8b,0xd6,0xe8,0xe2,0x00,0x8d,0x5c,0x48,0xb9,0xd0,0xf6,0x02,0x65,0xfb,0x7f,0x00,0x00,0x48,0x89,0x4e,0x18,0x48,0xb9,0x88,0x4e,0x3c,0x68,0xfb,0x7f,0x00,0x00,0x48,0x89,0x4e,0x20,0x48,0x89,0x74,0x24,0x48,0x33,0xc9,0x89,0x4c,0x24,0x50,0x48,0x8d,0x44,0x24,0x60,0x89,0x08,0x66,0x89,0x48,0x04,0x48,0xb9,0xe8,0x6a,0x06,0x68,0xfb,0x7f,0x00,0x00,0xe8,0x61,0x0f,0x8d,0x5c,0x48,0x8b,0xe8,0x48,0x8d,0x7d,0x08,0x48,0x8d,0x74,0x24,0x48,0xe8,0x30,0x01,0x8d,0x5c,0x48,0xa5,0xe8,0x29,0x01,0x8d,0x5c,0x48,0xa5,0x45,0x33,0xc0,0x48,0xba,0x90,0x13,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0xb9,0x58,0x61,0x3d,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x09,0x48,0x8d,0x44,0x24,0x28,0x48,0x89,0x18,0x48,0x89,0x68,0x08,0x4c,0x89,0x40,0x10,0x48,0x89,0x50,0x18,0x4c,0x8d,0x44,0x24,0x28,0x48,0x8b,0xd1,0x33,0xc9,0xe8,0x67,0xf9,0x7e,0x58,0x90,0x48,0x83,0xc4,0x68,0x5b,0x5d,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> PublicStaticOneLineFuncヽᐤstringㆍstringㆍstringㆍstringᐤ  =>  new byte[435]{0x41,0x56,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x20,0x48,0x8b,0xf1,0x48,0x8b,0xfa,0x49,0x8b,0xd8,0x49,0x8b,0xe9,0x48,0xb9,0xc8,0x52,0x12,0x65,0xfb,0x7f,0x00,0x00,0xba,0x04,0x00,0x00,0x00,0xe8,0x16,0x12,0x8d,0x5c,0x4c,0x8b,0xf0,0x49,0x8b,0xce,0x4c,0x8b,0xc6,0x33,0xd2,0xe8,0xd6,0x02,0x8d,0x5c,0x49,0x8b,0xce,0x4c,0x8b,0xc7,0xba,0x01,0x00,0x00,0x00,0xe8,0xc6,0x02,0x8d,0x5c,0x49,0x8b,0xce,0x4c,0x8b,0xc3,0xba,0x02,0x00,0x00,0x00,0xe8,0xb6,0x02,0x8d,0x5c,0x49,0x8b,0xce,0x4c,0x8b,0xc5,0xba,0x03,0x00,0x00,0x00,0xe8,0xa6,0x02,0x8d,0x5c,0x48,0xb9,0x50,0x61,0x3d,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x09,0x49,0x8b,0xd6,0x48,0xb8,0xf0,0xd6,0xbe,0xc0,0xfb,0x7f,0x00,0x00,0x48,0x83,0xc4,0x20,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0x48,0xff,0xe0,0x00,0x00,0x00,0x19,0x0a,0x06,0x00,0x0a,0x32,0x06,0x30,0x05,0x50,0x04,0x60,0x03,0x70,0x02,0xe0,0x40,0x00,0x00,0x00,0x18,0xcf,0x5c,0x68,0xfb,0x7f,0x00,0x00,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x68,0xc5,0xf8,0x77,0x48,0x8b,0xf1,0x48,0x8d,0x7c,0x24,0x28,0xb9,0x10,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x48,0x8b,0xd9,0x48,0x8d,0x4c,0x24,0x48,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x01,0xc5,0xfa,0x7f,0x41,0x10,0x48,0x89,0x54,0x24,0x58,0x66,0xc7,0x44,0x24,0x54,0x2c,0x00,0x48,0xb9,0x60,0xfe,0x3a,0x68,0xfb,0x7f,0x00,0x00,0xe8,0xb1,0x0f,0x8d,0x5c,0x48,0x8b,0xf0,0x48,0x8d,0x4e,0x08,0x48,0x8b,0xd6,0xe8,0xe2,0x00,0x8d,0x5c,0x48,0xb9,0xd0,0xf6,0x02,0x65,0xfb,0x7f,0x00,0x00,0x48,0x89,0x4e,0x18,0x48,0xb9,0x88,0x4e,0x3c,0x68,0xfb,0x7f,0x00,0x00,0x48,0x89,0x4e,0x20,0x48,0x89,0x74,0x24,0x48,0x33,0xc9,0x89,0x4c,0x24,0x50,0x48,0x8d,0x44,0x24,0x60,0x89,0x08,0x66,0x89,0x48,0x04,0x48,0xb9,0xe8,0x6a,0x06,0x68,0xfb,0x7f,0x00,0x00,0xe8,0x61,0x0f,0x8d,0x5c,0x48,0x8b,0xe8,0x48,0x8d,0x7d,0x08,0x48,0x8d,0x74,0x24,0x48,0xe8,0x30,0x01,0x8d,0x5c,0x48,0xa5,0xe8,0x29,0x01,0x8d,0x5c,0x48,0xa5,0x45,0x33,0xc0,0x48,0xba,0x90,0x13,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0xb9,0x58,0x61,0x3d,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x09,0x48,0x8d,0x44,0x24,0x28,0x48,0x89,0x18,0x48,0x89,0x68,0x08,0x4c,0x89,0x40,0x10,0x48,0x89,0x50,0x18,0x4c,0x8d,0x44,0x24,0x28,0x48,0x8b,0xd1,0x33,0xc9,0xe8,0x67,0xf9,0x7e,0x58,0x90,0x48,0x83,0xc4,0x68,0x5b,0x5d,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> Callヽᐤstringㆍarray_dynamicᐤ  =>  new byte[259]{0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x68,0xc5,0xf8,0x77,0x48,0x8b,0xf1,0x48,0x8d,0x7c,0x24,0x28,0xb9,0x10,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x48,0x8b,0xd9,0x48,0x8d,0x4c,0x24,0x48,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x01,0xc5,0xfa,0x7f,0x41,0x10,0x48,0x89,0x54,0x24,0x58,0x66,0xc7,0x44,0x24,0x54,0x2c,0x00,0x48,0xb9,0x60,0xfe,0x3a,0x68,0xfb,0x7f,0x00,0x00,0xe8,0xb1,0x0f,0x8d,0x5c,0x48,0x8b,0xf0,0x48,0x8d,0x4e,0x08,0x48,0x8b,0xd6,0xe8,0xe2,0x00,0x8d,0x5c,0x48,0xb9,0xd0,0xf6,0x02,0x65,0xfb,0x7f,0x00,0x00,0x48,0x89,0x4e,0x18,0x48,0xb9,0x88,0x4e,0x3c,0x68,0xfb,0x7f,0x00,0x00,0x48,0x89,0x4e,0x20,0x48,0x89,0x74,0x24,0x48,0x33,0xc9,0x89,0x4c,0x24,0x50,0x48,0x8d,0x44,0x24,0x60,0x89,0x08,0x66,0x89,0x48,0x04,0x48,0xb9,0xe8,0x6a,0x06,0x68,0xfb,0x7f,0x00,0x00,0xe8,0x61,0x0f,0x8d,0x5c,0x48,0x8b,0xe8,0x48,0x8d,0x7d,0x08,0x48,0x8d,0x74,0x24,0x48,0xe8,0x30,0x01,0x8d,0x5c,0x48,0xa5,0xe8,0x29,0x01,0x8d,0x5c,0x48,0xa5,0x45,0x33,0xc0,0x48,0xba,0x90,0x13,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0xb9,0x58,0x61,0x3d,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x09,0x48,0x8d,0x44,0x24,0x28,0x48,0x89,0x18,0x48,0x89,0x68,0x08,0x4c,0x89,0x40,0x10,0x48,0x89,0x50,0x18,0x4c,0x8d,0x44,0x24,0x28,0x48,0x8b,0xd1,0x33,0xc9,0xe8,0x67,0xf9,0x7e,0x58,0x90,0x48,0x83,0xc4,0x68,0x5b,0x5d,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> get_ReadOnlySpanTypePatternヽᐤᐤ  =>  new byte[19]{0x0f,0x1f,0x44,0x00,0x00,0x48,0xb8,0xf8,0x57,0x3d,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x00,0xc3};

        public static ReadOnlySpan<byte> get_ExpressionBodyヽᐤᐤ  =>  new byte[19]{0x0f,0x1f,0x44,0x00,0x00,0x48,0xb8,0xc0,0x5e,0x3d,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x00,0xc3};

    }
}