//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct AsmRowKey : IComparable<AsmRowKey>, IEquatable<AsmRowKey>
    {
        public readonly uint Seq;

        public readonly uint DocSeq;

        public readonly Hex32 OriginId;

        [MethodImpl(Inline)]
        public AsmRowKey(uint seq, uint docseq, Hex32 origin)
        {
            OriginId = origin;
            Seq = seq;
            DocSeq = docseq;
        }

        public string Format()
            => string.Format("{0:x6}:{1:x4}:{2:x8}", Seq, DocSeq, (uint)OriginId);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(AsmRowKey src)
            => Seq == src.Seq && DocSeq == src.DocSeq;

        public override bool Equals(object src)
            => src is AsmRowKey x && Equals(x);

        public override int GetHashCode()
            => (int)alg.hash.combine(Seq,DocSeq);

        [MethodImpl(Inline)]
        public int CompareTo(AsmRowKey src)
            => Seq.CompareTo(src.Seq);

        [MethodImpl(Inline)]
        public static implicit operator AsmRowKey((uint seq, uint docseq, Hex32 origin) src)
            => new AsmRowKey(src.seq, src.docseq, src.origin);

        [MethodImpl(Inline)]
        public static bool operator ==(AsmRowKey a, AsmRowKey b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(AsmRowKey a, AsmRowKey b)
            => !a.Equals(b);
    }
}