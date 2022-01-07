﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2022-01-07 15:36:32 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class cpu_fcpu
    {
        public static ReadOnlySpan<byte> vrcpヽᐤVector128ᐸfloatᐳᐤ  =>  new byte[17]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf8,0x53,0x02,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> vrcpヽᐤVector256ᐸfloatᐳᐤ  =>  new byte[20]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfc,0x53,0x02,0xc5,0xfd,0x11,0x01,0x48,0x8b,0xc1,0xc5,0xf8,0x77,0xc3};

        public static ReadOnlySpan<byte> vfmaddヽᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳㆍVector128ᐸfloatᐳᐤ  =>  new byte[27]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x79,0x10,0x08,0xc4,0xc2,0x71,0xa8,0x01,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> vfmaddヽᐤVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳᐤ  =>  new byte[27]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x79,0x10,0x08,0xc4,0xc2,0xf1,0xa8,0x01,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> vfmaddヽᐤVector256ᐸfloatᐳㆍVector256ᐸfloatᐳㆍVector256ᐸfloatᐳᐤ  =>  new byte[30]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfd,0x10,0x02,0xc4,0xc1,0x7d,0x10,0x08,0xc4,0xc2,0x75,0xa8,0x01,0xc5,0xfd,0x11,0x01,0x48,0x8b,0xc1,0xc5,0xf8,0x77,0xc3};

        public static ReadOnlySpan<byte> vfmaddヽᐤVector256ᐸdoubleᐳㆍVector256ᐸdoubleᐳㆍVector256ᐸdoubleᐳᐤ  =>  new byte[30]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfd,0x10,0x02,0xc4,0xc1,0x7d,0x10,0x08,0xc4,0xc2,0xf5,0xa8,0x01,0xc5,0xfd,0x11,0x01,0x48,0x8b,0xc1,0xc5,0xf8,0x77,0xc3};

        public static ReadOnlySpan<byte> vceilヽᐤVector128ᐸfloatᐳᐤ  =>  new byte[19]{0xc5,0xf8,0x77,0x66,0x90,0xc4,0xe3,0x79,0x08,0x02,0x0a,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> vceilヽᐤVector128ᐸdoubleᐳᐤ  =>  new byte[19]{0xc5,0xf8,0x77,0x66,0x90,0xc4,0xe3,0x79,0x09,0x02,0x0a,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> vceilヽᐤVector256ᐸfloatᐳᐤ  =>  new byte[22]{0xc5,0xf8,0x77,0x66,0x90,0xc4,0xe3,0x7d,0x08,0x02,0x0a,0xc5,0xfd,0x11,0x01,0x48,0x8b,0xc1,0xc5,0xf8,0x77,0xc3};

        public static ReadOnlySpan<byte> vceilヽᐤVector256ᐸdoubleᐳᐤ  =>  new byte[22]{0xc5,0xf8,0x77,0x66,0x90,0xc4,0xe3,0x7d,0x09,0x02,0x0a,0xc5,0xfd,0x11,0x01,0x48,0x8b,0xc1,0xc5,0xf8,0x77,0xc3};

        public static ReadOnlySpan<byte> vfloorヽᐤVector128ᐸfloatᐳᐤ  =>  new byte[19]{0xc5,0xf8,0x77,0x66,0x90,0xc4,0xe3,0x79,0x08,0x02,0x09,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> vfloorヽᐤVector128ᐸdoubleᐳᐤ  =>  new byte[19]{0xc5,0xf8,0x77,0x66,0x90,0xc4,0xe3,0x79,0x09,0x02,0x09,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> vfloorヽᐤVector256ᐸfloatᐳᐤ  =>  new byte[22]{0xc5,0xf8,0x77,0x66,0x90,0xc4,0xe3,0x7d,0x08,0x02,0x09,0xc5,0xfd,0x11,0x01,0x48,0x8b,0xc1,0xc5,0xf8,0x77,0xc3};

        public static ReadOnlySpan<byte> vfloorヽᐤVector256ᐸdoubleᐳᐤ  =>  new byte[22]{0xc5,0xf8,0x77,0x66,0x90,0xc4,0xe3,0x7d,0x09,0x02,0x09,0xc5,0xfd,0x11,0x01,0x48,0x8b,0xc1,0xc5,0xf8,0x77,0xc3};

        public static ReadOnlySpan<byte> vconvert128x32fヽᐤVector128ᐸintᐳᐤ  =>  new byte[17]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf8,0x5b,0x02,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> vconvert128x32fヽᐤVector128ᐸdoubleᐳᐤ  =>  new byte[17]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x5a,0x02,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> vconvert128x32fヽᐤVector256ᐸdoubleᐳᐤ  =>  new byte[20]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfd,0x5a,0x02,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc5,0xf8,0x77,0xc3};

        public static ReadOnlySpan<byte> vconvert128x32iヽᐤVector128ᐸfloatᐳᐤ  =>  new byte[17]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x5b,0x02,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> vconvert128x32iヽᐤVector256ᐸdoubleᐳᐤ  =>  new byte[20]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xff,0xe6,0x02,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc5,0xf8,0x77,0xc3};

        public static ReadOnlySpan<byte> vconvert128x32iヽᐤVector128ᐸdoubleᐳᐤ  =>  new byte[17]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfb,0xe6,0x02,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> vconvert256x32fヽᐤVector256ᐸintᐳᐤ  =>  new byte[20]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfc,0x5b,0x02,0xc5,0xfd,0x11,0x01,0x48,0x8b,0xc1,0xc5,0xf8,0x77,0xc3};

        public static ReadOnlySpan<byte> vconvert256x32iヽᐤVector256ᐸfloatᐳᐤ  =>  new byte[20]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfd,0x5b,0x02,0xc5,0xfd,0x11,0x01,0x48,0x8b,0xc1,0xc5,0xf8,0x77,0xc3};

        public static ReadOnlySpan<byte> vconvert256x64fヽᐤVector128ᐸintᐳᐤ  =>  new byte[20]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfe,0xe6,0x02,0xc5,0xfd,0x11,0x01,0x48,0x8b,0xc1,0xc5,0xf8,0x77,0xc3};

        public static ReadOnlySpan<byte> vdivヽᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳᐤ  =>  new byte[22]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x78,0x5e,0x00,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> vdivヽᐤVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳᐤ  =>  new byte[22]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x79,0x5e,0x00,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> vdivヽᐤVector256ᐸfloatᐳㆍVector256ᐸfloatᐳᐤ  =>  new byte[25]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfd,0x10,0x02,0xc4,0xc1,0x7c,0x5e,0x00,0xc5,0xfd,0x11,0x01,0x48,0x8b,0xc1,0xc5,0xf8,0x77,0xc3};

        public static ReadOnlySpan<byte> vdivヽᐤVector256ᐸdoubleᐳㆍVector256ᐸdoubleᐳᐤ  =>  new byte[25]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfd,0x10,0x02,0xc4,0xc1,0x7d,0x5e,0x00,0xc5,0xfd,0x11,0x01,0x48,0x8b,0xc1,0xc5,0xf8,0x77,0xc3};

        public static ReadOnlySpan<byte> vsqrtヽᐤVector128ᐸfloatᐳᐤ  =>  new byte[17]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf8,0x51,0x02,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> vsqrtヽᐤVector128ᐸdoubleᐳᐤ  =>  new byte[17]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x51,0x02,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> vsqrtヽᐤVector256ᐸfloatᐳᐤ  =>  new byte[20]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfc,0x51,0x02,0xc5,0xfd,0x11,0x01,0x48,0x8b,0xc1,0xc5,0xf8,0x77,0xc3};

        public static ReadOnlySpan<byte> vsqrtヽᐤVector256ᐸdoubleᐳᐤ  =>  new byte[20]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfd,0x51,0x02,0xc5,0xfd,0x11,0x01,0x48,0x8b,0xc1,0xc5,0xf8,0x77,0xc3};

        public static ReadOnlySpan<byte> vrsqrtヽᐤVector128ᐸfloatᐳᐤ  =>  new byte[17]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf8,0x52,0x02,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> vxor1ヽᐤVector128ᐸfloatᐳᐤ  =>  new byte[30]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf8,0x57,0xc0,0xc5,0xf0,0x57,0xc9,0xc5,0xf8,0xc2,0xc1,0x00,0xc5,0xf8,0x57,0x02,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> vxor1ヽᐤVector128ᐸdoubleᐳᐤ  =>  new byte[30]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf8,0x57,0xc0,0xc5,0xf0,0x57,0xc9,0xc5,0xf9,0xc2,0xc1,0x00,0xc5,0xf9,0x57,0x02,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> vxor1ヽᐤVector256ᐸfloatᐳᐤ  =>  new byte[33]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfc,0x57,0xc0,0xc5,0xf4,0x57,0xc9,0xc5,0xfc,0xc2,0xc1,0x00,0xc5,0xfc,0x57,0x02,0xc5,0xfd,0x11,0x01,0x48,0x8b,0xc1,0xc5,0xf8,0x77,0xc3};

        public static ReadOnlySpan<byte> vxor1ヽᐤVector256ᐸdoubleᐳᐤ  =>  new byte[33]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfc,0x57,0xc0,0xc5,0xf4,0x57,0xc9,0xc5,0xfd,0xc2,0xc1,0x00,0xc5,0xfd,0x57,0x02,0xc5,0xfd,0x11,0x01,0x48,0x8b,0xc1,0xc5,0xf8,0x77,0xc3};

        public static ReadOnlySpan<byte> vfmanヽᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳㆍVector128ᐸfloatᐳᐤ  =>  new byte[27]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x79,0x10,0x08,0xc4,0xc2,0x71,0xac,0x01,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> vfmanヽᐤVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳᐤ  =>  new byte[27]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x79,0x10,0x08,0xc4,0xc2,0xf1,0xac,0x01,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> vfmanヽᐤVector256ᐸfloatᐳㆍVector256ᐸfloatᐳㆍVector256ᐸfloatᐳᐤ  =>  new byte[30]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfd,0x10,0x02,0xc4,0xc1,0x7d,0x10,0x08,0xc4,0xc2,0x75,0xac,0x01,0xc5,0xfd,0x11,0x01,0x48,0x8b,0xc1,0xc5,0xf8,0x77,0xc3};

        public static ReadOnlySpan<byte> vfmanヽᐤVector256ᐸdoubleᐳㆍVector256ᐸdoubleᐳㆍVector256ᐸdoubleᐳᐤ  =>  new byte[30]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfd,0x10,0x02,0xc4,0xc1,0x7d,0x10,0x08,0xc4,0xc2,0xf5,0xac,0x01,0xc5,0xfd,0x11,0x01,0x48,0x8b,0xc1,0xc5,0xf8,0x77,0xc3};

        public static ReadOnlySpan<byte> vfmasヽᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳㆍVector128ᐸfloatᐳᐤ  =>  new byte[27]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x79,0x10,0x08,0xc4,0xc2,0x71,0xa6,0x01,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> vfmasヽᐤVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳᐤ  =>  new byte[27]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x79,0x10,0x08,0xc4,0xc2,0xf1,0xa6,0x01,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> vfmasヽᐤVector256ᐸfloatᐳㆍVector256ᐸfloatᐳㆍVector256ᐸfloatᐳᐤ  =>  new byte[30]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfd,0x10,0x02,0xc4,0xc1,0x7d,0x10,0x08,0xc4,0xc2,0x75,0xa6,0x01,0xc5,0xfd,0x11,0x01,0x48,0x8b,0xc1,0xc5,0xf8,0x77,0xc3};

        public static ReadOnlySpan<byte> vfmasヽᐤVector256ᐸdoubleᐳㆍVector256ᐸdoubleᐳㆍVector256ᐸdoubleᐳᐤ  =>  new byte[30]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfd,0x10,0x02,0xc4,0xc1,0x7d,0x10,0x08,0xc4,0xc2,0xf5,0xa6,0x01,0xc5,0xfd,0x11,0x01,0x48,0x8b,0xc1,0xc5,0xf8,0x77,0xc3};

        public static ReadOnlySpan<byte> vroundヽᐤVector128ᐸfloatᐳᐤ  =>  new byte[19]{0xc5,0xf8,0x77,0x66,0x90,0xc4,0xe3,0x79,0x08,0x02,0x08,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> vroundヽᐤVector128ᐸdoubleᐳᐤ  =>  new byte[19]{0xc5,0xf8,0x77,0x66,0x90,0xc4,0xe3,0x79,0x09,0x02,0x08,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> vroundzヽᐤVector128ᐸfloatᐳᐤ  =>  new byte[19]{0xc5,0xf8,0x77,0x66,0x90,0xc4,0xe3,0x79,0x08,0x02,0x0b,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> vroundzヽᐤVector128ᐸdoubleᐳᐤ  =>  new byte[19]{0xc5,0xf8,0x77,0x66,0x90,0xc4,0xe3,0x79,0x09,0x02,0x0b,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> vroundヽᐤVector256ᐸfloatᐳᐤ  =>  new byte[22]{0xc5,0xf8,0x77,0x66,0x90,0xc4,0xe3,0x7d,0x08,0x02,0x08,0xc5,0xfd,0x11,0x01,0x48,0x8b,0xc1,0xc5,0xf8,0x77,0xc3};

        public static ReadOnlySpan<byte> vroundヽᐤVector256ᐸdoubleᐳᐤ  =>  new byte[22]{0xc5,0xf8,0x77,0x66,0x90,0xc4,0xe3,0x7d,0x09,0x02,0x08,0xc5,0xfd,0x11,0x01,0x48,0x8b,0xc1,0xc5,0xf8,0x77,0xc3};

        public static ReadOnlySpan<byte> vroundzヽᐤVector256ᐸfloatᐳᐤ  =>  new byte[22]{0xc5,0xf8,0x77,0x66,0x90,0xc4,0xe3,0x7d,0x08,0x02,0x0b,0xc5,0xfd,0x11,0x01,0x48,0x8b,0xc1,0xc5,0xf8,0x77,0xc3};

        public static ReadOnlySpan<byte> vroundzヽᐤVector256ᐸdoubleᐳᐤ  =>  new byte[22]{0xc5,0xf8,0x77,0x66,0x90,0xc4,0xe3,0x7d,0x09,0x02,0x0b,0xc5,0xfd,0x11,0x01,0x48,0x8b,0xc1,0xc5,0xf8,0x77,0xc3};

        public static ReadOnlySpan<byte> vmulヽᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳᐤ  =>  new byte[22]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x78,0x59,0x00,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> vmulヽᐤVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳᐤ  =>  new byte[22]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x79,0x59,0x00,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> vmulヽᐤVector256ᐸfloatᐳㆍVector256ᐸfloatᐳᐤ  =>  new byte[25]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfd,0x10,0x02,0xc4,0xc1,0x7c,0x59,0x00,0xc5,0xfd,0x11,0x01,0x48,0x8b,0xc1,0xc5,0xf8,0x77,0xc3};

        public static ReadOnlySpan<byte> vmulヽᐤVector256ᐸdoubleᐳㆍVector256ᐸdoubleᐳᐤ  =>  new byte[25]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfd,0x10,0x02,0xc4,0xc1,0x7d,0x59,0x00,0xc5,0xfd,0x11,0x01,0x48,0x8b,0xc1,0xc5,0xf8,0x77,0xc3};

        public static ReadOnlySpan<byte> vmovehlヽᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳᐤ  =>  new byte[26]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x79,0x10,0x08,0xc5,0xf8,0x12,0xc1,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> vmovelhヽᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳᐤ  =>  new byte[26]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x79,0x10,0x08,0xc5,0xf8,0x16,0xc1,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> vdotヽᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳㆍbyteᐤ  =>  new byte[98]{0x56,0x48,0x83,0xec,0x40,0xc5,0xf8,0x77,0x4c,0x89,0x4c,0x24,0x68,0x48,0x8b,0xf1,0x48,0x8d,0x4c,0x24,0x68,0x44,0x0f,0xb6,0x09,0x0f,0xb6,0x49,0x01,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x79,0x10,0x08,0x45,0x84,0xc9,0x75,0x08,0x41,0xb9,0xff,0x00,0x00,0x00,0xeb,0x04,0x44,0x0f,0xb6,0xc9,0x48,0x8b,0xce,0xc5,0xf9,0x29,0x44,0x24,0x30,0xc5,0xf9,0x29,0x4c,0x24,0x20,0x48,0x8d,0x54,0x24,0x30,0x4c,0x8d,0x44,0x24,0x20,0x45,0x0f,0xb6,0xc9,0xe8,0x87,0x39,0xcf,0xfb,0x48,0x8b,0xc6,0x48,0x83,0xc4,0x40,0x5e,0xc3};

        public static ReadOnlySpan<byte> vdotヽᐤVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳㆍbyteᐤ  =>  new byte[98]{0x56,0x48,0x83,0xec,0x40,0xc5,0xf8,0x77,0x4c,0x89,0x4c,0x24,0x68,0x48,0x8b,0xf1,0x48,0x8d,0x4c,0x24,0x68,0x44,0x0f,0xb6,0x09,0x0f,0xb6,0x49,0x01,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x79,0x10,0x08,0x45,0x84,0xc9,0x75,0x08,0x41,0xb9,0xff,0x00,0x00,0x00,0xeb,0x04,0x44,0x0f,0xb6,0xc9,0x48,0x8b,0xce,0xc5,0xf9,0x29,0x44,0x24,0x30,0xc5,0xf9,0x29,0x4c,0x24,0x20,0x48,0x8d,0x54,0x24,0x30,0x4c,0x8d,0x44,0x24,0x20,0x45,0x0f,0xb6,0xc9,0xe8,0x0f,0x39,0xcf,0xfb,0x48,0x8b,0xc6,0x48,0x83,0xc4,0x40,0x5e,0xc3};

        public static ReadOnlySpan<byte> vdotヽᐤVector256ᐸfloatᐳㆍVector256ᐸfloatᐳㆍbyteᐤ  =>  new byte[107]{0x56,0x48,0x83,0xec,0x70,0xc5,0xf8,0x77,0x4c,0x89,0x8c,0x24,0x98,0x00,0x00,0x00,0x48,0x8b,0xf1,0x48,0x8d,0x8c,0x24,0x98,0x00,0x00,0x00,0x44,0x0f,0xb6,0x09,0x0f,0xb6,0x49,0x01,0xc5,0xfd,0x10,0x02,0xc4,0xc1,0x7d,0x10,0x08,0x45,0x84,0xc9,0x75,0x08,0x41,0xb9,0xff,0x00,0x00,0x00,0xeb,0x04,0x44,0x0f,0xb6,0xc9,0x48,0x8b,0xce,0xc5,0xfd,0x11,0x44,0x24,0x40,0xc5,0xfd,0x11,0x4c,0x24,0x20,0x48,0x8d,0x54,0x24,0x40,0x4c,0x8d,0x44,0x24,0x20,0x45,0x0f,0xb6,0xc9,0xe8,0x29,0x3f,0xcf,0xfb,0x48,0x8b,0xc6,0xc5,0xf8,0x77,0x48,0x83,0xc4,0x70,0x5e,0xc3};

        public static ReadOnlySpan<byte> vhaddヽᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳᐤ  =>  new byte[22]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x7b,0x7c,0x00,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> vhaddヽᐤVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳᐤ  =>  new byte[22]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x79,0x7c,0x00,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> vhaddヽᐤVector256ᐸfloatᐳㆍVector256ᐸfloatᐳᐤ  =>  new byte[25]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfd,0x10,0x02,0xc4,0xc1,0x7f,0x7c,0x00,0xc5,0xfd,0x11,0x01,0x48,0x8b,0xc1,0xc5,0xf8,0x77,0xc3};

        public static ReadOnlySpan<byte> vhaddヽᐤVector256ᐸdoubleᐳㆍVector256ᐸdoubleᐳᐤ  =>  new byte[25]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfd,0x10,0x02,0xc4,0xc1,0x7d,0x7c,0x00,0xc5,0xfd,0x11,0x01,0x48,0x8b,0xc1,0xc5,0xf8,0x77,0xc3};

        public static ReadOnlySpan<byte> vhsubヽᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳᐤ  =>  new byte[22]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x7b,0x7d,0x00,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> vhsubヽᐤVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳᐤ  =>  new byte[22]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x79,0x7d,0x00,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> vhsubヽᐤVector256ᐸfloatᐳㆍVector256ᐸfloatᐳᐤ  =>  new byte[25]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfd,0x10,0x02,0xc4,0xc1,0x7f,0x7d,0x00,0xc5,0xfd,0x11,0x01,0x48,0x8b,0xc1,0xc5,0xf8,0x77,0xc3};

        public static ReadOnlySpan<byte> vhsubヽᐤVector256ᐸdoubleᐳㆍVector256ᐸdoubleᐳᐤ  =>  new byte[25]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfd,0x10,0x02,0xc4,0xc1,0x7d,0x7d,0x00,0xc5,0xfd,0x11,0x01,0x48,0x8b,0xc1,0xc5,0xf8,0x77,0xc3};

    }
}
