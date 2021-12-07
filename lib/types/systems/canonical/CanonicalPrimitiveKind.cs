//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using PN = CanonicalSpecs;

    [SymSource("canonical")]
    public enum CanonicalPrimitiveKind : uint
    {
        [Symbol(PN.U, "Designates an unsigned integral type of bounded parametric width")]
        U,

        [Symbol(PN.I, "Designates a signed integral type of bounded parametric width")]
        I,

        [Symbol(PN.C, "Designates a character type type of constrained parametric width of 8, 16 or 32")]
        C,

        [Symbol(PN.Ct, "Designates a parametric character type of constrained parametric width of 8, 16 or 32")]
        Ct,

        [Symbol(PN.F, "Designates a floating-point type of constrained parametric width of 16, 32, 64 or 128")]
        F,

        [Symbol(PN.V, "Designates a vector type, parametric in both width and constrained cell type")]
        V,

        [Symbol(PN.S, "Designates a character string type of arbitrary lenth over a supported character type")]
        S,

        [Symbol(PN.St, "Designates a character string type of arbitrary lenth over a parametric type that corresponds to a subset of supported character types")]
        St,

        [Symbol(PN.Sn, "Designates a character string type of parametric lenth")]
        Sn,

        [Symbol(PN.Snt, "Designates a character string type of parametric lenth and character type")]
        Snt,

        [Symbol(PN.Bit, "Designates a type of bit-width 1")]
        Bit,

        [Symbol(PN.Bits, "Designates a sequence of bits of length bounded by a parametric type")]
        Bits,

        [Symbol(PN.BitsN, "Designates a sequence of bits of paramtric length and type")]
        BitsN,

        [Symbol(PN.Bv, "Designates a bitvector of bounded parametric width")]
        BV,

        [Symbol(PN.Seq, "Designates a sequence of arbitry length over a parametric type")]
        Seq,

        [Symbol(PN.SeqN, "Designates a sequence of parametric length over a parametric type")]
        SeqN,
    }
}