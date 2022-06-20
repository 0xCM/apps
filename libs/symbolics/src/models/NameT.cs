//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct Name<T> : INamed<T>
        where T : unmanaged, ICharBlock<T>
    {
        public readonly T Data;

        [MethodImpl(Inline)]
        public Name(T name)
        {
            Data = name;
        }

        T INamed<T>.Name
            => Data;

        public override string ToString()
            => Data.ToString();
    }
}