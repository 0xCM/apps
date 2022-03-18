//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential), Record(TableId)]
        public struct RuleSchema
        {
            public const string TableId = "xed.rules.schemas";

            public const byte FieldCount = 8;

            public uint Seq;

            public RuleTableKind TableKind;

            public Identifier TableName;

            public char ColKind;

            public byte Index;

            public FieldKind Field;

            public CellDataKind DataKind;

            public FS.FileUri TableDef;

            public int CompareTo(RuleSchema src)
            {
                var result = ((byte)TableKind).CompareTo((byte)src.TableKind);
                if(result == 0)
                {
                    result = TableName.CompareTo(src.TableName);
                    if(result == 0)
                        result = Index.CompareTo(src.Index);
                }
                return result;
            }

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,12,32,8,8,24,12,1};
        }
    }
}