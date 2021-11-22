﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2021-11-14 3:49:57 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class lib_opcodes
    {
        public static ReadOnlySpan<byte> encodeヽᐤLabelㆍDomainㆍHex32ᐤ  =>  new byte[30]{0x0f,0x1f,0x44,0x00,0x00,0x41,0x0f,0xb7,0xc0,0x45,0x8b,0xc1,0x49,0xc1,0xe0,0x10,0x49,0x0b,0xc0,0x48,0x89,0x11,0x48,0x89,0x41,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> codeヽᐤOpCodeᐤ  =>  new byte[14]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x41,0x08,0x48,0xc1,0xe8,0x10,0xc3};

        public static ReadOnlySpan<byte> domainヽᐤOpCodeᐤ  =>  new byte[10]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb7,0x41,0x08,0xc3};

        public static ReadOnlySpan<byte> encodeヽgᐸ8uᐳᐤLabelㆍDomainㆍHex32ᐤ  =>  new byte[41]{0x50,0x0f,0x1f,0x40,0x00,0x41,0x0f,0xb7,0xc0,0x45,0x8b,0xc1,0x49,0xc1,0xe0,0x10,0x49,0x0b,0xc0,0x48,0x89,0x04,0x24,0x0f,0xb6,0x04,0x24,0x48,0x89,0x11,0x88,0x41,0x08,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> encodeヽgᐸ16uᐳᐤLabelㆍDomainㆍHex32ᐤ  =>  new byte[42]{0x50,0x0f,0x1f,0x40,0x00,0x41,0x0f,0xb7,0xc0,0x45,0x8b,0xc1,0x49,0xc1,0xe0,0x10,0x49,0x0b,0xc0,0x48,0x89,0x04,0x24,0x0f,0xb7,0x04,0x24,0x48,0x89,0x11,0x66,0x89,0x41,0x08,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> encodeヽgᐸ32uᐳᐤLabelㆍDomainㆍHex32ᐤ  =>  new byte[40]{0x50,0x0f,0x1f,0x40,0x00,0x41,0x0f,0xb7,0xc0,0x45,0x8b,0xc1,0x49,0xc1,0xe0,0x10,0x49,0x0b,0xc0,0x48,0x89,0x04,0x24,0x8b,0x04,0x24,0x48,0x89,0x11,0x89,0x41,0x08,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> encodeヽgᐸ64uᐳᐤLabelㆍDomainㆍHex32ᐤ  =>  new byte[30]{0x0f,0x1f,0x44,0x00,0x00,0x41,0x0f,0xb7,0xc0,0x45,0x8b,0xc1,0x49,0xc1,0xe0,0x10,0x49,0x0b,0xc0,0x48,0x89,0x11,0x48,0x89,0x41,0x08,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> codeヽgᐸ8uᐳᐤOpCodeᐸbyteᐳᐤ  =>  new byte[18]{0x48,0x83,0xec,0x18,0x90,0x0f,0xb6,0x41,0x08,0x48,0xc1,0xe8,0x10,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> codeヽgᐸ16uᐳᐤOpCodeᐸushortᐳᐤ  =>  new byte[18]{0x50,0x0f,0x1f,0x40,0x00,0x0f,0xb7,0x41,0x08,0x48,0xc1,0xe8,0x10,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> codeヽgᐸ32uᐳᐤOpCodeᐸuintᐳᐤ  =>  new byte[17]{0x50,0x0f,0x1f,0x40,0x00,0x8b,0x41,0x08,0x48,0xc1,0xe8,0x10,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> codeヽgᐸ64uᐳᐤOpCodeᐸulongᐳᐤ  =>  new byte[14]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x41,0x08,0x48,0xc1,0xe8,0x10,0xc3};

        public static ReadOnlySpan<byte> domainヽgᐸ8uᐳᐤOpCodeᐸbyteᐳᐤ  =>  new byte[17]{0x48,0x83,0xec,0x18,0x90,0x0f,0xb6,0x41,0x08,0x0f,0xb7,0xc0,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> domainヽgᐸ16uᐳᐤOpCodeᐸushortᐳᐤ  =>  new byte[14]{0x50,0x0f,0x1f,0x40,0x00,0x0f,0xb7,0x41,0x08,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> domainヽgᐸ32uᐳᐤOpCodeᐸuintᐳᐤ  =>  new byte[16]{0x50,0x0f,0x1f,0x40,0x00,0x8b,0x41,0x08,0x0f,0xb7,0xc0,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> domainヽgᐸ64uᐳᐤOpCodeᐸulongᐳᐤ  =>  new byte[13]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x41,0x08,0x0f,0xb7,0xc0,0xc3};

        public static ReadOnlySpan<byte> untypeヽgᐸ8uᐳᐤOpCodeᐸbyteᐳᐤ  =>  new byte[27]{0x48,0x83,0xec,0x18,0x90,0x48,0x8b,0x02,0x0f,0xb6,0x52,0x08,0x48,0x89,0x01,0x48,0x89,0x51,0x08,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> untypeヽgᐸ16uᐳᐤOpCodeᐸushortᐳᐤ  =>  new byte[27]{0x50,0x0f,0x1f,0x40,0x00,0x48,0x8b,0x02,0x0f,0xb7,0x52,0x08,0x48,0x89,0x01,0x48,0x89,0x51,0x08,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> untypeヽgᐸ32uᐳᐤOpCodeᐸuintᐳᐤ  =>  new byte[26]{0x50,0x0f,0x1f,0x40,0x00,0x48,0x8b,0x02,0x8b,0x52,0x08,0x48,0x89,0x01,0x48,0x89,0x51,0x08,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> untypeヽgᐸ64uᐳᐤOpCodeᐸulongᐳᐤ  =>  new byte[23]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x02,0x48,0x8b,0x52,0x08,0x48,0x89,0x01,0x48,0x89,0x51,0x08,0x48,0x8b,0xc1,0xc3};

    }
}