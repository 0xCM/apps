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
        public readonly struct reg : IRegOpClass<reg>, IAsmSigOp<reg,GpRegToken>
        {
            public NativeSize Size {get;}

            public RegClassCode RegClass {get;}

            public GpRegToken Token => GpRegToken.reg;

            [MethodImpl(Inline)]
            public reg(NativeSize size, RegClassCode @class)
            {
                Size = size;
                RegClass = @class;
            }

            public AsmOpClass OpClass
                => AsmOpClass.Reg;

            [MethodImpl(Inline)]
            public static implicit operator AsmOperand(reg src)
                => new AsmOperand(src.OpClass, src.Size, (byte)src.RegClass);
        }
    }
}