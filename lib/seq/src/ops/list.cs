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
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static DelimitedList<T> list<T>(T[] items, char delimiter = Comma, SeqEnclosureKind enclosure = Bracketed)
            => new DelimitedList<T>(items, delimiter, enclosure);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static DelimitedList<T> list<T>(char delimiter = Comma, SeqEnclosureKind enclosure = Bracketed)
            => new DelimitedList<T>(delimiter, enclosure);
    }
}