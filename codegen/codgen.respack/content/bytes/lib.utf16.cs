﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2022-01-07 15:36:31 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class lib_utf16
    {
        public static ReadOnlySpan<byte> hashヽᐤutf16pᐤ  =>  new byte[58]{0x48,0x83,0xec,0x28,0x90,0x48,0x8b,0xd1,0x45,0x33,0xc0,0x66,0x83,0x3a,0x00,0x74,0x09,0x49,0xff,0xc0,0x48,0x83,0xc2,0x02,0xeb,0xf1,0x49,0x8b,0xd0,0x48,0x63,0xd2,0x48,0xd1,0xe2,0x41,0xb8,0xb1,0xaa,0xc0,0x69,0x41,0xb9,0xf1,0x5c,0xfc,0x7f,0xe8,0xfc,0xd4,0x2a,0xfd,0x90,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> hashヽᐤutf16ᐤ  =>  new byte[73]{0x48,0x83,0xec,0x28,0x90,0x48,0x85,0xc9,0x75,0x0d,0x48,0xb9,0x60,0x30,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x09,0x48,0x85,0xc9,0x75,0x06,0x33,0xc9,0x33,0xd2,0xeb,0x0a,0x48,0x8d,0x51,0x0c,0x8b,0x49,0x08,0x48,0x87,0xca,0x48,0x63,0xd2,0x48,0xd1,0xe2,0x41,0xb8,0xb1,0xaa,0xc0,0x69,0x41,0xb9,0xf1,0x5c,0xfc,0x7f,0xe8,0x9d,0xd4,0x2a,0xfd,0x90,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> encodingヽᐤᐤ  =>  new byte[19]{0x0f,0x1f,0x44,0x00,0x00,0x48,0xb8,0x00,0x18,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x00,0xc3};

        public static ReadOnlySpan<byte> lengthヽᐤrspan8uᐤ  =>  new byte[81]{0x48,0x83,0xec,0x38,0x33,0xc0,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x48,0xba,0x00,0x18,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x8b,0x01,0x8b,0x49,0x08,0x4c,0x8d,0x44,0x24,0x28,0x49,0x89,0x00,0x41,0x89,0x48,0x08,0x48,0x89,0x54,0x24,0x20,0x48,0x8b,0xca,0x48,0x8d,0x54,0x24,0x28,0x48,0x8b,0x44,0x24,0x20,0x48,0x8b,0x00,0x48,0x8b,0x40,0x60,0xff,0x50,0x08,0x90,0x48,0x83,0xc4,0x38,0xc3};

        public static ReadOnlySpan<byte> encodeヽᐤstringᐤ  =>  new byte[64]{0x56,0x48,0x83,0xec,0x20,0x48,0x8b,0xf1,0x48,0xb9,0x00,0x18,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x09,0x48,0x8b,0x01,0x48,0x8b,0x40,0x58,0xff,0x50,0x10,0x48,0x85,0xc0,0x75,0x06,0x33,0xd2,0x33,0xc9,0xeb,0x07,0x48,0x8d,0x50,0x10,0x8b,0x48,0x08,0x48,0x89,0x16,0x89,0x4e,0x08,0x48,0x8b,0xc6,0x48,0x83,0xc4,0x20,0x5e,0xc3};

        public static ReadOnlySpan<byte> encodeヽᐤarray_charᐤ  =>  new byte[41]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x85,0xd2,0x75,0x07,0x33,0xc0,0x45,0x33,0xc0,0xeb,0x08,0x48,0x8d,0x42,0x10,0x44,0x8b,0x42,0x08,0x49,0x63,0xd0,0x48,0xd1,0xe2,0x48,0x89,0x01,0x89,0x51,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> decodeヽᐤrspan8uㆍstringᕀoutᐤ  =>  new byte[86]{0x56,0x48,0x83,0xec,0x30,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x48,0x8b,0xf2,0x48,0xba,0x00,0x18,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x8b,0x01,0x8b,0x49,0x08,0x4c,0x8d,0x44,0x24,0x20,0x49,0x89,0x00,0x41,0x89,0x48,0x08,0x48,0x8b,0xca,0x48,0x8d,0x54,0x24,0x20,0x39,0x09,0xe8,0x66,0x8f,0x8c,0xfb,0x48,0x8b,0xd0,0x48,0x8b,0xce,0xe8,0x93,0xae,0x40,0x5b,0x48,0x8b,0xc6,0x48,0x83,0xc4,0x30,0x5e,0xc3};

        public static ReadOnlySpan<byte> sizeヽᐤutf16pᐤ  =>  new byte[23]{0x0f,0x1f,0x44,0x00,0x00,0x33,0xc0,0x66,0x83,0x39,0x00,0x74,0x09,0x48,0xff,0xc0,0x48,0x83,0xc1,0x02,0xeb,0xf1,0xc3};

        public static ReadOnlySpan<byte> bytesヽᐤstringᐤ  =>  new byte[37]{0x48,0x83,0xec,0x28,0x90,0x48,0x8b,0xd1,0x48,0xb9,0x00,0x18,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x09,0x48,0x8b,0x01,0x48,0x8b,0x40,0x58,0xff,0x50,0x10,0x90,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> bytesヽᐤarray_charᐤ  =>  new byte[37]{0x48,0x83,0xec,0x28,0x90,0x48,0x8b,0xd1,0x48,0xb9,0x00,0x18,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x09,0x48,0x8b,0x01,0x48,0x8b,0x40,0x50,0xff,0x50,0x38,0x90,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> nonemptyヽᐤutf16pᐤ  =>  new byte[24]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x85,0xc9,0x74,0x0b,0x66,0x83,0x39,0x00,0x0f,0x95,0xc0,0x0f,0xb6,0xc0,0xc3,0x33,0xc0,0xc3};

    }
}