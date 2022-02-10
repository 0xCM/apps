//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct SdmOps
    {
        [Op]
        public static string format(in AsmFormExpr src)
        {
            var mnemonic = src.Sig.Mnemonic.Format(MnemonicCase.Lowercase);
            if(src.Sig.OpCount == 0)
                return string.Format("{0}() = {1}", mnemonic, src.OpCode);
            else
            {
                var buffer = CharBlock64.Empty;
                src.Sig.OperandText(ref buffer);
                return string.Format("{0}({1}) = {2}", mnemonic, buffer.Format().Trim(), src.OpCode);
            }
        }
    }
}