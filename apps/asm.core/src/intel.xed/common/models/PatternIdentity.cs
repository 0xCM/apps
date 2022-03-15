//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    partial struct XedModels
    {
        [Record(TableId)]
        public struct PatternIdentity : IComparable<PatternIdentity>
        {
            public const string TableId = "xed.patterns.identity";

            public const byte FieldCount = 6;

            public uint PatternId;

            public Identifier Name;

            public IClass Class;

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