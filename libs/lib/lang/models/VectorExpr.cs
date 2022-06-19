//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class VectorExpr : IExpr, ISeq<IExpr>
    {
        readonly Index<IExpr> Data;

        public VectorExpr(params IExpr[] terms)
        {
            Data = terms;
        }

        public uint N
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public ReadOnlySpan<IExpr> View
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public string Format()
            => string.Format("<{0}>",Data.Delimit().Format());

        public override string ToString()
            => Format();

        public static implicit operator VectorExpr(IExpr[] src)
            => new VectorExpr(src);
    }
}