﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2022-01-14 21:56:33 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class lib_apijit
    {
        public static ReadOnlySpan<byte> JitCatalogヽᐤᐤ  =>  new byte[106]{0x57,0x56,0x48,0x83,0xec,0x28,0x48,0x8b,0xf1,0x48,0x8b,0xfa,0x48,0x8b,0x4e,0x18,0x49,0xbb,0x58,0x0f,0x98,0x61,0xfb,0x7f,0x00,0x00,0x48,0xb8,0x58,0x0f,0x98,0x61,0xfb,0x7f,0x00,0x00,0x39,0x09,0xff,0x10,0x48,0x8b,0xc8,0x49,0xbb,0x60,0x0f,0x98,0x61,0xfb,0x7f,0x00,0x00,0x48,0xb8,0x60,0x0f,0x98,0x61,0xfb,0x7f,0x00,0x00,0x39,0x09,0xff,0x10,0x4c,0x8b,0xc0,0x48,0x8b,0xd7,0x48,0x8b,0xce,0x48,0xb8,0xc0,0x1d,0xe2,0x62,0xfb,0x7f,0x00,0x00,0x48,0x83,0xc4,0x28,0x5e,0x5f,0x48,0xff,0xe0,0x00,0x19,0x06,0x03,0x00,0x06,0x42,0x02,0x60,0x01,0x70};

        public static ReadOnlySpan<byte> JitヽᐤApiCompleteTypeㆍHashSetᐸstringᐳᐤ  =>  new byte[166]{0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x28,0x48,0x8b,0xf1,0x48,0x8b,0xfa,0x49,0x8b,0xd8,0x48,0xb9,0xa0,0x31,0xaf,0x63,0xfb,0x7f,0x00,0x00,0xe8,0x20,0xb9,0x68,0x5c,0x48,0x8b,0xe8,0x48,0x8d,0x4d,0x08,0x48,0x8b,0xd7,0xe8,0x51,0xaa,0x68,0x5c,0x48,0xb9,0x58,0x79,0x22,0x65,0xfb,0x7f,0x00,0x00,0xe8,0x02,0xb9,0x68,0x5c,0x48,0x8b,0xf8,0x48,0x8d,0x4d,0x08,0x48,0x8b,0xd3,0xe8,0xa3,0x38,0x96,0xff,0x48,0x8b,0xd8,0x48,0x8d,0x4f,0x08,0x48,0x8b,0xd5,0xe8,0x24,0xaa,0x68,0x5c,0x49,0xb8,0x28,0x6a,0x81,0x63,0xfb,0x7f,0x00,0x00,0x4c,0x89,0x47,0x18,0x4c,0x8b,0xc7,0x48,0x8b,0xd3,0x48,0xb9,0xe0,0x7a,0x22,0x65,0xfb,0x7f,0x00,0x00,0xe8,0x69,0xf5,0xff,0xff,0x48,0x8b,0xd0,0x48,0x8b,0xce,0x48,0xb8,0xf0,0x1d,0xe2,0x62,0xfb,0x7f,0x00,0x00,0x48,0x83,0xc4,0x28,0x5b,0x5d,0x5e,0x5f,0x48,0xff,0xe0,0x00,0x00,0x19,0x08,0x05,0x00,0x08,0x42,0x04,0x30,0x03,0x50};

        public static ReadOnlySpan<byte> Membersヽᐤarray_JittedMethodᐤ  =>  new byte[419]{0x41,0x57,0x41,0x56,0x41,0x55,0x41,0x54,0x57,0x56,0x55,0x53,0x48,0x81,0xec,0x98,0x00,0x00,0x00,0xc5,0xf8,0x77,0x48,0x8b,0xf1,0x48,0x8d,0x7c,0x24,0x30,0xb9,0x1a,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x48,0x8b,0xf2,0x8b,0x7e,0x08,0x48,0x63,0xd7,0x48,0xb9,0xf8,0x7e,0x22,0x65,0xfb,0x7f,0x00,0x00,0xe8,0xce,0x8f,0xba,0xfc,0x48,0x8b,0xd8,0x33,0xed,0x85,0xff,0x0f,0x8e,0x3d,0x01,0x00,0x00,0x48,0x63,0xcd,0x48,0x8d,0x0c,0x89,0x48,0x8d,0x4c,0xce,0x10,0xc5,0xfa,0x6f,0x01,0xc5,0xfa,0x7f,0x44,0x24,0x70,0xc5,0xfa,0x6f,0x41,0x10,0xc5,0xfa,0x7f,0x84,0x24,0x80,0x00,0x00,0x00,0x48,0x8b,0x41,0x20,0x48,0x89,0x84,0x24,0x90,0x00,0x00,0x00,0x4c,0x8b,0x74,0x24,0x70,0xc6,0x44,0x24,0x68,0x00,0x48,0xb9,0x98,0x99,0x00,0x63,0xfb,0x7f,0x00,0x00,0xe8,0xe8,0xb7,0x68,0x5c,0x48,0x0f,0xbe,0x4c,0x24,0x68,0x88,0x48,0x08,0x48,0x8b,0xc8,0x49,0x8b,0xd6,0xe8,0xa4,0x3e,0x96,0xff,0x4c,0x8b,0xf8,0x48,0x8d,0x4c,0x24,0x78,0x48,0x8b,0x01,0x48,0x8b,0x51,0x08,0x0f,0xb6,0x49,0x10,0x48,0x89,0x44,0x24,0x50,0x48,0x89,0x54,0x24,0x58,0x88,0x4c,0x24,0x60,0x49,0x8b,0xce,0x49,0x8b,0x06,0x48,0x8b,0x40,0x40,0xff,0x50,0x30,0x4c,0x8b,0xe0,0x4c,0x89,0x7c,0x24,0x48,0x48,0xb9,0x68,0x9a,0xee,0x62,0xfb,0x7f,0x00,0x00,0xe8,0x8f,0xb7,0x68,0x5c,0x4c,0x8b,0xf8,0x4c,0x8d,0x6c,0x24,0x50,0x48,0x8d,0x44,0x24,0x48,0x48,0x89,0x44,0x24,0x28,0x48,0x8d,0x54,0x24,0x30,0x4c,0x8b,0x4c,0x24,0x50,0x4c,0x89,0x0a,0x4c,0x8b,0x4c,0x24,0x58,0x4c,0x89,0x4a,0x08,0x44,0x0f,0xb6,0x4c,0x24,0x60,0x44,0x88,0x4a,0x10,0x48,0x8d,0x54,0x24,0x30,0x4c,0x8b,0x4c,0x24,0x48,0x4d,0x8b,0xc4,0xb9,0x10,0x00,0x00,0x00,0xe8,0x86,0x3e,0x96,0xff,0x4c,0x8b,0xc8,0x49,0x8b,0xd5,0x4c,0x8b,0x44,0x24,0x28,0x49,0x8b,0xcf,0xe8,0xe3,0x40,0x96,0xff,0x48,0xb9,0x80,0xe6,0xf0,0x62,0xfb,0x7f,0x00,0x00,0xe8,0x24,0xb7,0x68,0x5c,0x4c,0x8b,0xe0,0x4c,0x8b,0x8c,0x24,0x90,0x00,0x00,0x00,0x49,0x8b,0xcc,0x49,0x8b,0xd7,0x4d,0x8b,0xc6,0xe8,0xe3,0x67,0xed,0xfd,0x48,0x8b,0xcb,0x8b,0xd5,0x4d,0x8b,0xc4,0xe8,0x5e,0xa9,0x68,0x5c,0xff,0xc5,0x3b,0xef,0x0f,0x8c,0xc3,0xfe,0xff,0xff,0x48,0x8b,0xc3,0x48,0x81,0xc4,0x98,0x00,0x00,0x00,0x5b,0x5d,0x5e,0x5f,0x41,0x5c,0x41,0x5d,0x41,0x5e,0x41,0x5f,0xc3};

        public static ReadOnlySpan<byte> JitDirectヽᐤIApiHostᐤ  =>  new byte[1091]{0x55,0x41,0x57,0x41,0x56,0x41,0x55,0x41,0x54,0x57,0x56,0x53,0x48,0x81,0xec,0x58,0x01,0x00,0x00,0xc5,0xf8,0x77,0x48,0x8d,0xac,0x24,0x90,0x01,0x00,0x00,0x48,0x8b,0xf1,0x48,0x8d,0xbd,0x48,0xff,0xff,0xff,0xb9,0x20,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x48,0x8b,0xf2,0x48,0x8d,0x8d,0x98,0xfe,0xff,0xff,0x49,0x8b,0xd2,0xe8,0xca,0x04,0x59,0x5c,0x48,0x8b,0xf8,0x48,0x8b,0xcc,0x48,0x89,0x8d,0xb8,0xfe,0xff,0xff,0x48,0x8b,0xcd,0x48,0x89,0x8d,0xc8,0xfe,0xff,0xff,0x48,0xb9,0xf0,0x2f,0xaf,0x63,0xfb,0x7f,0x00,0x00,0xe8,0x44,0xb6,0x68,0x5c,0x48,0x8b,0xd8,0x48,0x8d,0x4b,0x08,0x48,0x8b,0xd6,0xe8,0x75,0xa7,0x68,0x5c,0x48,0xb9,0x58,0x79,0x22,0x65,0xfb,0x7f,0x00,0x00,0xe8,0x26,0xb6,0x68,0x5c,0x48,0x8b,0xf0,0x48,0x8b,0x4b,0x08,0xe8,0xfa,0xa7,0x96,0xff,0x4c,0x8b,0xf0,0x48,0x8d,0x4e,0x08,0x48,0x8b,0xd3,0xe8,0x4b,0xa7,0x68,0x5c,0x49,0xb8,0xf8,0x69,0x81,0x63,0xfb,0x7f,0x00,0x00,0x4c,0x89,0x46,0x18,0x4c,0x8b,0xc6,0x49,0x8b,0xd6,0x48,0xb9,0xe0,0x7a,0x22,0x65,0xfb,0x7f,0x00,0x00,0xe8,0x90,0xf2,0xff,0xff,0x48,0x8b,0xf0,0x44,0x8b,0x76,0x08,0x49,0x63,0xd6,0x48,0xb9,0xf8,0x7e,0x22,0x65,0xfb,0x7f,0x00,0x00,0xe8,0x5f,0x8d,0xba,0xfc,0x4c,0x8b,0xf8,0x45,0x39,0x3f,0x4c,0x89,0xbd,0x20,0xff,0xff,0xff,0x4d,0x8d,0x67,0x10,0x45,0x33,0xed,0x45,0x85,0xf6,0x0f,0x8e,0xd2,0x02,0x00,0x00,0x49,0x63,0xcd,0x48,0x8d,0x0c,0x89,0x48,0x89,0xb5,0x28,0xff,0xff,0xff,0x48,0x8d,0x4c,0xce,0x10,0xc5,0xfa,0x6f,0x09,0xc5,0xfa,0x7f,0x4d,0xa0,0xc5,0xfa,0x6f,0x49,0x10,0xc5,0xfa,0x7f,0x4d,0xb0,0x48,0x8b,0x41,0x20,0x48,0x89,0x45,0xc0,0xc6,0x45,0x80,0x00,0x48,0xb9,0x98,0x99,0x00,0x63,0xfb,0x7f,0x00,0x00,0xe8,0x71,0xb5,0x68,0x5c,0x48,0x8b,0xc8,0x48,0x0f,0xbe,0x55,0x80,0x88,0x51,0x08,0x48,0x8b,0x45,0xa0,0x48,0x89,0x85,0xd8,0xfe,0xff,0xff,0x48,0x8b,0xd0,0xe8,0x23,0x3c,0x96,0xff,0x48,0x89,0x85,0x10,0xff,0xff,0xff,0x48,0x89,0x9d,0x30,0xff,0xff,0xff,0x48,0x8b,0x4b,0x08,0x48,0x8d,0x55,0x88,0x49,0xbb,0x78,0x0f,0x98,0x61,0xfb,0x7f,0x00,0x00,0x49,0xb8,0x78,0x0f,0x98,0x61,0xfb,0x7f,0x00,0x00,0x39,0x09,0x41,0xff,0x10,0x48,0x8b,0x4d,0x88,0x48,0x89,0x8d,0x68,0xff,0xff,0xff,0x48,0x8b,0x4d,0x90,0x48,0x89,0x8d,0x70,0xff,0xff,0xff,0x0f,0xb6,0x4d,0x98,0x88,0x8d,0x78,0xff,0xff,0xff,0x48,0x8b,0x8d,0xd8,0xfe,0xff,0xff,0x48,0x89,0x8d,0xd8,0xfe,0xff,0xff,0x48,0x8b,0x01,0x48,0x8b,0x40,0x40,0xff,0x50,0x30,0x48,0x89,0x85,0xf0,0xfe,0xff,0xff,0x48,0x8b,0x8d,0x10,0xff,0xff,0xff,0x48,0x89,0x8d,0x60,0xff,0xff,0xff,0x48,0xb9,0x68,0x9a,0xee,0x62,0xfb,0x7f,0x00,0x00,0xe8,0xc8,0xb4,0x68,0x5c,0x48,0x89,0x85,0xe8,0xfe,0xff,0xff,0x4c,0x8d,0x95,0x68,0xff,0xff,0xff,0x4c,0x89,0x95,0x40,0xff,0xff,0xff,0x4c,0x8d,0x9d,0x60,0xff,0xff,0xff,0x4c,0x89,0x9d,0x38,0xff,0xff,0xff,0x48,0x8d,0x95,0x48,0xff,0xff,0xff,0x4c,0x8b,0x8d,0x68,0xff,0xff,0xff,0x4c,0x89,0x0a,0x4c,0x8b,0x8d,0x70,0xff,0xff,0xff,0x4c,0x89,0x4a,0x08,0x44,0x0f,0xb6,0x8d,0x78,0xff,0xff,0xff,0x44,0x88,0x4a,0x10,0x48,0x8d,0x95,0x48,0xff,0xff,0xff,0x4c,0x8b,0x8d,0x60,0xff,0xff,0xff,0x4c,0x8b,0x85,0xf0,0xfe,0xff,0xff,0xb9,0x10,0x00,0x00,0x00,0xe8,0x9e,0x3b,0x96,0xff,0x4c,0x8b,0xc8,0x48,0x8b,0x95,0x40,0xff,0xff,0xff,0x4c,0x8b,0x85,0x38,0xff,0xff,0xff,0x48,0x8b,0x8d,0xe8,0xfe,0xff,0xff,0xe8,0xf1,0x3d,0x96,0xff,0x48,0x8b,0x85,0xe8,0xfe,0xff,0xff,0x48,0x89,0x85,0x08,0xff,0xff,0xff,0x49,0x63,0xcd,0x4c,0x89,0xa5,0x18,0xff,0xff,0xff,0x49,0x8d,0x14,0xcc,0x48,0x89,0x95,0x00,0xff,0xff,0xff,0x4c,0x8b,0x85,0xd8,0xfe,0xff,0xff,0x49,0x8b,0xc8,0x4c,0x89,0x85,0xf8,0xfe,0xff,0xff,0x4d,0x8b,0x08,0x4d,0x8b,0x49,0x60,0x41,0xff,0x11,0x48,0x8b,0xc8,0x33,0xd2,0x45,0x33,0xc0,0xe8,0x16,0x74,0x83,0x5c,0x48,0x8b,0x8d,0xf8,0xfe,0xff,0xff,0x48,0x89,0x8d,0xf8,0xfe,0xff,0xff,0x48,0x8b,0x01,0x48,0x8b,0x40,0x60,0xff,0x10,0x48,0x85,0xc0,0x0f,0x84,0x15,0x01,0x00,0x00,0x48,0x89,0x85,0xe0,0xfe,0xff,0xff,0x48,0x8b,0xc8,0x49,0xbb,0x80,0x0f,0x98,0x61,0xfb,0x7f,0x00,0x00,0x48,0xba,0x80,0x0f,0x98,0x61,0xfb,0x7f,0x00,0x00,0x39,0x09,0xff,0x12,0x48,0x8b,0xc8,0x45,0x33,0xdb,0x48,0xb8,0x78,0x8c,0xd9,0x61,0xfb,0x7f,0x00,0x00,0x48,0x89,0x85,0xa8,0xfe,0xff,0xff,0x48,0x8d,0x05,0x22,0x00,0x00,0x00,0x48,0x89,0x85,0xc0,0xfe,0xff,0xff,0x48,0x8d,0x85,0x98,0xfe,0xff,0xff,0x48,0x89,0x47,0x10,0xc6,0x47,0x0c,0x00,0x48,0xb8,0xb0,0x91,0xd9,0x61,0xfb,0x7f,0x00,0x00,0xff,0x10,0xc6,0x47,0x0c,0x01,0x48,0xba,0xa8,0x7b,0x99,0xc1,0xfb,0x7f,0x00,0x00,0x83,0x3a,0x00,0x74,0x0c,0x48,0xb9,0x78,0xb2,0x98,0xc1,0xfb,0x7f,0x00,0x00,0xff,0x11,0x48,0x8b,0x8d,0xa0,0xfe,0xff,0xff,0x48,0x89,0x4f,0x10,0x48,0x8b,0xf0,0x48,0x8b,0x8d,0xe0,0xfe,0xff,0xff,0xe8,0x7b,0x65,0xfc,0x5b,0x48,0xb9,0x80,0xe6,0xf0,0x62,0xfb,0x7f,0x00,0x00,0xe8,0x2c,0xb3,0x68,0x5c,0x48,0x8b,0xd8,0x4c,0x8b,0xce,0x48,0x8b,0xcb,0x48,0x8b,0x95,0x08,0xff,0xff,0xff,0x4c,0x8b,0x85,0xf8,0xfe,0xff,0xff,0xe8,0xe8,0x63,0xed,0xfd,0x48,0x8b,0x8d,0x00,0xff,0xff,0xff,0x48,0x8b,0xd3,0xe8,0x11,0xa4,0x68,0x5c,0x41,0xff,0xc5,0x45,0x3b,0xee,0x48,0x8b,0x9d,0x30,0xff,0xff,0xff,0x48,0x8b,0xb5,0x28,0xff,0xff,0xff,0x4c,0x8b,0xa5,0x18,0xff,0xff,0xff,0x0f,0x8c,0x2e,0xfd,0xff,0xff,0x4c,0x8b,0xbd,0x20,0xff,0xff,0xff,0x49,0x8b,0xc7,0xc6,0x47,0x0c,0x01,0x48,0x8d,0x65,0xc8,0x5b,0x5e,0x5f,0x41,0x5c,0x41,0x5d,0x41,0x5e,0x41,0x5f,0x5d,0xc3,0x48,0xb9,0x70,0x7a,0xb3,0x61,0xfb,0x7f,0x00,0x00,0xe8,0xb2,0xb2,0x68,0x5c,0x48,0x8b,0xf0,0xe8,0xf2,0xbf,0x91,0xfe,0xc7,0x46,0x70,0x52,0x43,0x43,0xe0,0xc7,0x46,0x74,0x00,0x15,0x13,0x80,0x48,0x8d,0x4e,0x10,0x48,0x8b,0xd0,0xe8,0xd0,0xa3,0x68,0x5c,0xc7,0x46,0x74,0x01,0x15,0x13,0x80,0x33,0xc9,0x48,0x89,0x4e,0x78,0xc7,0x46,0x74,0x57,0x00,0x07,0x80,0xc7,0x46,0x74,0x03,0x40,0x00,0x80,0x48,0x8b,0xce,0xe8,0xbd,0xee,0x64,0x5c};

        public static ReadOnlySpan<byte> JitGenericヽᐤIApiHostᐤ  =>  new byte[320]{0x41,0x56,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x50,0xc5,0xf8,0x77,0x48,0x8b,0xf1,0x48,0x8d,0x7c,0x24,0x28,0xb9,0x0a,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x48,0x8b,0xf1,0x48,0x8b,0xfa,0x48,0xb9,0xc8,0x30,0xaf,0x63,0xfb,0x7f,0x00,0x00,0xe8,0x0a,0xb2,0x68,0x5c,0x48,0x8b,0xd8,0x48,0x8d,0x4b,0x08,0x48,0x8b,0xd7,0xe8,0x3b,0xa3,0x68,0x5c,0x48,0xb9,0x58,0x79,0x22,0x65,0xfb,0x7f,0x00,0x00,0xe8,0xec,0xb1,0x68,0x5c,0x48,0x8b,0xf8,0x48,0x8b,0x4b,0x08,0xe8,0xf0,0xb0,0x96,0xff,0x48,0x8b,0xe8,0x48,0x8d,0x4f,0x08,0x48,0x8b,0xd3,0xe8,0x11,0xa3,0x68,0x5c,0x49,0xb8,0x10,0x6a,0x81,0x63,0xfb,0x7f,0x00,0x00,0x4c,0x89,0x47,0x18,0x4c,0x8b,0xc7,0x48,0x8b,0xd5,0x48,0xb9,0xe0,0x7a,0x22,0x65,0xfb,0x7f,0x00,0x00,0xe8,0x56,0xee,0xff,0xff,0x48,0x85,0xc0,0x75,0x06,0x33,0xff,0x33,0xdb,0xeb,0x07,0x48,0x8d,0x78,0x10,0x8b,0x58,0x08,0x48,0xb9,0x20,0x00,0xa7,0x61,0xfb,0x7f,0x00,0x00,0xba,0x89,0x00,0x00,0x00,0xe8,0x18,0x71,0x65,0x5c,0x48,0xba,0xe0,0xfe,0x93,0x70,0xc3,0x01,0x00,0x00,0x48,0x8b,0x12,0x48,0xb9,0x88,0x8a,0x22,0x65,0xfb,0x7f,0x00,0x00,0xe8,0xec,0xde,0xb8,0xfc,0x48,0x8b,0xe8,0x45,0x33,0xf6,0x85,0xdb,0x7e,0x4c,0x48,0x8b,0xce,0x49,0x63,0xd6,0x48,0x8d,0x14,0x92,0x48,0x8d,0x14,0xd7,0xc5,0xfa,0x6f,0x02,0xc5,0xfa,0x7f,0x44,0x24,0x28,0xc5,0xfa,0x6f,0x42,0x10,0xc5,0xfa,0x7f,0x44,0x24,0x38,0x48,0x8b,0x42,0x20,0x48,0x89,0x44,0x24,0x48,0x48,0x8d,0x54,0x24,0x28,0xe8,0xfc,0x56,0xef,0xfd,0x4c,0x8b,0xc0,0x8b,0x55,0x10,0x48,0x8b,0xcd,0xe8,0x1e,0x42,0xb8,0xfc,0x41,0xff,0xc6,0x44,0x3b,0xf3,0x7c,0xb4,0x48,0x8b,0xcd,0x39,0x09,0xe8,0x6c,0xb0,0x22,0x5c,0x90,0x48,0x83,0xc4,0x50,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0xc3};

        public static ReadOnlySpan<byte> JitGenericヽᐤJittedMethodᐤ  =>  new byte[1379]{0x55,0x41,0x57,0x41,0x56,0x41,0x55,0x41,0x54,0x57,0x56,0x53,0x48,0x81,0xec,0x38,0x01,0x00,0x00,0xc5,0xf8,0x77,0x48,0x8d,0xac,0x24,0x70,0x01,0x00,0x00,0x48,0x8b,0xf1,0x48,0x8d,0xbd,0x38,0xff,0xff,0xff,0xb9,0x24,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x48,0x89,0xa5,0xb0,0xfe,0xff,0xff,0x48,0x89,0x4d,0x10,0x48,0x8b,0xf2,0x48,0x8b,0x0e,0x48,0x89,0x8d,0x20,0xff,0xff,0xff,0x48,0x8b,0x8d,0x20,0xff,0xff,0xff,0xe8,0xa8,0xb7,0x96,0xff,0x48,0x85,0xc0,0x75,0x06,0x33,0xff,0x33,0xdb,0xeb,0x07,0x48,0x8d,0x78,0x10,0x8b,0x58,0x08,0x44,0x8b,0xf3,0x49,0x63,0xd6,0x48,0xb9,0xf8,0x7e,0x22,0x65,0xfb,0x7f,0x00,0x00,0xe8,0xf1,0x87,0xba,0xfc,0x48,0x89,0x85,0x18,0xff,0xff,0xff,0x48,0x83,0xbd,0x18,0xff,0xff,0xff,0x00,0x75,0x08,0x45,0x33,0xff,0x45,0x33,0xe4,0xeb,0x3d,0x48,0x8b,0x8d,0x18,0xff,0xff,0xff,0xe8,0x1c,0x58,0x62,0x5c,0x4c,0x8b,0xf8,0x48,0xb9,0x62,0x75,0xf2,0x63,0xfb,0x7f,0x00,0x00,0xe8,0xaa,0xed,0x61,0x5c,0x4c,0x3b,0xf8,0x0f,0x85,0x33,0x03,0x00,0x00,0x4c,0x8b,0xbd,0x18,0xff,0xff,0xff,0x49,0x83,0xc7,0x10,0x48,0x8b,0x8d,0x18,0xff,0xff,0xff,0x44,0x8b,0x61,0x08,0x45,0x33,0xed,0x48,0x63,0xcb,0x48,0x85,0xc9,0x0f,0x8e,0xde,0x02,0x00,0x00,0x48,0x89,0x7d,0xb8,0x44,0x89,0x75,0xc0,0xc5,0xfa,0x6f,0x45,0xb8,0xc5,0xfa,0x7f,0x45,0xa8,0x48,0x8b,0x4d,0xa8,0x49,0x63,0xd5,0x48,0x8d,0x04,0xd1,0x48,0x89,0x85,0x10,0xff,0xff,0xff,0x4c,0x8b,0x06,0x4c,0x89,0x85,0xe8,0xfe,0xff,0xff,0x48,0xb9,0x88,0x77,0xb3,0x61,0xfb,0x7f,0x00,0x00,0xba,0x01,0x00,0x00,0x00,0xe8,0x4a,0xb1,0x68,0x5c,0x4c,0x8b,0x85,0x10,0xff,0xff,0xff,0x4d,0x8b,0x00,0x48,0x89,0x85,0xf0,0xfe,0xff,0xff,0x48,0x8b,0xc8,0x33,0xd2,0xe8,0xff,0xa1,0x68,0x5c,0x48,0x8b,0x8d,0xe8,0xfe,0xff,0xff,0x48,0x8b,0x95,0xf0,0xfe,0xff,0xff,0x48,0x8b,0x01,0x48,0x8b,0x40,0x60,0xff,0x50,0x38,0x48,0x8b,0xc8,0x48,0x89,0x85,0x08,0xff,0xff,0xff,0x48,0x8b,0x10,0x48,0x8b,0x52,0x60,0xff,0x12,0x48,0x8b,0xc8,0x33,0xd2,0x45,0x33,0xc0,0xe8,0x87,0x6f,0x83,0x5c,0x48,0x8b,0x8d,0x08,0xff,0xff,0xff,0x48,0x89,0x8d,0x08,0xff,0xff,0xff,0x48,0x8b,0x01,0x48,0x8b,0x40,0x60,0xff,0x10,0x48,0x85,0xc0,0x0f,0x84,0xd4,0x01,0x00,0x00,0x48,0x89,0x85,0xc0,0xfe,0xff,0xff,0x48,0x8b,0xc8,0x49,0xbb,0x90,0x0f,0x98,0x61,0xfb,0x7f,0x00,0x00,0x48,0xba,0x90,0x0f,0x98,0x61,0xfb,0x7f,0x00,0x00,0x39,0x09,0xff,0x12,0x48,0x8b,0xc8,0xe8,0xf5,0x87,0x96,0xff,0x48,0x89,0x45,0xa0,0x48,0x8b,0x8d,0xc0,0xfe,0xff,0xff,0xe8,0x4d,0x61,0xfc,0x5b,0x48,0x8b,0x45,0xa0,0x48,0x89,0x85,0x50,0xff,0xff,0xff,0xc6,0x45,0x98,0x00,0x48,0xb9,0x98,0x99,0x00,0x63,0xfb,0x7f,0x00,0x00,0xe8,0xef,0xae,0x68,0x5c,0x48,0x0f,0xbe,0x4d,0x98,0x88,0x48,0x08,0x48,0x8b,0xc8,0x48,0x8b,0x95,0x08,0xff,0xff,0xff,0xe8,0xa8,0x35,0x96,0xff,0x48,0x89,0x85,0x00,0xff,0xff,0xff,0x48,0x8d,0x4e,0x08,0x48,0x8b,0x11,0x4c,0x8b,0x41,0x08,0x0f,0xb6,0x49,0x10,0x48,0x89,0x55,0x80,0x4c,0x89,0x45,0x88,0x88,0x4d,0x90,0x48,0x8b,0x8d,0x20,0xff,0xff,0xff,0x48,0x8b,0x95,0x20,0xff,0xff,0xff,0x48,0x8b,0x12,0x48,0x8b,0x52,0x40,0xff,0x52,0x30,0x48,0x89,0x85,0xd0,0xfe,0xff,0xff,0x48,0x8b,0x8d,0x00,0xff,0xff,0xff,0x48,0x89,0x8d,0x78,0xff,0xff,0xff,0x48,0xb9,0x68,0x9a,0xee,0x62,0xfb,0x7f,0x00,0x00,0xe8,0x7b,0xae,0x68,0x5c,0x48,0x89,0x85,0xc8,0xfe,0xff,0xff,0x4c,0x8d,0x55,0x80,0x4c,0x89,0x95,0x30,0xff,0xff,0xff,0x4c,0x8d,0x9d,0x78,0xff,0xff,0xff,0x4c,0x89,0x9d,0x28,0xff,0xff,0xff,0x48,0x8d,0x95,0x38,0xff,0xff,0xff,0x4c,0x8b,0x4d,0x80,0x4c,0x89,0x0a,0x4c,0x8b,0x4d,0x88,0x4c,0x89,0x4a,0x08,0x44,0x0f,0xb6,0x4d,0x90,0x44,0x88,0x4a,0x10,0x48,0x8d,0x95,0x38,0xff,0xff,0xff,0x4c,0x8b,0x8d,0x78,0xff,0xff,0xff,0x4c,0x8b,0x85,0xd0,0xfe,0xff,0xff,0xb9,0x10,0x00,0x00,0x00,0xe8,0x5d,0x35,0x96,0xff,0x4c,0x8b,0xc8,0x48,0x8b,0x95,0x30,0xff,0xff,0xff,0x4c,0x8b,0x85,0x28,0xff,0xff,0xff,0x48,0x8b,0x8d,0xc8,0xfe,0xff,0xff,0xe8,0xb0,0x37,0x96,0xff,0x4c,0x89,0xbd,0x68,0xff,0xff,0xff,0x44,0x89,0xa5,0x70,0xff,0xff,0xff,0xc5,0xfa,0x6f,0x85,0x68,0xff,0xff,0xff,0xc5,0xfa,0x7f,0x85,0x58,0xff,0xff,0xff,0x48,0xb9,0x80,0xe6,0xf0,0x62,0xfb,0x7f,0x00,0x00,0xe8,0xd3,0xad,0x68,0x5c,0x48,0x8b,0x8d,0x58,0xff,0xff,0xff,0x49,0x63,0xd5,0x4c,0x8d,0x14,0xd1,0x4c,0x89,0x95,0xd8,0xfe,0xff,0xff,0x48,0x89,0x85,0xe0,0xfe,0xff,0xff,0x48,0x8b,0xc8,0x48,0x8b,0x95,0xc8,0xfe,0xff,0xff,0x4c,0x8b,0x85,0x08,0xff,0xff,0xff,0x4c,0x8b,0x8d,0x50,0xff,0xff,0xff,0xe8,0x72,0x5e,0xed,0xfd,0x48,0x8b,0x8d,0xd8,0xfe,0xff,0xff,0x48,0x8b,0x95,0xe0,0xfe,0xff,0xff,0xe8,0x97,0x9e,0x68,0x5c,0x41,0xff,0xc5,0x41,0x8b,0xc5,0x48,0x63,0xcb,0x48,0x3b,0xc1,0x0f,0x8c,0x79,0xfd,0xff,0xff,0xeb,0x55,0x48,0xb9,0x70,0x7a,0xb3,0x61,0xfb,0x7f,0x00,0x00,0xe8,0x64,0xad,0x68,0x5c,0x48,0x8b,0xf0,0xe8,0xa4,0xba,0x91,0xfe,0xc7,0x46,0x70,0x52,0x43,0x43,0xe0,0xc7,0x46,0x74,0x00,0x15,0x13,0x80,0x48,0x8d,0x4e,0x10,0x48,0x8b,0xd0,0xe8,0x82,0x9e,0x68,0x5c,0xc7,0x46,0x74,0x01,0x15,0x13,0x80,0x33,0xc9,0x48,0x89,0x4e,0x78,0xc7,0x46,0x74,0x57,0x00,0x07,0x80,0xc7,0x46,0x74,0x03,0x40,0x00,0x80,0x48,0x8b,0xce,0xe8,0x6f,0xe9,0x64,0x5c,0xcc,0x48,0x8b,0x85,0x18,0xff,0xff,0xff,0x48,0x8d,0x65,0xc8,0x5b,0x5e,0x5f,0x41,0x5c,0x41,0x5d,0x41,0x5e,0x41,0x5f,0x5d,0xc3,0x48,0x8b,0x85,0xf8,0xfe,0xff,0xff,0x48,0x8d,0x65,0xc8,0x5b,0x5e,0x5f,0x41,0x5c,0x41,0x5d,0x41,0x5e,0x41,0x5f,0x5d,0xc3,0xe8,0x49,0x7a,0xb8,0xfc,0xcc,0x55,0x41,0x57,0x41,0x56,0x41,0x55,0x41,0x54,0x57,0x56,0x53,0x48,0x83,0xec,0x28,0xc5,0xf8,0x77,0x48,0x8b,0x69,0x20,0x48,0x89,0x6c,0x24,0x20,0x48,0x8d,0xad,0x70,0x01,0x00,0x00,0x48,0x8b,0xca,0x39,0x09,0xe8,0x9b,0x81,0xb7,0xfc,0x48,0x8b,0xc8,0x48,0x8b,0x00,0x48,0x8b,0x40,0x40,0xff,0x50,0x30,0x48,0x8b,0xf0,0x48,0x8b,0x8d,0x20,0xff,0xff,0xff,0x48,0x8b,0x85,0x20,0xff,0xff,0xff,0x48,0x8b,0x00,0x48,0x8b,0x40,0x40,0xff,0x50,0x38,0x48,0x8b,0xc8,0x33,0xd2,0xe8,0xb9,0xba,0x91,0xfe,0x48,0x8b,0xf8,0x48,0xb9,0x50,0x70,0xa8,0x70,0xc3,0x01,0x00,0x00,0x48,0x8b,0x19,0x48,0x8b,0x8d,0x20,0xff,0xff,0xff,0xe8,0x3d,0x31,0xba,0xfc,0x4c,0x8b,0xc8,0x48,0x8b,0xcb,0x4c,0x8b,0xc7,0x48,0x8b,0xd6,0xe8,0x5c,0x75,0xb7,0xfc,0x48,0x8b,0xf0,0x48,0x8b,0x4d,0x10,0xe8,0x00,0xfe,0xb7,0xfc,0x48,0x8b,0xf8,0x48,0x8b,0xcf,0x48,0xba,0xf0,0x52,0xcd,0x61,0xfb,0x7f,0x00,0x00,0x49,0xb8,0xe0,0x67,0xe2,0x64,0xfb,0x7f,0x00,0x00,0xe8,0x51,0x94,0x56,0x5c,0x48,0x8b,0xcf,0x48,0x8b,0xd6,0xff,0xd0,0x48,0xb9,0x68,0x94,0x22,0x65,0xfb,0x7f,0x00,0x00,0xe8,0xea,0xb4,0x93,0xff,0x48,0x89,0x85,0xf8,0xfe,0xff,0xff,0x48,0x8d,0x05,0x06,0xff,0xff,0xff,0x48,0x83,0xc4,0x28,0x5b,0x5e,0x5f,0x41,0x5c,0x41,0x5d,0x41,0x5e,0x41,0x5f,0x5d,0xc3,0x55,0x41,0x57,0x41,0x56,0x41,0x55,0x41,0x54,0x57,0x56,0x53,0x48,0x83,0xec,0x28,0xc5,0xf8,0x77,0x48,0x8b,0x69,0x20,0x48,0x89,0x6c,0x24,0x20,0x48,0x8d,0xad,0x70,0x01,0x00,0x00,0x48,0x8b,0xf2,0x48,0x8b,0x4d,0x10,0xe8,0x7c,0xfd,0xb7,0xfc,0x48,0x8b,0xf8,0x48,0x8b,0xcf,0x48,0xba,0xf0,0x52,0xcd,0x61,0xfb,0x7f,0x00,0x00,0x49,0xb8,0xe0,0x67,0xe2,0x64,0xfb,0x7f,0x00,0x00,0xe8,0xcd,0x93,0x56,0x5c,0x48,0x8b,0xd8,0x48,0x8b,0xce,0x48,0x8b,0x06,0x48,0x8b,0x40,0x40,0xff,0x50,0x08,0x48,0x8b,0xd0,0x48,0x8b,0xcf,0xff,0xd3,0x48,0x8d,0x05,0x70,0xfe,0xff,0xff,0x48,0x83,0xc4,0x28,0x5b,0x5e,0x5f,0x41,0x5c,0x41,0x5d,0x41,0x5e,0x41,0x5f,0x5d,0xc3};

    }
}
