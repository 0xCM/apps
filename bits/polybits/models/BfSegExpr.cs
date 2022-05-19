//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = PolyBits;

    [StructLayout(StructLayout,Pack=1)]
    public readonly struct BfSegExpr
    {
        public readonly Char5Seq SegName;

        public readonly BfInterval SegBits;

        [MethodImpl(Inline)]
        public BfSegExpr(Char5Seq name, BfInterval bits)
        {
            SegName = name;
            SegBits = bits;
        }


        public uint MinPos
        {
            [MethodImpl(Inline)]
            get => SegBits.Offset;
        }

        public uint MaxPos
        {
            [MethodImpl(Inline)]
            get => SegBits.MaxPos;
        }

        public byte SegWidth
        {
            [MethodImpl(Inline)]
            get => SegBits.Width;
        }

        [MethodImpl(Inline)]
        public bool Equals(BfSegExpr src)
            => SegBits == src.SegBits && SegName == src.SegName;

        public string Format()
            => SegWidth == 1 ? string.Format("{0}[{1}]",SegName, MaxPos) : string.Format("{0}[{1}:{2}]", SegName, MaxPos, MinPos);

        public override string ToString()
            => Format();
    }
}