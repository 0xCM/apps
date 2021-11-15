//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AsmRegName
    {
        readonly text7 Data;

        [MethodImpl(Inline)]
        public AsmRegName(text7 name)
        {
            Data = name;
        }

        public string Format()
            => Data.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AsmRegName(text7 src)
            => new AsmRegName(src);
    }
}