//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct relations
    {
       [MethodImpl(Inline)]
        public static LabeledEdge<V> edge<V>(Label label, V src, V dst)
            where V : unmanaged, ILabeledVertex, IEquatable<V>
                => new LabeledEdge<V>(label,src,dst);
    }
}