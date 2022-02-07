//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public readonly struct OpAssignment
        {
            public readonly OpKind Kind;

            public readonly ulong Value;

            [MethodImpl(Inline)]
            public OpAssignment(OpKind kind, ulong value)
            {
                Kind = kind;
                Value = value;
            }

            [MethodImpl(Inline)]
            public static implicit operator OpAssignment((OpKind kind, ulong value) src)
                => new OpAssignment(src.kind, src.value);
        }
    }
}