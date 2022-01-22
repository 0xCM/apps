//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class AsmSigModels
    {
        public readonly struct rflags : IRegOpClass<rflags>
        {
            public AsmOpClass OpClass => AsmOpClass.Reg;

            public NativeSize Size => NativeSizeCode.W64;

            public RegClassCode RegClass => RegClassCode.FLAG;

            [MethodImpl(Inline)]
            public static implicit operator Reg(rflags src)
                => new Reg(src.Size, src.RegClass);

            [MethodImpl(Inline)]
            public static implicit operator AsmOperand(rflags src)
                => new AsmOperand(src.OpClass, src.Size, (byte)src.RegClass);
        }
    }
}