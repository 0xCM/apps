//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;
    using static core;

    public class AsmSigExpr<T>
    {
        public AsmMnemonic Mnemonic {get;}

        public Index<T> Operands {get;}

        public AsmSigExpr(AsmMnemonic mnemonic, params T[] ops)
        {
            Mnemonic = mnemonic;
            Operands = ops;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Mnemonic.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Mnemonic.IsNonEmpty;
        }

        public string Format()
        {
            var dst = text.buffer();
            dst.Append(Mnemonic.Format(MnemonicCase.Lowercase));
            var count = Operands.Count;
            for(var i=0; i<count; i++)
            {
                if(i == 0)
                    dst.Append(Chars.Space);
                else
                    dst.Append(", ");

                dst.Append(Operands[i].ToString());
            }
            return dst.Emit();
        }
    }
}