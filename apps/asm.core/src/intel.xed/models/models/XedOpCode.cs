//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
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