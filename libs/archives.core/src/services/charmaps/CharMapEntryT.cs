//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CharMapEntry<T>
        where T : unmanaged
    {
        public Hex16 Source {get;}

        public T Target {get;}

        [MethodImpl(Inline)]
        public CharMapEntry(Hex16 src, T dst)
        {
            Source = src;
            Target = dst;
        }
    }
}