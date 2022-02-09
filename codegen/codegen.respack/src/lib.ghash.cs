﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2022-01-14 21:56:34 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class lib_ghash
    {
        public static ReadOnlySpan<byte> calcヽgᐸ8uᐳᐤ8uᐤ  =>  new byte[9]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc1,0xc3};

        public static ReadOnlySpan<byte> calcヽgᐸ8iᐳᐤ8iᐤ  =>  new byte[10]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x0f,0xbe,0xc1,0xc3};

        public static ReadOnlySpan<byte> calcヽgᐸ16uᐳᐤ16uᐤ  =>  new byte[9]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb7,0xc1,0xc3};

        public static ReadOnlySpan<byte> calcヽgᐸ16iᐳᐤ16iᐤ  =>  new byte[10]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x0f,0xbf,0xc1,0xc3};

        public static ReadOnlySpan<byte> calcヽgᐸ32uᐳᐤ32uᐤ  =>  new byte[8]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> calcヽgᐸ32iᐳᐤ32iᐤ  =>  new byte[8]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> calcヽgᐸ64uᐳᐤ64uᐤ  =>  new byte[21]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0xc1,0x48,0xc1,0xe8,0x20,0x69,0xc0,0x29,0x55,0x55,0xa5,0x03,0xc1,0xc3};

        public static ReadOnlySpan<byte> calcヽgᐸ64iᐳᐤ64iᐤ  =>  new byte[21]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0xc1,0x48,0xc1,0xf8,0x20,0x69,0xc0,0x29,0x55,0x55,0xa5,0x03,0xc1,0xc3};

        public static ReadOnlySpan<byte> calcヽgᐸ32fᐳᐤ32fᐤ  =>  new byte[26]{0xc5,0xf8,0x77,0x66,0x90,0xc4,0xe1,0xfa,0x2c,0xc0,0x48,0x8b,0xd0,0x48,0xc1,0xfa,0x20,0x69,0xd2,0x29,0x55,0x55,0xa5,0x03,0xc2,0xc3};

        public static ReadOnlySpan<byte> calcヽgᐸ64fᐳᐤ64fᐤ  =>  new byte[34]{0x50,0xc5,0xf8,0x77,0x90,0xc5,0xfb,0x11,0x04,0x24,0x48,0x8b,0x04,0x24,0x48,0x8b,0xd0,0x48,0xc1,0xea,0x20,0x69,0xd2,0x29,0x55,0x55,0xa5,0x03,0xc2,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> bytehashヽgᐸ8uᐳᐤ8uᐤ  =>  new byte[11]{0x89,0x4c,0x24,0x08,0x90,0xb8,0xc5,0x9d,0x1c,0x81,0xc3};

        public static ReadOnlySpan<byte> bytehashヽgᐸ8iᐳᐤ8iᐤ  =>  new byte[11]{0x89,0x4c,0x24,0x08,0x90,0xb8,0xc5,0x9d,0x1c,0x81,0xc3};

        public static ReadOnlySpan<byte> bytehashヽgᐸ16uᐳᐤ16uᐤ  =>  new byte[84]{0x89,0x4c,0x24,0x08,0x90,0x48,0x8d,0x44,0x24,0x08,0xba,0xc5,0x9d,0x1c,0x81,0x33,0xc9,0x4c,0x63,0xc1,0x4c,0x03,0xc0,0x44,0x8d,0x49,0x01,0x4d,0x63,0xc9,0x4c,0x03,0xc8,0x45,0x0f,0xb6,0x00,0x45,0x0f,0xb6,0x09,0x45,0x69,0xc9,0x29,0x55,0x55,0xa5,0x45,0x0f,0xb6,0xc0,0x45,0x03,0xc1,0x45,0x69,0xc0,0x29,0x55,0x55,0xa5,0x41,0x03,0xd0,0x69,0xd2,0x93,0x01,0x00,0x01,0xff,0xc1,0x44,0x8b,0xc1,0x4d,0x85,0xc0,0x7e,0xc0,0x8b,0xc2,0xc3};

        public static ReadOnlySpan<byte> bytehashヽgᐸ16iᐳᐤ16iᐤ  =>  new byte[84]{0x89,0x4c,0x24,0x08,0x90,0x48,0x8d,0x44,0x24,0x08,0xba,0xc5,0x9d,0x1c,0x81,0x33,0xc9,0x4c,0x63,0xc1,0x4c,0x03,0xc0,0x44,0x8d,0x49,0x01,0x4d,0x63,0xc9,0x4c,0x03,0xc8,0x45,0x0f,0xb6,0x00,0x45,0x0f,0xb6,0x09,0x45,0x69,0xc9,0x29,0x55,0x55,0xa5,0x45,0x0f,0xb6,0xc0,0x45,0x03,0xc1,0x45,0x69,0xc0,0x29,0x55,0x55,0xa5,0x41,0x03,0xd0,0x69,0xd2,0x93,0x01,0x00,0x01,0xff,0xc1,0x44,0x8b,0xc1,0x4d,0x85,0xc0,0x7e,0xc0,0x8b,0xc2,0xc3};

        public static ReadOnlySpan<byte> bytehashヽgᐸ32uᐳᐤ32uᐤ  =>  new byte[85]{0x89,0x4c,0x24,0x08,0x90,0x48,0x8d,0x44,0x24,0x08,0xba,0xc5,0x9d,0x1c,0x81,0x33,0xc9,0x4c,0x63,0xc1,0x4c,0x03,0xc0,0x44,0x8d,0x49,0x01,0x4d,0x63,0xc9,0x4c,0x03,0xc8,0x45,0x0f,0xb6,0x00,0x45,0x0f,0xb6,0x09,0x45,0x69,0xc9,0x29,0x55,0x55,0xa5,0x45,0x0f,0xb6,0xc0,0x45,0x03,0xc1,0x45,0x69,0xc0,0x29,0x55,0x55,0xa5,0x41,0x03,0xd0,0x69,0xd2,0x93,0x01,0x00,0x01,0xff,0xc1,0x44,0x8b,0xc1,0x49,0x83,0xf8,0x03,0x7c,0xbf,0x8b,0xc2,0xc3};

        public static ReadOnlySpan<byte> bytehashヽgᐸ32iᐳᐤ32iᐤ  =>  new byte[85]{0x89,0x4c,0x24,0x08,0x90,0x48,0x8d,0x44,0x24,0x08,0xba,0xc5,0x9d,0x1c,0x81,0x33,0xc9,0x4c,0x63,0xc1,0x4c,0x03,0xc0,0x44,0x8d,0x49,0x01,0x4d,0x63,0xc9,0x4c,0x03,0xc8,0x45,0x0f,0xb6,0x00,0x45,0x0f,0xb6,0x09,0x45,0x69,0xc9,0x29,0x55,0x55,0xa5,0x45,0x0f,0xb6,0xc0,0x45,0x03,0xc1,0x45,0x69,0xc0,0x29,0x55,0x55,0xa5,0x41,0x03,0xd0,0x69,0xd2,0x93,0x01,0x00,0x01,0xff,0xc1,0x44,0x8b,0xc1,0x49,0x83,0xf8,0x03,0x7c,0xbf,0x8b,0xc2,0xc3};

        public static ReadOnlySpan<byte> bytehashヽgᐸ64uᐳᐤ64uᐤ  =>  new byte[85]{0x48,0x89,0x4c,0x24,0x08,0x48,0x8d,0x44,0x24,0x08,0xba,0xc5,0x9d,0x1c,0x81,0x33,0xc9,0x4c,0x63,0xc1,0x4c,0x03,0xc0,0x44,0x8d,0x49,0x01,0x4d,0x63,0xc9,0x4c,0x03,0xc8,0x45,0x0f,0xb6,0x00,0x45,0x0f,0xb6,0x09,0x45,0x69,0xc9,0x29,0x55,0x55,0xa5,0x45,0x0f,0xb6,0xc0,0x45,0x03,0xc1,0x45,0x69,0xc0,0x29,0x55,0x55,0xa5,0x41,0x03,0xd0,0x69,0xd2,0x93,0x01,0x00,0x01,0xff,0xc1,0x44,0x8b,0xc1,0x49,0x83,0xf8,0x07,0x7c,0xbf,0x8b,0xc2,0xc3};

        public static ReadOnlySpan<byte> bytehashヽgᐸ64iᐳᐤ64iᐤ  =>  new byte[85]{0x48,0x89,0x4c,0x24,0x08,0x48,0x8d,0x44,0x24,0x08,0xba,0xc5,0x9d,0x1c,0x81,0x33,0xc9,0x4c,0x63,0xc1,0x4c,0x03,0xc0,0x44,0x8d,0x49,0x01,0x4d,0x63,0xc9,0x4c,0x03,0xc8,0x45,0x0f,0xb6,0x00,0x45,0x0f,0xb6,0x09,0x45,0x69,0xc9,0x29,0x55,0x55,0xa5,0x45,0x0f,0xb6,0xc0,0x45,0x03,0xc1,0x45,0x69,0xc0,0x29,0x55,0x55,0xa5,0x41,0x03,0xd0,0x69,0xd2,0x93,0x01,0x00,0x01,0xff,0xc1,0x44,0x8b,0xc1,0x49,0x83,0xf8,0x07,0x7c,0xbf,0x8b,0xc2,0xc3};

        public static ReadOnlySpan<byte> bytehashヽgᐸ32fᐳᐤ32fᐤ  =>  new byte[82]{0xc5,0xfa,0x11,0x44,0x24,0x08,0x48,0x8d,0x44,0x24,0x08,0xba,0xc5,0x9d,0x1c,0x81,0x33,0xc9,0x4c,0x63,0xc1,0x4c,0x03,0xc0,0xff,0xc1,0x4c,0x63,0xc9,0x4c,0x03,0xc8,0x45,0x0f,0xb6,0x00,0x45,0x0f,0xb6,0x09,0x45,0x69,0xc9,0x29,0x55,0x55,0xa5,0x45,0x0f,0xb6,0xc0,0x45,0x03,0xc1,0x45,0x69,0xc0,0x29,0x55,0x55,0xa5,0x41,0x03,0xd0,0x69,0xd2,0x93,0x01,0x00,0x01,0x44,0x8b,0xc1,0x49,0x83,0xf8,0x03,0x7c,0xc3,0x8b,0xc2,0xc3};

        public static ReadOnlySpan<byte> bytehashヽgᐸ64fᐳᐤ64fᐤ  =>  new byte[86]{0xc5,0xfb,0x11,0x44,0x24,0x08,0x48,0x8d,0x44,0x24,0x08,0xba,0xc5,0x9d,0x1c,0x81,0x33,0xc9,0x4c,0x63,0xc1,0x4c,0x03,0xc0,0x44,0x8d,0x49,0x01,0x4d,0x63,0xc9,0x4c,0x03,0xc8,0x45,0x0f,0xb6,0x00,0x45,0x0f,0xb6,0x09,0x45,0x69,0xc9,0x29,0x55,0x55,0xa5,0x45,0x0f,0xb6,0xc0,0x45,0x03,0xc1,0x45,0x69,0xc0,0x29,0x55,0x55,0xa5,0x41,0x03,0xd0,0x69,0xd2,0x93,0x01,0x00,0x01,0xff,0xc1,0x44,0x8b,0xc1,0x49,0x83,0xf8,0x07,0x7c,0xbf,0x8b,0xc2,0xc3};

        public static ReadOnlySpan<byte> combineヽgᐸ8uᐳᐤ8uㆍ8uᐤ  =>  new byte[23]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc1,0x0f,0xb6,0xd2,0x69,0xd2,0x29,0x55,0x55,0xa5,0x0f,0xb6,0xc0,0x03,0xc2,0xc3};

        public static ReadOnlySpan<byte> combineヽgᐸ8iᐳᐤ8iㆍ8iᐤ  =>  new byte[26]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x0f,0xbe,0xc1,0x48,0x0f,0xbe,0xd2,0x69,0xd2,0x29,0x55,0x55,0xa5,0x48,0x0f,0xbe,0xc0,0x03,0xc2,0xc3};

        public static ReadOnlySpan<byte> combineヽgᐸ16uᐳᐤ16uㆍ16uᐤ  =>  new byte[23]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb7,0xc1,0x0f,0xb7,0xd2,0x69,0xd2,0x29,0x55,0x55,0xa5,0x0f,0xb7,0xc0,0x03,0xc2,0xc3};

        public static ReadOnlySpan<byte> combineヽgᐸ16iᐳᐤ16iㆍ16iᐤ  =>  new byte[26]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x0f,0xbf,0xc1,0x48,0x0f,0xbf,0xd2,0x69,0xd2,0x29,0x55,0x55,0xa5,0x48,0x0f,0xbf,0xc0,0x03,0xc2,0xc3};

        public static ReadOnlySpan<byte> combineヽgᐸ32uᐳᐤ32uㆍ32uᐤ  =>  new byte[14]{0x0f,0x1f,0x44,0x00,0x00,0x69,0xc2,0x29,0x55,0x55,0xa5,0x03,0xc1,0xc3};

        public static ReadOnlySpan<byte> combineヽgᐸ32iᐳᐤ32iㆍ32iᐤ  =>  new byte[14]{0x0f,0x1f,0x44,0x00,0x00,0x69,0xc2,0x29,0x55,0x55,0xa5,0x03,0xc1,0xc3};

        public static ReadOnlySpan<byte> combineヽgᐸ64uᐳᐤ64uㆍ64uᐤ  =>  new byte[44]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0xc1,0x48,0xc1,0xe8,0x20,0x69,0xc0,0x29,0x55,0x55,0xa5,0x03,0xc1,0x48,0x8b,0xca,0x48,0xc1,0xe9,0x20,0x69,0xc9,0x29,0x55,0x55,0xa5,0x03,0xd1,0x69,0xd2,0x29,0x55,0x55,0xa5,0x03,0xc2,0xc3};

        public static ReadOnlySpan<byte> combineヽgᐸ64iᐳᐤ64iㆍ64iᐤ  =>  new byte[44]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0xc1,0x48,0xc1,0xe8,0x20,0x69,0xc0,0x29,0x55,0x55,0xa5,0x03,0xc1,0x48,0x8b,0xca,0x48,0xc1,0xe9,0x20,0x69,0xc9,0x29,0x55,0x55,0xa5,0x03,0xd1,0x69,0xd2,0x29,0x55,0x55,0xa5,0x03,0xc2,0xc3};

        public static ReadOnlySpan<byte> combineヽgᐸ32fᐳᐤ32fㆍ32fᐤ  =>  new byte[36]{0x50,0xc5,0xf8,0x77,0x90,0xc5,0xfa,0x11,0x44,0x24,0x04,0x8b,0x44,0x24,0x04,0xc5,0xfa,0x11,0x0c,0x24,0x8b,0x14,0x24,0x69,0xd2,0x29,0x55,0x55,0xa5,0x03,0xc2,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> combineヽgᐸ64fᐳᐤ64fㆍ64fᐤ  =>  new byte[72]{0x48,0x83,0xec,0x18,0xc5,0xf8,0x77,0xc5,0xfb,0x11,0x44,0x24,0x10,0x48,0x8b,0x44,0x24,0x10,0xc5,0xfb,0x11,0x4c,0x24,0x08,0x48,0x8b,0x54,0x24,0x08,0x48,0x8b,0xc8,0x48,0xc1,0xe9,0x20,0x69,0xc9,0x29,0x55,0x55,0xa5,0x03,0xc1,0x48,0x8b,0xca,0x48,0xc1,0xe9,0x20,0x69,0xc9,0x29,0x55,0x55,0xa5,0x03,0xd1,0x69,0xd2,0x29,0x55,0x55,0xa5,0x03,0xc2,0x48,0x83,0xc4,0x18,0xc3};

        public static ReadOnlySpan<byte> calcヽgᐸ8uᐳᐤ8uㆍ8uㆍ8uㆍ8uᐤ  =>  new byte[44]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc1,0x0f,0xb6,0xd2,0x69,0xd2,0x29,0x55,0x55,0xa5,0x03,0xc2,0x41,0x0f,0xb6,0xd0,0x41,0x0f,0xb6,0xc9,0x69,0xc9,0x29,0x55,0x55,0xa5,0x03,0xd1,0x69,0xd2,0x29,0x55,0x55,0xa5,0x03,0xc2,0xc3};

        public static ReadOnlySpan<byte> calcヽgᐸ16uᐳᐤ16uㆍ16uㆍ16uㆍ16uᐤ  =>  new byte[44]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb7,0xc1,0x0f,0xb7,0xd2,0x69,0xd2,0x29,0x55,0x55,0xa5,0x03,0xc2,0x41,0x0f,0xb7,0xd0,0x41,0x0f,0xb7,0xc9,0x69,0xc9,0x29,0x55,0x55,0xa5,0x03,0xd1,0x69,0xd2,0x29,0x55,0x55,0xa5,0x03,0xc2,0xc3};

        public static ReadOnlySpan<byte> calcヽgᐸ32uᐳᐤ32uㆍ32uㆍ32uㆍ32uᐤ  =>  new byte[32]{0x0f,0x1f,0x44,0x00,0x00,0x69,0xc2,0x29,0x55,0x55,0xa5,0x03,0xc1,0x41,0x69,0xd1,0x29,0x55,0x55,0xa5,0x41,0x03,0xd0,0x69,0xd2,0x29,0x55,0x55,0xa5,0x03,0xc2,0xc3};

        public static ReadOnlySpan<byte> calcヽgᐸ64uᐳᐤ64uㆍ64uㆍ64uㆍ64uᐤ  =>  new byte[92]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0xc1,0x48,0xc1,0xe8,0x20,0x69,0xc0,0x29,0x55,0x55,0xa5,0x03,0xc1,0x48,0x8b,0xca,0x48,0xc1,0xe9,0x20,0x69,0xc9,0x29,0x55,0x55,0xa5,0x03,0xd1,0x69,0xd2,0x29,0x55,0x55,0xa5,0x03,0xc2,0x49,0x8b,0xd0,0x48,0xc1,0xea,0x20,0x69,0xd2,0x29,0x55,0x55,0xa5,0x41,0x03,0xd0,0x49,0x8b,0xc9,0x48,0xc1,0xe9,0x20,0x69,0xc9,0x29,0x55,0x55,0xa5,0x41,0x03,0xc9,0x69,0xc9,0x29,0x55,0x55,0xa5,0x03,0xd1,0x69,0xd2,0x29,0x55,0x55,0xa5,0x03,0xc2,0xc3};

        public static ReadOnlySpan<byte> calcヽgᐸ8uᐳᐤrspan8uᐤ  =>  new byte[100]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x11,0x8b,0x49,0x08,0x8b,0xc1,0x85,0xc0,0x75,0x03,0x33,0xc0,0xc3,0xb8,0xc5,0x9d,0x1c,0x81,0x45,0x33,0xc0,0xff,0xc9,0x48,0x63,0xc9,0x48,0x85,0xc9,0x7e,0x3d,0x4d,0x63,0xc8,0x4c,0x03,0xca,0x41,0xff,0xc0,0x4d,0x63,0xd0,0x4c,0x03,0xd2,0x45,0x0f,0xb6,0x09,0x45,0x0f,0xb6,0x12,0x45,0x69,0xd2,0x29,0x55,0x55,0xa5,0x45,0x0f,0xb6,0xc9,0x45,0x03,0xca,0x45,0x69,0xc9,0x29,0x55,0x55,0xa5,0x41,0x03,0xc1,0x69,0xc0,0x93,0x01,0x00,0x01,0x45,0x8b,0xc8,0x4c,0x3b,0xc9,0x7c,0xc3,0xc3};

        public static ReadOnlySpan<byte> calcヽgᐸ8iᐳᐤrspan8iᐤ  =>  new byte[100]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x11,0x8b,0x49,0x08,0x8b,0xc1,0x85,0xc0,0x75,0x03,0x33,0xc0,0xc3,0xb8,0xc5,0x9d,0x1c,0x81,0x45,0x33,0xc0,0xff,0xc9,0x48,0x63,0xc9,0x48,0x85,0xc9,0x7e,0x3d,0x4d,0x63,0xc8,0x4c,0x03,0xca,0x41,0xff,0xc0,0x4d,0x63,0xd0,0x4c,0x03,0xd2,0x4d,0x0f,0xbe,0x09,0x4d,0x0f,0xbe,0x12,0x45,0x69,0xd2,0x29,0x55,0x55,0xa5,0x4d,0x0f,0xbe,0xc9,0x45,0x03,0xca,0x45,0x69,0xc9,0x29,0x55,0x55,0xa5,0x41,0x03,0xc1,0x69,0xc0,0x93,0x01,0x00,0x01,0x45,0x8b,0xc8,0x4c,0x3b,0xc9,0x7c,0xc3,0xc3};

        public static ReadOnlySpan<byte> calcヽgᐸ16uᐳᐤrspan16uᐤ  =>  new byte[102]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x11,0x8b,0x49,0x08,0x8b,0xc1,0x85,0xc0,0x75,0x03,0x33,0xc0,0xc3,0xb8,0xc5,0x9d,0x1c,0x81,0x45,0x33,0xc0,0xff,0xc9,0x48,0x63,0xc9,0x48,0x85,0xc9,0x7e,0x3f,0x4d,0x63,0xc8,0x4e,0x8d,0x0c,0x4a,0x41,0xff,0xc0,0x4d,0x63,0xd0,0x4e,0x8d,0x14,0x52,0x45,0x0f,0xb7,0x09,0x45,0x0f,0xb7,0x12,0x45,0x69,0xd2,0x29,0x55,0x55,0xa5,0x45,0x0f,0xb7,0xc9,0x45,0x03,0xca,0x45,0x69,0xc9,0x29,0x55,0x55,0xa5,0x41,0x03,0xc1,0x69,0xc0,0x93,0x01,0x00,0x01,0x45,0x8b,0xc8,0x4c,0x3b,0xc9,0x7c,0xc1,0xc3};

        public static ReadOnlySpan<byte> calcヽgᐸ16iᐳᐤrspan16iᐤ  =>  new byte[102]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x11,0x8b,0x49,0x08,0x8b,0xc1,0x85,0xc0,0x75,0x03,0x33,0xc0,0xc3,0xb8,0xc5,0x9d,0x1c,0x81,0x45,0x33,0xc0,0xff,0xc9,0x48,0x63,0xc9,0x48,0x85,0xc9,0x7e,0x3f,0x4d,0x63,0xc8,0x4e,0x8d,0x0c,0x4a,0x41,0xff,0xc0,0x4d,0x63,0xd0,0x4e,0x8d,0x14,0x52,0x4d,0x0f,0xbf,0x09,0x4d,0x0f,0xbf,0x12,0x45,0x69,0xd2,0x29,0x55,0x55,0xa5,0x4d,0x0f,0xbf,0xc9,0x45,0x03,0xca,0x45,0x69,0xc9,0x29,0x55,0x55,0xa5,0x41,0x03,0xc1,0x69,0xc0,0x93,0x01,0x00,0x01,0x45,0x8b,0xc8,0x4c,0x3b,0xc9,0x7c,0xc1,0xc3};

        public static ReadOnlySpan<byte> calcヽgᐸ32uᐳᐤrspan32uᐤ  =>  new byte[96]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x11,0x8b,0x49,0x08,0x8b,0xc1,0x85,0xc0,0x75,0x03,0x33,0xc0,0xc3,0xb8,0xc5,0x9d,0x1c,0x81,0x45,0x33,0xc0,0xff,0xc9,0x48,0x63,0xc9,0x48,0x85,0xc9,0x7e,0x39,0x4d,0x63,0xc8,0x4e,0x8d,0x0c,0x8a,0x41,0xff,0xc0,0x4d,0x63,0xd0,0x4e,0x8d,0x14,0x92,0x45,0x8b,0x09,0x45,0x8b,0x12,0x45,0x69,0xd2,0x29,0x55,0x55,0xa5,0x45,0x03,0xca,0x45,0x69,0xc9,0x29,0x55,0x55,0xa5,0x41,0x03,0xc1,0x69,0xc0,0x93,0x01,0x00,0x01,0x45,0x8b,0xc8,0x4c,0x3b,0xc9,0x7c,0xc7,0xc3};

        public static ReadOnlySpan<byte> calcヽgᐸ32iᐳᐤrspan32iᐤ  =>  new byte[96]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x11,0x8b,0x49,0x08,0x8b,0xc1,0x85,0xc0,0x75,0x03,0x33,0xc0,0xc3,0xb8,0xc5,0x9d,0x1c,0x81,0x45,0x33,0xc0,0xff,0xc9,0x48,0x63,0xc9,0x48,0x85,0xc9,0x7e,0x39,0x4d,0x63,0xc8,0x4e,0x8d,0x0c,0x8a,0x41,0xff,0xc0,0x4d,0x63,0xd0,0x4e,0x8d,0x14,0x92,0x45,0x8b,0x09,0x45,0x8b,0x12,0x45,0x69,0xd2,0x29,0x55,0x55,0xa5,0x45,0x03,0xca,0x45,0x69,0xc9,0x29,0x55,0x55,0xa5,0x41,0x03,0xc1,0x69,0xc0,0x93,0x01,0x00,0x01,0x45,0x8b,0xc8,0x4c,0x3b,0xc9,0x7c,0xc7,0xc3};

        public static ReadOnlySpan<byte> calcヽgᐸ64uᐳᐤrspan64uᐤ  =>  new byte[130]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x11,0x8b,0x49,0x08,0x8b,0xc1,0x85,0xc0,0x75,0x03,0x33,0xc0,0xc3,0xb8,0xc5,0x9d,0x1c,0x81,0x45,0x33,0xc0,0xff,0xc9,0x48,0x63,0xc9,0x48,0x85,0xc9,0x7e,0x5b,0x4d,0x63,0xc8,0x4e,0x8d,0x0c,0xca,0x41,0xff,0xc0,0x4d,0x63,0xd0,0x4e,0x8d,0x14,0xd2,0x4d,0x8b,0x09,0x4d,0x8b,0x12,0x4d,0x8b,0xd9,0x49,0xc1,0xeb,0x20,0x45,0x69,0xdb,0x29,0x55,0x55,0xa5,0x45,0x03,0xcb,0x4d,0x8b,0xda,0x49,0xc1,0xeb,0x20,0x45,0x69,0xdb,0x29,0x55,0x55,0xa5,0x45,0x03,0xd3,0x45,0x69,0xd2,0x29,0x55,0x55,0xa5,0x45,0x03,0xca,0x45,0x69,0xc9,0x29,0x55,0x55,0xa5,0x41,0x03,0xc1,0x69,0xc0,0x93,0x01,0x00,0x01,0x45,0x8b,0xc8,0x4c,0x3b,0xc9,0x7c,0xa5,0xc3};

        public static ReadOnlySpan<byte> calcヽgᐸ64iᐳᐤrspan64iᐤ  =>  new byte[130]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x11,0x8b,0x49,0x08,0x8b,0xc1,0x85,0xc0,0x75,0x03,0x33,0xc0,0xc3,0xb8,0xc5,0x9d,0x1c,0x81,0x45,0x33,0xc0,0xff,0xc9,0x48,0x63,0xc9,0x48,0x85,0xc9,0x7e,0x5b,0x4d,0x63,0xc8,0x4e,0x8d,0x0c,0xca,0x41,0xff,0xc0,0x4d,0x63,0xd0,0x4e,0x8d,0x14,0xd2,0x4d,0x8b,0x09,0x4d,0x8b,0x12,0x4d,0x8b,0xd9,0x49,0xc1,0xeb,0x20,0x45,0x69,0xdb,0x29,0x55,0x55,0xa5,0x45,0x03,0xcb,0x4d,0x8b,0xda,0x49,0xc1,0xeb,0x20,0x45,0x69,0xdb,0x29,0x55,0x55,0xa5,0x45,0x03,0xd3,0x45,0x69,0xd2,0x29,0x55,0x55,0xa5,0x45,0x03,0xca,0x45,0x69,0xc9,0x29,0x55,0x55,0xa5,0x41,0x03,0xc1,0x69,0xc0,0x93,0x01,0x00,0x01,0x45,0x8b,0xc8,0x4c,0x3b,0xc9,0x7c,0xa5,0xc3};

        public static ReadOnlySpan<byte> calcヽgᐸ32fᐳᐤrspan32fᐤ  =>  new byte[128]{0x50,0xc5,0xf8,0x77,0x90,0x48,0x8b,0x11,0x8b,0x49,0x08,0x8b,0xc1,0x85,0xc0,0x75,0x07,0x33,0xc0,0x48,0x83,0xc4,0x08,0xc3,0xb8,0xc5,0x9d,0x1c,0x81,0x45,0x33,0xc0,0xff,0xc9,0x48,0x63,0xc9,0x48,0x85,0xc9,0x7e,0x51,0x4d,0x63,0xc8,0x4e,0x8d,0x0c,0x8a,0x41,0xff,0xc0,0x4d,0x63,0xd0,0x4e,0x8d,0x14,0x92,0xc4,0xc1,0x7a,0x10,0x01,0xc4,0xc1,0x7a,0x10,0x0a,0xc5,0xfa,0x11,0x44,0x24,0x04,0x44,0x8b,0x4c,0x24,0x04,0xc5,0xfa,0x11,0x0c,0x24,0x44,0x8b,0x14,0x24,0x45,0x69,0xd2,0x29,0x55,0x55,0xa5,0x45,0x03,0xca,0x45,0x69,0xc9,0x29,0x55,0x55,0xa5,0x41,0x03,0xc1,0x69,0xc0,0x93,0x01,0x00,0x01,0x45,0x8b,0xc8,0x4c,0x3b,0xc9,0x7c,0xaf,0x48,0x83,0xc4,0x08,0xc3};

        public static ReadOnlySpan<byte> calcヽgᐸ64fᐳᐤrspan64fᐤ  =>  new byte[166]{0x48,0x83,0xec,0x18,0xc5,0xf8,0x77,0x48,0x8b,0x11,0x8b,0x49,0x08,0x8b,0xc1,0x85,0xc0,0x75,0x07,0x33,0xc0,0x48,0x83,0xc4,0x18,0xc3,0xb8,0xc5,0x9d,0x1c,0x81,0x45,0x33,0xc0,0xff,0xc9,0x48,0x63,0xc9,0x48,0x85,0xc9,0x7e,0x75,0x4d,0x63,0xc8,0x4e,0x8d,0x0c,0xca,0x41,0xff,0xc0,0x4d,0x63,0xd0,0x4e,0x8d,0x14,0xd2,0xc4,0xc1,0x7b,0x10,0x01,0xc4,0xc1,0x7b,0x10,0x0a,0xc5,0xfb,0x11,0x44,0x24,0x10,0x4c,0x8b,0x4c,0x24,0x10,0xc5,0xfb,0x11,0x4c,0x24,0x08,0x4c,0x8b,0x54,0x24,0x08,0x4d,0x8b,0xd9,0x49,0xc1,0xeb,0x20,0x45,0x69,0xdb,0x29,0x55,0x55,0xa5,0x45,0x03,0xcb,0x4d,0x8b,0xda,0x49,0xc1,0xeb,0x20,0x45,0x69,0xdb,0x29,0x55,0x55,0xa5,0x45,0x03,0xd3,0x45,0x69,0xd2,0x29,0x55,0x55,0xa5,0x45,0x03,0xca,0x45,0x69,0xc9,0x29,0x55,0x55,0xa5,0x41,0x03,0xc1,0x69,0xc0,0x93,0x01,0x00,0x01,0x45,0x8b,0xc8,0x4c,0x3b,0xc9,0x7c,0x8b,0x48,0x83,0xc4,0x18,0xc3};

    }
}
