//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct CellTypes : IIndex<CellType>
        {
            readonly Index<CellType> Data;

            [MethodImpl(Inline)]
            public CellTypes(CellType[] src)
            {
                Data = src;
            }

            public uint Count
            {
                [MethodImpl(Inline)]
                get => Data.Count;
            }

            public ref CellType this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            public ref CellType this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            public CellType[] Storage
            {
                [MethodImpl(Inline)]
                get => Data.Storage;
            }

            [MethodImpl(Inline)]
            public static implicit operator CellTypes(CellType[] src)
                => new CellTypes(src);

            [MethodImpl(Inline)]
            public static implicit operator CellType[](CellTypes src)
                => src.Data;
        }
    }
}