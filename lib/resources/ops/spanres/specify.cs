//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct SpanRes
    {
        [MethodImpl(Inline), Op]
        public static ByteSpanSpec specify(Identifier name, BinaryCode data, bool @static = true)
            => new ByteSpanSpec(name, data, @static);

        [MethodImpl(Inline)]
        public static SymSpanSpec<E> specify<E>(Identifier name)
            where E : unmanaged, Enum
                => specify<E>(name, Symbols.index<E>().View);

        [MethodImpl(Inline)]
        public static SymSpanSpec<E> specify<E>(Identifier name, ReadOnlySpan<Sym<E>> literals, bool @static = true)
            where E : unmanaged, Enum
                => new SymSpanSpec<E>(name, literals, @static);

        [Op]
        public static ByteSpanSpec specify(OpUri uri, BinaryCode data, bool @static = true)
            => new ByteSpanSpec(LegalIdentityBuilder.code(uri.OpId), data, @static);
    }
}