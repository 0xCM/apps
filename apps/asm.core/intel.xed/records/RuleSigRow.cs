//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [Record(TableId)]
        public struct RuleSigRow : IComparable<RuleSigRow>
        {
            public const string TableId = "xed.rules.tables.sigs";

            public const byte FieldCount = 3;

            public uint Seq;

            public RuleSig Sig;

            public FS.FileUri TableDef;

            public int CompareTo(RuleSigRow src)
                => Sig.CompareTo(src.Sig);

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,32,1};
        }
    }
}