//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct AsmParser
    {
        public static Outcome label(string src, out AsmOffsetLabel dst)
        {
            dst = default;
            var result = DataParser.parse(src, out Hex64 value);
            if(result)
                dst = asm.label(bits.effwidth(value), value);
            return result;
        }

        public static Outcome label(string src, out AsmBlockLabel dst)
        {
            var i = text.index(src, Chars.Colon);
            if(i > 0)
            {
                dst = new AsmBlockLabel(text.left(src,i).Trim());
                return true;
            }
            else
            {
                dst = AsmBlockLabel.Empty;
                return false;
            }
        }
    }
}