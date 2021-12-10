//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct LlvmArrow<T> : QuikGraph.IEdge<T>, IArrow<T>, IEquatable<LlvmArrow<T>>, IComparable<LlvmArrow<T>>
        where T : IEquatable<T>, IComparable<T>
    {
        public T Source {get;}

        public T Target {get;}

        [MethodImpl(Inline)]
        public LlvmArrow(T src, T dst)
        {
            Source = src;
            Target = dst;
        }

        public bool Equals(LlvmArrow<T> src)
            => Source.Equals(src.Source) && Target.Equals(src.Target);

        public override int GetHashCode()
            => (int)alg.hash.combine(Source.GetHashCode(),Target.GetHashCode());

        public override bool Equals(object src)
            => src is LlvmArrow<T> a && Equals(a);

        public string Format()
            => string.Format("{0} -> {1}", Source, Target);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(LlvmArrow<T> src)
        {
            var a = Source.CompareTo(src.Source);
            if(a != 0)
                return a;
            return Target.CompareTo(src.Target);
        }

        [MethodImpl(Inline)]
        public static implicit operator LlvmArrow<T>((T src, T dst) def)
            => new LlvmArrow<T>(def.src, def.dst);
    }
}