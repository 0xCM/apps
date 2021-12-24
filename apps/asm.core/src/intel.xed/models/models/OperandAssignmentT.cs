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
        public readonly struct OperandAssignment<T>
            where T : unmanaged
        {
            public OperandKind Kind {get;}

            public T Value {get;}

            [MethodImpl(Inline)]
            public OperandAssignment(OperandKind kind, T value)
            {
                Kind = kind;
                Value = value;
            }

            public string Format()
                => string.Format("{0}={1}", Kind,Value);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator OperandAssignment<T>((OperandKind kind, T value) src)
                => new OperandAssignment<T>(src.kind, src.value);

            public static implicit operator OperandAssignment(OperandAssignment<T> src)
                => new OperandAssignment(src.Kind,core.bw64(src.Value));
        }
    }
}