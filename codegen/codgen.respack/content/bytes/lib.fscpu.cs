﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2022-01-07 15:36:30 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class lib_fscpu
    {
        public static ReadOnlySpan<byte> vloadsヽᐤ32fᐤ  =>  new byte[25]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfa,0x11,0x4c,0x24,0x10,0xc5,0xfa,0x10,0x44,0x24,0x10,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> vloadsヽᐤ64fᐤ  =>  new byte[25]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfb,0x11,0x4c,0x24,0x10,0xc5,0xfb,0x10,0x44,0x24,0x10,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> vstoresヽᐤVector128ᐸfloatᐳᐤ  =>  new byte[41]{0x50,0xc5,0xf8,0x77,0x33,0xc0,0x89,0x44,0x24,0x04,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x11,0x44,0x24,0x04,0xc5,0xf9,0x10,0x01,0xc5,0xfa,0x11,0x44,0x24,0x04,0xc5,0xfa,0x10,0x44,0x24,0x04,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> vstoresヽᐤVector128ᐸdoubleᐳᐤ  =>  new byte[38]{0x50,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x04,0x24,0xc5,0xf8,0x57,0xc0,0xc5,0xfb,0x11,0x04,0x24,0xc5,0xf9,0x10,0x01,0xc5,0xfb,0x11,0x04,0x24,0xc5,0xfb,0x10,0x04,0x24,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> convertヽᐤ32iㆍVector128ᐸdoubleᐳᕀoutᐤ  =>  new byte[21]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf8,0x57,0xc0,0xc5,0xfb,0x2a,0xc1,0xc5,0xf9,0x11,0x02,0x48,0x8b,0xc2,0xc3};

        public static ReadOnlySpan<byte> convertヽᐤ32iㆍVector128ᐸfloatᐳᕀoutᐤ  =>  new byte[21]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x2a,0xc1,0xc5,0xf9,0x11,0x02,0x48,0x8b,0xc2,0xc3};

        public static ReadOnlySpan<byte> convertヽᐤ64iㆍVector128ᐸfloatᐳᕀoutᐤ  =>  new byte[22]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf8,0x57,0xc0,0xc4,0xe1,0xfa,0x2a,0xc1,0xc5,0xf9,0x11,0x02,0x48,0x8b,0xc2,0xc3};

        public static ReadOnlySpan<byte> to32iヽᐤ32fᕀinᐤ  =>  new byte[10]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfa,0x2d,0x01,0xc3};

        public static ReadOnlySpan<byte> to32iヽᐤ64fᕀinᐤ  =>  new byte[10]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfb,0x2d,0x01,0xc3};

        public static ReadOnlySpan<byte> to64iヽᐤ32fᕀinᐤ  =>  new byte[11]{0xc5,0xf8,0x77,0x66,0x90,0xc4,0xe1,0xfa,0x2d,0x01,0xc3};

        public static ReadOnlySpan<byte> to64iヽᐤ64fᕀinᐤ  =>  new byte[11]{0xc5,0xf8,0x77,0x66,0x90,0xc4,0xe1,0xfb,0x2d,0x01,0xc3};

        public static ReadOnlySpan<byte> vmovsヽᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳᐤ  =>  new byte[26]{0xc5,0xf8,0x77,0x66,0x90,0xc4,0xc1,0x79,0x10,0x00,0xc5,0xf9,0x10,0x0a,0xc5,0xfa,0x10,0xc1,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> vmovsヽᐤVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳᐤ  =>  new byte[26]{0xc5,0xf8,0x77,0x66,0x90,0xc4,0xc1,0x79,0x10,0x00,0xc5,0xf9,0x10,0x0a,0xc5,0xfb,0x10,0xc1,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> vaddsヽᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳᐤ  =>  new byte[22]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x7a,0x58,0x00,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> vaddsヽᐤVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳᐤ  =>  new byte[22]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x7b,0x58,0x00,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> vmulsヽᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳᐤ  =>  new byte[22]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x7a,0x59,0x00,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> vmulsヽᐤVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳᐤ  =>  new byte[22]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x7b,0x59,0x00,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> vfmaddsヽᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳㆍVector128ᐸfloatᐳᐤ  =>  new byte[27]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x79,0x10,0x08,0xc4,0xc2,0x71,0xa9,0x01,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> vfmaddsヽᐤVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳᐤ  =>  new byte[27]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x79,0x10,0x08,0xc4,0xc2,0xf1,0xa9,0x01,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> fmsubヽᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳㆍVector128ᐸfloatᐳᐤ  =>  new byte[27]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x79,0x10,0x08,0xc4,0xc2,0x71,0xab,0x01,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> fmsubヽᐤVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳᐤ  =>  new byte[27]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x79,0x10,0x08,0xc4,0xc2,0xf1,0xab,0x01,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> fnmaddヽᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳㆍVector128ᐸfloatᐳᐤ  =>  new byte[27]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x79,0x10,0x08,0xc4,0xc2,0x71,0xad,0x01,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> fnmaddヽᐤVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳᐤ  =>  new byte[27]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x79,0x10,0x08,0xc4,0xc2,0xf1,0xad,0x01,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> vdivsヽᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳᐤ  =>  new byte[22]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x7a,0x5e,0x00,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> vdivsヽᐤVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳᐤ  =>  new byte[22]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x7b,0x5e,0x00,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> subヽᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳᐤ  =>  new byte[22]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x7a,0x5c,0x00,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> subヽᐤVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳᐤ  =>  new byte[22]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x7b,0x5c,0x00,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> maxヽᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳᐤ  =>  new byte[22]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x7a,0x5f,0x00,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> maxヽᐤVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳᐤ  =>  new byte[22]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x7b,0x5f,0x00,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> minヽᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳᐤ  =>  new byte[22]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x7a,0x5d,0x00,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> minヽᐤVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳᐤ  =>  new byte[22]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x7b,0x5d,0x00,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> eqヽᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳᐤ  =>  new byte[27]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x01,0xc5,0xf8,0x2e,0x02,0x0f,0x9b,0xc2,0x0f,0x94,0xc0,0x22,0xc2,0x0f,0xb6,0xd0,0x8b,0xc2,0xc3};

        public static ReadOnlySpan<byte> eqヽᐤVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳᐤ  =>  new byte[27]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x01,0xc5,0xf9,0x2e,0x02,0x0f,0x9b,0xc2,0x0f,0x94,0xc0,0x22,0xc2,0x0f,0xb6,0xd0,0x8b,0xc2,0xc3};

        public static ReadOnlySpan<byte> neqヽᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳᐤ  =>  new byte[27]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x01,0xc5,0xf8,0x2f,0x02,0x0f,0x9a,0xc2,0x0f,0x95,0xc0,0x0a,0xc2,0x0f,0xb6,0xd0,0x8b,0xc2,0xc3};

        public static ReadOnlySpan<byte> neqヽᐤVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳᐤ  =>  new byte[27]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x01,0xc5,0xf9,0x2f,0x02,0x0f,0x9a,0xc2,0x0f,0x95,0xc0,0x0a,0xc2,0x0f,0xb6,0xd0,0x8b,0xc2,0xc3};

        public static ReadOnlySpan<byte> gtヽᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳᐤ  =>  new byte[20]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x01,0xc5,0xf8,0x2f,0x02,0x0f,0x97,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> gtヽᐤVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳᐤ  =>  new byte[20]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x01,0xc5,0xf9,0x2f,0x02,0x0f,0x97,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> gteqヽᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳᐤ  =>  new byte[20]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x01,0xc5,0xf8,0x2f,0x02,0x0f,0x93,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> gteqヽᐤVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳᐤ  =>  new byte[20]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x01,0xc5,0xf9,0x2f,0x02,0x0f,0x93,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> ngtヽᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳᐤ  =>  new byte[45]{0x50,0xc5,0xf8,0x77,0x90,0xc5,0xf9,0x10,0x01,0xc5,0xfa,0xc2,0x02,0x02,0xc5,0xfa,0x11,0x44,0x24,0x04,0x8b,0x44,0x24,0x04,0x25,0xff,0xff,0xff,0x7f,0x3d,0x00,0x00,0x80,0x7f,0x0f,0x9f,0xc0,0x0f,0xb6,0xc0,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> ngtヽᐤVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳᐤ  =>  new byte[60]{0x50,0xc5,0xf8,0x77,0x90,0xc5,0xf9,0x10,0x01,0xc5,0xfb,0xc2,0x02,0x02,0xc5,0xfb,0x11,0x04,0x24,0x48,0x8b,0x04,0x24,0x48,0xba,0xff,0xff,0xff,0xff,0xff,0xff,0xff,0x7f,0x48,0x23,0xc2,0x48,0xba,0x00,0x00,0x00,0x00,0x00,0x00,0xf0,0x7f,0x48,0x3b,0xc2,0x0f,0x9f,0xc0,0x0f,0xb6,0xc0,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> ltヽᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳᐤ  =>  new byte[20]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc5,0xf8,0x2f,0x01,0x0f,0x97,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> ltヽᐤVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳᐤ  =>  new byte[20]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc5,0xf9,0x2f,0x01,0x0f,0x97,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> nltヽᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳᐤ  =>  new byte[45]{0x50,0xc5,0xf8,0x77,0x90,0xc5,0xf9,0x10,0x01,0xc5,0xfa,0xc2,0x02,0x05,0xc5,0xfa,0x11,0x44,0x24,0x04,0x8b,0x44,0x24,0x04,0x25,0xff,0xff,0xff,0x7f,0x3d,0x00,0x00,0x80,0x7f,0x0f,0x9f,0xc0,0x0f,0xb6,0xc0,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> nltヽᐤVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳᐤ  =>  new byte[60]{0x50,0xc5,0xf8,0x77,0x90,0xc5,0xf9,0x10,0x01,0xc5,0xfb,0xc2,0x02,0x05,0xc5,0xfb,0x11,0x04,0x24,0x48,0x8b,0x04,0x24,0x48,0xba,0xff,0xff,0xff,0xff,0xff,0xff,0xff,0x7f,0x48,0x23,0xc2,0x48,0xba,0x00,0x00,0x00,0x00,0x00,0x00,0xf0,0x7f,0x48,0x3b,0xc2,0x0f,0x9f,0xc0,0x0f,0xb6,0xc0,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> lteqヽᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳᐤ  =>  new byte[20]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc5,0xf8,0x2e,0x01,0x0f,0x93,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> lteqヽᐤVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳᐤ  =>  new byte[20]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc5,0xf9,0x2e,0x01,0x0f,0x93,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> cmpヽᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳㆍFpCmpModeᕀ8uᐤ  =>  new byte[63]{0x56,0x48,0x83,0xec,0x40,0xc5,0xf8,0x77,0x48,0x8b,0xf1,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x79,0x10,0x08,0x48,0x8b,0xce,0xc5,0xf9,0x29,0x44,0x24,0x30,0xc5,0xf9,0x29,0x4c,0x24,0x20,0x48,0x8d,0x54,0x24,0x30,0x4c,0x8d,0x44,0x24,0x20,0x45,0x0f,0xb6,0xc9,0xe8,0x8a,0x0a,0xfe,0xfb,0x48,0x8b,0xc6,0x48,0x83,0xc4,0x40,0x5e,0xc3};

        public static ReadOnlySpan<byte> cmpヽᐤVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳㆍFpCmpModeᕀ8uᐤ  =>  new byte[63]{0x56,0x48,0x83,0xec,0x40,0xc5,0xf8,0x77,0x48,0x8b,0xf1,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x79,0x10,0x08,0x48,0x8b,0xce,0xc5,0xf9,0x29,0x44,0x24,0x30,0xc5,0xf9,0x29,0x4c,0x24,0x20,0x48,0x8d,0x54,0x24,0x30,0x4c,0x8d,0x44,0x24,0x20,0x45,0x0f,0xb6,0xc9,0xe8,0x22,0x0a,0xfe,0xfb,0x48,0x8b,0xc6,0x48,0x83,0xc4,0x40,0x5e,0xc3};

        public static ReadOnlySpan<byte> ceilヽᐤVector128ᐸfloatᐳᐤ  =>  new byte[23]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xe3,0x79,0x0a,0xc0,0x0a,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> ceilヽᐤVector128ᐸdoubleᐳᐤ  =>  new byte[23]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xe3,0x79,0x0b,0xc0,0x0a,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> floorヽᐤVector128ᐸfloatᐳᐤ  =>  new byte[23]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xe3,0x79,0x0a,0xc0,0x09,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> floorヽᐤVector128ᐸdoubleᐳᐤ  =>  new byte[23]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xe3,0x79,0x0b,0xc0,0x09,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> rcpヽᐤVector128ᐸfloatᐳᐤ  =>  new byte[21]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc5,0xfa,0x53,0xc0,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> sqrtヽᐤVector128ᐸfloatᐳᐤ  =>  new byte[21]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc5,0xfa,0x51,0xc0,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> sqrtヽᐤVector128ᐸdoubleᐳᐤ  =>  new byte[21]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc5,0xfb,0x51,0xc0,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> rsqrtヽᐤVector128ᐸfloatᐳᕀrefᐤ  =>  new byte[21]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x01,0xc5,0xfa,0x52,0xc0,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> IsNaNヽᐤVector128ᐸfloatᐳㆍ8uᐤ  =>  new byte[79]{0x48,0x83,0xec,0x48,0xc5,0xf8,0x77,0xc5,0xf9,0x10,0x01,0xc5,0xf9,0x29,0x44,0x24,0x30,0x0f,0xb6,0xc2,0x83,0xf8,0x04,0x73,0x2c,0x48,0x8d,0x4c,0x24,0x30,0x48,0x63,0xc0,0xc5,0xfa,0x10,0x04,0x81,0xc5,0xfa,0x11,0x44,0x24,0x2c,0x8b,0x44,0x24,0x2c,0x25,0xff,0xff,0xff,0x7f,0x3d,0x00,0x00,0x80,0x7f,0x0f,0x9f,0xc0,0x0f,0xb6,0xc0,0x48,0x83,0xc4,0x48,0xc3,0xb9,0x15,0x00,0x00,0x00,0xe8,0x79,0xb7,0xff,0xfb};

        public static ReadOnlySpan<byte> IsNaNヽᐤVector128ᐸdoubleᐳㆍ8uᐤ  =>  new byte[96]{0x48,0x83,0xec,0x48,0xc5,0xf8,0x77,0xc5,0xf9,0x10,0x01,0xc5,0xf9,0x29,0x44,0x24,0x30,0x0f,0xb6,0xc2,0x83,0xf8,0x02,0x73,0x3d,0x48,0x8d,0x4c,0x24,0x30,0x48,0x63,0xc0,0xc5,0xfb,0x10,0x04,0xc1,0xc5,0xfb,0x11,0x44,0x24,0x28,0x48,0x8b,0x44,0x24,0x28,0x48,0xb9,0xff,0xff,0xff,0xff,0xff,0xff,0xff,0x7f,0x48,0x23,0xc1,0x48,0xb9,0x00,0x00,0x00,0x00,0x00,0x00,0xf0,0x7f,0x48,0x3b,0xc1,0x0f,0x9f,0xc0,0x0f,0xb6,0xc0,0x48,0x83,0xc4,0x48,0xc3,0xb9,0x15,0x00,0x00,0x00,0xe8,0xf8,0xb6,0xff,0xfb};

        public static ReadOnlySpan<byte> fpmodeヽᐤFpCmpModeᕀ8uᐤ  =>  new byte[9]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc1,0xc3};

    }
}