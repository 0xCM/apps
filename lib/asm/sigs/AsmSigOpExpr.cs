//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using static Root;
    using static core;

    /// <summary>
    /// Represents an operand in the context of an instruction signature
    /// </summary>
    [DataType("asm.sigop.expr")]
    public readonly struct AsmSigOpExpr
    {
        readonly string Content;

        [MethodImpl(Inline)]
        internal AsmSigOpExpr(string data)
        {
            Content = data.Trim();
        }

        public string Text
        {
            [MethodImpl(Inline)]
            get => Content ?? EmptyString;
        }

        public ReadOnlySpan<char> Data
        {
            [MethodImpl(Inline)]
            get => Text;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => text.length(Text) == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => text.length(Text) != 0;
        }

        // public Index<AsmSigOpExpr> Decompose()
        //     => IsComposite ? map(text.split(Text, Chars.FSlash), x => (AsmSigOpExpr)x) : array(this);

        public string Format()
            => Text;

        public override string ToString()
            => Format();

        public bool Equals(AsmSigOpExpr src)
            => Text.Equals(src.Text);

        [MethodImpl(Inline)]
        public static implicit operator AsmSigOpExpr(string src)
            => new AsmSigOpExpr(src);

        public static AsmSigOpExpr Empty
        {
            [MethodImpl(Inline)]
            get => new AsmSigOpExpr(EmptyString);
        }
    }
}