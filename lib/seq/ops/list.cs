//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Chars;

    partial struct Seq
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static DelimitedList<T> list<T>(T[] items, char delimiter = Comma, SeqEnclosureKind enclosure = SeqEnclosureKind.Bracketed)
            => new DelimitedList<T>(items, delimiter, enclosure);
    }
}