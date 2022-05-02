//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedGrids
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct GridRow
        {
            public RuleSig Rule;

            public ushort Index;

            public ushort Row;

            public byte ColCount;

            public Index<GridCol> Cols;

            public ref GridCol this[byte i]
            {
                [MethodImpl(Inline)]
                get => ref Cols[i];
            }

            public uint PackedWidth()
                => Cols.Storage.Where(c => c.Field != 0).Select(x => x.Size.Packed).Sum();

            public uint AlignedWidth()
                => Cols.Storage.Where(c => c.Field != 0).Select(x => x.Size.Aligned).Sum();

            public DataSize Size()
                => new DataSize(PackedWidth(), AlignedWidth());
        }
    }
}