﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2022-01-07 15:36:29 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class capture_capture
    {
        public static ReadOnlySpan<byte> runヽᐤarray_stringᐤ  =>  new byte[994]{0x55,0x41,0x57,0x41,0x56,0x57,0x56,0x53,0x48,0x81,0xec,0x38,0x01,0x00,0x00,0xc5,0xf8,0x77,0x48,0x8d,0xac,0x24,0x60,0x01,0x00,0x00,0x48,0x8b,0xf1,0x48,0x8d,0xbd,0xd8,0xfe,0xff,0xff,0xb9,0x40,0x00,0x00,0x00,0x33,0xc0,0xf3,0xab,0x48,0x8b,0xce,0x48,0x89,0xa5,0xc8,0xfe,0xff,0xff,0x48,0x8b,0xf1,0x48,0xb9,0xc8,0xe7,0x33,0x65,0xfb,0x7f,0x00,0x00,0xe8,0x57,0xf0,0xb2,0x5f,0x48,0x8b,0xf8,0xe8,0x5f,0xa7,0xff,0xff,0x48,0x8b,0xd8,0x48,0x8b,0xcb,0x48,0x8b,0x03,0x48,0x8b,0x40,0x48,0xff,0x50,0x30,0x48,0x8b,0xd0,0x33,0xc9,0x48,0x89,0x8d,0x48,0xff,0xff,0xff,0x48,0x8d,0x8d,0x48,0xff,0xff,0xff,0xe8,0x67,0xab,0xff,0xff,0x48,0x8b,0x8d,0x48,0xff,0xff,0xff,0xba,0x5c,0x00,0x00,0x00,0x41,0xb8,0x2f,0x00,0x00,0x00,0x39,0x09,0xe8,0xf6,0xb9,0xfe,0xff,0x48,0x8b,0xd0,0x33,0xc9,0x48,0x89,0x8d,0x40,0xff,0xff,0xff,0x48,0x8d,0x8d,0x40,0xff,0xff,0xff,0xe8,0x36,0xab,0xff,0xff,0x48,0x8b,0x8d,0x40,0xff,0xff,0xff,0x48,0x89,0x8d,0x38,0xff,0xff,0xff,0x48,0x8d,0x8d,0x38,0xff,0xff,0xff,0xe8,0x2c,0xab,0xff,0xff,0x48,0x8b,0xc8,0xe8,0xf4,0xf0,0xff,0xff,0x48,0x8b,0xd0,0x33,0xc9,0x48,0x89,0x8d,0x28,0xff,0xff,0xff,0x48,0x8d,0x8d,0x28,0xff,0xff,0xff,0xe8,0xfc,0xaa,0xff,0xff,0x48,0x8b,0x8d,0x28,0xff,0xff,0xff,0xba,0x5c,0x00,0x00,0x00,0x41,0xb8,0x2f,0x00,0x00,0x00,0x39,0x09,0xe8,0x8b,0xb9,0xfe,0xff,0x48,0x8b,0xd0,0x33,0xc9,0x48,0x89,0x8d,0x20,0xff,0xff,0xff,0x48,0x8d,0x8d,0x20,0xff,0xff,0xff,0xe8,0xcb,0xaa,0xff,0xff,0x33,0xc9,0x48,0x89,0x8d,0x30,0xff,0xff,0xff,0x48,0x8b,0x95,0x20,0xff,0xff,0xff,0x48,0x8d,0x8d,0x30,0xff,0xff,0xff,0xe8,0x17,0xac,0xff,0xff,0x48,0x8b,0x8d,0x30,0xff,0xff,0xff,0x48,0x89,0x4d,0xd0,0x48,0x8b,0xcb,0x48,0x8b,0xd6,0xe8,0x01,0xea,0xff,0xff,0x48,0x8b,0xd8,0x48,0x8b,0xcb,0x49,0xbb,0x28,0x00,0x03,0x65,0xfb,0x7f,0x00,0x00,0x39,0x09,0xff,0x15,0x29,0x77,0xec,0xff,0x48,0x8b,0xc8,0x49,0xbb,0x30,0x00,0x03,0x65,0xfb,0x7f,0x00,0x00,0x39,0x09,0xff,0x15,0x1c,0x77,0xec,0xff,0x4c,0x8b,0xf0,0x49,0xb8,0x60,0x30,0x28,0x61,0xa1,0x02,0x00,0x00,0x4d,0x8b,0x00,0x48,0x8b,0xcb,0x48,0x8b,0xd6,0xe8,0x49,0xeb,0xff,0xff,0x48,0x89,0x85,0xd0,0xfe,0xff,0xff,0x48,0x8b,0x95,0xd0,0xfe,0xff,0xff,0x48,0xb9,0x40,0x49,0x3a,0x65,0xfb,0x7f,0x00,0x00,0xe8,0x94,0xc2,0xff,0xff,0x48,0x8b,0xd8,0x48,0xb9,0xc0,0x30,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x09,0x48,0x89,0x4d,0x90,0x48,0x8b,0x8d,0xd0,0xfe,0xff,0xff,0x48,0xba,0x80,0x16,0x3a,0x65,0xfb,0x7f,0x00,0x00,0x49,0xb8,0xc8,0xff,0x3a,0x65,0xfb,0x7f,0x00,0x00,0xe8,0xe0,0xd6,0xa0,0x5f,0x4c,0x8b,0xf8,0x48,0x8d,0x4d,0x90,0x48,0x8d,0x55,0xd0,0xe8,0x10,0xca,0xff,0xff,0x4c,0x8b,0xc0,0x48,0x8d,0x55,0x98,0x48,0x8b,0x8d,0xd0,0xfe,0xff,0xff,0x41,0xff,0xd7,0x83,0x7e,0x08,0x00,0x75,0x12,0x49,0x8b,0xd6,0x48,0x8b,0xcb,0x39,0x09,0xe8,0x44,0xc1,0xff,0xff,0x48,0x8b,0xf0,0xeb,0x16,0x49,0x8b,0xd6,0x48,0x8b,0xcb,0x41,0xb8,0x01,0x00,0x00,0x00,0x39,0x09,0xe8,0x3c,0xc1,0xff,0xff,0x48,0x8b,0xf0,0x33,0xc9,0x89,0x4f,0x08,0x48,0xb9,0xd0,0x0a,0x3c,0x65,0xfb,0x7f,0x00,0x00,0xe8,0x5d,0xee,0xb2,0x5f,0x48,0x8b,0xd8,0x48,0x8d,0x4b,0x08,0x48,0x8b,0xd7,0xe8,0x8e,0xdf,0xb2,0x5f,0x48,0xb9,0xd8,0x2e,0x16,0x65,0xfb,0x7f,0x00,0x00,0x48,0x89,0x4b,0x18,0x48,0x85,0xf6,0x0f,0x85,0xe2,0x00,0x00,0x00,0x33,0xc9,0x33,0xd2,0x4c,0x8d,0x85,0x10,0xff,0xff,0xff,0x49,0x89,0x08,0x41,0x89,0x50,0x08,0x48,0x8d,0x8d,0x10,0xff,0xff,0xff,0x48,0x8b,0xd3,0x45,0x33,0xc0,0xe8,0xa3,0xf6,0xff,0xff,0x48,0xb9,0xc8,0x30,0x28,0x61,0xa1,0x02,0x00,0x00,0x48,0x8b,0x09,0x48,0x89,0x4d,0x88,0x8b,0x4f,0x08,0x89,0x4d,0x80,0x48,0x8b,0xce,0x48,0x85,0xc9,0x0f,0x85,0xa7,0x00,0x00,0x00,0x33,0xc9,0x89,0x8d,0x78,0xff,0xff,0xff,0x48,0x8b,0x8d,0xd0,0xfe,0xff,0xff,0x48,0xba,0x80,0x16,0x3a,0x65,0xfb,0x7f,0x00,0x00,0x49,0xb8,0xd0,0x0c,0x3c,0x65,0xfb,0x7f,0x00,0x00,0xe8,0xe8,0xd5,0xa0,0x5f,0x48,0x8b,0xf8,0x48,0x8b,0x9d,0xd0,0xfe,0xff,0xff,0x4c,0x8d,0xb5,0x50,0xff,0xff,0xff,0xc5,0xfa,0x6f,0x45,0x98,0xc5,0xfa,0x7f,0x85,0xd8,0xfe,0xff,0xff,0xc5,0xfa,0x6f,0x45,0xa8,0xc5,0xfa,0x7f,0x85,0xe8,0xfe,0xff,0xff,0xc5,0xfa,0x6f,0x45,0xb8,0xc5,0xfa,0x7f,0x85,0xf8,0xfe,0xff,0xff,0x48,0x8b,0x4d,0xc8,0x48,0x89,0x8d,0x08,0xff,0xff,0xff,0x48,0x8d,0x4d,0x88,0x48,0x8d,0x55,0x80,0x4c,0x8d,0x85,0x78,0xff,0xff,0xff,0xe8,0xa1,0xca,0xff,0xff,0x4c,0x8b,0xc8,0xc7,0x44,0x24,0x20,0x0d,0x00,0x00,0x00,0x49,0x8b,0xd6,0x4c,0x8d,0x85,0xd8,0xfe,0xff,0xff,0x48,0x8b,0xcb,0xff,0xd7,0xeb,0x14,0x48,0x8d,0x4e,0x10,0x8b,0x56,0x08,0xe9,0x16,0xff,0xff,0xff,0x8b,0x4e,0x08,0xe9,0x53,0xff,0xff,0xff,0x48,0x83,0xbd,0xd0,0xfe,0xff,0xff,0x00,0x74,0x19,0x48,0x8b,0x8d,0xd0,0xfe,0xff,0xff,0x49,0xbb,0x38,0x00,0x03,0x65,0xfb,0x7f,0x00,0x00,0x39,0x09,0xff,0x15,0x16,0x75,0xec,0xff,0x48,0x8b,0xc6,0x48,0x8d,0x65,0xd8,0x5b,0x5e,0x5f,0x41,0x5e,0x41,0x5f,0x5d,0xc3,0x55,0x41,0x57,0x41,0x56,0x57,0x56,0x53,0x48,0x83,0xec,0x38,0xc5,0xf8,0x77,0x48,0x8b,0x69,0x28,0x48,0x89,0x6c,0x24,0x28,0x48,0x8d,0xad,0x60,0x01,0x00,0x00,0x48,0x83,0xbd,0xd0,0xfe,0xff,0xff,0x00,0x74,0x19,0x48,0x8b,0x8d,0xd0,0xfe,0xff,0xff,0x49,0xbb,0x38,0x00,0x03,0x65,0xfb,0x7f,0x00,0x00,0x39,0x09,0xff,0x15,0xc4,0x74,0xec,0xff,0x90,0x48,0x83,0xc4,0x38,0x5b,0x5e,0x5f,0x41,0x5e,0x41,0x5f,0x5d,0xc3};

        public static ReadOnlySpan<byte> runヽᐤIWfRuntimeㆍIndexᐸPartIdᛁbyteᐳㆍCaptureWorkflowOptionsᕀ8uᐤ  =>  new byte[55]{0x57,0x56,0x48,0x83,0xec,0x28,0x48,0x8b,0xfa,0x41,0x8b,0xf0,0x48,0x8b,0xd1,0x48,0xb9,0x40,0x49,0x3a,0x65,0xfb,0x7f,0x00,0x00,0xe8,0x62,0x89,0xf6,0xff,0x48,0x8b,0xc8,0x44,0x0f,0xb6,0xc6,0x48,0x8b,0xd7,0x39,0x09,0xe8,0x61,0xcf,0xf6,0xff,0x90,0x48,0x83,0xc4,0x28,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> runヽᐤIWfRuntimeㆍIndexᐸApiHostUriᐳㆍCaptureWorkflowOptionsᕀ8uᐤ  =>  new byte[96]{0x57,0x56,0x48,0x83,0xec,0x38,0x33,0xc0,0x48,0x89,0x44,0x24,0x28,0x48,0x8b,0xfa,0x41,0x8b,0xf0,0x48,0x8b,0xd1,0x48,0xb9,0x40,0x49,0x3a,0x65,0xfb,0x7f,0x00,0x00,0xe8,0x0b,0x89,0xf6,0xff,0x48,0x8b,0xc8,0x48,0x85,0xff,0x75,0x07,0x33,0xd2,0x45,0x33,0xc0,0xeb,0x08,0x48,0x8d,0x57,0x10,0x44,0x8b,0x47,0x08,0x48,0x8d,0x44,0x24,0x28,0x48,0x89,0x10,0x44,0x89,0x40,0x08,0x48,0x8d,0x54,0x24,0x28,0x44,0x0f,0xb6,0xc6,0x39,0x09,0xe8,0xa8,0xde,0x2c,0xfd,0x90,0x48,0x83,0xc4,0x38,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> exchangeヽᐤarray_8uᐤ  =>  new byte[84]{0x57,0x56,0x53,0x48,0x83,0xec,0x10,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x04,0x24,0x48,0x8b,0xd9,0x48,0x85,0xd2,0x75,0x06,0x33,0xc0,0x33,0xc9,0xeb,0x07,0x48,0x8d,0x42,0x10,0x8b,0x4a,0x08,0x48,0x8d,0x14,0x24,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x02,0x48,0x8d,0x14,0x24,0x48,0x89,0x02,0x89,0x4a,0x08,0x48,0x8b,0xfb,0x48,0x8d,0x34,0x24,0xe8,0x49,0xfd,0xdf,0x5c,0x48,0xa5,0x48,0x8b,0xc3,0x48,0x83,0xc4,0x10,0x5b,0x5e,0x5f,0xc3};

    }
}