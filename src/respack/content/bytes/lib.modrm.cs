﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2022-01-06 21:17:27 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class lib_modrm
    {
        public static ReadOnlySpan<byte> Valueヽᐤᐤ  =>  new byte[847]{0xe9,0xb3,0x0f,0x50,0xfe,0x5f,0x10,0x10,0xe8,0xdb,0x76,0x16,0x5e,0x5e,0x11,0x0f,0xe8,0xd3,0x76,0x16,0x5e,0x5e,0x13,0x0e,0xe9,0xcb,0x0f,0x50,0xfe,0x5f,0x15,0x0d,0xe8,0xc3,0x76,0x16,0x5e,0x5e,0x16,0x0c,0xe8,0xbb,0x76,0x16,0x5e,0x5e,0x18,0x0b,0xe8,0xb3,0x76,0x16,0x5e,0x5e,0x19,0x0a,0xe8,0xab,0x76,0x16,0x5e,0x5e,0x1b,0x09,0xe8,0xa3,0x76,0x16,0x5e,0x5e,0x1c,0x08,0xe8,0x9b,0x76,0x16,0x5e,0x5e,0x1e,0x07,0xe8,0x93,0x76,0x16,0x5e,0x5e,0x1f,0x06,0xe8,0x8b,0x76,0x16,0x5e,0x5e,0x21,0x05,0xe8,0x83,0x76,0x16,0x5e,0x5e,0x22,0x04,0xe8,0x7b,0x76,0x16,0x5e,0x5e,0x24,0x03,0xe8,0x73,0x76,0x16,0x5e,0x5e,0x26,0x02,0xe8,0x6b,0x76,0x16,0x5e,0x5e,0x28,0x01,0xe8,0x63,0x76,0x16,0x5e,0x5e,0x2a,0x00,0xd0,0x0d,0xce,0x66,0xfb,0x7f,0x00,0x00,0xe8,0x53,0x76,0x16,0x5e,0x5e,0x00,0x06,0xe8,0x4b,0x76,0x16,0x5e,0x5e,0x02,0x05,0xe8,0x43,0x76,0x16,0x5e,0x5e,0x04,0x04,0xe8,0x3b,0x76,0x16,0x5e,0x5e,0x06,0x03,0xe8,0x33,0x76,0x16,0x5e,0x5e,0x08,0x02,0xe8,0x2b,0x76,0x16,0x5e,0x5e,0x0a,0x01,0xe8,0x23,0x76,0x16,0x5e,0x5e,0x0c,0x00,0x48,0x14,0xce,0x66,0xfb,0x7f,0x00,0x00,0xe8,0x13,0x76,0x16,0x5e,0x5e,0x00,0x03,0xe8,0x0b,0x76,0x16,0x5e,0x5e,0x02,0x02,0xe8,0x03,0x76,0x16,0x5e,0x5e,0x04,0x01,0xe8,0xfb,0x75,0x16,0x5e,0x5e,0x06,0x00,0xb0,0x16,0xce,0x66,0xfb,0x7f,0x00,0x00,0xe8,0xeb,0x75,0x16,0x5e,0x5e,0x00,0x0d,0xe8,0xe3,0x75,0x16,0x5e,0x5e,0x02,0x0c,0xe8,0xdb,0x75,0x16,0x5e,0x5e,0x04,0x0b,0xe8,0xd3,0x75,0x16,0x5e,0x5e,0x05,0x0a,0xe8,0xcb,0x75,0x16,0x5e,0x5e,0x07,0x09,0xe8,0xc3,0x75,0x16,0x5e,0x5e,0x08,0x08,0xe8,0xbb,0x75,0x16,0x5e,0x5e,0x0a,0x07,0xe8,0xb3,0x75,0x16,0x5e,0x5e,0x0b,0x06,0xe8,0xab,0x75,0x16,0x5e,0x5e,0x0d,0x05,0xe8,0xa3,0x75,0x16,0x5e,0x5e,0x0e,0x04,0xe8,0x9b,0x75,0x16,0x5e,0x5e,0x10,0x03,0xe8,0x93,0x75,0x16,0x5e,0x5e,0x11,0x02,0xe8,0x8b,0x75,0x16,0x5e,0x5e,0x13,0x01,0xe8,0x83,0x75,0x16,0x5e,0x5e,0x15,0x00,0xe8,0x18,0xce,0x66,0xfb,0x7f,0x00,0x00,0xe8,0x73,0x75,0x16,0x5e,0x5e,0x00,0x02,0xe8,0x6b,0x75,0x16,0x5e,0x5e,0x04,0x01,0xe8,0x63,0x75,0x16,0x5e,0x5e,0x08,0x00,0x18,0x1b,0xce,0x66,0xfb,0x7f,0x00,0x00,0xe8,0x53,0x75,0x16,0x5e,0x5e,0x00,0x00,0x48,0x1d,0xce,0x66,0xfb,0x7f,0x00,0x00,0xe8,0x43,0x75,0x16,0x5e,0x5e,0x00,0x10,0xe8,0x3b,0x75,0x16,0x5e,0x5e,0x02,0x0f,0xe8,0x33,0x75,0x16,0x5e,0x5e,0x03,0x0e,0xe8,0x2b,0x75,0x16,0x5e,0x5e,0x05,0x0d,0xe8,0x23,0x75,0x16,0x5e,0x5e,0x06,0x0c,0xe8,0x1b,0x75,0x16,0x5e,0x5e,0x08,0x0b,0xe8,0x13,0x75,0x16,0x5e,0x5e,0x0a,0x0a,0xe8,0x0b,0x75,0x16,0x5e,0x5e,0x0c,0x09,0xe8,0x03,0x75,0x16,0x5e,0x5e,0x0d,0x08,0xe8,0xfb,0x74,0x16,0x5e,0x5e,0x0f,0x07,0xe8,0xf3,0x74,0x16,0x5e,0x5e,0x10,0x06,0xe8,0xeb,0x74,0x16,0x5e,0x5e,0x12,0x05,0xe8,0xe3,0x74,0x16,0x5e,0x5e,0x13,0x04,0xe8,0xdb,0x74,0x16,0x5e,0x5e,0x15,0x03,0xe8,0xd3,0x74,0x16,0x5e,0x5e,0x16,0x02,0xe8,0xcb,0x74,0x16,0x5e,0x5e,0x18,0x01,0xe8,0xc3,0x74,0x16,0x5e,0x5e,0x1a,0x00,0x48,0x1f,0xce,0x66,0xfb,0x7f,0x00,0x00,0xe8,0xb3,0x74,0x16,0x5e,0x5e,0x00,0x02,0xe8,0xab,0x74,0x16,0x5e,0x5e,0x04,0x01,0xe8,0xa3,0x74,0x16,0x5e,0x5e,0x08,0x00,0xb0,0x21,0xce,0x66,0xfb,0x7f,0x00,0x00,0xe8,0x93,0x74,0x16,0x5e,0x5e,0x00,0x00,0x30,0x23,0xce,0x66,0xfb,0x7f,0x00,0x00,0xe8,0x83,0x74,0x16,0x5e,0x5e,0x00,0x00,0xe0,0x23,0xce,0x66,0xfb,0x7f,0x00,0x00,0xe8,0x73,0x74,0x16,0x5e,0x5e,0x00,0x03,0xe8,0x6b,0x74,0x16,0x5e,0x5e,0x02,0x02,0xe8,0x63,0x74,0x16,0x5e,0x5e,0x04,0x01,0xe8,0x5b,0x74,0x16,0x5e,0x5e,0x06,0x00,0x90,0x24,0xce,0x66,0xfb,0x7f,0x00,0x00,0xe8,0x4b,0x74,0x16,0x5e,0x5e,0x00,0x02,0xe8,0x43,0x74,0x16,0x5e,0x5e,0x04,0x01,0xe8,0x3b,0x74,0x16,0x5e,0x5e,0x08,0x00,0xb0,0x28,0xce,0x66,0xfb,0x7f,0x00,0x00,0xe8,0x2b,0x74,0x16,0x5e,0x5e,0x00,0x00,0x30,0x2a,0xce,0x66,0xfb,0x7f,0x00,0x00,0xe8,0x1b,0x74,0x16,0x5e,0x5e,0x00,0x00,0xe0,0x2a,0xce,0x66,0xfb,0x7f,0x00,0x00,0xe8,0x0b,0x74,0x16,0x5e,0x5e,0x00,0x02,0xe8,0x03,0x74,0x16,0x5e,0x5e,0x04,0x01,0xe8,0xfb,0x73,0x16,0x5e,0x5e,0x08,0x00,0x20,0x2e,0xce,0x66,0xfb,0x7f,0x00,0x00,0xe8,0xeb,0x73,0x16,0x5e,0x5e,0x00,0x00,0xa0,0x2f,0xce,0x66,0xfb,0x7f,0x00,0x00,0xe8,0xdb,0x73,0x16,0x5e,0x5e,0x00,0x00,0x50,0x30,0xce,0x66,0xfb,0x7f,0x00,0x00,0xe8,0xcb,0x73,0x16,0x5e,0x5e,0x00,0x06,0xe8,0xc3,0x73,0x16,0x5e,0x5e,0x02,0x05,0xe8,0xbb,0x73,0x16,0x5e,0x5e,0x04,0x04,0xe8,0xb3,0x73,0x16,0x5e,0x5e,0x06,0x03,0xe8,0xab,0x73,0x16,0x5e,0x5e,0x08,0x02,0xe8,0xa3,0x73,0x16,0x5e,0x5e,0x0a,0x01,0xe8,0x9b,0x73,0x16,0x5e,0x5e,0x0c};

        public static ReadOnlySpan<byte> Formatヽᐤᐤ  =>  new byte[823]{0xe9,0xcb,0x0f,0x50,0xfe,0x5f,0x15,0x0d,0xe8,0xc3,0x76,0x16,0x5e,0x5e,0x16,0x0c,0xe8,0xbb,0x76,0x16,0x5e,0x5e,0x18,0x0b,0xe8,0xb3,0x76,0x16,0x5e,0x5e,0x19,0x0a,0xe8,0xab,0x76,0x16,0x5e,0x5e,0x1b,0x09,0xe8,0xa3,0x76,0x16,0x5e,0x5e,0x1c,0x08,0xe8,0x9b,0x76,0x16,0x5e,0x5e,0x1e,0x07,0xe8,0x93,0x76,0x16,0x5e,0x5e,0x1f,0x06,0xe8,0x8b,0x76,0x16,0x5e,0x5e,0x21,0x05,0xe8,0x83,0x76,0x16,0x5e,0x5e,0x22,0x04,0xe8,0x7b,0x76,0x16,0x5e,0x5e,0x24,0x03,0xe8,0x73,0x76,0x16,0x5e,0x5e,0x26,0x02,0xe8,0x6b,0x76,0x16,0x5e,0x5e,0x28,0x01,0xe8,0x63,0x76,0x16,0x5e,0x5e,0x2a,0x00,0xd0,0x0d,0xce,0x66,0xfb,0x7f,0x00,0x00,0xe8,0x53,0x76,0x16,0x5e,0x5e,0x00,0x06,0xe8,0x4b,0x76,0x16,0x5e,0x5e,0x02,0x05,0xe8,0x43,0x76,0x16,0x5e,0x5e,0x04,0x04,0xe8,0x3b,0x76,0x16,0x5e,0x5e,0x06,0x03,0xe8,0x33,0x76,0x16,0x5e,0x5e,0x08,0x02,0xe8,0x2b,0x76,0x16,0x5e,0x5e,0x0a,0x01,0xe8,0x23,0x76,0x16,0x5e,0x5e,0x0c,0x00,0x48,0x14,0xce,0x66,0xfb,0x7f,0x00,0x00,0xe8,0x13,0x76,0x16,0x5e,0x5e,0x00,0x03,0xe8,0x0b,0x76,0x16,0x5e,0x5e,0x02,0x02,0xe8,0x03,0x76,0x16,0x5e,0x5e,0x04,0x01,0xe8,0xfb,0x75,0x16,0x5e,0x5e,0x06,0x00,0xb0,0x16,0xce,0x66,0xfb,0x7f,0x00,0x00,0xe8,0xeb,0x75,0x16,0x5e,0x5e,0x00,0x0d,0xe8,0xe3,0x75,0x16,0x5e,0x5e,0x02,0x0c,0xe8,0xdb,0x75,0x16,0x5e,0x5e,0x04,0x0b,0xe8,0xd3,0x75,0x16,0x5e,0x5e,0x05,0x0a,0xe8,0xcb,0x75,0x16,0x5e,0x5e,0x07,0x09,0xe8,0xc3,0x75,0x16,0x5e,0x5e,0x08,0x08,0xe8,0xbb,0x75,0x16,0x5e,0x5e,0x0a,0x07,0xe8,0xb3,0x75,0x16,0x5e,0x5e,0x0b,0x06,0xe8,0xab,0x75,0x16,0x5e,0x5e,0x0d,0x05,0xe8,0xa3,0x75,0x16,0x5e,0x5e,0x0e,0x04,0xe8,0x9b,0x75,0x16,0x5e,0x5e,0x10,0x03,0xe8,0x93,0x75,0x16,0x5e,0x5e,0x11,0x02,0xe8,0x8b,0x75,0x16,0x5e,0x5e,0x13,0x01,0xe8,0x83,0x75,0x16,0x5e,0x5e,0x15,0x00,0xe8,0x18,0xce,0x66,0xfb,0x7f,0x00,0x00,0xe8,0x73,0x75,0x16,0x5e,0x5e,0x00,0x02,0xe8,0x6b,0x75,0x16,0x5e,0x5e,0x04,0x01,0xe8,0x63,0x75,0x16,0x5e,0x5e,0x08,0x00,0x18,0x1b,0xce,0x66,0xfb,0x7f,0x00,0x00,0xe8,0x53,0x75,0x16,0x5e,0x5e,0x00,0x00,0x48,0x1d,0xce,0x66,0xfb,0x7f,0x00,0x00,0xe8,0x43,0x75,0x16,0x5e,0x5e,0x00,0x10,0xe8,0x3b,0x75,0x16,0x5e,0x5e,0x02,0x0f,0xe8,0x33,0x75,0x16,0x5e,0x5e,0x03,0x0e,0xe8,0x2b,0x75,0x16,0x5e,0x5e,0x05,0x0d,0xe8,0x23,0x75,0x16,0x5e,0x5e,0x06,0x0c,0xe8,0x1b,0x75,0x16,0x5e,0x5e,0x08,0x0b,0xe8,0x13,0x75,0x16,0x5e,0x5e,0x0a,0x0a,0xe8,0x0b,0x75,0x16,0x5e,0x5e,0x0c,0x09,0xe8,0x03,0x75,0x16,0x5e,0x5e,0x0d,0x08,0xe8,0xfb,0x74,0x16,0x5e,0x5e,0x0f,0x07,0xe8,0xf3,0x74,0x16,0x5e,0x5e,0x10,0x06,0xe8,0xeb,0x74,0x16,0x5e,0x5e,0x12,0x05,0xe8,0xe3,0x74,0x16,0x5e,0x5e,0x13,0x04,0xe8,0xdb,0x74,0x16,0x5e,0x5e,0x15,0x03,0xe8,0xd3,0x74,0x16,0x5e,0x5e,0x16,0x02,0xe8,0xcb,0x74,0x16,0x5e,0x5e,0x18,0x01,0xe8,0xc3,0x74,0x16,0x5e,0x5e,0x1a,0x00,0x48,0x1f,0xce,0x66,0xfb,0x7f,0x00,0x00,0xe8,0xb3,0x74,0x16,0x5e,0x5e,0x00,0x02,0xe8,0xab,0x74,0x16,0x5e,0x5e,0x04,0x01,0xe8,0xa3,0x74,0x16,0x5e,0x5e,0x08,0x00,0xb0,0x21,0xce,0x66,0xfb,0x7f,0x00,0x00,0xe8,0x93,0x74,0x16,0x5e,0x5e,0x00,0x00,0x30,0x23,0xce,0x66,0xfb,0x7f,0x00,0x00,0xe8,0x83,0x74,0x16,0x5e,0x5e,0x00,0x00,0xe0,0x23,0xce,0x66,0xfb,0x7f,0x00,0x00,0xe8,0x73,0x74,0x16,0x5e,0x5e,0x00,0x03,0xe8,0x6b,0x74,0x16,0x5e,0x5e,0x02,0x02,0xe8,0x63,0x74,0x16,0x5e,0x5e,0x04,0x01,0xe8,0x5b,0x74,0x16,0x5e,0x5e,0x06,0x00,0x90,0x24,0xce,0x66,0xfb,0x7f,0x00,0x00,0xe8,0x4b,0x74,0x16,0x5e,0x5e,0x00,0x02,0xe8,0x43,0x74,0x16,0x5e,0x5e,0x04,0x01,0xe8,0x3b,0x74,0x16,0x5e,0x5e,0x08,0x00,0xb0,0x28,0xce,0x66,0xfb,0x7f,0x00,0x00,0xe8,0x2b,0x74,0x16,0x5e,0x5e,0x00,0x00,0x30,0x2a,0xce,0x66,0xfb,0x7f,0x00,0x00,0xe8,0x1b,0x74,0x16,0x5e,0x5e,0x00,0x00,0xe0,0x2a,0xce,0x66,0xfb,0x7f,0x00,0x00,0xe8,0x0b,0x74,0x16,0x5e,0x5e,0x00,0x02,0xe8,0x03,0x74,0x16,0x5e,0x5e,0x04,0x01,0xe8,0xfb,0x73,0x16,0x5e,0x5e,0x08,0x00,0x20,0x2e,0xce,0x66,0xfb,0x7f,0x00,0x00,0xe8,0xeb,0x73,0x16,0x5e,0x5e,0x00,0x00,0xa0,0x2f,0xce,0x66,0xfb,0x7f,0x00,0x00,0xe8,0xdb,0x73,0x16,0x5e,0x5e,0x00,0x00,0x50,0x30,0xce,0x66,0xfb,0x7f,0x00,0x00,0xe8,0xcb,0x73,0x16,0x5e,0x5e,0x00,0x06,0xe8,0xc3,0x73,0x16,0x5e,0x5e,0x02,0x05,0xe8,0xbb,0x73,0x16,0x5e,0x5e,0x04,0x04,0xe8,0xb3,0x73,0x16,0x5e,0x5e,0x06,0x03,0xe8,0xab,0x73,0x16,0x5e,0x5e,0x08,0x02,0xe8,0xa3,0x73,0x16,0x5e,0x5e,0x0a,0x01,0xe8,0x9b,0x73,0x16,0x5e,0x5e,0x0c};

        public static ReadOnlySpan<byte> initヽᐤ8uᐤ  =>  new byte[8]{0x0f,0x1f,0x44,0x00,0x00,0x33,0xc0,0xc3};

        public static ReadOnlySpan<byte> Rmヽᐤᐤ  =>  new byte[20]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0x01,0x25,0x07,0xff,0xff,0xff,0x83,0xe0,0x07,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> Rmヽᐤuint3ᐤ  =>  new byte[24]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0x01,0x25,0xf8,0x00,0x00,0x00,0x0f,0xb6,0xc0,0x0f,0xb6,0xd2,0x0b,0xc2,0x88,0x01,0xc3};

        public static ReadOnlySpan<byte> Regヽᐤᐤ  =>  new byte[26]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0x01,0x25,0x38,0xff,0xff,0xff,0xc1,0xe8,0x03,0x0f,0xb6,0xc0,0x83,0xe0,0x07,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> Regヽᐤuint3ᐤ  =>  new byte[30]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0x01,0x25,0xc7,0x00,0x00,0x00,0x0f,0xb6,0xc0,0x0f,0xb6,0xd2,0xc1,0xe2,0x03,0x0f,0xb6,0xd2,0x0b,0xc2,0x88,0x01,0xc3};

        public static ReadOnlySpan<byte> Modヽᐤᐤ  =>  new byte[24]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0x01,0x83,0xe0,0xc0,0xc1,0xe8,0x06,0x0f,0xb6,0xc0,0x83,0xe0,0x03,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> Modヽᐤuint2ᐤ  =>  new byte[28]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0x01,0x83,0xe0,0x3f,0x0f,0xb6,0xc0,0x0f,0xb6,0xd2,0xc1,0xe2,0x06,0x0f,0xb6,0xd2,0x0b,0xc2,0x88,0x01,0xc3};

        public static ReadOnlySpan<byte> ToBitStringヽᐤᐤ  =>  new byte[212]{0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x48,0x33,0xc0,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x48,0x89,0x44,0x24,0x38,0x48,0x89,0x44,0x24,0x40,0x48,0x8b,0xf1,0x0f,0xb6,0x0e,0x83,0xe1,0xc0,0xc1,0xe9,0x06,0x40,0x0f,0xb6,0xf9,0x83,0xe7,0x03,0x48,0xb9,0x18,0xba,0x31,0x66,0xfb,0x7f,0x00,0x00,0xe8,0x50,0x72,0x8c,0x5c,0x48,0x8b,0xd8,0x40,0x88,0x7b,0x08,0x0f,0xb6,0x0e,0x81,0xe1,0x38,0xff,0xff,0xff,0xc1,0xe9,0x03,0x40,0x0f,0xb6,0xf9,0x83,0xe7,0x07,0x48,0xb9,0x80,0xc6,0x31,0x66,0xfb,0x7f,0x00,0x00,0xe8,0x27,0x72,0x8c,0x5c,0x48,0x8b,0xe8,0x40,0x88,0x7d,0x08,0x40,0x0f,0xb6,0x36,0x81,0xe6,0x07,0xff,0xff,0xff,0x83,0xe6,0x07,0x48,0xb9,0x80,0xc6,0x31,0x66,0xfb,0x7f,0x00,0x00,0xe8,0x04,0x72,0x8c,0x5c,0x40,0x88,0x70,0x08,0x49,0xb8,0x98,0x13,0x28,0x61,0xa1,0x02,0x00,0x00,0x4d,0x8b,0x00,0x48,0xba,0x30,0x58,0x3d,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x8d,0x4c,0x24,0x28,0x48,0x89,0x19,0x48,0x89,0x69,0x08,0x48,0x89,0x41,0x10,0x4c,0x89,0x41,0x18,0x4c,0x8d,0x44,0x24,0x28,0x33,0xc9,0xe8,0x26,0x5c,0x7e,0x58,0x90,0x48,0x83,0xc4,0x48,0x5b,0x5d,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> op_implicit_ModRm_8u  =>  new byte[9]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc1,0xc3};

        public static ReadOnlySpan<byte> op_EqualityヽᐤModRmㆍModRmᐤ  =>  new byte[20]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc1,0x0f,0xb6,0xd2,0x3b,0xc2,0x0f,0x94,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> op_InequalityヽᐤModRmㆍModRmᐤ  =>  new byte[20]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc1,0x0f,0xb6,0xd2,0x3b,0xc2,0x0f,0x95,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> get_Emptyヽᐤᐤ  =>  new byte[8]{0x0f,0x1f,0x44,0x00,0x00,0x33,0xc0,0xc3};

    }
}
