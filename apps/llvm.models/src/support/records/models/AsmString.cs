//-----------------------------------------------------------------------------
// Copyright   :  (c) LLVM Project
// License     :  Apache-2.0 WITH LLVM-exceptions
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System.Runtime.CompilerServices;

    using static Root;

    using SQ = SymbolicQuery;

    public readonly struct AsmString
    {
        static Pair<string>[] Repl = new Pair<string>[]{
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
            };

        public static AsciBlock64 format(string value)
        {
            var ws = SQ.wsindex(value);
            var dst = EmptyString;
            if(ws != NotFound)
                dst = text.right(text.unfence(text.remove(text.trim(text.right(value,ws)), Chars.Quote),0, Fencing.Embraced),Chars.Caret);
            else
                dst = text.remove(value,Chars.Quote);

            return text.normalize(dst, Repl);
        }

        public static AsciBlock32 mnemonic(string value)
        {
            var mnemonic = text.remove(value,Chars.Quote);
            var ws = SQ.wsindex(mnemonic);
            if(ws != NotFound)
                mnemonic = text.remove(text.left(mnemonic, ws), Chars.Quote);
            // if(text.contains(mnemonic, Chars.LBrace) && text.contains(mnemonic, Chars.RBrace))
            // {
            //     var i = text.index(mnemonic, Chars.LBrace);
            //     var left = text.left(mnemonic,i);
            //     var content = text.unfence(mnemonic, 0, Fencing.Embraced);
            //     var j = text.index(content, Chars.Caret);
            //     if(j != NotFound)
            //     {
            //         var right = text.right(content,j);
            //         if(core.nonempty(right))
            //             mnemonic = left + right;
            //     }
            //     else
            //         mnemonic = left;
            // }
            return mnemonic;
        }

        readonly AsciBlock64 Content;

        [MethodImpl(Inline)]
        public AsmString(string src)
        {
            Content = src;
        }

        public string Format()
            => Content.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AsmString(string src)
            => new AsmString(src);
    }
}