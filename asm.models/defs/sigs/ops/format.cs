//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class AsmSigs
    {
        public static string format(in AsmSig src)
        {
            var storage = CharBlock64.Null;
            var dst = storage.Data;
            var i=0u;
            seek(dst,i++) = Chars.LParen;
            text.copy(src.Mnemonic.Format(MnemonicCase.Uppercase), ref i, dst);
            var count = src.OperandCount;

            if(count != 0)
                seek(dst,i++) = Chars.Space;

            for(byte j=0; j<count; j++)
            {
                ref readonly var op = ref operand(src,j);
                if(op.IsEmpty)
                    break;

                if(j != 0)
                {
                    seek(dst,i++) = Chars.Comma;
                    seek(dst,i++) = Chars.Space;
                }

                text.copy(op.Text, ref i, dst);
            }
            seek(dst,i++) = Chars.RParen;
            return storage.Format();
        }
    }
}