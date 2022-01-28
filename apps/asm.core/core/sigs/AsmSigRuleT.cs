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

    public class AsmSigRule<T> : AsmSigRule
        where T : IRuleExpr
    {
        public AsmSigRule(AsmMnemonic mnemonic, byte opcount)
            : base(mnemonic, opcount)
        {

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
    }
}