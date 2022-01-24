//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial class AsmSigModels
    {
        public readonly struct Reg : IRegOpClass<Reg>, IAsmSigOp<Reg,GpRegToken>
        {
            public NativeSize Size {get;}

            public RegClassCode RegClass {get;}

            [MethodImpl(Inline)]
            public Reg(NativeSize size, RegClassCode @class)
            {
                Size = size;
                RegClass = @class;
            }

            public AsmSigOpKind OpKind
                => AsmSigOpKind.GpReg;

            public GpRegToken Token
                => GpRegToken.reg;

            public AsmOpClass OpClass
                => AsmOpClass.Reg;
        }
    }
}