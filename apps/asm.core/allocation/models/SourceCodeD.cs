//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public readonly struct SourceCode<D> : ISourceCode<SourceCode<D>,D>
    {
        public readonly SourceText Source;

        public readonly CorrelationToken CT;

        public readonly uint Hash;

        public readonly D Data;

        [MethodImpl(Inline)]
        public SourceCode(SourceText src, CorrelationToken ct, D desc)
        {
            Source = src;
            CT = ct;
            Hash = src.Hash;
            Data = desc;
        }

        D ISourceCode<SourceCode<D>, D>.Data
            => Data;

        SourceText ISourceCode.Source
            => Source;

        CorrelationToken ICorrelated.CT
            => CT;

        [MethodImpl(Inline)]
        public bool Equals(SourceCode<D> src)
            => CT.Equals(src.CT);

        [MethodImpl(Inline)]
        public int CompareTo(SourceCode<D> src)
            => CT.CompareTo(src.CT);

        public override bool Equals(object src)
            => src is SourceCode<D> x && Equals(x);

        public override int GetHashCode()
            => (int)Hash;

        public string Format()
            => Source.Format();

        public override string ToString()
            => Source.Format();

        [MethodImpl(Inline)]
        public static implicit operator SourceCode(SourceCode<D> src)
            => new SourceCode(src.Source, src.CT, src.Hash);
    }
}