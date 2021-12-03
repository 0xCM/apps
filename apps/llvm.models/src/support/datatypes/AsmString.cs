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
            ("$rc","$(rc)"),
            };

        public static AsmMnemonic mnemonic(string value)
        {
            static string cleanse(string src)
            {
                var i = text.index(src, Chars.LBrace);
                var j = text.index(src, Chars.RBrace);
                if(i == NotFound || j == NotFound || j<=i)
                    return src;
                var content = text.inside(src,i,j);
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
            var ws = SQ.wsindex(value);
            if(ws != NotFound)
                dst = text.right(value, ws);
            dst = text.normalize(dst, Repl).Trim();
            var length = dst.Length;
            if(length > 0)
            {
                if(dst[0] == Chars.LBrace && dst[length - 1] == Chars.RBrace)
                    dst = text.inside(dst,0, length - 1);
                var k = text.index(dst,Chars.Caret);
                if(k != NotFound)
                    dst = text.right(dst,k);
            }
            return dst;
        }

        readonly AsciBlock64 Content;

        [MethodImpl(Inline)]
        public AsmString(string src)
        {
            Content = src;
        }

        public string Format()
            => Content.Format().Trim();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AsmString(string src)
            => new AsmString(src);
    }
}