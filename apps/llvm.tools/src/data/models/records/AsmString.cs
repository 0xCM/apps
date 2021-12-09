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

    public readonly struct AsmString
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

        /// <summary>
        /// Attempts to infer the instruction mnemonic from an asmstring
        /// </summary>
        /// <param name="value">The source value</param>
        public static AsmMnemonic mnemonic(string value)
        {
            static string cleanse(string src)
            {
                var i = text.index(src, Chars.LBrace);
                var j = text.index(src, Chars.RBrace);
                if(i == NotFound || j == NotFound || j<=i)
                    return src;

                var content = text.inside(src, i, j);
                var k = text.index(content, Chars.Caret);
                if(k == NotFound)
                    return text.left(src, i);

                var suffix = text.right(content,k);
                return text.left(src,i) + suffix;
            }

            var mnemonic = text.remove(value,Chars.Quote);
            var ws = SQ.wsindex(mnemonic);
            if(ws != NotFound)
                mnemonic = text.remove(text.left(mnemonic, ws), Chars.Quote);

            return cleanse(mnemonic);
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

        readonly string Content;

        public string Text
        {
            [MethodImpl(Inline)]
            get => Content ?? EmptyString;
        }

        [MethodImpl(Inline)]
        public AsmString(string src)
        {
            Content = src;
        }

        public string Format()
            => Text;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AsmString(string src)
            => new AsmString(src);
    }
}