﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2021-11-14 3:49:57 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class lib_currentprocess
    {
        public static ReadOnlySpan<byte> get_OsThreadIdヽᐤᐤ  =>  new byte[147]{0x55,0x41,0x57,0x41,0x56,0x41,0x55,0x41,0x54,0x57,0x56,0x53,0x48,0x83,0xec,0x68,0x48,0x8d,0xac,0x24,0xa0,0x00,0x00,0x00,0x48,0x8d,0x4d,0x88,0x49,0x8b,0xd2,0xe8,0xbc,0xad,0xf6,0x5b,0x48,0x8b,0xf0,0x4c,0x8b,0xdc,0x4c,0x89,0x5d,0xa8,0x4c,0x8b,0xdd,0x4c,0x89,0x5d,0xb8,0x45,0x33,0xdb,0x48,0xb8,0x38,0xd4,0xff,0x80,0xfe,0x7f,0x00,0x00,0x48,0x89,0x45,0x98,0x48,0x8d,0x05,0x16,0x00,0x00,0x00,0x48,0x89,0x45,0xb0,0x48,0x8d,0x45,0x88,0x48,0x89,0x46,0x10,0xc6,0x46,0x0c,0x00,0xff,0x15,0xe5,0xbd,0xa4,0xfd,0xc6,0x46,0x0c,0x01,0x83,0x3d,0x7a,0x62,0x44,0x5c,0x00,0x74,0x06,0xff,0x15,0x42,0x99,0x43,0x5c,0x48,0x8b,0x55,0x90,0x48,0x89,0x56,0x10,0xc6,0x46,0x0c,0x01,0x48,0x8d,0x65,0xc8,0x5b,0x5e,0x5f,0x41,0x5c,0x41,0x5d,0x41,0x5e,0x41,0x5f,0x5d,0xc3};

        public static ReadOnlySpan<byte> get_ManagedThreadIdヽᐤᐤ  =>  new byte[55]{0x48,0x83,0xec,0x28,0x90,0x48,0xb9,0x20,0x00,0xac,0x7f,0xfe,0x7f,0x00,0x00,0xba,0xe2,0x01,0x00,0x00,0xe8,0x27,0x3c,0x00,0x5c,0x48,0x8b,0x48,0x08,0x48,0x85,0xc9,0x75,0x08,0xe8,0xf9,0xe1,0x9a,0x5b,0x48,0x8b,0xc8,0x39,0x09,0xe8,0xbf,0x1c,0x03,0x5c,0x90,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> get_ProcessIdヽᐤᐤ  =>  new byte[40]{0x56,0x48,0x83,0xec,0x20,0xe8,0xd6,0xcb,0x56,0xfc,0x48,0x8b,0xf0,0x8b,0x0e,0x48,0x8b,0xce,0xba,0x01,0x00,0x00,0x00,0xe8,0x1c,0xeb,0xd9,0xfd,0x8b,0x86,0xc8,0x00,0x00,0x00,0x48,0x83,0xc4,0x20,0x5e,0xc3};

        public static ReadOnlySpan<byte> get_ProcessHandleヽᐤᐤ  =>  new byte[46]{0x56,0x48,0x83,0xec,0x20,0xe8,0x96,0xcb,0x56,0xfc,0x48,0x8b,0xf0,0x8b,0x0e,0x48,0x8b,0xce,0xba,0x20,0x00,0x00,0x00,0xe8,0xdc,0xea,0xd9,0xfd,0x48,0x8b,0xce,0xe8,0x34,0xeb,0xd9,0xfd,0x48,0x8b,0x40,0x08,0x48,0x83,0xc4,0x20,0x5e,0xc3};

        public static ReadOnlySpan<byte> get_ThreadHandleヽᐤᐤ  =>  new byte[147]{0x55,0x41,0x57,0x41,0x56,0x41,0x55,0x41,0x54,0x57,0x56,0x53,0x48,0x83,0xec,0x68,0x48,0x8d,0xac,0x24,0xa0,0x00,0x00,0x00,0x48,0x8d,0x4d,0x88,0x49,0x8b,0xd2,0xe8,0x1c,0xac,0xf6,0x5b,0x48,0x8b,0xf0,0x4c,0x8b,0xdc,0x4c,0x89,0x5d,0xa8,0x4c,0x8b,0xdd,0x4c,0x89,0x5d,0xb8,0x45,0x33,0xdb,0x48,0xb8,0x80,0xd4,0xff,0x80,0xfe,0x7f,0x00,0x00,0x48,0x89,0x45,0x98,0x48,0x8d,0x05,0x16,0x00,0x00,0x00,0x48,0x89,0x45,0xb0,0x48,0x8d,0x45,0x88,0x48,0x89,0x46,0x10,0xc6,0x46,0x0c,0x00,0xff,0x15,0x55,0xbc,0xa4,0xfd,0xc6,0x46,0x0c,0x01,0x83,0x3d,0xda,0x60,0x44,0x5c,0x00,0x74,0x06,0xff,0x15,0xa2,0x97,0x43,0x5c,0x48,0x8b,0x55,0x90,0x48,0x89,0x56,0x10,0xc6,0x46,0x0c,0x01,0x48,0x8d,0x65,0xc8,0x5b,0x5e,0x5f,0x41,0x5c,0x41,0x5d,0x41,0x5e,0x41,0x5f,0x5d,0xc3};

        public static ReadOnlySpan<byte> get_Nameヽᐤᐤ  =>  new byte[42]{0x56,0x48,0x83,0xec,0x20,0xe8,0x86,0xca,0x56,0xfc,0x48,0x8b,0xf0,0x8b,0x0e,0x48,0x8b,0xce,0xba,0x08,0x00,0x00,0x00,0xe8,0xcc,0xe9,0xd9,0xfd,0x48,0x8b,0x46,0x28,0x48,0x8b,0x40,0x10,0x48,0x83,0xc4,0x20,0x5e,0xc3};

    }
}
