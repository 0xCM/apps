//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        public class RuleGrids
        {
            public readonly Index<GridFields> Tables;

            public readonly uint MaxCols;

            public RuleGrids(GridFields[] src)
            {
                Tables = src;
                MaxCols = src.Select(x => x.ColCount).Max();
            }

            public uint TableCount
            {
                [MethodImpl(Inline)]
                get => Tables.Count;
            }

            public ref GridFields this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Tables[i];
            }

            public ref GridFields this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Tables[i];
            }

            public static implicit operator RuleGrids(GridFields[] src)
                => new RuleGrids(src);

            public static implicit operator RuleGrids(Index<GridFields> src)
                => new RuleGrids(src);
        }
    }
}