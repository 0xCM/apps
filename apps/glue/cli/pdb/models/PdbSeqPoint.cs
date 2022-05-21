//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct PdbSeqPoint : ITextual
    {
        public static PdbSeqPoint adapt(SymUnmanagedSequencePoint src)
            => new PdbSeqPoint((uint)src.Offset,
                ((uint)src.StartLine, (uint)src.StartColumn),
                ((uint)src.EndLine, (uint)src.EndColumn));

        public uint Offset {get;}

        public GridPoint<uint> UpperLeft {get;}

        public GridPoint<uint> LowerRight {get;}

        [MethodImpl(Inline)]
        public PdbSeqPoint(uint offset, GridPoint<uint> x, GridPoint<uint> y)
        {
            Offset = offset;
            UpperLeft = x;
            LowerRight = y;
        }

        public uint StartLine
        {
            [MethodImpl(Inline)]
            get => UpperLeft.Row;
        }

        public uint StartColumn
        {
            [MethodImpl(Inline)]
            get => UpperLeft.Col;
        }

        public uint EndLine
        {
            [MethodImpl(Inline)]
            get => LowerRight.Row;
        }

        public uint EndColumn
        {
            [MethodImpl(Inline)]
            get => LowerRight.Col;
        }

        public bool IsHidden
        {
            [MethodImpl(Inline)]
            get => StartLine == 0xfeefee;
        }

        public string Format()
            =>  string.Format("[{0:D3}, ({1:D3},{2:D3}), ({3:D3},{4:D3})]", Offset, StartLine, StartColumn, EndLine, EndColumn);

        public override string ToString()
            => Format();
    }
}