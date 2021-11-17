//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class VectorType<T> : FixedWidthType<T>
        where T : VectorType<T>, new()
    {
        protected VectorType(BitWidth storage, BitWidth content, BitWidth cellwidth, uint cellcount)
            : base(storage, content)
        {
            CellCount = cellcount;
            CellWidth = cellwidth;
        }

        public uint CellCount {get;}

        public BitWidth CellWidth {get;}
    }
}