//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;
    using System.Runtime.CompilerServices;

    using static Root;

    [StructLayout(LayoutKind.Sequential, Pack =1)]
    public readonly struct Relation : IRelation
    {
        public Label Source {get;}

        public Label Target {get;}

        [MethodImpl(Inline)]
        public Relation(Label src, Label dst)
        {
            Source = src;
            Target = dst;
        }

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => alg.hash.combine(Source.Hash, Target.Hash);
        }

        public string Format()
            => string.Format("{0} -> {1}", Source, Target);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(Relation src)
            => Source == src.Source && Target == src.Target;

        public override int GetHashCode()
            => (int)Hash;
    }
}