﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2021-11-14 3:49:56 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class lib_bit32
    {
        public static ReadOnlySpan<byte> ToCharヽᐤᐤ  =>  new byte[14]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0x01,0x83,0xc0,0x30,0x0f,0xb7,0xc0,0xc3};

        public static ReadOnlySpan<byte> Parseヽᐤcharᐤ  =>  new byte[18]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb7,0xc1,0x83,0xf8,0x31,0x0f,0x94,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> Fromヽᐤboolᐤ  =>  new byte[15]{0x0f,0x1f,0x44,0x00,0x00,0x89,0x4c,0x24,0x08,0x0f,0xb6,0x44,0x24,0x08,0xc3};

        public static ReadOnlySpan<byte> testヽᐤ8iㆍ8uᐤ  =>  new byte[22]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x0f,0xbe,0xc1,0x0f,0xb6,0xd2,0x0f,0xa3,0xd0,0x0f,0x92,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> testヽᐤ8uㆍ32iᐤ  =>  new byte[16]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc1,0x8b,0xca,0xd3,0xe8,0x83,0xe0,0x01,0xc3};

        public static ReadOnlySpan<byte> testヽᐤ16iㆍ32iᐤ  =>  new byte[19]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x0f,0xbf,0xc1,0x0f,0xa3,0xd0,0x0f,0x92,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> testヽᐤ16uㆍ32iᐤ  =>  new byte[16]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb7,0xc1,0x8b,0xca,0xd3,0xe8,0x83,0xe0,0x01,0xc3};

        public static ReadOnlySpan<byte> testヽᐤ32iㆍ32iᐤ  =>  new byte[15]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xa3,0xd1,0x0f,0x92,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> testヽᐤ64iㆍ32iᐤ  =>  new byte[16]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x0f,0xa3,0xd1,0x0f,0x92,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> testヽᐤ32uㆍ32iᐤ  =>  new byte[15]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0xc1,0x8b,0xca,0xd3,0xe8,0x83,0xe0,0x01,0xc3};

        public static ReadOnlySpan<byte> testヽᐤ64uㆍ32iᐤ  =>  new byte[17]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0xc1,0x8b,0xca,0x48,0xd3,0xe8,0x83,0xe0,0x01,0xc3};

        public static ReadOnlySpan<byte> setヽᐤ8iㆍ8uㆍBit32ᐤ  =>  new byte[46]{0x0f,0x1f,0x44,0x00,0x00,0x49,0x0f,0xbe,0xc0,0xf7,0xd0,0xff,0xc0,0x4c,0x0f,0xbe,0xc1,0x41,0x33,0xc0,0x0f,0xb6,0xca,0xba,0x01,0x00,0x00,0x00,0xd3,0xe2,0x23,0xc2,0x48,0x0f,0xbe,0xc0,0x41,0x33,0xc0,0x48,0x0f,0xbe,0xc8,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> setヽᐤ8uㆍ8uㆍBit32ᐤ  =>  new byte[44]{0x0f,0x1f,0x44,0x00,0x00,0x41,0x0f,0xb6,0xc0,0xf7,0xd0,0xff,0xc0,0x44,0x0f,0xb6,0xc1,0x41,0x33,0xc0,0x0f,0xb6,0xca,0xba,0x01,0x00,0x00,0x00,0xd3,0xe2,0x23,0xc2,0x0f,0xb6,0xc0,0x41,0x33,0xc0,0x0f,0xb6,0xc8,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> setヽᐤ16iㆍ8uㆍBit32ᐤ  =>  new byte[46]{0x0f,0x1f,0x44,0x00,0x00,0x49,0x0f,0xbf,0xc0,0xf7,0xd0,0xff,0xc0,0x4c,0x0f,0xbf,0xc1,0x41,0x33,0xc0,0x0f,0xb6,0xca,0xba,0x01,0x00,0x00,0x00,0xd3,0xe2,0x23,0xc2,0x48,0x0f,0xbf,0xc0,0x41,0x33,0xc0,0x48,0x0f,0xbf,0xc8,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> setヽᐤ16uㆍ8uㆍBit32ᐤ  =>  new byte[44]{0x0f,0x1f,0x44,0x00,0x00,0x41,0x0f,0xb7,0xc0,0xf7,0xd0,0xff,0xc0,0x44,0x0f,0xb7,0xc1,0x41,0x33,0xc0,0x0f,0xb6,0xca,0xba,0x01,0x00,0x00,0x00,0xd3,0xe2,0x23,0xc2,0x0f,0xb7,0xc0,0x41,0x33,0xc0,0x0f,0xb7,0xc8,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> setヽᐤ32iㆍ8uㆍBit32ᐤ  =>  new byte[32]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0xc1,0x41,0xf7,0xd0,0x41,0xff,0xc0,0x44,0x33,0xc0,0x0f,0xb6,0xca,0xba,0x01,0x00,0x00,0x00,0xd3,0xe2,0x41,0x23,0xd0,0x33,0xc2,0xc3};

        public static ReadOnlySpan<byte> setヽᐤ32uㆍ8uㆍBit32ᐤ  =>  new byte[32]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0xc1,0x41,0xf7,0xd0,0x41,0xff,0xc0,0x44,0x33,0xc0,0x0f,0xb6,0xca,0xba,0x01,0x00,0x00,0x00,0xd3,0xe2,0x41,0x23,0xd0,0x33,0xc2,0xc3};

        public static ReadOnlySpan<byte> setヽᐤ64iㆍ8uㆍBit32ᐤ  =>  new byte[41]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0xc1,0x41,0x8b,0xc8,0x4c,0x8b,0xc1,0x49,0xf7,0xd0,0x49,0xff,0xc0,0x4c,0x33,0xc0,0x0f,0xb6,0xca,0xba,0x01,0x00,0x00,0x00,0x48,0xd3,0xe2,0x49,0x23,0xd0,0x48,0x33,0xc2,0xc3};

        public static ReadOnlySpan<byte> setヽᐤ64uㆍ8uㆍBit32ᐤ  =>  new byte[41]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0xc1,0x41,0x8b,0xc8,0x4c,0x8b,0xc1,0x49,0xf7,0xd0,0x49,0xff,0xc0,0x4c,0x33,0xc0,0x0f,0xb6,0xca,0xba,0x01,0x00,0x00,0x00,0x48,0xd3,0xe2,0x49,0x23,0xd0,0x48,0x33,0xc2,0xc3};

        public static ReadOnlySpan<byte> identityヽᐤBit32ᐤ  =>  new byte[8]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> andヽᐤBit32ㆍBit32ᐤ  =>  new byte[10]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0xc1,0x23,0xc2,0xc3};

        public static ReadOnlySpan<byte> orヽᐤBit32ㆍBit32ᐤ  =>  new byte[10]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0xc1,0x0b,0xc2,0xc3};

        public static ReadOnlySpan<byte> xorヽᐤBit32ㆍBit32ᐤ  =>  new byte[10]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0xc1,0x33,0xc2,0xc3};

        public static ReadOnlySpan<byte> notヽᐤBit32ᐤ  =>  new byte[13]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0xc1,0xf7,0xd0,0x83,0xe0,0x01,0xc3};

        public static ReadOnlySpan<byte> nandヽᐤBit32ㆍBit32ᐤ  =>  new byte[15]{0x0f,0x1f,0x44,0x00,0x00,0x23,0xd1,0x8b,0xc2,0xf7,0xd0,0x83,0xe0,0x01,0xc3};

        public static ReadOnlySpan<byte> norヽᐤBit32ㆍBit32ᐤ  =>  new byte[15]{0x0f,0x1f,0x44,0x00,0x00,0x0b,0xd1,0x8b,0xc2,0xf7,0xd0,0x83,0xe0,0x01,0xc3};

        public static ReadOnlySpan<byte> xnorヽᐤBit32ㆍBit32ᐤ  =>  new byte[15]{0x0f,0x1f,0x44,0x00,0x00,0x33,0xd1,0x8b,0xc2,0xf7,0xd0,0x83,0xe0,0x01,0xc3};

        public static ReadOnlySpan<byte> implヽᐤBit32ㆍBit32ᐤ  =>  new byte[15]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0xc2,0xf7,0xd0,0x83,0xe0,0x01,0x0b,0xc1,0xc3};

        public static ReadOnlySpan<byte> nonimplヽᐤBit32ㆍBit32ᐤ  =>  new byte[15]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0xc1,0xf7,0xd0,0x83,0xe0,0x01,0x23,0xc2,0xc3};

        public static ReadOnlySpan<byte> cimplヽᐤBit32ㆍBit32ᐤ  =>  new byte[15]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0xc1,0xf7,0xd0,0x83,0xe0,0x01,0x0b,0xc2,0xc3};

        public static ReadOnlySpan<byte> cnonimplヽᐤBit32ㆍBit32ᐤ  =>  new byte[15]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0xc2,0xf7,0xd0,0x83,0xe0,0x01,0x23,0xc1,0xc3};

        public static ReadOnlySpan<byte> selectヽᐤBit32ㆍBit32ㆍBit32ᐤ  =>  new byte[20]{0x0f,0x1f,0x44,0x00,0x00,0x23,0xd1,0x8b,0xc1,0xf7,0xd0,0x41,0x23,0xc0,0x0b,0xc2,0x83,0xe0,0x01,0xc3};

        public static ReadOnlySpan<byte> op_TrueヽᐤBit32ᐤ  =>  new byte[14]{0x0f,0x1f,0x44,0x00,0x00,0x85,0xc9,0x0f,0x95,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> op_FalseヽᐤBit32ᐤ  =>  new byte[14]{0x0f,0x1f,0x44,0x00,0x00,0x85,0xc9,0x0f,0x94,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> op_implicit_bool_Bit32  =>  new byte[9]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc1,0xc3};

        public static ReadOnlySpan<byte> op_implicit_Bit32_bool  =>  new byte[14]{0x0f,0x1f,0x44,0x00,0x00,0x85,0xc9,0x0f,0x95,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> op_explicit_Bit32_8u  =>  new byte[9]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc1,0xc3};

        public static ReadOnlySpan<byte> op_explicit_Bit32_8i  =>  new byte[10]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x0f,0xbe,0xc1,0xc3};

        public static ReadOnlySpan<byte> op_explicit_8u_Bit32  =>  new byte[12]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc1,0x83,0xe0,0x01,0xc3};

        public static ReadOnlySpan<byte> op_explicit_Bit32_16u  =>  new byte[9]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb7,0xc1,0xc3};

        public static ReadOnlySpan<byte> op_explicit_Bit32_16i  =>  new byte[10]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x0f,0xbf,0xc1,0xc3};

        public static ReadOnlySpan<byte> op_explicit_16u_Bit32  =>  new byte[12]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb7,0xc1,0x83,0xe0,0x01,0xc3};

        public static ReadOnlySpan<byte> op_explicit_Bit32_32i  =>  new byte[8]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> op_implicit_32i_Bit32  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0xc1,0x83,0xe0,0x01,0xc3};

        public static ReadOnlySpan<byte> op_explicit_Bit32_32u  =>  new byte[8]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> op_explicit_Bit32_64i  =>  new byte[8]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> op_explicit_Bit32_32f  =>  new byte[21]{0xc5,0xf8,0x77,0x66,0x90,0x8b,0xc1,0xc5,0xf8,0x57,0xc0,0xc4,0xe1,0xfb,0x2a,0xc0,0xc5,0xfb,0x5a,0xc0,0xc3};

        public static ReadOnlySpan<byte> op_explicit_Bit32_64f  =>  new byte[17]{0xc5,0xf8,0x77,0x66,0x90,0x8b,0xc1,0xc5,0xf8,0x57,0xc0,0xc4,0xe1,0xfb,0x2a,0xc0,0xc3};

        public static ReadOnlySpan<byte> op_explicit_32u_Bit32  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0xc1,0x83,0xe0,0x01,0xc3};

        public static ReadOnlySpan<byte> op_explicit_Bit32_64u  =>  new byte[8]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> op_implicit_BitStateᕀ8u_Bit32  =>  new byte[9]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc1,0xc3};

        public static ReadOnlySpan<byte> op_implicit_Bit32_BitStateᕀ8u  =>  new byte[9]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc1,0xc3};

        public static ReadOnlySpan<byte> op_implicit_Bit32_bit  =>  new byte[17]{0x0f,0x1f,0x44,0x00,0x00,0x85,0xc9,0x0f,0x95,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> op_explicit_64u_Bit32  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0xc1,0x83,0xe0,0x01,0xc3};

        public static ReadOnlySpan<byte> EqualsヽᐤBit32ᐤ  =>  new byte[14]{0x0f,0x1f,0x44,0x00,0x00,0x39,0x11,0x0f,0x94,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> Wrapヽᐤ32uᐤ  =>  new byte[8]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> SafeWrapヽᐤ8uᐤ  =>  new byte[12]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc1,0x83,0xe0,0x01,0xc3};

        public static ReadOnlySpan<byte> SafeWrapヽᐤ16uᐤ  =>  new byte[12]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb7,0xc1,0x83,0xe0,0x01,0xc3};

        public static ReadOnlySpan<byte> SafeWrapヽᐤ32uᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0xc1,0x83,0xe0,0x01,0xc3};

        public static ReadOnlySpan<byte> SafeWrapヽᐤ32iᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0xc1,0x83,0xe0,0x01,0xc3};

        public static ReadOnlySpan<byte> SafeWrapヽᐤ64uᐤ  =>  new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0xc1,0x83,0xe0,0x01,0xc3};

        public static ReadOnlySpan<byte> genericヽgᐸ8uᐳᐤBit32ᐤ  =>  new byte[16]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x89,0x4c,0x24,0x08,0x0f,0xb6,0x44,0x24,0x08,0xc3};

        public static ReadOnlySpan<byte> genericヽgᐸ8iᐳᐤBit32ᐤ  =>  new byte[17]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x89,0x4c,0x24,0x08,0x48,0x0f,0xbe,0x44,0x24,0x08,0xc3};

        public static ReadOnlySpan<byte> genericヽgᐸ16uᐳᐤBit32ᐤ  =>  new byte[16]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x89,0x4c,0x24,0x08,0x0f,0xb7,0x44,0x24,0x08,0xc3};

        public static ReadOnlySpan<byte> genericヽgᐸ16iᐳᐤBit32ᐤ  =>  new byte[17]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x89,0x4c,0x24,0x08,0x48,0x0f,0xbf,0x44,0x24,0x08,0xc3};

        public static ReadOnlySpan<byte> genericヽgᐸ32uᐳᐤBit32ᐤ  =>  new byte[8]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> genericヽgᐸ32iᐳᐤBit32ᐤ  =>  new byte[8]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> genericヽgᐸ64uᐳᐤBit32ᐤ  =>  new byte[16]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x89,0x4c,0x24,0x08,0x48,0x8b,0x44,0x24,0x08,0xc3};

        public static ReadOnlySpan<byte> genericヽgᐸ64iᐳᐤBit32ᐤ  =>  new byte[16]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x89,0x4c,0x24,0x08,0x48,0x8b,0x44,0x24,0x08,0xc3};

        public static ReadOnlySpan<byte> genericヽgᐸ32fᐳᐤBit32ᐤ  =>  new byte[17]{0xc5,0xf8,0x77,0x66,0x90,0x48,0x89,0x4c,0x24,0x08,0xc5,0xfa,0x10,0x44,0x24,0x08,0xc3};

        public static ReadOnlySpan<byte> genericヽgᐸ64fᐳᐤBit32ᐤ  =>  new byte[17]{0xc5,0xf8,0x77,0x66,0x90,0x48,0x89,0x4c,0x24,0x08,0xc5,0xfb,0x10,0x44,0x24,0x08,0xc3};

        public static ReadOnlySpan<byte> specificヽgᐸ8uᐳᐤ8uᐤ  =>  new byte[17]{0x0f,0x1f,0x44,0x00,0x00,0x89,0x4c,0x24,0x08,0x8b,0x44,0x24,0x08,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> specificヽgᐸ8iᐳᐤ8iᐤ  =>  new byte[18]{0x0f,0x1f,0x44,0x00,0x00,0x89,0x4c,0x24,0x08,0x8b,0x44,0x24,0x08,0x48,0x0f,0xbe,0xc0,0xc3};

        public static ReadOnlySpan<byte> specificヽgᐸ16uᐳᐤ16uᐤ  =>  new byte[17]{0x0f,0x1f,0x44,0x00,0x00,0x89,0x4c,0x24,0x08,0x8b,0x44,0x24,0x08,0x0f,0xb7,0xc0,0xc3};

        public static ReadOnlySpan<byte> specificヽgᐸ16iᐳᐤ16iᐤ  =>  new byte[18]{0x0f,0x1f,0x44,0x00,0x00,0x89,0x4c,0x24,0x08,0x8b,0x44,0x24,0x08,0x48,0x0f,0xbf,0xc0,0xc3};

        public static ReadOnlySpan<byte> specificヽgᐸ32uᐳᐤ32uᐤ  =>  new byte[8]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> specificヽgᐸ32iᐳᐤ32iᐤ  =>  new byte[8]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> specificヽgᐸ64uᐳᐤ64uᐤ  =>  new byte[15]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x89,0x4c,0x24,0x08,0x8b,0x44,0x24,0x08,0xc3};

        public static ReadOnlySpan<byte> specificヽgᐸ64iᐳᐤ64iᐤ  =>  new byte[15]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x89,0x4c,0x24,0x08,0x8b,0x44,0x24,0x08,0xc3};

        public static ReadOnlySpan<byte> specificヽgᐸ32fᐳᐤ32fᐤ  =>  new byte[16]{0x0f,0x1f,0x44,0x00,0x00,0xc5,0xfa,0x11,0x44,0x24,0x08,0x8b,0x44,0x24,0x08,0xc3};

        public static ReadOnlySpan<byte> specificヽgᐸ64fᐳᐤ64fᐤ  =>  new byte[16]{0x0f,0x1f,0x44,0x00,0x00,0xc5,0xfb,0x11,0x44,0x24,0x08,0x8b,0x44,0x24,0x08,0xc3};

    }
}
