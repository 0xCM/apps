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
            var raw = src.RawAsmString;
            var input = normalize(raw);
            var m0 = mnemonic(input);
            var p0 = pattern(input);
            dst = new AsmString(name, m0, p0, raw);
            return dst;
        }

        public static AsmString extract(InstEntity src)
        {
            var dst = AsmString.Empty;
            var name = src.InstName;
            if(src.isCodeGenOnly || src.isPseudo)
                return new AsmString(name, AsmMnemonic.Empty, EmptyString, EmptyString);

            var raw = src.RawAsmString;
            var input = normalize(raw);
            var m0 = mnemonic(input);
            var p0 = pattern(input);
            dst = new AsmString(name, m0, p0, raw);
            return dst;
        }

        static string normalize(string src)
            => text.remove(src, Chars.Quote).Replace(Chars.Tab, Chars.Space).Trim();

        static string pattern(string src)
        {
            var monic = mnemonic(src).Format();
            var i = text.index(src, Chars.Space);
            if(i == NotFound)
                return monic;
            else
            {
                var right = text.right(src,i);
                if(text.fenced(right, Fencing.Embraced))
                    right = text.unfence(right, 0, Fencing.Embraced);

                var j = text.index(right, Chars.Caret);
                if(j >= 0)
                    right = text.right(right,j);
                right = text.replace(right,"${mask}", "$mask");
                return string.Format("{0} {1}", monic, right);
            }
        }

        static AsmMnemonic mnemonic(string src)
        {
            var input = normalize(src);
            var i = text.index(src, Chars.Space);
            var dst = input;
            if(i >=0)
            {
                var left = text.left(input,i);
                var j = text.index(left, Chars.LBrace);
                if(j >= 0)
                    dst = text.left(left,j);
                else
                    dst = left;
            }
            return dst;
        }
    }
}