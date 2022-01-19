//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial class AsmSigs
    {
        public readonly struct cr : IRegOpClass<cr>
        {
            public AsmOpClass OpClass
                => AsmOpClass.Reg;

            public NativeSize Size
                => NativeSizeCode.W64;

            public RegClassCode RegClass
                => RegClassCode.CR;

            [MethodImpl(Inline)]
            public static implicit operator reg(cr src)
                => new reg(src.Size, src.RegClass);

            [MethodImpl(Inline)]
            public static implicit operator AsmOperand(cr src)
                => new AsmOperand(src.OpClass, src.Size, (byte)src.RegClass);
        }
    }
}