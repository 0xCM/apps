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
        public static AsmSigInfo siginfo(AsmMnemonic mnemonic, string content)
            => new AsmSigInfo(mnemonic, content);

        [Op]
        public static AsmSigInfo siginfo(string src)
        {
            if(AsmParser.siginfo(src, out var dst))
                return dst;
            else
                return AsmSigInfo.Empty;
        }
    }
}