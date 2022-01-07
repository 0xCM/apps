﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2022-01-07 15:36:31 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class lib_currentprocess
    {
        public static ReadOnlySpan<byte> get_OsThreadIdヽᐤᐤ  =>  new byte[165]{0x55,0x41,0x57,0x41,0x56,0x41,0x55,0x41,0x54,0x57,0x56,0x53,0x48,0x83,0xec,0x68,0x48,0x8d,0xac,0x24,0xa0,0x00,0x00,0x00,0x48,0x8d,0x4d,0x88,0x49,0x8b,0xd2,0xe8,0x5c,0x13,0x8f,0x5b,0x48,0x8b,0xf0,0x4c,0x8b,0xdc,0x4c,0x89,0x5d,0xa8,0x4c,0x8b,0xdd,0x4c,0x89,0x5d,0xb8,0x45,0x33,0xdb,0x48,0xb8,0xd8,0xe0,0x39,0x66,0xfb,0x7f,0x00,0x00,0x48,0x89,0x45,0x98,0x48,0x8d,0x05,0x1c,0x00,0x00,0x00,0x48,0x89,0x45,0xb0,0x48,0x8d,0x45,0x88,0x48,0x89,0x46,0x10,0xc6,0x46,0x0c,0x00,0x48,0xb8,0xa8,0xe3,0x39,0x66,0xfb,0x7f,0x00,0x00,0xff,0x10,0xc6,0x46,0x0c,0x01,0x48,0xba,0xa8,0x7b,0x07,0xc5,0xfb,0x7f,0x00,0x00,0x83,0x3a,0x00,0x74,0x0c,0x48,0xb9,0x78,0xb2,0x06,0xc5,0xfb,0x7f,0x00,0x00,0xff,0x11,0x48,0x8b,0x55,0x90,0x48,0x89,0x56,0x10,0xc6,0x46,0x0c,0x01,0x48,0x8d,0x65,0xc8,0x5b,0x5e,0x5f,0x41,0x5c,0x41,0x5d,0x41,0x5e,0x41,0x5f,0x5d,0xc3};

        public static ReadOnlySpan<byte> get_ManagedThreadIdヽᐤᐤ  =>  new byte[55]{0x48,0x83,0xec,0x28,0x90,0x48,0xb9,0x20,0x00,0x12,0x65,0xfb,0x7f,0x00,0x00,0xba,0xe2,0x01,0x00,0x00,0xe8,0xb7,0xa1,0x98,0x5b,0x48,0x8b,0x48,0x08,0x48,0x85,0xc9,0x75,0x08,0xe8,0x89,0x47,0x90,0x57,0x48,0x8b,0xc8,0x39,0x09,0xe8,0x4f,0x82,0x9b,0x5b,0x90,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> get_ProcessIdヽᐤᐤ  =>  new byte[40]{0x56,0x48,0x83,0xec,0x20,0xe8,0x6e,0x41,0xed,0xfb,0x48,0x8b,0xf0,0x8b,0x0e,0x48,0x8b,0xce,0xba,0x01,0x00,0x00,0x00,0xe8,0x64,0x79,0x62,0xfd,0x8b,0x86,0xc8,0x00,0x00,0x00,0x48,0x83,0xc4,0x20,0x5e,0xc3};

        public static ReadOnlySpan<byte> get_ProcessHandleヽᐤᐤ  =>  new byte[46]{0x56,0x48,0x83,0xec,0x20,0xe8,0x2e,0x41,0xed,0xfb,0x48,0x8b,0xf0,0x8b,0x0e,0x48,0x8b,0xce,0xba,0x20,0x00,0x00,0x00,0xe8,0x24,0x79,0x62,0xfd,0x48,0x8b,0xce,0xe8,0x7c,0x79,0x62,0xfd,0x48,0x8b,0x40,0x08,0x48,0x83,0xc4,0x20,0x5e,0xc3};

        public static ReadOnlySpan<byte> get_ThreadHandleヽᐤᐤ  =>  new byte[165]{0x55,0x41,0x57,0x41,0x56,0x41,0x55,0x41,0x54,0x57,0x56,0x53,0x48,0x83,0xec,0x68,0x48,0x8d,0xac,0x24,0xa0,0x00,0x00,0x00,0x48,0x8d,0x4d,0x88,0x49,0x8b,0xd2,0xe8,0xac,0x11,0x8f,0x5b,0x48,0x8b,0xf0,0x4c,0x8b,0xdc,0x4c,0x89,0x5d,0xa8,0x4c,0x8b,0xdd,0x4c,0x89,0x5d,0xb8,0x45,0x33,0xdb,0x48,0xb8,0x20,0xe1,0x39,0x66,0xfb,0x7f,0x00,0x00,0x48,0x89,0x45,0x98,0x48,0x8d,0x05,0x1c,0x00,0x00,0x00,0x48,0x89,0x45,0xb0,0x48,0x8d,0x45,0x88,0x48,0x89,0x46,0x10,0xc6,0x46,0x0c,0x00,0x48,0xb8,0xb8,0xe3,0x39,0x66,0xfb,0x7f,0x00,0x00,0xff,0x10,0xc6,0x46,0x0c,0x01,0x48,0xba,0xa8,0x7b,0x07,0xc5,0xfb,0x7f,0x00,0x00,0x83,0x3a,0x00,0x74,0x0c,0x48,0xb9,0x78,0xb2,0x06,0xc5,0xfb,0x7f,0x00,0x00,0xff,0x11,0x48,0x8b,0x55,0x90,0x48,0x89,0x56,0x10,0xc6,0x46,0x0c,0x01,0x48,0x8d,0x65,0xc8,0x5b,0x5e,0x5f,0x41,0x5c,0x41,0x5d,0x41,0x5e,0x41,0x5f,0x5d,0xc3};

        public static ReadOnlySpan<byte> get_Nameヽᐤᐤ  =>  new byte[42]{0x56,0x48,0x83,0xec,0x20,0xe8,0x0e,0x40,0xed,0xfb,0x48,0x8b,0xf0,0x8b,0x0e,0x48,0x8b,0xce,0xba,0x08,0x00,0x00,0x00,0xe8,0x04,0x78,0x62,0xfd,0x48,0x8b,0x46,0x28,0x48,0x8b,0x40,0x10,0x48,0x83,0xc4,0x20,0x5e,0xc3};

    }
}
