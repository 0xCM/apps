//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct PointMap<I,T>
        where I : unmanaged
        where T : unmanaged
    {
        public I Source;

        public T Target;

        public string Format()
            => string.Format("{0} -> {1}", Source, Target);

        public override string ToString()
            => Format();
    }
}