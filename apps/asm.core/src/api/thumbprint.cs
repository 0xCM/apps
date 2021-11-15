//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct asm
    {
        [MethodImpl(Inline),Op]
        public static AsmThumbprint thumbprint(AsmExpr statement, AsmSigInfo sig, AsmOpCodeString opcode, AsmHexCode encoded)
            => new AsmThumbprint(statement, sig, opcode, encoded);

        [MethodImpl(Inline),Op]
        public static AsmThumbprint thumbprint(AsmExpr statement, AsmFormInfo form, AsmHexCode encoded)
            => new AsmThumbprint(statement, form.Sig, form.OpCode, encoded);

        [MethodImpl(Inline),Op]
        public static AsmThumbprint thumbprint(in HostAsmRecord src)
            => thumbprint(src.Expression, src.Sig, src.OpCode, src.Encoded);
    }
}