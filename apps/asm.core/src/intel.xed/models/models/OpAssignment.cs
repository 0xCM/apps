//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial struct XedModels
    {
        public readonly struct OpAssignment
        {
            public readonly XedOpKind Kind;

            public readonly ulong Value;

            [MethodImpl(Inline)]
            public OpAssignment(XedOpKind kind, ulong value)
            {
                Kind = kind;
                Value = value;
            }

            [MethodImpl(Inline)]
            public static implicit operator OpAssignment((XedOpKind kind, ulong value) src)
                => new OpAssignment(src.kind, src.value);
        }
    }
}