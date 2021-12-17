//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public readonly struct scalar<K,T> : IScalarValue<K,T>
        where K : unmanaged
        where T : unmanaged
    {
        public BitWidth ContentWidth {get;}

        public K Kind {get;}

        public T Value {get;}

        public string Format()
            => Value.ToString();
    }
}