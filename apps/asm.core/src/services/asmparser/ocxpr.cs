//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct AsmParser
    {
        [Op]
        public static Outcome ocstring(string src, out AsmOpCodeString dst)
        {
            dst = new AsmOpCodeString(src);
            return true;
        }

        public static Outcome parse(string src, out AsmOpCodeString dst)
        {
            dst = asm.ocstring(src);
            return true;
        }
    }
}
