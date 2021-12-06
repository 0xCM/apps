//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Bindes an expression with its encoding
    /// </summary>
    public readonly struct AsmStatementEncoding : IEquatable<AsmStatementEncoding>, IComparable<AsmStatementEncoding>
    {
        public uint Seq {get;}

        public AsmExpr Asm {get;}

        public LineNumber Line {get;}

        public Address32 Offset {get;}

        public AsmHexCode Encoding {get;}

        [MethodImpl(Inline)]
        public AsmStatementEncoding(uint seq, AsmExpr asm, LineNumber line, Address32 offset, AsmHexCode code)
        {
            Seq = seq;
            Asm = asm;
            Line = line;
            Offset = offset;
            Encoding = code;
        }

        public bool Equals(AsmStatementEncoding src)
            => Asm.Equals(src.Asm) && Encoding.Equals(src.Encoding);

        public int CompareTo(AsmStatementEncoding src)
            => Encoding.CompareTo(src.Encoding);

        public override bool Equals(object src)
            => src is AsmStatementEncoding x && Equals(x);

        public override int GetHashCode()
            => (int)alg.hash.combine(Asm.GetHashCode(), Encoding.GetHashCode());
    }
}