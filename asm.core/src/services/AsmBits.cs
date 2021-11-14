//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    [ApiHost]
    public partial class AsmBits
    {
        const NumericKind Closure = UnsignedInts;

        const string FieldSep = " | ";

        const char Open = Chars.LBracket;

        const char Close = Chars.RBracket;

        static AsmBits The;

        AsmBits()
        {
        }

        static AsmBits()
        {
            The = new AsmBits();
        }
    }
}