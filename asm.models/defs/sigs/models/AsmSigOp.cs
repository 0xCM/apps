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
    public readonly struct AsmSigOp
    {
        readonly ulong Data;

        [MethodImpl(Inline)]
        internal AsmSigOp(AsmOpClass @class, AsmSigOpKind kind, NativeSize size)
        {
            Data = Bitfields.join((byte)@class, (byte)kind, (byte)size.Code);
        }

        public AsmOpClass Class
        {
            [MethodImpl(Inline)]
            get => (AsmOpClass)Data;
        }

        public AsmSigOpKind Kind
        {
            [MethodImpl(Inline)]
            get => (AsmSigOpKind)(Data >> 8);
        }

        public NativeSize Size
        {
            [MethodImpl(Inline)]
            get => new NativeSize((NativeSizeCode)(byte)(Data >> 16));
        }
    }
}