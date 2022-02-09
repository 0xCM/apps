﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2022-01-14 21:56:33 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class lib_bytelogic
    {
        public static ReadOnlySpan<byte> storeヽᐤ64uㆍ8uᕀrefᐤ  =>  new byte[12]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0x02,0x48,0x8b,0xc2,0xc3};

        public static ReadOnlySpan<byte> notヽᐤ8uᕀinㆍ8uᕀrefᐤ  =>  new byte[12]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x01,0x0f,0xb6,0x02,0xc3};

        public static ReadOnlySpan<byte> andヽᐤ8uᕀinㆍ8uᕀinㆍ8uᕀrefᐤ  =>  new byte[16]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x01,0x48,0x8b,0x02,0x41,0x0f,0xb6,0x00,0xc3};

        public static ReadOnlySpan<byte> nandヽᐤ8uᕀinㆍ8uᕀinㆍ8uᕀrefᐤ  =>  new byte[16]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x01,0x48,0x8b,0x02,0x41,0x0f,0xb6,0x00,0xc3};

        public static ReadOnlySpan<byte> orヽᐤ8uᕀinㆍ8uᕀinㆍ8uᕀrefᐤ  =>  new byte[16]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x01,0x48,0x8b,0x02,0x41,0x0f,0xb6,0x00,0xc3};

        public static ReadOnlySpan<byte> norヽᐤ8uᕀinㆍ8uᕀinㆍ8uᕀrefᐤ  =>  new byte[16]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x01,0x48,0x8b,0x02,0x41,0x0f,0xb6,0x00,0xc3};

        public static ReadOnlySpan<byte> xorヽᐤ8uᕀinㆍ8uᕀinㆍ8uᕀrefᐤ  =>  new byte[16]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x01,0x48,0x8b,0x02,0x41,0x0f,0xb6,0x00,0xc3};

        public static ReadOnlySpan<byte> xnorヽᐤ8uᕀinㆍ8uᕀinㆍ8uᕀrefᐤ  =>  new byte[16]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x01,0x48,0x8b,0x02,0x41,0x0f,0xb6,0x00,0xc3};

        public static ReadOnlySpan<byte> nonimplヽᐤ8uᕀinㆍ8uᕀinㆍ8uᕀrefᐤ  =>  new byte[16]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x01,0x48,0x8b,0x02,0x41,0x0f,0xb6,0x00,0xc3};

        public static ReadOnlySpan<byte> implヽᐤ8uᕀinㆍ8uᕀinㆍ8uᕀrefᐤ  =>  new byte[16]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x01,0x48,0x8b,0x02,0x41,0x0f,0xb6,0x00,0xc3};

        public static ReadOnlySpan<byte> cimplヽᐤ8uᕀinㆍ8uᕀinㆍ8uᕀrefᐤ  =>  new byte[16]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x01,0x48,0x8b,0x02,0x41,0x0f,0xb6,0x00,0xc3};

        public static ReadOnlySpan<byte> cnonimplヽᐤ8uᕀinㆍ8uᕀinㆍ8uᕀrefᐤ  =>  new byte[16]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x01,0x48,0x8b,0x02,0x41,0x0f,0xb6,0x00,0xc3};

        public static ReadOnlySpan<byte> xornotヽᐤ8uᕀinㆍ8uᕀinㆍ8uᕀrefᐤ  =>  new byte[16]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x01,0x48,0x8b,0x02,0x41,0x0f,0xb6,0x00,0xc3};

        public static ReadOnlySpan<byte> testzヽᐤ8uᕀinㆍ8uᕀinᐤ  =>  new byte[66]{0x48,0x83,0xec,0x18,0xc5,0xf8,0x77,0x48,0x8b,0x01,0x48,0x8b,0x12,0x48,0x89,0x44,0x24,0x10,0x48,0x8d,0x44,0x24,0x10,0xc4,0xe2,0x79,0x59,0x44,0x24,0x10,0x48,0x89,0x54,0x24,0x08,0x48,0x8d,0x44,0x24,0x08,0xc4,0xe2,0x79,0x59,0x4c,0x24,0x08,0xc4,0xe2,0x79,0x17,0xc1,0x0f,0x94,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> testcヽᐤ8uᕀinㆍ8uᕀinᐤ  =>  new byte[66]{0x48,0x83,0xec,0x18,0xc5,0xf8,0x77,0x48,0x8b,0x01,0x48,0x8b,0x12,0x48,0x89,0x44,0x24,0x10,0x48,0x8d,0x44,0x24,0x10,0xc4,0xe2,0x79,0x59,0x44,0x24,0x10,0x48,0x89,0x54,0x24,0x08,0x48,0x8d,0x44,0x24,0x08,0xc4,0xe2,0x79,0x59,0x4c,0x24,0x08,0xc4,0xe2,0x79,0x17,0xc1,0x0f,0x92,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> testcヽᐤ8uᕀinᐤ  =>  new byte[54]{0x50,0xc5,0xf8,0x77,0x90,0x48,0x8b,0x01,0x48,0x89,0x04,0x24,0x48,0x8d,0x04,0x24,0xc4,0xe2,0x79,0x59,0x04,0x24,0xc5,0xf0,0x57,0xc9,0xc5,0xe8,0x57,0xd2,0xc4,0xe2,0x71,0x29,0xca,0xc4,0xe2,0x79,0x17,0xc1,0x0f,0x92,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> selectヽᐤ8uᕀinㆍ8uᕀinㆍ8uᕀinㆍ8uᕀrefᐤ  =>  new byte[19]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x01,0x48,0x8b,0x02,0x49,0x8b,0x00,0x41,0x0f,0xb6,0x01,0xc3};

        public static ReadOnlySpan<byte> testzヽᐤ64uㆍ64uᐤ  =>  new byte[60]{0x48,0x83,0xec,0x18,0xc5,0xf8,0x77,0x48,0x89,0x4c,0x24,0x10,0x48,0x8d,0x44,0x24,0x10,0xc4,0xe2,0x79,0x59,0x44,0x24,0x10,0x48,0x89,0x54,0x24,0x08,0x48,0x8d,0x44,0x24,0x08,0xc4,0xe2,0x79,0x59,0x4c,0x24,0x08,0xc4,0xe2,0x79,0x17,0xc1,0x0f,0x94,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> testcヽᐤ64uㆍ64uᐤ  =>  new byte[60]{0x48,0x83,0xec,0x18,0xc5,0xf8,0x77,0x48,0x89,0x4c,0x24,0x10,0x48,0x8d,0x44,0x24,0x10,0xc4,0xe2,0x79,0x59,0x44,0x24,0x10,0x48,0x89,0x54,0x24,0x08,0x48,0x8d,0x44,0x24,0x08,0xc4,0xe2,0x79,0x59,0x4c,0x24,0x08,0xc4,0xe2,0x79,0x17,0xc1,0x0f,0x92,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> testcヽᐤ64uᐤ  =>  new byte[51]{0x50,0xc5,0xf8,0x77,0x90,0x48,0x89,0x0c,0x24,0x48,0x8d,0x04,0x24,0xc4,0xe2,0x79,0x59,0x04,0x24,0xc5,0xf0,0x57,0xc9,0xc5,0xe8,0x57,0xd2,0xc4,0xe2,0x71,0x29,0xca,0xc4,0xe2,0x79,0x17,0xc1,0x0f,0x92,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0x48,0x83,0xc4,0x08,0xc3};

    }
}
