//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public readonly record struct OpCodeMap : IComparable<OpCodeMap>
        {
            public readonly OpCodeKind Kind;

            public readonly OpCodeClass Class;

            public readonly OpCodeIndex Index;

            public readonly asci2 Symbol;

            public readonly asci4 Selector;

            public readonly asci8 Depictor;

            public readonly Hex16 Value;

            public OpCodeMap(OpCodeKind kind, OpCodeClass @class, OpCodeIndex index, asci2 indicator, asci4 selector)
            {
                Kind = kind;
                Class = @class;
                Index = index;
                Symbol = indicator;
                Selector = selector;
                Value = XedOpCodes.value(kind);
                Depictor = $"{Symbol}[{Value}]";
            }

            public int CompareTo(OpCodeMap src)
                => XedOpCodes.cmp(Kind, src.Kind);

            public string Format()
                => Depictor.Format();

            public override string ToString()
                => Format();
        }
    }
}