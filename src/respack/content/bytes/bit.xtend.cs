﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
// Generated   : 2021-12-01 21:34:44 -06:00
//-----------------------------------------------------------------------------
namespace Z0.ByteCode
{
    using System;
    using System.Runtime.CompilerServices;


    public static class bit_xtend
    {
        public static ReadOnlySpan<byte> OnNoneヽᐤbitㆍActionᐤ  =>  new byte[40]{0x48,0x83,0xec,0x28,0x90,0x84,0xc9,0x0f,0x94,0xc1,0x0f,0xb6,0xc9,0x0f,0xb6,0xc9,0x88,0x4c,0x24,0x20,0x80,0x7c,0x24,0x20,0x00,0x74,0x07,0x48,0x8b,0x4a,0x08,0xff,0x52,0x18,0x90,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> OnNoneヽᐤboolㆍActionᐤ  =>  new byte[21]{0x0f,0x1f,0x44,0x00,0x00,0x84,0xc9,0x75,0x0b,0x48,0x8b,0x4a,0x08,0x48,0x8b,0x42,0x18,0x48,0xff,0xe0,0xc3};

        public static ReadOnlySpan<byte> OnSomeヽᐤboolㆍActionᐤ  =>  new byte[21]{0x0f,0x1f,0x44,0x00,0x00,0x84,0xc9,0x74,0x0b,0x48,0x8b,0x4a,0x08,0x48,0x8b,0x42,0x18,0x48,0xff,0xe0,0xc3};

        public static ReadOnlySpan<byte> OnSomeヽᐤbitㆍActionᐤ  =>  new byte[22]{0x48,0x83,0xec,0x28,0x90,0x84,0xc9,0x74,0x07,0x48,0x8b,0x4a,0x08,0xff,0x52,0x18,0x90,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> FormatPackedヽᐤrspanbitᐤ  =>  new byte[140]{0x56,0x48,0x83,0xec,0x40,0x33,0xc0,0x48,0x89,0x44,0x24,0x30,0x48,0x89,0x44,0x24,0x38,0x48,0x89,0x44,0x24,0x20,0x48,0x89,0x44,0x24,0x28,0x48,0x8b,0xf1,0x8b,0x56,0x08,0x48,0x8d,0x4c,0x24,0x30,0xe8,0x35,0xb3,0xf7,0xff,0x48,0x8b,0x16,0x8b,0x4e,0x08,0x48,0x8b,0x44,0x24,0x30,0x45,0x33,0xc0,0x85,0xc9,0x7e,0x28,0x4d,0x63,0xc8,0x4e,0x8d,0x14,0x48,0x42,0x80,0x3c,0x0a,0x00,0x75,0x08,0x41,0xb9,0x30,0x00,0x00,0x00,0xeb,0x06,0x41,0xb9,0x31,0x00,0x00,0x00,0x66,0x45,0x89,0x0a,0x41,0xff,0xc0,0x44,0x3b,0xc1,0x7c,0xd8,0x48,0x8b,0x54,0x24,0x30,0x8b,0x4c,0x24,0x38,0x48,0x8d,0x44,0x24,0x20,0x48,0x89,0x10,0x89,0x48,0x08,0x48,0x8d,0x54,0x24,0x20,0x33,0xc9,0xe8,0x43,0x7f,0xad,0xfc,0x90,0x48,0x83,0xc4,0x40,0x5e,0xc3};

        public static ReadOnlySpan<byte> FormatPackedヽᐤspanbitᐤ  =>  new byte[144]{0x57,0x56,0x48,0x83,0xec,0x48,0xc5,0xf8,0x77,0x33,0xc0,0x48,0x89,0x44,0x24,0x38,0x48,0x89,0x44,0x24,0x28,0x48,0x8b,0x31,0x8b,0x79,0x08,0x48,0x8d,0x4c,0x24,0x38,0xc5,0xf8,0x57,0xc0,0xc5,0xfa,0x7f,0x01,0x48,0x8d,0x4c,0x24,0x38,0x8b,0xd7,0xe8,0x8c,0xb2,0xf7,0xff,0x48,0x8b,0x54,0x24,0x38,0x33,0xc9,0x85,0xff,0x7e,0x29,0x48,0x63,0xc1,0x48,0x8d,0x04,0x42,0x4c,0x63,0xc1,0x42,0x80,0x3c,0x06,0x00,0x75,0x08,0x41,0xb8,0x30,0x00,0x00,0x00,0xeb,0x06,0x41,0xb8,0x31,0x00,0x00,0x00,0x66,0x44,0x89,0x00,0xff,0xc1,0x3b,0xcf,0x7c,0xd7,0x48,0x8b,0x54,0x24,0x38,0x8b,0x4c,0x24,0x40,0x48,0x8d,0x44,0x24,0x28,0x48,0x89,0x10,0x89,0x48,0x08,0x48,0x8d,0x54,0x24,0x28,0x33,0xc9,0xe8,0xa0,0x7e,0xad,0xfc,0x90,0x48,0x83,0xc4,0x48,0x5e,0x5f,0xc3};

        public static ReadOnlySpan<byte> RenderPackedヽᐤrspanbitㆍspancharᐤ  =>  new byte[62]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0x41,0x08,0x45,0x33,0xc0,0x85,0xc0,0x7e,0x2e,0x4c,0x8b,0x0a,0x4d,0x63,0xd0,0x4f,0x8d,0x0c,0x51,0x4c,0x8b,0x19,0x43,0x80,0x3c,0x13,0x00,0x75,0x08,0x41,0xba,0x30,0x00,0x00,0x00,0xeb,0x06,0x41,0xba,0x31,0x00,0x00,0x00,0x66,0x45,0x89,0x11,0x41,0xff,0xc0,0x44,0x3b,0xc0,0x7c,0xd2,0xc3};

        public static ReadOnlySpan<byte> RenderPackedヽᐤspanbitㆍspancharᐤ  =>  new byte[68]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0x01,0x8b,0x49,0x08,0x48,0x8b,0x12,0x44,0x8b,0xc1,0x45,0x33,0xc9,0x85,0xc9,0x7e,0x28,0x4d,0x63,0xd1,0x4e,0x8d,0x1c,0x52,0x42,0x80,0x3c,0x10,0x00,0x75,0x08,0x41,0xba,0x30,0x00,0x00,0x00,0xeb,0x06,0x41,0xba,0x31,0x00,0x00,0x00,0x66,0x45,0x89,0x13,0x41,0xff,0xc1,0x44,0x3b,0xc9,0x7c,0xd8,0x41,0x8b,0xc0,0xc3};

        public static ReadOnlySpan<byte> FormatGridBitsヽᐤspan8uㆍ32iㆍintㆍboolᐤ  =>  new byte[58]{0x48,0x83,0xec,0x38,0x33,0xc0,0x48,0x89,0x44,0x24,0x28,0x4c,0x89,0x44,0x24,0x50,0x4c,0x8b,0x01,0x8b,0x49,0x08,0x48,0x8d,0x44,0x24,0x28,0x4c,0x89,0x00,0x89,0x48,0x08,0x48,0x8d,0x4c,0x24,0x28,0x45,0x0f,0xb6,0xc9,0x4c,0x8b,0x44,0x24,0x50,0xe8,0x2c,0xb9,0x00,0xfe,0x90,0x48,0x83,0xc4,0x38,0xc3};

        public static ReadOnlySpan<byte> FormatGridBitsヽᐤrspan8uㆍ32iㆍintㆍboolᐤ  =>  new byte[30]{0x48,0x83,0xec,0x28,0x90,0x4c,0x89,0x44,0x24,0x40,0x45,0x0f,0xb6,0xc9,0x4c,0x8b,0x44,0x24,0x40,0xe8,0xf8,0xb8,0x00,0xfe,0x90,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> FormatGridBitsヽᐤspan8uㆍ32uㆍuintㆍboolᐤ  =>  new byte[109]{0x48,0x83,0xec,0x38,0x33,0xc0,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x4c,0x89,0x44,0x24,0x50,0x4c,0x8b,0x01,0x8b,0x49,0x08,0x48,0x8d,0x44,0x24,0x50,0x44,0x0f,0xb6,0x10,0x8b,0x40,0x04,0x45,0x84,0xd2,0x75,0x08,0x45,0x33,0xd2,0x45,0x33,0xdb,0xeb,0x09,0x44,0x8b,0xd8,0x41,0xba,0x01,0x00,0x00,0x00,0x48,0x8d,0x44,0x24,0x28,0x4c,0x89,0x00,0x89,0x48,0x08,0x48,0x8d,0x4c,0x24,0x20,0x44,0x88,0x11,0x44,0x89,0x59,0x04,0x48,0x8d,0x4c,0x24,0x28,0x4c,0x8b,0x44,0x24,0x20,0x45,0x0f,0xb6,0xc9,0xe8,0x69,0xb8,0x00,0xfe,0x90,0x48,0x83,0xc4,0x38,0xc3};

        public static ReadOnlySpan<byte> FormatGridBitsヽᐤrspan8uㆍ32uㆍuintㆍboolᐤ  =>  new byte[107]{0x48,0x83,0xec,0x38,0x33,0xc0,0x48,0x89,0x44,0x24,0x28,0x48,0x89,0x44,0x24,0x30,0x4c,0x89,0x44,0x24,0x50,0x4c,0x8d,0x44,0x24,0x50,0x41,0x0f,0xb6,0x00,0x45,0x8b,0x40,0x04,0x4c,0x8b,0x11,0x8b,0x49,0x08,0x84,0xc0,0x75,0x07,0x33,0xc0,0x45,0x33,0xdb,0xeb,0x08,0x45,0x8b,0xd8,0xb8,0x01,0x00,0x00,0x00,0x4c,0x8d,0x44,0x24,0x28,0x4d,0x89,0x10,0x41,0x89,0x48,0x08,0x48,0x8d,0x4c,0x24,0x20,0x88,0x01,0x44,0x89,0x59,0x04,0x48,0x8d,0x4c,0x24,0x28,0x4c,0x8b,0x44,0x24,0x20,0x45,0x0f,0xb6,0xc9,0xe8,0xdb,0xb7,0x00,0xfe,0x90,0x48,0x83,0xc4,0x38,0xc3};

        public static ReadOnlySpan<byte> IfSomeヽgᐸ8uᐳᐤboolㆍFuncᐸbyteᐳㆍ8uᐤ  =>  new byte[25]{0x0f,0x1f,0x44,0x00,0x00,0x84,0xc9,0x74,0x0b,0x48,0x8b,0x4a,0x08,0x48,0x8b,0x42,0x18,0x48,0xff,0xe0,0x41,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> IfSomeヽgᐸ16uᐳᐤboolㆍFuncᐸushortᐳㆍ16uᐤ  =>  new byte[25]{0x0f,0x1f,0x44,0x00,0x00,0x84,0xc9,0x74,0x0b,0x48,0x8b,0x4a,0x08,0x48,0x8b,0x42,0x18,0x48,0xff,0xe0,0x41,0x0f,0xb7,0xc0,0xc3};

        public static ReadOnlySpan<byte> IfSomeヽgᐸ32uᐳᐤboolㆍFuncᐸuintᐳㆍ32uᐤ  =>  new byte[21]{0x41,0x8b,0xc0,0x66,0x90,0x84,0xc9,0x74,0x0b,0x48,0x8b,0x4a,0x08,0x48,0x8b,0x42,0x18,0x48,0xff,0xe0,0xc3};

        public static ReadOnlySpan<byte> IfSomeヽgᐸ64uᐳᐤboolㆍFuncᐸulongᐳㆍ64uᐤ  =>  new byte[21]{0x49,0x8b,0xc0,0x66,0x90,0x84,0xc9,0x74,0x0b,0x48,0x8b,0x4a,0x08,0x48,0x8b,0x42,0x18,0x48,0xff,0xe0,0xc3};

        public static ReadOnlySpan<byte> IfSomeヽgᐸ8uᐳᐤbitㆍFuncᐸbyteᐳㆍ8uᐤ  =>  new byte[31]{0x48,0x83,0xec,0x28,0x90,0x84,0xc9,0x74,0x0d,0x48,0x8b,0x4a,0x08,0xff,0x52,0x18,0x90,0x48,0x83,0xc4,0x28,0xc3,0x41,0x0f,0xb6,0xc0,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> IfSomeヽgᐸ16uᐳᐤbitㆍFuncᐸushortᐳㆍ16uᐤ  =>  new byte[31]{0x48,0x83,0xec,0x28,0x90,0x84,0xc9,0x74,0x0d,0x48,0x8b,0x4a,0x08,0xff,0x52,0x18,0x90,0x48,0x83,0xc4,0x28,0xc3,0x41,0x0f,0xb7,0xc0,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> IfSomeヽgᐸ32uᐳᐤbitㆍFuncᐸuintᐳㆍ32uᐤ  =>  new byte[30]{0x48,0x83,0xec,0x28,0x90,0x41,0x8b,0xc0,0x84,0xc9,0x74,0x0d,0x48,0x8b,0x4a,0x08,0xff,0x52,0x18,0x90,0x48,0x83,0xc4,0x28,0xc3,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> IfSomeヽgᐸ64uᐳᐤbitㆍFuncᐸulongᐳㆍ64uᐤ  =>  new byte[30]{0x48,0x83,0xec,0x28,0x90,0x49,0x8b,0xc0,0x84,0xc9,0x74,0x0d,0x48,0x8b,0x4a,0x08,0xff,0x52,0x18,0x90,0x48,0x83,0xc4,0x28,0xc3,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> OnNoneヽgᐸ8uᐳᐤbyteㆍActionᐤ  =>  new byte[30]{0x48,0x83,0xec,0x28,0x90,0x48,0x89,0x4c,0x24,0x30,0x80,0x7c,0x24,0x30,0x00,0x75,0x07,0x48,0x8b,0x4a,0x08,0xff,0x52,0x18,0x90,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> OnNoneヽgᐸ16uᐳᐤushortㆍActionᐤ  =>  new byte[30]{0x48,0x83,0xec,0x28,0x90,0x48,0x89,0x4c,0x24,0x30,0x80,0x7c,0x24,0x30,0x00,0x75,0x07,0x48,0x8b,0x4a,0x08,0xff,0x52,0x18,0x90,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> OnNoneヽgᐸ32uᐳᐤuintㆍActionᐤ  =>  new byte[30]{0x48,0x83,0xec,0x28,0x90,0x48,0x89,0x4c,0x24,0x30,0x80,0x7c,0x24,0x30,0x00,0x75,0x07,0x48,0x8b,0x4a,0x08,0xff,0x52,0x18,0x90,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> OnNoneヽgᐸ64uᐳᐤulongㆍActionᐤ  =>  new byte[23]{0x48,0x83,0xec,0x28,0x90,0x80,0x39,0x00,0x75,0x07,0x48,0x8b,0x4a,0x08,0xff,0x52,0x18,0x90,0x48,0x83,0xc4,0x28,0xc3};

        public static ReadOnlySpan<byte> OnSomeヽgᐸ8uᐳᐤbyteㆍActionᐸbyteᐳᐤ  =>  new byte[218]{0x48,0x83,0xec,0x28,0x90,0x48,0x89,0x4c,0x24,0x30,0x0f,0xb6,0x4c,0x24,0x30,0x85,0xc9,0x74,0x1a,0x85,0xc9,0x74,0x1c,0x48,0x89,0x54,0x24,0x20,0x48,0x8b,0x4a,0x08,0x0f,0xb6,0x54,0x24,0x31,0x48,0x8b,0x44,0x24,0x20,0xff,0x50,0x18,0x90,0x48,0x83,0xc4,0x28,0xc3,0xe8,0xd0,0x64,0xaf,0xfc,0xcc,0x00,0x00,0x00,0x19,0x04,0x01,0x00,0x04,0x42,0x00,0x00,0x40,0x00,0x00,0x00,0x80,0x16,0x68,0x7a,0xfd,0x7f,0x00,0x00,0x48,0x83,0xec,0x28,0x90,0x48,0x89,0x4c,0x24,0x30,0x0f,0xb6,0x4c,0x24,0x30,0x85,0xc9,0x74,0x1a,0x85,0xc9,0x74,0x1c,0x48,0x89,0x54,0x24,0x20,0x48,0x8b,0x4a,0x08,0x0f,0xb7,0x54,0x24,0x32,0x48,0x8b,0x44,0x24,0x20,0xff,0x50,0x18,0x90,0x48,0x83,0xc4,0x28,0xc3,0xe8,0x80,0x64,0xaf,0xfc,0xcc,0x00,0x00,0x00,0x19,0x04,0x01,0x00,0x04,0x42,0x00,0x00,0x40,0x00,0x00,0x00,0xf8,0x16,0x68,0x7a,0xfd,0x7f,0x00,0x00,0x48,0x83,0xec,0x28,0x90,0x48,0x89,0x4c,0x24,0x30,0x0f,0xb6,0x4c,0x24,0x30,0x85,0xc9,0x74,0x19,0x85,0xc9,0x74,0x1b,0x48,0x89,0x54,0x24,0x20,0x48,0x8b,0x4a,0x08,0x8b,0x54,0x24,0x34,0x48,0x8b,0x44,0x24,0x20,0xff,0x50,0x18,0x90,0x48,0x83,0xc4,0x28,0xc3,0xe8,0x31,0x64,0xaf,0xfc,0xcc,0x19,0x04};

        public static ReadOnlySpan<byte> OnSomeヽgᐸ16uᐳᐤushortㆍActionᐸushortᐳᐤ  =>  new byte[138]{0x48,0x83,0xec,0x28,0x90,0x48,0x89,0x4c,0x24,0x30,0x0f,0xb6,0x4c,0x24,0x30,0x85,0xc9,0x74,0x1a,0x85,0xc9,0x74,0x1c,0x48,0x89,0x54,0x24,0x20,0x48,0x8b,0x4a,0x08,0x0f,0xb7,0x54,0x24,0x32,0x48,0x8b,0x44,0x24,0x20,0xff,0x50,0x18,0x90,0x48,0x83,0xc4,0x28,0xc3,0xe8,0x80,0x64,0xaf,0xfc,0xcc,0x00,0x00,0x00,0x19,0x04,0x01,0x00,0x04,0x42,0x00,0x00,0x40,0x00,0x00,0x00,0xf8,0x16,0x68,0x7a,0xfd,0x7f,0x00,0x00,0x48,0x83,0xec,0x28,0x90,0x48,0x89,0x4c,0x24,0x30,0x0f,0xb6,0x4c,0x24,0x30,0x85,0xc9,0x74,0x19,0x85,0xc9,0x74,0x1b,0x48,0x89,0x54,0x24,0x20,0x48,0x8b,0x4a,0x08,0x8b,0x54,0x24,0x34,0x48,0x8b,0x44,0x24,0x20,0xff,0x50,0x18,0x90,0x48,0x83,0xc4,0x28,0xc3,0xe8,0x31,0x64,0xaf,0xfc,0xcc,0x19,0x04};

        public static ReadOnlySpan<byte> OnSomeヽgᐸ32uᐳᐤuintㆍActionᐸuintᐳᐤ  =>  new byte[58]{0x48,0x83,0xec,0x28,0x90,0x48,0x89,0x4c,0x24,0x30,0x0f,0xb6,0x4c,0x24,0x30,0x85,0xc9,0x74,0x19,0x85,0xc9,0x74,0x1b,0x48,0x89,0x54,0x24,0x20,0x48,0x8b,0x4a,0x08,0x8b,0x54,0x24,0x34,0x48,0x8b,0x44,0x24,0x20,0xff,0x50,0x18,0x90,0x48,0x83,0xc4,0x28,0xc3,0xe8,0x31,0x64,0xaf,0xfc,0xcc,0x19,0x04};

        public static ReadOnlySpan<byte> OnSomeヽgᐸ64uᐳᐤulongㆍActionᐸulongᐳᐤ  =>  new byte[54]{0x48,0x83,0xec,0x28,0x90,0x0f,0xb6,0x01,0x4c,0x8b,0x41,0x08,0x84,0xc0,0x74,0x18,0x84,0xc0,0x74,0x1a,0x48,0x89,0x54,0x24,0x20,0x48,0x8b,0x4a,0x08,0x49,0x8b,0xd0,0x48,0x8b,0x44,0x24,0x20,0xff,0x50,0x18,0x90,0x48,0x83,0xc4,0x28,0xc3,0xe8,0xe5,0x63,0xaf,0xfc,0xcc,0x19,0x04};

    }
}
