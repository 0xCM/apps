//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static Root;
    using static core;

    partial class IntelSdm
    {
        public Index<AsmSigExpr> Sigs(ReadOnlySpan<SdmOpCodeDetail> src)
        {
            var count = src.Length;
            var buffer = alloc<AsmSigExpr>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var record = ref skip(src,i);
                ref var dst = ref seek(buffer,i);
                var sig = record.Sig.Format().Trim();
                var mnemonic = record.Mnemonic.Format(MnemonicCase.Lowercase);
                var j = text.index(sig,Chars.Space);
                if(j > 0)
                {
                    var operands = text.right(sig,j);
                    if(text.contains(sig,Chars.Comma))
                        dst = AsmSigs.expression(mnemonic, text.trim(text.split(operands, Chars.Comma)));
                    else
                        dst = AsmSigs.expression(mnemonic, operands);
                }
                else
                {
                    dst = AsmSigs.expression(mnemonic);
                }

            }
            return buffer;
        }
    }
}