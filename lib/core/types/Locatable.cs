//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Locatable : ILocatable
    {
        public dynamic Locator {get;}

        [MethodImpl(Inline)]
        public Locatable(dynamic locator)
            => Locator = locator;

        public static Locatable Empty
        {
            [MethodImpl(Inline)]
            get => new Locatable(0ul);
        }

        public string Format()
            => Locator?.ToString() ?? EmptyString;
    }
}