//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AsmStatement
    {
        readonly text31 Data;

        [MethodImpl(Inline)]
        public AsmStatement(string src)
        {
            Data = src;
        }

        [MethodImpl(Inline)]
        public static implicit operator AsmStatement(string src)
            => new AsmStatement(src);

        public string Format()
            => Data.Format();

        public override string ToString()
            => Format();
    }

    [ApiHost]
    public readonly partial struct AsmStatements
    {
        const string RP1 = "{0} {1}";

        const string RP2 = "{0} {1}, {2}";

    }
}