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

    public class AsmSigRule<T> : RuleExpr
        where T : IRuleExpr
    {
        public AsmMnemonic Mnemonic {get;}

        public Index<AsmSigOpRule<T>> Operands {get;}

        public AsmSigRule(AsmMnemonic mnemonic, byte opcount)
        {
            Mnemonic = mnemonic;
            Operands = alloc<AsmSigOpRule<T>>(opcount);
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

        public AsmSigRule<T> WithOperand(byte index, T operand)
        {
            Operands[index] = operand;
            return this;
        }

        public override string Format()
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

        public override string ToString()
            => Format();
    }
}