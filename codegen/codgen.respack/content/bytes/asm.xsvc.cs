﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2022-01-07 15:36:29 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class asm_xsvc
    {
        public static ReadOnlySpan<byte> AsmDecoderヽᐤIWfRuntimeᐤ  =>  new byte[31]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0xd1,0x48,0xb9,0xd0,0x88,0x2f,0x66,0xfb,0x7f,0x00,0x00,0x48,0xb8,0x40,0xf5,0xdf,0x67,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> AsmRowBuilderヽᐤIWfRuntimeᐤ  =>  new byte[31]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0xd1,0x48,0xb9,0x68,0xd0,0x2f,0x66,0xfb,0x7f,0x00,0x00,0x48,0xb8,0x40,0xf5,0xdf,0x67,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> HostAsmEmitterヽᐤIWfRuntimeᐤ  =>  new byte[31]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0xd1,0x48,0xb9,0xc0,0xea,0x2f,0x66,0xfb,0x7f,0x00,0x00,0x48,0xb8,0x40,0xf5,0xdf,0x67,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> ResPackUnpackerヽᐤIWfRuntimeᐤ  =>  new byte[31]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0xd1,0x48,0xb9,0x88,0x7b,0x2f,0x66,0xfb,0x7f,0x00,0x00,0x48,0xb8,0x40,0xf5,0xdf,0x67,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> AsmJmpPipeヽᐤIWfRuntimeᐤ  =>  new byte[31]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0xd1,0x48,0xb9,0x20,0xa2,0x2f,0x66,0xfb,0x7f,0x00,0x00,0x48,0xb8,0x40,0xf5,0xdf,0x67,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> ImmWriterヽᐤIWfRuntimeㆍApiHostUriᕀinᐤ  =>  new byte[269]{0x57,0x56,0x53,0x48,0x81,0xec,0x80,0x00,0x00,0x00,0xc5,0xf8,0x77,0x48,0x8b,0xf1,0x48,0x8d,0x7c,0x24,0x38,0xb9,0x12,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x48,0x8b,0xd9,0x33,0xc9,0x4c,0x8d,0x5c,0x24,0x38,0xc5,0xf8,0x57,0xc0,0xc4,0xc1,0x7a,0x7f,0x03,0xc4,0xc1,0x7a,0x7f,0x43,0x10,0xc4,0xc1,0x7a,0x7f,0x43,0x20,0xc4,0xc1,0x7a,0x7f,0x43,0x30,0x49,0x89,0x4b,0x40,0x4c,0x8d,0x5c,0x24,0x20,0xc5,0xf8,0x57,0xc0,0xc4,0xc1,0x7a,0x7f,0x03,0x49,0x89,0x4b,0x10,0x48,0x89,0x54,0x24,0x38,0xc4,0xc1,0x7a,0x6f,0x00,0xc5,0xfa,0x7f,0x44,0x24,0x48,0x49,0x8b,0x48,0x10,0x48,0x89,0x4c,0x24,0x58,0x48,0x8b,0x4c,0x24,0x38,0x49,0xbb,0xd0,0x10,0x03,0x65,0xfb,0x7f,0x00,0x00,0x48,0xb8,0xd0,0x10,0x03,0x65,0xfb,0x7f,0x00,0x00,0x39,0x09,0xff,0x10,0x48,0x89,0x44,0x24,0x40,0x48,0x8b,0x4c,0x24,0x40,0x49,0xbb,0xd8,0x10,0x03,0x65,0xfb,0x7f,0x00,0x00,0x48,0xb8,0xd8,0x10,0x03,0x65,0xfb,0x7f,0x00,0x00,0x39,0x09,0xff,0x10,0x48,0x89,0x44,0x24,0x60,0x48,0x8d,0x4c,0x24,0x20,0xe8,0xbd,0x4e,0xfa,0xff,0xc5,0xfa,0x6f,0x00,0xc5,0xfa,0x7f,0x44,0x24,0x68,0x48,0x8b,0x50,0x10,0x48,0x89,0x54,0x24,0x78,0x48,0x8b,0xfb,0x48,0x8d,0x74,0x24,0x38,0xe8,0xed,0x22,0xe1,0x5c,0xe8,0xe8,0x22,0xe1,0x5c,0xe8,0xe3,0x22,0xe1,0x5c,0xe8,0xde,0x22,0xe1,0x5c,0x48,0xa5,0xe8,0xd7,0x22,0xe1,0x5c,0x48,0xa5,0x48,0xa5,0x48,0xa5,0x48,0x8b,0xc3,0x48,0x81,0xc4,0x80,0x00,0x00,0x00,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> ImmWriterヽᐤIWfRuntimeㆍApiHostUriᕀinㆍFolderPathᐤ  =>  new byte[272]{0x57,0x56,0x53,0x48,0x81,0xec,0x80,0x00,0x00,0x00,0xc5,0xf8,0x77,0x48,0x8b,0xf1,0x48,0x8d,0x7c,0x24,0x38,0xb9,0x12,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x48,0x8b,0xd9,0x33,0xc9,0x4c,0x8d,0x5c,0x24,0x38,0xc5,0xf8,0x57,0xc0,0xc4,0xc1,0x7a,0x7f,0x03,0xc4,0xc1,0x7a,0x7f,0x43,0x10,0xc4,0xc1,0x7a,0x7f,0x43,0x20,0xc4,0xc1,0x7a,0x7f,0x43,0x30,0x49,0x89,0x4b,0x40,0x4c,0x8d,0x5c,0x24,0x20,0xc5,0xf8,0x57,0xc0,0xc4,0xc1,0x7a,0x7f,0x03,0x49,0x89,0x4b,0x10,0x48,0x89,0x54,0x24,0x38,0xc4,0xc1,0x7a,0x6f,0x00,0xc5,0xfa,0x7f,0x44,0x24,0x48,0x49,0x8b,0x48,0x10,0x48,0x89,0x4c,0x24,0x58,0x48,0x8b,0x4c,0x24,0x38,0x49,0x8b,0xd1,0x49,0xbb,0xe0,0x10,0x03,0x65,0xfb,0x7f,0x00,0x00,0x48,0xb8,0xe0,0x10,0x03,0x65,0xfb,0x7f,0x00,0x00,0x39,0x09,0xff,0x10,0x48,0x89,0x44,0x24,0x40,0x48,0x8b,0x4c,0x24,0x40,0x49,0xbb,0xe8,0x10,0x03,0x65,0xfb,0x7f,0x00,0x00,0x48,0xb8,0xe8,0x10,0x03,0x65,0xfb,0x7f,0x00,0x00,0x39,0x09,0xff,0x10,0x48,0x89,0x44,0x24,0x60,0x48,0x8d,0x4c,0x24,0x20,0xe8,0x8a,0x4d,0xfa,0xff,0xc5,0xfa,0x6f,0x00,0xc5,0xfa,0x7f,0x44,0x24,0x68,0x48,0x8b,0x50,0x10,0x48,0x89,0x54,0x24,0x78,0x48,0x8b,0xfb,0x48,0x8d,0x74,0x24,0x38,0xe8,0xba,0x21,0xe1,0x5c,0xe8,0xb5,0x21,0xe1,0x5c,0xe8,0xb0,0x21,0xe1,0x5c,0xe8,0xab,0x21,0xe1,0x5c,0x48,0xa5,0xe8,0xa4,0x21,0xe1,0x5c,0x48,0xa5,0x48,0xa5,0x48,0xa5,0x48,0x8b,0xc3,0x48,0x81,0xc4,0x80,0x00,0x00,0x00,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> ProcessAsmヽᐤIWfRuntimeᐤ  =>  new byte[31]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0xd1,0x48,0xb9,0xc8,0xf0,0x2f,0x66,0xfb,0x7f,0x00,0x00,0x48,0xb8,0x40,0xf5,0xdf,0x67,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> ApiCodeBlockTraverserヽᐤIWfRuntimeᐤ  =>  new byte[31]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0xd1,0x48,0xb9,0xc0,0x74,0x2f,0x66,0xfb,0x7f,0x00,0x00,0x48,0xb8,0x40,0xf5,0xdf,0x67,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> AsmCallPipeヽᐤIWfRuntimeᐤ  =>  new byte[31]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0xd1,0x48,0xb9,0x78,0x81,0x2f,0x66,0xfb,0x7f,0x00,0x00,0x48,0xb8,0x40,0xf5,0xdf,0x67,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

    }
}