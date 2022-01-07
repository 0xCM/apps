﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2022-01-06 21:17:27 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class lib_bitposcalcs
    {
        public static ReadOnlySpan<byte> deltaヽᐤBitPosㆍBitPosᐤ  =>  new byte[57]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0x02,0x44,0x8b,0x42,0x04,0x8b,0x52,0x08,0x44,0x8b,0x09,0x44,0x8b,0x51,0x04,0x8b,0x49,0x08,0x41,0x0f,0xaf,0xc9,0x41,0x03,0xca,0x44,0x8b,0xc9,0x0f,0xaf,0xc2,0x44,0x03,0xc0,0x45,0x3b,0xc1,0x72,0x06,0x41,0x8b,0xc0,0x2b,0xc1,0xc3,0x8b,0xc1,0x41,0x2b,0xc0,0xc3};

        public static ReadOnlySpan<byte> addヽᐤBitPosᕀrefㆍ32uᐤ  =>  new byte[61]{0x0f,0x1f,0x44,0x00,0x00,0x44,0x8b,0x41,0x08,0x45,0x8b,0xc8,0x44,0x8b,0x11,0x44,0x8b,0x59,0x04,0x45,0x0f,0xaf,0xca,0x45,0x03,0xcb,0x44,0x03,0xca,0x41,0x8b,0xc1,0x33,0xd2,0x41,0xf7,0xf0,0x89,0x01,0x44,0x8b,0x41,0x08,0x41,0x8b,0xc1,0x33,0xd2,0x41,0xf7,0xf0,0x0f,0xb6,0xc2,0x89,0x41,0x04,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> incヽᐤBitPosᕀrefᐤ  =>  new byte[36]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0x41,0x04,0x8b,0x51,0x08,0xff,0xca,0x3b,0xc2,0x73,0x08,0x48,0x8d,0x41,0x04,0xff,0x00,0xeb,0x07,0xff,0x01,0x33,0xc0,0x89,0x41,0x04,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> decヽᐤBitPosᕀrefᐤ  =>  new byte[38]{0x0f,0x1f,0x44,0x00,0x00,0x83,0x79,0x04,0x00,0x74,0x08,0x48,0x8d,0x41,0x04,0xff,0x08,0xeb,0x0f,0x83,0x39,0x00,0x74,0x0a,0x8b,0x41,0x08,0xff,0xc8,0x89,0x41,0x04,0xff,0x09,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> subヽᐤBitPosᕀrefㆍ32uᐤ  =>  new byte[75]{0x0f,0x1f,0x44,0x00,0x00,0x44,0x8b,0xc2,0x8b,0x41,0x08,0x8b,0x11,0x44,0x8b,0x49,0x04,0x0f,0xaf,0xc2,0x41,0x03,0xc1,0x41,0x2b,0xc0,0x85,0xc0,0x74,0x22,0x44,0x8b,0x49,0x08,0x41,0x8b,0xc0,0x33,0xd2,0x41,0xf7,0xf1,0x89,0x01,0x44,0x8b,0x49,0x08,0x41,0x8b,0xc0,0x33,0xd2,0x41,0xf7,0xf1,0x0f,0xb6,0xc2,0x89,0x41,0x04,0xeb,0x07,0x33,0xc0,0x89,0x01,0x89,0x41,0x04,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> eqヽᐤBitPosᕀinㆍBitPosᕀinᐤ  =>  new byte[35]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0x01,0x3b,0x02,0x75,0x15,0x8b,0x41,0x04,0x3b,0x42,0x04,0x75,0x0d,0x8b,0x41,0x08,0x3b,0x42,0x08,0x0f,0x94,0xc0,0x0f,0xb6,0xc0,0xc3,0x33,0xc0,0xc3};

        public static ReadOnlySpan<byte> linearIndexヽᐤ32uㆍ32uᐤ  =>  new byte[12]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0xc2,0x33,0xd2,0xf7,0xf1,0xc3};

        public static ReadOnlySpan<byte> linearIndexヽᐤ32uㆍ32uㆍ32uᐤ  =>  new byte[14]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0xc2,0x0f,0xaf,0xc1,0x41,0x03,0xc0,0xc3};

        public static ReadOnlySpan<byte> linearIndexヽᐤBitPosᕀinᐤ  =>  new byte[19]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0x41,0x08,0x8b,0x11,0x8b,0x49,0x04,0x0f,0xaf,0xc2,0x03,0xc1,0xc3};

        public static ReadOnlySpan<byte> offsetModヽᐤ32uㆍ32uᐤ  =>  new byte[15]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0xc2,0x33,0xd2,0xf7,0xf1,0x0f,0xb6,0xc2,0xc3};

        public static ReadOnlySpan<byte> addヽgᐸ8uᐳᐤBitPosᐸbyteᐳᕀrefㆍ32uᐤ  =>  new byte[65]{0x48,0x83,0xec,0x28,0xc5,0xf8,0x77,0xc5,0xfa,0x6f,0x01,0xc5,0xfa,0x7f,0x44,0x24,0x08,0xc5,0xfa,0x6f,0x41,0x10,0xc5,0xfa,0x7f,0x44,0x24,0x18,0x8b,0x44,0x24,0x08,0xc1,0xe0,0x03,0x03,0x44,0x24,0x0c,0x03,0xc2,0x8b,0xd0,0xc1,0xea,0x03,0x89,0x11,0x83,0xe0,0x07,0x0f,0xb6,0xc0,0x89,0x41,0x04,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> addヽgᐸ16uᐳᐤBitPosᐸushortᐳᕀrefㆍ32uᐤ  =>  new byte[65]{0x48,0x83,0xec,0x28,0xc5,0xf8,0x77,0xc5,0xfa,0x6f,0x01,0xc5,0xfa,0x7f,0x44,0x24,0x08,0xc5,0xfa,0x6f,0x41,0x10,0xc5,0xfa,0x7f,0x44,0x24,0x18,0x8b,0x44,0x24,0x08,0xc1,0xe0,0x04,0x03,0x44,0x24,0x0c,0x03,0xc2,0x8b,0xd0,0xc1,0xea,0x04,0x89,0x11,0x83,0xe0,0x0f,0x0f,0xb6,0xc0,0x89,0x41,0x04,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> addヽgᐸ32uᐳᐤBitPosᐸuintᐳᕀrefㆍ32uᐤ  =>  new byte[65]{0x48,0x83,0xec,0x28,0xc5,0xf8,0x77,0xc5,0xfa,0x6f,0x01,0xc5,0xfa,0x7f,0x44,0x24,0x08,0xc5,0xfa,0x6f,0x41,0x10,0xc5,0xfa,0x7f,0x44,0x24,0x18,0x8b,0x44,0x24,0x08,0xc1,0xe0,0x05,0x03,0x44,0x24,0x0c,0x03,0xc2,0x8b,0xd0,0xc1,0xea,0x05,0x89,0x11,0x83,0xe0,0x1f,0x0f,0xb6,0xc0,0x89,0x41,0x04,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> addヽgᐸ64uᐳᐤBitPosᐸulongᐳᕀrefㆍ32uᐤ  =>  new byte[65]{0x48,0x83,0xec,0x28,0xc5,0xf8,0x77,0xc5,0xfa,0x6f,0x01,0xc5,0xfa,0x7f,0x44,0x24,0x08,0xc5,0xfa,0x6f,0x41,0x10,0xc5,0xfa,0x7f,0x44,0x24,0x18,0x8b,0x44,0x24,0x08,0xc1,0xe0,0x06,0x03,0x44,0x24,0x0c,0x03,0xc2,0x8b,0xd0,0xc1,0xea,0x06,0x89,0x11,0x83,0xe0,0x3f,0x0f,0xb6,0xc0,0x89,0x41,0x04,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> countヽgᐸ8uᐳᐤBitPosᐸbyteᐳᕀinㆍBitPosᐸbyteᐳᕀinᐤ  =>  new byte[166]{0x48,0x83,0xec,0x68,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x48,0x48,0x89,0x44,0x24,0x50,0x48,0x89,0x44,0x24,0x58,0x48,0x89,0x44,0x24,0x60,0xc5,0xfa,0x6f,0x01,0xc5,0xfa,0x7f,0x44,0x24,0x48,0xc5,0xfa,0x6f,0x41,0x10,0xc5,0xfa,0x7f,0x44,0x24,0x58,0xc5,0xfa,0x6f,0x44,0x24,0x48,0xc5,0xfa,0x7f,0x44,0x24,0x28,0xc5,0xfa,0x6f,0x44,0x24,0x58,0xc5,0xfa,0x7f,0x44,0x24,0x38,0x8b,0x44,0x24,0x28,0x8b,0x4c,0x24,0x2c,0x8d,0x04,0xc1,0xc5,0xfa,0x6f,0x02,0xc5,0xfa,0x7f,0x44,0x24,0x48,0xc5,0xfa,0x6f,0x42,0x10,0xc5,0xfa,0x7f,0x44,0x24,0x58,0xc5,0xfa,0x6f,0x44,0x24,0x48,0xc5,0xfa,0x7f,0x44,0x24,0x08,0xc5,0xfa,0x6f,0x44,0x24,0x58,0xc5,0xfa,0x7f,0x44,0x24,0x18,0x8b,0x54,0x24,0x08,0x8b,0x4c,0x24,0x0c,0x8d,0x14,0xd1,0x48,0x2b,0xc2,0x48,0x8b,0xd0,0x48,0xc1,0xfa,0x3f,0x03,0xd0,0x48,0xc1,0xf8,0x3f,0x33,0xc2,0xff,0xc0,0x48,0x83,0xc4,0x68,0xc3};

        public static ReadOnlySpan<byte> countヽgᐸ16uᐳᐤBitPosᐸushortᐳᕀinㆍBitPosᐸushortᐳᕀinᐤ  =>  new byte[170]{0x48,0x83,0xec,0x68,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x48,0x48,0x89,0x44,0x24,0x50,0x48,0x89,0x44,0x24,0x58,0x48,0x89,0x44,0x24,0x60,0xc5,0xfa,0x6f,0x01,0xc5,0xfa,0x7f,0x44,0x24,0x48,0xc5,0xfa,0x6f,0x41,0x10,0xc5,0xfa,0x7f,0x44,0x24,0x58,0xc5,0xfa,0x6f,0x44,0x24,0x48,0xc5,0xfa,0x7f,0x44,0x24,0x28,0xc5,0xfa,0x6f,0x44,0x24,0x58,0xc5,0xfa,0x7f,0x44,0x24,0x38,0x8b,0x44,0x24,0x28,0xc1,0xe0,0x04,0x03,0x44,0x24,0x2c,0x8b,0xc0,0xc5,0xfa,0x6f,0x02,0xc5,0xfa,0x7f,0x44,0x24,0x48,0xc5,0xfa,0x6f,0x42,0x10,0xc5,0xfa,0x7f,0x44,0x24,0x58,0xc5,0xfa,0x6f,0x44,0x24,0x48,0xc5,0xfa,0x7f,0x44,0x24,0x08,0xc5,0xfa,0x6f,0x44,0x24,0x58,0xc5,0xfa,0x7f,0x44,0x24,0x18,0x8b,0x54,0x24,0x08,0xc1,0xe2,0x04,0x03,0x54,0x24,0x0c,0x8b,0xd2,0x48,0x2b,0xc2,0x48,0x8b,0xd0,0x48,0xc1,0xfa,0x3f,0x03,0xd0,0x48,0xc1,0xf8,0x3f,0x33,0xc2,0xff,0xc0,0x48,0x83,0xc4,0x68,0xc3};

        public static ReadOnlySpan<byte> countヽgᐸ32uᐳᐤBitPosᐸuintᐳᕀinㆍBitPosᐸuintᐳᕀinᐤ  =>  new byte[170]{0x48,0x83,0xec,0x68,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x48,0x48,0x89,0x44,0x24,0x50,0x48,0x89,0x44,0x24,0x58,0x48,0x89,0x44,0x24,0x60,0xc5,0xfa,0x6f,0x01,0xc5,0xfa,0x7f,0x44,0x24,0x48,0xc5,0xfa,0x6f,0x41,0x10,0xc5,0xfa,0x7f,0x44,0x24,0x58,0xc5,0xfa,0x6f,0x44,0x24,0x48,0xc5,0xfa,0x7f,0x44,0x24,0x28,0xc5,0xfa,0x6f,0x44,0x24,0x58,0xc5,0xfa,0x7f,0x44,0x24,0x38,0x8b,0x44,0x24,0x28,0xc1,0xe0,0x05,0x03,0x44,0x24,0x2c,0x8b,0xc0,0xc5,0xfa,0x6f,0x02,0xc5,0xfa,0x7f,0x44,0x24,0x48,0xc5,0xfa,0x6f,0x42,0x10,0xc5,0xfa,0x7f,0x44,0x24,0x58,0xc5,0xfa,0x6f,0x44,0x24,0x48,0xc5,0xfa,0x7f,0x44,0x24,0x08,0xc5,0xfa,0x6f,0x44,0x24,0x58,0xc5,0xfa,0x7f,0x44,0x24,0x18,0x8b,0x54,0x24,0x08,0xc1,0xe2,0x05,0x03,0x54,0x24,0x0c,0x8b,0xd2,0x48,0x2b,0xc2,0x48,0x8b,0xd0,0x48,0xc1,0xfa,0x3f,0x03,0xd0,0x48,0xc1,0xf8,0x3f,0x33,0xc2,0xff,0xc0,0x48,0x83,0xc4,0x68,0xc3};

        public static ReadOnlySpan<byte> countヽgᐸ64uᐳᐤBitPosᐸulongᐳᕀinㆍBitPosᐸulongᐳᕀinᐤ  =>  new byte[170]{0x48,0x83,0xec,0x68,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x48,0x48,0x89,0x44,0x24,0x50,0x48,0x89,0x44,0x24,0x58,0x48,0x89,0x44,0x24,0x60,0xc5,0xfa,0x6f,0x01,0xc5,0xfa,0x7f,0x44,0x24,0x48,0xc5,0xfa,0x6f,0x41,0x10,0xc5,0xfa,0x7f,0x44,0x24,0x58,0xc5,0xfa,0x6f,0x44,0x24,0x48,0xc5,0xfa,0x7f,0x44,0x24,0x28,0xc5,0xfa,0x6f,0x44,0x24,0x58,0xc5,0xfa,0x7f,0x44,0x24,0x38,0x8b,0x44,0x24,0x28,0xc1,0xe0,0x06,0x03,0x44,0x24,0x2c,0x8b,0xc0,0xc5,0xfa,0x6f,0x02,0xc5,0xfa,0x7f,0x44,0x24,0x48,0xc5,0xfa,0x6f,0x42,0x10,0xc5,0xfa,0x7f,0x44,0x24,0x58,0xc5,0xfa,0x6f,0x44,0x24,0x48,0xc5,0xfa,0x7f,0x44,0x24,0x08,0xc5,0xfa,0x6f,0x44,0x24,0x58,0xc5,0xfa,0x7f,0x44,0x24,0x18,0x8b,0x54,0x24,0x08,0xc1,0xe2,0x06,0x03,0x54,0x24,0x0c,0x8b,0xd2,0x48,0x2b,0xc2,0x48,0x8b,0xd0,0x48,0xc1,0xfa,0x3f,0x03,0xd0,0x48,0xc1,0xf8,0x3f,0x33,0xc2,0xff,0xc0,0x48,0x83,0xc4,0x68,0xc3};

        public static ReadOnlySpan<byte> incヽgᐸ8uᐳᐤBitPosᐸbyteᐳᕀrefᐤ  =>  new byte[32]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0x41,0x04,0x83,0xf8,0x07,0x73,0x08,0x48,0x8d,0x41,0x04,0xff,0x00,0xeb,0x07,0xff,0x01,0x33,0xc0,0x89,0x41,0x04,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> incヽgᐸ16uᐳᐤBitPosᐸushortᐳᕀrefᐤ  =>  new byte[32]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0x41,0x04,0x83,0xf8,0x0f,0x73,0x08,0x48,0x8d,0x41,0x04,0xff,0x00,0xeb,0x07,0xff,0x01,0x33,0xc0,0x89,0x41,0x04,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> incヽgᐸ32uᐳᐤBitPosᐸuintᐳᕀrefᐤ  =>  new byte[32]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0x41,0x04,0x83,0xf8,0x1f,0x73,0x08,0x48,0x8d,0x41,0x04,0xff,0x00,0xeb,0x07,0xff,0x01,0x33,0xc0,0x89,0x41,0x04,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> incヽgᐸ64uᐳᐤBitPosᐸulongᐳᕀrefᐤ  =>  new byte[32]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0x41,0x04,0x83,0xf8,0x3f,0x73,0x08,0x48,0x8d,0x41,0x04,0xff,0x00,0xeb,0x07,0xff,0x01,0x33,0xc0,0x89,0x41,0x04,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> decヽgᐸ8uᐳᐤBitPosᐸbyteᐳᕀrefᐤ  =>  new byte[37]{0x0f,0x1f,0x44,0x00,0x00,0x83,0x79,0x04,0x00,0x74,0x08,0x48,0x8d,0x41,0x04,0xff,0x08,0xeb,0x0e,0x83,0x39,0x00,0x74,0x09,0xc7,0x41,0x04,0x07,0x00,0x00,0x00,0xff,0x09,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> decヽgᐸ16uᐳᐤBitPosᐸushortᐳᕀrefᐤ  =>  new byte[37]{0x0f,0x1f,0x44,0x00,0x00,0x83,0x79,0x04,0x00,0x74,0x08,0x48,0x8d,0x41,0x04,0xff,0x08,0xeb,0x0e,0x83,0x39,0x00,0x74,0x09,0xc7,0x41,0x04,0x0f,0x00,0x00,0x00,0xff,0x09,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> decヽgᐸ32uᐳᐤBitPosᐸuintᐳᕀrefᐤ  =>  new byte[37]{0x0f,0x1f,0x44,0x00,0x00,0x83,0x79,0x04,0x00,0x74,0x08,0x48,0x8d,0x41,0x04,0xff,0x08,0xeb,0x0e,0x83,0x39,0x00,0x74,0x09,0xc7,0x41,0x04,0x1f,0x00,0x00,0x00,0xff,0x09,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> decヽgᐸ64uᐳᐤBitPosᐸulongᐳᕀrefᐤ  =>  new byte[37]{0x0f,0x1f,0x44,0x00,0x00,0x83,0x79,0x04,0x00,0x74,0x08,0x48,0x8d,0x41,0x04,0xff,0x08,0xeb,0x0e,0x83,0x39,0x00,0x74,0x09,0xc7,0x41,0x04,0x3f,0x00,0x00,0x00,0xff,0x09,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> subヽgᐸ8uᐳᐤBitPosᐸbyteᐳᕀrefㆍ32uᐤ  =>  new byte[80]{0x48,0x83,0xec,0x28,0xc5,0xf8,0x77,0xc5,0xfa,0x6f,0x01,0xc5,0xfa,0x7f,0x44,0x24,0x08,0xc5,0xfa,0x6f,0x41,0x10,0xc5,0xfa,0x7f,0x44,0x24,0x18,0x8b,0x44,0x24,0x08,0x44,0x8b,0x44,0x24,0x0c,0x41,0x8d,0x04,0xc0,0x2b,0xc2,0x85,0xc0,0x74,0x12,0x8b,0xc2,0xc1,0xe8,0x03,0x89,0x01,0x83,0xe2,0x07,0x0f,0xb6,0xc2,0x89,0x41,0x04,0xeb,0x07,0x33,0xc0,0x89,0x01,0x89,0x41,0x04,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> subヽgᐸ16uᐳᐤBitPosᐸushortᐳᕀrefㆍ32uᐤ  =>  new byte[78]{0x48,0x83,0xec,0x28,0xc5,0xf8,0x77,0xc5,0xfa,0x6f,0x01,0xc5,0xfa,0x7f,0x44,0x24,0x08,0xc5,0xfa,0x6f,0x41,0x10,0xc5,0xfa,0x7f,0x44,0x24,0x18,0x8b,0x44,0x24,0x08,0xc1,0xe0,0x04,0x03,0x44,0x24,0x0c,0x2b,0xc2,0x85,0xc0,0x74,0x12,0x8b,0xc2,0xc1,0xe8,0x04,0x89,0x01,0x83,0xe2,0x0f,0x0f,0xb6,0xc2,0x89,0x41,0x04,0xeb,0x07,0x33,0xc0,0x89,0x01,0x89,0x41,0x04,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> subヽgᐸ32uᐳᐤBitPosᐸuintᐳᕀrefㆍ32uᐤ  =>  new byte[78]{0x48,0x83,0xec,0x28,0xc5,0xf8,0x77,0xc5,0xfa,0x6f,0x01,0xc5,0xfa,0x7f,0x44,0x24,0x08,0xc5,0xfa,0x6f,0x41,0x10,0xc5,0xfa,0x7f,0x44,0x24,0x18,0x8b,0x44,0x24,0x08,0xc1,0xe0,0x05,0x03,0x44,0x24,0x0c,0x2b,0xc2,0x85,0xc0,0x74,0x12,0x8b,0xc2,0xc1,0xe8,0x05,0x89,0x01,0x83,0xe2,0x1f,0x0f,0xb6,0xc2,0x89,0x41,0x04,0xeb,0x07,0x33,0xc0,0x89,0x01,0x89,0x41,0x04,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> subヽgᐸ64uᐳᐤBitPosᐸulongᐳᕀrefㆍ32uᐤ  =>  new byte[78]{0x48,0x83,0xec,0x28,0xc5,0xf8,0x77,0xc5,0xfa,0x6f,0x01,0xc5,0xfa,0x7f,0x44,0x24,0x08,0xc5,0xfa,0x6f,0x41,0x10,0xc5,0xfa,0x7f,0x44,0x24,0x18,0x8b,0x44,0x24,0x08,0xc1,0xe0,0x06,0x03,0x44,0x24,0x0c,0x2b,0xc2,0x85,0xc0,0x74,0x12,0x8b,0xc2,0xc1,0xe8,0x06,0x89,0x01,0x83,0xe2,0x3f,0x0f,0xb6,0xc2,0x89,0x41,0x04,0xeb,0x07,0x33,0xc0,0x89,0x01,0x89,0x41,0x04,0x48,0x8b,0xc1,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> eqヽgᐸ8uᐳᐤBitPosᐸbyteᐳᕀinㆍBitPosᐸbyteᐳᕀinᐤ  =>  new byte[27]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0x01,0x3b,0x02,0x75,0x0d,0x8b,0x41,0x04,0x3b,0x42,0x04,0x0f,0x94,0xc0,0x0f,0xb6,0xc0,0xc3,0x33,0xc0,0xc3};

        public static ReadOnlySpan<byte> eqヽgᐸ16uᐳᐤBitPosᐸushortᐳᕀinㆍBitPosᐸushortᐳᕀinᐤ  =>  new byte[27]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0x01,0x3b,0x02,0x75,0x0d,0x8b,0x41,0x04,0x3b,0x42,0x04,0x0f,0x94,0xc0,0x0f,0xb6,0xc0,0xc3,0x33,0xc0,0xc3};

        public static ReadOnlySpan<byte> eqヽgᐸ32uᐳᐤBitPosᐸuintᐳᕀinㆍBitPosᐸuintᐳᕀinᐤ  =>  new byte[27]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0x01,0x3b,0x02,0x75,0x0d,0x8b,0x41,0x04,0x3b,0x42,0x04,0x0f,0x94,0xc0,0x0f,0xb6,0xc0,0xc3,0x33,0xc0,0xc3};

        public static ReadOnlySpan<byte> eqヽgᐸ64uᐳᐤBitPosᐸulongᐳᕀinㆍBitPosᐸulongᐳᕀinᐤ  =>  new byte[27]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0x01,0x3b,0x02,0x75,0x0d,0x8b,0x41,0x04,0x3b,0x42,0x04,0x0f,0x94,0xc0,0x0f,0xb6,0xc0,0xc3,0x33,0xc0,0xc3};

    }
}
