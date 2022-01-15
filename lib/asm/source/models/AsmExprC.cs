//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AsmExpr<C>  : IEquatable<AsmExpr<C>>, IComparable<AsmExpr<C>>, INullity
        where C : unmanaged, ICharBlock<C>
    {
        public C Content {get;}

        [MethodImpl(Inline)]
        public AsmExpr(C content)
            => Content = content;

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Content.IsNonEmpty;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Content.IsEmpty;
        }

        public ReadOnlySpan<char> Data
        {
            [MethodImpl(Inline)]
            get => Content.Data;
        }

        public AsmPartKind PartKind
        {
            [MethodImpl(Inline)]
            get => AsmPartKind.Expr;
        }

        [MethodImpl(Inline)]
        public bool Equals(AsmExpr<C> src)
            => Content.Equals(src.Content);

        [MethodImpl(Inline)]
        public int CompareTo(AsmExpr<C> src)
            => Content.CompareTo(src.Content);

        public override int GetHashCode()
            => Content.GetHashCode();

        public override bool Equals(object src)
            => src is AsmExpr<C> x && Equals(x);

        public override string ToString()
            => Format();

        public string Format()
            => Content.Format();

        public string FormatPadded()
            => string.Format(RP.pad((int)Content.Capacity), Content);

        [MethodImpl(Inline)]
        public static implicit operator AsmExpr(AsmExpr<C> src)
            => new AsmExpr(src.Format());

        [MethodImpl(Inline)]
        public static implicit operator AsmExpr<C>(AsmExpr src)
            => new AsmExpr(src.Content);

        [MethodImpl(Inline)]
        public static implicit operator AsmExpr<C>(string src)
            => new AsmExpr<C>(CharBlocks.init<C>(src, out _));

        [MethodImpl(Inline)]
        public static implicit operator AsmExpr<C>(ReadOnlySpan<char> src)
            => new AsmExpr<C>(CharBlocks.init<C>(src, out _));

        [MethodImpl(Inline)]
        public static implicit operator AsmExpr<C>(Span<char> src)
            => new AsmExpr<C>(CharBlocks.init<C>(src, out _));

        [MethodImpl(Inline)]
        public static implicit operator AsmCell(AsmExpr<C> src)
            => asm.cell(src.Format(), src.PartKind);
    }
}