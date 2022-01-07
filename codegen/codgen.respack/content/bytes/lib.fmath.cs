﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2022-01-07 15:36:31 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class lib_fmath
    {
        public static ReadOnlySpan<byte> decヽᐤ32fᐤ  =>  new byte[14]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfa,0x5c,0x05,0x03,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> decヽᐤ64fᐤ  =>  new byte[14]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfb,0x5c,0x05,0x03,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> incヽᐤ32fᐤ  =>  new byte[14]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfa,0x58,0x05,0x03,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> incヽᐤ64fᐤ  =>  new byte[14]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfb,0x58,0x05,0x03,0x00,0x00,0x00,0xc3};

        public static ReadOnlySpan<byte> negateヽᐤ32fᐤ  =>  new byte[18]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfa,0x10,0x0d,0x0b,0x00,0x00,0x00,0xc5,0xf8,0x57,0xc1,0xc3};

        public static ReadOnlySpan<byte> negateヽᐤ64fᐤ  =>  new byte[18]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfb,0x10,0x0d,0x0b,0x00,0x00,0x00,0xc5,0xf8,0x57,0xc1,0xc3};

        public static ReadOnlySpan<byte> addヽᐤ32fㆍ32fᐤ  =>  new byte[10]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfa,0x58,0xc1,0xc3};

        public static ReadOnlySpan<byte> addヽᐤ64fㆍ64fᐤ  =>  new byte[10]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfb,0x58,0xc1,0xc3};

        public static ReadOnlySpan<byte> subヽᐤ32fㆍ32fᐤ  =>  new byte[10]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfa,0x5c,0xc1,0xc3};

        public static ReadOnlySpan<byte> subヽᐤ64fㆍ64fᐤ  =>  new byte[10]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfb,0x5c,0xc1,0xc3};

        public static ReadOnlySpan<byte> mulヽᐤ32fㆍ32fᐤ  =>  new byte[10]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfa,0x59,0xc1,0xc3};

        public static ReadOnlySpan<byte> mulヽᐤ64fㆍ64fᐤ  =>  new byte[10]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfb,0x59,0xc1,0xc3};

        public static ReadOnlySpan<byte> divヽᐤ32fㆍ32fᐤ  =>  new byte[10]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfa,0x5e,0xc1,0xc3};

        public static ReadOnlySpan<byte> divヽᐤ64fㆍ64fᐤ  =>  new byte[10]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfb,0x5e,0xc1,0xc3};

        public static ReadOnlySpan<byte> modヽᐤ32fㆍ32fᐤ  =>  new byte[18]{0x48,0x83,0xec,0x28,0xc5,0xf8,0x77,0xe8,0xe4,0x3a,0xb2,0x5b,0x90,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> modヽᐤ64fㆍ64fᐤ  =>  new byte[18]{0x48,0x83,0xec,0x28,0xc5,0xf8,0x77,0xe8,0x24,0x3a,0xb2,0x5b,0x90,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> modmulヽᐤ32fㆍ32fㆍ32fᐤ  =>  new byte[26]{0x48,0x83,0xec,0x28,0xc5,0xf8,0x77,0xc5,0xfa,0x59,0xc1,0xc5,0xf8,0x28,0xca,0xe8,0x7c,0x3a,0xb2,0x5b,0x90,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> modmulヽᐤ64fㆍ64fㆍ64fᐤ  =>  new byte[26]{0x48,0x83,0xec,0x28,0xc5,0xf8,0x77,0xc5,0xfb,0x59,0xc1,0xc5,0xf8,0x28,0xca,0xe8,0xbc,0x39,0xb2,0x5b,0x90,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> divmodヽᐤ32fㆍ32fᐤ  =>  new byte[70]{0x48,0x83,0xec,0x48,0xc5,0xf8,0x77,0xc5,0xf8,0x29,0x74,0x24,0x30,0xc5,0xf8,0x28,0xf0,0xc5,0xca,0x5e,0xf1,0xe8,0x16,0x3a,0xb2,0x5b,0xc5,0xf0,0x57,0xc9,0xc5,0xfa,0x11,0x4c,0x24,0x28,0xc5,0xfa,0x11,0x4c,0x24,0x2c,0xc5,0xfa,0x11,0x74,0x24,0x28,0xc5,0xfa,0x11,0x44,0x24,0x2c,0x48,0x8b,0x44,0x24,0x28,0xc5,0xf8,0x28,0x74,0x24,0x30,0x48,0x83,0xc4,0x48,0xc3};

        public static ReadOnlySpan<byte> divmodヽᐤ64fㆍ64fᐤ  =>  new byte[62]{0x56,0x48,0x83,0xec,0x30,0xc5,0xf8,0x77,0xc5,0xf8,0x29,0x74,0x24,0x20,0x48,0x8b,0xf1,0xc5,0xf8,0x28,0xf1,0xc5,0xcb,0x5e,0xf2,0xc5,0xf8,0x28,0xc1,0xc5,0xf8,0x28,0xca,0xe8,0x0a,0x35,0xb2,0x5b,0xc5,0xfb,0x11,0x36,0xc5,0xfb,0x11,0x46,0x08,0x48,0x8b,0xc6,0xc5,0xf8,0x28,0x74,0x24,0x20,0x48,0x83,0xc4,0x30,0x5e,0xc3};

        public static ReadOnlySpan<byte> ceilヽᐤ32fᐤ  =>  new byte[12]{0xc5,0xf8,0x77,0x66,0x90,0xc4,0xe3,0x79,0x0a,0xc0,0x0a,0xc3};

        public static ReadOnlySpan<byte> ceilヽᐤ64fᐤ  =>  new byte[12]{0xc5,0xf8,0x77,0x66,0x90,0xc4,0xe3,0x79,0x0b,0xc0,0x0a,0xc3};

        public static ReadOnlySpan<byte> floorヽᐤ32fᐤ  =>  new byte[12]{0xc5,0xf8,0x77,0x66,0x90,0xc4,0xe3,0x79,0x0a,0xc0,0x09,0xc3};

        public static ReadOnlySpan<byte> floorヽᐤ64fᐤ  =>  new byte[12]{0xc5,0xf8,0x77,0x66,0x90,0xc4,0xe3,0x79,0x0b,0xc0,0x09,0xc3};

        public static ReadOnlySpan<byte> clampヽᐤ32fㆍ32fᐤ  =>  new byte[17]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf8,0x2e,0xc1,0x77,0x01,0xc3,0xc5,0xf8,0x28,0xc1,0xc3};

        public static ReadOnlySpan<byte> clampヽᐤ64fㆍ64fᐤ  =>  new byte[17]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x2e,0xc1,0x77,0x01,0xc3,0xc5,0xf8,0x28,0xc1,0xc3};

        public static ReadOnlySpan<byte> distヽᐤ32fㆍ32fᐤ  =>  new byte[25]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf8,0x2e,0xc1,0x73,0x09,0xc5,0xf2,0x5c,0xc8,0xc5,0xf8,0x28,0xc1,0xc3,0xc5,0xfa,0x5c,0xc1,0xc3};

        public static ReadOnlySpan<byte> distヽᐤ64fㆍ64fᐤ  =>  new byte[25]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x2e,0xc1,0x73,0x09,0xc5,0xf3,0x5c,0xc8,0xc5,0xf8,0x28,0xc1,0xc3,0xc5,0xfb,0x5c,0xc1,0xc3};

        public static ReadOnlySpan<byte> dividesヽᐤ32fㆍ32fᐤ  =>  new byte[48]{0x48,0x83,0xec,0x28,0xc5,0xf8,0x77,0xc5,0xf8,0x28,0xd0,0xc5,0xf8,0x28,0xc1,0xc5,0xf8,0x28,0xca,0xe8,0x08,0x34,0xb2,0x5b,0xc5,0xf0,0x57,0xc9,0xc5,0xf8,0x2e,0xc1,0x0f,0x9b,0xc0,0x7a,0x03,0x0f,0x94,0xc0,0x0f,0xb6,0xc0,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> dividesヽᐤ64fㆍ64fᐤ  =>  new byte[48]{0x48,0x83,0xec,0x28,0xc5,0xf8,0x77,0xc5,0xf8,0x28,0xd0,0xc5,0xf8,0x28,0xc1,0xc5,0xf8,0x28,0xca,0xe8,0x28,0x33,0xb2,0x5b,0xc5,0xf0,0x57,0xc9,0xc5,0xf9,0x2e,0xc1,0x0f,0x9b,0xc0,0x7a,0x03,0x0f,0x94,0xc0,0x0f,0xb6,0xc0,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> fmaヽᐤ32fㆍ32fㆍ32fᐤ  =>  new byte[11]{0xc5,0xf8,0x77,0x66,0x90,0xc4,0xe2,0x71,0xa9,0xc2,0xc3};

        public static ReadOnlySpan<byte> fmaヽᐤ64fㆍ64fㆍ64fᐤ  =>  new byte[11]{0xc5,0xf8,0x77,0x66,0x90,0xc4,0xe2,0xf1,0xa9,0xc2,0xc3};

        public static ReadOnlySpan<byte> fmodヽᐤ32fㆍ32fᐤ  =>  new byte[18]{0xc5,0xf8,0x77,0x66,0x90,0x48,0xb8,0x30,0x9d,0x4f,0x68,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> fmodヽᐤ64fㆍ64fᐤ  =>  new byte[18]{0xc5,0xf8,0x77,0x66,0x90,0x48,0xb8,0x70,0x75,0xdf,0x67,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> roundヽᐤ32fㆍ32iᐤ  =>  new byte[21]{0xc5,0xf8,0x77,0x66,0x90,0x45,0x33,0xc0,0x48,0xb8,0x78,0x9d,0x4f,0x68,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> roundヽᐤ64fㆍ32iᐤ  =>  new byte[21]{0xc5,0xf8,0x77,0x66,0x90,0x45,0x33,0xc0,0x48,0xb8,0x78,0x76,0xdf,0x67,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> signumヽᐤ32fᐤ  =>  new byte[21]{0x48,0x83,0xec,0x28,0xc5,0xf8,0x77,0xe8,0xf4,0x93,0xb5,0xfe,0x48,0x0f,0xbe,0xc0,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> signumヽᐤ64fᐤ  =>  new byte[21]{0x48,0x83,0xec,0x28,0xc5,0xf8,0x77,0xe8,0x9c,0x93,0xb5,0xfe,0x48,0x0f,0xbe,0xc0,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> squareヽᐤ32fᐤ  =>  new byte[10]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfa,0x59,0xc0,0xc3};

        public static ReadOnlySpan<byte> squareヽᐤ64fᐤ  =>  new byte[10]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfb,0x59,0xc0,0xc3};

        public static ReadOnlySpan<byte> sqrtヽᐤ32fᐤ  =>  new byte[10]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfa,0x51,0xc0,0xc3};

        public static ReadOnlySpan<byte> sqrtヽᐤ64fᐤ  =>  new byte[10]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfb,0x51,0xc0,0xc3};

        public static ReadOnlySpan<byte> absヽᐤ32fᐤ  =>  new byte[18]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfa,0x10,0x0d,0x0b,0x00,0x00,0x00,0xc5,0xf8,0x54,0xc1,0xc3};

        public static ReadOnlySpan<byte> absヽᐤ64fᐤ  =>  new byte[18]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfb,0x10,0x0d,0x0b,0x00,0x00,0x00,0xc5,0xf8,0x54,0xc1,0xc3};

        public static ReadOnlySpan<byte> positiveヽᐤ32fᐤ  =>  new byte[23]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf0,0x57,0xc9,0xc5,0xf8,0x2e,0xc1,0x0f,0x97,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> positiveヽᐤ64fᐤ  =>  new byte[23]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf0,0x57,0xc9,0xc5,0xf9,0x2e,0xc1,0x0f,0x97,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> negativeヽᐤ32fᐤ  =>  new byte[23]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf0,0x57,0xc9,0xc5,0xf8,0x2e,0xc8,0x0f,0x97,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> negativeヽᐤ64fᐤ  =>  new byte[23]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf0,0x57,0xc9,0xc5,0xf9,0x2e,0xc8,0x0f,0x97,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> eqヽᐤ32fㆍ32fᐤ  =>  new byte[24]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf8,0x2e,0xc1,0x0f,0x9b,0xc0,0x7a,0x03,0x0f,0x94,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> eqヽᐤ64fㆍ64fᐤ  =>  new byte[24]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x2e,0xc1,0x0f,0x9b,0xc0,0x7a,0x03,0x0f,0x94,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> neqヽᐤ32fㆍ32fᐤ  =>  new byte[24]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf8,0x2e,0xc1,0x0f,0x9a,0xc0,0x7a,0x03,0x0f,0x95,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> neqヽᐤ64fㆍ64fᐤ  =>  new byte[24]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x2e,0xc1,0x0f,0x9a,0xc0,0x7a,0x03,0x0f,0x95,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> gtヽᐤ32fㆍ32fᐤ  =>  new byte[19]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf8,0x2e,0xc1,0x0f,0x97,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> gtヽᐤ64fㆍ64fᐤ  =>  new byte[19]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x2e,0xc1,0x0f,0x97,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> gteqヽᐤ32fㆍ32fᐤ  =>  new byte[19]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf8,0x2e,0xc1,0x0f,0x93,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> gteqヽᐤ64fㆍ64fᐤ  =>  new byte[19]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x2e,0xc1,0x0f,0x93,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> ltヽᐤ32fㆍ32fᐤ  =>  new byte[19]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf8,0x2e,0xc8,0x0f,0x97,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> ltヽᐤ64fㆍ64fᐤ  =>  new byte[19]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x2e,0xc8,0x0f,0x97,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> lteqヽᐤ32fㆍ32fᐤ  =>  new byte[19]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf8,0x2e,0xc8,0x0f,0x93,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> lteqヽᐤ64fㆍ64fᐤ  =>  new byte[19]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x2e,0xc8,0x0f,0x93,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> nonzヽᐤ32fᐤ  =>  new byte[28]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf0,0x57,0xc9,0xc5,0xf8,0x2e,0xc1,0x0f,0x9a,0xc0,0x7a,0x03,0x0f,0x95,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> nonzヽᐤ64fᐤ  =>  new byte[28]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf0,0x57,0xc9,0xc5,0xf9,0x2e,0xc1,0x0f,0x9a,0xc0,0x7a,0x03,0x0f,0x95,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> nonzヽᐤ32fㆍ32fᐤ  =>  new byte[23]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xe8,0x57,0xd2,0xc5,0xf8,0x2e,0xc2,0x7a,0x03,0x75,0x01,0xc3,0xc5,0xf8,0x28,0xc1,0xc3};

        public static ReadOnlySpan<byte> nonzヽᐤ64fㆍ64fᐤ  =>  new byte[23]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xe8,0x57,0xd2,0xc5,0xf9,0x2e,0xc2,0x7a,0x03,0x75,0x01,0xc3,0xc5,0xf8,0x28,0xc1,0xc3};

        public static ReadOnlySpan<byte> maxヽᐤ32fㆍ32fᐤ  =>  new byte[17]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf8,0x2e,0xc1,0x77,0x05,0xc5,0xf8,0x28,0xc1,0xc3,0xc3};

        public static ReadOnlySpan<byte> maxヽᐤ64fㆍ64fᐤ  =>  new byte[17]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x2e,0xc1,0x77,0x05,0xc5,0xf8,0x28,0xc1,0xc3,0xc3};

        public static ReadOnlySpan<byte> minヽᐤ32fㆍ32fᐤ  =>  new byte[17]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf8,0x2e,0xc8,0x77,0x05,0xc5,0xf8,0x28,0xc1,0xc3,0xc3};

        public static ReadOnlySpan<byte> minヽᐤ64fㆍ64fᐤ  =>  new byte[17]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x2e,0xc8,0x77,0x05,0xc5,0xf8,0x28,0xc1,0xc3,0xc3};

        public static ReadOnlySpan<byte> widthヽᐤ32fㆍ32fᐤ  =>  new byte[30]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf2,0x5a,0xc9,0xc5,0xfa,0x5a,0xc0,0xc5,0xf3,0x5c,0xc8,0xc5,0xfb,0x10,0x05,0x0f,0x00,0x00,0x00,0xc5,0xf8,0x54,0xc1,0xc3};

        public static ReadOnlySpan<byte> widthヽᐤ64fㆍ64fᐤ  =>  new byte[22]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf3,0x5c,0xc8,0xc5,0xfb,0x10,0x05,0x0f,0x00,0x00,0x00,0xc5,0xf8,0x54,0xc1,0xc3};

        public static ReadOnlySpan<byte> withinヽᐤ32fㆍ32fㆍ32fᐤ  =>  new byte[48]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf8,0x2e,0xc1,0x77,0x10,0xc5,0xf2,0x5c,0xc8,0xc5,0xf8,0x2e,0xd1,0x0f,0x93,0xc0,0x0f,0xb6,0xc0,0xeb,0x0e,0xc5,0xfa,0x5c,0xc1,0xc5,0xf8,0x2e,0xd0,0x0f,0x93,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> withinヽᐤ64fㆍ64fㆍ64fᐤ  =>  new byte[48]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x2e,0xc1,0x77,0x10,0xc5,0xf3,0x5c,0xc8,0xc5,0xf9,0x2e,0xd1,0x0f,0x93,0xc0,0x0f,0xb6,0xc0,0xeb,0x0e,0xc5,0xfb,0x5c,0xc1,0xc5,0xf9,0x2e,0xd0,0x0f,0x93,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> betweenヽᐤ32fㆍ32fㆍ32fᐤ  =>  new byte[32]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf8,0x2e,0xc1,0x72,0x0c,0xc5,0xf8,0x2e,0xd0,0x0f,0x93,0xc0,0x0f,0xb6,0xc0,0xeb,0x02,0x33,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> betweenヽᐤ64fㆍ64fㆍ64fᐤ  =>  new byte[32]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x2e,0xc1,0x72,0x0c,0xc5,0xf9,0x2e,0xd0,0x0f,0x93,0xc0,0x0f,0xb6,0xc0,0xeb,0x02,0x33,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> fcmpヽᐤ32fㆍ32fㆍFpCmpModeᕀ8uᐤ  =>  new byte[453]{0x56,0x48,0x83,0xec,0x20,0xc5,0xf8,0x77,0x41,0x0f,0xb6,0xc0,0x83,0xf8,0x1e,0x0f,0x87,0x8e,0x01,0x00,0x00,0x8b,0xc0,0x48,0x8d,0x0d,0xc2,0x01,0x00,0x00,0x8b,0x0c,0x81,0x48,0x8d,0x15,0xe0,0xff,0xff,0xff,0x48,0x03,0xca,0xff,0xe1,0xc5,0xf8,0x2e,0xc1,0x0f,0x9b,0xc0,0x7a,0x03,0x0f,0x94,0xc0,0x0f,0xb6,0xc0,0xe9,0x5c,0x01,0x00,0x00,0xc5,0xf8,0x2e,0xc1,0x0f,0x9b,0xc0,0x7a,0x03,0x0f,0x94,0xc0,0x0f,0xb6,0xc0,0xe9,0x48,0x01,0x00,0x00,0xc5,0xf8,0x2e,0xc1,0x0f,0x9b,0xc0,0x7a,0x03,0x0f,0x94,0xc0,0x0f,0xb6,0xc0,0xe9,0x34,0x01,0x00,0x00,0xc5,0xf8,0x2e,0xc1,0x0f,0x9b,0xc0,0x7a,0x03,0x0f,0x94,0xc0,0x0f,0xb6,0xc0,0xe9,0x20,0x01,0x00,0x00,0xc5,0xf8,0x2e,0xc1,0x0f,0x9a,0xc0,0x7a,0x03,0x0f,0x95,0xc0,0x0f,0xb6,0xc0,0xe9,0x0c,0x01,0x00,0x00,0xc5,0xf8,0x2e,0xc1,0x0f,0x9a,0xc0,0x7a,0x03,0x0f,0x95,0xc0,0x0f,0xb6,0xc0,0xe9,0xf8,0x00,0x00,0x00,0xc5,0xf8,0x2e,0xc1,0x0f,0x9a,0xc0,0x7a,0x03,0x0f,0x95,0xc0,0x0f,0xb6,0xc0,0xe9,0xe4,0x00,0x00,0x00,0xc5,0xf8,0x2e,0xc1,0x0f,0x9a,0xc0,0x7a,0x03,0x0f,0x95,0xc0,0x0f,0xb6,0xc0,0xe9,0xd0,0x00,0x00,0x00,0xc5,0xf8,0x2e,0xc8,0x0f,0x97,0xc0,0x0f,0xb6,0xc0,0xe9,0xc1,0x00,0x00,0x00,0xc5,0xf8,0x2e,0xc8,0x0f,0x97,0xc0,0x0f,0xb6,0xc0,0xe9,0xb2,0x00,0x00,0x00,0xc5,0xf8,0x2e,0xc1,0x0f,0x97,0xc0,0x0f,0xb6,0xc0,0xe9,0xa3,0x00,0x00,0x00,0xc5,0xf8,0x2e,0xc1,0x0f,0x97,0xc0,0x0f,0xb6,0xc0,0xe9,0x94,0x00,0x00,0x00,0xc5,0xf8,0x2e,0xc8,0x0f,0x93,0xc0,0x0f,0xb6,0xc0,0xe9,0x85,0x00,0x00,0x00,0xc5,0xf8,0x2e,0xc8,0x0f,0x93,0xc0,0x0f,0xb6,0xc0,0xe9,0x76,0x00,0x00,0x00,0xc5,0xf8,0x2e,0xc1,0x0f,0x93,0xc0,0x0f,0xb6,0xc0,0xeb,0x6a,0xc5,0xf8,0x2e,0xc1,0x0f,0x93,0xc0,0x0f,0xb6,0xc0,0xeb,0x5e,0xc5,0xf8,0x2e,0xc1,0x0f,0x92,0xc0,0x0f,0xb6,0xc0,0xeb,0x52,0xc5,0xf8,0x2e,0xc1,0x0f,0x92,0xc0,0x0f,0xb6,0xc0,0xeb,0x46,0xc5,0xf8,0x2e,0xc1,0x0f,0x96,0xc0,0x0f,0xb6,0xc0,0xeb,0x3a,0xc5,0xf8,0x2e,0xc1,0x0f,0x96,0xc0,0x0f,0xb6,0xc0,0xeb,0x2e,0xc5,0xf8,0x2e,0xc8,0x0f,0x92,0xc0,0x0f,0xb6,0xc0,0xeb,0x22,0xc5,0xf8,0x2e,0xc8,0x0f,0x92,0xc0,0x0f,0xb6,0xc0,0xeb,0x16,0xc5,0xf8,0x2e,0xc8,0x0f,0x96,0xc0,0x0f,0xb6,0xc0,0xeb,0x0a,0xc5,0xf8,0x2e,0xc8,0x0f,0x96,0xc0,0x0f,0xb6,0xc0,0x48,0x83,0xc4,0x20,0x5e,0xc3,0x48,0xb9,0xd8,0xd3,0x42,0x65,0xfb,0x7f,0x00,0x00,0xe8,0x7e,0x8c,0x9f,0x5b,0x48,0x8b,0xf0,0x48,0x8b,0xce,0xe8,0xab,0x39,0xed,0xfb,0x48,0x8b,0xce,0xe8,0xbb,0xc8,0x9b,0x5b};

        public static ReadOnlySpan<byte> fcmpヽᐤ64fㆍ64fㆍFpCmpModeᕀ8uᐤ  =>  new byte[453]{0x56,0x48,0x83,0xec,0x20,0xc5,0xf8,0x77,0x41,0x0f,0xb6,0xc0,0x83,0xf8,0x1e,0x0f,0x87,0x8e,0x01,0x00,0x00,0x8b,0xc0,0x48,0x8d,0x0d,0xc2,0x01,0x00,0x00,0x8b,0x0c,0x81,0x48,0x8d,0x15,0xe0,0xff,0xff,0xff,0x48,0x03,0xca,0xff,0xe1,0xc5,0xf9,0x2e,0xc1,0x0f,0x9b,0xc0,0x7a,0x03,0x0f,0x94,0xc0,0x0f,0xb6,0xc0,0xe9,0x5c,0x01,0x00,0x00,0xc5,0xf9,0x2e,0xc1,0x0f,0x9b,0xc0,0x7a,0x03,0x0f,0x94,0xc0,0x0f,0xb6,0xc0,0xe9,0x48,0x01,0x00,0x00,0xc5,0xf9,0x2e,0xc1,0x0f,0x9b,0xc0,0x7a,0x03,0x0f,0x94,0xc0,0x0f,0xb6,0xc0,0xe9,0x34,0x01,0x00,0x00,0xc5,0xf9,0x2e,0xc1,0x0f,0x9b,0xc0,0x7a,0x03,0x0f,0x94,0xc0,0x0f,0xb6,0xc0,0xe9,0x20,0x01,0x00,0x00,0xc5,0xf9,0x2e,0xc1,0x0f,0x9a,0xc0,0x7a,0x03,0x0f,0x95,0xc0,0x0f,0xb6,0xc0,0xe9,0x0c,0x01,0x00,0x00,0xc5,0xf9,0x2e,0xc1,0x0f,0x9a,0xc0,0x7a,0x03,0x0f,0x95,0xc0,0x0f,0xb6,0xc0,0xe9,0xf8,0x00,0x00,0x00,0xc5,0xf9,0x2e,0xc1,0x0f,0x9a,0xc0,0x7a,0x03,0x0f,0x95,0xc0,0x0f,0xb6,0xc0,0xe9,0xe4,0x00,0x00,0x00,0xc5,0xf9,0x2e,0xc1,0x0f,0x9a,0xc0,0x7a,0x03,0x0f,0x95,0xc0,0x0f,0xb6,0xc0,0xe9,0xd0,0x00,0x00,0x00,0xc5,0xf9,0x2e,0xc8,0x0f,0x97,0xc0,0x0f,0xb6,0xc0,0xe9,0xc1,0x00,0x00,0x00,0xc5,0xf9,0x2e,0xc8,0x0f,0x97,0xc0,0x0f,0xb6,0xc0,0xe9,0xb2,0x00,0x00,0x00,0xc5,0xf9,0x2e,0xc1,0x0f,0x97,0xc0,0x0f,0xb6,0xc0,0xe9,0xa3,0x00,0x00,0x00,0xc5,0xf9,0x2e,0xc1,0x0f,0x97,0xc0,0x0f,0xb6,0xc0,0xe9,0x94,0x00,0x00,0x00,0xc5,0xf9,0x2e,0xc8,0x0f,0x93,0xc0,0x0f,0xb6,0xc0,0xe9,0x85,0x00,0x00,0x00,0xc5,0xf9,0x2e,0xc8,0x0f,0x93,0xc0,0x0f,0xb6,0xc0,0xe9,0x76,0x00,0x00,0x00,0xc5,0xf9,0x2e,0xc1,0x0f,0x93,0xc0,0x0f,0xb6,0xc0,0xeb,0x6a,0xc5,0xf9,0x2e,0xc1,0x0f,0x93,0xc0,0x0f,0xb6,0xc0,0xeb,0x5e,0xc5,0xf9,0x2e,0xc1,0x0f,0x92,0xc0,0x0f,0xb6,0xc0,0xeb,0x52,0xc5,0xf9,0x2e,0xc1,0x0f,0x92,0xc0,0x0f,0xb6,0xc0,0xeb,0x46,0xc5,0xf9,0x2e,0xc1,0x0f,0x96,0xc0,0x0f,0xb6,0xc0,0xeb,0x3a,0xc5,0xf9,0x2e,0xc1,0x0f,0x96,0xc0,0x0f,0xb6,0xc0,0xeb,0x2e,0xc5,0xf9,0x2e,0xc8,0x0f,0x92,0xc0,0x0f,0xb6,0xc0,0xeb,0x22,0xc5,0xf9,0x2e,0xc8,0x0f,0x92,0xc0,0x0f,0xb6,0xc0,0xeb,0x16,0xc5,0xf9,0x2e,0xc8,0x0f,0x96,0xc0,0x0f,0xb6,0xc0,0xeb,0x0a,0xc5,0xf9,0x2e,0xc8,0x0f,0x96,0xc0,0x0f,0xb6,0xc0,0x48,0x83,0xc4,0x20,0x5e,0xc3,0x48,0xb9,0xd8,0xd3,0x42,0x65,0xfb,0x7f,0x00,0x00,0xe8,0x0e,0x8a,0x9f,0x5b,0x48,0x8b,0xf0,0x48,0x8b,0xce,0xe8,0x3b,0x37,0xed,0xfb,0x48,0x8b,0xce,0xe8,0x4b,0xc6,0x9b,0x5b};

        public static ReadOnlySpan<byte> cbrtヽᐤ32fᐤ  =>  new byte[18]{0xc5,0xf8,0x77,0x66,0x90,0x48,0xb8,0xf0,0x8b,0xee,0xc4,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> cbrtヽᐤ64fᐤ  =>  new byte[18]{0xc5,0xf8,0x77,0x66,0x90,0x48,0xb8,0xf0,0x8d,0xee,0xc4,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> expヽᐤ32fᐤ  =>  new byte[18]{0xc5,0xf8,0x77,0x66,0x90,0x48,0xb8,0x30,0x8c,0xee,0xc4,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> expヽᐤ64fᐤ  =>  new byte[18]{0xc5,0xf8,0x77,0x66,0x90,0x48,0xb8,0x20,0x8e,0xee,0xc4,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> powヽᐤ32fㆍ32fᐤ  =>  new byte[18]{0xc5,0xf8,0x77,0x66,0x90,0x48,0xb8,0xe0,0x8c,0xee,0xc4,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> powヽᐤ64fㆍ64fᐤ  =>  new byte[18]{0xc5,0xf8,0x77,0x66,0x90,0x48,0xb8,0xa0,0x8e,0xee,0xc4,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> relerrヽᐤ32fㆍ32fᐤ  =>  new byte[73]{0x50,0xc5,0xf8,0x77,0x90,0xc5,0xf8,0x2e,0xc1,0x73,0x06,0xc5,0xf2,0x5c,0xc8,0xeb,0x0c,0xc5,0xf8,0x28,0xd0,0xc5,0xea,0x5c,0xd1,0xc5,0xf8,0x28,0xca,0xc5,0xf2,0x5e,0xc8,0xc5,0xfa,0x11,0x4c,0x24,0x04,0x8b,0x44,0x24,0x04,0x25,0xff,0xff,0xff,0x7f,0x3d,0x00,0x00,0x80,0x7f,0x7f,0x09,0xc5,0xf8,0x28,0xc1,0x48,0x83,0xc4,0x08,0xc3,0xc5,0xf8,0x57,0xc0,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> relerrヽᐤ64fㆍ64fᐤ  =>  new byte[88]{0x50,0xc5,0xf8,0x77,0x90,0xc5,0xf9,0x2e,0xc1,0x73,0x06,0xc5,0xf3,0x5c,0xc8,0xeb,0x0c,0xc5,0xf8,0x28,0xd0,0xc5,0xeb,0x5c,0xd1,0xc5,0xf8,0x28,0xca,0xc5,0xf3,0x5e,0xc8,0xc5,0xfb,0x11,0x0c,0x24,0x48,0x8b,0x04,0x24,0x48,0xba,0xff,0xff,0xff,0xff,0xff,0xff,0xff,0x7f,0x48,0x23,0xc2,0x48,0xba,0x00,0x00,0x00,0x00,0x00,0x00,0xf0,0x7f,0x48,0x3b,0xc2,0x7f,0x09,0xc5,0xf8,0x28,0xc1,0x48,0x83,0xc4,0x08,0xc3,0xc5,0xf8,0x57,0xc0,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> fcsumヽᐤ64fᕀinㆍ64fᕀrefㆍ64fᕀrefᐤ  =>  new byte[51]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xfb,0x10,0x01,0xc5,0xfb,0x5c,0x02,0xc4,0xc1,0x7b,0x10,0x08,0xc5,0xf8,0x28,0xd1,0xc5,0xeb,0x58,0xd0,0xc5,0xf8,0x28,0xda,0xc5,0xe3,0x5c,0xd9,0xc5,0xe3,0x5c,0xd8,0xc5,0xfb,0x11,0x1a,0xc4,0xc1,0x7b,0x11,0x10,0x49,0x8b,0xc0,0xc3};

        public static ReadOnlySpan<byte> gcdヽᐤ32fㆍ32fᐤ  =>  new byte[121]{0x48,0x83,0xec,0x48,0xc5,0xf8,0x77,0xc5,0xf8,0x29,0x74,0x24,0x30,0xc5,0xf8,0x29,0x7c,0x24,0x20,0xc5,0xfa,0x10,0x15,0x75,0x00,0x00,0x00,0xc5,0xf8,0x54,0xc2,0xc5,0xf8,0x28,0xf1,0xc5,0xfa,0x10,0x15,0x65,0x00,0x00,0x00,0xc5,0xc8,0x54,0xf2,0xc5,0xf0,0x57,0xc9,0xc5,0xf8,0x2e,0xf1,0x7a,0x02,0x74,0x38,0xc5,0xf8,0x28,0xce,0xe8,0x9c,0x23,0xb2,0x5b,0xc5,0xf8,0x28,0xf8,0xc5,0xf8,0x57,0xc0,0xc5,0xf8,0x2e,0xf8,0x7a,0x17,0x75,0x15,0xc5,0xf8,0x28,0xc6,0xc5,0xf8,0x28,0x74,0x24,0x30,0xc5,0xf8,0x28,0x7c,0x24,0x20,0x48,0x83,0xc4,0x48,0xc3,0xc5,0xf8,0x28,0xc6,0xc5,0xf8,0x28,0xf7,0xeb,0xc8,0xc5,0xf8,0x28,0xf0,0xeb,0xdb};

        public static ReadOnlySpan<byte> gcdヽᐤ64fㆍ64fᐤ  =>  new byte[121]{0x48,0x83,0xec,0x48,0xc5,0xf8,0x77,0xc5,0xf8,0x29,0x74,0x24,0x30,0xc5,0xf8,0x29,0x7c,0x24,0x20,0xc5,0xfb,0x10,0x15,0x75,0x00,0x00,0x00,0xc5,0xf8,0x54,0xc2,0xc5,0xf8,0x28,0xf1,0xc5,0xfb,0x10,0x15,0x65,0x00,0x00,0x00,0xc5,0xc8,0x54,0xf2,0xc5,0xf0,0x57,0xc9,0xc5,0xf9,0x2e,0xf1,0x7a,0x02,0x74,0x38,0xc5,0xf8,0x28,0xce,0xe8,0x5c,0x22,0xb2,0x5b,0xc5,0xf8,0x28,0xf8,0xc5,0xf8,0x57,0xc0,0xc5,0xf9,0x2e,0xf8,0x7a,0x17,0x75,0x15,0xc5,0xf8,0x28,0xc6,0xc5,0xf8,0x28,0x74,0x24,0x30,0xc5,0xf8,0x28,0x7c,0x24,0x20,0x48,0x83,0xc4,0x48,0xc3,0xc5,0xf8,0x28,0xc6,0xc5,0xf8,0x28,0xf7,0xeb,0xc8,0xc5,0xf8,0x28,0xf0,0xeb,0xdb};

        public static ReadOnlySpan<byte> log2ヽᐤ32fᐤ  =>  new byte[18]{0xc5,0xf8,0x77,0x66,0x90,0x48,0xb8,0xb0,0x8c,0xee,0xc4,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> log2ヽᐤ64fᐤ  =>  new byte[18]{0xc5,0xf8,0x77,0x66,0x90,0x48,0xb8,0x70,0x8e,0xee,0xc4,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> lnヽᐤ32fᐤ  =>  new byte[18]{0xc5,0xf8,0x77,0x66,0x90,0x48,0xb8,0xc0,0x8c,0xee,0xc4,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> lnヽᐤ64fᐤ  =>  new byte[18]{0xc5,0xf8,0x77,0x66,0x90,0x48,0xb8,0x80,0x8e,0xee,0xc4,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> logヽᐤ32fㆍfloatᐤ  =>  new byte[50]{0x48,0x83,0xec,0x28,0xc5,0xf8,0x77,0x48,0x89,0x54,0x24,0x38,0x48,0x8d,0x44,0x24,0x38,0x0f,0xb6,0x10,0xc5,0xfa,0x10,0x48,0x04,0x84,0xd2,0x75,0x0a,0xc5,0xfa,0x10,0x0d,0x13,0x00,0x00,0x00,0xeb,0x00,0xe8,0x8c,0xa9,0x25,0xff,0x90,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> logヽᐤ64fㆍdoubleᐤ  =>  new byte[40]{0x48,0x83,0xec,0x28,0xc5,0xf8,0x77,0x0f,0xb6,0x02,0xc5,0xfb,0x10,0x4a,0x08,0x84,0xc0,0x75,0x0a,0xc5,0xfb,0x10,0x0d,0x15,0x00,0x00,0x00,0xeb,0x00,0xe8,0x86,0x81,0xb5,0xfe,0x90,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> sinヽᐤ32fᐤ  =>  new byte[18]{0xc5,0xf8,0x77,0x66,0x90,0x48,0xb8,0x00,0x8d,0xee,0xc4,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> sinヽᐤ64fᐤ  =>  new byte[18]{0xc5,0xf8,0x77,0x66,0x90,0x48,0xb8,0xc0,0x8e,0xee,0xc4,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> cosヽᐤ32fᐤ  =>  new byte[18]{0xc5,0xf8,0x77,0x66,0x90,0x48,0xb8,0x10,0x8c,0xee,0xc4,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> cosヽᐤ64fᐤ  =>  new byte[18]{0xc5,0xf8,0x77,0x66,0x90,0x48,0xb8,0x00,0x8e,0xee,0xc4,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> tanヽᐤ32fᐤ  =>  new byte[18]{0xc5,0xf8,0x77,0x66,0x90,0x48,0xb8,0x30,0x8d,0xee,0xc4,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> tanヽᐤ64fᐤ  =>  new byte[18]{0xc5,0xf8,0x77,0x66,0x90,0x48,0xb8,0xf0,0x8e,0xee,0xc4,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> asinヽᐤ32fᐤ  =>  new byte[18]{0xc5,0xf8,0x77,0x66,0x90,0x48,0xb8,0xa0,0x8b,0xee,0xc4,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> asinヽᐤ64fᐤ  =>  new byte[18]{0xc5,0xf8,0x77,0x66,0x90,0x48,0xb8,0xa0,0x8d,0xee,0xc4,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> acosヽᐤ32fᐤ  =>  new byte[18]{0xc5,0xf8,0x77,0x66,0x90,0x48,0xb8,0x80,0x8b,0xee,0xc4,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> acosヽᐤ64fᐤ  =>  new byte[18]{0xc5,0xf8,0x77,0x66,0x90,0x48,0xb8,0x80,0x8d,0xee,0xc4,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> atanヽᐤ32fᐤ  =>  new byte[18]{0xc5,0xf8,0x77,0x66,0x90,0x48,0xb8,0xd0,0x8b,0xee,0xc4,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> atanヽᐤ64fᐤ  =>  new byte[18]{0xc5,0xf8,0x77,0x66,0x90,0x48,0xb8,0xd0,0x8d,0xee,0xc4,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> sinhヽᐤ32fᐤ  =>  new byte[18]{0xc5,0xf8,0x77,0x66,0x90,0x48,0xb8,0x10,0x8d,0xee,0xc4,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> sinhヽᐤ64fᐤ  =>  new byte[18]{0xc5,0xf8,0x77,0x66,0x90,0x48,0xb8,0xd0,0x8e,0xee,0xc4,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> coshヽᐤ32fᐤ  =>  new byte[18]{0xc5,0xf8,0x77,0x66,0x90,0x48,0xb8,0x20,0x8c,0xee,0xc4,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> coshヽᐤ64fᐤ  =>  new byte[18]{0xc5,0xf8,0x77,0x66,0x90,0x48,0xb8,0x10,0x8e,0xee,0xc4,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> tanhヽᐤ32fᐤ  =>  new byte[18]{0xc5,0xf8,0x77,0x66,0x90,0x48,0xb8,0x40,0x8d,0xee,0xc4,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> tanhヽᐤ64fᐤ  =>  new byte[18]{0xc5,0xf8,0x77,0x66,0x90,0x48,0xb8,0x00,0x8f,0xee,0xc4,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> asinhヽᐤ32fᐤ  =>  new byte[18]{0xc5,0xf8,0x77,0x66,0x90,0x48,0xb8,0xb0,0x8b,0xee,0xc4,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> asinhヽᐤ64fᐤ  =>  new byte[18]{0xc5,0xf8,0x77,0x66,0x90,0x48,0xb8,0xb0,0x8d,0xee,0xc4,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> acoshヽᐤ32fᐤ  =>  new byte[18]{0xc5,0xf8,0x77,0x66,0x90,0x48,0xb8,0x90,0x8b,0xee,0xc4,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> acoshヽᐤ64fᐤ  =>  new byte[18]{0xc5,0xf8,0x77,0x66,0x90,0x48,0xb8,0x90,0x8d,0xee,0xc4,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> atanhヽᐤ32fᐤ  =>  new byte[18]{0xc5,0xf8,0x77,0x66,0x90,0x48,0xb8,0xe0,0x8b,0xee,0xc4,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> atanhヽᐤ64fᐤ  =>  new byte[18]{0xc5,0xf8,0x77,0x66,0x90,0x48,0xb8,0xe0,0x8d,0xee,0xc4,0xfb,0x7f,0x00,0x00,0x48,0xff,0xe0};

    }
}
