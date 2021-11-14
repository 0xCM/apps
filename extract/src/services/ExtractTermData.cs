//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public readonly struct ExtractTermData
    {
        const byte SBB = 0x19;

        const byte RET = 0xc3;

        const byte INT3 = 0xcc;

        // cc cc cc
        public static ReadOnlySpan<byte> Term3A => new byte[3]{INT3, INT3, INT3};

        public const sbyte Term3AModifier = -3;

        // cc 00 19
        public static ReadOnlySpan<byte> Term3B => new byte[3]{INT3, 0, SBB};

        public const sbyte Term3BModifier = -3;

        //c3 00 00 19
        public static ReadOnlySpan<byte> Term4A => new byte[4]{RET, 0, 0, SBB};

        public const sbyte Term4AModifier = -3;

        /// c3 19 01 01
        public static ReadOnlySpan<byte> Term4B => new byte[4]{RET, SBB, 0x01, 0x01};

        public const sbyte Term4BModifier = -3;

        // 00 00 00 00 00
        public static ReadOnlySpan<byte> Term5A => new byte[5]{0, 0, 0, 0, 0};

        public const sbyte Term5AModifier = -5;

        //19 00 00 00 40 00
        public static ReadOnlySpan<byte> Term6A => new byte[6]{SBB, 0, 0, 0, 0x40, 0};

        public const sbyte Term6AModifier = -6;

        public static ReadOnlySpan<sbyte> TermModifiers => new sbyte[6]{Term3AModifier,Term3BModifier,Term4AModifier, Term4BModifier,Term5AModifier,Term6AModifier};
    }
}