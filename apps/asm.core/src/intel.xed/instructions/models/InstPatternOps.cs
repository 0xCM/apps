//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedModels;

    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1), Record(TableName)]
        public struct InstPatternOps : IComparable<InstPatternOps>
        {
            public const byte FieldCount = 15;

            public const string TableName = "xed.inst.patterns.ops";

            public uint InstId;

            public uint PatternId;

            public IClass Mnemonic;

            public byte OpIndex;

            public RuleOpName Name;

            public RuleOpKind Kind;

            public @string Expression;

            public RuleOpAttrib Action;

            public RuleOpAttrib WidthCode;

            public RuleOpAttrib CellType;

            public EmptyZero<ushort> BitWidth;

            public EmptyZero<ushort> CellWidth;

            public RuleOpAttrib RegLit;

            public RuleOpAttrib Modifier;

            public RuleOpAttrib Visibility;

            public int CompareTo(InstPatternOps src)
            {
                var result = InstId.CompareTo(src.InstId);
                if(result == 0)
                {
                    result = PatternId.CompareTo(src.PatternId);
                    if(result == 0)
                        result = OpIndex.CompareTo(src.OpIndex);
                }
                return result;
            }

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{10,10,18,8,8,8,32,8,10,10,10,10,16,8,12};

            public static InstPatternOps Empty => default;
        }
    }
}