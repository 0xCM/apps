//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.CompilerServices;

    using static Root;

    [StructLayout(LayoutKind.Sequential, Pack =1)]
    public readonly struct Relation<K> : IRelation<K>
        where K : unmanaged
    {
        public K Kind {get;}

        public Label Source {get;}

        public Label Target {get;}

        [MethodImpl(Inline)]
        public Relation(K kind, Label src, Label dst)
        {
            Kind = kind;
            Source = src;
            Target = dst;
        }

        public string Format()
            => string.Format("{0}:{1} -> {2}", Kind, Source, Target);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(Relation<K> src)
            => core.bw64(Kind) == core.bw64(src.Kind)
            && Source == src.Source
            && Target == src.Target;
    }
}