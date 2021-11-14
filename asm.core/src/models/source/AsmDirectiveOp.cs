//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AsmDirectiveOp
    {
        public string Value {get;}

        [MethodImpl(Inline)]
        public AsmDirectiveOp(string value)
        {
            Value = value;
        }

        public string Format()
            => Value ?? EmptyString;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AsmDirectiveOp(string src)
            => new AsmDirectiveOp(src);
    }
}