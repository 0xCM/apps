//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
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