//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct AsciName<T> : INamed<T>
        where T : unmanaged, IAsciSeq<T>
    {
        public readonly T Data;

        [MethodImpl(Inline)]
        public AsciName(T name)
        {
            Data = name;
        }

        T INamed<T>.Name
            => Data;

        public override string ToString()
            => Data.ToString();
    }
}