﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2021-12-01 21:34:44 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class cpu_gfscpu
    {
        public static ReadOnlySpan<byte> loadヽgᐸ32fᐳᐤ32fᐤ  =>  new byte[29]{0x50,0xc5,0xf8,0x77,0x90,0xc5,0xfa,0x11,0x4c,0x24,0x04,0xc5,0xfa,0x10,0x44,0x24,0x04,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> loadヽgᐸ64fᐳᐤ64fᐤ  =>  new byte[27]{0x50,0xc5,0xf8,0x77,0x90,0xc5,0xfb,0x11,0x0c,0x24,0xc5,0xfb,0x10,0x04,0x24,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> storeヽgᐸ32fᐳᐤVector128ᐸfloatᐳᐤ  =>  new byte[47]{0x50,0xc5,0xf8,0x77,0x33,0xc0,0x89,0x44,0x24,0x04,0xc5,0xf9,0x10,0x01,0xc5,0xf0,0x57,0xc9,0xc5,0xfa,0x11,0x4c,0x24,0x04,0xc5,0xfa,0x11,0x4c,0x24,0x04,0xc5,0xfa,0x11,0x44,0x24,0x04,0xc5,0xfa,0x10,0x44,0x24,0x04,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> storeヽgᐸ64fᐳᐤVector128ᐸdoubleᐳᐤ  =>  new byte[43]{0x50,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x04,0x24,0xc5,0xf9,0x10,0x01,0xc5,0xf0,0x57,0xc9,0xc5,0xfb,0x11,0x0c,0x24,0xc5,0xfb,0x11,0x0c,0x24,0xc5,0xfb,0x11,0x04,0x24,0xc5,0xfb,0x10,0x04,0x24,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> addヽgᐸ32fᐳᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳᐤ  =>  new byte[26]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x79,0x10,0x08,0xc5,0xfa,0x58,0xc1,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> addヽgᐸ64fᐳᐤVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳᐤ  =>  new byte[26]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x79,0x10,0x08,0xc5,0xfb,0x58,0xc1,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> subヽgᐸ32fᐳᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳᐤ  =>  new byte[26]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x79,0x10,0x08,0xc5,0xfa,0x5c,0xc1,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> subヽgᐸ64fᐳᐤVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳᐤ  =>  new byte[26]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x79,0x10,0x08,0xc5,0xfb,0x5c,0xc1,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> mulヽgᐸ32fᐳᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳᐤ  =>  new byte[26]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x79,0x10,0x08,0xc5,0xfa,0x59,0xc1,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> mulヽgᐸ64fᐳᐤVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳᐤ  =>  new byte[26]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x79,0x10,0x08,0xc5,0xfb,0x59,0xc1,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> divヽgᐸ32fᐳᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳᐤ  =>  new byte[26]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x79,0x10,0x08,0xc5,0xfa,0x5e,0xc1,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> divヽgᐸ64fᐳᐤVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳᐤ  =>  new byte[26]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x79,0x10,0x08,0xc5,0xfb,0x5e,0xc1,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> minヽgᐸ32fᐳᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳᐤ  =>  new byte[26]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x79,0x10,0x08,0xc5,0xfa,0x5d,0xc1,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> minヽgᐸ64fᐳᐤVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳᐤ  =>  new byte[26]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x79,0x10,0x08,0xc5,0xfb,0x5d,0xc1,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> maxヽgᐸ32fᐳᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳᐤ  =>  new byte[26]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x79,0x10,0x08,0xc5,0xfa,0x5f,0xc1,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> maxヽgᐸ64fᐳᐤVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳᐤ  =>  new byte[26]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x79,0x10,0x08,0xc5,0xfb,0x5f,0xc1,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> ceilヽgᐸ32fᐳᐤVector128ᐸfloatᐳᐤ  =>  new byte[23]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xe3,0x79,0x0a,0xc0,0x0a,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> ceilヽgᐸ64fᐳᐤVector128ᐸdoubleᐳᐤ  =>  new byte[23]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xe3,0x79,0x0b,0xc0,0x0a,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> floorヽgᐸ32fᐳᐤVector128ᐸfloatᐳᐤ  =>  new byte[23]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xe3,0x79,0x0a,0xc0,0x09,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> floorヽgᐸ64fᐳᐤVector128ᐸdoubleᐳᐤ  =>  new byte[23]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xe3,0x79,0x0b,0xc0,0x09,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> sqrtヽgᐸ32fᐳᐤVector128ᐸfloatᐳᐤ  =>  new byte[21]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc5,0xfa,0x51,0xc0,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> sqrtヽgᐸ64fᐳᐤVector128ᐸdoubleᐳᐤ  =>  new byte[21]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc5,0xfb,0x51,0xc0,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> fmaddヽgᐸ32fᐳᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳㆍVector128ᐸfloatᐳᐤ  =>  new byte[109]{0x56,0x48,0x83,0xec,0x60,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x50,0x48,0x89,0x44,0x24,0x58,0x48,0x8b,0xf1,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x79,0x10,0x08,0xc4,0xc1,0x79,0x10,0x11,0xc5,0xe0,0x57,0xdb,0xc5,0xf9,0x29,0x5c,0x24,0x50,0x48,0x8d,0x4c,0x24,0x50,0xc5,0xf9,0x29,0x44,0x24,0x40,0xc5,0xf9,0x29,0x4c,0x24,0x30,0xc5,0xf9,0x29,0x54,0x24,0x20,0x48,0x8d,0x54,0x24,0x40,0x4c,0x8d,0x44,0x24,0x30,0x4c,0x8d,0x4c,0x24,0x20,0xe8,0x96,0xfb,0xff,0xff,0xc5,0xf9,0x28,0x44,0x24,0x50,0xc5,0xf9,0x11,0x06,0x48,0x8b,0xc6,0x48,0x83,0xc4,0x60,0x5e,0xc3};

        public static ReadOnlySpan<byte> fmaddヽgᐸ64fᐳᐤVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳᐤ  =>  new byte[109]{0x56,0x48,0x83,0xec,0x60,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x50,0x48,0x89,0x44,0x24,0x58,0x48,0x8b,0xf1,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x79,0x10,0x08,0xc4,0xc1,0x79,0x10,0x11,0xc5,0xe0,0x57,0xdb,0xc5,0xf9,0x29,0x5c,0x24,0x50,0x48,0x8d,0x4c,0x24,0x50,0xc5,0xf9,0x29,0x44,0x24,0x40,0xc5,0xf9,0x29,0x4c,0x24,0x30,0xc5,0xf9,0x29,0x54,0x24,0x20,0x48,0x8d,0x54,0x24,0x40,0x4c,0x8d,0x44,0x24,0x30,0x4c,0x8d,0x4c,0x24,0x20,0xe8,0x36,0xfb,0xff,0xff,0xc5,0xf9,0x28,0x44,0x24,0x50,0xc5,0xf9,0x11,0x06,0x48,0x8b,0xc6,0x48,0x83,0xc4,0x60,0x5e,0xc3};

        public static ReadOnlySpan<byte> fmsubヽgᐸ32fᐳᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳㆍVector128ᐸfloatᐳᐤ  =>  new byte[32]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x79,0x10,0x08,0xc4,0xc1,0x79,0x10,0x11,0xc4,0xe2,0x71,0xab,0xc2,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> fmsubヽgᐸ64fᐳᐤVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳᐤ  =>  new byte[32]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x79,0x10,0x08,0xc4,0xc1,0x79,0x10,0x11,0xc4,0xe2,0xf1,0xab,0xc2,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> fnmaddヽgᐸ32fᐳᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳㆍVector128ᐸfloatᐳᐤ  =>  new byte[32]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x79,0x10,0x08,0xc4,0xc1,0x79,0x10,0x11,0xc4,0xe2,0x71,0xad,0xc2,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> fnmaddヽgᐸ64fᐳᐤVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳᐤ  =>  new byte[32]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x79,0x10,0x08,0xc4,0xc1,0x79,0x10,0x11,0xc4,0xe2,0xf1,0xad,0xc2,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> eqヽgᐸ32fᐳᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳᐤ  =>  new byte[31]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x01,0xc5,0xf9,0x10,0x0a,0xc5,0xf8,0x2e,0xc1,0x0f,0x9b,0xc2,0x0f,0x94,0xc0,0x22,0xc2,0x0f,0xb6,0xd0,0x8b,0xc2,0xc3};

        public static ReadOnlySpan<byte> eqヽgᐸ64fᐳᐤVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳᐤ  =>  new byte[31]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x01,0xc5,0xf9,0x10,0x0a,0xc5,0xf9,0x2e,0xc1,0x0f,0x9b,0xc2,0x0f,0x94,0xc0,0x22,0xc2,0x0f,0xb6,0xd0,0x8b,0xc2,0xc3};

        public static ReadOnlySpan<byte> neqヽgᐸ32fᐳᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳᐤ  =>  new byte[31]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x01,0xc5,0xf9,0x10,0x0a,0xc5,0xf8,0x2f,0xc1,0x0f,0x9a,0xc2,0x0f,0x95,0xc0,0x0a,0xc2,0x0f,0xb6,0xd0,0x8b,0xc2,0xc3};

        public static ReadOnlySpan<byte> neqヽgᐸ64fᐳᐤVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳᐤ  =>  new byte[31]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x01,0xc5,0xf9,0x10,0x0a,0xc5,0xf9,0x2f,0xc1,0x0f,0x9a,0xc2,0x0f,0x95,0xc0,0x0a,0xc2,0x0f,0xb6,0xd0,0x8b,0xc2,0xc3};

        public static ReadOnlySpan<byte> lteqヽgᐸ32fᐳᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳᐤ  =>  new byte[24]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x01,0xc5,0xf9,0x10,0x0a,0xc5,0xf8,0x2e,0xc8,0x0f,0x93,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> lteqヽgᐸ64fᐳᐤVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳᐤ  =>  new byte[24]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x01,0xc5,0xf9,0x10,0x0a,0xc5,0xf8,0x2e,0xc8,0x0f,0x93,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> ngtヽgᐸ32fᐳᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳᐤ  =>  new byte[49]{0x50,0xc5,0xf8,0x77,0x90,0xc5,0xf9,0x10,0x01,0xc5,0xf9,0x10,0x0a,0xc5,0xfa,0xc2,0xc1,0x02,0xc5,0xfa,0x11,0x44,0x24,0x04,0x8b,0x44,0x24,0x04,0x25,0xff,0xff,0xff,0x7f,0x3d,0x00,0x00,0x80,0x7f,0x0f,0x9f,0xc0,0x0f,0xb6,0xc0,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> ngtヽgᐸ64fᐳᐤVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳᐤ  =>  new byte[49]{0x50,0xc5,0xf8,0x77,0x90,0xc5,0xf9,0x10,0x01,0xc5,0xf9,0x10,0x0a,0xc5,0xfa,0xc2,0xc1,0x02,0xc5,0xfa,0x11,0x44,0x24,0x04,0x8b,0x44,0x24,0x04,0x25,0xff,0xff,0xff,0x7f,0x3d,0x00,0x00,0x80,0x7f,0x0f,0x9f,0xc0,0x0f,0xb6,0xc0,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> nltヽgᐸ32fᐳᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳᐤ  =>  new byte[49]{0x50,0xc5,0xf8,0x77,0x90,0xc5,0xf9,0x10,0x01,0xc5,0xf9,0x10,0x0a,0xc5,0xfa,0xc2,0xc1,0x05,0xc5,0xfa,0x11,0x44,0x24,0x04,0x8b,0x44,0x24,0x04,0x25,0xff,0xff,0xff,0x7f,0x3d,0x00,0x00,0x80,0x7f,0x0f,0x9f,0xc0,0x0f,0xb6,0xc0,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> nltヽgᐸ64fᐳᐤVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳᐤ  =>  new byte[49]{0x50,0xc5,0xf8,0x77,0x90,0xc5,0xf9,0x10,0x01,0xc5,0xf9,0x10,0x0a,0xc5,0xfa,0xc2,0xc1,0x05,0xc5,0xfa,0x11,0x44,0x24,0x04,0x8b,0x44,0x24,0x04,0x25,0xff,0xff,0xff,0x7f,0x3d,0x00,0x00,0x80,0x7f,0x0f,0x9f,0xc0,0x0f,0xb6,0xc0,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> gtヽgᐸ32fᐳᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳᐤ  =>  new byte[24]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x01,0xc5,0xf9,0x10,0x0a,0xc5,0xf8,0x2f,0xc1,0x0f,0x97,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> gtヽgᐸ64fᐳᐤVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳᐤ  =>  new byte[24]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x01,0xc5,0xf9,0x10,0x0a,0xc5,0xf9,0x2f,0xc1,0x0f,0x97,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> gteqヽgᐸ32fᐳᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳᐤ  =>  new byte[24]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x01,0xc5,0xf9,0x10,0x0a,0xc5,0xf8,0x2f,0xc1,0x0f,0x93,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> gteqヽgᐸ64fᐳᐤVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳᐤ  =>  new byte[24]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x01,0xc5,0xf9,0x10,0x0a,0xc5,0xf9,0x2f,0xc1,0x0f,0x93,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> ltヽgᐸ32fᐳᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳᐤ  =>  new byte[24]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x01,0xc5,0xf9,0x10,0x0a,0xc5,0xf8,0x2f,0xc8,0x0f,0x97,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> ltヽgᐸ64fᐳᐤVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳᐤ  =>  new byte[24]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x01,0xc5,0xf9,0x10,0x0a,0xc5,0xf9,0x2f,0xc8,0x0f,0x97,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> cmpヽgᐸ32fᐳᐤVector128ᐸfloatᐳㆍVector128ᐸfloatᐳㆍFpCmpModeᕀ8uᐤ  =>  new byte[87]{0x56,0x48,0x83,0xec,0x50,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x40,0x48,0x89,0x44,0x24,0x48,0x48,0x8b,0xf1,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x79,0x10,0x08,0x48,0x8d,0x4c,0x24,0x40,0xc5,0xf9,0x29,0x44,0x24,0x30,0xc5,0xf9,0x29,0x4c,0x24,0x20,0x48,0x8d,0x54,0x24,0x30,0x4c,0x8d,0x44,0x24,0x20,0x45,0x0f,0xb6,0xc9,0xe8,0x2c,0x0d,0xcf,0xfb,0xc5,0xf9,0x28,0x44,0x24,0x40,0xc5,0xf9,0x11,0x06,0x48,0x8b,0xc6,0x48,0x83,0xc4,0x50,0x5e,0xc3};

        public static ReadOnlySpan<byte> cmpヽgᐸ64fᐳᐤVector128ᐸdoubleᐳㆍVector128ᐸdoubleᐳㆍFpCmpModeᕀ8uᐤ  =>  new byte[87]{0x56,0x48,0x83,0xec,0x50,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x40,0x48,0x89,0x44,0x24,0x48,0x48,0x8b,0xf1,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x79,0x10,0x08,0x48,0x8d,0x4c,0x24,0x40,0xc5,0xf9,0x29,0x44,0x24,0x30,0xc5,0xf9,0x29,0x4c,0x24,0x20,0x48,0x8d,0x54,0x24,0x30,0x4c,0x8d,0x44,0x24,0x20,0x45,0x0f,0xb6,0xc9,0xe8,0xb4,0x0c,0xcf,0xfb,0xc5,0xf9,0x28,0x44,0x24,0x40,0xc5,0xf9,0x11,0x06,0x48,0x8b,0xc6,0x48,0x83,0xc4,0x50,0x5e,0xc3};

    }
}
