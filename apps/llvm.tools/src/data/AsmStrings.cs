//-----------------------------------------------------------------------------
// Copyright   :  (c) LLVM Project
// License     :  Apache-2.0 WITH LLVM-exceptions
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using Asm;

    using static Root;

    public readonly struct AsmStrings
    {
        public static AsmVariationCode varcode(string inst, AsmMnemonic monic)
        {
            var fmt = monic.Format(MnemonicCase.Uppercase);
            if(text.empty(inst) || text.empty(fmt) || !text.contains(inst,fmt))
                return AsmVariationCode.Empty;
            var candidate = text.remove(inst,fmt);
            return text.nonempty(candidate) ? new AsmVariationCode(candidate) : AsmVariationCode.Empty;
        }

        public static AsmString extract(InstAliasEntity src)
        {
            var dst = AsmString.Empty;
            var name = src.InstName;
            var data = src.AsmStringSource;
            var input = normalize(data);
            dst = new AsmString(name, mnemonic(input), pattern(input), data);
            return dst;
        }

        public static AsmString extract(InstEntity src)
        {
            var dst = AsmString.Empty;
            var name = src.InstName;
            if(src.isCodeGenOnly || src.isPseudo)
                return new AsmString(name, AsmMnemonic.Empty, EmptyString, EmptyString);

            var data = src.AsmStringSource;
            var input = normalize(data);
            dst = new AsmString(name, mnemonic(input), pattern(input), data);
            return dst;
        }

        static string normalize(string src)
            => text.remove(src, Chars.Quote).Replace(Chars.Tab, Chars.Space).Trim();

        static string pattern(string src)
        {
            var input = text.replace(src,"${mask}", "$mask");
            var monic = mnemonic(input).Format();
            var i = text.index(input, Chars.Space);
            if(i == NotFound)
                return monic;
            else
            {
                var right = text.right(input,i);
                if(text.fenced(right, Fencing.Embraced))
                    right = text.unfence(right, 0, Fencing.Embraced);

                var j = text.index(right, Chars.Caret);
                if(j >= 0)
                    right = text.right(right,j);
                return string.Format("{0} {1}", monic, right);
            }
        }

        static AsmMnemonic mnemonic(string src)
        {
            var input = normalize(src);
            var i = text.index(input, Chars.Space);
            if(i == NotFound)
                return input;

            var dst = text.left(input,i);
            var j = text.index(dst,Chars.LBrace);
            if(j>0)
                return text.left(dst,j);
            else
                return dst;
        }
    }
}