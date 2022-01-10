//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct asm
    {
        [Op]
        public static AsmEncodingInfo encoding(in ProcessAsmRecord src)
            => new AsmEncodingInfo((src.OpCode, src.Sig), src.Statement, src.Encoded, AsmBits.bitstring(src.Encoded));

        [Op]
        public static AsmEncodingInfo encoding(in AsmFormInfo form, in AsmExpr statement, in AsmHexCode encoded)
            => new AsmEncodingInfo(form, statement, encoded, AsmBits.bitstring(encoded));

        [MethodImpl(Inline), Op]
        public static AsmEncodingInfo encoding(in AsmFormInfo form, in AsmExpr statement, in AsmHexCode encoded, in AsmBitstring bitstring)
            => new AsmEncodingInfo(form, statement, encoded, bitstring);
    }
}