﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2022-01-07 15:36:32 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class fsm_primalfsmspecs
    {
        public static ReadOnlySpan<byte> modelGヽᐤarray_Stateᕀ8uㆍarray_Eventᕀ8uㆍarray_Resultᕀ8uᐤ  =>  new byte[116]{0x41,0x56,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x20,0x48,0x8b,0xf1,0x48,0x8b,0xfa,0x49,0x8b,0xd8,0x49,0x8b,0xe9,0x48,0xb9,0x20,0x00,0xd4,0x76,0xfd,0x7f,0x00,0x00,0xba,0xb2,0x00,0x00,0x00,0xe8,0xb6,0xcf,0xeb,0x5b,0x48,0xba,0x78,0x16,0x4f,0x73,0xd5,0x01,0x00,0x00,0x4c,0x8b,0x32,0x48,0x8b,0xd7,0x48,0x8b,0xce,0xe8,0x1e,0x01,0xef,0x5b,0x48,0x8d,0x4e,0x08,0x48,0x8b,0xd3,0xe8,0x12,0x01,0xef,0x5b,0x48,0x8d,0x4e,0x10,0x48,0x8b,0xd5,0xe8,0x06,0x01,0xef,0x5b,0x48,0x8d,0x4e,0x18,0x49,0x8b,0xd6,0xe8,0xfa,0x00,0xef,0x5b,0x48,0x8b,0xc6,0x48,0x83,0xc4,0x20,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0xc3};

        public static ReadOnlySpan<byte> modelヽᐤarray_Eventᕀ8uㆍarray_Stateᕀ8uㆍarray_Resultᕀ8uᐤ  =>  new byte[1060]{0x41,0x57,0x41,0x56,0x41,0x55,0x41,0x54,0x57,0x56,0x55,0x53,0x48,0x81,0xec,0xe8,0x00,0x00,0x00,0x48,0x8b,0xf1,0x48,0x8d,0xbc,0x24,0x98,0x00,0x00,0x00,0xb9,0x14,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x48,0x8b,0xd9,0x48,0x8b,0xea,0x4d,0x8b,0xf0,0x4d,0x8b,0xf9,0x48,0xb9,0x88,0xe7,0x74,0x78,0xfd,0x7f,0x00,0x00,0xba,0x05,0x00,0x00,0x00,0xe8,0x96,0x08,0xef,0x5b,0x4c,0x8b,0xe0,0x33,0xc9,0x48,0x8d,0x94,0x24,0x90,0x00,0x00,0x00,0x89,0x0a,0xc6,0x84,0x24,0x90,0x00,0x00,0x00,0x00,0xc6,0x84,0x24,0x91,0x00,0x00,0x00,0x00,0xc6,0x84,0x24,0x92,0x00,0x00,0x00,0x01,0x8b,0x8c,0x24,0x90,0x00,0x00,0x00,0x89,0x8c,0x24,0x88,0x00,0x00,0x00,0x8b,0x8c,0x24,0x88,0x00,0x00,0x00,0x40,0x0f,0xb6,0xf1,0x8b,0x8c,0x24,0x89,0x00,0x00,0x00,0x40,0x0f,0xb6,0xf9,0x8b,0x8c,0x24,0x8a,0x00,0x00,0x00,0x44,0x0f,0xb6,0xe9,0x40,0x0f,0xb6,0xce,0x0f,0xb6,0xc9,0x40,0x0f,0xb6,0xd7,0xc6,0x84,0x24,0x80,0x00,0x00,0x00,0x00,0xc6,0x84,0x24,0x81,0x00,0x00,0x00,0x00,0x33,0xc0,0x89,0x84,0x24,0x84,0x00,0x00,0x00,0x0f,0xb6,0xc9,0x0f,0xb6,0xd2,0x88,0x8c,0x24,0x81,0x00,0x00,0x00,0x88,0x94,0x24,0x80,0x00,0x00,0x00,0xe8,0xdb,0xfa,0xff,0xff,0x89,0x84,0x24,0x84,0x00,0x00,0x00,0x48,0xb9,0x38,0x70,0xf7,0x7a,0xfd,0x7f,0x00,0x00,0xe8,0xbd,0x06,0xef,0x5b,0x48,0x8b,0x94,0x24,0x80,0x00,0x00,0x00,0x48,0x89,0x50,0x08,0x48,0x8d,0x94,0x24,0xd8,0x00,0x00,0x00,0x48,0x89,0x02,0x40,0x88,0x72,0x08,0x40,0x88,0x7a,0x09,0x44,0x88,0x6a,0x0a,0x49,0x8d,0x7c,0x24,0x10,0x48,0x8d,0xb4,0x24,0xd8,0x00,0x00,0x00,0xe8,0x68,0xf8,0xee,0x5b,0x48,0xa5,0x33,0xc9,0x48,0x8d,0x54,0x24,0x78,0x89,0x0a,0xc6,0x44,0x24,0x78,0x00,0xc6,0x44,0x24,0x79,0x01,0xc6,0x44,0x24,0x7a,0x02,0x8b,0x4c,0x24,0x78,0x89,0x4c,0x24,0x70,0x8b,0x4c,0x24,0x70,0x40,0x0f,0xb6,0xf1,0x8b,0x4c,0x24,0x71,0x40,0x0f,0xb6,0xf9,0x8b,0x4c,0x24,0x72,0x44,0x0f,0xb6,0xe9,0x40,0x0f,0xb6,0xce,0x0f,0xb6,0xc9,0x40,0x0f,0xb6,0xd7,0xc6,0x44,0x24,0x68,0x00,0xc6,0x44,0x24,0x69,0x00,0x33,0xc0,0x89,0x44,0x24,0x6c,0x0f,0xb6,0xc9,0x0f,0xb6,0xd2,0x88,0x4c,0x24,0x69,0x88,0x54,0x24,0x68,0xe8,0x28,0xfa,0xff,0xff,0x89,0x44,0x24,0x6c,0x48,0xb9,0x38,0x70,0xf7,0x7a,0xfd,0x7f,0x00,0x00,0xe8,0x0d,0x06,0xef,0x5b,0x48,0x8b,0x54,0x24,0x68,0x48,0x89,0x50,0x08,0x48,0x8d,0x94,0x24,0xc8,0x00,0x00,0x00,0x48,0x89,0x02,0x40,0x88,0x72,0x08,0x40,0x88,0x7a,0x09,0x44,0x88,0x6a,0x0a,0x49,0x8d,0x7c,0x24,0x20,0x48,0x8d,0xb4,0x24,0xc8,0x00,0x00,0x00,0xe8,0xbb,0xf7,0xee,0x5b,0x48,0xa5,0x33,0xc9,0x48,0x8d,0x54,0x24,0x60,0x89,0x0a,0xc6,0x44,0x24,0x60,0x00,0xc6,0x44,0x24,0x61,0x02,0xc6,0x44,0x24,0x62,0x03,0x8b,0x4c,0x24,0x60,0x89,0x4c,0x24,0x58,0x8b,0x4c,0x24,0x58,0x40,0x0f,0xb6,0xf1,0x8b,0x4c,0x24,0x59,0x40,0x0f,0xb6,0xf9,0x8b,0x4c,0x24,0x5a,0x44,0x0f,0xb6,0xe9,0x40,0x0f,0xb6,0xce,0x0f,0xb6,0xc9,0x40,0x0f,0xb6,0xd7,0xc6,0x44,0x24,0x50,0x00,0xc6,0x44,0x24,0x51,0x00,0x33,0xc0,0x89,0x44,0x24,0x54,0x0f,0xb6,0xc9,0x0f,0xb6,0xd2,0x88,0x4c,0x24,0x51,0x88,0x54,0x24,0x50,0xe8,0x7b,0xf9,0xff,0xff,0x89,0x44,0x24,0x54,0x48,0xb9,0x38,0x70,0xf7,0x7a,0xfd,0x7f,0x00,0x00,0xe8,0x60,0x05,0xef,0x5b,0x48,0x8b,0x54,0x24,0x50,0x48,0x89,0x50,0x08,0x48,0x8d,0x94,0x24,0xb8,0x00,0x00,0x00,0x48,0x89,0x02,0x40,0x88,0x72,0x08,0x40,0x88,0x7a,0x09,0x44,0x88,0x6a,0x0a,0x49,0x8d,0x7c,0x24,0x30,0x48,0x8d,0xb4,0x24,0xb8,0x00,0x00,0x00,0xe8,0x0e,0xf7,0xee,0x5b,0x48,0xa5,0x33,0xc9,0x48,0x8d,0x54,0x24,0x48,0x89,0x0a,0xc6,0x44,0x24,0x48,0x00,0xc6,0x44,0x24,0x49,0x03,0xc6,0x44,0x24,0x4a,0x04,0x8b,0x4c,0x24,0x48,0x89,0x4c,0x24,0x40,0x8b,0x4c,0x24,0x40,0x40,0x0f,0xb6,0xf1,0x8b,0x4c,0x24,0x41,0x40,0x0f,0xb6,0xf9,0x8b,0x4c,0x24,0x42,0x44,0x0f,0xb6,0xe9,0x40,0x0f,0xb6,0xce,0x0f,0xb6,0xc9,0x40,0x0f,0xb6,0xd7,0xc6,0x44,0x24,0x38,0x00,0xc6,0x44,0x24,0x39,0x00,0x33,0xc0,0x89,0x44,0x24,0x3c,0x0f,0xb6,0xc9,0x0f,0xb6,0xd2,0x88,0x4c,0x24,0x39,0x88,0x54,0x24,0x38,0xe8,0xce,0xf8,0xff,0xff,0x89,0x44,0x24,0x3c,0x48,0xb9,0x38,0x70,0xf7,0x7a,0xfd,0x7f,0x00,0x00,0xe8,0xb3,0x04,0xef,0x5b,0x48,0x8b,0x54,0x24,0x38,0x48,0x89,0x50,0x08,0x48,0x8d,0x94,0x24,0xa8,0x00,0x00,0x00,0x48,0x89,0x02,0x40,0x88,0x72,0x08,0x40,0x88,0x7a,0x09,0x44,0x88,0x6a,0x0a,0x49,0x8d,0x7c,0x24,0x40,0x48,0x8d,0xb4,0x24,0xa8,0x00,0x00,0x00,0xe8,0x61,0xf6,0xee,0x5b,0x48,0xa5,0x33,0xc9,0x48,0x8d,0x54,0x24,0x30,0x89,0x0a,0xc6,0x44,0x24,0x30,0x00,0xc6,0x44,0x24,0x31,0x04,0xc6,0x44,0x24,0x32,0x05,0x8b,0x4c,0x24,0x30,0x89,0x4c,0x24,0x28,0x8b,0x4c,0x24,0x28,0x40,0x0f,0xb6,0xf1,0x8b,0x4c,0x24,0x29,0x40,0x0f,0xb6,0xf9,0x8b,0x4c,0x24,0x2a,0x44,0x0f,0xb6,0xe9,0x40,0x0f,0xb6,0xce,0x0f,0xb6,0xc9,0x40,0x0f,0xb6,0xd7,0xc6,0x44,0x24,0x20,0x00,0xc6,0x44,0x24,0x21,0x00,0x33,0xc0,0x89,0x44,0x24,0x24,0x0f,0xb6,0xc9,0x0f,0xb6,0xd2,0x88,0x4c,0x24,0x21,0x88,0x54,0x24,0x20,0xe8,0x21,0xf8,0xff,0xff,0x89,0x44,0x24,0x24,0x48,0xb9,0x38,0x70,0xf7,0x7a,0xfd,0x7f,0x00,0x00,0xe8,0x06,0x04,0xef,0x5b,0x48,0x8b,0x54,0x24,0x20,0x48,0x89,0x50,0x08,0x48,0x8d,0x94,0x24,0x98,0x00,0x00,0x00,0x48,0x89,0x02,0x40,0x88,0x72,0x08,0x40,0x88,0x7a,0x09,0x44,0x88,0x6a,0x0a,0x49,0x8d,0x7c,0x24,0x50,0x48,0x8d,0xb4,0x24,0x98,0x00,0x00,0x00,0xe8,0xb4,0xf5,0xee,0x5b,0x48,0xa5,0x48,0x8b,0xcb,0x48,0x8b,0xd5,0xe8,0xd7,0xf4,0xee,0x5b,0x48,0x8d,0x4b,0x08,0x49,0x8b,0xd6,0xe8,0xcb,0xf4,0xee,0x5b,0x48,0x8d,0x4b,0x10,0x49,0x8b,0xd7,0xe8,0xbf,0xf4,0xee,0x5b,0x48,0x8d,0x4b,0x18,0x49,0x8b,0xd4,0xe8,0xb3,0xf4,0xee,0x5b,0x48,0x8b,0xc3,0x48,0x81,0xc4,0xe8,0x00,0x00,0x00,0x5b,0x5d,0x5e,0x5f,0x41,0x5c,0x41,0x5d,0x41,0x5e,0x41,0x5f,0xc3};

    }
}
