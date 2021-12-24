//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct XedModels
    {
        public readonly struct OperandAssignment
        {
            public OperandKind Kind {get;}

            public ulong Value {get;}

            [MethodImpl(Inline)]
            public OperandAssignment(OperandKind kind, ulong value)
            {
                Kind = kind;
                Value = value;
            }

            public string Format()
                => string.Format("{0}={1}", Kind,Value);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator OperandAssignment((OperandKind kind, ulong value) src)
                => new OperandAssignment(src.kind, src.value);

            public static OperandAssignment Empty => default;
        }
    }
}