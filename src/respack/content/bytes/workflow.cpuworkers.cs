﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2021-12-01 21:34:44 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class workflow_cpuworkers
    {
        public static ReadOnlySpan<byte> formatヽᐤCpuCycleInfoᕀinᐤ  =>  new byte[266]{0x57,0x56,0x48,0x83,0xec,0x28,0x48,0x8b,0xf1,0x48,0xb9,0xc8,0x52,0xd4,0x76,0xfd,0x7f,0x00,0x00,0xba,0x05,0x00,0x00,0x00,0xe8,0xf3,0x3e,0x5a,0x5c,0x48,0x8b,0xf8,0x48,0xb9,0xe0,0x96,0xd4,0x76,0xfd,0x7f,0x00,0x00,0xe8,0x51,0x3d,0x5a,0x5c,0x44,0x8b,0x46,0x04,0x44,0x89,0x40,0x08,0x4c,0x8b,0xc0,0x48,0x8b,0xcf,0x33,0xd2,0xe8,0x9c,0x2f,0x5a,0x5c,0x48,0xb9,0xe0,0x96,0xd4,0x76,0xfd,0x7f,0x00,0x00,0xe8,0x2d,0x3d,0x5a,0x5c,0x44,0x8b,0x06,0x44,0x89,0x40,0x08,0x4c,0x8b,0xc0,0x48,0x8b,0xcf,0xba,0x01,0x00,0x00,0x00,0xe8,0x76,0x2f,0x5a,0x5c,0x48,0xb9,0x80,0xa6,0xd4,0x76,0xfd,0x7f,0x00,0x00,0xe8,0x07,0x3d,0x5a,0x5c,0x4c,0x8b,0x46,0x08,0x4c,0x89,0x40,0x08,0x4c,0x8b,0xc0,0x48,0x8b,0xcf,0xba,0x02,0x00,0x00,0x00,0xe8,0x4f,0x2f,0x5a,0x5c,0x48,0xb9,0x80,0xa6,0xd4,0x76,0xfd,0x7f,0x00,0x00,0xe8,0xe0,0x3c,0x5a,0x5c,0x4c,0x8b,0x46,0x10,0x4c,0x89,0x40,0x08,0x4c,0x8b,0xc0,0x48,0x8b,0xcf,0xba,0x03,0x00,0x00,0x00,0xe8,0x28,0x2f,0x5a,0x5c,0x48,0xb9,0x80,0xa6,0xd4,0x76,0xfd,0x7f,0x00,0x00,0xe8,0xb9,0x3c,0x5a,0x5c,0x4c,0x8b,0x46,0x18,0x4c,0x89,0x40,0x08,0x4c,0x8b,0xc0,0x48,0x8b,0xcf,0xba,0x04,0x00,0x00,0x00,0xe8,0x01,0x2f,0x5a,0x5c,0x48,0xb9,0x40,0x1d,0x5e,0x73,0xd5,0x01,0x00,0x00,0x48,0x8b,0x09,0x48,0x8b,0xd7,0x48,0xb8,0xf0,0xd6,0xf5,0xcf,0xfd,0x7f,0x00,0x00,0x48,0x83,0xc4,0x28,0x5e,0x5f,0x48,0xff,0xe0,0x00,0x00,0x19,0x06,0x03,0x00,0x06,0x42};

        public static ReadOnlySpan<byte> threadヽᐤ32uᐤ  =>  new byte[18]{0x0f,0x1f,0x44,0x00,0x00,0x48,0xb8,0xe0,0x99,0xfa,0x77,0xfd,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static ReadOnlySpan<byte> delayヽᐤTimeSpanᐤ  =>  new byte[85]{0x48,0x83,0xec,0x48,0x33,0xc0,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x48,0x89,0x44,0x24,0x38,0x48,0x89,0x44,0x24,0x40,0x33,0xc0,0x48,0x89,0x44,0x24,0x30,0x48,0x8d,0x44,0x24,0x38,0x48,0x89,0x08,0xc7,0x44,0x24,0x28,0xff,0xff,0xff,0xff,0x48,0x8d,0x4c,0x24,0x28,0xe8,0xbd,0xfb,0xff,0xff,0x48,0x8b,0x44,0x24,0x30,0x48,0x85,0xc0,0x75,0x0a,0x48,0x8d,0x4c,0x24,0x30,0xe8,0x59,0xcf,0xf9,0xfd,0x90,0x48,0x83,0xc4,0x48,0xc3};

        public static ReadOnlySpan<byte> advanceヽᐤᐤ  =>  new byte[28]{0x0f,0x1f,0x44,0x00,0x00,0x48,0xb8,0x00,0xd8,0xec,0x76,0xfd,0x7f,0x00,0x00,0xba,0x01,0x00,0x00,0x00,0xf0,0x0f,0xc1,0x10,0x8d,0x42,0x01,0xc3};

        public static ReadOnlySpan<byte> identifyヽᐤ32uㆍ32uᐤ  =>  new byte[17]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0xc1,0x8b,0xd2,0x48,0xc1,0xe2,0x20,0x48,0x0b,0xc2,0xc3};

        public static ReadOnlySpan<byte> nameヽᐤ32uㆍ32uᐤ  =>  new byte[145]{0x57,0x56,0x53,0x48,0x83,0xec,0x40,0x33,0xc0,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x48,0x89,0x44,0x24,0x38,0x8b,0xf1,0x8b,0xfa,0x48,0xb9,0xe0,0x96,0xd4,0x76,0xfd,0x7f,0x00,0x00,0xe8,0x30,0x37,0x5a,0x5c,0x48,0x8b,0xd8,0x89,0x73,0x08,0x48,0xb9,0xe0,0x96,0xd4,0x76,0xfd,0x7f,0x00,0x00,0xe8,0x1b,0x37,0x5a,0x5c,0x89,0x78,0x08,0x45,0x33,0xc0,0x48,0xba,0x90,0x13,0x4d,0x73,0xd5,0x01,0x00,0x00,0x48,0x8b,0x12,0x48,0xb9,0xf0,0x94,0x4d,0x73,0xd5,0x01,0x00,0x00,0x48,0x8b,0x09,0x4c,0x8d,0x4c,0x24,0x20,0x49,0x89,0x19,0x49,0x89,0x41,0x08,0x4d,0x89,0x41,0x10,0x49,0x89,0x51,0x18,0x4c,0x8d,0x44,0x24,0x20,0x48,0x8b,0xd1,0x33,0xc9,0xe8,0x38,0x21,0xc2,0x55,0x90,0x48,0x83,0xc4,0x40,0x5b,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> exampleヽᐤ32uㆍ64uㆍ64uᐤ  =>  new byte[332]{0x55,0x41,0x57,0x41,0x56,0x41,0x54,0x57,0x56,0x53,0x48,0x83,0xec,0x70,0x48,0x8d,0xac,0x24,0xa0,0x00,0x00,0x00,0x33,0xc0,0x48,0x89,0x45,0xa8,0x48,0x89,0x45,0xb0,0x48,0x89,0x45,0xb8,0x48,0x89,0x45,0xc0,0x8b,0xf1,0x49,0x8b,0xf8,0x48,0xb9,0xd8,0x05,0x72,0x7a,0xfd,0x7f,0x00,0x00,0xe8,0x74,0x36,0x5a,0x5c,0x48,0x8b,0xd8,0x48,0x8d,0x4b,0x08,0x48,0x8b,0xd3,0xe8,0xa5,0x27,0x5a,0x5c,0x48,0xb9,0xd0,0x07,0x11,0x7a,0xfd,0x7f,0x00,0x00,0x48,0x89,0x4b,0x18,0x48,0xb9,0x40,0x2b,0x2c,0x78,0xfd,0x7f,0x00,0x00,0x48,0x89,0x4b,0x20,0x33,0xc9,0x48,0x89,0x4d,0xc8,0x89,0x4c,0x24,0x20,0xc7,0x44,0x24,0x28,0x0a,0x00,0x00,0x00,0x48,0x8d,0x4d,0xc8,0x33,0xd2,0x45,0x33,0xc0,0x45,0x33,0xc9,0xe8,0x6e,0xcf,0xf9,0xfd,0x4c,0x8b,0x75,0xc8,0x48,0xb9,0x00,0xd8,0xec,0x76,0xfd,0x7f,0x00,0x00,0xb8,0x01,0x00,0x00,0x00,0x44,0x8b,0xf8,0xf0,0x44,0x0f,0xc1,0x39,0x41,0xff,0xc7,0x48,0xb9,0xe0,0x96,0xd4,0x76,0xfd,0x7f,0x00,0x00,0xe8,0xf9,0x35,0x5a,0x5c,0x4c,0x8b,0xe0,0x41,0x89,0x74,0x24,0x08,0x48,0xb9,0xe0,0x96,0xd4,0x76,0xfd,0x7f,0x00,0x00,0xe8,0xe2,0x35,0x5a,0x5c,0x44,0x89,0x78,0x08,0x45,0x33,0xc0,0x48,0xba,0x90,0x13,0x4d,0x73,0xd5,0x01,0x00,0x00,0x48,0x8b,0x12,0x48,0xb9,0xf0,0x94,0x4d,0x73,0xd5,0x01,0x00,0x00,0x48,0x8b,0x09,0x4c,0x8d,0x4d,0xa8,0x4d,0x89,0x21,0x49,0x89,0x41,0x08,0x4d,0x89,0x41,0x10,0x49,0x89,0x51,0x18,0x4c,0x8d,0x45,0xa8,0x48,0x8b,0xd1,0x33,0xc9,0xe8,0x00,0x20,0xc2,0x55,0x48,0xc7,0x44,0x24,0x30,0x00,0x00,0x01,0x00,0x48,0xc7,0x44,0x24,0x38,0xff,0xff,0xff,0xff,0x48,0x89,0x44,0x24,0x28,0x41,0x8b,0xd7,0x4c,0x8b,0xc3,0x4c,0x8b,0xcf,0x4c,0x89,0x74,0x24,0x20,0x8b,0xce,0xe8,0x5c,0xf9,0xff,0xff,0x90,0x48,0x8d,0x65,0xd0,0x5b,0x5e,0x5f,0x41,0x5c,0x41,0x5e,0x41,0x5f,0x5d,0xc3};

        public static ReadOnlySpan<byte> describeヽgᐸ8uᐳᐤCpuWorkerᐸbyteᐳᕀinㆍCpuCycleInfoᕀrefᐤ  =>  new byte[107]{0x57,0x56,0x48,0x83,0xec,0x28,0xc5,0xf8,0x77,0x48,0x8b,0xf2,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x06,0xc5,0xfa,0x7f,0x46,0x10,0x48,0x8b,0x01,0x8b,0x40,0x3c,0x89,0x46,0x04,0x48,0x8b,0x01,0x8b,0x40,0x38,0x89,0x06,0x48,0x8b,0x01,0x48,0x8b,0x40,0x28,0x48,0x89,0x46,0x08,0x48,0x8b,0x01,0x48,0x8b,0x40,0x30,0x48,0x89,0x46,0x10,0x48,0x8b,0x09,0x48,0x8b,0x49,0x18,0x48,0x85,0xc9,0x75,0x04,0x33,0xff,0xeb,0x0d,0xe8,0xfb,0xb7,0x9f,0xfe,0x48,0x8b,0x78,0x20,0x48,0x03,0x78,0x18,0x48,0x89,0x7e,0x18,0x48,0x8b,0xc6,0x48,0x83,0xc4,0x28,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> describeヽgᐸ16uᐳᐤCpuWorkerᐸushortᐳᕀinㆍCpuCycleInfoᕀrefᐤ  =>  new byte[107]{0x57,0x56,0x48,0x83,0xec,0x28,0xc5,0xf8,0x77,0x48,0x8b,0xf2,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x06,0xc5,0xfa,0x7f,0x46,0x10,0x48,0x8b,0x01,0x8b,0x40,0x3c,0x89,0x46,0x04,0x48,0x8b,0x01,0x8b,0x40,0x38,0x89,0x06,0x48,0x8b,0x01,0x48,0x8b,0x40,0x28,0x48,0x89,0x46,0x08,0x48,0x8b,0x01,0x48,0x8b,0x40,0x30,0x48,0x89,0x46,0x10,0x48,0x8b,0x09,0x48,0x8b,0x49,0x18,0x48,0x85,0xc9,0x75,0x04,0x33,0xff,0xeb,0x0d,0xe8,0x6b,0xb7,0x9f,0xfe,0x48,0x8b,0x78,0x20,0x48,0x03,0x78,0x18,0x48,0x89,0x7e,0x18,0x48,0x8b,0xc6,0x48,0x83,0xc4,0x28,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> describeヽgᐸ32uᐳᐤCpuWorkerᐸuintᐳᕀinㆍCpuCycleInfoᕀrefᐤ  =>  new byte[107]{0x57,0x56,0x48,0x83,0xec,0x28,0xc5,0xf8,0x77,0x48,0x8b,0xf2,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x06,0xc5,0xfa,0x7f,0x46,0x10,0x48,0x8b,0x01,0x8b,0x40,0x3c,0x89,0x46,0x04,0x48,0x8b,0x01,0x8b,0x40,0x38,0x89,0x06,0x48,0x8b,0x01,0x48,0x8b,0x40,0x28,0x48,0x89,0x46,0x08,0x48,0x8b,0x01,0x48,0x8b,0x40,0x30,0x48,0x89,0x46,0x10,0x48,0x8b,0x09,0x48,0x8b,0x49,0x18,0x48,0x85,0xc9,0x75,0x04,0x33,0xff,0xeb,0x0d,0xe8,0xdb,0xb6,0x9f,0xfe,0x48,0x8b,0x78,0x20,0x48,0x03,0x78,0x18,0x48,0x89,0x7e,0x18,0x48,0x8b,0xc6,0x48,0x83,0xc4,0x28,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> describeヽgᐸ64uᐳᐤCpuWorkerᐸulongᐳᕀinㆍCpuCycleInfoᕀrefᐤ  =>  new byte[107]{0x57,0x56,0x48,0x83,0xec,0x28,0xc5,0xf8,0x77,0x48,0x8b,0xf2,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x06,0xc5,0xfa,0x7f,0x46,0x10,0x48,0x8b,0x01,0x8b,0x40,0x44,0x89,0x46,0x04,0x48,0x8b,0x01,0x8b,0x40,0x40,0x89,0x06,0x48,0x8b,0x01,0x48,0x8b,0x40,0x28,0x48,0x89,0x46,0x08,0x48,0x8b,0x01,0x48,0x8b,0x40,0x30,0x48,0x89,0x46,0x10,0x48,0x8b,0x09,0x48,0x8b,0x49,0x18,0x48,0x85,0xc9,0x75,0x04,0x33,0xff,0xeb,0x0d,0xe8,0x4b,0xb6,0x9f,0xfe,0x48,0x8b,0x78,0x20,0x48,0x03,0x78,0x18,0x48,0x89,0x7e,0x18,0x48,0x8b,0xc6,0x48,0x83,0xc4,0x28,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> createヽgᐸ8uᐳᐤ32uㆍ32uㆍFuncᐸbyteㆍbyteᐳㆍ8uㆍTimeSpanㆍstringㆍ64uㆍ64uᐤ  =>  new byte[276]{0x41,0x57,0x41,0x56,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x28,0xc5,0xf8,0x77,0x8b,0xf9,0x8b,0xda,0x49,0x8b,0xf0,0x41,0x8b,0xe9,0x48,0xb9,0x08,0x1b,0x7d,0x7a,0xfd,0x7f,0x00,0x00,0xe8,0xd8,0x32,0x5a,0x5c,0x4c,0x8b,0xf0,0x4c,0x8b,0xbc,0x24,0x80,0x00,0x00,0x00,0x41,0x89,0x7e,0x38,0x33,0xd2,0x49,0x89,0x56,0x18,0x41,0x89,0x5e,0x3c,0x49,0x8d,0x4e,0x08,0x48,0x8b,0xd6,0xe8,0xf3,0x23,0x5a,0x5c,0x41,0x88,0x6e,0x40,0x4d,0x89,0x7e,0x48,0x48,0x8b,0xb4,0x24,0x98,0x00,0x00,0x00,0x49,0x89,0x76,0x28,0x33,0xc9,0x49,0x89,0x4e,0x30,0x48,0x8b,0xb4,0x24,0x90,0x00,0x00,0x00,0x49,0x89,0x76,0x20,0x49,0x8d,0x4e,0x50,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x01,0xc5,0xfa,0x7f,0x41,0x10,0x33,0xc9,0x49,0x89,0x4e,0x10,0x48,0xb9,0x10,0x24,0x7d,0x7a,0xfd,0x7f,0x00,0x00,0xe8,0x67,0x32,0x5a,0x5c,0x48,0x8b,0xf0,0x48,0x8d,0x4e,0x08,0x49,0x8b,0xd6,0xe8,0x98,0x23,0x5a,0x5c,0x48,0xb9,0x58,0x3c,0x30,0x7a,0xfd,0x7f,0x00,0x00,0x48,0x89,0x4e,0x18,0x48,0xb9,0xa0,0x14,0xe0,0x76,0xfd,0x7f,0x00,0x00,0xe8,0x6b,0x91,0x4b,0x5c,0x48,0x8b,0xf8,0x48,0x8b,0xcf,0x48,0x8b,0xd6,0xe8,0xfd,0x0c,0xa7,0xfc,0x48,0x8b,0xcf,0xba,0x01,0x00,0x00,0x00,0xe8,0xe0,0x18,0x59,0x5c,0x48,0x8b,0xcf,0x48,0x8b,0x94,0x24,0x88,0x00,0x00,0x00,0xe8,0x60,0x0d,0xa7,0xfc,0x49,0x8d,0x4e,0x10,0x48,0x8b,0xd7,0xe8,0x44,0x23,0x5a,0x5c,0x48,0x8b,0xcf,0xe8,0x4c,0x0b,0xa7,0xfc,0x49,0x8b,0xc6,0x48,0x83,0xc4,0x28,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0x41,0x5f,0xc3};

        public static ReadOnlySpan<byte> createヽgᐸ16uᐳᐤ32uㆍ32uㆍFuncᐸushortㆍushortᐳㆍ16uㆍTimeSpanㆍstringㆍ64uㆍ64uᐤ  =>  new byte[277]{0x41,0x57,0x41,0x56,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x28,0xc5,0xf8,0x77,0x8b,0xf9,0x8b,0xda,0x49,0x8b,0xf0,0x41,0x8b,0xe9,0x48,0xb9,0xf0,0x1e,0x7d,0x7a,0xfd,0x7f,0x00,0x00,0xe8,0x98,0x31,0x5a,0x5c,0x4c,0x8b,0xf0,0x4c,0x8b,0xbc,0x24,0x80,0x00,0x00,0x00,0x41,0x89,0x7e,0x38,0x33,0xd2,0x49,0x89,0x56,0x18,0x41,0x89,0x5e,0x3c,0x49,0x8d,0x4e,0x08,0x48,0x8b,0xd6,0xe8,0xb3,0x22,0x5a,0x5c,0x66,0x41,0x89,0x6e,0x40,0x4d,0x89,0x7e,0x48,0x48,0x8b,0xb4,0x24,0x98,0x00,0x00,0x00,0x49,0x89,0x76,0x28,0x33,0xc9,0x49,0x89,0x4e,0x30,0x48,0x8b,0xb4,0x24,0x90,0x00,0x00,0x00,0x49,0x89,0x76,0x20,0x49,0x8d,0x4e,0x50,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x01,0xc5,0xfa,0x7f,0x41,0x10,0x33,0xc9,0x49,0x89,0x4e,0x10,0x48,0xb9,0x10,0x24,0x7d,0x7a,0xfd,0x7f,0x00,0x00,0xe8,0x26,0x31,0x5a,0x5c,0x48,0x8b,0xf0,0x48,0x8d,0x4e,0x08,0x49,0x8b,0xd6,0xe8,0x57,0x22,0x5a,0x5c,0x48,0xb9,0x18,0x3d,0x30,0x7a,0xfd,0x7f,0x00,0x00,0x48,0x89,0x4e,0x18,0x48,0xb9,0xa0,0x14,0xe0,0x76,0xfd,0x7f,0x00,0x00,0xe8,0x2a,0x90,0x4b,0x5c,0x48,0x8b,0xf8,0x48,0x8b,0xcf,0x48,0x8b,0xd6,0xe8,0xbc,0x0b,0xa7,0xfc,0x48,0x8b,0xcf,0xba,0x01,0x00,0x00,0x00,0xe8,0x9f,0x17,0x59,0x5c,0x48,0x8b,0xcf,0x48,0x8b,0x94,0x24,0x88,0x00,0x00,0x00,0xe8,0x1f,0x0c,0xa7,0xfc,0x49,0x8d,0x4e,0x10,0x48,0x8b,0xd7,0xe8,0x03,0x22,0x5a,0x5c,0x48,0x8b,0xcf,0xe8,0x0b,0x0a,0xa7,0xfc,0x49,0x8b,0xc6,0x48,0x83,0xc4,0x28,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0x41,0x5f,0xc3};

        public static ReadOnlySpan<byte> createヽgᐸ32uᐳᐤ32uㆍ32uㆍFuncᐸuintㆍuintᐳㆍ32uㆍTimeSpanㆍstringㆍ64uㆍ64uᐤ  =>  new byte[276]{0x41,0x57,0x41,0x56,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x28,0xc5,0xf8,0x77,0x8b,0xf9,0x8b,0xda,0x49,0x8b,0xf0,0x41,0x8b,0xe9,0x48,0xb9,0xa8,0x21,0x7d,0x7a,0xfd,0x7f,0x00,0x00,0xe8,0x58,0x30,0x5a,0x5c,0x4c,0x8b,0xf0,0x4c,0x8b,0xbc,0x24,0x80,0x00,0x00,0x00,0x41,0x89,0x7e,0x38,0x33,0xd2,0x49,0x89,0x56,0x18,0x41,0x89,0x5e,0x3c,0x49,0x8d,0x4e,0x08,0x48,0x8b,0xd6,0xe8,0x73,0x21,0x5a,0x5c,0x41,0x89,0x6e,0x40,0x4d,0x89,0x7e,0x48,0x48,0x8b,0xb4,0x24,0x98,0x00,0x00,0x00,0x49,0x89,0x76,0x28,0x33,0xc9,0x49,0x89,0x4e,0x30,0x48,0x8b,0xb4,0x24,0x90,0x00,0x00,0x00,0x49,0x89,0x76,0x20,0x49,0x8d,0x4e,0x50,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x01,0xc5,0xfa,0x7f,0x41,0x10,0x33,0xc9,0x49,0x89,0x4e,0x10,0x48,0xb9,0x10,0x24,0x7d,0x7a,0xfd,0x7f,0x00,0x00,0xe8,0xe7,0x2f,0x5a,0x5c,0x48,0x8b,0xf0,0x48,0x8d,0x4e,0x08,0x49,0x8b,0xd6,0xe8,0x18,0x21,0x5a,0x5c,0x48,0xb9,0xa0,0x3d,0x30,0x7a,0xfd,0x7f,0x00,0x00,0x48,0x89,0x4e,0x18,0x48,0xb9,0xa0,0x14,0xe0,0x76,0xfd,0x7f,0x00,0x00,0xe8,0xeb,0x8e,0x4b,0x5c,0x48,0x8b,0xf8,0x48,0x8b,0xcf,0x48,0x8b,0xd6,0xe8,0x7d,0x0a,0xa7,0xfc,0x48,0x8b,0xcf,0xba,0x01,0x00,0x00,0x00,0xe8,0x60,0x16,0x59,0x5c,0x48,0x8b,0xcf,0x48,0x8b,0x94,0x24,0x88,0x00,0x00,0x00,0xe8,0xe0,0x0a,0xa7,0xfc,0x49,0x8d,0x4e,0x10,0x48,0x8b,0xd7,0xe8,0xc4,0x20,0x5a,0x5c,0x48,0x8b,0xcf,0xe8,0xcc,0x08,0xa7,0xfc,0x49,0x8b,0xc6,0x48,0x83,0xc4,0x28,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0x41,0x5f,0xc3};

        public static ReadOnlySpan<byte> createヽgᐸ64uᐳᐤ32uㆍ32uㆍFuncᐸulongㆍulongᐳㆍ64uㆍTimeSpanㆍstringㆍ64uㆍ64uᐤ  =>  new byte[276]{0x41,0x57,0x41,0x56,0x57,0x56,0x55,0x53,0x48,0x83,0xec,0x28,0xc5,0xf8,0x77,0x8b,0xf9,0x8b,0xda,0x49,0x8b,0xf0,0x49,0x8b,0xe9,0x48,0xb9,0x10,0xab,0x40,0x79,0xfd,0x7f,0x00,0x00,0xe8,0x18,0x2f,0x5a,0x5c,0x4c,0x8b,0xf0,0x4c,0x8b,0xbc,0x24,0x80,0x00,0x00,0x00,0x41,0x89,0x7e,0x40,0x33,0xd2,0x49,0x89,0x56,0x18,0x41,0x89,0x5e,0x44,0x49,0x8d,0x4e,0x08,0x48,0x8b,0xd6,0xe8,0x33,0x20,0x5a,0x5c,0x49,0x89,0x6e,0x38,0x4d,0x89,0x7e,0x48,0x48,0x8b,0xb4,0x24,0x98,0x00,0x00,0x00,0x49,0x89,0x76,0x28,0x33,0xc9,0x49,0x89,0x4e,0x30,0x48,0x8b,0xb4,0x24,0x90,0x00,0x00,0x00,0x49,0x89,0x76,0x20,0x49,0x8d,0x4e,0x50,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x01,0xc5,0xfa,0x7f,0x41,0x10,0x33,0xc9,0x49,0x89,0x4e,0x10,0x48,0xb9,0x10,0x24,0x7d,0x7a,0xfd,0x7f,0x00,0x00,0xe8,0xa7,0x2e,0x5a,0x5c,0x48,0x8b,0xf0,0x48,0x8d,0x4e,0x08,0x49,0x8b,0xd6,0xe8,0xd8,0x1f,0x5a,0x5c,0x48,0xb9,0x60,0x24,0xdb,0x78,0xfd,0x7f,0x00,0x00,0x48,0x89,0x4e,0x18,0x48,0xb9,0xa0,0x14,0xe0,0x76,0xfd,0x7f,0x00,0x00,0xe8,0xab,0x8d,0x4b,0x5c,0x48,0x8b,0xf8,0x48,0x8b,0xcf,0x48,0x8b,0xd6,0xe8,0x3d,0x09,0xa7,0xfc,0x48,0x8b,0xcf,0xba,0x01,0x00,0x00,0x00,0xe8,0x20,0x15,0x59,0x5c,0x48,0x8b,0xcf,0x48,0x8b,0x94,0x24,0x88,0x00,0x00,0x00,0xe8,0xa0,0x09,0xa7,0xfc,0x49,0x8d,0x4e,0x10,0x48,0x8b,0xd7,0xe8,0x84,0x1f,0x5a,0x5c,0x48,0x8b,0xcf,0xe8,0x8c,0x07,0xa7,0xfc,0x49,0x8b,0xc6,0x48,0x83,0xc4,0x28,0x5b,0x5d,0x5e,0x5f,0x41,0x5e,0x41,0x5f,0xc3};

    }
}
