//-----------------------------------------------------------------------------
// Copyright   :  (c) LLVM Project
// License     :  Apache-2.0 WITH LLVM-exceptions
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System.Runtime.CompilerServices;

    using static Root;
    using Asm;

    using SQ = SymbolicQuery;

    public readonly struct AsmStrings
    {
        static Pair<string>[] Repl = new Pair<string>[]{
            ("\"", ""),
            ("$dst", "$(dst)"),
            ("${dst}","$(dst)"),
            ("${mask}","$(mask)"),
            ("$src1","$(src1)"),
            ("${src1}","$(src1)"),
            ("$src2","$(src2)"),
            ("${src2}","$(src2)"),
            ("$src3","$(src3)"),
            ("${src3}","$(src3)"),
            ("$src5","$(src5)"),
            ("$src","$(src)"),
            ("$cntl","$(cntl)"),
            ("$op","$(op)"),
            ("$cc","$(cc)"),
            ("$mask","$(mask)"),
            ("$len","$(len)"),
            ("$idx","$(idx)"),
            ("$port","$(port)"),
            ("$cnt","$(cnt)"),
            ("$reg","$(reg)"),
            ("$seg","$(seg)"),
            ("$off","$(off)"),
            ("$imm","$(imm)"),
            ("$addr","$(addr)"),
            ("$val", "$(val)"),
            ("$mem", "$(mem)"),
            ("$rc","$(rc)"),
            ("$r1", "$(r1)"),
            ("$r2", "$(r2)"),
            ("$r", "$(r)"),
            ("$zero", "$(zero)"),
            ("$amt", "$(amt)"),
            ("$trap", "$(trap)"),
            ("$ptr", "$(ptr)"),
            ("$cond", $"(cond)"),
            ("PSEUDO!",""),
            ("#ADJCALLSTACKDOWN", ""),
            ("#ADJCALLSTACKUP", "")

            };

        public static AsmVariationCode varcode(string inst, AsmMnemonic monic)
        {
            var fmt = monic.Format(MnemonicCase.Uppercase);
            if(text.empty(inst) || text.empty(fmt) || !text.contains(inst,fmt))
                return AsmVariationCode.Empty;
            var candidate = text.remove(inst,fmt);
            return text.nonempty(candidate) ? new AsmVariationCode(candidate) : AsmVariationCode.Empty;
        }

        static string pattern(string src)
        {
            var monic = AsmStrings.mnemonic(src).Format();
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

        public static AsmString extract(InstEntity inst)
        {
            var dst = AsmString.Empty;
            var name = inst.InstName;
            if(inst.isCodeGenOnly || inst.isPseudo)
            {
                dst = new AsmString(name, AsmMnemonic.Empty, EmptyString, EmptyString);
            }
            else
            {
                var raw = inst.RawAsmString;
                var input = text.remove(raw, Chars.Quote).Replace(Chars.Tab, Chars.Space).Trim();
                var m0 = AsmStrings.mnemonic(input);
                var p0 = pattern(input);
                dst = new AsmString(name, m0, p0, raw);
            }
            return dst;
        }

        public static AsmMnemonic mnemonic(string src)
        {
            var input = text.remove(src, Chars.Quote).Replace(Chars.Tab, Chars.Space).Trim();
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

        public static string normalize(string value)
        {
            var dst = value;
            dst = text.normalize(dst, Repl).Trim();
            var ws = SQ.wsindex(dst);
            if(ws != NotFound)
            {
                var monic = mnemonic(text.left(dst, ws));
                dst = text.right(dst, ws);
                var length = dst.Length;
                if(length > 0)
                {
                    if(dst[0] == Chars.LBrace && dst[length - 1] == Chars.RBrace)
                        dst = text.inside(dst,0, length - 1);

                    var k = text.index(dst, Chars.Caret);
                    if(k != NotFound)
                    {
                        dst = text.right(dst, k);
                        var j = text.index(dst, Chars.RBrace);
                        if(j != NotFound)
                            dst = EmptyString;
                    }
                    else
                    {
                        var m = text.index(dst, Chars.RBrace);
                        if(m != NotFound)
                            dst = text.left(dst,m);

                        var n = text.index(dst, Chars.LBrace);
                        if(n != NotFound)
                            dst = text.left(dst,Chars.LBrace);
                    }
                }
                dst = string.Format("{0} {1}", monic, dst);
            }
            else
                dst = mnemonic(dst).Format();
            return dst;
        }
    }
}