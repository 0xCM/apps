//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules;
    using static XedModels;

    partial class XedPatterns
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

            public OpName Name;

            public OpKind Kind;

            public @string Expression;

            public OpAttrib Action;

            public OpAttrib WidthCode;

            public OpAttrib CellType;

            public EmptyZero<ushort> BitWidth;

            public EmptyZero<ushort> CellWidth;

            public OpAttrib RegLit;

            public OpAttrib Modifier;

            public OpAttrib Visibility;

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