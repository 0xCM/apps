//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct Hash<K,P> : IHashCode<K,P>
        where K : unmanaged
        where P : unmanaged
    {
        public K Value {get;}

        public P Primitive
        {
            [MethodImpl(Inline)]
            get => core.@as<K,P>(Value);
        }

        [MethodImpl(Inline)]
        public Hash(K value)
            => Value = value;
    }
}