//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static FlagFormatters;

    partial struct Flags
    {
        public static ITextFormatter<Flags8<E>> formatter<E>(W8 w)
            where E : unmanaged, Enum
                => new Enum8Formatter<E>();

        public static ITextFormatter<Flags16<E>> formatter<E>(W16 w)
            where E : unmanaged, Enum
                => new Enum16Formatter<E>();

        public static ITextFormatter<Flags32<E>> formatter<E>(W32 w)
            where E : unmanaged, Enum
                => new Enum32Formatter<E>();

        public static ITextFormatter<Flags64<E>> formatter<E>(W64 w)
            where E : unmanaged, Enum
                => new Enum64Formatter<E>();
    }
}