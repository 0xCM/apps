//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public readonly struct AsmFormExpr : IEquatable<AsmFormExpr>, IComparable<AsmFormExpr>
    {
        public static Identifier identify(in AsmFormExpr src)
        {
            var dst = text.buffer();
            ref readonly var sig = ref src.Sig;
            dst.Append(sig.Mnemonic.Format(MnemonicCase.Lowercase));
            var ops = sig.Operands();
            var count = ops.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var op = ref skip(ops,i);
                dst.Append(Chars.Underscore);
                dst.Append(text.replace(op.Text, Chars.Colon, Chars.x));
            }

            return dst.Emit();
        }
        readonly public AsmSigExpr Sig;

        public readonly CharBlock36 OpCode;

        [MethodImpl(Inline)]
        public AsmFormExpr(in AsmSigExpr sig, in CharBlock36 oc)
        {
            Sig = sig;
            OpCode = oc;
        }

        public Identifier Identity
            => identify(this);

        public string Text
            => string.Format("{0} {1}", Sig, OpCode);

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => alg.hash.marvin(Text);
        }

        public string Format()
            => Text;

        public override string ToString()
            => Format();

        public int CompareTo(AsmFormExpr src)
            =>  Text.CompareTo(src.Text);

        public bool Equals(AsmFormExpr src)
            => Text.Equals(src.Text);

        public override int GetHashCode()
            => (int)Hash;

        public override bool Equals(object obj)
            => obj is AsmFormExpr x && Equals(x);
    }
}