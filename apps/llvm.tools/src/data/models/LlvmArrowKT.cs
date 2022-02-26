//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    public readonly struct LlvmArrow<K,T> : QuikGraph.IEdge<T>, IArrow<T>, IEquatable<LlvmArrow<K,T>>, IComparable<LlvmArrow<K,T>>
        where T : IEquatable<T>, IComparable<T>
        where K : unmanaged
    {
        public K Kind {get;}

        public T Source {get;}

        public T Target {get;}

        [MethodImpl(Inline)]
        public LlvmArrow(K kind, T src, T dst)
        {
            Kind = kind;
            Source = src;
            Target = dst;
        }

        ulong KindValue
        {
            [MethodImpl(Inline)]
            get => core.bw64(Kind);
        }

        public bool Equals(LlvmArrow<K,T> src)
            => Source.Equals(src.Source) && Target.Equals(src.Target);

        public override int GetHashCode()
            => (int)alg.hash.combine(Source.GetHashCode(), Target.GetHashCode(), KindValue.GetHashCode());

        public override bool Equals(object src)
            => src is LlvmArrow<K,T> a && Equals(a);

        public string Format()
            => string.Format("{0} -> {1}", Source, Target);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(LlvmArrow<K,T> src)
        {
            var k = KindValue.CompareTo(src.Kind);
            if(k == 0)
            {
                var m = Source.CompareTo(src.Source);
                if(m == 0)
                    return Target.CompareTo(src.Target);
                else
                    return m;
            }
            else
                return k;
        }

        [MethodImpl(Inline)]
        public static implicit operator LlvmArrow<K,T>((K kind, T src, T dst) def)
            => new LlvmArrow<K,T>(def.kind, def.src, def.dst);
    }
}