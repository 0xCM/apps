//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AsmStatement
    {
        readonly TextBlock Data;

        [MethodImpl(Inline)]
        public AsmStatement(TextBlock src)
        {
            Data = src;
        }

        public string Format()
            => Data.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AsmStatement(string src)
            => new AsmStatement(src);
    }
}