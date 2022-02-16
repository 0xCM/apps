//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public readonly struct AsmParser
    {
        [Parser]
        public static Outcome parse(string src, out AsmMnemonic dst)
        {
            dst = src;
            return true;
        }

        [Parser]
        public static Outcome parse(string src, out AsmExpr dst)
        {
            dst = text.trim(src);
            return true;
        }

        [Parser]
        public static Outcome parse(string src, out AsmHexCode dst)
        {
            dst = AsmHexCode.parse(src);
            return true;
        }
    }
}
