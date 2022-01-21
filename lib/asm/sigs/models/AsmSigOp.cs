//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines an asm signature operand
    /// </summary>
    [DataType("asm.sigop")]
    public readonly struct AsmSigOp
    {
        public AsmSigOpKind Kind {get;}

        public byte TokenValue {get;}

        [MethodImpl(Inline)]
        internal AsmSigOp(AsmSigOpKind kind, byte token)
        {
            Kind = kind;
            TokenValue = token;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Kind == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Kind != 0;
        }

        public static AsmSigOp Empty => default;

        [MethodImpl(Inline)]
        public static implicit operator AsmSigOp((AsmSigOpKind kind, byte value) src)
            => new AsmSigOp(src.kind,src.value);
    }
}