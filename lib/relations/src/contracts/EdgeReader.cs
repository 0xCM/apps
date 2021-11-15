//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public delegate void EdgeReader<V>(in LabeledEdge<V> e)
        where V : unmanaged, ILabeledVertex, IEquatable<V>;
}