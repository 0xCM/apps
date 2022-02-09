//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public readonly struct AsmFormSpec : IComparable<AsmFormSpec>, IEquatable<AsmFormSpec>
    {
        public static Hex32 token(in AsmSigExpr sig, in AsmOpCode oc)
            => alg.hash.combine(alg.hash.marvin(oc.Format()), alg.hash.marvin(sig.Format()));

        public static AsmFormSpec from(AsmFormRecord src)
            => new AsmFormSpec(src.Kind, src.Sig, src.OpCode);

        public readonly Identifier Kind;

        public readonly AsmOpCode OpCode;

        public readonly AsmSigExpr Sig;

        public readonly Hex32 Token;

        public AsmFormSpec(Identifier kind, in AsmSigExpr sig, in AsmOpCode oc)
        {
            Kind = kind;
            Sig = sig;
            OpCode = oc;
            Token = token(sig, oc);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Kind.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Kind.IsNonEmpty;
        }

        public string Format()
            => string.Format("{0}:{1} | {2}", Kind, OpCode, Sig);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Token;

        public int CompareTo(AsmFormSpec src)
        {
            var result = Kind.CompareTo(src.Kind);
            if(result == 0)
                result = OpCode.Format().CompareTo(src.OpCode.Format());
            return result;
        }

        [MethodImpl(Inline)]
        public bool Equals(AsmFormSpec src)
            => Token == src.Token;

        public override bool Equals(object src)
            => src is AsmFormSpec x && Equals(x);

        public static AsmFormSpec Empty => default;
    }
}