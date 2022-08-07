//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface INativeKey<K> : IKeyed<K>
        where K : unmanaged, IEquatable<K>, IComparable<K>
    {

    }
}