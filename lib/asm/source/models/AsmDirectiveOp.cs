//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AsmDirectiveOp : IAsmSourcePart
    {
        public @string Value {get;}

        [MethodImpl(Inline)]
        public AsmDirectiveOp(string value)
        {
            Value = value;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Value.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Value.IsNonEmpty;
        }

        AsmPartKind IAsmSourcePart.PartKind
            => AsmPartKind.DirectiveOp;

        public string Format()
            => Value;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AsmDirectiveOp(string src)
            => new AsmDirectiveOp(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmCell(AsmDirectiveOp src)
            => new AsmCell(default, AsmPartKind.DirectiveOp, src.Value);

        public static AsmDirectiveOp Empty => new AsmDirectiveOp(EmptyString);
    }
}