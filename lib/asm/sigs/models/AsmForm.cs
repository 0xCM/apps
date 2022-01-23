//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AsmForm : IEquatable<AsmForm>, IComparable<AsmForm>
    {
        readonly public AsmSigExpr Sig;

        public readonly CharBlock36 OpCode;

        [MethodImpl(Inline)]
        public AsmForm(in AsmSigExpr sig, in CharBlock36 oc)
        {
            Sig = sig;
            OpCode = oc;
        }

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

        public int CompareTo(AsmForm src)
            =>  Text.CompareTo(src.Text);

        public bool Equals(AsmForm src)
            => Text.Equals(src.Text);

        public override int GetHashCode()
            => (int)Hash;

        public override bool Equals(object obj)
            => obj is AsmForm x && Equals(x);
    }
}