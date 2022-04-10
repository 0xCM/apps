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
        [Record(TableId)]
        public struct PatternIdentity : IComparable<PatternIdentity>
        {
            public const string TableId = "xed.patterns.identity";

            public const byte FieldCount = 6;

            public uint PatternId;

            public Identifier Name;

            public InstClass InstClass;

            public OpCodeKind OcKind;

            public AsmOcValue OcValue;

            public TextBlock PatternBody;

            public int CompareTo(PatternIdentity src)
            {
                var result = Name.CompareTo(src.Name);
                if(result==0)
                    result = PatternBody.CompareTo(src.PatternBody);
                return result;
            }

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{12,64,24,12,24,1};
        }

    }
}