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
        [MethodImpl(Inline), Op]
        public static AsmSigInfo sigxpr(AsmMnemonic mnemonic, string content)
            => new AsmSigInfo(mnemonic, content);

        [Op]
        public static AsmSigInfo sigxpr(string src)
        {
            if(AsmParser.sigxpr(src, out var dst))
                return dst;
            else
                return AsmSigInfo.Empty;
        }
    }
}