//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedModels;

    partial struct XedModels
    {
        public readonly struct XedOpCode
        {
            public readonly IClass Class;

            public readonly OpCodeKind Kind;

            public readonly AsmOcValue Value;

            [MethodImpl(Inline)]
            public XedOpCode(IClass @class, OpCodeKind kind, AsmOcValue value)
            {
                Class = @class;
                Kind = kind;
                Value = value;
            }
        }
    }
}