//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct DocRowKey : IComparable<DocRowKey>, IEquatable<DocRowKey>
    {
        public readonly uint Seq;

        public readonly uint DocSeq;

        [MethodImpl(Inline)]
        public DocRowKey(uint seq, uint docseq)
        {
            Seq = seq;
            DocSeq = docseq;
        }

        public string Format()
            => string.Format("{0:D6}:{1:D4}");

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(DocRowKey src)
            => Seq == src.Seq && DocSeq == src.DocSeq;

        public override bool Equals(object src)
            => src is DocRowKey x && Equals(x);

        public override int GetHashCode()
            => (int)alg.hash.combine(Seq,DocSeq);

        [MethodImpl(Inline)]
        public int CompareTo(DocRowKey src)
            => Seq.CompareTo(src.Seq);

        [MethodImpl(Inline)]
        public static implicit operator DocRowKey((uint seq, uint docseq) src)
            => new DocRowKey(src.seq, src.docseq);
    }
}