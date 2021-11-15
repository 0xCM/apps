//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static SeqEnclosureKind;
    using static Chars;

    partial struct seq
    {
        [MethodImpl(Inline)]
        public static DelimitedList<T> enclose<T>(T[] src)
            => list(src, Chars.Comma, SeqEnclosureKind.Embraced);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static EnclosedSpan<T> enclose<T>(SeqEnclosureKind kind, char delimiter, ReadOnlySpan<T> src)
            => new EnclosedSpan<T>(src, kind, delimiter);

        [MethodImpl(Inline)]
        public static EnclosedSpan<T> enclose<T>(ReadOnlySpan<T> src)
            => enclose(SeqEnclosureKind.Embraced, Chars.Comma, src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static EnclosedSpan<T> enclose<T>(SeqEnclosureKind kind, char delimiter, Span<T> src)
            => new EnclosedSpan<T>(src, kind, delimiter);

        [MethodImpl(Inline)]
        public static EnclosedSpan<T> enclose<T>(Span<T> src)
            => enclose(SeqEnclosureKind.Embraced, Chars.Comma, src);

        [MethodImpl(Inline), Op]
        internal static char left(SeqEnclosureKind kind)
            => kind == Embraced ? LBrace : kind == Bracketed ? LBracket : LParen;

        [MethodImpl(Inline), Op]
        internal static char right(SeqEnclosureKind kind)
            => kind == Embraced ? RBrace : kind == Bracketed ? RBracket : RParen;
   }
}