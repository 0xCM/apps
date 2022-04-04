//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public readonly struct OpCodeMap
        {
            public readonly OpCodeKind Kind;

            public readonly OpCodeClass Class;

            public readonly OpCodeIndex Index;

            public readonly char Indicator;

            public readonly asci4 Selector;

            public OpCodeMap(OpCodeKind kind, OpCodeClass @class, OpCodeIndex index, char indicator, asci4 selector)
            {
                Kind = kind;
                Class = @class;
                Index = index;
                Indicator = indicator;
                Selector = selector;
            }

            public string Format()
                => string.Format("{0}:{1}", Indicator, Selector);

            public override string ToString()
                => Format();
        }
    }
}