//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using api = AsmSigs;

    public readonly struct AsmFormExpr : IEquatable<AsmFormExpr>, IComparable<AsmFormExpr>
    {
        readonly public AsmSigExpr Sig;

        public readonly CharBlock36 OpCode;

        [MethodImpl(Inline)]
        public AsmFormExpr(in AsmSigExpr sig, in CharBlock36 oc)
        {
            Sig = sig;
            OpCode = oc;
        }

        public Identifier Identity
            => api.identify(this);

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