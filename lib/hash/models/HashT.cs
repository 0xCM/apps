//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct Hash<T>
        where T : unmanaged, IHashCode<T,T>
    {
        public readonly T Value;

        [MethodImpl(Inline)]
        public Hash(T src)
        {
            Value = src;
        }

        [MethodImpl(Inline)]
        public static implicit operator Hash<T>(T src)
            => new Hash<T>(src);
    }
}