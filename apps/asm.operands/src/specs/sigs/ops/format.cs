//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class AsmSigs
    {
        public static string format(in AsmSigOp src)
            => expression(src).Text;

        public static string format(in AsmSigExpr src)
        {
            var storage = CharBlock64.Null;
            var dst = storage.Data;
            var i=0u;
            text.copy(src.Mnemonic.Format(MnemonicCase.Lowercase), ref i, dst);
            var count = src.OperandCount;

            if(count != 0)
                seek(dst,i++) = Chars.Space;

            operands(src, ref i, dst);
            return storage.Format();
        }

        public static string format(AsmSigRuleExpr src)
        {
            var dst = text.buffer();
            dst.Append(src.Mnemonic.Format(MnemonicCase.Lowercase));
            var count = src.Operands.Count;
            for(var i=0; i<count; i++)
            {
                if(i == 0)
                    dst.Append(Chars.Space);
                else
                    dst.Append(", ");

                dst.Append(src.Operands[i].ToString());
            }
            return dst.Emit();
        }

        public static string format(in AsmSig src)
        {
            var dst = text.buffer();
            dst.Append(src.Mnemonic.Format(MnemonicCase.Lowercase));
            var count = src.OpCount;
            for(byte i=0; i<count; i++)
            {
                if(i != 0)
                    dst.Append(", ");
                else
                    dst.Append(Chars.Space);

                dst.Append(expression(src[i]).Format());
            }
            return dst.Emit();
        }
    }
}