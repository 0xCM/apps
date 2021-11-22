﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2021-11-14 3:49:56 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class glue_nasm
    {
        public static ReadOnlySpan<byte> ReadListingヽᐤFilePathᐤ  =>  new byte[906]{0x55,0x41,0x57,0x41,0x56,0x41,0x55,0x41,0x54,0x57,0x56,0x53,0x48,0x81,0xec,0x68,0x01,0x00,0x00,0xc5,0xf8,0x77,0x48,0x8d,0xac,0x24,0xa0,0x01,0x00,0x00,0x48,0x8b,0xf1,0x48,0x8d,0xbd,0x98,0xfe,0xff,0xff,0xb9,0x4c,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x48,0x89,0xa5,0x80,0xfe,0xff,0xff,0x4c,0x8b,0xf1,0x4c,0x8b,0xfa,0x49,0x8b,0xd8,0x49,0x8b,0x76,0x08,0x48,0xb9,0x28,0x0d,0xcb,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x09,0x48,0x89,0x4d,0x80,0x33,0xc9,0x48,0x89,0x8d,0xf8,0xfe,0xff,0xff,0x48,0x8d,0x8d,0xf8,0xfe,0xff,0xff,0x48,0x8b,0xd3,0xe8,0x9f,0x9b,0xa4,0xff,0x48,0x8b,0x8d,0xf8,0xfe,0xff,0xff,0x48,0x89,0x8d,0x78,0xff,0xff,0xff,0x48,0x8d,0x4d,0x80,0x48,0x8d,0x95,0x78,0xff,0xff,0xff,0xe8,0x51,0x25,0xa9,0xfe,0x4c,0x8b,0xc0,0x48,0x8d,0x55,0x90,0x48,0x8b,0xce,0x49,0xbb,0x28,0x11,0x9d,0x7f,0xfe,0x7f,0x00,0x00,0x39,0x09,0xff,0x15,0x5d,0x74,0xb4,0xfc,0x48,0xb9,0x20,0x00,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xba,0x6f,0x00,0x00,0x00,0xe8,0xf1,0x9a,0x75,0x5c,0x48,0xb9,0x80,0x2f,0xb6,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x09,0xe8,0xaf,0xd8,0xff,0xff,0x4c,0x8b,0xe0,0x48,0xba,0x20,0x18,0xb6,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x8b,0xcb,0xe8,0x4f,0x9a,0xc7,0xfc,0x48,0x89,0x85,0x90,0xfe,0xff,0xff,0x41,0xbd,0x01,0x00,0x00,0x00,0x48,0x8b,0x8d,0x90,0xfe,0xff,0xff,0x39,0x09,0xe8,0xac,0x07,0x4a,0xfe,0x85,0xc0,0x0f,0x85,0xe8,0x00,0x00,0x00,0x41,0x8d,0x4d,0x01,0x89,0x4d,0x8c,0x48,0x8d,0x8d,0x48,0xff,0xff,0xff,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x01,0x48,0x8b,0x8d,0x90,0xfe,0xff,0xff,0x48,0x8b,0x85,0x90,0xfe,0xff,0xff,0x48,0x8b,0x00,0x48,0x8b,0x40,0x48,0xff,0x50,0x38,0x4c,0x8b,0xc0,0x48,0x8d,0x8d,0x48,0xff,0xff,0xff,0x41,0x8b,0xd5,0xe8,0x2c,0x1a,0xd7,0xfd,0x48,0x8d,0x85,0x38,0xff,0xff,0xff,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x00,0x48,0x8b,0x85,0x48,0xff,0xff,0xff,0x8b,0x95,0x50,0xff,0xff,0xff,0x48,0x8d,0x8d,0x38,0xff,0xff,0xff,0x48,0x89,0x01,0x89,0x51,0x08,0xc5,0xfa,0x6f,0x85,0x38,0xff,0xff,0xff,0xc5,0xfa,0x7f,0x85,0xe8,0xfe,0xff,0xff,0x41,0xff,0x44,0x24,0x14,0x49,0x8b,0x44,0x24,0x08,0x41,0x8b,0x54,0x24,0x10,0x39,0x50,0x08,0x76,0x24,0x8d,0x4a,0x01,0x41,0x89,0x4c,0x24,0x10,0x48,0x63,0xd2,0x48,0xc1,0xe2,0x04,0x48,0x8d,0x7c,0x10,0x10,0x48,0x8d,0xb5,0xe8,0xfe,0xff,0xff,0xe8,0x47,0xcc,0x78,0x5c,0x48,0xa5,0xeb,0x1f,0xc5,0xfa,0x6f,0x85,0xe8,0xfe,0xff,0xff,0xc5,0xfa,0x7f,0x85,0xd0,0xfe,0xff,0xff,0x49,0x8b,0xcc,0x48,0x8d,0x95,0xd0,0xfe,0xff,0xff,0xe8,0x4c,0xfc,0xff,0xff,0x48,0x8b,0x8d,0x90,0xfe,0xff,0xff,0xe8,0xc8,0x06,0x4a,0xfe,0x85,0xc0,0x44,0x8b,0x6d,0x8c,0x0f,0x84,0x18,0xff,0xff,0xff,0x49,0x8b,0xcc,0x39,0x09,0xe8,0xca,0xfd,0xff,0xff,0x48,0x8b,0xf0,0x49,0x8b,0x7e,0x08,0x48,0xb9,0x30,0x0d,0xcb,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x09,0x48,0x89,0x8d,0x70,0xff,0xff,0xff,0x8b,0x4e,0x08,0x89,0x8d,0x68,0xff,0xff,0xff,0x33,0xc9,0x48,0x89,0x8d,0xe0,0xfe,0xff,0xff,0x48,0x8d,0x8d,0xe0,0xfe,0xff,0xff,0x48,0x8b,0xd3,0xe8,0xd6,0x99,0xa4,0xff,0x48,0x8b,0x8d,0xe0,0xfe,0xff,0xff,0x48,0x89,0x8d,0x78,0xff,0xff,0xff,0x48,0x8b,0xcf,0x48,0xba,0x38,0xe3,0xcf,0x7f,0xfe,0x7f,0x00,0x00,0x49,0xb8,0x88,0xdc,0xd2,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0xdc,0xc1,0x66,0x5c,0x4c,0x8b,0xf0,0x4c,0x8d,0xa5,0x10,0xff,0xff,0xff,0xc5,0xfa,0x6f,0x45,0x90,0xc5,0xfa,0x7f,0x85,0x98,0xfe,0xff,0xff,0xc5,0xfa,0x6f,0x45,0xa0,0xc5,0xfa,0x7f,0x85,0xa8,0xfe,0xff,0xff,0xc5,0xfa,0x6f,0x45,0xb0,0xc5,0xfa,0x7f,0x85,0xb8,0xfe,0xff,0xff,0x48,0x8b,0x4d,0xc0,0x48,0x89,0x8d,0xc8,0xfe,0xff,0xff,0x48,0x8d,0x8d,0x70,0xff,0xff,0xff,0x48,0x8d,0x95,0x68,0xff,0xff,0xff,0x4c,0x8d,0x85,0x78,0xff,0xff,0xff,0xe8,0xa6,0x23,0xa9,0xfe,0x4c,0x8b,0xc8,0x49,0x8b,0xd4,0x4c,0x8d,0x85,0x98,0xfe,0xff,0xff,0x48,0x8b,0xcf,0x41,0xff,0xd6,0x48,0x8d,0x8d,0x00,0xff,0xff,0xff,0x48,0x89,0x19,0x48,0x8d,0x8d,0x08,0xff,0xff,0xff,0x48,0x89,0x31,0xc5,0xfa,0x6f,0x85,0x00,0xff,0xff,0xff,0xc5,0xfa,0x7f,0x85,0x58,0xff,0xff,0xff,0x48,0x8b,0x8d,0x90,0xfe,0xff,0xff,0x49,0xbb,0x30,0x11,0x9d,0x7f,0xfe,0x7f,0x00,0x00,0x39,0x09,0xff,0x15,0x06,0x72,0xb4,0xfc,0x49,0x8b,0xff,0x48,0x8d,0xb5,0x58,0xff,0xff,0xff,0xe8,0xe7,0xca,0x78,0x5c,0xe8,0xe2,0xca,0x78,0x5c,0x49,0x8b,0xc7,0x48,0x8d,0x65,0xc8,0x5b,0x5e,0x5f,0x41,0x5c,0x41,0x5d,0x41,0x5e,0x41,0x5f,0x5d,0xc3,0x55,0x41,0x57,0x41,0x56,0x41,0x55,0x41,0x54,0x57,0x56,0x53,0x48,0x83,0xec,0x28,0xc5,0xf8,0x77,0x48,0x8b,0x69,0x20,0x48,0x89,0x6c,0x24,0x20,0x48,0x8d,0xad,0xa0,0x01,0x00,0x00,0x48,0x83,0xbd,0x90,0xfe,0xff,0xff,0x00,0x74,0x19,0x48,0x8b,0x8d,0x90,0xfe,0xff,0xff,0x49,0xbb,0x30,0x11,0x9d,0x7f,0xfe,0x7f,0x00,0x00,0x39,0x09,0xff,0x15,0x98,0x71,0xb4,0xfc,0x90,0x48,0x83,0xc4,0x28,0x5b,0x5e,0x5f,0x41,0x5c,0x41,0x5d,0x41,0x5e,0x41,0x5f,0x5d,0xc3};

        public static ReadOnlySpan<byte> RenderCodeBlockヽᐤNasmCodeBlockᕀinㆍITextBufferᐤ  =>  new byte[1190]{0x41,0x57,0x41,0x56,0x41,0x55,0x41,0x54,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x48,0x48,0x8b,0xf1,0x48,0x8d,0x7c,0x24,0x20,0xb9,0x0a,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x48,0x8b,0xf9,0x48,0x8b,0xda,0x49,0x8b,0xf0,0x8b,0x0b,0x89,0x4c,0x24,0x38,0x48,0x8b,0x4b,0x08,0x48,0x89,0x4c,0x24,0x40,0x48,0x8b,0x4c,0x24,0x40,0x48,0x89,0x4c,0x24,0x30,0x48,0x8d,0x4c,0x24,0x30,0xe8,0xb0,0xa1,0xc7,0xfc,0x48,0x85,0xc0,0x74,0x3a,0x83,0x78,0x08,0x00,0x76,0x34,0x8b,0x13,0x89,0x54,0x24,0x38,0x48,0x8b,0x53,0x08,0x48,0x89,0x54,0x24,0x40,0x48,0x8d,0x54,0x24,0x38,0x48,0x8b,0xcf,0x4c,0x8b,0xc6,0xe8,0x26,0x57,0xd9,0xfd,0x48,0x8b,0xce,0x49,0xbb,0x68,0x11,0x9d,0x7f,0xfe,0x7f,0x00,0x00,0x39,0x09,0xff,0x15,0xc9,0x6c,0xb4,0xfc,0x48,0x8b,0x4b,0x10,0x48,0x85,0xc9,0x75,0x06,0x33,0xdb,0x33,0xed,0xeb,0x07,0x48,0x8d,0x59,0x10,0x8b,0x69,0x08,0x45,0x33,0xf6,0x85,0xed,0x0f,0x8e,0xaf,0x02,0x00,0x00,0x4d,0x63,0xfe,0x49,0xc1,0xe7,0x05,0x4c,0x03,0xfb,0x48,0xb9,0xc8,0x52,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xba,0x01,0x00,0x00,0x00,0xe8,0xf2,0xd4,0x78,0x5c,0x4c,0x8b,0xe0,0x48,0xb9,0xe0,0x96,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0x50,0xd3,0x78,0x5c,0x45,0x8b,0x07,0x44,0x89,0x40,0x08,0x4c,0x8b,0xc0,0x49,0x8b,0xcc,0x33,0xd2,0xe8,0x9c,0xc5,0x78,0x5c,0x48,0xba,0x38,0x0d,0xcb,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x8b,0xce,0x4d,0x8b,0xc4,0x49,0xbb,0x38,0x11,0x9d,0x7f,0xfe,0x7f,0x00,0x00,0x39,0x09,0xff,0x15,0x0f,0x6c,0xb4,0xfc,0x48,0xb9,0xc8,0x52,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xba,0x02,0x00,0x00,0x00,0xe8,0x93,0xd4,0x78,0x5c,0x4c,0x8b,0xe0,0x49,0xb8,0x60,0xfd,0xca,0x45,0x59,0x02,0x00,0x00,0x4d,0x8b,0x00,0x49,0x8b,0xcc,0x33,0xd2,0xe8,0x49,0xc5,0x78,0x5c,0x48,0xb9,0xc0,0x33,0xcf,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0xda,0xd2,0x78,0x5c,0x4d,0x8b,0x47,0x08,0x4c,0x89,0x40,0x08,0x4c,0x8b,0xc0,0x49,0x8b,0xcc,0xba,0x01,0x00,0x00,0x00,0xe8,0x22,0xc5,0x78,0x5c,0x48,0xba,0x40,0x0d,0xcb,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x8b,0xce,0x4d,0x8b,0xc4,0x49,0xbb,0x40,0x11,0x9d,0x7f,0xfe,0x7f,0x00,0x00,0x39,0x09,0xff,0x15,0x9d,0x6b,0xb4,0xfc,0x48,0xb9,0xc8,0x52,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xba,0x02,0x00,0x00,0x00,0xe8,0x19,0xd4,0x78,0x5c,0x4c,0x8b,0xe0,0x49,0xb8,0x60,0xfd,0xca,0x45,0x59,0x02,0x00,0x00,0x4d,0x8b,0x00,0x49,0x8b,0xcc,0x33,0xd2,0xe8,0xcf,0xc4,0x78,0x5c,0x48,0xb9,0x70,0x1b,0xcf,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0x60,0xd2,0x78,0x5c,0x4c,0x8b,0xe8,0x49,0x8b,0x57,0x10,0x49,0x8d,0x4d,0x08,0xe8,0x90,0xc3,0x78,0x5c,0x4d,0x8b,0xc5,0x49,0x8b,0xcc,0xba,0x01,0x00,0x00,0x00,0xe8,0xa0,0xc4,0x78,0x5c,0x48,0xba,0x48,0x0d,0xcb,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x8b,0xce,0x4d,0x8b,0xc4,0x49,0xbb,0x48,0x11,0x9d,0x7f,0xfe,0x7f,0x00,0x00,0x39,0x09,0xff,0x15,0x23,0x6b,0xb4,0xfc,0x48,0xb9,0xc8,0x52,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xba,0x02,0x00,0x00,0x00,0xe8,0x97,0xd3,0x78,0x5c,0x4c,0x8b,0xe0,0x49,0xb8,0x60,0xfd,0xca,0x45,0x59,0x02,0x00,0x00,0x4d,0x8b,0x00,0x49,0x8b,0xcc,0x33,0xd2,0xe8,0x4d,0xc4,0x78,0x5c,0x48,0xb9,0x28,0x37,0xcf,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0xde,0xd1,0x78,0x5c,0x4c,0x8b,0xe8,0x49,0x8b,0x57,0x18,0x49,0x8d,0x4d,0x08,0xe8,0x0e,0xc3,0x78,0x5c,0x4d,0x8b,0xc5,0x49,0x8b,0xcc,0xba,0x01,0x00,0x00,0x00,0xe8,0x1e,0xc4,0x78,0x5c,0x48,0xba,0x50,0x0d,0xcb,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x8b,0xce,0x4d,0x8b,0xc4,0x49,0xbb,0x50,0x11,0x9d,0x7f,0xfe,0x7f,0x00,0x00,0x39,0x09,0xff,0x15,0xa9,0x6a,0xb4,0xfc,0x48,0xb9,0xc8,0x52,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xba,0x02,0x00,0x00,0x00,0xe8,0x15,0xd3,0x78,0x5c,0x4c,0x8b,0xe0,0x49,0xb8,0x60,0xfd,0xca,0x45,0x59,0x02,0x00,0x00,0x4d,0x8b,0x00,0x49,0x8b,0xcc,0x33,0xd2,0xe8,0xcb,0xc3,0x78,0x5c,0x49,0x83,0xc7,0x18,0x39,0x3f,0x4c,0x8d,0x6f,0x68,0x4d,0x8b,0x3f,0x4d,0x85,0xff,0x0f,0x84,0x95,0x00,0x00,0x00,0x45,0x8b,0x47,0x08,0x49,0x8b,0xcf,0x33,0xd2,0xe8,0xb7,0xf9,0xff,0xff,0x49,0x8d,0x4f,0x10,0x41,0x8b,0x57,0x08,0x48,0x8d,0x44,0x24,0x20,0x48,0x89,0x08,0x89,0x50,0x08,0x48,0x8d,0x4c,0x24,0x20,0x49,0x8b,0xd5,0xe8,0x87,0xb0,0x26,0xfe,0x4c,0x8b,0xc0,0x49,0x8b,0xcc,0xba,0x01,0x00,0x00,0x00,0xe8,0x77,0xc3,0x78,0x5c,0x48,0xba,0x58,0x0d,0xcb,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x8b,0xce,0x4d,0x8b,0xc4,0x49,0xbb,0x58,0x11,0x9d,0x7f,0xfe,0x7f,0x00,0x00,0x39,0x09,0xff,0x15,0x0a,0x6a,0xb4,0xfc,0x48,0x8b,0xce,0x49,0xbb,0x60,0x11,0x9d,0x7f,0xfe,0x7f,0x00,0x00,0x39,0x09,0xff,0x15,0xfd,0x69,0xb4,0xfc,0x41,0xff,0xc6,0x44,0x3b,0xf5,0x0f,0x8c,0x51,0xfd,0xff,0xff,0x48,0x83,0xc4,0x48,0x5b,0x5d,0x5e,0x5f,0x41,0x5c,0x41,0x5d,0x41,0x5e,0x41,0x5f,0xc3,0xb9,0x02,0x00,0x00,0x00,0xe8,0x0e,0xa0,0xc8,0xfc,0xcc,0x00,0x19,0x10,0x09,0x00,0x10,0x82,0x0c,0x30,0x0b,0x50,0x0a,0x60,0x09,0x70,0x08,0xc0,0x06,0xd0,0x04,0xe0,0x02,0xf0,0x00,0x00,0x40,0x00,0x00,0x00,0xa0,0x3c,0x0a,0x83,0xfe,0x7f,0x00,0x00,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x28,0x48,0x8b,0xf2,0x49,0x8b,0xf8,0x48,0xb9,0xc8,0x52,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xba,0x01,0x00,0x00,0x00,0xe8,0xfe,0xd1,0x78,0x5c,0x48,0x8b,0xd8,0x48,0xb9,0xe0,0x96,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0x5c,0xd0,0x78,0x5c,0x44,0x8b,0x06,0x44,0x89,0x40,0x08,0x4c,0x8b,0xc0,0x48,0x8b,0xcb,0x33,0xd2,0xe8,0xa8,0xc2,0x78,0x5c,0x48,0xba,0x38,0x0d,0xcb,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x8b,0xcf,0x4c,0x8b,0xc3,0x49,0xbb,0x70,0x11,0x9d,0x7f,0xfe,0x7f,0x00,0x00,0x39,0x09,0xff,0x15,0x53,0x69,0xb4,0xfc,0x48,0xb9,0xc8,0x52,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xba,0x02,0x00,0x00,0x00,0xe8,0x9f,0xd1,0x78,0x5c,0x48,0x8b,0xd8,0x49,0xb8,0x60,0xfd,0xca,0x45,0x59,0x02,0x00,0x00,0x4d,0x8b,0x00,0x48,0x8b,0xcb,0x33,0xd2,0xe8,0x55,0xc2,0x78,0x5c,0x48,0xb9,0xe8,0xfe,0xcf,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0xe6,0xcf,0x78,0x5c,0x48,0x8b,0xe8,0x48,0x8b,0x56,0x08,0x48,0x8d,0x4d,0x08,0xe8,0x16,0xc1,0x78,0x5c,0x4c,0x8b,0xc5,0x48,0x8b,0xcb,0xba,0x01,0x00,0x00,0x00,0xe8,0x26,0xc2,0x78,0x5c,0x48,0xba,0x80,0x95,0xb6,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x8b,0xcf,0x4c,0x8b,0xc3,0x49,0xbb,0x78,0x11,0x9d,0x7f,0xfe,0x7f,0x00,0x00,0x48,0x8b,0x05,0xda,0x68,0xb4,0xfc,0x39,0x09,0x48,0x83,0xc4,0x28,0x5b,0x5d,0x5e,0x5f,0x48,0xff,0xe0,0x00,0x19,0x08,0x05,0x00,0x08,0x42,0x04,0x30,0x03,0x50};

        public static ReadOnlySpan<byte> RenderLabelヽᐤNasmLabelᕀinㆍITextBufferᐤ  =>  new byte[262]{0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x28,0x48,0x8b,0xf2,0x49,0x8b,0xf8,0x48,0xb9,0xc8,0x52,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xba,0x01,0x00,0x00,0x00,0xe8,0xfe,0xd1,0x78,0x5c,0x48,0x8b,0xd8,0x48,0xb9,0xe0,0x96,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0x5c,0xd0,0x78,0x5c,0x44,0x8b,0x06,0x44,0x89,0x40,0x08,0x4c,0x8b,0xc0,0x48,0x8b,0xcb,0x33,0xd2,0xe8,0xa8,0xc2,0x78,0x5c,0x48,0xba,0x38,0x0d,0xcb,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x8b,0xcf,0x4c,0x8b,0xc3,0x49,0xbb,0x70,0x11,0x9d,0x7f,0xfe,0x7f,0x00,0x00,0x39,0x09,0xff,0x15,0x53,0x69,0xb4,0xfc,0x48,0xb9,0xc8,0x52,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xba,0x02,0x00,0x00,0x00,0xe8,0x9f,0xd1,0x78,0x5c,0x48,0x8b,0xd8,0x49,0xb8,0x60,0xfd,0xca,0x45,0x59,0x02,0x00,0x00,0x4d,0x8b,0x00,0x48,0x8b,0xcb,0x33,0xd2,0xe8,0x55,0xc2,0x78,0x5c,0x48,0xb9,0xe8,0xfe,0xcf,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0xe6,0xcf,0x78,0x5c,0x48,0x8b,0xe8,0x48,0x8b,0x56,0x08,0x48,0x8d,0x4d,0x08,0xe8,0x16,0xc1,0x78,0x5c,0x4c,0x8b,0xc5,0x48,0x8b,0xcb,0xba,0x01,0x00,0x00,0x00,0xe8,0x26,0xc2,0x78,0x5c,0x48,0xba,0x80,0x95,0xb6,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x8b,0xcf,0x4c,0x8b,0xc3,0x49,0xbb,0x78,0x11,0x9d,0x7f,0xfe,0x7f,0x00,0x00,0x48,0x8b,0x05,0xda,0x68,0xb4,0xfc,0x39,0x09,0x48,0x83,0xc4,0x28,0x5b,0x5d,0x5e,0x5f,0x48,0xff,0xe0,0x00,0x19,0x08,0x05,0x00,0x08,0x42,0x04,0x30,0x03,0x50};

        public static ReadOnlySpan<byte> RenderLabelヽᐤIdentifierᕀinㆍITextBufferᐤ  =>  new byte[1410]{0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x28,0x48,0x8b,0xfa,0x49,0x8b,0xf0,0x48,0xb9,0xc8,0x52,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xba,0x02,0x00,0x00,0x00,0xe8,0xde,0xd0,0x78,0x5c,0x48,0x8b,0xd8,0x49,0xb8,0x60,0xfd,0xca,0x45,0x59,0x02,0x00,0x00,0x4d,0x8b,0x00,0x48,0x8b,0xcb,0x33,0xd2,0xe8,0x94,0xc1,0x78,0x5c,0x49,0xb8,0x60,0x30,0xb6,0x45,0x59,0x02,0x00,0x00,0x4d,0x8b,0x00,0x48,0x8b,0xcb,0xba,0x01,0x00,0x00,0x00,0xe8,0x7a,0xc1,0x78,0x5c,0x48,0xba,0x40,0x0d,0xcb,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x8b,0xce,0x4c,0x8b,0xc3,0x49,0xbb,0x80,0x11,0x9d,0x7f,0xfe,0x7f,0x00,0x00,0x39,0x09,0xff,0x15,0x35,0x68,0xb4,0xfc,0x48,0xb9,0xc8,0x52,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xba,0x02,0x00,0x00,0x00,0xe8,0x71,0xd0,0x78,0x5c,0x48,0x8b,0xd8,0x49,0xb8,0x60,0xfd,0xca,0x45,0x59,0x02,0x00,0x00,0x4d,0x8b,0x00,0x48,0x8b,0xcb,0x33,0xd2,0xe8,0x27,0xc1,0x78,0x5c,0x49,0xb8,0x60,0x30,0xb6,0x45,0x59,0x02,0x00,0x00,0x4d,0x8b,0x00,0x48,0x8b,0xcb,0xba,0x01,0x00,0x00,0x00,0xe8,0x0d,0xc1,0x78,0x5c,0x48,0xba,0x50,0x0d,0xcb,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x8b,0xce,0x4c,0x8b,0xc3,0x49,0xbb,0x88,0x11,0x9d,0x7f,0xfe,0x7f,0x00,0x00,0x39,0x09,0xff,0x15,0xd0,0x67,0xb4,0xfc,0x48,0xb9,0xc8,0x52,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xba,0x02,0x00,0x00,0x00,0xe8,0x04,0xd0,0x78,0x5c,0x48,0x8b,0xd8,0x49,0xb8,0x60,0xfd,0xca,0x45,0x59,0x02,0x00,0x00,0x4d,0x8b,0x00,0x48,0x8b,0xcb,0x33,0xd2,0xe8,0xba,0xc0,0x78,0x5c,0x49,0xb8,0x60,0x30,0xb6,0x45,0x59,0x02,0x00,0x00,0x4d,0x8b,0x00,0x48,0x8b,0xcb,0xba,0x01,0x00,0x00,0x00,0xe8,0xa0,0xc0,0x78,0x5c,0x48,0xba,0x58,0x0d,0xcb,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x8b,0xce,0x4c,0x8b,0xc3,0x49,0xbb,0x90,0x11,0x9d,0x7f,0xfe,0x7f,0x00,0x00,0x39,0x09,0xff,0x15,0x6b,0x67,0xb4,0xfc,0x48,0xb9,0xc8,0x52,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xba,0x02,0x00,0x00,0x00,0xe8,0x97,0xcf,0x78,0x5c,0x48,0x8b,0xd8,0x49,0xb8,0x60,0xfd,0xca,0x45,0x59,0x02,0x00,0x00,0x4d,0x8b,0x00,0x48,0x8b,0xcb,0x33,0xd2,0xe8,0x4d,0xc0,0x78,0x5c,0x48,0xb9,0xe8,0xfe,0xcf,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0xde,0xcd,0x78,0x5c,0x48,0x8b,0xe8,0x48,0x8b,0x17,0x48,0x8d,0x4d,0x08,0xe8,0x0f,0xbf,0x78,0x5c,0x4c,0x8b,0xc5,0x48,0x8b,0xcb,0xba,0x01,0x00,0x00,0x00,0xe8,0x1f,0xc0,0x78,0x5c,0x48,0xba,0x80,0x95,0xb6,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x8b,0xce,0x4c,0x8b,0xc3,0x49,0xbb,0x98,0x11,0x9d,0x7f,0xfe,0x7f,0x00,0x00,0x48,0x8b,0x05,0xf3,0x66,0xb4,0xfc,0x39,0x09,0x48,0x83,0xc4,0x28,0x5b,0x5d,0x5e,0x5f,0x48,0xff,0xe0,0x00,0x00,0x19,0x08,0x05,0x00,0x08,0x42,0x04,0x30,0x03,0x50,0x02,0x60,0x01,0x70,0x00,0x00,0x40,0x00,0x00,0x00,0x90,0x3d,0x0a,0x83,0xfe,0x7f,0x00,0x00,0x41,0x57,0x41,0x56,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x28,0x48,0x8b,0xd9,0x48,0x8b,0xf2,0x49,0x8b,0xf8,0x48,0xb9,0xc8,0x52,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xba,0x01,0x00,0x00,0x00,0xe8,0xd7,0xce,0x78,0x5c,0x48,0x8b,0xe8,0x48,0xb9,0xe0,0x96,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0x35,0xcd,0x78,0x5c,0x44,0x8b,0x46,0x04,0x44,0x89,0x40,0x08,0x4c,0x8b,0xc0,0x48,0x8b,0xcd,0x33,0xd2,0xe8,0x80,0xbf,0x78,0x5c,0x48,0xba,0x38,0x0d,0xcb,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x8b,0xcf,0x4c,0x8b,0xc5,0x49,0xbb,0xa0,0x11,0x9d,0x7f,0xfe,0x7f,0x00,0x00,0x39,0x09,0xff,0x15,0x5b,0x66,0xb4,0xfc,0x33,0xed,0x48,0x8d,0x4e,0x18,0x48,0x8b,0x01,0x48,0x85,0xc0,0x74,0x39,0x8b,0x40,0x08,0x85,0xc0,0x74,0x32,0x48,0x8b,0x01,0x48,0x85,0xc0,0x74,0x23,0x8b,0x40,0x08,0x83,0xf8,0x01,0x75,0x1b,0x48,0x8b,0x09,0x83,0x79,0x08,0x00,0x0f,0x86,0xc7,0x02,0x00,0x00,0x80,0x79,0x10,0x00,0x0f,0x94,0xc1,0x0f,0xb6,0xc9,0x85,0xc9,0x75,0x07,0xbd,0x02,0x00,0x00,0x00,0xeb,0x19,0x48,0x8d,0x4e,0x08,0xe8,0x7b,0x9a,0xc7,0xfc,0x48,0x85,0xc0,0x74,0x0b,0x83,0x78,0x08,0x00,0x76,0x05,0xbd,0x01,0x00,0x00,0x00,0x83,0xfd,0x01,0x75,0x23,0x48,0x8d,0x56,0x08,0x48,0x8b,0xcb,0x4c,0x8b,0xc7,0x48,0xb8,0xd0,0xa8,0xe8,0x82,0xfe,0x7f,0x00,0x00,0x48,0x83,0xc4,0x28,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0x41,0x5f,0x48,0xff,0xe0,0x48,0xb9,0xc8,0x52,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xba,0x02,0x00,0x00,0x00,0xe8,0xef,0xcd,0x78,0x5c,0x4c,0x8b,0xf0,0x49,0xb8,0x60,0xfd,0xca,0x45,0x59,0x02,0x00,0x00,0x4d,0x8b,0x00,0x49,0x8b,0xce,0x33,0xd2,0xe8,0xa5,0xbe,0x78,0x5c,0x48,0xb9,0xc0,0x33,0xcf,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0x36,0xcc,0x78,0x5c,0x4c,0x8b,0x46,0x10,0x4c,0x89,0x40,0x08,0x4c,0x8b,0xc0,0x49,0x8b,0xce,0xba,0x01,0x00,0x00,0x00,0xe8,0x7e,0xbe,0x78,0x5c,0x48,0xba,0x40,0x0d,0xcb,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x8b,0xcf,0x4d,0x8b,0xc6,0x49,0xbb,0xa8,0x11,0x9d,0x7f,0xfe,0x7f,0x00,0x00,0x39,0x09,0xff,0x15,0x61,0x65,0xb4,0xfc,0x48,0xb9,0xc8,0x52,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xba,0x02,0x00,0x00,0x00,0xe8,0x75,0xcd,0x78,0x5c,0x4c,0x8b,0xf0,0x49,0xb8,0x60,0xfd,0xca,0x45,0x59,0x02,0x00,0x00,0x4d,0x8b,0x00,0x49,0x8b,0xce,0x33,0xd2,0xe8,0x2b,0xbe,0x78,0x5c,0x48,0xb9,0x28,0x37,0xcf,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0xbc,0xcb,0x78,0x5c,0x4c,0x8b,0xf8,0x48,0x8b,0x56,0x18,0x49,0x8d,0x4f,0x08,0xe8,0xec,0xbc,0x78,0x5c,0x4d,0x8b,0xc7,0x49,0x8b,0xce,0xba,0x01,0x00,0x00,0x00,0xe8,0xfc,0xbd,0x78,0x5c,0x48,0xba,0x50,0x0d,0xcb,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x8b,0xcf,0x4d,0x8b,0xc6,0x49,0xbb,0xb0,0x11,0x9d,0x7f,0xfe,0x7f,0x00,0x00,0x39,0x09,0xff,0x15,0xe7,0x64,0xb4,0xfc,0x83,0xfd,0x02,0x75,0x71,0x48,0xb9,0xc8,0x52,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xba,0x02,0x00,0x00,0x00,0xe8,0xee,0xcc,0x78,0x5c,0x48,0x8b,0xe8,0x49,0xb8,0x60,0xfd,0xca,0x45,0x59,0x02,0x00,0x00,0x4d,0x8b,0x00,0x48,0x8b,0xcd,0x33,0xd2,0xe8,0xa4,0xbd,0x78,0x5c,0x48,0x8d,0x56,0x18,0x48,0x8b,0xcb,0xe8,0x98,0x4e,0xd9,0xfd,0x4c,0x8b,0xc0,0x48,0x8b,0xcd,0xba,0x01,0x00,0x00,0x00,0xe8,0x88,0xbd,0x78,0x5c,0x48,0xba,0x58,0x0d,0xcb,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x8b,0xcf,0x4c,0x8b,0xc5,0x49,0xbb,0xc8,0x11,0x9d,0x7f,0xfe,0x7f,0x00,0x00,0x39,0x09,0xff,0x15,0x8b,0x64,0xb4,0xfc,0xeb,0x6d,0x48,0xb9,0xc8,0x52,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xba,0x02,0x00,0x00,0x00,0xe8,0x7d,0xcc,0x78,0x5c,0x48,0x8b,0xd8,0x49,0xb8,0x60,0xfd,0xca,0x45,0x59,0x02,0x00,0x00,0x4d,0x8b,0x00,0x48,0x8b,0xcb,0x33,0xd2,0xe8,0x33,0xbd,0x78,0x5c,0x49,0xb8,0x60,0x30,0xb6,0x45,0x59,0x02,0x00,0x00,0x4d,0x8b,0x00,0x48,0x8b,0xcb,0xba,0x01,0x00,0x00,0x00,0xe8,0x19,0xbd,0x78,0x5c,0x48,0xba,0x58,0x0d,0xcb,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x8b,0xcf,0x4c,0x8b,0xc3,0x49,0xbb,0xb8,0x11,0x9d,0x7f,0xfe,0x7f,0x00,0x00,0x39,0x09,0xff,0x15,0x0c,0x64,0xb4,0xfc,0x48,0xb9,0xc8,0x52,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xba,0x02,0x00,0x00,0x00,0xe8,0x10,0xcc,0x78,0x5c,0x48,0x8b,0xd8,0x49,0xb8,0x60,0xfd,0xca,0x45,0x59,0x02,0x00,0x00,0x4d,0x8b,0x00,0x48,0x8b,0xcb,0x33,0xd2,0xe8,0xc6,0xbc,0x78,0x5c,0x48,0xb9,0x70,0x1b,0xcf,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0x57,0xca,0x78,0x5c,0x48,0x8b,0xe8,0x48,0x8b,0x56,0x20,0x48,0x8d,0x4d,0x08,0xe8,0x87,0xbb,0x78,0x5c,0x4c,0x8b,0xc5,0x48,0x8b,0xcb,0xba,0x01,0x00,0x00,0x00,0xe8,0x97,0xbc,0x78,0x5c,0x48,0xba,0x80,0x95,0xb6,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x8b,0xcf,0x4c,0x8b,0xc3,0x49,0xbb,0xc0,0x11,0x9d,0x7f,0xfe,0x7f,0x00,0x00,0x48,0x8b,0x05,0x93,0x63,0xb4,0xfc,0x39,0x09,0x48,0x83,0xc4,0x28,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0x41,0x5f,0x48,0xff,0xe0,0xe8,0x5d,0x4e,0x8b,0x5c,0xcc,0x19,0x0c,0x07,0x00,0x0c,0x42,0x08,0x30,0x07,0x50,0x06,0x60,0x05,0x70};

        public static ReadOnlySpan<byte> RenderListEntryヽᐤNasmListEntryᕀinㆍITextBufferᐤ  =>  new byte[898]{0x41,0x57,0x41,0x56,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x28,0x48,0x8b,0xd9,0x48,0x8b,0xf2,0x49,0x8b,0xf8,0x48,0xb9,0xc8,0x52,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xba,0x01,0x00,0x00,0x00,0xe8,0xd7,0xce,0x78,0x5c,0x48,0x8b,0xe8,0x48,0xb9,0xe0,0x96,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0x35,0xcd,0x78,0x5c,0x44,0x8b,0x46,0x04,0x44,0x89,0x40,0x08,0x4c,0x8b,0xc0,0x48,0x8b,0xcd,0x33,0xd2,0xe8,0x80,0xbf,0x78,0x5c,0x48,0xba,0x38,0x0d,0xcb,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x8b,0xcf,0x4c,0x8b,0xc5,0x49,0xbb,0xa0,0x11,0x9d,0x7f,0xfe,0x7f,0x00,0x00,0x39,0x09,0xff,0x15,0x5b,0x66,0xb4,0xfc,0x33,0xed,0x48,0x8d,0x4e,0x18,0x48,0x8b,0x01,0x48,0x85,0xc0,0x74,0x39,0x8b,0x40,0x08,0x85,0xc0,0x74,0x32,0x48,0x8b,0x01,0x48,0x85,0xc0,0x74,0x23,0x8b,0x40,0x08,0x83,0xf8,0x01,0x75,0x1b,0x48,0x8b,0x09,0x83,0x79,0x08,0x00,0x0f,0x86,0xc7,0x02,0x00,0x00,0x80,0x79,0x10,0x00,0x0f,0x94,0xc1,0x0f,0xb6,0xc9,0x85,0xc9,0x75,0x07,0xbd,0x02,0x00,0x00,0x00,0xeb,0x19,0x48,0x8d,0x4e,0x08,0xe8,0x7b,0x9a,0xc7,0xfc,0x48,0x85,0xc0,0x74,0x0b,0x83,0x78,0x08,0x00,0x76,0x05,0xbd,0x01,0x00,0x00,0x00,0x83,0xfd,0x01,0x75,0x23,0x48,0x8d,0x56,0x08,0x48,0x8b,0xcb,0x4c,0x8b,0xc7,0x48,0xb8,0xd0,0xa8,0xe8,0x82,0xfe,0x7f,0x00,0x00,0x48,0x83,0xc4,0x28,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0x41,0x5f,0x48,0xff,0xe0,0x48,0xb9,0xc8,0x52,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xba,0x02,0x00,0x00,0x00,0xe8,0xef,0xcd,0x78,0x5c,0x4c,0x8b,0xf0,0x49,0xb8,0x60,0xfd,0xca,0x45,0x59,0x02,0x00,0x00,0x4d,0x8b,0x00,0x49,0x8b,0xce,0x33,0xd2,0xe8,0xa5,0xbe,0x78,0x5c,0x48,0xb9,0xc0,0x33,0xcf,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0x36,0xcc,0x78,0x5c,0x4c,0x8b,0x46,0x10,0x4c,0x89,0x40,0x08,0x4c,0x8b,0xc0,0x49,0x8b,0xce,0xba,0x01,0x00,0x00,0x00,0xe8,0x7e,0xbe,0x78,0x5c,0x48,0xba,0x40,0x0d,0xcb,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x8b,0xcf,0x4d,0x8b,0xc6,0x49,0xbb,0xa8,0x11,0x9d,0x7f,0xfe,0x7f,0x00,0x00,0x39,0x09,0xff,0x15,0x61,0x65,0xb4,0xfc,0x48,0xb9,0xc8,0x52,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xba,0x02,0x00,0x00,0x00,0xe8,0x75,0xcd,0x78,0x5c,0x4c,0x8b,0xf0,0x49,0xb8,0x60,0xfd,0xca,0x45,0x59,0x02,0x00,0x00,0x4d,0x8b,0x00,0x49,0x8b,0xce,0x33,0xd2,0xe8,0x2b,0xbe,0x78,0x5c,0x48,0xb9,0x28,0x37,0xcf,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0xbc,0xcb,0x78,0x5c,0x4c,0x8b,0xf8,0x48,0x8b,0x56,0x18,0x49,0x8d,0x4f,0x08,0xe8,0xec,0xbc,0x78,0x5c,0x4d,0x8b,0xc7,0x49,0x8b,0xce,0xba,0x01,0x00,0x00,0x00,0xe8,0xfc,0xbd,0x78,0x5c,0x48,0xba,0x50,0x0d,0xcb,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x8b,0xcf,0x4d,0x8b,0xc6,0x49,0xbb,0xb0,0x11,0x9d,0x7f,0xfe,0x7f,0x00,0x00,0x39,0x09,0xff,0x15,0xe7,0x64,0xb4,0xfc,0x83,0xfd,0x02,0x75,0x71,0x48,0xb9,0xc8,0x52,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xba,0x02,0x00,0x00,0x00,0xe8,0xee,0xcc,0x78,0x5c,0x48,0x8b,0xe8,0x49,0xb8,0x60,0xfd,0xca,0x45,0x59,0x02,0x00,0x00,0x4d,0x8b,0x00,0x48,0x8b,0xcd,0x33,0xd2,0xe8,0xa4,0xbd,0x78,0x5c,0x48,0x8d,0x56,0x18,0x48,0x8b,0xcb,0xe8,0x98,0x4e,0xd9,0xfd,0x4c,0x8b,0xc0,0x48,0x8b,0xcd,0xba,0x01,0x00,0x00,0x00,0xe8,0x88,0xbd,0x78,0x5c,0x48,0xba,0x58,0x0d,0xcb,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x8b,0xcf,0x4c,0x8b,0xc5,0x49,0xbb,0xc8,0x11,0x9d,0x7f,0xfe,0x7f,0x00,0x00,0x39,0x09,0xff,0x15,0x8b,0x64,0xb4,0xfc,0xeb,0x6d,0x48,0xb9,0xc8,0x52,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xba,0x02,0x00,0x00,0x00,0xe8,0x7d,0xcc,0x78,0x5c,0x48,0x8b,0xd8,0x49,0xb8,0x60,0xfd,0xca,0x45,0x59,0x02,0x00,0x00,0x4d,0x8b,0x00,0x48,0x8b,0xcb,0x33,0xd2,0xe8,0x33,0xbd,0x78,0x5c,0x49,0xb8,0x60,0x30,0xb6,0x45,0x59,0x02,0x00,0x00,0x4d,0x8b,0x00,0x48,0x8b,0xcb,0xba,0x01,0x00,0x00,0x00,0xe8,0x19,0xbd,0x78,0x5c,0x48,0xba,0x58,0x0d,0xcb,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x8b,0xcf,0x4c,0x8b,0xc3,0x49,0xbb,0xb8,0x11,0x9d,0x7f,0xfe,0x7f,0x00,0x00,0x39,0x09,0xff,0x15,0x0c,0x64,0xb4,0xfc,0x48,0xb9,0xc8,0x52,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xba,0x02,0x00,0x00,0x00,0xe8,0x10,0xcc,0x78,0x5c,0x48,0x8b,0xd8,0x49,0xb8,0x60,0xfd,0xca,0x45,0x59,0x02,0x00,0x00,0x4d,0x8b,0x00,0x48,0x8b,0xcb,0x33,0xd2,0xe8,0xc6,0xbc,0x78,0x5c,0x48,0xb9,0x70,0x1b,0xcf,0x7f,0xfe,0x7f,0x00,0x00,0xe8,0x57,0xca,0x78,0x5c,0x48,0x8b,0xe8,0x48,0x8b,0x56,0x20,0x48,0x8d,0x4d,0x08,0xe8,0x87,0xbb,0x78,0x5c,0x4c,0x8b,0xc5,0x48,0x8b,0xcb,0xba,0x01,0x00,0x00,0x00,0xe8,0x97,0xbc,0x78,0x5c,0x48,0xba,0x80,0x95,0xb6,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0x8b,0xcf,0x4c,0x8b,0xc3,0x49,0xbb,0xc0,0x11,0x9d,0x7f,0xfe,0x7f,0x00,0x00,0x48,0x8b,0x05,0x93,0x63,0xb4,0xfc,0x39,0x09,0x48,0x83,0xc4,0x28,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0x41,0x5f,0x48,0xff,0xe0,0xe8,0x5d,0x4e,0x8b,0x5c,0xcc,0x19,0x0c,0x07,0x00,0x0c,0x42,0x08,0x30,0x07,0x50,0x06,0x60,0x05,0x70};

        public static ReadOnlySpan<byte> kindヽᐤNasmListEntryᕀinᐤ  =>  new byte[114]{0x56,0x48,0x83,0xec,0x20,0x33,0xf6,0x48,0x8d,0x41,0x18,0x48,0x8b,0x10,0x48,0x85,0xd2,0x74,0x35,0x8b,0x52,0x08,0x85,0xd2,0x74,0x2e,0x48,0x8b,0x10,0x48,0x85,0xd2,0x74,0x1f,0x8b,0x52,0x08,0x83,0xfa,0x01,0x75,0x17,0x48,0x8b,0x00,0x83,0x78,0x08,0x00,0x76,0x36,0x80,0x78,0x10,0x00,0x0f,0x94,0xc0,0x0f,0xb6,0xc0,0x85,0xc0,0x75,0x07,0xbe,0x02,0x00,0x00,0x00,0xeb,0x19,0x48,0x83,0xc1,0x08,0xe8,0x4f,0x97,0xc7,0xfc,0x48,0x85,0xc0,0x74,0x0b,0x83,0x78,0x08,0x00,0x76,0x05,0xbe,0x01,0x00,0x00,0x00,0x8b,0xc6,0x48,0x83,0xc4,0x20,0x5e,0xc3,0xe8,0xc2,0x4d,0x8b,0x5c,0xcc,0x00,0x19,0x05};

        public static ReadOnlySpan<byte> renderヽᐤNasmDebugOptionsᕀ16uᐤ  =>  new byte[412]{0x48,0x83,0xec,0x38,0x90,0x0f,0xb7,0xd1,0xf6,0xc2,0x02,0x75,0x12,0x48,0xb8,0x60,0x30,0xb6,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x00,0x48,0x83,0xc4,0x38,0xc3,0xf6,0xc2,0x10,0x0f,0x95,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0x88,0x44,0x24,0x30,0x8b,0x44,0x24,0x30,0x0f,0xb6,0xc8,0xf6,0xc2,0x40,0x0f,0x95,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0x88,0x44,0x24,0x28,0x8b,0x44,0x24,0x28,0x44,0x0f,0xb6,0xc0,0x41,0xd1,0xe0,0xf7,0xc2,0x00,0x01,0x00,0x00,0x0f,0x95,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0x88,0x44,0x24,0x20,0x8b,0x44,0x24,0x20,0x0f,0xb6,0xc0,0x44,0x8d,0x0c,0x40,0xf7,0xc2,0x00,0x04,0x00,0x00,0x0f,0x95,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0x88,0x44,0x24,0x18,0x8b,0x44,0x24,0x18,0x44,0x0f,0xb6,0xd0,0x41,0xc1,0xe2,0x02,0xf7,0xc2,0x00,0x10,0x00,0x00,0x0f,0x95,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0x88,0x44,0x24,0x10,0x8b,0x44,0x24,0x10,0x0f,0xb6,0xc0,0x44,0x8d,0x1c,0x80,0xf7,0xc2,0x00,0x40,0x00,0x00,0x0f,0x95,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0x88,0x44,0x24,0x08,0x8b,0x44,0x24,0x08,0x0f,0xb6,0xc0,0x8d,0x14,0x40,0xd1,0xe2,0x85,0xc9,0x75,0x2a,0x45,0x85,0xc0,0x75,0x20,0x45,0x85,0xc9,0x75,0x16,0x45,0x85,0xd2,0x75,0x0c,0x45,0x85,0xdb,0x75,0x02,0xeb,0x03,0x41,0x8b,0xd3,0xeb,0x03,0x41,0x8b,0xd2,0xeb,0x03,0x41,0x8b,0xd1,0xeb,0x03,0x41,0x8b,0xd0,0xeb,0x02,0x8b,0xd1,0x85,0xd2,0x75,0x12,0x48,0xb8,0x60,0x0d,0xcb,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x00,0x48,0x83,0xc4,0x38,0xc3,0xff,0xca,0x83,0xfa,0x05,0x77,0x72,0x8b,0xc2,0x48,0x8d,0x15,0x7f,0x00,0x00,0x00,0x8b,0x14,0x82,0x48,0x8d,0x0d,0xda,0xfe,0xff,0xff,0x48,0x03,0xd1,0xff,0xe2,0x48,0xb8,0x68,0x0d,0xcb,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x00,0xeb,0x58,0x48,0xb8,0x70,0x0d,0xcb,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x00,0xeb,0x49,0x48,0xb8,0x78,0x0d,0xcb,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x00,0xeb,0x3a,0x48,0xb8,0x80,0x0d,0xcb,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x00,0xeb,0x2b,0x48,0xb8,0x88,0x0d,0xcb,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x00,0xeb,0x1c,0x48,0xb8,0x90,0x0d,0xcb,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x00,0xeb,0x0d,0x48,0xb8,0x60,0x30,0xb6,0x45,0x59,0x02,0x00,0x00,0x48,0x8b,0x00,0x48,0x83,0xc4,0x38,0xc3};

        public static ReadOnlySpan<byte> testヽᐤNasmDebugOptionsᕀ16uㆍNasmDebugOptionsᕀ16uᐤ  =>  new byte[23]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb7,0xc1,0x0f,0xb7,0xd2,0x85,0xc2,0x0f,0x95,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> scriptヽᐤNasmCaseㆍFilePathᐤ  =>  new byte[154]{0x57,0x56,0x53,0x48,0x83,0xec,0x50,0xc5,0xf8,0x77,0x48,0x8b,0xf1,0x48,0x8d,0x7c,0x24,0x08,0xb9,0x12,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x48,0x8b,0xd9,0x33,0xc0,0x48,0x8d,0x4c,0x24,0x28,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x01,0xc5,0xfa,0x7f,0x41,0x10,0x48,0x89,0x41,0x20,0xc5,0xfa,0x6f,0x02,0xc5,0xfa,0x7f,0x44,0x24,0x08,0xc5,0xfa,0x6f,0x42,0x10,0xc5,0xfa,0x7f,0x44,0x24,0x18,0xc5,0xfa,0x6f,0x44,0x24,0x08,0xc5,0xfa,0x7f,0x44,0x24,0x28,0xc5,0xfa,0x6f,0x44,0x24,0x18,0xc5,0xfa,0x7f,0x44,0x24,0x38,0x48,0x8d,0x44,0x24,0x48,0x4c,0x89,0x00,0x48,0x8b,0xfb,0x48,0x8d,0x74,0x24,0x28,0xe8,0xa5,0xb8,0x78,0x5c,0xe8,0xa0,0xb8,0x78,0x5c,0xe8,0x9b,0xb8,0x78,0x5c,0xe8,0x96,0xb8,0x78,0x5c,0xe8,0x91,0xb8,0x78,0x5c,0x48,0x8b,0xc3,0x48,0x83,0xc4,0x50,0x5b,0x5e,0x5f,0xc3};

    }
}