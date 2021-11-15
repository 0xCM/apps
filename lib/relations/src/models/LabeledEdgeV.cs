//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct LabeledEdge<V> : IEdge<V>, IEquatable<LabeledEdge<V>>
        where V : unmanaged, ILabeledVertex, IEquatable<V>
    {
        public Label Name {get;}

        public V Source {get;}

        public V Target {get;}

        [MethodImpl(Inline)]
        public LabeledEdge(Label label, V src, V dst)
        {
            Name = label;
            Source = src;
            Target = dst;
        }

        [MethodImpl(Inline)]
        public bool Equals(LabeledEdge<V> src)
            => Source.Equals(src.Source) && Target.Equals(src.Target) && Name.Equals(src.Name);

        public string Format()
            => string.Format("{0}:{1} -> {2}", Name, Source, Target);

        public override string ToString()
            => Format();
    }
}