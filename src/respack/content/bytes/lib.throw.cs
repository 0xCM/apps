﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2021-12-01 21:34:43 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class lib_throw
    {
        public static ReadOnlySpan<byte> originヽᐤstringㆍstringㆍintᐤ  =>  new byte[142]{0x57,0x56,0x48,0x83,0xec,0x18,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x04,0x24,0x48,0x89,0x44,0x24,0x08,0x4c,0x89,0x4c,0x24,0x48,0x48,0x8b,0xf1,0x48,0x8d,0x4c,0x24,0x48,0x0f,0xb6,0x01,0x8b,0x79,0x04,0x33,0xc9,0x48,0x8d,0x04,0x24,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x00,0x48,0x89,0x48,0x10,0x48,0x89,0x14,0x24,0x48,0x8d,0x14,0x24,0x4d,0x85,0xc0,0x75,0x0d,0x49,0xb8,0x60,0x30,0xf4,0x31,0x3a,0x02,0x00,0x00,0x4d,0x8b,0x00,0x48,0x8d,0x4a,0x08,0x49,0x8b,0xd0,0xe8,0x01,0xcf,0xad,0x5b,0x89,0x7c,0x24,0x10,0x48,0x8b,0x14,0x24,0x48,0x8b,0xce,0xe8,0xf1,0xce,0xad,0x5b,0x48,0x8d,0x4e,0x08,0x48,0x8b,0x54,0x24,0x08,0xe8,0xe3,0xce,0xad,0x5b,0x8b,0x44,0x24,0x10,0x89,0x46,0x10,0x48,0x8b,0xc6,0x48,0x83,0xc4,0x18,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> eヽᐤExceptionᐤ  =>  new byte[190]{0x48,0x83,0xec,0x28,0x90,0xe8,0xe6,0x19,0xaa,0x5b,0xcc,0x00,0x19,0x04,0x01,0x00,0x04,0x42,0x00,0x00,0x40,0x00,0x00,0x00,0xa8,0x60,0x6a,0x7b,0xfb,0x7f,0x00,0x00,0x57,0x56,0x48,0x83,0xec,0x58,0xc5,0xf8,0x77,0x48,0x8b,0xf1,0x48,0x8d,0x7c,0x24,0x28,0xb9,0x0c,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x4c,0x89,0x8c,0x24,0x88,0x00,0x00,0x00,0x48,0x8b,0xf1,0x48,0x8d,0x8c,0x24,0x88,0x00,0x00,0x00,0x0f,0xb6,0x01,0x8b,0x79,0x04,0x33,0xc9,0x48,0x8d,0x44,0x24,0x28,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x00,0x48,0x89,0x48,0x10,0x48,0x89,0x54,0x24,0x28,0x48,0x8d,0x54,0x24,0x28,0x4d,0x85,0xc0,0x75,0x0d,0x49,0xb8,0x60,0x30,0xf4,0x31,0x3a,0x02,0x00,0x00,0x4d,0x8b,0x00,0x48,0x8d,0x4a,0x08,0x49,0x8b,0xd0,0xe8,0x1f,0xce,0xad,0x5b,0x89,0x7c,0x24,0x38,0x48,0x8b,0x54,0x24,0x28,0x48,0x89,0x54,0x24,0x40,0x48,0x8b,0x54,0x24,0x30,0x48,0x89,0x54,0x24,0x48,0x8b,0x54,0x24,0x38,0x89,0x54,0x24,0x50,0x48,0x8d,0x54,0x24,0x40,0x48,0x8b,0xce,0xe8,0x1a,0xfa,0x68,0xfd};

        public static ReadOnlySpan<byte> sourcedヽᐤstringㆍstringㆍstringㆍintᐤ  =>  new byte[158]{0x57,0x56,0x48,0x83,0xec,0x58,0xc5,0xf8,0x77,0x48,0x8b,0xf1,0x48,0x8d,0x7c,0x24,0x28,0xb9,0x0c,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x4c,0x89,0x8c,0x24,0x88,0x00,0x00,0x00,0x48,0x8b,0xf1,0x48,0x8d,0x8c,0x24,0x88,0x00,0x00,0x00,0x0f,0xb6,0x01,0x8b,0x79,0x04,0x33,0xc9,0x48,0x8d,0x44,0x24,0x28,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x00,0x48,0x89,0x48,0x10,0x48,0x89,0x54,0x24,0x28,0x48,0x8d,0x54,0x24,0x28,0x4d,0x85,0xc0,0x75,0x0d,0x49,0xb8,0x60,0x30,0xf4,0x31,0x3a,0x02,0x00,0x00,0x4d,0x8b,0x00,0x48,0x8d,0x4a,0x08,0x49,0x8b,0xd0,0xe8,0x1f,0xce,0xad,0x5b,0x89,0x7c,0x24,0x38,0x48,0x8b,0x54,0x24,0x28,0x48,0x89,0x54,0x24,0x40,0x48,0x8b,0x54,0x24,0x30,0x48,0x89,0x54,0x24,0x48,0x8b,0x54,0x24,0x38,0x89,0x54,0x24,0x50,0x48,0x8d,0x54,0x24,0x40,0x48,0x8b,0xce,0xe8,0x1a,0xfa,0x68,0xfd};

        public static ReadOnlySpan<byte> messageヽᐤstringᐤ  =>  new byte[154]{0x57,0x56,0x48,0x83,0xec,0x28,0x48,0x8b,0xf1,0x48,0xb9,0x90,0x03,0x1f,0x77,0xfb,0x7f,0x00,0x00,0xe8,0xa8,0xdc,0xad,0x5b,0x48,0x8b,0xf8,0x48,0x8b,0xcf,0xe8,0xe5,0xb0,0xfa,0xfb,0x48,0x8d,0x4f,0x10,0x48,0x8b,0xd6,0xe8,0xd1,0xcd,0xad,0x5b,0x48,0x8b,0xcf,0xe8,0xd9,0x18,0xaa,0x5b,0xcc,0x19,0x06,0x03,0x00,0x06,0x42,0x02,0x60,0x01,0x70,0x00,0x00,0x40,0x00,0x00,0x00,0x60,0x61,0x6a,0x7b,0xfb,0x7f,0x00,0x00,0x57,0x56,0x48,0x83,0xec,0x28,0x48,0x8b,0xf1,0x48,0xb9,0x90,0x03,0x1f,0x77,0xfb,0x7f,0x00,0x00,0xe8,0x58,0xdc,0xad,0x5b,0x48,0x8b,0xf8,0x48,0x8b,0x4e,0x08,0xff,0x56,0x18,0x48,0x8b,0xf0,0x48,0x8b,0xcf,0xe8,0x8b,0xb0,0xfa,0xfb,0x48,0x8d,0x4f,0x10,0x48,0x8b,0xd6,0xe8,0x77,0xcd,0xad,0x5b,0x48,0x8b,0xcf,0xe8,0x7f,0x18,0xaa,0x5b,0xcc,0x00,0x00,0x19,0x06,0x03,0x00,0x06,0x42};

        public static ReadOnlySpan<byte> messageヽᐤFuncᐸstringᐳᐤ  =>  new byte[74]{0x57,0x56,0x48,0x83,0xec,0x28,0x48,0x8b,0xf1,0x48,0xb9,0x90,0x03,0x1f,0x77,0xfb,0x7f,0x00,0x00,0xe8,0x58,0xdc,0xad,0x5b,0x48,0x8b,0xf8,0x48,0x8b,0x4e,0x08,0xff,0x56,0x18,0x48,0x8b,0xf0,0x48,0x8b,0xcf,0xe8,0x8b,0xb0,0xfa,0xfb,0x48,0x8d,0x4f,0x10,0x48,0x8b,0xd6,0xe8,0x77,0xcd,0xad,0x5b,0x48,0x8b,0xcf,0xe8,0x7f,0x18,0xaa,0x5b,0xcc,0x00,0x00,0x19,0x06,0x03,0x00,0x06,0x42};

        public static ReadOnlySpan<byte> sourcedヽᐤstringㆍAppMsgSourceᕀinᐤ  =>  new byte[122]{0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x28,0x48,0x8b,0xf1,0x48,0x8b,0xfa,0x48,0xb9,0x90,0x03,0x1f,0x77,0xfb,0x7f,0x00,0x00,0xe8,0xf3,0xdb,0xad,0x5b,0x48,0x8b,0xd8,0xb9,0xee,0x3c,0x00,0x00,0x48,0xba,0xd0,0x5f,0x22,0x77,0xfb,0x7f,0x00,0x00,0xe8,0x1c,0x68,0xc0,0x5b,0x48,0x8b,0xe8,0x48,0x8b,0xcf,0xe8,0xf1,0xec,0x68,0xfd,0x4c,0x8b,0xc0,0x48,0x8b,0xcd,0x48,0x8b,0xd6,0xe8,0xbb,0xa4,0xfa,0xfb,0x48,0x8b,0xf0,0x48,0x8b,0xcb,0xe8,0x00,0xb0,0xfa,0xfb,0x48,0x8d,0x4b,0x10,0x48,0x8b,0xd6,0xe8,0xec,0xcc,0xad,0x5b,0x48,0x8b,0xcb,0xe8,0xf4,0x17,0xaa,0x5b,0xcc,0x00,0x00,0x00,0x19,0x08,0x05,0x00,0x08,0x42,0x04,0x30,0x03,0x50};

    }
}
