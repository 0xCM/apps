//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines the literal content of a symbol
    /// </summary>
    public readonly struct SymExpr : ITextual
    {
        readonly string Content;

        [MethodImpl(Inline)]
        public SymExpr(string content)
            => Content = content ?? EmptyString;

        public ushort CharCount
        {
            [MethodImpl(Inline)]
            get => (ushort)(Content?.Length ?? 0);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => CharCount == 0;
        }

        public bool IsNonEmpty
        {
            get => CharCount != 0;
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

        [MethodImpl(Inline)]
        public string Format()
            => Text;

        [MethodImpl(Inline)]
        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Text.GetHashCode();

        public bool Equals(SymExpr src)
            => Text.Equals(src.Text, NoCase);

        public override bool Equals(object src)
            => src is SymExpr e && Equals(e);

        public static implicit operator SymExpr(string src)
            => new SymExpr(src);

        public static bool operator ==(SymExpr a, SymExpr b)
            => a.Equals(b);

        public static bool operator !=(SymExpr a, SymExpr b)
            => !a.Equals(b);

        public static SymExpr Empty
        {
            [MethodImpl(Inline)]
            get => new SymExpr(EmptyString);
        }
    }
}